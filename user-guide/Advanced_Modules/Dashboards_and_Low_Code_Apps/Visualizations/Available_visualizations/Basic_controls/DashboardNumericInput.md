---
uid: DashboardNumericInput
---

# Numeric input

Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35902 -->. This basic control allows the user to enter numbers, which will then be available as a number feed in the dashboard or low-code app. The number feed can be used by queries and by script parameters in low-code app actions.

![Numeric input](~/user-guide/images/Numeric_Input.png)<br>*Numeric input component in DataMiner 10.4.6*

The following options are available to fine-tune the component layout:

- *Label*: Text that will be displayed next to the numeric input box.

- *Inline*: Available from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36983 -->. Determines whether the label is displayed above the numeric input box or next to it. If this option is selected, it is displayed next to the box.

- *Placeholder*: Placeholder that will be displayed inside the numeric input box.

- *Icon*: Icon that will be displayed in the numeric input box.

In the *Settings* tab, you can also configure the following optional settings:

- *Feed value on*: Determines when the value in the box becomes available as a feed. This can be when the user presses Enter ("Enter"), when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change"). If you select *Focus lost*, the value will also become available when the user presses Enter.

- *Step size*: The value the user specifies will need to be a multiple of the value specified with this option. For example, if the step size is 3, the user can enter 3, 6, 9, etc. but not 2 or 5.

- *Number of decimals*: The maximum number of decimals.

- *Minimum*: The minimum value for the numeric input.

- *Maximum*: The maximum value for the numeric input.

> [!NOTE]
> From DataMiner 10.3.0 [CU10]/10.4.1 onwards<!-- RN 37736 -->, you can drag a data feed to the component to link it to that feed, or [specify a feed in the URL](xref:Specifying_data_input_in_a_dashboard_URL). This way, the component will be filled in based on the feed, but users will still be able to modify the value.

## Component actions

From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40252-->, when you have added a numeric input component to a low-code app, you can configure the following [component action](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Set value*: Allows you to set the current value of the component to either a static value or a feed.

  > [!NOTE]
  > When the component has the *General > Feed value on > Value change* option enabled, the value will immediately be passed as the component's feed. If this option is not enabled, the value will only be passed when Enter is pressed (if the *General > Feed value on > Enter* option is enabled) or when the focus is no longer on the box (if the *General > Feed value on > Focus lost* option is enabled).
