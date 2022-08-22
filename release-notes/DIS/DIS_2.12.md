---
uid: DIS_2.12
---

# DIS 2.12

## New features

### IDE

#### QAction code library \[ID_13977\]

DIS now contains a code library with reusable C# code, such as classes and methods that can be used for e.g. creating elements and services, processing DVEs, etc. Code from that library can be used in all QActions without having to copy/paste code from an external source into the protocol.

When you use code from this built-in library in a particular QAction, DIS will automatically detect this code and copy all used classes, methods, etc. (along with all dependencies) from the code library to a generic QAction (with ID 63000).

The advantage of this approach is that no additional DLL files need to be copied to the DataMiner installation folder when the protocol is put into use. All necessary code is included in the protocol itself. By including all code in the protocol, we also prevent future code library updates from rendering a protocol inoperable.

In the *DIS Settings* window, a new *Code Library* tab has been added. In that tab, you can specify custom directories containing additional .cs code files to be added to the QAction code library.

#### Generate Parameters Wizard: New input type 'WSDL' \[ID_17747\]

The *Generate Parameters Wizard* window now also allows you to generate \<Param> tag (as well as all the necessary \<Timer>, \<Group>, \<Trigger> and \<Action> tags) based on parameter data in a WSDL file.

> [!NOTE]
> Up to now, you had to position the mouse cursor anywhere between two existing \<Param> tags before selecting the *Generate Parameters...* menu option. Now, this is no longer necessary. The parameters will automatically be added in the correct location.
>
> A *Generate Parameters...* command has now also been added to the DIS menu.

#### Enhanced grid view \[ID_18351\]

The *DIS Grid* window has been enhanced. This tool window allows you to manage and configure all parameters in the protocol using a spreadsheet-like view.

Important changes:

- A *Sequence* tag has been added.
- When a range tag is generated, a *Low* and a *High* tag is automatically included (default values: 0).
- When a position tag is generated, a *Row* and *Column* tag is automatically included (default values: 0).
- The right-click menu now also contains a *Duplicate* command.

#### QActions can now be built and maintained on a computer without a local DataMiner Agent \[ID_18457\]

The DataMiner DLL files that are necessary to build and maintain QActions are now included into the DIS installation file. Hence, it is now possible to build and maintain QActions on a computer that has no local DataMiner Agent installed.

The following DLL files are included:

- Interop.SLDms.dll
- QActionHelper.dll
- QActionHelperBaseClasses.dll
- SLManagedAutomation.dll
- SLManagedScripting.dll
- SLNetTypes.dll

#### DIS installation file: Additional prerequisites \[ID_18823\]

To ensure that the user's Visual Studio installation has all the assemblies required to run the DIS extension, two prerequisites have been added to the extension manifest:

- Visual Studio core editor
- .NET Framework 4 - 4.6 development tools

These two modules will now automatically be installed when you install DIS.

### Validator

#### Check Interprete table as inputParameter \[ID_18444\]

From now on, the Validator will check whether table parameters specified in the inputParameter attribute of a QAction have a correct Interprete tag.

Two new error codes have been added:

| Result code | Class | Description |
|-------------|-------|-------------|
| 2973 | Error | Table ({0}), that is being used as inputParameter on QAction {1}, has no valid Interprete tag defined. |
| 2974 | Error | Table ({0}), that is being used as inputParameter on QAction {1}, has an incorrect Interprete tag defined. (Should be 'other'-'double') |

### XML Schema

#### New units added to UOM schema: pHz, nHz, L \[ID_18512\]

The following units have been added to the UOM schema:

- pHz: picohertz
- nHz: nanohertz
- L: liter

#### New tags and attributes \[ID_18513\]\[ID_18949\]\[ID_18950\]\[ID_18951\]\[ID_18952\]\[ID_18954\]

The Protocol XML schema now supports the following tags and/or tag attributes:

