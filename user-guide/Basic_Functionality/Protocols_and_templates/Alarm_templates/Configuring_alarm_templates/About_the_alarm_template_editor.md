---
uid: About_the_alarm_template_editor
---

# About the alarm template editor

To configure an alarm template, you must first open the template editor. You can do so as follows:

- From the overview of all templates in the Protocols & Templates module:

  - In the app, right-click the template and select *Open*, *Open in new card* or *Open in new undocked card*.

- From a particular element or service in the Surveyor:

  - To open an existing template, right-click the element or service in the Surveyor and select *Protocols & Templates \> View alarm template '\[template name\]'*.

  - To create and configure a new template, right-click the element or service in the Surveyor and select *Protocols & Templates \> Assign alarm template* > *\<New alarm template>*. Then specify the name for the new template and click *OK*.

The alarm template editor consists of two main sections:

- The *General* section at the top, which you can expand by clicking *Show details*:

  - At the top, you can specify a description for the template.

    > [!NOTE]
    > From DataMiner 9.0.5 onwards, templates can be quickly assigned via the Surveyor right-click menu. The description you enter here is shown as a tooltip in that menu, and may help users to select the correct template.

  - On the right, this section shows the protocol and protocol version linked to the template, and a list of elements to which it has been assigned.

  - At the bottom of the section, you can schedule when the alarm template should be applied. See [Scheduling an alarm template](xref:Scheduling_an_alarm_template).

- The *Alarm template parameters* section, where alarm thresholds can be configured:

  - By default, for a new alarm template, general parameters are not displayed. To configure monitoring for these, click the *Only monitored parameters* button and select *Only protocol parameters* or *All parameters (protocol + general)*.

  - If you open an existing alarm template, only the parameters for which thresholds have been set are shown. To see other parameters as well, click the *Only monitored parameters* button and select *Only protocol parameters* or *All parameters (protocol + general)*.

  - To quickly find a particular parameter, you can use the filter box in the top-right corner.

For more information on how to configure alarm thresholds, refer to the sections below. Also keep the following information in mind:

- If you select the *Monitored* checkbox next to a parameter, but do not define any threshold, the parameter will be set to an undefined state.

- From DataMiner 9.0.0 CU14 onwards, you can select or deselect all parameters at once, by right-clicking the column header of the list of parameters and selecting *Enable all parameters* or *Disable all parameters*, respectively.

- For DVE elements, the parent element and child element alarm templates function as if they were part of an alarm template group, with the child element template getting the highest priority. This means that if a parameter is monitored in the parent element template, but not in the child element template, the parameter will not be monitored in the child element. See also [Alarm template groups](xref:Alarm_template_groups).

- When you finish the configuration of an alarm template, from DataMiner 9.0.5 onwards, a dialog box will appear that allows you to immediately link that template to one or more elements.
