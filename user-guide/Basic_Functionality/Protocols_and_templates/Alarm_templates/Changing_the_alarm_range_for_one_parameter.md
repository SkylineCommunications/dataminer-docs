---
uid: Changing_the_alarm_range_for_one_parameter
---

# Changing the alarm range for one parameter

Both from the Alarm Console and from a parameter card, it is possible to quickly change the alarm range for one particular parameter. This can be particularly useful for users who do not have access to the Protocols & Templates module.

There are several ways you can access the alarm range editor:

- In the Alarm Console, right-click an alarm for that particular parameter, and select *Change \> Alarm range*.

- On a parameter card, click the hamburger button in the top-left corner, and select *Change alarm range*.

- On a parameter card, go to the templates tab and select *ALARM*.

In the alarm range editor, you can do the following:

- Clear the *Monitored* checkbox to stop monitoring the parameter.

- Change the type of alarm monitoring: *Normal*, *Relative*, *Absolute*, or *Rate*.

    > [!TIP]
    > See also: [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds)

- Enter different values for the alarm thresholds.

- Select *Info* and enter a parameter value. Whenever the parameter gets this value, an information event will be generated.

At the bottom of the window, an information message will show you what other elements use the same alarm range.

To save your changes, there are two options:

- To change the alarm range for all elements using the same template, click *Update Alarm Template*.

- To only change the alarm range for this element, click *Update this element only*. In this case, a copy of the alarm template will be created, and you will have to enter a name for this new alarm template.

> [!NOTE]
> If a parameter is monitored by an alarm template group, the template shown in the alarm range editor is the alarm template with the highest priority monitoring that parameter.
>
