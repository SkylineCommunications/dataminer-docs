---
uid: DIS_2.17
---

# DIS 2.17

## New features

### Validator

#### New and updated checks and error messages \[ID_21495\]\[ID_21496\]\[ID_21567\]\[ID_21571\]\[ID_21663\]\[ID_21729\]\[ID_21747\]\[ID_21750\]\[ID_21771\]\[ID_21772\]\[ID_21773\]

The following checks and error messages have been added or updated.

| ID     | Check                        | Error message                                                                                                                                         |
|--------|------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.9.6  | CheckOptionsAttribute        | Unicode option on protocol was added.                                                                                                                 |
| 1.9.7  | CheckOptionsAttribute        | Unicode option on protocol was removed.                                                                                                               |
| 1.18.1 | CheckXMLDeclaration          | Invalid XML encoding '{currentEncoding}'. Possible values '{possibleValues}'.                                                                         |
| 2.17.6 | CheckOptionsAttribute        | Unrecommended use of the "preserve state" option on table '{tablePid}'.                                                                               |
| 2.17.7 | CheckOptionsAttribute        | Table view option '{viewOption}' must refer to an existing table excluding the view table itself. View table PID '{viewTablePid}'.                    |
| 2.17.8 | CheckOptionsAttribute        | Column '{columnPid}' specified in the filterChange option must refer to a column of the view table '{viewTablePid}'.                                  |
| 2.17.9 | CheckOptionsAttribute        | Column '{columnPid}' specified in the directView option of view table '{viewTablePid}' must refer to a column of another table.                       |
| 2.36.1 | CheckExceptionsTag           | Exception value tag for exception with id '{exceptionId}' on Param '{paramPid}' was changed from '{previousExceptionValue}' to '{newExceptionValue}'. |
| 2.36.2 | CheckExceptionsTag           | Exception with id '{exceptionId}' was removed from Param '{paramPid}'.                                                                                |
| 2.36.3 | CheckExceptionsTag           | Exception with id '{exceptionId}' was added to Param '{paramPid}'.                                                                                    |
| 2.37.1 | CheckTypeTag                 | Param with id '{paramId}' should be implemented as a '{measurementType}'.                                                                             |
| 2.38.1 | CheckOptionsAttribute        | Invalid syntax on view option of column with IDX '{columnIdx}'. View table '{viewTablePid}'.                                                          |
| 2.38.2 | CheckOptionsAttribute        | Column view option '{viewOption}' must refer to an existing column of another table. View table PID '{viewTablePid}'.                                 |
| 2.38.3 | CheckOptionsAttribute        | Invalid combination of view table filterChange option with column view option. View table PID '{viewTablePid}'.                                       |
| 2.39.1 | CheckDisplayKey              | Table with ID '{tableId}' has multiple display key definitions.                                                                                       |
| 2.39.2 | CheckDisplayKey              | DisplayColumn is the same as the primary key. Table PID '{tablePid}'.                                                                                 |
| 2.39.3 | CheckDisplayKey              | Unrecommended use of displayColumn. Table PID '{tablePid}'.                                                                                           |
| 2.40.1 | CheckDisplayTag              | Unrecommended use of Exception Display '{currentDisplay}' on Param '{paramPid}'. Possible values '{possibleValues}'.                                  |
| 5.6.1  | CheckOnTagTimeTagCombination | The On tag value '{onTagValue}' can't be used in combination with the Time tag value '{timeTagValue}'. Trigger ID '{triggerId}'.                      |
| 5.6.2  | CheckOnTagTimeTagCombination | Multiple triggers with same Time/On combination. Trigger IDs '{triggerId}'.                                                                           |
| 5.7.1  | CheckAfterStartupFlow        | After startup Trigger can't have a Condition. Trigger ID '{triggerId}'.                                                                               |
| 5.7.2  | CheckAfterStartupFlow        | After startup Action can't have a Condition. Action ID '{actionId}'.                                                                                  |
| 5.7.3  | CheckAfterStartupFlow        | After startup Trigger must have a Type tag with value 'action'. Trigger ID '{triggerId}'                                                              |
| 5.7.4  | CheckAfterStartupFlow        | After startup Action must have an On tag with value 'group'. Action ID '{actionId}'.                                                                  |
| 5.7.5  | CheckAfterStartupFlow        | After startup Action must have a Type tag with value 'execute next' or 'execute'. Action ID '{actionId}'.                                             |
| 5.7.6  | CheckAfterStartupFlow        | After startup Group must have a Type tag with value 'poll', 'poll trigger' or 'poll action'. Group ID '{groupId}'.                                    |
| 7.1.1  | CheckTimeTag                 | Missing tag 'Time' in Timer '{parentId}'.                                                                                                             |
| 7.1.2  | CheckTimeTag                 | Empty tag 'Time' in Timer '{parentId}'.                                                                                                               |
| 7.1.3  | CheckTimeTag                 | Untrimmed tag 'Time' in Timer '{parentId}'.                                                                                                           |
| 7.1.4  | CheckTimeTag                 | Invalid value '{tagValue}' in tag 'Time'. Possible values 'loop, 1-2073600000'.                                                                       |
| 7.1.5  | CheckTimeTag                 | Timer Tag value '{timeValue}' is higher than the max allowed value of 24 days. Timer id '{timerId}'.                                                  |

> [!NOTE]
> Checks 2.39.x replace the legacy Validator return codes 1704, 3802 and 3803.

### XML Schema

#### Protocol Schema: Updated element and attribute rules \[ID_21462\]

The syntax rules for the following elements and/or attributes have been updated:

| Element/attribute            | Syntax rule                                                                           |
|------------------------------|---------------------------------------------------------------------------------------|
| Protocol.Actions.Action@id<br>Protocol.Groups.Group@id<br>Protocol.QActions.QAction@id<br>Protocol.Timers.Timer@id<br>Protocol.Triggers.Trigger@id | Allowed ID ranges:<br> \[1-64,299\]<br> \[70,000-99,999\]<br> \[1,000,000-9,999,999\] |

#### Protocol Schema: New elements and attributes \[ID_21568\]

The Protocol XML schema now supports the following elements and/or element attributes:

| Element                                                         | Attribute |
|-----------------------------------------------------------------|-----------|
| Protocol.Params.Param.SNMP.InvalidResponseHandling              |           |
| Protocol.Params.Param.SNMP.InvalidResponseHandling.InfiniteLoop |           |

## Changes

### Enhancements

#### IDE - XML editor: Automatic code indentation \[ID_20675\]

Up to now, it was recommended to customize the tab settings in Visual Studio. From now on, DIS will automatically apply the following tab settings when it detects that you have opened a protocol or an Automation script:

- Tab size: 4
- Indent size: 4
- Keep tabs

### Fixes

#### IDE - XML editor: Problem when trying to view the changes made in a file revision \[ID_21721\]

When, while viewing the history of a file under source control (e.g. SVN or GIT), you right-clicked a revision and clicked *Show Changes*, in some cases, an exception could be thrown.
