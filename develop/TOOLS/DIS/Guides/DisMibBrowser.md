---
uid: DisGuides_MibBrowser
---

# Getting Started with the DIS MIB Browser

## Prerequisites

Before diving in, ensure you have the following:

- A working installation of Visual Studio. If you don't have it installed, you can download it [here](https://visualstudio.microsoft.com/downloads/).
- The extension 'DIS' installed. You can find this on [DataMiner Dojo](https://community.dataminer.services/exphub-dis/).
  - More information on how to install DIS can be found [here](https://docs.dataminer.services/develop/TOOLS/DIS/Installing_and_configuring/Prerequisites.html).
- Basic knowledge of network management concepts, especially MIB and SNMP.

1. **Launching the MIB Browser**

   After installing the extension, go to *Extensions* > *DIS* > *Tool Windows* > *DIS MIB Browser*.

   ![Visual Studio Menu - DIS - MIB Browser](~/develop/images/DIS_Menu_MibBrowser.png)

   By default, the tool window will open undocked. Dock it just as you would dock any other tool window in Visual Studio.

1. **Navigating the Browser Interface**

   Here's a brief rundown of the main components you'll encounter:

   - *MIB Tree*: Displays the MIB object hierarchy.
   - *Files*: Enables the loading and unloading of additional MIB files.
   - *Compare*: Useful for identifying missing OIDs in the connector and vice versa.

   ![DIS ToolWindow - MIB Browser - Default](~/develop/images/DIS_ToolWindow_MibBrowser_Default.png)

1. **Loading MIB Files**

   - Start by going to *Files* > *Add*.
   - Browser and select MIB file(s) you wish to load and click *Open*.
   - Click *Load files* to initiate the loading process.
   - Upon completion, your chosen MIB file structure will be displayed within the *MIB Tree*.

   ![DIS ToolWindow - MIB Browser - Files - Loading](~/develop/images/DIS_ToolWindow_MibBrowser_LoadingFiles.gif)

   - When not all MIB files could be loaded, an error message will be shown.
   - If you want to exclude a MIB file from being loaded, clear the *Active* checkbox in front of it.
   - If you want to remove files from the list, select them and click *Remove*.

## Efficient Parameter Generation

### Individual Parameter Generation

For a quick parameter creation:

- Simply drag the desired parameter from the MIB Tree and drop it into the connector at the location you want it to be.
- The DIS tool will automatically fetch the relevant MIB data and populate the parameter accordingly.

![DIS ToolWindow - MIB Browser - MIB Tree - Drag&Drop](~/develop/images/DIS_ToolWindow_MibBrowser_DragAndDrop.gif)

> [!NOTE]
> When you drag and drop a column parameter, the table name will only be added in front of the name when it is not already included.
> Also when the SNMP name of a table contains "Table", this string will be excluded from the column parameter name and description.
> This will prevent table names from being included twice in column parameter names.

### Bulk Parameter Generation

For larger projects, generating multiple parameters concurrently becomes invaluable:

- Right-click on your desired location within the XML.
- From the context menu, choose the *Generate Parameters...* option.

![DIS ToolWindow - MIB Browser - ContextMenu - Generate Parameters](~/develop/images/DIS_ToolWindow_MibBrowser_ContextMenu_GenerateParameters.png)

#### Generate Parameters Wizard

1. **Select Input Type**: By default, *MIB* is preselected. Click *Next* to proceed.
1. **Choose Desired Parameters**: View the items present in the MIB Browser and select the ones you wish to generate. For table generation, the wizard automatically adds the columns, but you can also omit unnecessary columns. After making your selections, press *Next*.

   ![DIS - Generate Parameters - Choose Params](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_ChooseParams.png)

1. **Set Initial Parameter ID**: Define a starting parameter ID for the generated parameters. Adjust the offset for write parameters. Then, proceed with *Next*.
1. **Check ID Validity**: This screen previews the upcoming parameter generation, highlighting any potential ID conflicts. If everything looks in order, click *Next*. If you wish to bypass additional settings and generate parameters immediately, select *Finish*.

   ![DIS - Generate Parameters - Validate IDs](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_ValidateIds.png)

1. **Manage Timers**: View and modify current timers in the connector, or introduce new ones. Opt for *Next* to define groups or *Finish* to generate parameters and timers.

   ![DIS - Generate Parameters - Timers](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_Timers.png)

1. **Establish or Update Groups**: The wizard offers group suggestions based on your current selections. You can edit these or introduce new ones. Assign each group to its appropriate timer if applicable, then click *Next*.

   ![DIS - Generate Parameters - Groups](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_Groups.png)

1. **Group Parameter Assignment**: Here you can decide which group each parameter belongs to. Once satisfied with your configurations, hit *Finish*. Your parameters, alongside their respective groups and timers, will then be generated.

   ![DIS - Generate Parameters - Group Params Assignment](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_GroupParams.png)

## Comparing Connector and MIB Files

The ability to swiftly identify descrepancies between your connector and MIB files is crucial. The DIS MIB Browser provides an efficient solution for this via its *Compare* tab. This tool helps ensure that your SNMP connectors are always updated in line with the most recent MIB files.

### Steps to Compare

1. **Accessing the Compare Feature**: In the DIS MIB Browser, navigate to the *Compare* tab. This is where you can view potential differences between your loaded MIB files and the connector.
1. **Synchronizing Data**: Click on the *Refresh* button. This action syncs the currently loaded MIB files with the connector, thus initiating a comparison.
1. **Analysing Differences**: Post synchronization, observe the two lists:
   - The **top** list displays any parameters present in the MIB files but missing from your connector.
   - The **bottom** list highlights parameters that are found in your connector but absent in the loaded MIB files.

   ![DIS ToolWindow - MIB Browser - MIB Tree - Compare](~/develop/images/DIS_ToolWindow_MibBrowser_Compare.png)

Using these lists, you can quickly spot any new additions or removals in the MIB file relative to the connector.

For any missing parameters in the connector, leverage the drag & drop feature detailed earlier in this guide. Simply select the desired parameter from the top list and drag it to the connector. The DIS MIB Browser will use the MIB's information to populate several parts of the parameter automatically, ensuring a seamless integration process.

In case you want to share the differences, you can use the *Copy to Clipboard* button to copy the results to the Windows Clipboard.

## See also

- [DIS MIB Browser](xref:DisMibBrowserToolWindow)
