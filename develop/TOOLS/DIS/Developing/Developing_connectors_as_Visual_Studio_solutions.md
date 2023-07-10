---
uid: Developing_connectors_as_Visual_Studio_solutions
---

# Connector development

## Creating a new connector solution

To create a new connector solution, select *File \> New \> Project*.

In Visual Studio 2019, select *File \> New \> DataMiner Protocol Solution*

## Converting an existing protocol XML file to a solution

DIS supports converting an existing protocol XML file into a Visual Studio solution. To convert an existing protocol XML file to a solution, open the protocol XML file in Visual Studio and select *DIS \> Protocol \> Convert to Solution*

A new solution will be created, and the existing protocol XML file will be added. However, the [QAction](xref:Protocol.QActions.QAction) tags will not contain any C# code. For each of the QActions in the original protocol XML file, a new C# Class Library project will be created, and any DLL imports specified in the original QActions will be converted to references on the C# projects (pointing either to other C# projects or to DLL files).

> [!NOTE]
> When you open a protocol, DIS will automatically detect whether the protocol is solution-based. A protocol will be considered solution-based when the solution has a "Solution Items" folder containing a *protocol.xml* file and a "QActions" folder containing at least one C# project named "QAction\_\<id>".

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
> - A QAction project can contain several \*.cs files that you can organize in different folders. The files will then be combined when the protocol is assembled.
> - It is recommended to place all "using" directives inside the namespace instead of at the top of the file.
> - When developing connectors as a Visual Studio solution, DLL imports need to be configured by adding references on the C# project itself (instead of using the [dllImport](xref:Protocol.QActions.QAction-dllImport) attribute).

To introduce a reference to another QAction, select the QAction project, right-click, and select *Add* > *Reference*. In the *Reference Manager* window, select *Projects*, and then select the checkbox for the desired QAction project(s) you want to reference. This will be translated by DIS to `[ProtocolName].[ProtocolVersion].QAction.<id>.dll` imports in the protocol XML when the connector is assembled.

For custom DLLs, make sure the DLL is located in the *Dlls* folder of the solution. By doing so, the required custom DLLs for this connector will eventually also be included in the repository, alongside the protocol XML. To introduce a reference to this custom DLL, select the QAction project, right-click, and select *Add* > *Reference*. In the *Reference Manager* window, select *Browse*, navigate to the DLL, and select the corresponding checkbox.

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

A connector Visual Studio solution is organized into various folders, each serving a specific purpose:

- **Dlls**: This folder contains the custom DLLs used by this protocol. These DLLs are not part of DataMiner but are essential for this protocol. When the protocol is published on SVN through the CI/CD pipeline, the DLLs provided in this folder will also be automatically published on SVN. This ensures that the required DLLs are available on SVN alongside the protocol XML file.

- **Documentation**: This folder allows you to add documentation related to the solution.

- **Internal**: This folder contains the C# Class Library Visual Studio projects for the QAction helper (QAction_Helper) and the Class Library code (QAction_ClassLibrary). Obsolete from DIS v2.41 onwards. This folder is hidden by default as the code within it is generated automatically and should not be modified.

> [!NOTE]
> From DIS v2.41 onwards, an information bar will appear when a Class Library project (i.e. a project named "QAction_ClassLibrary" or "AutomationScript_ClassLibrary") is detected in a protocol or Automation script solution. This information bar provides the option to convert existing solutions that use of the Class Library generation feature. By clicking *Fix*, the Class Library project will be removed, and references to the project will be replaced with references to the automatically generated Class Library project (default ID 63000).

- **QActions**: This folder contains a C# Class Library Visual Studio project for each QAction defined in the protocol XML file. These projects are named `QAction_<id>`, where \<id> represents the ID of the QAction as defined in the protocol XML file (e.g. QAction_2).

- **Solution items**: This folder contains the protocol XML. The main difference between a solution protocol XML file and a regular protocol XML file is that the former does not contain the QAction C# code (as this is now in the QAction projects in the Visual Studio solution).

- **Tests**: This folder is intended for test projects.

> [!NOTE]
> Test projects should only be integrated into protocol solutions for the purpose of testing protocol functionality. They should not be used for system tests that include certain Automation scripts, among other things.
