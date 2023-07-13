---
uid: Developing_Automation_scripts_as_Visual_Studio_solutions
---

# Developing Automation scripts as Visual Studio solutions

- An Automation script solution can contain multiple scripts, whereas a connector solution can only contain one single connector.

- C# projects that contain the code for the C# Exe blocks of an Automation script can contain multiple .cs files. At compilation, the contents of those files will be combined into one Exe block.

- DLL imports need to be configured on the C# project itself by adding references to the external components. These can be external DLL files (located in C:\\DataMiner\\ProtocolScripts or C:\\DataMiner\\Files) or other scripts in the same solution.

    > [!NOTE]
    > If you want an external DLL file to be placed in a specific folder instead of C:\\DataMiner\\ProtocolScripts, then specify the full path to that folder in the *DataMiner DLL Path* property of that DLL file.
    >
    > As from DIS v2.42, this feature has been removed. If this is required for a particular use case, please contact [Data Acquisition](mailto:support.data-acquisition@skyline.be).

- ​Up to DIS v2.40, it was only possible to refer to a [library script Exe](xref:Compiling_a_CSharp_code_block_as_a_library) from within the same Automation script. As from DIS v2.41, in a Visual Studio solution, you can also add a reference to a project from another Automation script in the solution. DIS will then automatically add a `scriptRef`.

  See the following example, in which `{SCRIPTNAME}` is the name of the other script containing the library and `{LIBRARYNAME}` is the name of the library:

  ```xml
  <Param type="scriptRef">{SCRIPTNAME}:{LIBRARYNAME}</Param>
  ```

  As DIS will automatically add a `scriptRef`, developers will only need to add a reference to the project that represents the library.

> [!TIP]
> For a video course on creating Visual Studio Automation script solutions, see [DataMiner Automation](https://community.dataminer.services/courses/dataminer-automation/) on DataMiner Dojo.

## Creating an Automation script solution

To create a new Automation script solution containing an initial Automation script, follow the instructions below.

In Visual Studio 2022, perform the following steps:

1. Select *File \> New \> Project*.
1. In the *Create a new project* pop-up window, select *DataMiner Automation Script Solution*.
1. Enter the name and location of the solution, then click *Next*.
1. Provide the name of the Automaton script and the author, and click *Create*.

In Visual Studio 2019, perform the following steps:

1. Select *File \> New \> DataMiner Automation Script Solution*.
1. Enter the name of the solution.
1. Select the target folder.

   > [!NOTE]
   > The default protocol solution folder and the default Automation script folder can both be specified in *DIS Settings \> Solutions*.

1. Select *Create initial Automation script* if you want to solution to contain a basic script with one Exe block.
1. Click *OK*.

> [!NOTE]
> If another solution is open when you perform step 1, you will be asked whether you want to save unsaved changes.

## Creating a new script in a solution

To create a new script in an Automation script solution, do the following:

1. Open the Automation script solution.
1. Select *File \> New \> New DataMiner Automation Script...* or right-click a solution folder in the Solution Explorer and select *Add \> New DataMiner Automation Script...*
1. Enter the name of the new script.
1. Click *OK*.

## Importing an existing script that is stored on your local computer

To import an existing Automation script stored on your local computer into an Automation script solution, do the following:

1. Right-click a solution folder in the Solution Explorer.
1. Select *Add \> Existing DataMiner Automation Script*.
1. Select a least one Automation script file.
1. Click *Open*.

> [!NOTE]
> When you add existing scripts to an Automation script solution, they are automatically converted to the correct format. For each C# Exe block, a C# project is created, and the code in that C# Exe block is transferred to the newly created C# project.

## Importing an existing script that is stored on the DataMiner Agent you are connected to

To import an existing Automation script stored on the DMA you are connected to into an Automation script solution, do the following:

1. Right-click a solution folder in the Solution Explorer.
1. Select *Add \> Import DataMiner Automation Script*.
1. Select a least one Automation script file.
1. Click *Open*.

> [!NOTE]
>
> - This new *Import DataMiner Automation Script* option will only be available if DIS is connected to a DataMiner Agent.
> - When you add existing scripts to an Automation script solution, they are automatically converted to the correct format. For each C# Exe block, a C# project is created, and the code in that Exe block is transferred to the newly created C# project.

## Saving a compiled script to a file

A compiled Automation script can be saved either as an XML file or as a *.dmapp* package.

To save a compiled Automation script

1. Open the XML file containing the Automation script that you want to compile.
1. Select *File \> Save Compiled Script As...*
1. In the *Save As* window, select a folder, enter a file name, set *Save as type* to either "Automation script package (\*.dmapp)" or "Automation script file (\*.xml)", and click *Save*.

If you choose to save an Automation script as a package, the package will contain the Automation script as well as all required DLL files (e.g. DLL files of NuGet packages that are used in the Automation script).

## Saving all compiled scripts in a solution to a zip file

To save a compiled version of all Automation scripts in a solution to a zip file (with all C# code in their Exe blocks), do the following:

1. Open the XML files containing the Automation scripts that you want to compile.
1. Select *File \> Save All Compiled Scripts As...*
1. Enter a file name and a folder.
1. Click *Save*.

## Uploading a script to a DataMiner Agent

To upload an Automation script to a DataMiner Agent, do the following:

1. Open the XML file containing the Automation script.
1. Click *Publish* to compile the script and publish it to the DataMiner Agent that was set as default DMA in the *DMA* tab of the *DIS Settings* dialog box.

> [!NOTE]
> If you want to publish the script to another, non-default DMA, click the drop-down button at the right of the *Publish* button, and click the DMA to which you want the file to be published.

## Structure of an Automation script solution

An Automaton script Visual Studio solution is organized into various folders, each serving a specific purpose:

- **CompanionFiles**: This folder allows you to add additional files that need to be installed along with the Automation script as part of an installation package.

- **Dlls**: This folder contains the additional assemblies used by the Automation scripts. These assemblies are not part of DataMiner but are essential for one of the Automation scripts. Placing them in this folder ensures that the required assemblies are readily available in the repository alongside the Automation script XML files.

- **Documentation**: This folder allows you to add documentation related to the solution.

- **Internal**: This folder contains the C# Class Library Visual Studio project for the class library code (*AutomationScript_ClassLibrary*). Obsolete from DIS v2.41 onwards. This folder is hidden by default as the code within it is generated automatically and should not be modified.

  > [!NOTE]
  > From DIS v2.41 onwards, an information bar will appear when a Class Library project (i.e. a project named "AutomationScript_ClassLibrary") is detected in an Automation script solution. This information bar provides the option to convert existing solutions that use of the Class Library generation feature. By clicking *Fix*, the Class Library project will be removed, and references to the project will be replaced with references to the automatically generated Class Library project (default ID 63000).

- **Scripts**: This folder contains subfolders, with each subfolder representing an individual Automation script. The name of each subfolder corresponds with the name of the Automation script. Inside each subfolder, you will find the XML file for the Automation script and a subfolder named "Actions". The *Actions* folder contains the C# projects for each C# Exe block present in the Automation script.

- **QActions**: This folder contains a C# Class Library project for each QAction defined in the protocol XML file. These projects are named `QAction_<id>`, where \<id> represents the ID of the QAction as defined in the protocol XML file (e.g. QAction_2).

- **Tests**: This folder is intended for test projects.

  > [!NOTE]
  > Test projects should only be integrated into protocol solutions for the purpose of testing protocol functionality. They should not be used for system tests that include certain Automation scripts, among other things.
