---
uid: DOM_editor_adding_field
---

# Adding a field

The DOM Editor allows you to add a field to an existing section definition. This is possible even when there are instances of that specific object already.

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script.

   When the DOM designer package has been installed, this script will be included in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module in which you want to add a field, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. Click *Section Definitions*.

1. Click *Edit* next to the section definition you want to add the field to.

1. Click *Field Descriptors*, and click the *+* button.

1. Fill in the necessary information for the field and click *Back*.

   > [!NOTE]
   > If you add a mandatory field, whenever an existing instance is saved, that added mandatory field will need to be filled in.

1. Click *Back* again and then click *Apply* and *OK*.

> [!NOTE]
> You can also add a new section to an existing module and add new fields to that. In that case, after you have added the fields, you will also need to add the section to the definition:
>
> 1. In the window with the four buttons, click *Definitions*.
> 1. Next to the definition, click *Edit*.
> 1. Click *Section Definition Links*.
> 1. Click the + button.
> 1. Click *Back* and then click *Apply* to save your update.
