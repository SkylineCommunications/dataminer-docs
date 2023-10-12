---
uid: DIS_2.38
---

# DIS 2.38

## New features

### IDE

#### XML editor: Validator results now include warnings \[ID_32837\]

When, in the *DIS Validator* pane, you click the information icon of an error or you right-click that error and select *Show Details*, the window showing those details will now also include possible warnings.

Also, when you right-click an error with warnings and select *Fix \> This error*, a popup window will now appear to draw your attention to those warnings. Only when you click *OK* in that popup window will the error be fixed.

#### XML editor: Protocol comparison will now also include a validation of both protocols \[ID_33133\]

When you compare two protocols in the *DIS Comparer* tool window, apart from comparing the protocols, DIS will now also automatically validate both these protocols.

When comparison and validation have finished, instead of one result list, you will now see two tabs:

- *Major Change*: The result of the protocol comparison.
- *Validator*: The differences between the two protocol validations.

#### Language version of the C# projects now set to 7.3 by default \[ID_33184\]

As from version 2.38, by default, DIS will set the language version of the C# projects to 7.3.

#### Automation Script solutions: New 'Import Automation Script' command \[ID_33411\]

Apart from the *Existing DataMiner Automation Script...* option, which can be used to import locally stored Automation scripts into an Automation script solution, you can now use the *Import DataMiner Automation Script* option to import Automation scripts from the DataMiner Agent you are connected to.

1. Right-click a solution folder in the Solution Explorer.
1. Select *Add \> Import DataMiner Automation Script*.
1. Select a least one Automation script file.
1. Click *Open*.

> [!NOTE]
>
> - This new *Import DataMiner Automation Script* option will only be available if DIS is connected to a DataMiner Agent.
> - When you add existing scripts to an Automation script solution, they are automatically converted to the correct format. For each Exe block, a C# project is created, and the code in that Exe block is transferred to the newly created C# project.

### Validator

