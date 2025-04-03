---
uid: Functions_XML_files
---

# Functions XML files

In this section:

> [!TIP]
> See also: [Implementing virtual functions](xref:implementing_function_srm)

## About functions files

Functions are defined in DataMiner by means of XML files linked to protocols. These files are located within the *Functions* subfolder of each relevant protocol folder in *C:\\Skyline DataMiner\\Protocols*.

Based on these functions XML files, "virtual function" elements can be created for elements that use the matching protocol. Such virtual function elements, or “virtual function resources”, are created by the Service & Resource Management module when the functions are in use. It is not possible to manually delete or edit these elements, change their state (e.g. pause or stop them), mask these elements, assign alarm or trend templates to them or use them in element simulations. Overall, they act much like DVE child elements, except that they are controlled by the Service & Resource Management module instead of by a DVE parent element.

In the Protocols & Templates module, virtual function definitions are indicated in the same way as DVE child protocols, except with a different icon. This can be a default icon or a custom icon defined in the functions XML file. The same icon will also be used to display the virtual function elements in the Surveyor.

> [!NOTE]
>
> - Several functions XML files can be uploaded for one protocol, but in that case each of the files must have a unique file name.
> - When a functions XML file is uploaded to a protocol, the system will check the validity of the XML file structure. An information event will indicate whether the upload succeeded or failed, or if there is a duplicate file name.
> - In addition to functions XML files, the system can also contain virtual function protocols that are automatically generated based on virtual function definitions. These are listed in the *Virtual functions* section at the bottom of the first column of the Protocols & Templates module.

> [!TIP]
> For information about the Functions XML structure, refer to [Functions schema](xref:SchemaFunctions).

## Uploading a functions XML file in DataMiner Cube

To upload a functions XML files, you can use the Protocols & Templates module.

To do so, follow the same procedure as for a *Protocol.xml* file. See [Uploading a Protocol.xml file](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System#uploading-a-protocolxml-file).

> [!NOTE]
> Uploading a functions XML file is only possible if the server has the SRM license, the name of the file is unique, and the file has the Protocol tag configured (see [Functions schema](xref:SchemaFunctions)).

## Setting a functions file active

If there are several functions XML files for one protocol, you can select to set a different functions XML file as the active file. To do so, in the Protocols & Templates module, right-click the file in the *Functions files* list and select *Set as active functions file*.

> [!NOTE]
> It may not be possible to set a different functions file active if the current active file is in use in a service definition, booking definition or planned booking instance and the change of file entails one or more of the following modifications:
>
> - removing a virtual function definition
> - lowering the maximum number of instances of a virtual function definition
> - changing the name of a virtual function definition to a name that is not unique within the protocol function version
> - changing the profile of a virtual function definition
> - changing the parent of a virtual function definition
> - changing entry points of a virtual function definition
> - removing an interface of a virtual function definition

## Deleting a functions file

To delete a functions file, in the Protocols & Templates module, right-click the functions file you want to remove and select *Delete*.

> [!NOTE]
> Only inactive functions files can be removed. In addition, in case the functions file is in use in the Service & Resource Management configuration, removing the file will only be possible with the [Modules > Services > Definitions > Force Updates](xref:DataMiner_user_permissions#modules--services--definitions--force-updates) user permission.
