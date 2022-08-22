---
uid: DIS_2.34
---

# DIS 2.34

## New features

### IDE

#### DIS Comparer tool window now allows you to download a previous release of a selected protocol and compare both \[ID_30088\]

Up to now, when you wanted to compare a protocol to one of its previous versions, you first had to download that previous version, save it in a random folder and then select both in the *DIS Comparer* tool window. From now on, after having selected a protocol on one side of the *DIS Comparer* window, on the other side of the window you can now immediately select one of its previous versions to compare it to.

To select a previous version of a protocol you already opened in the DIS Comparer tool window, do the following:

1. Click *Select protocol...*
1. In the *Select Protocol...* window, select *Previous release*, and select one of the releases from the list.
1. Click *OK*.

> [!NOTE]
> For the *Previous release* option to work, the DataMiner Integration Studio has to be able to connect to `https://api.skyline.be/`.

#### Enhancements that make using the class library in a serialization/deserialization context more convenient \[ID_30205\]

The following enhancements will make using the class library in a serialization/deserialization context more convenient:

- Interfaces, base classes and their implementations will now all be copied together into the generated QAction or Automation script.

  If the generator detects that an interface is being used while the class that implements it is not, then the latter will now be copied along into the generated code. Also, if a class is being used while the interface is not, then both will now be copied into the generated code.

- The generated code will now contain all fields and properties of classes, unless they are private, even when those fields and properties are not being used.

#### DIS Validator: Selecting multiple items in the result list \[ID_30492\]

It is now possible to select multiple items in the result list of the *DIS Validator* tool window.

To select more than one item, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive items, click the first one in the list and then click the last one while holding down the SHIFT key.

Use this to do the following:

- Copy a number of results in one go.
- Suppress a number of results in one go.
- Postpone a number of results in one go.
- ...

> [!NOTE]
> Suppressing or postponing a number of results will only work when all selected items have the same error code.

### Validator

#### New checks and error messages \[ID_24390\] \[ID_29543\] \[ID_30739\] \[ID_30740\] \[ID_30741\] \[ID_30742\] \[ID_30795\]

The following checks and error messages have been added.

