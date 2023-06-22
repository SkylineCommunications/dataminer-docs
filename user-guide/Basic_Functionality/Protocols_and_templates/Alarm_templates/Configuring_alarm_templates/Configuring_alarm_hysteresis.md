---
uid: Configuring_alarm_hysteresis
---

# Configuring hysteresis in an alarm template

Two types of [hysteresis](xref:Alarm_hysteresis) are available, clear hysteresis and alarm hysteresis, respectively having an effect on the clearing and on the triggering of alarms:

- Enter a value in the *Hyst off* column to determine the number of seconds before the severity level of an alarm decreases.

- Enter a value in the *Hyst on* column to determine the number of seconds before the severity level of an alarm increases.

- If you want to apply hysteresis to specific severity levels only, when you enter a value in the *Hyst off* or *Hyst on* box, select the severity levels in the drop-down list below the box.

> [!NOTE]
>
> - For most parameters, the hysteresis interval has to be higher than the polling interval. For example, if a parameter is only polled every 10 seconds, you should not configure a hysteresis interval of 5 seconds. However, an exception to this are parameters updated via traps or via a smart-serial connection.
> - For parameters of type string, hysteresis should only be applied to "high" severity levels (e.g. Warning High, Major High), not to "low" severity levels. From DataMiner 10.1.9/10.2.0 onwards, applying hysteresis to "low" severity levels is no longer possible for string parameters.

> [!TIP]
> See also: [Alarm templates – Hysteresis](https://community.dataminer.services/video/alarm-templates-hysteresis/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
