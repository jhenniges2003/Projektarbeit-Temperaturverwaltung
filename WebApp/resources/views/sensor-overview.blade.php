<x-layouts.app :title="__('Sensorübersicht')">
    <div class="mb-6">
        <!-- Id Dynamisieren -->
        <h1>Sensor: </h1>
    </div>
    <div class="flex h-full w-full flex-1 flex-col gap-4 rounded-xl">
        <div class="w-full grid auto-rows-min gap-4 md:grid-cols-2 border border-color rounded-xl">
            <div>
                <h2>Sensor Informationen</h2>
                <div class="border border-color rounded-xl m-5 p-5">
                    <div>
                        <div>
                            Durchschnittstemperatur:
                        </div>
                        <div>
                            Maximaltemperatur:
                        </div>
                        <div>
                            Addresse:
                        </div>
                        <div>
                            Serverschrank:
                        </div>
                    </div>

                </div>
            </div>
            <div>
                <h2>Hersteller Informationen</h2>
                <div class="border border-color rounded-xl m-5 p-5">
                    <div>
                        <div>
                            Durchschnittstemperatur:
                        </div>
                        <div>
                            Maximaltemperatur:
                        </div>
                        <div>
                            Addresse:
                        </div>
                        <div>
                            Serverschrank:
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="grid auto-rows-min gap-4 md:grid-cols-2">
            <div class="relative aspect-video rounded-xl border border-neutral-200 dark:border-neutral-700">
                <h2>10 letzten Temperaturen</h2>
                <div class="mx-5">
                    <!-- Foreach durchgehen Sensoren-->
                    <ul>
                        <li class="flex justify-between items-center border border-b-0 rounded-t-xl border-neutral-200 dark:border-neutral-700 p-2">
                            <div>
                                12:00 Uhr
                            </div>
                            <div>
                                <div>23°C</div>
                            </div>
                        </li>
                        <li class="flex justify-between border border-b-0 border-neutral-200 dark:border-neutral-700 p-2">
                            <div>
                                12:30 Uhr
                            </div>
                            <div>
                                <div>23°C</div>
                            </div>
                        </li>
                        <li class="flex justify-between border rounded-b-xl border-neutral-200 dark:border-neutral-700 p-2">
                            <div>
                                13:00 Uhr
                            </div>
                            <div>
                                <div>23°C</div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="relative aspect-video rounded-xl border border-neutral-200 dark:border-neutral-700">
                <h2>Maximal Temperatur ändern</h2>

            </div>
        </div>
    </div>
</x-layouts.app>
