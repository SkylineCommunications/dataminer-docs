---
uid: About_alarm_templates
---

# About alarm templates

An alarm template is an XML file that contains all alarm thresholds for all parameters defined in a particular DataMiner protocol. It is an overlay file that overrides the default alarm thresholds defined in a DataMiner protocol.

![Alarm template](~/dataminer/images/Alarm_Template.png)<br>*Alarm template in DataMiner 10.4.5*

Using the [alarm template editor](xref:About_the_alarm_template_editor) in the Protocols & Templates module, You can [create as many alarm templates](xref:Creating_an_alarm_template) for each DataMiner protocol as you want. You can then [assign different alarm templates](xref:Assigning_an_alarm_template) to different elements, even if they are using the same protocol. Switching between templates is easy, so that alarm thresholds can quickly be changed.

Different alarm templates can also be combined in [alarm template groups](xref:Alarm_template_groups), in order to build alarm template hierarchies allowing alarm thresholds for one or more parameters to be overruled without any changes to the base template.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Want to see the alarm template editor in action? Watch <a href="xref:Creating_an_alarm_template" style="color: #657AB7;">this short video</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>
