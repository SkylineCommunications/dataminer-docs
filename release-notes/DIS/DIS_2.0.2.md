---
uid: DIS_2.0.2
---

# DIS 2.0.2

## New features

### IDE

#### Protocol tag shortcut menus \[ID_12467\]

A number of features have been added to the shortcut menu menus that open when you click a small Down arrow in front of certain protocol tags in the protocol editor.

See the table below for an overview of those new features.

| Protocol tag | Command | Function |
|--------------|---------|----------|
| Param | Add New Column | Add a new column to a table parameter. |
|       | Include in Group | Include the parameter in one of the listed groups of type “poll”.<br>From now on, this command is only available for SNMP parameters (i.e. parameters with an \<SNMP> subtag). |
| Trigger | Add Existing Action | Add an existing action to the trigger.<br>(only if the trigger is of type “action”) |
|         | Add Existing Trigger | Add an existing trigger to the trigger.<br>(only if the trigger is of type “trigger”) |
| Group | Generate New Parameter<br>Add Existing Parameter<br>Generate New Pair<br>Add Existing Pair<br>Generate New Session<br>Add Existing Session | As long as a group of type “poll” is still empty, you can use these commands to add a parameter, a pair, or a session to it.<br>However, once you added one item to a group of type “poll”, all other items you add must be of the same type.<br>If a group already contains a pair, for example, you will no longer be allowed to add parameters or sessions to that group. |
|       | Add Existing Action | Add an existing action to the group.<br>(only if the group is of type “action” or “poll action”) |
|       | Add Existing Trigger | Add an existing trigger to the group.<br>(only if the group is of type “trigger” or “poll trigger”) |
| Timer | Add Existing Group | Add an existing group to the timer. |
| Pair | Add Existing Command | Add an existing command to the pair. |
|      | Add Existing Response | Add an existing response to the pair. |
| Command | Add Existing Parameter | Add an existing parameter to the command. |
| Response | Add Existing Parameter | Add an existing parameter to the response. |
| QAction | Edit QAction | Create a temporary C# project containing the code of the QAction, and open the QAction in a new QAction editor tab.<br>This command replaces the *Edit C#* button found in previous DIS versions. |
|         | Open All QActions | For each of the available QActions, create a temporary C# project containing the code of that QAction, and open each QAction in a new QAction editor tab. |
|         | Add QAction Reference | Automatically add a *\[ProtocolName\].\[ProtocolVersion\].QAction.X.dll* reference to the *dllImport* attribute.<br>Note: The list only contains QActions with “options=precompiled”. |

> [!NOTE]
>
> - If, in an “Include in ...” list or an “Add Existing ...” list, you select an item that is already included, then that item will be removed.
> - From now on, “Include in ...” and “Add Existing ...” lists no longer close when you have selected an item. They will now stay open to allow you to select multiple items.

### Validator

#### New test added: CheckTableColumnExports \[ID_12446\]

If you click *Validate* in the Protocol Editor, DIS now also checks the export settings of table columns.

When a table is exported from a main DVE protocol to a child DVE protocol, it is of the utmost importance that all columns of that table get exported. This new test will produce an error each time it finds a table column of which the export settings differ from those of the table.

Result codes:

| Result code | Class       | Description                                                                                   |
|-------------|-------------|-----------------------------------------------------------------------------------------------|
| 4800        | Information | Table column exports OK.                                                                      |
| 4801        | Error       | Export settings of table column \[Parameter ID\] differ from those of table \[Parameter ID\]. |

## Changes

### Enhancements

#### IDE - Linked items listed in incorrect order \[ID_12694\]

Up to now, lists of items linked to items selected in the protocol editor (e.g. a list of actions in a trigger, a list of parameters in a command, a list of groups in a timer, etc.) were sorted by ID. Now, linked items will be listed in the order in which they appear in the protocol.xml file.

### Fixes

#### Validator - Invalid timeout warnings \[ID_12449\]

In some cases, warnings were incorrectly generated for timeouts of serial responses if those responses contained a “next param” parameter and had a trailer followed by a CRC.

#### Validator - Invalid warnings for exported parameters with 'RTDisplay=false' \[ID_12450\]

Previously, warnings were generated for exported parameters with “RTDisplay=false”.

As it is allowed to specify “RTDisplay=false” for exported parameters, such warnings will no longer be generated.

#### Validator - Invalid 'Unexpected RTDisplay=true' warnings \[ID_12451\]

Previously, “Unexpected RTDisplay=true” warnings were incorrectly generated for Write parameters associated with Read parameters used in dependency values. Now, an additional check will be performed to prevent such warnings from being generated.

#### Validator - Invalid 'Unexpected RTDisplay=true' warnings \[ID_12457\]

From now on, “Unexpected RTDisplay=true” warnings will no longer be generated for table parameters with a *duplicateAs* attribute.

#### Validator - Incorrect element count \[ID_12460\]

Up to now, when verifying group contents, comments were also evaluated. This could result in either a program error or an incorrect count of the items in the group.

#### Validator - Invalid 'Unexpected RTDisplay=true' warnings \[ID_12464\]

From now on, “Unexpected RTDisplay=true” warnings will no longer be generated for tables used in tree control “extratabs”.

#### Validator - Invalid 'Unexpected RTDisplay=true' warnings \[ID_12466\]

From now on, “Unexpected RTDisplay=true” warnings will no longer be generated for parameters of which the *\<Type>* tag has a *virtual=”source”* attribute.
