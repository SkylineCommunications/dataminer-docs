---
uid: DIS_2.36
---

# DIS 2.36

## New features

### IDE

#### New tool window: DIS protocol diagram \[ID_31913\]

The new *DIS Protocol diagram* tool window shows a graphical representation of a protocol. It allows you to see how a protocol is built, navigate through its logic and investigate flow issues.

When you open the tool window, you first have to select an item to start from: a parameter, a QAction, a session, a response, a group, a trigger, an action or a timer. You can then set the required depth, i.e. the number of levels you want to have displayed starting from the item you selected, and the type of diagram (BoundedFR, EfficientSugiyama, FR, ISOM, KK, LinLog, LeftRightTree or TopBottomTree).

In the diagram itself, each item (parameter, QAction, session, response, group, trigger, action, timer) is represented by a box with a particular icon and color, showing the ID and name of the item.

- Click the ID of an item to navigate to that item in the protocol.xml file.
- Hover over an item to see a tooltip with its full name and full description.
- Double-click a box representing an item to make that item the new starting point of the diagram. This will cause the entire diagram to be redrawn.

In the top-left corner of the diagram, you also have a number of zoom options: a slider to adjust to zoom factor, a “1:1” button (to switch to zoom factor 1) and a “Fill” button to automatically adjust the zoom factor to the current size of the diagram window.

#### New command to save all compiled Automation scripts in a solution to a zip file \[ID_32166\]

When developing Automation scripts as part of a Visual Studio solution, up to now, it was possible to save a compiled script to a file using the *File \> Save Compiled Script As...* command.

From now on, you can use the *File \> Save All Compiled Scripts As...* command to save all compiled scripts in a solution to a zip file in one go.

#### DIS Comparer: Suppressing errors \[ID_32223\]

In the *DIS Comparer* tool window, it is now also possible to suppress errors after having compared two protocol.xml files. To do so, select one or more errors, right-click, and select *Suppress*.

#### Import Protocol and Import Automation Script windows now have a filter box \[ID_32396\]

Both the *Import Protocol* and *Import Automation Script* windows now have a filter box in the top-right corner. This will allow you to filter the list of protocols or Automation scripts.

#### DIS Validator and DIS Comparer windows now have a filter box \[ID_32407\]

Both the *DIS Validator* and *DIS Comparer* tool windows now have a filter box in the top-right corner. This will allow you to filter the validation or comparison results.

### Validator

#### New checks and error messages \[ID_32143\]

The following checks and error messages have been added.

