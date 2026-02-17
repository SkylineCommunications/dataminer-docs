---
uid: Toggle
---

# Toggle

This basic control (available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41903-->) allows you to enable or disable specific capabilities.

The toggle component accepts boolean input (e.g., variables of type boolean), but can also be used as data output (*Data* > *Components* > *[Page name]* > *Toggle* > *Value* > *Booleans*) to drive GQI queries, automation scripts, and more. For example, you can use one toggle component to trigger a second toggle component.

![Two toggle switches](~/dataminer/images/Notification_and_Vibration_Controls.gif)<br>*Toggle components in DataMiner 10.5.3*

To configure the toggle component:

1. In the *Component* > *Settings* pane, determine whether the component's default value should be "false" (toggle switch disabled) or "true" (toggle switch enabled). By default, this is set to "false".

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Label*: Text that will be displayed next to the toggle switch.

   - *Icon*: Icon that will be displayed next to the toggle switch.

## Component actions

When you have added a toggle component to a low-code app, you can configure the following [component action](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Set value*: Allows you to set the current value of the component to either a static value (true, false, or empty) or data input (variables of type boolean)<!--RN 41911-->.
