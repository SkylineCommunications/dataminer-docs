---
uid: Setting_the_offline_window_for_an_SLA
---

# Setting the offline window for an SLA

It is possible to define a recurring window during which the service will be considered offline. Alarms raised during that window will not affect the SLA, except those associated with parameters that have explicitly been allowed to disregard the offline window settings.

To configure an SLA offline window:

1. In DataMiner Cube, go to the *Offline Window* page of the SLA element.

1. Click the button *Add Entry* to add an entry to the table.

1. Specify the following information for the new entry:

   - **Offline Window Start Day**:

     The day of the week on which the offline window occurs.

   - **Offline Window Start Time**:

     The start time of the offline window, in the format XX hours XX minutes.

   - **Offline Window End Time**:

     The end time of the offline window, in the format XX hours XX minutes.

   - **Offline Window State**:

     *Disabled* or *Enabled*, or *Delete* if you wish to remove the entry.

> [!NOTE]
>
> - The weight of alarms that occurred prior to a change to this setting will not be recalculated retroactively. We therefore recommend resetting the SLA after changing this setting.
> - Be careful when setting the offline window start and end times. If you set an end time that is invalid, because it occurs before the start time, the end time will be reset to the default time of 23:59. Likewise, if you set a start time that occurs after the end time, the start time will be reset to the default time of 00:00.
> - From version 3.0.0 of the *Skyline SLA Definition Basic* protocol onwards, it is possible to hide outages that occur in the offline window. To do so, on the *Advanced Configuration* page, set *Offline Window Outages* to *Hide*. Note that you need at least security level 3 to change any of the settings on the *Advanced Configuration* page.
> - For more information on how to set a particular parameter to have an impact during the offline window, see [Creating an information template](xref:Creating_an_information_template).
