---
uid: DIS_2.14
---

# DIS 2.14

## New features

### IDE

#### DIS MIB Browser: Error messages will now be shown when not all MIB files could be loaded \[ID_19905\]

From now on, the following error messages will be shown in the *DIS MIB Browser* window when not all MIB files could be loaded:

- If there are pending modules:

    ```txt
    Some MIB files could not be loaded because they contain a reference to one or more modules that could not be found. Please check the Missing/Pending modules sections.
    ```

- If some files could not be parsed:

    ```txt
    Some MIB files could not be compiled. Please check the Errors section.
    ```

Also, items in the *Pending Modules* section will now be displayed in orange and items in the *Missing Modules* section will be displayed in red.

#### XML editor: Update button indicating that a new DIS version is available will now have an orange background \[ID_20077\]

If DataMiner Integration Studio is set to check for updates, an *Update…* button will appear if a newer version of the DataMinerIntegrationStudio.vsix file is available on the DataMiner Collaboration Platform. From now on, this *Update...* button will have an orange background.

#### XML editor: ‘Copy Script to Clipboard’ command \[ID_20150\]

When you are editing an Automation script file, you can click the small Down arrow in front of the Script.Exe element to open a shortcut menu. In that menu, you will now find a *Copy Script to Clipboard* command, which will allow you to easily copy an entire Automation script to another file.

#### XML editor: No longer possible to publish a protocol with an incorrect Type tag, an empty Version tag or an empty Name tag \[ID_20182\]

When, in the XML editor, you click *Publish* in order to publish the protocol you are editing, DIS will now refuse to publish the protocol and show a message box

- when the Protocol.Type tag contain an incorrect value,
- when the Protocol.Version tag is empty, or
- when the Protocol.Name tag is empty.

#### New tool window: DIS Macros \[ID_20348\]

The new *DIS Macros* tool window allows developers to create C# scripts that can be used to make changes to a protocol file (e.g. update OIDs based on conditions, update table definitions, increment/decrement parameters, etc.).

To open the tool window, open the DIS menu, and click *Tool Windows \> DIS Macros*.

- In the tool window, you can set up a folder structure into which you can then store the macros you create. It is also possible to export a macro folder to a zip file and to import a zip file containing macros as a child folder of an existing folder.
- At the top of the tool window, you find two buttons: *Run* and *Open*.

  - Click *Run* to run the selected macro.
  - Click *Open* to edit the selected macro.

  > [!NOTE]
  > When you run a macro, it will always affect the last XML or C# document that was active.

##### Structure of a macro file

In essence, a DIS macro consists of a Script class containing a Run() method that passes an Engine object. That object provides access to input data and allows you to modify the document, write log entries, etc.

The following input data is available in the "engine.Input" object:

- File name
- File content
- Cursor position
- Selected text blocks (start, length and contents)
- If the macro is run on a Protocol.xml file:

  - Parsed XML object structure
  - Parsed protocol model

The following methods are available in the "engine" object:

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

### Validator

#### Protocol.CheckNameTag check now also returns an error if the protocol name starts with 'Production' \[ID_20285\]

From now on, the Protocol.CheckNameTag check will also return an error if the name of a protocol starts with "Production".

If an error of this type appears in the *DIS Validation* window, you will be able to fix it right away. If you right-click the error and select *Fix \> This error*, the "Production" prefix will be removed.

| ID    | Check                 | Error message |
|-------|-----------------------|---------------|
| 1.2.5 | Protocol.CheckNameTag | InvalidPrefix |

### XML Schema

#### Protocol Schema: New elements and attributes \[ID_20112\]\[ID_20113\]

The Protocol XML schema now supports the following elements and/or element attributes:

| Element                     | Attribute       |
|-----------------------------|-----------------|
| Protocol.Chains.SearchChain |                 |
| Protocol.Params.Param       | pollingInterval |

#### Protocol Schema: Updated element and attribute rules \[ID_20114\]\[ID_20117\]\[ID_20118\]\[ID_20120\]\[ID_20121\]\[ID_20133\]\[ID_20403\]

The syntax rules for the following elements and/or attributes have been updated:

| Element/attribute                      | Syntax rule                                                                         |
|----------------------------------------|-------------------------------------------------------------------------------------|
| Protocol.Groups.Group.Param            | Allowed parameter range is now identical to that of Protocol.Params.Param.          |
| Protocol.Params.Param@saveInterval     | Duration must be positive.                                                          |
| Protocol.Params.Param.Interprete.Range | If present, child element ‘Low’ must appear before child element ‘High’.            |
| Protocol.QActions.QAction@options      | Can now contain more than one option.                                               |
| Protocol.Timers.Timer.Content.Group    | Element can now also contain “col:#:#” (in which “#” must be replaced by a number). |
| Protocol.Triggers.Trigger.Name         | Must be unique.                                                                     |
| Protocol.Triggers.Trigger.On@id        | Must contain either an integer or “each”.                                           |