| Check ID | Error message name                                                | Error message                                                                                                                                                              |
|----------|-------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.25.1   | MinVersionTooLow                                                  | Minimum required version '{currentMinDmVersion}' too low.                                                                                                                  |
| 1.25.2   | MinVersionTooLow_Sub                                              | Expected value '{expectedMinDmVersion}'. '{requiredDmVersion}' : '{usedFeature}'                                                                                           |
| 1.25.3   | MinVersionFeatureUsedInItemWithId_Sub                         | Feature used in '{itemKind}' with '{identifierType}' '{itemId}'.                                                                                                           |
| 1.25.4   | MinVersionFeatureUsedInItem_Sub                              | Feature used in '{itemKind}'.                                                                                                                                              |
| 1.25.5   | UntrimmedTag                                                      | Untrimmed tag 'MinimumRequiredVersion'. Current value '{tagValue}'.                                                                                                        |
| 2.38.4   | MissingRelation                                                   | Missing Relation between table '{fkToTablePid}' and table '{fkFromTablePid}' due to foreignKey on column '{fkColumnPid}'.                                                  |
| 2.49.1   | MissingTag                                                        | Missing tag 'Param/Message' in Param '{pid}'.                                                                                                                              |
| 2.50.1   | MisconfiguredConfirmOptions                                       | Misconfigured 'confirm' option(s) in 'Discreet@options' for ContextMenu. Param ID '{pid}'.                                                                                 |
| 3.11.6   | ColumnManagedByDataMiner                                          | Unsupported set on column '{columnPid}' with '{optionLocation}' containing '{optionName}'.                                                                                 |
| 3.11.7   | ColumnManagedByProtocolItem                                   | Unsupported set on column '{columnPid}' managed by {managedByItemKind} '{managedByItemId}' with '{optionLocation}' containing '{optionName}'.                              |
| 3.12.2   | UnexpectedAccessModifierForEntryPointMethod                   | Entry point method '{entryPointClass}.{entryPointMethod}' has unexpected access modifier '{currentAccessModifier}'. QAction ID {qactionId}.                                |
| 3.12.3   | UnexpectedAccessModifierForEntryPointClass                    | Entry point class '{entryPointClass}' has unexpected access modifier '{currentAccessModifier}'. QAction ID {qactionId}.                                                    |
| 3.12.4   | UnexpectedArg0TypeForEntryPointMethod                         | Entry point method '{entryPointClass}.{entryPointMethod}' has a first argument with unexpected type '{arg0Type}'. QAction ID {qactionId}.                                  |
| 3.15.7   | UnrecommendedNotifyProtocol<br>NTDeleteRow                        | Method 'SLProtocol.NotifyProtocol(156/\*NT_DELETE_ROW\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                  |
| 3.15.8   | UnrecommendedNotifyProtocol<br>NTAddRow                           | Method 'SLProtocol.NotifyProtocol(149/\*NT_ADD_ROW\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                     |
| 3.15.9   | UnrecommendedNotifyProtocol<br>NT_CHECK_TRIGGER                   | Method 'SLProtocol.NotifyProtocol(134/\*NT_CHECK_TRIGGER\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                               |
| 3.15.10  | UnrecommendedNotifyProtocol<br>NT_GET_DATA                        | Method 'SLProtocol.NotifyProtocol(60/\*NT_GET_DATA\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                     |
| 3.15.11  | UnrecommendedNotifyProtocol<br>NT_GET_KEY_POSITION                | Method 'SLProtocol.NotifyProtocol(163/\*NT_GET_KEY_POSITION\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                            |
| 3.15.12  | UnrecommendedNotifyProtocol<br>NT_GET_PARAMETER                   | Method 'SLProtocol.NotifyProtocol(73/\*NT_GET_PARAMETER\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                |
| 3.15.13  | UnrecommendedNotifyProtocol<br>NT_GET_PARAMETER_BY_DATA           | Method 'SLProtocol.NotifyProtocol( 87/\*NT_GET_PARAMETER_BY_DATA\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                       |
| 3.15.14  | UnrecommendedNotifyProtocol<br>NT_GET_PARAMETER_BY_NAME           | Method 'SLProtocol.NotifyProtocol(85/\*NT_GET_PARAMETER_BY_NAME\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                        |
| 3.15.15  | UnrecommendedNotifyProtocol<br>NT_GET_DESCRIPTION                 | Method 'SLProtocol.NotifyProtocol(77/\*NT_GET_DESCRIPTION\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                              |
| 3.15.16  | UnrecommendedNotifyProtocol<br>NT_GET_PARAMETER_INDEX             | Method 'SLProtocol.NotifyProtocol(122/\*NT_GET_PARAMETER_INDEX\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                         |
| 3.15.17  | UnrecommendedNotifyProtocol<br>NT_GET_ITEM_DATA                   | Method 'SLProtocol.NotifyProtocol(88/\*NT_GET_ITEM_DATA\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                |
| 3.15.18  | UnrecommendedNotifyProtocol<br>NT_GET_ROW                         | Method 'SLProtocol.NotifyProtocol(215/\*NT_GET_ROW\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                     |
| 3.15.19  | UnrecommendedNotifyProtocol<br>NT_ARRAY_ROW_COUNT                 | Method 'SLProtocol.NotifyProtocol(195/\*NT_ARRAY_ROW_COUNT\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                             |
| 3.15.20  | UnrecommendedNotifyProtocol<br>NT_NOTIFY_DISPLAY                  | Method 'SLProtocol.NotifyProtocol(123/\*NT_NOTIFY_DISPLAY\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                              |
| 3.15.21  | UnrecommendedNotifyProtocol<br>NT_SET_PARAMETER_WITH_HISTORY | Method 'SLProtocol.NotifyProtocol(256/\*NT_SET_PARAMETER_WITH_HISTORY\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                  |
| 3.15.22  | UnrecommendedNotifyProtocol<br>NT_SET_PARAMETER_BY_DATA           | Method 'SLProtocol.NotifyProtocol(86/\*NT_SET_PARAMETER_BY_DATA\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                        |
| 3.15.23  | UnrecommendedNotifyProtocol<br>NT_SET_PARAMETER_BY_NAME           | Method 'SLProtocol.NotifyProtocol(84/\*NT_SET_PARAMETER_BY_NAME\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                        |
| 3.15.24  | UnrecommendedNotifyProtocol<br>NT_SET_DESCRIPTION                 | Method 'SLProtocol.NotifyProtocol(131/\*NT_SET_DESCRIPTION\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                             |
| 3.15.25  | UnrecommendedNotifyProtocol<br>NT_SET_ITEM_DATA                   | Method 'SLProtocol.NotifyProtocol(89/\*NT_SET_ITEM_DATA\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                |
| 3.15.26  | UnrecommendedNotifyProtocol<br>NT_SET_ROW                         | Method 'SLProtocol.NotifyProtocol(225/\*NT_SET_ROW\*/, ...)' is unrecommended. QAction ID {qactionId}.                                                                     |
| 3.33.1   | UnexpectedImplementation                                          | Method 'SLProtocol.GetParameters' with arguments '{arguments}' is not implemented as expected. QAction ID '{qactionId}'.                                                   |
| 3.33.2   | NonExistingParam                                                  | Method 'SLProtocol.GetParameters' references a non-existing 'Param' with ID '{paramId}'. QAction ID '{qactionId}'.                                                         |
| 3.33.3   | HardCodedPid                                                      | Unrecommended use of magic number '{hardCodedPid}', use 'Parameter' class instead. QAction ID '{qactionId}'.                                                               |
| 3.33.4   | UnsupportedArgumentTypeForIds                                 | Invocation of method 'SLProtocol.GetParameters' has an invalid type '{argumentType}' for the argument 'ids'. QAction ID '{qactionId}'.                                     |
| 3.34.1   | UnexpectedImplementation                                          | Method 'NotifyProtocol(220/\*NT_FILL_ARRAY_WITH_COLUMN\*/, ...)' with arguments '{arguments}' is not implemented as expected. QAction ID '{qactionId}'.                    |
| 3.34.2   | NonExistingTable                                                  | Method 'NotifyProtocol(220/\*NT_FILL_ARRAY_WITH_COLUMN\*/, ...)' references a non-existing 'table' with PID '{tablePid}'. QAction ID '{qactionId}'.                        |
| 3.34.3   | NonExistingColumn                                                 | Method 'NotifyProtocol(220/\*NT_FILL_ARRAY_WITH_COLUMN\*/, ...)' references a non-existing 'column' with PID '{columnPid}'. QAction ID '{qactionId}'.                      |
| 3.34.4   | ColumnMissingHistorySet                                           | NotifyProtocol(220/\*NT_FILL_ARRAY_WITH_COLUMN\*/, ...) method with one or more DateTime(s) given to it requires 'Param@historySet=true' on column with PID '{columnPid}'. |
| 3.34.5   | HardCodedTablePid                                                 | Unrecommended use of magic number '{hardCodedTablePid}', use 'Parameter' class instead. QAction ID '{qactionId}'.                                                          |
| 3.34.6   | HardCodedColumnPid                                                | Unrecommended use of magic number '{hardCodedColumnPid}', use 'Parameter' class instead. QAction ID '{qactionId}'.                                                         |
| 3.34.7   | ColumnManagedByDataMiner                                          | Unsupported set on column '{columnPid}' with '{optionLocation}' containing '{optionName}'.                                                                                 |
| 3.34.8   | ColumnManagedByProtocolItem                                   | Unsupported set on column '{columnPid}' managed by {managedByItemKind} '{managedByItemId}' with '{optionLocation}' containing '{optionName}'.                              |
| 13.2.5   | MissingForeignKeyForRelation                                      | Missing foreignKey(s) detected for relation '{relationNameOrPath}'.                                                                                                        |
| 13.2.6   | MissingForeignKeyInTable_Sub                                      | Missing foreignKey between table '{table1Pid}' and table '{table2Pid}'.                                                                                                    |

