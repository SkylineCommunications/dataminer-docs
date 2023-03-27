---
uid: DOM_editor_deleting_field
---

# Deleting a field

Deleting a field completely is only possible when no instances of the object exist.

> [!NOTE]
> If instances of the object exist, an error will be displayed when you try to delete the field. However, you can instead hide the field in the UI, so that for users it will look like it is deleted.

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script. You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module in which you want to delete a field, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. Click *Section Definitions*.

1. Click *Edit* next to the section definition in which you want to delete a field.

   ![DOM Editor: section definitions](~/user-guide/images/DOM_Editor_edit_section.png)

1. Click *Field Descriptors*.

   ![DOM Editor: edit section definition](~/user-guide/images/DOM_Editor_edit_field.png)

1. Next to the field you want to delete, click the X button.

   ![DOM Editor: edit field](~/user-guide/images/DOM_Editor_edit_field2.png)

1. Click *Back*, and then click *Apply*.

> [!NOTE]
> If there are no fields in a section, you can also delete that section. See [Deleting a section](xref:DOM_editor_deleting_section).
