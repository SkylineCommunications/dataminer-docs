---
uid: DashboardNumericInput
---

# Numeric input

Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35902 -->. This basic control allows the user to enter numbers, which will then be available as numeric data in the dashboard or low-code app. The data can be used by queries and by script parameters in low-code app actions.

![Numeric input](~/dataminer/images/Numeric_Input.png)<br>*Numeric input component in DataMiner 10.4.6*

The following options are available to fine-tune the component layout:

- *Label*: Text that will be displayed next to the numeric input box.

- *Inline*: Available from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36983 -->. Determines whether the label is displayed above the numeric input box or next to it. If this option is selected, it is displayed next to the box.

- *Placeholder*: Placeholder that will be displayed inside the numeric input box.

- *Icon*: Icon that will be displayed in the numeric input box.

In the *Settings* pane, you can also configure the following optional settings:

- *Emit value on*: Determines when the value in the box becomes available as data. This can be when the user presses Enter ("Enter"), when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change"). If you select *Focus lost*, the value will also become available when the user presses Enter. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this setting is called "*Feed value on*" instead.

- *Default value*: Available from DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41401-->. Allows you to specify the default value that will be entered into the numeric input component when the dashboard or low-code app is opened.

- *Step size*: The value the user specifies will need to be a multiple of the value specified with this option. For example, if the step size is 3, the user can enter 3, 6, 9, etc. but not 2 or 5.

- *Number of decimals*: The maximum number of decimals.

- *Minimum*: The minimum value for the numeric input.

- *Maximum*: The maximum value for the numeric input.

> [!NOTE]
> From DataMiner 10.3.0 [CU10]/10.4.1 onwards<!-- RN 37736 -->, you can drag data to the component to link it to that data, or [specify data input in the URL](xref:Specifying_data_input_in_a_URL). This way, the component will be filled in based on the linked data, but users will still be able to modify the value.

## Component actions

From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40252-->, when you have added a numeric input component to a low-code app, you can configure the following [component action](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Set value*: Allows you to set the current value of the component to either a static value or data input.

  > [!NOTE]
  > When the component has the *General > Emit value on > Value change* option enabled, the value will immediately be passed as the component's data. If this option is not enabled, the value will only be passed when Enter is pressed (if the *General > Emit value on > Enter* option is enabled) or when the focus is no longer on the box (if the *General > Emit value on > Focus lost* option is enabled).
