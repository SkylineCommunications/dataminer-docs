## Making a measurement point execute a script before taking a trace

Spectrum measurement points are often configured to set one or more parameters before taking a trace. However, they can also be configured to execute an entire Automation script before taking a trace.

> [!WARNING]
> Measurement points that execute Automation scripts should only be used in spectrum monitors. It is not recommended to request traces from such measurement points in a real-time spectrum display as this could cause performance issues.

1. On a spectrum analyzer card, go to the *Measurement points* menu and select *Edit measurement point*.

2. In the left pane of the *Edit measurement point* window, select the measurement point.

3. In the *Setup* section, select *Set up your measurement point via an Automation script*.

4. Click *\<empty>*, and select an Automation script in the drop-down list.

5. In the boxes below the script name, fill in the necessary dummies and parameters for the script.

6. If necessary, select additional options for the way the Automation script is run. For more information on these options, see [Script execution options](../automation/Script_execution_options.md).

7. Click *Apply* to apply your changes.
