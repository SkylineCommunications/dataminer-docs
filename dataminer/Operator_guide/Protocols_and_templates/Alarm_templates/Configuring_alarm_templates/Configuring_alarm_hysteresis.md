---
uid: Configuring_alarm_hysteresis
---

# Configuring hysteresis in an alarm template

Two types of [hysteresis](xref:Alarm_hysteresis) are available, clear hysteresis and alarm hysteresis, respectively having an effect on the clearing and on the triggering of alarms.

For a visual example of how hysteresis can be configured in an alarm template, watch the following video. The configuration options are also explained in the text below.

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/Alarm_Hysteresis.mp4" type="video/mp4">
  </video>
</div>

*Watch first: [Creating an alarm template](xref:Creating_an_alarm_template)*

- Enter a value in the *Hyst off* column to determine the number of seconds before the severity level of an alarm decreases.

- Enter a value in the *Hyst on* column to determine the number of seconds before the severity level of an alarm increases.

- If you want to apply hysteresis to specific severity levels only, when you enter a value in the *Hyst off* or *Hyst on* box, select the severity levels in the dropdown list below the box.

> [!NOTE]
>
> - For most parameters, the hysteresis interval has to be higher than the polling interval. For example, if a parameter is only polled every 10 seconds, you should not configure a hysteresis interval of 5 seconds. However, an exception to this are parameters updated via traps or via a smart-serial connection.
> - Using hysteresis in combination with conditions on the same parameter is not supported.
> - Using hysteresis in combination with [history sets](xref:Protocol.Params.Param-historySet) on the same parameter can cause unexpected behavior in alarm timestamps, as both features modify the parameter and alarm times. For this reason, we do not recommend combining them.
