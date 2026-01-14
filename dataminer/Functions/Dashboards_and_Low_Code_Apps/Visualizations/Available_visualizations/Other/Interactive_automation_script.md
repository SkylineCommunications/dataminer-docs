---
uid: InteractiveAutomationScript
---

# Interactive Automation script

Available from DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!-- RN 39969 -->, in the Low-Code Apps module.

This component allows you to visualize any interactive Automation script (IAS) within pages or panels of a low-code app.

## Prerequisites

- From DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44232-->, to visualize the interactive Automation script, you need the user permission [*Modules > Automation > Execute*](xref:DataMiner_user_permissions#modules--automation--execute). Prior to DataMiner 10.5.0 [CU11]/10.6.2, to visualize the interactive Automation script, you need the user permissions [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute) and [Modules > Automation > UI Available](xref:DataMiner_user_permissions#modules--automation--ui-available).

- From DataMiner 10.5.9/10.6.0 onwards, the script's [InteractivityOptions](xref:Automation-InteractivityOptions) should be set to *Always* for it to be compatible with this component.

## Interacting with the IAS component

When an interactive Automation script is visualized in a low-code app, you can interact with it through the UI defined in the script itself. Any dialog boxes or other UI elements created by the script (such as buttons, input fields, or error messages) appear directly inside the component.

The following behaviors apply when using the component:

- Scripts will time out after they have run for 15 minutes. This means that after a script has been shown in the component for 15 minutes, an error will be shown.

- When a new script is started while another is running, the component will wait for the current script to finish before launching the new one.

## Configuring the component

1. In the *Component* > *Settings* pane, select the script that should be shown in the component in the *Script* box.

   > [!NOTE]
   > Make sure to select an interactive script, because only interactive Automation scripts will work with this component.

1. If necessary, configure the parameters and/or dummies for the script.

   > [!NOTE]
   > If any required parameters or dummies are not configured, either here in the settings or through a [component action](#component-actions), the component will remain blank.

1. Optionally, in the *Events* section of the *Component* > *Settings* pane, configure what should happen when the script is finished.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Show title*: Setting this to *Show* will show the script title as the title of the component, overriding any title that may be configured via the *General* > *Title* setting.

   > [!NOTE]
   > The dimensions configured in the script are ignored when this component is used. Instead, the script will fill the entire component.

## Component actions

When you have added an IAS component to a low-code app, you can configure the following [component actions](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Start*: Starts a new script in the component.

- *Abort*: Stops the script that is currently running within the component. If any action is configured to be executed when the script is finished, this will not be triggered if the *Abort* action is used.

> [!NOTE]
> When a new script is started while another is running, the component will wait for the current script to finish before launching the new one. The abort action will finish the script that is currently shown.
