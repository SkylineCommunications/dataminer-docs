---
uid: Creating_an_alarm_template
---

# Creating an alarm template

To create a new alarm template:

1. Go to *Apps* > *Protocols & Templates*.

1. Select a protocol in the first column and a protocol version in the second column.

1. Right-click in the third column under *Alarm*, and select *New*.

   > [!NOTE]
   > To create a new alarm template that is very similar to one that already exists, it can be handy to duplicate the existing template instead of creating a blank new template. To do so, instead of selecting *New*, select the template that is similar, and then select *Duplicate* in the right-click menu.

1. In the *New alarm template* dialog:

   1. Keep *Alarm Template* selected.

   1. Enter a template name.

      > [!NOTE]
      > Some characters cannot be used in template names. For more information, see [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc).

   1. Check if the protocol and protocol version are correct and adapt them if necessary.

   1. Click *OK*.

      The alarm template editor will now open.

1. Optionally, click *Show details* at the top and specify a description for the alarm template.

   > [!NOTE]
   > Templates can be quickly assigned via the Surveyor right-click menu. The description you enter here is shown as a tooltip in that menu, and may help users to select the correct template.

1. Configure the alarm thresholds. You can configure [normal](xref:Configuring_normal_alarm_thresholds) or [dynamic](xref:Configuring_dynamic_alarm_thresholds) alarm thresholds.

1. Optionally, you can also:

   - [Configure alarm hysteresis](xref:Configuring_alarm_hysteresis).

   - [Make the alarm template generate information messages](xref:Configuring_alarm_template_information_message).

   - [Configure conditional alarm monitoring](xref:Using_conditions_in_an_alarm_template).

   - [Configure anomaly detection alarms](xref:Configuring_anomaly_detection_alarms).

   - [Configure automatic clearing of alarms](xref:Setting_the_autoclear_option_in_alarm_template).

   - [Schedule the alarm template](xref:Scheduling_an_alarm_template).

1. When the alarm template is fully configured, click *OK*.

   A dialog will be displayed where you can link the template to one or more elements.
