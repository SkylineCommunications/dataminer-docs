---
uid: Changing_the_spectrum_analyzer_settings
---

# Changing the spectrum analyzer settings

With the settings pane on the right side of the card, you can change the settings that determine what trace is retrieved. The trace window is then immediately updated according to the changes.

In the *Settings* pane, in the tab *Manual \> Settings* Spectrum analyzer settings, you can modify the settings like any other parameter in Cube. Just enter or select the new value, and click the green tick mark. If you want to modify several settings at the same time, you can also specify the new values and then click *Apply all* below the list of settings.

The table below describes the settings available in most spectrum elements. Depending on the protocol, however, different settings may be available.

| Setting              | Description                                                                                                                                                                                                                     |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Reference level      | The amplitude reference level. Different units can be selected for the value you enter, e.g. dBm, dBmV, mV.                                                                                                                     |
| Amplitude scale      | The scale used in the real-time display. Select a different value to change the size of each square in the grid.                                                                                                                |
| Start frequency      | The start frequency of the displayed frequency span. Different units can be selected for the value you enter, e.g. kHz, GHz.                                                                                                    |
| Stop frequency       | The stop frequency of the displayed frequency span. Different units can be selected for the value you enter, e.g. kHz, GHz.                                                                                                     |
| Frequency span       | The range between the start and stop frequencies. Can be set to 0 to enter zero-span mode.                                                                                                                                      |
| Center frequency     | The frequency in the middle of the display’s frequency axis. Different units can be selected for the value you enter, e.g. kHz, GHz.                                                                                            |
| Resolution bandwidth | RBW filter. Can be set to auto, or to a custom value that can be selected in the drop-down list.                                                                                                                                |
| Video bandwidth      | VBW filter. Can be set to auto, or to a custom value that can be selected in the drop-down list.                                                                                                                                |
| Sweeptime            | The time that the analyzer takes to tune across the displayed frequency span. Can either be set to auto by selecting the checkbox, or to a custom value by clearing the checkbox and selecting the value in the drop-down list. |
| Input attenuation    | Enter a value here to amplify or lower the signal strength at the input of the spectrum analyzer, in order to improve measuring accuracy.                                                                                       |

> [!NOTE]
>
> - Either *Start frequency* and *Stop frequency* or *Frequency span* and *Center frequency* are used in order to determine the frequency settings. Only one of these pairs should be used. If both are used, priority is given to *Start frequency* and *Stop frequency*, and *Frequency span* and *Center frequency* will not work properly.
> - If at the top of the settings panel “(From device)” is displayed, the settings have been loaded from the device. This happens when the spectrum element is configured to follow the device settings (see [Configuring a spectrum element to follow the device settings](xref:Configuring_a_spectrum_element_to_follow_the_device_settings)).
> - From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards<!--RN 37601-->, you can change the resolution bandwidth (RBW) and the video bandwidth (VBW) in the info pane, to the left of the real-time display on the spectrum analyzer card, by clicking the plus ("+") and minus ("-") buttons.