#### New checks and error messages \[ID_33428\] \[ID_33477\] \[ID_33698\] \[ID_33732\] \[ID_33740\]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 2.17.1 | EmptyAttribute | Empty attribute 'ArrayOptions@options' in Param '{tablePid}'. |
| 2.17.2 | UntrimmedAttribute | Untrimmed attribute 'ArrayOptions@options' in Table '{tablePid}'. Current value '{untrimmedValue}'. |
| 2.17.3 | NamingEmpty | Empty option 'naming' in attribute 'ArrayOptions@options'. Table PID '{tablePid}'. |
| 2.17.4 | NamingRefersToNonExistingParam | Option 'naming' in attribute 'ArrayOptions@options' references a non-existing 'Param' with ID '{referencedPid}'. Table PID '{tablePid}'. |
| 2.38.7 | ForeignKeyColumnInvalidInterpreteType | Invalid value '{columnIntrepeteType}' in tag 'Interprete/Type' for foreign key column. Possible values 'string'. FK column PID '{fkColumnPid}'. |
| 2.38.8 | ForeignKeyColumnInvalidMeasurementType | Invalid value '{columnMeasurementType}' in tag 'Measurement/Type' for foreign key column. Possible values 'string, number'. FK column PID '{fkColumnPid}'. |
| 2.38.9 | ForeignKeyColumnInvalidType | Invalid value '{columnType}' in tag 'Param/Type' for foreign key column. Possible values 'read'. FK column PID '{fkColumnPid}'. |
| 2.39.6 | DisplayKeyColumnInvalidInterpreteType | Invalid value '{columnIntrepeteType}' in tag 'Interprete/Type' for display key column. Possible values 'string'. DK column PID '{dkColumnPid}'. |
| 2.39.7 | DisplayKeyColumnInvalidMeasurementType | Invalid value '{columnMeasurementType}' in tag 'Measurement/Type' for display key column. Possible values 'string, number'. DK column PID '{dkColumnPid}'. |
| 2.39.8 | DisplayKeyColumnInvalidType | Invalid value '{columnType}' in tag 'Param/Type' for display key column. Possible values 'read'. DK column PID '{dkColumnPid}'. |
| 2.39.9 | DisplayKeyColumnMissing | Missing column with ColumnOption@type="displaykey". Table PID {tablePid}. |
| 2.39.10 | UnexpectedIdxSuffix | Unexpected \[IDX\] suffix on Param/Description. Column Pid {columnPid}. |
| 2.39.11 | DuplicateDisplayKeyColumn | Table has multiple ColumnOption tags with value 'displaykey' in type attribute. Table Pid {tablePid}. |
| 2.46.7 | InvalidColumnInterpreteType | Invalid value '{columnIntrepeteType}' in tag 'Interprete/Type' for primary key column. Possible values 'string'. PK column PID '{pkColumnPid}'. |
| 2.46.8 | InvalidColumnMeasurementType | Invalid value '{columnMeasurementType}' in tag 'Measurement/Type' for primary key column. Possible values 'string, number'. PK column PID '{pkColumnPid}'. |
| 2.46.9 | InvalidColumnType | Invalid value '{columnType}' in tag 'Param/Type' for primary key column. Possible values 'read'. PK column PID '{pkColumnPid}'. |
| 2.60.1 | EmptyTag | Missing tag 'Display' in Param '{pid}'. |
| 2.61.1 | MissingTag | Missing tag 'Param/Type' in Param '{pid}'. |
| 2.61.2 | EmptyTag | Empty tag 'Param/Type' in Param '{pid}'. |
| 2.61.3 | UntrimmedTag | Untrimmed tag 'Param/Type' in Param '{pid}'. Current value '{untrimmedValue}'. |
| 2.61.4 | InvalidValue | Invalid value '{tagValue}' in tag 'Param/Type'. Param ID '{pid}'. |
| 2.62.1 | EmptyAttribute | Empty attribute 'Type@id' in Param '{pid}'. |
| 2.62.2 | UntrimmedAttribute | Untrimmed attribute 'Type@id' in Param '{pid}'. Current value '{untrimmedValue}'. |
| 2.62.3 | NonExistingParam | Attribute 'Type@id' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'. |
| 2.62.4 | NonExistingResponse | Attribute 'Type@id' references a non-existing 'Response' with ID '{responseId}'. Param ID '{pid}'. |
| 2.62.5 | NonExistingColumn | Attribute 'Type@id' references a non-existing 'Column' with PID '{columnPid}'. Param ID '{pid}'. |
| 2.62.6 | MissingAttribute | Missing attribute 'Type@id' due to 'Param/Type' '{paramType}'. Param ID '{pid}'. |
| 2.63.1 | MissingAttribute | Missing attribute 'ColumnOption@pid' in table '{tablePid}'. |
| 2.63.2 | EmptyAttribute | Empty attribute 'ColumnOption@pid' in Param '{tablePid}'. |
| 2.63.3 | UntrimmedAttribute | Untrimmed attribute 'ColumnOption@pid' in Table '{tablePid}'. Current value '{untrimmedValue}'. |
| 2.63.4 | NonExistingParam | Attribute 'ColumnOption@pid' references a non-existing 'column' with PID '{columnPid}'. Table PID '{tablePid}'. |
| 2.64.1 | ColumnInvalidType | Invalid value '{columnType}' in tag 'Param/Type' for column. Possible values 'read, write, group, read bit, write bit'. Column PID '{columnPid}'. |
| 2.65.1 | EmptyTag | Empty tag 'ArrayOptions/NamingFormat' in Table '{tablePid}'. |
| 2.65.2 | UntrimmedTag | Untrimmed tag 'ArrayOptions/NamingFormat' in Table '{tablePid}'. Current value '{untrimmedValue}'. |
| 2.65.3 | NonExistingParam | Tag 'ArrayOptions/NamingFormat' references a non-existing 'Param' with ID '{referencedPid}'. Table PID '{tablePid}'. |
| 2.65.4 | MissingDynamicPart | Missing dynamic part(s) in 'ArrayOptions/NamingFormat' tag. Table PID '{tablePid}'. |
| 2.66.1 | ObsoleteTag | Obsolete tag 'Information/Includes'. Param ID '{pid}'. |
| 2.67.1 | EmptyTag | Missing tag 'Dependencies/Id' in Param '{pid}'. |
| 2.67.2 | UntrimmedTag | Untrimmed tag 'Dependencies/Id' in Param '{pid}'. Current value '{untrimmedValue}'. |
| 2.67.3 | NonExistingId | Attribute 'Dependencies/Id' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'. |
| 2.67.4 | RTDisplayExpected | RTDisplay(true) expected on Param '{pid}' containing 'Dependencies/Id' tag(s). |
| 2.67.5 | RTDisplayExpectedOnReferencedParam | RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Dependencies/Id' tag. Param ID '{referencingPid}'. |
| 6.5.1 | MissingTag | Missing tag 'Type' in Action '{actionId}'. |
| 6.5.2 | EmptyTag | Empty tag 'Type' in Action '{actionId}'. |
| 6.5.3 | UntrimmedTag | Untrimmed tag 'Type' in Action '{actionId}'. Current value '{untrimmedValue}'. |
| 6.5.4 | InvalidValue | Invalid value '{actionType}' in tag 'Type'. Action ID '{actionId}'. |
| 6.6.1 | MissingTag | Missing tag 'On' in Action '{actionId}'. |
| 6.6.2 | EmptyTag | Empty tag 'On' in Action '{actionId}'. |
| 6.6.3 | UntrimmedTag | Untrimmed tag 'On' in Action '{actionId}'. Current value '{untrimmedValue}'. |
| 6.6.4 | InvalidValue | Invalid value '{actionOn}' in tag 'On'. Action ID '{actionId}'. |
| 6.7.1 | IncompatibleTypeVsOnTag | Incompatible 'Action/Type' value '{actionType}' with 'Action/On' value '{actionOn}'. Action ID '{actionId}'. |
| 6.7.2 | MissingOnIdAttribute | Missing attribute 'On@id' due to 'Action/Type' '{actionType}' and 'Action/On' '{actionOn}'. Action ID '{actionId}'. |
| 6.7.3 | MissingTypeIdAttribute | Missing attribute 'Type@id' due to 'Action/Type' '{actionType}' and 'Action/On' '{actionOn}'. Action ID '{actionId}'. |
| 6.7.4 | MissingOnNrAttribute | Missing attribute 'On@nr' due to 'Action/Type' '{actionType}' and 'Action/On' '{actionOn}'. Action ID '{actionId}'. |
| 6.7.5 | NonExistingParamRefInTypeIdAttribute | Attribute 'Type@id' references a non-existing 'Param' with ID '{pid}'. Action ID '{actionId}'. |
| 6.7.6 | MissingTypeIdOrTypeValueAttribute | Missing attribute 'Type@id or Type@value' due to 'Action/Type' '{actionType}' and 'Action/On' '{actionOn}'. Action ID '{actionId}'. |
| 6.7.7 | ExcessiveTypeIdOrTypeValueAttribute | Excessive attribute 'Type@id or Type@value' due to 'Action/Type' '{actionType}' and 'Action/On' '{actionOn}'. Action ID '{actionId}'. |
| 6.7.8 | NonExistingRefToPairOnTimeoutSetNext | Attribute 'On@nr' references a non-existing 'Pair' with 1-based position '{pairPosition}' in Group '{groupId}'. Action ID '{actionId}' triggered by Trigger '{triggerId}'. |
| 6.7.9 | NonExistingConnectionRefInTypeNrAttribute | Attribute 'Type@nr' references a non-existing 'Connection' with ID '{connectionId}'. Action ID '{actionId}'. |
| 6.7.10 | UnsupportedConnectionTypeDueTo | {optionalPrefix}'Type@nr' attribute in action of type '{actionType}' on '{actionOn}' references Connection '{connectionId}' with wrong type '{connectionType}'. Action ID '{actionId}'. |
| 6.7.11 | UnsupportedGroupContentDueTo | Attribute 'On@id' in action of type '{actionType}' on '{actionOn}' references Group '{groupId}' which is missing 'Content/Param' tag(s). Action ID '{actionId}'. |
| 6.7.12 | UnsupportedGroupParamType | Attribute 'On@id' in action of type '{actionType}' on '{actionOn}' references Group '{groupId}' which references Param '{paramId}' with unsupported 'Param/Type' '{paramType}'. Action ID '{actionId}'. |
| 6.7.13 | UnsupportedGroupParamWithoutSnmp | Attribute 'On@id' in action of type '{actionType}' on '{actionOn}' references Group '{groupId}' which references Param '{paramId}' with unsupported 'SNMP/Enabled' '{snmpEnabledValue}'. Action ID '{actionId}'. |
| 6.7.100 | UnsupportedAttributeOnNr | Unsupported attribute 'Action/On@nr' in combination with 'Action/Type' '{actionType}' and  'Action/On' '{actionOn}'. Action ID '{actionId}'. |
| 6.22.2 | EmptyAttribute | Empty attribute 'Action/On@nr' in Action '{actionId}'. |
| 6.22.3 | UntrimmedAttribute | Untrimmed value '{untrimmedValue}' in attribute 'Action/On@nr'. Action ID '{actionId}'. |
| 6.22.4 | InvalidValue | Invalid value '{attributeValue}' in attribute 'Action/On@nr'. Action ID '{actionId}'. |

## Changes

### Enhancements

#### IDE - C# editor: StyleCop.Analyzers rules disabled \[ID_33313\]

DIS defines a default set of analysis rules for QAction projects. These rules can be used by Visual Studio extensions like e.g. SonarLint or StyleCop to analyze the code.

The following StyleCop.Analyzers rules have now been disabled:

- SA1127 - GenericTypeConstraintsMustBeOnOwnLine
- SA1128 - ConstructorInitializerMustBeOnOwnLine

#### Validator: System.Xml DLL file will by default be added as a reference to QAction projects when the Validator creates a solution \[ID_33472\]

When a protocol.xml file is being validated, a solution is built from the XML file. Up to now, when that solution was built, the System.Xml.dll would incorrectly not be added as a reference when creating the QAction project(s). In some cases, this could result in compilation errors during validation when types from the System.Xml DLL file were being used.

From now on, the System.Xml DLL file will by default be added as a reference to the QAction projects when the Validator creates a solution from a protocol.xml.

### Fixes

#### DIS Inject window: Automation script selection box would be empty \[ID_33473\]

When you opened the *DIS Inject* window to select the Automation script to be debugged, in some cases, the selection box listing all Automation scripts would be empty.
