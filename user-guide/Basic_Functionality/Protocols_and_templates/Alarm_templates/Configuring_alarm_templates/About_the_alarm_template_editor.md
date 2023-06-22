---
uid: About_the_alarm_template_editor
---

# About the alarm template editor

To configure an alarm template, usually the alarm template editor in the Protocols & Templates module is used.

> [!TIP]
> It is also possible to quickly [change the alarm range for one parameter](xref:Changing_the_alarm_range_for_one_parameter) without using the Protocols & Templates module.

## Opening the alarm template editor

- From the overview of all templates in the Protocols & Templates module:

  - In the app, right-click the template and select *Open*, *Open in new card*, or *Open in new undocked card*.

- From a particular element or service in the Surveyor:

  - To open an existing template, right-click the element or service in the Surveyor, and select *Protocols & Templates \> View alarm template '\[template name\]'*.

  - To create and configure a new template, right-click the element or service in the Surveyor, and select *Protocols & Templates \> Assign alarm template* > *\<New alarm template>*. Then specify the name for the new template and click *OK*.

## The alarm template editor user interface

The alarm template editor consists of two main sections:

- The *General* section at the top, which you can expand by clicking *Show details*:

  - At the top, you can specify a description for the template.

    > [!NOTE]
    > Templates can be quickly assigned via the Surveyor right-click menu. The description you enter here is shown as a tooltip in that menu, and may help users to select the correct template.

  - On the right, this section shows the protocol and protocol version linked to the template, and a list of elements to which it has been assigned.

  - At the bottom of the section, you can schedule when the alarm template should be applied. See [Scheduling an alarm template](xref:Scheduling_an_alarm_template).

- The *Alarm template parameters* section, where you can [configure alarm thresholds](xref:Configuring_absolute_alarm_thresholds):

  - By default, for a **new** alarm template, **general parameters are not displayed**. To configure monitoring for these, click the *Only monitored parameters* button, and select *Only protocol parameters* or *All parameters (protocol + general)*.

  - If you open an **existing** alarm template, **only the parameters for which thresholds have been set** are shown. To see other parameters as well, click the *Only monitored parameters* button and select *Only protocol parameters* or *All parameters (protocol + general)*.

  - To quickly find a particular parameter, you can use the filter box in the top-right corner.

  - For some matrix parameters, alarm thresholds need to be configured in a dedicated [alarm level editor](xref:Configuring_absolute_alarm_thresholds#configuring-alarm-thresholds-for-matrix-parameters).
