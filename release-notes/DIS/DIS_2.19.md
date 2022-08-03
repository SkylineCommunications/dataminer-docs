---
uid: DIS_2.19
---

# DIS 2.19

## New features

### IDE

#### DIS MIB Browser - Compare: Copy to Clipboard \[ID_22247\]

The *Compare* tab of the *DIS MIB Browser* window, which shows the differences between the OID data in the MIB tree and the parameter data in the protocol XML file, now contains a *Copy to Clipboard* button. Clicking that button will copy the results of the latest comparison to the Windows Clipboard.

Also, both the *OIDs missing in protocol* and *OIDs missing in MIB* panes can now be resized.

### Validator

#### New and updated checks and error messages \[ID_22214\]\[ID_22221\]\[ID_22263\]

The following checks and error messages have been added or updated.

| ID     | Check                          | Error message                                                                                                            |
|--------|--------------------------------|--------------------------------------------------------------------------------------------------------------------------|
| 1.13.4 | Protocol.CheckNameAttribute    | Missing attribute 'name' in ParameterGroup '{parameterGroupId}'.                                                         |
| 1.13.5 | Protocol.CheckNameAttribute    | Empty attribute 'name' in ParameterGroup '{parameterGroupId}'.                                                           |
| 1.13.6 | Protocol.CheckNameAttribute    | Duplicated ParameterGroup Name '{name}'. ParameterGroup IDs '{parameterGroupIds}'.                                       |
| 1.13.7 | Protocol.CheckNameAttribute    | Invalid chars '{invalidCharacters}' in attribute 'name'. Current value '{attributeValue}'.                               |
| 1.13.8 | Protocol.CheckNameAttribute    | Too long ParameterGroup Name. Current value '{parameterGroupName}'.                                                      |
| 1.13.9 | Protocol.CheckNameAttribute    | Untrimmed attribute 'name' in ParameterGroup '{parameterGroupId}'. Current value '{untrimmedName}'.                      |
| 2.46.1 | Param.CheckIndexAttribute      | Missing attribute 'index' in table '{tablePid}'.                                                                         |
| 2.46.2 | Param.CheckIndexAttribute      | Empty attribute 'index' in table '{tablePid}'.                                                                           |
| 2.46.3 | Param.CheckIndexAttribute      | Invalid attribute 'index' in table '{tablePid}'. Current value '{currentValue}'.                                         |
| 2.46.4 | Param.CheckIndexAttribute      | Reference to non-existing column with IDX '{indexValue}' in attribute 'index'. Table ID '{tablePid}'.                    |
| 2.46.5 | Param.CheckIndexAttribute      | Unrecommended value '{indexValue}' in attribute 'index'. Recommended values '{recommendedIndex}'. Table ID '{tablePid}'. |
| 2.46.6 | Param.CheckIndexAttribute      | Untrimmed attribute 'index' in table '{tablePid}'. Current value '{untrimmedIndex}'.                                     |
| 2.46.7 | Param.CheckIndexAttribute      | Invalid primary key column Interprete/Type '{columnIntrepeteType}'. Possible values 'string'. Table ID '{tablePid}'.     |
| 3.1.1  | QAction.CheckNameAttribute     | Duplicated QAction Name '{qactionName}'. QAction IDs '{qactionIds}'.                                                     |
| 4.1.1  | Group.CheckNameTag             | Duplicated Group Name '{groupName}'. Group IDs '{groupIds}'.                                                             |
| 5.9.1  | Trigger.CheckNameTag           | Duplicated Trigger Name '{triggerName}'. Trigger IDs '{triggerIds}'.                                                     |
| 6.1.1  | Action.CheckNameTag            | Duplicated Action Name '{actionName}'. Action IDs '{actionIds}'.                                                         |
| 7.2.1  | Timer.CheckNameTag             | Duplicated Timer Name '{timerName}'. Timer IDs '{timerIds}'.                                                             |
| 9.1.1  | Pair.CheckNameTag              | Duplicated Pair Name '{pairName}'. Pair IDs '{pairIds}'.                                                                 |
| 10.2.1 | Command.CheckNameTag           | Duplicated Command Name '{commandName}'. Command IDs '{itemIds}'.                                                        |
| 11.2.1 | Response.CheckNameTag          | Duplicated Response Name '{responseName}'. Response IDs '{itemIds}'.                                                     |
| 12.1.1 | Ports.CheckNameAttribute       | Duplicated PortSettings Name '{portName}'.                                                                               |
| 13.1.1 | Relation.CheckNameAttribute    | Duplicated Relation Name '{relationName}'.                                                                               |
| 14.1.1 | Topology.CheckNameAttribute    | Duplicated Topology Name '{topologyName}'.                                                                               |
| 15.1.1 | Chain.CheckChildNameAttributes | Duplicated Chain child Name '{chainName}'.                                                                               |

## Changes

### Enhancements

#### IDE - XML editor: Exception tags converted to Discreet tags when generating Write parameters for Read parameters \[ID_22206\]

When Write parameters were generated for Read parameters, up to now, Interprete.Exceptions.Exception tags were incorrectly copied to the newly created Write parameters. From now on, those Exception tags will be converted to Measurement.Discreets.Discreet tags instead.

#### IDE - Table editor: Enhanced view option support \[ID_22484\]

The table editor is now able to make the distinction between the view option for a DVE table and the view option for a view table. It now supports both options, and will generate one of the following warnings if a view option is not used correctly:

- “View option is only valid in case of a DVE table.”
- “View option is only valid in case of a view table.”

Also, the table editor now supports the new “viewImpact” option.

#### IDE: Enhanced DIS menu \[ID_22493\]

The main DIS menu has been restructured.

Also, the *Toggle Outlining at Level \[X\]* commands, which were grouped under the *Outlining* submenu, have been removed from the DIS menu and added to the right-click menu of the XML editor.

### Fixes

#### IDE: Problem when parsing MIB files \[ID_22211\]

While parsing a MIB file, up to now, an error could occur when the last item in a list of options was followed by a comma.

#### Validator: Incorrect errors returned when checking datetime and time parameters \[ID_22340\]

In some cases, the Validator would incorrectly return the following errors when checking datetime and time parameters.

| ID     | Check               | Error message                                                            |
|--------|---------------------|--------------------------------------------------------------------------|
| 2.9.7  | Param.CheckUnitsTag | Missing 'Units' tag for '{paramDisplayType}' Param with ID '{paramPid}'. |
| 2.11.1 | Param.CheckRangeTag | Missing 'Range' tag for '{paramDisplayType}' Param with ID '{paramPid}'. |

#### Validator: Incorrect error returned when checking a dummy parameter \[ID_22341\]

In some cases, the Validator would incorrectly return the following error when checking a dummy parameter.

| ID     | Check              | Error message                                          |
|--------|--------------------|--------------------------------------------------------|
| 2.20.2 | Param.CheckTypeTag | Interprete type on Param '{paramId}' has been removed. |

#### IDE: Macros not working in Visual Studio 2015 \[ID_22595\]

The following macros did not work in Visual Studio 2015 and have now been adapted:

- Increment Param PIDs
- List Filtered Params PIDs
