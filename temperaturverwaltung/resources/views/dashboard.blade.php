<x-layouts.app :title="__('Dashboard')">
    <div class="mb-6">
        <h1>Dashboard</h1>
    </div>
    <div class="flex h-full w-full flex-1 flex-col gap-4 rounded-xl">
        <div class="grid auto-rows-min gap-4 md:grid-cols-2">
            <div class="relative aspect-video rounded-xl border border-neutral-200 dark:border-neutral-700">
                <h2>Sensorübersicht</h2>
                <div class="mx-5">
                    <ul class="table-custom">
                        @foreach ($sensors as $sensor)
                            <li class="flex justify-between border border-b-0 border-neutral-200 dark:border-neutral-700 p-2">
                                <div>
                                    <div>
                                        <span class="font-bold">Sonsor:</span> {{ $sensor->sensorNr}}
                                    </div>
                                    <div>
                                        <span class="font-bold">Seververschrank:</span> {{$sensor->serverRack}}
                                    </div>
                                </div>
                                <div>
                                    <div>
                                        <span class="font-bold">Wert:</span> {{$temperatures[$sensor->sensorNr]->temperatureValue ?? 'N/A'}} °C
                                    </div>
                                    <div>Letzte Aktualisierung: 10min</div>
                                </div>
                            </li>
                        @endforeach
                    </ul>
                </div>
            </div>

            <div class="relative aspect-video overflow-hidden">
                <div class="rounded-xl border border-neutral-200 dark:border-neutral-700 mb-4">
                    <h2>kritische Sensoren</h2>
                    <div class="mx-5 mb-5">
                        <!-- Foreach durchgehen kritische Sensoren -> Max Temp. Dynamisch-->
                        <ul class="table-custom-critical">
                            @foreach($criticalTemperatures as $criticalTemperature)
                                <li>
                                    <div>
                                        <div>
                                            <span class="font-bold">Sensor:</span> {{ $criticalTemperature->sensorNr }}
                                        </div>
                                        <div>
                                            <span class="font-bold">Seververschrank:</span> {{$criticalTemperature->serverRack}}
                                        </div>
                                    </div>
                                    <div>
                                        <div>
                                            <span class="font-bold">Wert:</span> {{$criticalTemperature->temperatureValue}} °C
                                        </div>

                                        <!-- TODO: Soll dies noch mit rein? -->
                                        <div>Letzte Aktualisierung: 10min</div>
                                    </div>
                                </li>
                            @endforeach
                        </ul>
                    </div>
                </div>

                <div class="rounded-xl border border-neutral-200 dark:border-neutral-700">
                    <h2>Log-Tabelle</h2>
                </div>
            </div>
        </div>
    </div>
</x-layouts.app>