#### Protocol Schema: All elements and attributes must have a type defined \[ID_20404\]

From now on, all elements and attributes configured in the Protocol XML schema must explicitly have a type defined.

Also, the type of the following elements has been updated:

| Element      | Change                             |
|--------------|------------------------------------|
| Impact       | Type is now ‘xs:string’.           |
| NoTimeout    | Type is now ‘xs:string’.           |
| ActionToTake | Empty string is no longer allowed. |

#### Protocol Schema: Removed elements and attributes \[ID_20405\]

The following elements and/or element attributes have been removed from the Protocol XML schema:

| Element                    | Attribute |
|----------------------------|-----------|
| Protocol.Timers.Timer.Time | options   |

#### UOM Schema: New units added \[ID_20407\]

The following units have been added to the UOM Schema:

- mV/dB
- V/dBm

## Changes

### Enhancements

#### Debugging: Migrated elements can now also be debugged \[ID_20071\]

It is now also possible to debug elements that were migrated from one DataMiner Agent to another within a DataMiner System.

#### XML editor: Enhanced Automation script publication process \[ID_20255\]

A number of enhancements have been made to the Automation script publication process.

#### XML editor: Enhanced 'Automation Root' snippet and 'DataMiner Automation Script Template' file \[ID_20265\]

The following enhancements have been made to the ‘Automation Root’ snippet and the ‘DataMiner Automation Script Template’ file:

- An empty Script.Exe element of type “csharp” will now be added by default.
- The copyright and revision history text blocks are no longer located at the top of the XML file. They are now located inside the Script.Value element.

    > [!NOTE]
    > These two blocks have now also been added to the ‘Script Exe’ snippet.

- The parameters of type “using”, “ref” and “debug” are now commented by default as they can cause the script to fail.

    ```xml
    <!--<Param type="using">ADD_A_NAMESPACE_HERE</Param>-->
    <!--<Param type="ref">ADD_A_DLL_REFERENCE_HERE</Param>-->
    <!--<Param type="debug">true</Param>-->
    ```

#### XML editor: Exception handling added to 'QAction' snippet and 'After Startup' QAction of 'Protocol Root' snippet \[ID_20266\]

Exception handling (try-catch) has now been added to

- the “QAction” snippet, and
- the “After Startup” QAction of the “Protocol Root” snippet.

#### Validator: Text in Description column now wraps to the next line \[ID_20306\]

When the *Description* column of an error message in the *DIS Validator* window contains a large amount of text, from now on, that text will automatically wrap to the next line.

#### XML editor: Enhanced behavior when opening a QAction for editing \[ID_20336\]

Up to now, DIS would always ask you to save the protocol file when you opened a QAction for editing. From now on, it will only do so when necessary.

#### Settings.StyleCop file now included in DIS \[ID_20563\]

The Settings.StyleCop file, which contains all rule definitions used by StyleCop, is now included in DIS and automatically applied to all QAction and Automation script projects. It is no longer necessary to download and install this file manually.

### Fixes

#### IDE: MIB nodes incorrectly interpreted as tables during a MIB file import \[ID_20080\]

When importing a MIB file, in some cases, MIB nodes would be incorrectly interpreted as tables.

#### IDE - Display editor: Page names containing special characters were decoded incorrectly \[ID_20184\]

When the display editor was opened, in some cases, page names with special characters (e.g. “&”) would be decoded incorrectly.

#### Problem when creating a new protocol or Automation script file via File \> New \> File... \[ID_20297\]

When you created a new protocol or Automation script file via *File \> New \> File...*, in some cases, the new file would incorrectly be saved without the “.xml” extension.

#### IDE - DIS Tree View: Problem when removing redundant CDATA closing tags from a QAction \[ID_20358\]

When a CDATA element in a QAction had two closing tags (“\]\]\>\]\]\>”), and the DIS tree window indicated that it had found a syntax error in the QAction in question, the moment you removed one of those closing tags and closed the QAction, in some cases, it would become impossible to open the QAction again.

#### IDE: Problem when using 'Repeat selected text...' option \[ID_20546\]

In some cases, an “out of memory” exception could be thrown when you used the shortcut menu option “Repeat selected text...”.
