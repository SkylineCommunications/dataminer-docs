---
uid: Making_a_measurement_point_execute_a_script_before_taking_a_trace
---

# Making a measurement point execute a script before taking a trace

Spectrum measurement points are often configured to set one or more parameters before taking a trace. However, they can also be configured to execute an entire automation script before taking a trace.

> [!WARNING]
> Measurement points that execute automation scripts should only be used in spectrum monitors. It is not recommended to request traces from such measurement points in a real-time spectrum display as this could cause performance issues.

1. On a spectrum analyzer card, go to the *Measurement points* menu and select *Edit measurement point*.

1. In the left pane of the *Edit measurement point* window, select the measurement point.

1. In the *Setup* section, select *Set up your measurement point via an automation script*.

1. Click *\<empty>*, and select an automation script in the dropdown list.

1. In the boxes below the script name, fill in the necessary dummies and parameters for the script.

1. If necessary, select additional options for the way the automation script is run. For more information on these options, see [Script execution options](xref:Script_execution_options).

1. Click *Apply* to apply your changes.
