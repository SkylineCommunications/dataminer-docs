---
uid: DOM_editor_adding_section
---

# Adding a section definition

To add a section definition to an existing module and link it to an existing definition:

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script. You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module to which you want to add a section definition, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. Click *Section Definitions*, and then click *New*.

1. In the *Name* box, fill in the name of the section.

   ![DOM Editor: new section](~/user-guide/images/DOM_Editor_new_section.png)

1. Click *Apply*.

1. Add fields to the section:

   1. Click *Field Descriptors*, and click the *+* button.

   1. Fill in the necessary information for the field and click *Back*.

      ![DOM Editor: configuring a field](~/user-guide/images/DOM_Editor_new_field.png)

   1. Click *Field Descriptors* again and repeat the steps above until you have added all the necessary fields.

   > [!TIP]
   > For more information on the field descriptor configuration, see [FieldDescriptor](xref:DOM_SectionDefinition#fielddescriptor).

1. When you have added all fields, click *Apply* and *OK* to save the section definition.

1. Click *Back* to return to the window with the four buttons.

1. Link the section to a definition:

   1. In the window with the four buttons, click *Definitions*.

   1. Next to the definition, click *Edit*.

   1. Click *Section Definition Links*.

   1. Click the + button.

   1. Click *Back* and then click *Apply* to save your update.
