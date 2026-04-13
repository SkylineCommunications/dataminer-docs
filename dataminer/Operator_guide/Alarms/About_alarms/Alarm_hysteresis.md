---
uid: Alarm_hysteresis
---

# Alarm hysteresis

With alarm threshold hysteresis, you can fine-tune the sensitivity of your alarm thresholds by defining how long a parameter has to be below or above a certain threshold before the DataMiner System is allowed to consider it as being below or above that threshold.

![Alarm hysteresis](~/dataminer/images/hysteresis.jpg)

DataMiner supports two types of hysteresis:

- **Clear hysteresis**: Delaying the moment when an alarm is cleared, i.e., the moment when the severity of an alarm decreases.

- **Alarm hysteresis**: Delaying the moment when the severity of an alarm increases.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Want to see alarm threshold hysteresis in action? Watch <a href="xref:Configuring_alarm_hysteresis" style="color: #657AB7;">this short video</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

<br>

> [!TIP]
> See also:
>
> - [Configuring alarm hysteresis in an alarm template](xref:Configuring_alarm_hysteresis)
> - [Polling.xml](xref:Polling_xml#pollingxml)
