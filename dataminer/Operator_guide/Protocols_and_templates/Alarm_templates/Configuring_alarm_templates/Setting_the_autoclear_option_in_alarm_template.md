---
uid: Setting_the_autoclear_option_in_alarm_template
---

# Setting the autoclear options for alarms in an alarm template

For each parameter, it is possible to configure whether alarms will be [automatically cleared](xref:Clearing_alarms) or not, or if the system default settings will apply.

To do so:

1. Click the cogwheel button in the top-right corner of the alarm template editor.

1. Select the option *Allow override of parameter autoclear*. An extra column will appear in the template editor.

1. In the last column for the parameters where you want to override the autoclear parameter, select *True* or *False*.

   By default, the field will be set to *System Default*. This means that the parameter will inherit the AutoClear setting specified in the [AlarmSettings.AutoClear](xref:MaintenanceSettings.AlarmSettings.AutoClear) tag in *MaintenanceSettings.xml*.

> [!NOTE]
> Disabling autoclear is not recommended in larger systems as it can cause alarm trees to grow excessively large. Refer to the [best practices](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large) for more information.
