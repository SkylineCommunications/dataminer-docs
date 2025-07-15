---
uid: Working_with_Alerter_pop-up_balloons
---

# Working with Alerter pop-up balloons

When a pop-up balloon appears, it contains the following information about a particular alarm:

- Alarm severity, indicated by the color of the bar next to the alarm information

- Element name

- Parameter name

- Parameter value

- Timestamp

> [!NOTE]
>
> - In case there are several alarms at the same time, the alarm with the highest priority is shown first. See [Alarm type priority](xref:Alarm_types#alarm-type-priority).
> - It is possible to customize the content of Alerter pop-up balloons. See [Configuring Alerter pop-up balloons](xref:Configuring_Alerter_popup_balloons).
> - You can customize the size of Alerter pop-up balloons by dragging the balloon edges. When you have resized a balloon, this custom size will be applied for all subsequent balloons.
> - Alerter always shows the default alarm severity colors. If custom colors are [defined in DataMiner.xml](xref:Changing_the_default_alarm_colors), these are not applied in Alerter.

In a pop-up balloon, you can click certain items:

- Click **an element or service name** to open the default client application and go to the element or service in question.

- Click **Take Ownership** to take ownership of the alarm.

> [!NOTE]
> If a client application is already open when you click a balloon, and you are logged in with the same user account in both applications, then the element or service information will be accessed in the already opened client application window. To close a pop-up balloon, click the X in the top-right corner.
