---
uid: DOM_editor_adding_button
---

# Adding a button

You can add a button to a form to apply an action, e.g. to close a ticket.

For this, you need to first add a behavior definition, and then define the button, so that it can be shown in the UI that triggers the API action.

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script. You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module in which you want to add a button, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. Click *Behavior Definitions*, and then click *New*.

1. Click *Actions*.

   ![DOM Editor: new behavior definition](~/user-guide/images/DOM_Editor_new_behavior.png)

1. Define the action. For example, for an action to close a ticket, you could configure this as follows:

   ![DOM Editor: new behavior definition](~/user-guide/images/DOM_Editor_define_action.png)

   The script options `PARAMETERBYNAME:Action:Close ticket` in the example above are used by DataMiner Automation to know which action is triggered.

1. Click *Back* twice to go back to the *behaviors* window.

1. Click *Buttons*, and click *Add*.

1. Configure the button. For example, for a button to close a ticket, you could configure this as follows:

   ![DOM Editor: new button](~/user-guide/images/DOM_Editor_define_button.png)

1. Click *Back* twice, and click *Apply*.
