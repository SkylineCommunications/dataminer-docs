---
uid: DIS_menu
---

# DIS menu

After you have installed the *DataMinerIntegrationStudio.vsix* extension, the Microsoft Visual Studio menu bar will have a DIS menu.

The following sections provide more information on the DIS menu:

- [DMA](#dma)
- [Protocol \> Generate QAction helper code](#protocol--generate-qaction-helper-code)
- [Protocol \> Generate Class Library code](#protocol--generate-class-library-code) (removed since v2.41)
- [Protocol \> Convert to Solution...](#protocol--convert-to-solution)
- [Automation script \> Generate Class Library code](#automation-script--generate-class-library-code)
- [Plugins \> Generate driver help](#plugins--generate-driver-help)
- [Plugins \> Add After Startup](#plugins--add-after-startup)
- [Plugins \> Add matrix...](#plugins--add-matrix)
- [Plugins \> Add SNMP System Info...](#plugins--add-snmp-system-info)
- [Plugins \> Add SNMP Trap Receiver...](#plugins--add-snmp-trap-receiver)
- [Plugins \> Add Table Context Menu...](#plugins--add-table-context-menu)
- [Tool Windows \> DIS Tree View](#tool-windows--dis-tree-view)
- [Tool Windows \> DIS Mappings View](#tool-windows--dis-mappings-view)
- [Tool Windows \> DIS Macros](#tool-windows--dis-macros)
- [Tool Windows \> DIS Inject](#tool-windows--dis-inject)
- [Tool Windows \> DIS MIB Browser](#tool-windows--dis-mib-browser)
- [Tool Windows \> DIS Grid View](#tool-windows--dis-grid-view)
- [Tool Windows \> DIS Diagram](#tool-windows--dis-diagram)
- [Tool Windows \> DIS Validator](#tool-windows--dis-validator)
- [Tool Windows \> DIS Comparer](#tool-windows--dis-comparer)
- [Settings](#settings)
- [Check for updates...](#check-for-updates)
- [Help](#help)

## DMA

In the *DMA* submenu, you can find the following commands:

- Connect

    The *Connect* submenu lists all the DMAs configured in the *DMA* tab of the *DIS Settings* window. In the list, click the DMA to which you want DataMiner Integration Studio to connect.
    See [DMA](xref:DIS_settings#dma)

- Disconnect

    If you click *Disconnect*, DataMiner Integration Studio will disconnect from the DMA to which it was connected.     See [DMA](xref:DIS_settings#dma)

- Import Protocol

    If you click *Import Protocol*, the *Import Protocol* dialog box will allow you to import a copy of an existing protocol XML file found on the DMA to which DIS is connected. In order to make a clear distinction between main protocols and DVE protocols, the *Import Protocol* dialog box lists all available protocols in a three-level tree structure:

    - Level 1: Main protocols
    - Level 2: Protocol versions
    - Level 3: DVE protocols

    You can import multiple protocols at once (even a combination of main protocols and DVE protocols). Select the protocols you want to import, and click *Import*. Each protocol will be opened in a separate tab.

    > [!NOTE]
    >
    > - Use the filter box in the top-right corner to filter the list of protocols.
    > - In order to prevent users from accidentally publishing a DVE protocol, it is not possible to publish a DVE protocol from inside DIS. When DIS detects that the *Protocol/Name* tag contains a *parentProtocol* attribute and that it is not empty, publishing will fail and a warning message will appear.
    > - When DIS connects to a DataMiner Agent, it always uses polling.
    > - If this *Import Protocol* command is unavailable, you are not connected to a DMA. In the *DMA* menu, go to *Connect*, and click the DMA to which you want DIS to connect. See [DMA](xref:DIS_settings#dma)

- Import Automation script

    If you click *Import Automation script*, the *Import Automation Script* dialog box will allow you to import a copy of an existing Automation script XML file found on the DMA to which DIS is connected.

    You can import multiple Automation scripts at once. Select the scripts you want to import, and click *Import*. Each script will be opened in a separate tab.

    > [!NOTE]
    >
    > - Use the filter box in the top-right corner to filter the list of Automation scripts.
    > - When DIS connects to a DataMiner Agent, it always uses polling.
    > - If this *Import Automation script..* command is unavailable, you are not connected to a DMA. In the *DMA* menu, go to *Connect*, and click the DMA to which you want DIS to connect. See [DMA](xref:DIS_settings#dma)

> [!NOTE]
>
> - When, in the DIS menu, you select *DMA > Import Protocol* while an Automation script solution is open, a pop-up window will appear, saying that it is impossible to import a protocol while an Automation script solution is open.
> - When, in the DIS menu, you select *DMA > Import Automation Script* while a protocol solution is open, a pop-up window will appear, saying that it is impossible to import an Automation script while a protocol solution is open.
> - When, in the DIS menu, you select *DMA > Import Automation Script* while an Automation script solution is open, a pop-up window will appear, asking you whether you want the script to be imported into the open Automation script solution.

## Protocol \> Generate QAction helper code

C# helper classes are automatically added or updated each time you switch from an XML editor tab to a C# editor tab (or vice versa). If, however, you want to force an ad hoc update of all C# helper classes, you can select *Protocol \> Generate QAction Helper Code*.

## Protocol \> Generate Class Library code

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction). If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package (For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet)). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.

If you want to force an ad hoc regeneration of the Class Library QAction 63000 and the Class Library EXE blocks, you can click Generate Class Library Code.

DIS contains a class library with reusable C# code, such as classes and methods that can be used for e.g. creating elements and services, processing DVEs, etc. Code from this library can be used in QActions and Automation scripts without having to copy/paste code from an external source into a protocol or a script.

The advantage of this approach is that no additional DLL files need to be copied to the DataMiner installation folder when a protocol or script is put into use. All necessary code is included in the protocol or script itself. By including all code in the protocol or the script, we also prevent future code library updates from rendering a protocol or script inoperable.

If, in the Class Library tab of the DIS Settings window, you selected the *Automatically generate Class Library code* option, DIS will automatically detect whether you are using any code from the Class Library in a QAction or Automation script, and copy all used classes, methods, etc. (along with all dependencies) from the class library to a generic QAction (with ID 63000) or Automation script EXE block. If you want to force an ad hoc regeneration of the Class Library QAction 63000 or Class Library EXE blocks, you can select *Protocol \> Generate Class Library Code* in the main DIS menu.

See also: [Class Library](xref:DIS_settings#class-library)

## Protocol \> Convert to Solution...

If you want to convert the standalone protocol XML file you opened in the XML editor to a protocol solution, select *Protocol \> Convert to Solution...*

As from v2.26, DIS offers two distinct ways of developing a DataMiner protocol. For more information see [Two ways of developing DataMiner protocols and Automation scripts](xref:Overall_concept_of_the_DataMiner_Integration_Studio#two-ways-of-developing-dataminer-protocols-and-automation-scripts) and [Developing DataMiner protocols and Automation scripts as Visual Studio solutions](xref:Developing_DataMiner_protocols_and_Automation_scripts_as_Visual_Studio_solutions).

## Automation script \> Generate Class Library code

See [Protocol \> Generate Class Library code](#protocol--generate-class-library-code).

## Plugins \> Generate driver help

Generates the driver help.

## Plugins \> Add After Startup

Adds the after startup logic to the protocol. DIS will check whether the protocol.xml file contains an after startup trigger, and will add one if none was found. Apart from the trigger, it will also add all remaining items of the after startup flow.

See also [Executing a QAction after startup](xref:LogicExamples#executing-a-qaction-after-startup)

## Plugins \> Add matrix...

Adds a matrix and/or Inputs and Outputs tables to the protocol.

## Plugins \> Add SNMP System Info...

Adds the following SNMP System Info parameters to the protocol:

- System Description (1.3.6.1.2.1.1.1)
- System Object ID (1.3.6.1.2.1.1.2)
- System Uptime (1.3.6.1.2.1.1.3)
- System Name (1.3.6.1.2.1.1.5)
- System Contact (1.3.6.1.2.1.1.4)
- System Location (1.3.6.1.2.1.1.6)

## Plugins \> Add SNMP Trap Receiver...

Adds an SNMP trap receiver and a QAction with boilerplate code to process received traps.

## Plugins \> Add Table Context Menu...

Adds a custom context menu to a table in the protocol. You can choose between the following:

- Rows Manager (User-definable Keys): A default context menu that provides add, duplicate, edit and delete functionality.
- Rows Manager (Auto-incremented Keys): An extension of the previous type that allows developers to work with an auto-increment key parameter.
- Custom: Opens a wizard that allows you to specify the options.

## Tool Windows \> DIS Tree View

If you click *Tool Windows \> DIS Tree View*, the *DIS Tree* window will appear.

This tool window acts as a protocol table of contents, allowing you to easily navigate to a particular location in the protocol you are working on.

By default, the *DIS Tree* window will open undocked. You can dock it like any other tool window in Microsoft Visual Studio.

If you click an item in the DIS tree, two things will happen:

- The cursor in the file tab containing the protocol code will jump to the tag that defines the item you clicked.
- The lowest list box will list all items that are in some way linked to the item selected in the DIS tree.

If, for example, you select a Trigger, then

- the *Outgoing* list will show all items to which the selected Trigger contains a link,
- the *Incoming* list will show all items that contain a link to the selected Trigger, and
- the Conditions list will show all items referred to in the Trigger’s \<Condition> element.

### Opening the tree node where the cursor is in

When working in the XML editor or the C# editor, you can do one of the following to move the cursor to the DIS Tree and select the DIS tree node representing the element you are editing:

- Press a key combination (default: CTRL+1), or
- Click the following button, which is situated in the top-left corner of the DIS Tree window:

    ![](~/develop/images/SyncArrow_16x.jpg)

See also: [DIS keyboard shortcuts](xref:DIS_keyboard_shortcuts)

### Clicking or double-clicking items in the DIS Tree window

| If... | then... |
|-------|---------|
| you click an item in the DIS tree, | the lowest list box will list all items that are in some way linked to the item you selected in the DIS tree.<br> Example: When you click a write parameter (marked with “\[W\]”), then the associated read parameter will appear in the lowest list box.<br> Also, the cursor in the file tab containing the protocol code will jump to the tag that defines the item you clicked in the DIS tree. |
| you click the type of an item in the lowest list box (notice that the type turns into a hyperlink!), | the cursor in the file tab containing the protocol code will jump to the tag that defines the item you selected in the lowest list box. |
| you double-click an item in the lowest list box, | the item you double-clicked will be selected in the topmost list box.<br> Also, the cursor in the file tab containing the protocol code will jump to the tag that defines the item you double-clicked in the lowest list box. |

### Working with the breadcrumb control

At the top of the *DIS Tree* tool window, there is a breadcrumb control that allows you to quickly navigate to a particular location inside a protocol.xml file. This control always shows the path towards the node that is currently selected in the tree view (i.e. “Protocol \> Params \> Param”).

- If you click a breadcrumb (e.g. “Params”), the corresponding (parent) node will be selected in the tree view (e.g. “Params”).
- If you click an arrow next to a breadcrumb, a drop-down list will open, allowing you to immediately navigate to one of the child nodes.

### Expanding, collapsing or pinning DIS tree nodes

When you right-click a tree node in the *DIS Tree* tool window, a shortcut menu appears containing the following commands.

| Select... | in order to... |
|-----------|----------------|
| Expand recursive | Expand the selected tree node and all its underlying child nodes.<br> Note: If you perform this command on the root of the DIS tree, only its first-level child nodes (Params, Commands, Responses, Pairs, Groups, etc.) will be expanded. |
| Collapse recursive | Collapse the selected tree node. |
| Collapse parent | Collapse the node that contains the selected tree node. |
| Pin | Pin an XML node to the special pin section at the top of the *DIS Tree* tool window. |
| Unpin | Unpin a pinned node from the special pin section at the top of the *DIS Tree* tool window. |

### Pinning XML nodes

It is possible to pin XML nodes to a special pin section at the top of the *DIS Tree* tool window.

- To pin a node, right-click the node in the *DIS Tree*, and select *Pin* from the shortcut menu.
- To unpin a pinned node, right-click the node either in the *DIS Tree* or the pin section, and select *Unpin* from the shortcut menu.
- To unpin all pinned nodes, right-click a random node in the pin section, and select *Unpin All* from the shortcut menu.

When you hover over a pinned node in the pin section, a tooltip will appear, showing you more information about the node in question.

### Types of parameters that have a special indication in the Params node

When you open the *Params* node, certain types of parameters have a special indication. See the following table.

| Type of parameter        | Indication in DIS tree |
|--------------------------|------------------------|
| \<Type>array\</Type>     | \[Table\]              |
| \<Type>write\</Type>     | \[W\]                  |
| \<Type>group\</Type>     | \[Group\]              |
| \<Type>read bit\</Type>  | \[RB\]                 |
| \<Type>write bit\</Type> | \[WB\]                 |

## Tool Windows \> DIS Mappings View

If you click *Tool Windows \> DIS Mappings*, the *DIS Mapping* window will appear.

This tool window allows you to visualize relationships between items in the protocol you are working on.

By default, the *DIS Mapping* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

- In the topmost selection box, select the type of items of which you want to see a list. Next to each type, you will see the number of items of that type in the current protocol.
- In the list box underneath the selection box, which lists all items of the selected type, select an item by clicking its ID.
- The lowest list box lists all items that have a link to the item selected in the list box above.

If, for example, you select an Action, then

- the *Outgoing* list will show all items to which the selected Action contains a link,
- the *Incoming* list will show all items that contain a link to the selected Action, and
- the Conditions list will show all items referred to in the Action’s \<Condition> element.

### Clicking or double-clicking items in the DIS Mapping window

| If... | then... |
|-------|---------|
| you click anywhere on a line in the topmost list box, except on the name of the item, | the lowest list box will list all items that are in some way linked to the item you selected in the topmost list box. |
| you click the name of an item in the topmost list box (notice that the name turns into a hyperlink!), | the cursor in the file tab containing the protocol code will jump to the tag that defines the item you selected in the topmost list box. |
| you double-click an item in the lowest list box, | the item you double-clicked will be selected in the topmost list box.<br> Note: The selection box at the top of the *DIS Mapping* window will be set to the type of the item you double-clicked. |
| you click the type of an item in the lowest list box (notice that the type turns into a hyperlink!), | the cursor in the file tab containing the protocol code will jump to the tag that defines the item you selected in the lowest list box. |

## Tool Windows \> DIS Macros

If you click *Tool Windows \> DIS Macros*, the *DIS Macros* window will appear.

By default, the *DIS Macros* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

This tool window allows you to create C# scripts that can be used to make changes to a protocol file (e.g. update OIDs based on conditions, update table definitions, increment/decrement parameters, etc.).

In the tool window, you can set up a folder structure into which you can then store the macros you create. It is also possible to export a macro folder to a zip file and to import a zip file containing macros as a child folder of an existing folder.

At the top of the tool window, you find two buttons: *Run* and *Open*.

- Click *Run* to run the selected macro.
- Click *Open* to edit the selected macro.

> [!NOTE]
> - When you run a macro, it will always affect the last XML or C# document that was active.
> - When you try to open a DIS macro while working inside a protocol or Automation script solution, a message will appear, asking whether you want to open the DIS macro in a new Visual Studio instance.

### Structure of a macro file

In essence, a DIS macro consists of a Script class containing a Run() method that passes an Engine object. That object provides access to input data and allows you to modify the document, write log entries, etc.

The following input data is available in the “engine.Input” object:

- File name
- File content
- Cursor position
- Selected text blocks (start, length and contents)
- If the macro is run on a Protocol.xml file:

    - Parsed XML object structure
    - Parsed protocol model

The following methods are available in the “engine” object:

| Method              | Function                                                                   |
|---------------------|----------------------------------------------------------------------------|
| LogToOutputWindow() | Log a message to Visual Studio’s Output pane.                              |
| ShowInputBox()      | Request user input.                                                        |
| ReplaceAllText()    | Replace all text in the document.                                          |
| ReplaceText()       | Replace a specified block of text in the document.                         |
| InsertText()        | Insert new text at a specified position.                                   |
| DeleteText()        | Delete a specified block of text.                                          |
| XmlEdit             | Group a series of changes that will afterwards be applied to the document. |
| ProtocolEdit        | Group a series of changes that will afterwards be applied to the document. |

## Tool Windows \> DIS Inject

If you click *Tool Windows \> DIS Inject*, the *DIS Inject* window will appear.

By default, the *DIS Inject* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

This tool window allows you to make the necessary preparations before debugging the QAction(s) or Automation script(s) you are editing.

For step-by-step instructions on how to debug QActions and Automation scripts, see [Debugging QActions and Automation scripts](xref:Debugging_QActions_and_Automation_scripts).

### Connecting to one of the DMAs specified in the DIS settings

When you open the *DIS Inject* window, and you have not yet set up a connection to one of the DMAs specified in the *DMA* tab of the *DIS Settings* window, then a large *Connect* button will appear in the middle of the window. Click that button to connect DataMiner Integration Studio to the default DMA. If you want to connect to another, non-default DMA, click the drop-down button at the right of the *Connect* button, and click the DMA to which you want to connect.

See [Connect](xref:DIS_menu) and [DMA](xref:DIS_settings#dma)

> [!NOTE]
> The title of the *DIS Inject* window includes the name of the DMA to which DIS is connected (between brackets). When DIS is not connected to any DMA, the window title will include “(not connected)”.

### Debugging a QAction

Go to the *Protocol* tab if you want to debug a QAction.

#### Selecting an element from the connected DMA

Use the selection box at the top of the window to select the element to be used during the debugging operation. This must be an element that uses the exact same protocol as the one you are currently editing.

#### Manipulating the selected element

Below the element selection box you can find the element manipulation tool bar. From left to right, the buttons on this toolbar allow you to:

- Start the element
- Pause the element
- Stop the element
- Restart the element
- Open the element in *Element Display*
- Open the element in *DataMiner Cube*
- Open the element’s log file.

    > [!NOTE]
    > - If DIS is connected to a remote DataMiner Agent, then make sure the *C:\\Skyline DataMiner\\logging* folder on that DataMiner Agent is shared and accessible.
    > - Element Display is no longer available from DataMiner 9.6.0 onwards.

#### Linking temporary QAction projects to QActions in the protocol of the selected element

When you have selected an element in the element selection box, the *DIS Inject* window will list all QActions found in the protocol of the selected element, and will automatically link the temporary projects of the QActions that are being edited to the QActions in the list based on protocol name and QAction ID.

When, for example, you open a QAction with ID 12, then the temporary project will be named “QAction_12”. By default, when you open the *DIS Inject* window while editing QAction 12, then the *Project* selection box in row 12 will be set to “QAction_12”. If you want to override this default linking mechanism, and you want to link a different temporary project to a particular QAction, open the *Project* selection box, and select another project.

| If you click... | then... |
|-----------------|---------|
| the green plus, | you will replace (i.e. inject) the element's *QAction.dll* file (compiled in Release mode) with its counterpart found in the temporary QAction project (compiled in Debug mode). |
| the red X, | you will sever the temporary link between the element and the *QAction.dll* compiled in Debug mode.<br> This will restore the link between the element and its original *QAction.dll* (compiled in Release mode). |
| the yellow lightning bolt, | you will manually trigger the QAction by simulating a change of the parameter selected in the *Trigger ID* box (in case of a dynamic table parameter, use the *Trigger Key* box to specify the table row).<br> Only do this after you have attached the SLScripting process to the Debugger. |

#### Attaching the Microsoft Visual Studio Debugger to the DataMiner SLScripting process

After injecting the necessary *QAction.dll* files, you have to attach the Debugger to the SLScripting process.

| If you click... | then... |
|-----------------|---------|
| Attach | all temporary QAction projects will be built, and the Microsoft Visual Studio Debugger will be attached to the DataMiner SLScripting process.<br> Note: The design of the Microsoft Visual Studio screen will change and you will notice the word “Running” in the title bar. |
| Detach | the Microsoft Visual Studio Debugger will be detached from the DataMiner SLScripting process. |

### Debugging an Automation script

Go to the *Automation script* tab if you want to debug an Automation script.

#### Selecting an Automation script from the connected DMA

Use the selection box at the top of the tab to select the Automation script to be debugged.

#### Linking Exe block projects, assigning values to script parameters, and linking elements to script dummies

- In the Exe blocks list, go to the row of which the Exe ID matches that of the Exe block you have opened. If necessary, in the *Project* column, select another temporary Exe block project.
- In the script parameters list, assign a value to each of the script parameters in the list.
- In the script dummies list, link a DataMiner element to each of the script dummies in the list.

#### Attaching the Microsoft Visual Studio Debugger to the DataMiner SLAutomation process

After linking the Exe block projects, assigning values to the script parameters, and linking elements to the script dummies, you have to attach the Debugger to the SLAutomation process.

| If you click... | then... |
|-----------------|---------|
| Attach | all temporary Exe block projects will be built, and the Microsoft Visual Studio Debugger will be attached to the DataMiner SLAutomation process.<br> Note: The design of the Microsoft Visual Studio screen will change and you will notice the word “Running” in the title bar. |
| Detach | the Microsoft Visual Studio Debugger will be detached from the DataMiner SLAutomation process. |

#### Triggering the Automation script

Click *Execute* to manually trigger the Automation script.

## Tool Windows \> DIS MIB Browser

If you click *Tool Windows \> DIS MIB Browser*, the *DIS MIB Browser* window will appear.

This tool window allows you to build \<*Param>* tags based on OID data in MIB files.

By default, the *DIS MIB Browser* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

> [!NOTE]
> The MIB Browser currently supports adding parameters of type Gauge32, Integer, Integer32, TimeTicks and Unsigned32.

### MIB tree

The *MIB Tree* tab shows a graphical representation of all loaded MIB files.

To automatically create a *\<Param>* tag based on a particular OID in the MIB tree, drag the OID onto an open protocol XML file and, if necessary, modify the imported data (which will be highlighted).

> [!NOTE]
> - When you drag a table parameter from the *DIS MIB Browser* tool window onto a protocol.xml file, the table name will only be added in front of the name of the column parameter when it is not already included in the latter. Also, when the SNMP name of a table contains “Table”, this string will be excluded from column parameters names and descriptions. This will prevent table names from being included twice in column parameter names.
> - In the MIB tree, obsolete, deprecated and duplicate MIB nodes are indicated by a special icon.

### Files

The *Files* tab allows you to load MIB files into the MIB tree.

1. For every MIB file you want to load into the MIB tree, click *Add*, locate and select the file, and click *Open*.
1. If, for any reason, the list contains a MIB file that does not have to be loaded into the MIB tree, then clear the *Active* checkbox in front of it.
1. Click *Load Files* to load the listed MIB files into the MIB tree.

    When not all MIB files could be loaded, an error message will be shown.

When you want to remove files from the list, select them and click *Remove*. To select more than one file, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.

The bottom half of the *Files* tab contains three sections:

| Section | Contents |
|---------|----------|
| *Loaded Modules* | All MIB modules that are currently loaded into the MIB tree.<br> Note: A number of modules are loaded by default and will therefore always be listed in this section. |
| *Pending Modules* | All MIB modules that cannot be loaded because they contain references to other MIB modules that cannot be found. |
| *Missing Modules* | All MIB modules that cannot be found. |

> [!NOTE]
> - The location of the MIB store and other MIB browser settings can be specified in the *MIB* tab of the *DIS Settings* window. See: [MIB](xref:DIS_settings#mib)
> - The MIB browser allows you to import files with the following extensions: *mib*, *smi*, and *txt*.
> - DIS by default contains most common IANA and IETF MIB files. These MIB files contain common definitions that are often used in MIB files supplied by equipment vendor.

### Compare

The *Compare* tab shows the differences between the OID data in the MIB tree and the parameter data in the protocol XML file.

- The top pane lists the OIDs that do not have a corresponding *\<Param>* tag in the protocol XML file.
- The bottom pane lists the *\<Param>* tags in the protocol XML file that do not have a corresponding OID in the MIB tree.

At the top of the *Compare* tab, you can find two buttons:

- Click the *Refresh* button to rerun the comparison.
- Click the *Copy to Clipboard* button to copy the results of the latest comparison to the Windows Clipboard.

## Tool Windows \> DIS Grid View

If you click *Tool Windows \> DIS Grid View*, the *DIS Grid* window will appear.

This tool window allows you to manage and configure all parameters in the protocol using a spreadsheet-like view.

By default, the *DIS Grid* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

### Filtering the parameter list

At the top of the window, there is a filter bar that allows you to narrow down the parameters list.

- To set a filter, enter a piece of text or select a preset value in one or more of the filter boxes.
- To clear the filter, click *Clear filter*.

### Editing cell content

To edit data in the parameter list, just click inside a cell, and change its contents.

In some cells, you can enter text, while in other cells, you have to select a preset value or a checkbox.

### Using the right-click menu commands

When you right-click a row in the parameter list, a shortcut menu appears.

| Select... | in order to... |
|-----------|----------------|
| Fix Description | Apply the capitalization rules to the parameter description. |
| Insert Before | Add a new, blank parameter row above the one you right-clicked. |
| Insert After | Add a new, blank parameter row below the one you right-clicked. |
| Duplicate | Duplicate the row you right-clicked. |
| Delete | Delete a parameter row from the list. |
| Navigate | Make the cursor in the file tab containing the protocol code jump to the corresponding *\<Param>* tag.<br> Note: Instead of selecting *Navigate*, you can also press F12. |

### Managing parameter positions

When you have selected a parameter in the list, the *Positions* list at the bottom of the window lists all places where that parameter appears on the element card.

To edit existing data, just click inside a cell, and change its contents.

When you right-click a row, a shortcut menu appears.

| Select... | in order to... |
|-----------|----------------|
| Insert Before | Add a new, blank parameter row above the one you right-clicked. |
| Insert After | Add a new, blank parameter row below the one you right-clicked. |
| Duplicate | Duplicate the row you right-clicked. |
| Delete | Delete a parameter row from the list. |
| Navigate | Make the cursor in the file tab containing the protocol code jump to the corresponding *\<Position>* tag.<br> Note: Instead of selecting *Navigate*, you can also press F12. |

> [!NOTE]
> If you prefer to position parameters using a graphical user interface, use the Display Editor. See [Display editor](xref:Display_editor)

### Managing discreet values

When, in the list, you have selected a parameter of type “discreet”, the *Discreets* list at the bottom of the window lists all discreet values that are defined for that parameter.

To edit existing data, just click inside a cell, and change its contents.

When you right-click a row, a shortcut menu appears.

| Select... | in order to... |
|-----------|----------------|
| Insert Before | Add a new, blank parameter row above the one you right-clicked. |
| Insert After | Add a new, blank parameter row below the one you right-clicked. |
| Duplicate | Duplicate the row you right-clicked. |
| Delete | Delete a row from the list. |
| Navigate | Make the cursor in the file tab containing the protocol code jump to the corresponding *\<Discreet>* tag.<br> Note: Instead of selecting *Navigate*, you can also press F12. |

## Tool Windows \> DIS Diagram

If you click *Tool Windows \> DIS Diagram*, the *DIS Protocol Diagram* window will appear.

This window shows a graphical representation of a protocol. It allows you to see how a protocol is built, navigate through its logic and investigate flow issues.

When you open the tool window, you first have to select an item to start from: a parameter, a QAction, a session, a response, a group, a trigger, an action or a timer. You can then set the required depth (i.e. the number of items you want to have displayed starting from or ending with the item you selected), the direction (see the table below) and the type of diagram (BoundedFR, EfficientSugiyama, FR, ISOM, KK, LinLog, LeftRightTree or TopBottomTree).

| Direction | Description |
|-----------|-------------|
| Forward   | Shows the specified\* number of linked items starting from the item you selected. |
| Reverse   | Shows the specified\* number of linked items ending with the item you selected.   |
| Both      | Shows the specified\* number of linked items starting from the item you selected, as well as the specified\* number of linked items ending with the item you selected. |

*\* The value entered in the Depth box.*

In the diagram itself, each item (parameter, QAction, session, response, group, trigger, action, timer) is represented by a box with a particular icon and color, showing the ID and name of the item.

- Click the ID of an item to navigate to that item in the protocol.xml file.
- Hover over an item to see a tooltip with its full name and full description.
- Double-click a box representing an item to make that item the new starting point of the diagram. This will cause the entire diagram to be redrawn.

In the top-left corner of the diagram, you also have a number of zoom options: a slider to adjust to zoom factor, a *1:1* button (to switch to zoom factor 1) and a *Fill* button to automatically adjust the zoom factor to the current size of the diagram window.

## Tool Windows \> DIS Validator

If you click *Tool Windows \> DIS Validator*, the *DIS Validator* window will appear.

This window lists the results of the latest protocol validation in a tree structure, grouped by severity and category.

At the top of the tool window, you can find two buttons:

- Click *Validate* to launch a new protocol validation.
- Click *Export* to export the results of the latest validation to a CSV file.

As of DIS v2.41, when you open a main DVE protocol and click *Validate*, DIS will not only validate the main protocol but also all its exported child DVE protocols.

## Tool Windows \> DIS Comparer

If you click *Tool Windows \> DIS Comparer*, the *DIS Comparer* window will appear.

This tool window allows you to compare two protocol.xml files.

By default, the *DIS Comparer* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

For more information on how to work with this tool window, see [Compare](xref:XML_editor#compare).

## Settings

If you click *Settings*, the *DIS Settings* dialog box will appear. In this dialog box, you can configure the DIS settings.

> [!TIP]
> See also:
> [Changing the DataMiner Integration Studio settings](xref:Installing_and_configuring_DataMiner_Integration_Studio#changing-the-dataminer-integration-studio-settings)

## Check for updates...

If you click *Check for updates…*, the *DIS Update* dialog box will appear. This dialog box will indicate whether or not a new DIS version is available.

## Help

If you click *Help*, the DataMiner Integration Studio user guide will open in a browser window.
