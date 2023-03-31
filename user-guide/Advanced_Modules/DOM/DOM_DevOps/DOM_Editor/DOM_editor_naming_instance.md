---
uid: DOM_editor_naming_instance
---

# Naming a DOM instance

You can define the naming of instances on definition level or on module level. If something is defined on definition level this will take priority over the module level.

The procedure below details how you can name instances on definition level.

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script. You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module in which you want to define the naming, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. Click *Definitions*

1. Next to the definition, click *Edit*.

1. Click *Name Definitions*, and click the *+* button.

1. Define the name by adding one or more field values and/or static values. This way, you can concatenate field values and/or static values as the name of the instance.

   For example:

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_name_instance.png)

1. Click *Back* and *Apply*.

> [!NOTE]
> Naming instances on module level is similar, except that instead of the definition, you will need to edit the module, and click *Manager Settings* > *Instance Name Definition*.
