<?php

use Illuminate\Support\Facades\Route;
use Laravel\Fortify\Features;
use Livewire\Volt\Volt;

Route::get('/', function () {
    return view('welcome');
})->name('home');

/*Route::view('dashboard', 'dashboard')
    ->middleware(['auth', 'verified'])
    ->name('dashboard');*/

Route::get('dashboard', function () {
    $sensors = \Illuminate\Support\Facades\DB::table('sensors')->get();

    $temperatures = \Illuminate\Support\Facades\DB::table('temperatures')
        ->select('sensorNr', \Illuminate\Support\Facades\DB::raw('MAX(time) as latest_time'))
        ->groupBy('sensorNr')
        ->get()
        ->mapWithKeys(function ($item) {
            $latestTemperature = \Illuminate\Support\Facades\DB::table('temperatures')
                ->where('sensorNr', $item->sensorNr)
                ->where('time', $item->latest_time)
                ->first();
            return [$item->sensorNr => $latestTemperature];
        });

    $criticalTemperatures = \Illuminate\Support\Facades\DB::table('sensors')
        ->join('temperatures', 'sensors.sensorNr', '=', 'temperatures.sensorNr')
        ->whereIn('temperatures.time', function($query) {
            $query->select(\Illuminate\Support\Facades\DB::raw('MAX(time)'))
                ->from('temperatures')
                ->groupBy('sensorNr');
        })
        ->whereRaw('temperatures.temperatureValue >= sensors.maxTemp')
        ->select('sensors.*', 'temperatures.temperatureValue', 'temperatures.time')
        ->get();
    return view('dashboard', [
        'sensors' => $sensors,
        'temperatures' => $temperatures,
        'criticalTemperatures' => $criticalTemperatures
    ]);
})
    ->middleware(['auth', 'verified'])
    ->name('dashboard');

Route::get('sensors/{sensorNr}', function ($sensorNr) {
    $sensor = \Illuminate\Support\Facades\DB::table('sensors')
        ->where('sensorNr', $sensorNr)
        ->first();

    $manufacturer = \Illuminate\Support\Facades\DB::table('manufacturers')
        ->where('manufacturerId', $sensor->manufacturerId)
        ->first();

    $temperature = \Illuminate\Support\Facades\DB::table('temperatures')
        ->where('sensorNr', $sensorNr)
        ->orderBy('time', 'desc')
        ->limit(10)
        ->get();

    $averageTemperature = $temperature->avg('temperatureValue');

    if (!$sensor) {
        abort(404);
    }

    return view('sensor-overview', [
        'sensor' => $sensor,
        'manufacturer' => $manufacturer,
        'temperatures' => $temperature,
        'averageTemperature' => $averageTemperature
        ]
    );
})
    ->middleware(['auth', 'verified'])
    ->name('sensors');






Route::middleware(['auth'])->group(function () {
    Route::redirect('settings', 'settings/profile');

    Volt::route('settings/profile', 'settings.profile')->name('profile.edit');
    Volt::route('settings/password', 'settings.password')->name('password.edit');
    Volt::route('settings/appearance', 'settings.appearance')->name('appearance.edit');

    Volt::route('settings/two-factor', 'settings.two-factor')
        ->middleware(
            when(
                Features::canManageTwoFactorAuthentication()
                    && Features::optionEnabled(Features::twoFactorAuthentication(), 'confirmPassword'),
                ['password.confirm'],
                [],
            ),
        )
        ->name('two-factor.show');
});

require __DIR__.'/auth.php';