| Tag                                                           | Attribute     |
|---------------------------------------------------------------|---------------|
| Protocol.Chains.Chain.Field.DiagramPids                       | \-            |
| Protocol.Chains.Chain.Field.DiagramSorting                    | \-            |
| Protocol.Chains.Chain.Field.DiagramTitleFormat                | \-            |
| Protocol.Groups.Group                                         | ping          |
| Protocol.HTTP.Session                                         | ignoreTimeout |
| Protocol.HTTP.Session                                         | timeout       |
| Protocol.HTTP.Session.Connection                              | timeout       |
| Protocol.Params.Param                                         | saveInterval  |
| Protocol.Params.Param.ArrayOptions.ColumnOptions.ColumnOption | pollingRate   |
| Protocol.Params.Param.Interprete.Rounding                     | \-            |

#### EnumTriggerOn: New value 'session' \[ID_18954\]

The value “session” has been added to the list of allowed values for the Trigger.On tag (EnumTriggerOn).

## Changes

### Enhancements

#### XML editor: Publish button is now disabled in debug mode \[ID_18872\]

From now on, it will no longer be possible to click the *Publish* button at the top of the XML editor when Visual Studio is running in debug mode.

#### Schema: Additional content model restrictions \[ID_18514\]

A number of additional content model restrictions have been added to the protocol schema:

| Tag/attribute                           | Restriction                                                                  |
|-----------------------------------------|------------------------------------------------------------------------------|
| Protocol.Actions.Action.Name            | must be unique for all actions                                               |
| Protocol.Actions.Action.Name            | must now contain a unique non-empty string if present                        |
| Protocol.Commands.Command.Name          | must now contain a unique non-empty string if present                        |
| Protocol.Display@defaultPage            | must now contain a non-empty string if present                               |
| Protocol.Groups.Group.Content.Action    | now has to refer to an existing Protocol.Actions.Action@id value         |
| Protocol.Groups.Group.Content.Pair      | now has to refer to an existing Protocol.Pairs.Pair@id value             |
| Protocol.Groups.Group.Content.Session   | now has to refer to an existing Protocol.HTTP.Session@id value           |
| Protocol.Groups.Group.Content.Trigger   | now has to refer to an existing Protocol.Triggers.Trigger@id value       |
| Protocol.Groups.Group.Name              | must now contain a unique non-empty string if present                        |
| Protocol.HTTP.Session@name              | must now contain a unique non-empty string if present                        |
| Protocol.Name                           | must contain a non-empty string                                              |
| Protocol.Params.Param.Display.Range.Low | must now precede a Protocol.Params.Param.Display.Range.High element      |
| Protocol.Params.Param.Name              | must be a non-empty string and must be unique for a given type               |
| Protocol.QActions.QAction@name          | must now contain a unique non-empty string if present                        |
| Protocol.Responses.Response.Name        | must now contain a unique non-empty string if present                        |
| Protocol.SNMP                           | now always set to “auto”                                                     |
| Protocol.SNMP@includePages              | now always set to “true”                                                     |
| Protocol.Timers.Timer.Name              | must now contain a unique non-empty string if present                        |
| Protocol.Vendor                         | must contain a non-empty string                                              |
| Protocol.VendorOID                      | must now adhere to the pattern 1.3.6.1.4.1.8813.2.XXX, where XXX is a number |
| Protocol.Version                        | must now be a non-empty string                                               |

### Fixes

#### QAction editor: Problem with synchronization of a QAction C# project linked to a protocol.xml file \[ID_18421\]

In some rare cases, a QAction C# project linked to a protocol.xml file would no longer be synchronized correctly. Changes made to the QAction would be applied incorrectly in the protocol.xml file and vice versa. This problem has now been fixed.

#### Display editor: Problem when dragging a parameter from one page to another \[ID_18450\]

When, in the display editor, you dragged a parameter from one page to another, in some cases, DIS would incorrectly indicate that there are two parameters on the same position. This problem has now been fixed.

#### DIS settings: Problem when pressing ENTER after updating the Host box in the DMA tab \[ID_18881\]

When, in the *DMA* tab of the *DIS Settings* window, you changed the URL in the *Host* box and pressed ENTER, the change would not be applied. This problem has now been fixed.