#### DataMiner feature check \[ID_29542\]

The Validator will now also check whether the DataMiner version specified in the Protocol.Compliancies.MinimumRequiredVersion element supports all features used in the protocol.

Currently, the following features will be checked:

- Chains.Chain.Field@options=”SkipInDiagram”
- Chains.Chain@defaultSelectionField and Chains.Chain@groupingName
- Display.Pages.Page.Visibility@overridePID
- “ElementManagerType” parameter
- Engine property UserCookie
- HTTP.Session@loginMethod=”certificate”
- InternalLicenses.InternalLicense
- Notify type NT_DELETE_FOLDER (182): “recycle” parameter
- Notify type NT_FILL_ARRAY (193), NT_FILL_ARRAY_NO_DELETE (194) and NT_FILL_ARRAY_WITH_COLUMN (220): datetime parameter
- Notify type NT_UPDATE_PORTS_XML (128): ChangeType 10
- Notify types NT_GET_TABLE_ID_BY_COLUMN_ID (393) and NT_GET_PK_ID_BY_TABLE_ID (394)
- NotifyProtocol methods FillArray, FillArrayNoDelete and FillArrayWithColumn: “timeInfo” parameter
- Params.Param.Dashboard
- Params.Param.Database.Partition set to ”infinite”
- Params.Param.Display.DynamicUnits
- Params.Param.Interprete.Defaultvalue
- Params.Param.Measurement.Discreets.Discreet.Tooltip
- Params.Param.Measurement.Discreets@matrixLayout
- Params.Param.Measurement.Type@options=”date” and Params.Param.Measurement.Type@options =”datetime”
- Params.Param.Mediation.LinkTo.ValueMapping
- Params.Param.Replication
- Params.Param.SNMP.InvalidResponseHandling.InfiniteLoop
- Params.Param@saveInterval
- Portsettings.FlushPerDatagram
- ProfileHelper class
- QActionTable methods FillArray, FillArrayNoDelete and SetColumn: “timeInfo” parameter
- SLProtocol method SLProtocol.ExecuteScript
- Topologies.Topology.Cell.Exposer