| Check ID | Error message name                     | Error message                                                                                                                                              |
|----------|----------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.9.8    | EmptyAttribute                         | Empty attribute 'Protocol/Type@options'.                                                                                                                   |
| 1.9.9    | UntrimmedAttribute                     | Untrimmed attribute 'Protocol/Type@options'. Current value '{currentValue}'.                                                                               |
| 1.9.11   | NonExistingId                          | Attribute 'Protocol/Type@options' references a non-existing 'Param' with ID '{paramId}'.                                                                   |
| 1.9.12   | ReferencedParamWrongType               | Invalid DVE Param Type '{paramType}'. Expected Type 'array'. Param ID '{paramId}'.                                                                         |
| 1.9.13   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on DVE Table. Table PID '{dveTablePid}'.                                                                                          |
| 1.22.11  | NonExistingId                          | Attribute 'Protocol/Display@pageOrder' references a non-existing 'Param' with ID '{paramId}'.                                                              |
| 1.22.12  | ReferencedParamRTDisplayExpected   | RTDisplay(true) expected on Param '{referencedPid}' referenced by the 'Protocol/Display@pageOrder' attribute.                                              |
| 2.1.14   | RTDisplayExpectedOnSpectrumParam   | RTDisplay(true) expected on Spectrum Params. Param ID '{pid}'.                                                                                             |
| 2.2.10   | RTDisplayExpectedOnContextMenu     | RTDisplay(true) expected on Param '{contextMenuPid}' used as context menu for table.                                                                       |
| 2.2.11   | RTDisplayExpectedOnQActionFeedback | RTDisplay(true) expected on Param '{qactionFeedbackPid}' used for QAction feedback.                                                                        |
| 2.7.4    | RTDisplayExpected                      | RTDisplay(true) expected on Param '{pid}'.                                                                                                                 |
| 2.7.5    | RTDisplayUnexpected                    | Unexpected RTDisplay(true) on Param '{pid}'.                                                                                                               |
| 2.8.2    | EmptyAttribute                         | Empty attribute 'Param@trending' in Param '{pid}'.                                                                                                         |
| 2.8.3    | UntrimmedAttribute                     | Untrimmed attribute 'Param@trending' in Param '{pid}'. Current value '{untrimmedValue}'.                                                                   |
| 2.8.4    | RTDisplayExpected                      | RTDisplay(true) expected on trended parameters. Param ID '{paramId}'.                                                                                      |
| 2.24.2   | MissingTag                             | Missing tag 'Alarm/Monitored' in Param '{pid}'.                                                                                                            |
| 2.24.3   | EmptyTag                               | Empty tag 'Alarm/Monitored' in Param '{pid}'.                                                                                                              |
| 2.24.4   | InvalidTag                             | Invalid value '{tagValue}' in tag 'Alarm/Monitored'. Possible values 'true, false'. Param ID '{pid}'.                                                      |
| 2.24.5   | UntrimmedTag                           | Untrimmed tag 'Alarm/Monitored' in Param '{pid}'. Current value '{untrimmedValue}'.                                                                        |
| 2.24.6   | RTDisplayExpected                      | RTDisplay(true) expected on alarmed (monitored) parameters. Param ID '{paramId}'.                                                                          |
| 2.31.10  | ReferencedParamRTDisplayExpected   | RTDisplay(true) expected on Param '{columnPid}' displayed as table column. Table PID '{tablePid}'.                                                         |
| 2.34.4   | EmptyAttribute                         | Empty attribute 'Alarm@option' in Param '{pid}'.                                                                                                           |
| 2.34.5   | UntrimmedAttribute                     | Untrimmed attribute 'Alarm@option' in Param '{pid}'. Current value '{untrimmedValue}'.                                                                     |
| 2.34.6   | NonExistingId                          | Attribute 'Alarm@option' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'.                                                    |
| 2.34.7   | ReferencedParamRTDisplayExpected   | RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Alarm@option' attribute. Param ID '{referencingPid}'.                                 |
| 2.38.5   | ColumnOptionExpectingRTDisplay     | RTDisplay(true) expected on column Param '{columnPid}' due to '{option}' in 'ColumnOption@options' attribute. Table PID '{tablePid}'.                      |
| 2.38.6   | ForeignKeyExpectingRTDisplayOnPK   | RTDisplay(true) expected on PK column Param '{pkColumnPid}' due to '{foreignKeyOption}' in 'ColumnOption@options' attribute. Table PID '{tablePid}'.       |
| 2.43.1   | MissingTag                             | Missing tag 'Position/Row' in Param '{pid}'.                                                                                                               |
| 2.43.2   | EmptyTag                               | Empty tag 'Position/Row' in Param '{pid}'.                                                                                                                 |
| 2.43.3   | InvalidTag                             | Invalid value '{tagValue}' in tag 'Position/Row'. Param ID '{pid}'.                                                                                        |
| 2.43.4   | UntrimmedTag                           | Untrimmed tag 'Position/Row' in Param '{pid}'. Current value '{untrimmedValue}'.                                                                           |
| 2.54.1   | EmptyAttribute                         | Empty attribute 'Discreets@dependencyId' in Param '{pid}'.                                                                                                 |
| 2.54.2   | UntrimmedAttribute                     | Untrimmed attribute 'Discreets@dependencyId' in Param '{pid}'. Current value '{untrimmedValue}'.                                                           |
| 2.54.3   | InvalidValue                           | Invalid value '{attributeValue}' in attribute 'Discreets@dependencyId'. Param ID '{pid}'.                                                                  |
| 2.54.4   | NonExistingId                          | Attribute 'Discreets@dependencyId' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'.                                          |
| 2.54.5   | ReferencedParamWrongType               | Invalid Param Type '{referencedParamType}' on Param referenced by a 'Discreets@dependencyId' attribute. Param ID '{referencedPid}'.                        |
| 2.54.6   | ReferencedParamRTDisplayExpected   | RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Discreets@dependencyId' attribute. Param ID '{referencingPid}'.                       |
| 2.55.1   | EmptyAttribute                         | Empty attribute 'SNMP/TrapOID@mapAlarm' in Param '{pid}'.                                                                                                  |
| 2.55.2   | UntrimmedAttribute                     | Untrimmed attribute 'SNMP/TrapOID@mapAlarm' in Param '{pid}'. Current value '{untrimmedValue}'.                                                            |
| 2.55.3   | RTDisplayExpected                      | RTDisplay(true) expected on Param '{pid}' generating alarms based on traps.                                                                                |
| 2.56.1   | EmptyAttribute                         | Empty attribute 'Params@loadSequence'.                                                                                                                     |
| 2.56.2   | UntrimmedAttribute                     | Untrimmed attribute 'Params@loadSequence'. Current value '{untrimmedValue}'.                                                                               |
| 2.56.3   | NonExistingId                          | Attribute 'Params@loadSequence' references a non-existing 'Param' with ID '{pid}'.                                                                         |
| 2.56.5   | ReferencedParamSaveExpected            | Param '{referencedPid}' referenced by 'Params@loadSequence' attribute is expected to be saved.                                                             |
| 2.56.6   | ReferencedParamRTDisplayExpected   | RTDisplay(true) expected on Param '{referencedPid}' referenced by 'Params@loadSequence' attribute.                                                         |
| 2.57.1   | EmptyTag                               | Missing tag 'Display/Positions' in Param '{pid}'.                                                                                                          |
| 2.57.2   | RTDisplayExpected                      | RTDisplay(true) expected on Param '{pid}' which is positioned.                                                                                             |
| 2.58.1   | EmptyAttribute                         | Empty attribute 'Type@virtual' in Param '{pid}'.                                                                                                           |
| 2.58.2   | UntrimmedAttribute                     | Untrimmed attribute 'Type@virtual' in Param '{pid}'. Current value '{untrimmedValue}'.                                                                     |
| 2.58.3   | RTDisplayExpected                      | RTDisplay(true) expected on parameters used as virtual source. Param ID '{paramId}'.                                                                       |
| 2.59.1   | EmptyAttribute                         | Empty attribute 'Discreet@dependencyValues' in Param '{pid}'.                                                                                              |
| 2.59.2   | UntrimmedAttribute                     | Untrimmed attribute 'Discreet@dependencyValues' in Param '{pid}'. Current value '{untrimmedValue}'.                                                        |
| 2.59.3   | NonExistingId                          | Attribute 'Discreet@dependencyValues' references a non-existing 'Param' with ID '{referencePid}'. Param ID '{pid}'.                                        |
| 2.59.4   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on Param '{referencePid}' referenced in 'Discreet@dependencyValues' attribute. Param ID '{pid}'.                                  |
| 13.2.7   | ReferencedParamWrongType               | Invalid Param Type '{paramType}' in relation. Expected Type 'array'. Param ID '{paramId}'.                                                                 |
| 13.2.8   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on Param referenced in a relation path. Param ID '{paramId}'.                                                                     |
| 18.1.6   | ReferencedParamWrongType               | Invalid TreeControl Param Type '{paramType}'. Expected Type 'dummy'. Param ID '{paramId}'.                                                                 |
| 18.1.7   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on TreeControl Param. Param ID '{paramId}'.                                                                                       |
| 18.2.9   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on table displayed in TreeControl Hierarchy. Table PID '{tablePid}'.                                                              |
| 18.3.6   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on table displayed in TreeControl Hierarchy. Table PID '{tablePid}'.                                                              |
| 18.5.7   | ReferencedColumnExpectingRTDisplay | RTDisplay(true) expected on Param '{columnPid}' referred as condition column in 'Hierarchy/Table@condition' attribute. TreeControl PID '{treeControlPid}'. |
| 18.6.6   | ReferencedTableExpectingRTDisplay  | RTDisplay(true) expected on TreeControl/ExtraDetails table. Table PID '{tablePid}'.                                                                        |
| 18.7.6   | ReferencedColumnExpectingRTDisplay | RTDisplay(true) expected on column referenced by TreeControl 'LinkedDetails@discreetColumnId' attribute. Column PID '{columnPid}'.                         |
| 18.8.6   | ReferencedParamExpectingRTDisplay  | RTDisplay(true) expected on 'TreeControl/ExtraTabs/Tab\@parameters' Param. Param ID '{paramId}'.                                                            |

