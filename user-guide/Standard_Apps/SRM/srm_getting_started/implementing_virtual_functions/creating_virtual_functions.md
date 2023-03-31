---
uid: creating_virtual_functions
---

# Creating virtual functions

As any device or platform in the solution must be considered from a function perspective rather than a physical device perspective, [virtual functions](xref:srm_definitions#virtual-function) are essential in DataMiner SRM.

You can **create virtual functions using DataMiner Integration Studio** (version 2.37 or above):

1. Open Visual Studio (with [DataMiner Integration Studio](xref:DIS) installed).

1. In the header menu, select *File* > *New File*.

1. In the *New File* window, select *DataMiner Function Template* and click *Open*.

   ![New File window](~/user-guide/images/NewFunctionTemplate.png)

1. Specify the path to the connector exposing the function and click *OK*.

   ![New Function window](~/user-guide/images/NewFunction.png)

1. At the top of the code editor, click *Function Editor*.

   ![Function editor](~/user-guide/images/FunctionEditor.png)

   > [!TIP]
   > See also: [Function editor](xref:Function_editor)

1. Click *New function* to start creating a new function.

   ![New Function option in Function editor](~/user-guide/images/FunctionEditorNewFunction.png)

1. In the *Edit Function* window:

   - Specify the name of the function (e.g. decoding).

   - In the *Profile* box, select the profile definition that should be linked to the function.

   - If necessary, define the entry point for the function. This indicates the source data of the main element that will be used to create virtual function resources.

     - If this is full element, leave the entry point empty.
     - If this is based on a specific table of the element, select the table that will expose multiple instances of the function.

   - If necessary, also add interfaces of the function (using the *Add* button) and link them to the corresponding profile definitions.

   - When you have added all necessary information, click *OK*.

1. At the bottom of the Function editor, click *New page*.

   ![New Function option in Function editor](~/user-guide/images/FunctionEditorNewPage.png)

1. Specify a name for the page and click *OK*.

1. Add parameters that need to be displayed by the virtual function resource by dragging them from the *Parameters* column on the right to the *Layout* section in the middle.

   ![New Function option in Function Editor](~/user-guide/images/FunctionEditorParameters.png)

1. To save the virtual function, in the top-right corner, click *Apply Changes*.

1. [Publish](xref:XML_editor#publish) the function using DIS, or [upload](xref:Functions_XML_files#uploading-a-functions-xml-file-in-dataminer-cube) it to the DataMiner System.

1. [Activate](xref:Functions_XML_files#setting-a-functions-file-active) the function. At this point, the virtual function has been added to the system and the corresponding function connector has been created.

1. Optionally, In the Profiles module, define the mapping between the profile parameters and the protocol function parameters. You can do so using the *Linked with* section of the profile parameter configuration. See [Configuring profile parameters](xref:Configuring_profile_parameters).

   > [!NOTE]
   > This step will make it easier to develop a Profile-Load Script, as you will be able to implement it in a generic way. However, it is not always possible to have a one-to-one relationship between a protocol parameter and a profile parameter.
