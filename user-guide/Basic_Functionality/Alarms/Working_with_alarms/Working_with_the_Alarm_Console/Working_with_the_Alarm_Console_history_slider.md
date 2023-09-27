---
uid: WorkingWithTheAlarmConsoleHistorySlider
---

# Working with the Alarm Console history slider

In the Alarm Console, you can display a timeline at the bottom of the *Active alarms* tab. To do so, click the *History slider* button in the alarm bar: ![history slider button](~/user-guide/images/History_Slider_button.png)

> [!TIP]
> See also: [Alarm Console – Alarm history](https://community.dataminer.services/video/alarm-console-alarm-history/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Active alarms tab timeline

The timeline in the *Active alarms* tab shows the alarms that were active at a particular point in time.

There are two ways to move the slider to a specific time in the past on the timeline:

- By dragging the slider across the timeline. The date and time where the slider is located are displayed to the right of it.

- By clicking the clock icon and specifying a date and time.

## Advanced timeline settings

- With the SLNetClientTest tool, you can configure some advanced settings for the timeline configuration. See [Configuring how long alarm statistics are kept in memory](xref:SLNetClientTest_configuring_how_long_alarm_statistics).

  > [!WARNING]
  > The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

  The following settings are available:

  - **ActiveAlarmStatsTimeToKeep**: Time range of most recent active alarm statistics to keep in memory. Default: 2 days.

  - **ActiveAlarmStatsExpirationTime**: The amount of time that requested time ranges other than the most recent one will stay in memory (if unused). Default: 10 minutes.

- How long alarm data remain available to be displayed in the history slider depends on the database configuration. For more information, see [Specifying TTL overrides](xref:Specifying_TTL_overrides).
