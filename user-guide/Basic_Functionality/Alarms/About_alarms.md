---
uid: About_alarms
---

# About alarms

Your DataMiner System continuously retrieves a wide variety of parameter values from all elements. When a parameter is monitored, each time a value is retrieved from an element, that value is compared to a user-defined threshold. Each time that threshold is violated, the DataMiner System will generate an alarm.

Different [types of alarms](xref:Alarm_types) exist in DataMiner. [Hysteresis](xref:Alarm_hysteresis) can also be configured on alarms, so they are not triggered or not cleared immediately, depending on the type of hysteresis. Different alarm records can be [linked](xref:Alarm_linking) to each other in one so-called alarm tree. To determine when an alarm is triggered, alarm thresholds are configured in a so-called [alarm template](xref:About_alarm_templates).

The most important tool to manage alarms in DataMiner is the [Alarm Console](xref:Working_with_the_Alarm_Console). This console is by default displayed at the bottom of the client user interface.

> [!TIP]
> See also: [Rui’s Rapid Recap – Alarm Console introduction](https://community.dataminer.services/video/ruis-rapid-recap-alarm-console-introduction/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
