---
uid: Automation_scripts_as_a_Visual_Studio_solution
---

# Automation scripts as a Visual Studio solution

From DIS 2.31 onwards, developing Automation scripts as a Visual Studio solution is supported. While a protocol solution can only contain one single protocol, an Automation script solution can contain multiple scripts.

- C# projects that contain the code for the Exe blocks of an Automation script can contain multiple .cs files. At compilation, the contents of those files will be combined into one Exe block.

- DLL imports need to be configured on the C# project itself by adding references to the external components. These can be external DLL files (located in *C:\\DataMiner\\ProtocolScripts* or *C:\\DataMiner\\Files*) or other scripts in the same solution.

> [!TIP]
> See also: [Developing Automation scripts as Visual Studio solutions](xref:Developing_Automation_scripts_as_Visual_Studio_solutions)

## Creating an Automation script solution

To create a new Automation script solution containing one dummy Automation script, do the following:

1. Select *File* > *New* > *DataMiner Automation Script Solution*.

    > [!NOTE]
    > If another solution is open when you perform this step, you will be asked whether you want to save unsaved changes.

1. Enter the name of the solution.

1. Select the target folder.

    > [!NOTE]
    > The default protocol solution folder and the default Automation script folder can both be specified via *DIS Settings* > *Solutions*.

1. If you want the solution to contain a basic script with one Exe block, select *Create initial Automation script*.

1. Click *OK*.

## Creating a new script in a solution

To create a new script in an Automation script solution, do the following:

1. Open the Automation script solution.

1. Select *File* > *New* > *New DataMiner Automation Script* or right-click a solution folder in the Solution Explorer and select *Add* > *New DataMiner Automation Script*.

1. Enter the name of the new script.

1. Click *OK*.

## Adding an existing script to a solution

To add an existing Automation script to an Automation script solution, do the following:

1. Right-click a solution folder in the Solution Explorer.

1. Select *Add* > *Existing DataMiner Automation Script*.

1. Select at least one Automation script file.

1. Click *Open*.

> [!NOTE]
> When you add existing scripts to an Automation script solution, they are automatically converted to the correct format. For each Exe block, a C# project is created, and the code in that Exe block is transferred to the newly created C# project.

## Saving a compiled script

To save a compiled version of an Automation script to a file (with all C# code in its Exe block), do the following:

1. Open the XML file containing the Automation script that you want to compile.

1. Select *File* > *Save Compiled Automation Script*.

1. Enter a file name and a folder.

1. Click *Save*.

## Uploading a script to a DataMiner Agent

To upload an Automation script to a DataMiner Agent, do the following:

1. Open the XML file containing the Automation script.

1. Click *Publish* to compile the script and publish it to the DataMiner Agent that was set as default DMA in the *DMA* tab of the *DIS Settings* dialog box.

> [!NOTE]
> If you want to publish the script to another, non-default DMA, click the drop-down button at the right of the Publish button, and click the DMA to which you want the file to be published.