### XML Schema

#### Protocol Schema: Protocol.Params.Param.Alarm@lowhigh attribute removed \[ID_30664\]

The Protocol.Params.Param.Alarm@lowhigh attribute has been removed from the Protocol XML Schema.

#### Protocol Schema: Protocol.Chains.Chain.Field.Display element is no longer a mandatory element \[ID_30665\]

From now on, the Protocol.Chains.Chain.Field.Display element is no longer is mandatory child element of the Protocol.Chains.Chain.Field element.

#### Protocol Schema: New Protocol.Actions.Action.Type@regex attribute \[ID_30666\]

The Protocol.Actions.Action.Type@regex attribute has been added to the Protocol XML Schema.

### Class Library

#### Extended authentication algorithm support \[ID_30232\]

The class library now supports the following authentication algorithms:

- MD5
- HMAC-MD5
- SHA1
- HMAC-SHA1

## Changes

### Enhancements

#### Validator: Enhanced parsing of method arguments \[ID_31009\]

A number of enhancements have been made with regard to the parsing of method arguments.

### Fixes

#### Validator: False positives when checking title casing \[ID_30849\]

In some cases, the title casing checks 2.13.8, 2.14.8, 2.22.7 and 2.40.7 could return false positives when checking the following image formats:

- 1080i/30
- 1080p/30
- 1080psf/30

#### Validator: False positives when checking Treecontrol.HiddenColumns elements \[ID_30850\]

When tables were added to tree controls using ExtraDetails@detailsTableId arguments that referred to parameter IDs of foreign key columns, in some cases, the Validator could return false positives when checking TreeControl.HiddenColumns elements.

#### DIS Comparer: False positives when the casing of Param.Measurement.Discreets.Discreet.Value elements had changed \[ID_30859\]

When checking Param.Measurement.Discreets.Discreet.Value elements, in some cases, the DIS Comparer could return false positives when the casing of the values had changed.

#### DIS Comparer: False positives when values in the protocol had been trimmed by the user \[ID_30876\]

In some cases, the DIS Comparer could return false positives when values in the protocol had been trimmed by the user.

#### DIS Comparer: Automatic page button caption fixes would incorrectly be flagged as breaking changes \[ID_30886\]

When the DIS Comparer finds a page button caption that does not end with an ellipsis (“...”), it proposes an automatic non-breaking fix. However, in some cases, those fixes could incorrectly be flagged as breaking changes.

#### DIS Comparer: Some parameter description updates would incorrectly be considered as major changes \[ID_30894\]

Typically, the DIS Comparer will consider parameter description updates as major changes. However, in the following exceptional cases, updating the parameter description is allowed. Up to now, the DIS Comparer would incorrectly also consider these updates as major changes:

- Adding a description to a parameter that either had no description or an empty description.
- Removing the description of a parameter that does not require one and that will never be retrieved or updated by an Automation script.
