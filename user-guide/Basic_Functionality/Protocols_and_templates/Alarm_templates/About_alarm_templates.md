---
uid: About_alarm_templates
---

# About alarm templates

An alarm template is an XML file that contains all alarm thresholds for all parameters defined in a particular DataMiner protocol. It is an overlay file that overrides the default alarm thresholds defined in a DataMiner protocol.

An alarm template can be [assigned to an element type](xref:Assigning_an_alarm_template), or in other words, to all elements sharing the same DataMiner protocol. There is no limit to the number of alarm templates that can be created for every DataMiner protocol. Multiple alarm templates can be maintained and switching between them is easy, so that alarm thresholds can quickly be changed.

You can [create alarm templates](xref:Creating_an_alarm_template) using the [alarm template editor](xref:About_the_alarm_template_editor) in the Protocols & Templates module.

Different alarm templates can also be combined in [template groups](xref:Alarm_template_groups), in order to build alarm template hierarchies allowing alarm thresholds for one or more parameters to be overruled without any changes to the base template.
