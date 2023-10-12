---
uid: DOM_editor_new_def
---

# Creating a new module and definition

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script. You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Below the list of modules, click the *New* button.

   ![DOM Editor starting window](~/user-guide/images/DOM_Editor_new.png)

1. In the *Module ID* box, specify the name of the module you want to add. The name must be in lower case only.

   ![DOM Editor: new module window](~/user-guide/images/DOM_Editor_new2.png)

1. Click *Create*.

   The script will show the starting window again, and your new module will be added to the list of modules.

1. Next to your module, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/user-guide/images/DOM_Editor_edit_module.png)

1. Create the section definitions for your module:

   1. Click *Section Definitions*, and then click *New*.

   1. In the *Name* box, fill in the name of the section.

      ![DOM Editor: creating a new section](~/user-guide/images/DOM_Editor_new_section.png)

   1. Click *Apply*.

   1. Add fields to the section:

      1. Click *Field Descriptors*, and click the *+* button.

      1. Fill in the necessary information for the field and click *Back*.

         ![DOM Editor: configuring a field](~/user-guide/images/DOM_Editor_new_field.png)

      1. Click *Field Descriptors* again and repeat the steps above until you have added all the necessary fields.

      > [!TIP]
      > For more information on the field descriptor configuration, see [FieldDescriptor](xref:DOM_SectionDefinition#fielddescriptor).

   1. When you have added all fields, click *Apply* and *OK* to save the section definition.

1. To add another section definition, click *New* again and repeat the steps detailed above.

1. When you have configured and saved all section definitions you wanted to add, click *Back* to return to the window with the four buttons.

1. Create a [DOM definition](xref:DomDefinition) linked to one or more section definitions:

   1. Click *Definitions*, and then click *New*.

   1. In the *Name* box, fill in the name of the definition.

      ![DOM Editor: creating a new definition](~/user-guide/images/DOM_Editor_new_definition.png)

   1. Click *Section Definition Links*, and click the *+* button.

      The available sections will be added.

   1. Click the X button next to any sections you do not want to link the definition to.

   1. Click *Back*, *Apply*, and *OK* to save the definition

   > [!TIP]
   > If, for example, you have created a "ticket" section definition, you can link an "IT" DOM definition to this to represent your IT department. If you then want to create tickets for a different department later, you can create a new definition using the same module and reuse much of the configuration this way.

1. Click *Back* to return to the window with the four buttons.

1. Configure permissions for your module:

   1. Click *Manager Settings*.

   1. In the *View Permission*, *Create/Update Instance Permission*, *Delete Instance Permission*, and *Configure Permission* boxes, select *AccessElement*.

   1. Click *Apply* and *OK*.

> [!TIP]
> You can check what your data model looks like in a DataMiner low-code app. For more information on how to create such an app, refer to [this demo on DataMiner Dojo](https://community.dataminer.services/video/object-modeling-and-apps/). Prior to DataMiner 10.3.6/10.4.0, this requires the [DOMManager](xref:Overview_of_Soft_Launch_Options#dommanager) soft-launch option.
