---
uid: Developing_connectors_as_Visual_Studio_solutions
---

# Connector development

## Creating a new connector solution

To create a new connector solution, select *File \> New \> Project*.

> [!NOTE]
> In Visual Studio 2019, select *File \> New \> DataMiner Protocol Solution…*

## Converting an existing protocol XML file to a solution

DIS supports converting an existing protocol XML file into a Visual Studio solution. To convert an existing protocol XML file to a solution, open the protocol XML file in Visual Studio and select *DIS \> Protocol \> Convert to Solution...*

A new solution will be created, and the existing protocol XML file will be added. However, the [QAction](xref:Protocol.QActions.QAction) tags will not contain any C# code. For each of the QActions in the original protocol XML file, a new C# class library project will be created, and any DLL imports specified in the original QActions will be converted to references on the C# projects (pointing either to other C# projects or to DLL files).

> [!NOTE]
> When you open a protocol, DIS will automatically detect whether the protocol is solution-based. A protocol will be considered solution-based when the solution has a “Solution Items” folder containing a “protocol.xml” file and a “QActions” folder containing at least one C# project named “QAction\_\<id>”.

## Managing QActions

### Adding a QAction

To add a QAction project to a connector solution, do the following:

1. Add a new [QAction](xref:Protocol.QActions.QAction) tag to the protocol XML file (manually or via a snippet), assign a unique ID to it, and optionally add the necessary C# code.
1. Click the *Edit QAction* icon next to the \<QAction> tag.

DIS will automatically generate a new C# project, add it to the solution, and open the QAction in a new editor tab. If you have already added some C# code, that code will be moved to the QAction\_\<id>.cs file in the new C# project.

### Editing a QAction

To edit a QAction, you have two options:

- Click the *Edit QAction* icon next to the \<QAction> tag in the protocol XML file (as before).
- Open Visual Studio’s Solution Explorer window, go to the QAction\_\<id> project and open the QAction\_\<id>.cs file.

> [!NOTE]
>
> - A QAction project can contain several \*.cs files in you can organize these in differnt folders. The files will then be combined when the protocol is assembled.
> - It is recommended to place all “using” directives inside the namespace instead of at the top of the file.
> - When developing connectors as a Visual Studio solution, DLL imports now need to be configured by adding references on the C# project itself (instead of using the [dllImport](xref:Protocol.QActions.QAction-dllImport) attribute).
To introduce a reference to another QAction, select the QAction project, right-click and select *Add* > *Reference*. In the *Reference Manager* window, select *Projects* and then select the check box for the QAction project(s) you want to reference (This will be translated by DIS to “\[ProtocolName\].\[ProtocolVersion\].QAction.\<id>.dll” imports in the protocol XML when the connector is assembled).
For custom DLLs, make sure the DLL is present in the *Dlls* folder of the solution. This will ensure that the required custom DLLs for this connector are eventually also included in the repository, next to the protocol XML. To introduce a reference to this custom DLL, select the QAction project, right-click and select *Add* > *Reference*. In the *Reference Manager* window, select *Browse* and then browse to this DLL and select the corresponding check box.

### Removing a QAction

To remove a QAction, remove the \<QAction> tag in the protocol XML file as well as the C# project.

## Uploading a protocol to a DataMiner Agent

Because, in a connector solution, the QActions in the protocol XML file do not contain any C# code, the protocol first needs to be compiled before it can be uploaded to a DataMiner Agent. Once the connector is assembled, the code in all QAction projects and files found in the solution will be copied to the correct \<QAction> tags in the protocol XML file.

A connector will automatically be assembled when you click the *Publish* button at the top of the file tab, or when you right-click and select *Copy Protocol to Clipboard*.

## Saving an assembled connector to a file

A compiled connector can be saved either as an XML file or as a *.dmprotocol* package.

To save a compiled protocol

1. Select *File \> Save Compiled Protocol As...*
1. In the *Save As* window, select a folder, enter a file name, set *Save as type* to either "Protocol package (\*.dmprotocol)" or "Protocol file (\*.xml)", and click *Save*.

If you choose to save a protocol as a package, the package will contain the protocol as well as all required assemblies (e.g. DLL files of NuGet packages that are used in the connector).

## Structure of a connector solution

A connector Visual Studio solution consists of the following folders:

- *Dlls*: Contains the custom DLLs that are used by this protocol (i.e. DLLs that are not part of DataMiner but are required by this protocol). When the protocol gets published on SVN by the CI/CD pipeline, the DLLs provided in this folder will automatically also be published on SVN. This ensures that the required DLLS will be available on SVN next to the protocol XML file.

- *Documentation*: This folder can be used to add documentation related to this solution.

- *Internal*: This folder contains the C# class library Visual Studio projects for the QAction helper (QAction_Helper) and the class library code (QAction_ClassLibrary). The latter is no longer available as of v2.41. This folder is hidden by default, as this code is generated automatically and therefore should not be touched.

> [!NOTE]
> As from DIS v2.41, an information bar will allow you to convert existing solutions that make use of the Class Library generation feature.
> This information bar will appear when a Class Library project (i.e. a project named "QAction_ClassLibrary" or "AutomationScript_ClassLibrary") is detected in a protocol or Automation script solution. As soon as you click *Fix*, the Class Library project will be removed and the references to the project will be replaced by references to the automatically generated Class Library project (which, by default, will have ID 63000).

- *QActions*: This folder contains a C# class library Visual Studio project per QAction defined in the protocol XML file. The name of each project is QAction\_\<id>, where \<id> is the ID of the QAction as defined in the protocol XML file (e.g. QAction_2).

- *Solution items*: This folder contains the protocol XML. The main difference between a solution protocol XML file and a regular protocol XML file is that the former does not contain the QAction C# code (as this is now in the QAction projects in the Visual Studio solution).

- *Tests*: In this folder you can add test projects.

> [!NOTE]
> Test projects should only be integrated in protocol solutions with the purpose of testing protocol functionality (so not for system tests including certain Automation scripts, etc.).
