---
uid: DOM_editor_deleting_section
---

# Deleting a section definition

You can only delete a section definition if it no longer contains any fields. See [Deleting a field](xref:DOM_editor_deleting_field).

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script. You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module in which you want to delete a section definition, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. First unlink the section on definition level, because sections can only be deleted if they are not used by a definition:

   1. In the window with the four buttons, click *Definitions*.

   1. Next to the definition, click *Edit*.

   1. Click *Section Definition Links*.

   1. Click the X button next to the section definition.

   1. Click *Back* and then click *Apply* to save your change.

1. Click *OK* to return to the *sections* window.

1. Next to the section you want to delete, click the *Delete* button.
