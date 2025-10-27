---
uid: Monitoring_app_Alarm_Console
---

# Monitoring app Alarm Console

A collapsible Alarm Console pane at the bottom of the Monitoring app UI provides an overview of the alarms in the DMS, similar to the Alarm Console in Cube.

- By default, the Alarm Console is collapsed and only the alarm bar is displayed, showing the total number of active alarms and the total number of active alarms for each severity.

- Clicking or tapping the bar shows the Alarm Console pane, with the three default alarm tabs: active alarms, information events and masked alarms.

    > [!NOTE]
    > Only 1000 information events can be displayed in the app. If 1000 information events are displayed and another event enters the system, the oldest 100 events will no longer be displayed.

- Clicking or tapping the alarm counter for a particular severity in the alarm bar filters the *Active alarms* tab to only show alarms with that severity.

- Clicking or tapping an alarm opens an alarm card with detailed information.

- You can also navigate directly to an alarm card by using the following URL:
<br>*http://*\<DMA IP>*/monitoring/alarm/*\<DMA ID>*/*\<alarm ID>
