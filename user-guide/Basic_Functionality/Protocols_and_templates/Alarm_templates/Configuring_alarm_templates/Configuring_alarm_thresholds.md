---
uid: Configuring_alarm_thresholds
---

# Configuring regular alarm thresholds

To determine the alarm thresholds for a parameter, first select the checkbox in the first column next to the parameter to enable alarm monitoring.

You can then specify the alarm thresholds:

- To do so for an **analog** parameter, simply enter the values you want for the different alarm severities.

  Specifying multiple values for one severity level can be done in two ways:

  - Add the different values in the threshold field, separating them by semicolons.

  - Click the threshold field and then click the + icon to the right of it. Then specify the value in the box below the field. Repeat for each value you want to add.

  > [!NOTE]
  > When incorrect or illogical data is entered for the analog values, a red warning message will appear in the header, and you will need to correct your alarm limits.

- For a **discrete** parameter, enter the values by clicking the threshold fields and then selecting the values in the list below.

  To specify multiple values, simply select multiple checkboxes in the list.

- For a **hybrid** parameter, you can enter the values manually like for an analog parameter, or select the exception value displayed below the threshold field.

  Multiple values can be specified in the same way as for analog parameters, except that you can also specify the exception value as well.

- For a **string** parameter, i.e. a parameter that has a string as its value, you can specify the threshold(s) in the field similar to for an analog parameter.

  However, for this type of parameter, it is also possible to use an asterisk (`*`) or question mark as a wildcard. If you enter only an asterisk for a particular alarm level, this means that any value other than the ones defined for the other alarm levels will trigger an alarm for this alarm level.

When multiple values are specified for one alarm severity, the existing alarm will be updated with a new value each time it crosses a new threshold.

> [!NOTE]
>
> - It is not necessary to enter a value for each severity level. See [Guidelines for assigning alarm severity levels](xref:Guidelines_for_assigning_alarm_severity_levels).
> - It is also possible to enable or disable parameters through the template editor right-click menu.

> [!TIP]
> See also: [Discrete, analog and hybrid parameters](xref:Discrete_analog_and_hybrid_parameters)
