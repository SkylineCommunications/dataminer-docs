---
uid: creating_virtual_functions
---

# Creating virtual functions

As any device or platform in the solution must be considered from a function perspective rather than a physical device perspective, [virtual functions](xref:srm_definitions#virtual-function) are essential in DataMiner SRM.

## Creating virtual functions using DIS

You can **create virtual functions using DataMiner Integration Studio** (version 2.37 or above):

1. Open Visual Studio (with [DataMiner Integration Studio](xref:Overall_concept_of_the_DataMiner_Integration_Studio) installed).

1. In the header menu, select *File* > *New File* > *XML File*.

1. Press Ctrl + K + X, and navigate to the *DIS Function Root* snippet available under *DIS* > *Function*.

   ![DIS Function Root Snippet](~/dataminer/images/FunctionCodeSnippet.png)

1. Add the connector name in the Protocol tag.

1. At the top of the code editor, click *Function Editor*.

   If the connector is not opened, you will be prompted to open it.

   > [!TIP]
   > See also: [Function editor](xref:Function_editor)

1. Click *New function* to start creating a new function.

   ![New Function option in Function editor](~/dataminer/images/FunctionEditorNewFunction.png)

1. In the *Edit Function* window:

   - Specify the name of the function (e.g. decoding).

   - In the *Profile* box, select the profile definition that should be linked to the function.

   - If necessary, define the entry point for the function. This indicates the source data of the main element that will be used to create virtual function resources.

     - If this is full element, leave the entry point empty.
     - If this is based on a specific table of the element, select the table that will expose multiple instances of the function.

   - If necessary, also add interfaces of the function (using the *Add* button) and link them to the corresponding profile definitions.

   - When you have added all necessary information, click *OK*.

1. At the bottom of the Function editor, click *New page*.

   ![New Function option in Function editor](~/dataminer/images/FunctionEditorNewPage.png)

1. Specify a name for the page and click *OK*.

1. Add parameters that need to be displayed by the virtual function resource by dragging them from the *Parameters* column on the right to the *Layout* section in the middle.

   ![New Function option in Function Editor](~/dataminer/images/FunctionEditorParameters.png)

1. To save the virtual function, in the top-right corner, click *Apply Changes*.

## Adding virtual functions to a DMS

1. [Publish](xref:XML_editor#publish) the function using DIS, or **upload** it to the DataMiner System in the Protocols & Templates module, in the same way as you would [upload a Protocol.xml file](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System#uploading-a-protocolxml-file).

   Note that certain conditions will need to be met for you to be able to upload the file:

   - Uploading a functions XML file is only possible if the server has the SRM license, the name of the file is unique, and the file has the *Protocol* tag configured (see [Functions schema](xref:SchemaFunctions)).
   - Several functions XML files can be uploaded for one protocol, but in that case each of the files must have a unique file name.
   - When a functions XML file is uploaded to a protocol, the system will check the validity of the XML file structure. An information event will indicate whether the upload succeeded or failed, or if there is a duplicate file name.

1. In the Protocols & Templates module, right-click the file in the *Functions files* list and select *Set as active functions file*.

   At this point, the virtual function has been added to the system and the corresponding function connector has been created.

   Note that it may not be possible to set a different functions file active if the current active file is in use in a service definition, booking definition, or planned booking instance, and the change of file entails one or more of the following modifications:

   - Removing a virtual function definition.
   - Lowering the maximum number of instances of a virtual function definition.
   - Changing the name of a virtual function definition to a name that is not unique within the protocol function version.
   - Changing the profile of a virtual function definition.
   - Changing the parent of a virtual function definition.
   - Changing entry points of a virtual function definition.
   - Removing an interface of a virtual function definition.

1. Optionally, In the Profiles module, define the mapping between the profile parameters and the protocol function parameters. You can do so using the *Linked with* section of the profile parameter configuration. See [Configuring profile parameters](xref:Configuring_profile_parameters).

   This step will make it easier to develop a Profile-Load Script, as you will be able to implement it in a generic way. However, it is not always possible to have a one-to-one relationship between a protocol parameter and a profile parameter.

> [!NOTE]
> To **delete a functions file**, in the Protocols & Templates module, right-click the functions file you want to remove and select *Delete*. However, note that only inactive functions files can be removed. In addition, in case the functions file is in use in the Service & Resource Management configuration, removing the file will only be possible with the [Modules > Services > Definitions > Force Updates](xref:DataMiner_user_permissions#modules--services--definitions--force-updates) user permission.