### XML Schema

#### Installation Package Manifest Schema: SignDevelopmentVersion is now a required element \[ID_31643\]

The Manifest.Content.Protocols.Protocol.SignDevelopmentVersion is now a required element.

Default value: true

#### UOM Schema: New units added \[ID_31649\]

The following units have been added to the UOM Schema:

- SCMD (Standard Cubic Meter per Day)
- SCMH (Standard Cubic Meter per Hour)
- SCMM (Standard Cubic Meter per Minute)

#### Protocol Schema: Types of elements and attributes set or changed \[ID_32144\]

The types of the following elements and/or attributes have been set or changed.

| Element/attribute | Change |
|-------------------|--------|
| Protocol.Chains.Chain.Display.Visibility@default | Type set to EnumTrueFalse |
| Protocol.Chains.Chain.Field.Display.Selection.Visibility@default | Type set to EnumTrueFalse |
| Protocol.Chains.SearchChain.Display.Visibility@default | Type set to EnumTrueFalse |
| Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display.Visibility@default | Type set to EnumTrueFalse |
| Protocol.Params.Param.CRC.Content.Param | Type changed from TypeParamId to unsignedInt |
| Protocol.TreeControls.TreeControl.Hierarchy@path | Type changed from xs:string to TypeCommaSeparatedNumbers |

