---
uid: InteractiveAutomationScript
---

# Interactive Automation script

Available from DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards.<!-- RN 39969 -->

This component allows you to visualize any interactive Automation script within pages or panels of an low-code app.

> [!NOTE]
> This component is only available in the Low-Code Apps module. It only works with interactive scripts.

## Executing a script

1. To show a script on view of the component, you can use the *Component* > *Settings* > *General* > *Script*.

1. You can also use component actions to Start/Abort scripts. The start will start a new script in the component, while the abort action will stop the script currently running inside of the component.

    > [!NOTE]
    > When starting a new script while another is running, the component will wait for the current script to finish before launching the new one. Aborting will finish the one currently shown.

Scripts will timeout after 15 minutes of them running. This means that after 15 minutes of a script being shown in the component an error will appear.

This component will not prompt for any missing parameters or dummies. This means that these should be filled in trough the config of either the actions or the script setting. When there are missing parameters or dummies the component will remain blank.

## Action on script finish

1. You can configure actions to happen when a script finishes using the *Component* > *Settings* > *Events* > *On finish* setting. This does not trigger when you abort the script using the previously mentioned action.

## Layout Settings

1. You can make the component display the title of the script via *Component* > *Layout* > *Advanced* > *Show Title*. This will however override the title you can set on any component using the *Component* > *Layout* > *General* > *Title* setting.

The script dimensions are ignored when using this component. This means your script will fill in the entire component.
