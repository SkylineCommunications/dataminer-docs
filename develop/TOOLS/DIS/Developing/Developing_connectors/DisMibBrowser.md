---
uid: DIS_MIB_Browser
---

# Getting Started with the DIS MIB Browser

> [!TIP]
> See also: [Tutorial: Exploring the DIS MIB Browser](xref:DisTutorials_MibBrowser)

> [!NOTE]
> All images displayed on this page show DataMiner Integration Studio version 2.44.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

  > [!TIP]
  > For more information on how to install DIS, see [Prerequisites](xref:Prerequisites).

- Basic knowledge of network management concepts, especially MIB and SNMP

## Launching the MIB Browser

After installing the DIS extension, open Visual Studio and go to *Extensions* > *DIS* > *Tool Windows* > *DIS MIB Browser*.

![Visual Studio Menu - DIS - MIB Browser](~/develop/images/DIS_Menu_MibBrowser.png)

By default, the *DIS MIB Browser* window will open undocked. Dock it just as you would dock any other tool window in Visual Studio.

> [!TIP]
> For an overview of the three main tabs in the *DIS MIB Browser* tool window, see [DIS MIB Browser](xref:DisMibBrowserToolWindow).

## Loading MIB files

1. For every MIB file you want to load into the MIB tree, go to the *Files* tab, click *Add*, locate and select the file, and click *Open*.

   > [!NOTE]
   > The MIB browser allows you to import files with the following extensions: *mib*, *smi*, and *txt*.

1. If, for any reason, the list contains a MIB file that does not have to be loaded into the MIB tree, then clear the *Active* checkbox in front of it.

1. Click *Load Files* to load the listed MIB files into the MIB tree.

   When not all MIB files could be loaded, an error message will be shown.

![MIB Browser-Loading](~/develop/images/DIS_ToolWindow_MibBrowser_LoadingFiles.gif)

When you want to remove files from the list, select them and click *Remove*. To select more than one file, click one, and then click another while holding down the CTRL key. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.

## Generating parameters

### Generating an individual parameter

To generate a single parameter, drag a parameter from the MIB Tree and drop it into the connector at your chosen location.

The DIS tool will automatically retrieve the relevant MIB data and populate the parameter accordingly.

![MIB Browser-Drag&Drop](~/develop/images/DIS_ToolWindow_MibBrowser_DragAndDrop.gif)

> [!NOTE]
>
> - When you drag and drop a column parameter, the table name will only be added if it is not already included.
> - If the SNMP name of a table contains "Table", this string will be excluded from the column parameter name and description. This prevents table names from being duplicated in column parameter names.

### Generating parameters in bulk

In larger projects, generating multiple parameters simultaneously may be beneficial:

1. Right-click your chosen location within the XML file.

1. Select *Generate Parameters*.

   ![MIB Browser-Generate Parameters](~/develop/images/DIS_ToolWindow_MibBrowser_ContextMenu_GenerateParameters.png)

   This action opens the *Generate Parameters Wizard*.

1. Specify the necessary information:

   1. **Input type**: The default is *MIB*.

   1. **Item selection**: Choose the parameters you want to generate from the list of available items. For table generation, the wizard auto-includes columns, but you can omit any unnecessary ones.

      ![DIS - Generate Parameters - Choose Params](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_ChooseParams.png)

   1. **Parameter ID settings**: Define a starting ID for the generated parameters. Adjust the offset for write parameters.

   1. **ID validity check**: A list of all parameters about to be generated is displayed, highlighting any potential ID conflicts. Modify IDs if needed.

      ![DIS - Generate Parameters - Validate IDs](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_ValidateIds.png)

      > [!NOTE]
      > After this point, you can skip additional settings and generate parameters immediately by selecting *Finish*.

   1. **Timers**: A list of all timers in the connector is displayed. You can modify the current timers or add new ones.

      ![DIS - Generate Parameters - Timers](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_Timers.png)

   1. **Groups**: The wizard suggests groups based on your current selections. You can modify these groups or add new ones. If applicable, select an appropriate timer for the groups.

      ![DIS - Generate Parameters - Groups](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_Groups.png)

   1. **Group assignment**: Decide which group each parameter belongs to.

      ![DIS - Generate Parameters - Group Params Assignment](~/develop/images/DIS_ToolWindow_MibBrowser_GenerateParameters_GroupParams.png)

1. Select *Finish* in the lower right corner to generate your parameters, along with their respective groups and timers.

## Comparing the connector with MIB Files

Your SNMP connector should always be up-to-date with the latest MIB files. The DIS MIB Browser's *Compare* tab offers an effective way to identify any disparities between your connector and the MIB files.

1. In the DIS MIB Browser, go to the *Compare* tab.

1. Click *Refresh* to synchronize the data.

1. Observe any potential differences between the loaded MIB files and your connector:

   - The top list displays parameters found in the MIB files that are missing in your connector.

   - The bottom list displays parameters found in your connector that are missing in the loaded MIB files.

   > [!NOTE]
   > You can copy and share any differences by selecting *Copy to Clipboard*.

   ![DIS ToolWindow - MIB Browser - MIB Tree - Compare](~/develop/images/DIS_ToolWindow_MibBrowser_Compare.png)

1. If there are parameters missing from your connector, use the *drag and drop* feature to transfer them from the top list to the connector.

   This action will enable the DIS MIB Browser to populate various parameter details automatically, streamlining the integration process.
