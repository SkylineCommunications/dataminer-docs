---
uid: AdvancedDVEsTemplates
---

# Assigning templates to DVE parent or child elements

DVEs are defined in tables in the parent element, which means that the parameters in the child element are in fact defined in tables in the parent element. In addition, foreign key relations are used to display a table in a child element, but they can also be used for different purposes even when a DVE is present. As a result of this, the behavior when [alarm templates](xref:About_alarm_templates) or [trend templates](xref:About_trend_templates) are assigned to DVE parent or child elements can be different depending on specific circumstances.

Applying an alarm or trend template to the parent element can affect the monitoring/trending of the child elements, and inversely, applying an alarm or trend template to a child element can affect the parent element. More specifically, templates applied to child elements may override part of the main element template and take precedence over the parent element's configuration.

Below, you can find more information about the different possibilities. In the text below, when the configuration of a parameter in a trend or alarm template is mentioned, this refers to a standalone parameter or a [table parameter filtered by index](xref:Configuring_normal_alarm_thresholds#configuring-alarm-thresholds-for-dynamic-table-parameters)

- The configuration of the child DVE template **will take precedence** in the following cases:

  - When the parameter is part of the DVE table in the main element's protocol as defined by the ";element" attribute.
  - When the parameter is is subject to a relation with the DVE table in the main element's protocol.

  However, note that **when the child element overrides its parent's alarm/trend template, both parent and child element are affected**. This is because all data for a DVE child element comes from the tables defining it in the main element. As such, this only happens for the DVE tables or tables that are linked with the DVE table by a foreign key. For example, one possible effect is that trending/monitoring stops on the main element for parameters exported as a DVE or linked to the DVE via a foreign key or relation. Alternatively, a table row in the main element may appear to be monitored/trended when you would not expect this, because the DVE child element's template overrides the template of the main element.

- The configuration of the child DVE template **will not take precedence** in the following cases:

  - A specific filter excludes the (table) parameter from being included in the alarm or trend template.
  - The specified parameter is not present in the DVE child element or has no foreign key relation with it.

For **alarm templates** specifically, the parent and child element templates can be said to function as if they were part of an [alarm template group](xref:Alarm_template_groups), with the child element template getting the highest priority.

Consider for example a DVE element where a specific parameter is excluded from monitoring in the child template, while in the parent template the row corresponding to this record is monitored. This will result in the parameter from the child element being excluded from monitoring, which means that no alarm will be generated on the child element for this parameter. In addition, the row corresponding to this record in the parent template will be excluded from monitoring, and no alarm will be generated for this row on the parent element either. Note that this also applies the other way around: if in the DVE child a specific parameter is included, that specific linked row will also be monitored on the parent element.

Any other parameter in the parent element's template, meaning any parameter that is not specifically linked to a DVE for which an overriding configuration exists, will still be monitored. As such, it is **possible to have different rows in the same table exhibiting differing monitoring behavior**.

In scenarios where **only the parent element** has an alarm template assigned, and no alarm template is directly assigned to the DVE child, the child element inherits the alarm template from its parent. Therefore, when an alarm is triggered on a parameter exported to a DVE child element, that **alarm affects only the state of the child element**, not the parent element. This behavior is intentional and designed to avoid duplicate alarms appearing in the Alarm Console for both the parent and child. If an alarm is triggered on a parameter that is not exported, the alarm will affect the parent element only, not the child element.