## Changes

### Enhancements

#### Protocol version editor: Enhancements \[ID_29861\]

A number of enhancements have been made to the protocol version editor.

- All four parts of a version number (branch, system, major and minor) are now editable anywhere in the tree. When you update a version number, all child items will be updated accordingly and recursively.
- Enhanced field validation:

  - All fields will now allow any kind of value and will get a red border in case of an error.
  - The *Author* field will now get a red border when empty or set to the default value.
  - The *Based On* field will now get a red border when the version has an unexpected format, when the selected version is illogical, or when no version has been selected in situations where this is necessary (e.g. the first version of a new range).

- All validation remarks will now cause a warning icon to appear in the tree. These warning icons will automatically bubble up to the higher tree levels. That way, errors will be visible even when tree items are collapsed.
- When you create a new version, the *Based On* field will now automatically be populated when possible.
- Tabbing from one field to another has been improved.

#### Function editor: Enhancements \[ID_32389\]

Up to now, page names would incorrectly be compared in a case-sensitive way. From now on, they will be compared in a case-insensitive way.

When a page is renamed or when the casing of a page is changed, the export rules for the parameters on that page will now be updated.

When a parameter is moved onto a page, and its new location matches its location specified in the protocol, any export rules for that parameter will now be removed.

#### Automation scripts: DLL references added via an Exe or Param tag will now be disregarded when identical references were added via the solution explorer \[ID_32422\]

When developing Automation scripts as Visual Studio solutions, it is good practice to add DLL references to the C# project via the solution explorer rather than to add them via Exe and/or Param tags.

In cases where the same DLL was referenced both via the solution explorer and via an Exe or Param tag, up to now, a script would end up containing duplicate references when compiled. From now on, when the compiler finds duplicate references, it will disregard the ones added via an Exe or Param tag and only keep the ones added via the solution explorer.

#### Protocols: Enhanced 'Add New Column' command \[ID_32465\]

When editing a protocol.xml file, in front of every \<Param> element that defines a table parameter, you can click the small *Down* arrow and select the *Add New Column* command to add a column to that table parameter. That command has now been enhanced.

From now on, when you add a new column to a table parameter, the following will happen:

- The new column will automatically be assigned a default parameter ID.
- The name of the new column will get a prefix containing the name of the table parameter.
- The description of the new column will get a suffix containing the description of the table in parenthesis.
- When the last column of the table is a displayKey column, then the new column will be inserted before that displayKey column.
- When the last column of the table has a write column next to it, then the new column will be added to the right of the write column. It will not be added in between a read and a write column.

### Fixes

#### Validator: Condition members without an operator would be considered invalid \[ID_32138\]

In some cases, the *DIS Validator* could report a false positive when a member of a condition did not contain an operator. Conditions like “id:100 == id:12” would be considered invalid.

From now on, condition members that do not contain an operator will no longer be considered invalid.
