<x-layouts.app :title="__('Sensorübersicht')">
    <div class="mb-6">
        <!-- Id Dynamisieren -->
        <h1>Sensor: {{$sensor->sensorNr}} </h1>
    </div>
    <div class="flex h-full w-full flex-1 flex-col gap-4 rounded-xl">
        <div class="w-full grid auto-rows-min gap-4 md:grid-cols-2 border border-color rounded-xl">
            <div>
                <h2>Sensor Informationen</h2>
                <div class="border border-color rounded-xl m-5 p-5">
                    <div>
                        <table class="table-auto w-3/4 text-left">
                            <tr>
                                <td class="font-bold">Durchschnittstemperatur:</td>
                                <td>{{$averageTemperature}} °C</td>
                            </tr>
                            <tr>
                                <td class="font-bold">Maximaltemperatur:</td>
                                <td>{{$sensor->maxTemp}}</td>
                            </tr>
                            <tr>
                                <td class="font-bold">Addresse:</td>
                                <td>{{$sensor->address}}</td>
                            </tr>
                            <tr>
                                <td class="font-bold">Serverschrank:</td>
                                <td>{{$sensor->serverRack}}</td>
                            </tr>
                        </table>
                    </div>

                </div>
            </div>
            <div>
                <h2>Hersteller Informationen</h2>
                <div class="border border-color rounded-xl m-5 p-5">
                    <div>
                        <table class="table-auto w-3/4 text-left">
                            <tr>
                                <td class="font-bold">ID:</td>
                                <td>{{$manufacturer->manufacturerId}}</td>
                            </tr>
                            <tr>
                                <td class="font-bold">Name:</td>
                                <td>{{$manufacturer->manufacturerName}}</td>
                            </tr>
                            <tr>
                                <td class="font-bold">Addresse:</td>
                                <td>{{$manufacturer->address}}</td>
                            </tr>
                            <tr>
                                <td class="font-bold">Telefonnummer:</td>
                                <td>{{$manufacturer->phoneNumber}}</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="grid auto-rows-min gap-4 md:grid-cols-2">
            <div class="relative aspect-video rounded-xl border border-neutral-200 dark:border-neutral-700">
                <h2>10 letzten Temperaturen</h2>
                <div class="mx-5">
                    <ul class="table-custom-overview">
                        @foreach($temperatures as $temperature)
                            <li class="flex justify-between border border-b-0 border-neutral-200 dark:border-neutral-700 p-2">
                                <div>
                                    {{ \Carbon\Carbon::parse($temperature->time)->format('H:i') }} Uhr
                                </div>
                                <div>
                                    <div>{{$temperature->temperatureValue}} °C</div>
                                </div>
                            </li>
                        @endforeach
                    </ul>
                </div>
            </div>

            <div class="relative aspect-video rounded-xl border border-neutral-200 dark:border-neutral-700">
                <h2>Maximal Temperatur ändern</h2>
                <div class="border border-color rounded-xl m-5 p-5">
                    <form action="{{ route('sensors.update-max-temp', $sensor->sensorNr) }}" method="POST">
                        @csrf
                        @method('PUT')

                        <div class="mb-4">
                            <label for="maxTemp" class="block font-medium mb-2">Neue Maximaltemperatur (°C):</label>
                            <input type="number" name="maxTemp" id="maxTemp"
                                   class="w-full px-3 py-2 border border-gray-300 rounded-md"
                                   value="{{ $sensor->maxTemp }}" step="0.1" required>
                        </div>

                        <div class="mt-4">
                            <button type="submit" class="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700">
                                Temperatur aktualisieren
                            </button>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </div>
</x-layouts.app>
