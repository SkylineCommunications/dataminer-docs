---
uid: InteractiveAutomationScript
---

# Interactive automation script

Available from DataMiner 10.4.9 onwards.

This component allows you to visualize any interactive automation script within a component. Allowing you to implement these scripts within pages and panels of any Low Code App.

> [!IMPORTANT]
> Only interactive scripts work in this component.

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