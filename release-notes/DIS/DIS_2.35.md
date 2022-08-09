---
uid: DIS_2.35
---

# DIS 2.35

## New features

### IDE

#### XML editor: Link lists now also contain parameters referred to in id attributes of \<LengthType> elements and in connectionPID attributes of \<Group> elements \[ID_30926\] \[ID_30935\]

In the XML editor, next to certain items, you will find a button in the shape of a paper clip. When you hover over this paper clip, a list box will appear, listing all items that are in some way linked to the item in question. From now on, this list box will also contain parameters referred to in id attributes of \<LengthType> elements and in connectionPID attributes of \<Group> elements.

#### Support for Microsoft Visual Studio 2022 \[ID_31366\]

DIS now supports Microsoft Visual Studio 2022.

Available installation packages:

| Microsoft Visual Studio version           | DIS installation package                     |
|-------------------------------------------|----------------------------------------------|
| Visual Studio 2022                        | DataMinerIntegrationStudio17 \<version>.vsix |
| Visual Studio 2019 or Visual Studio 2017  | DataMinerIntegrationStudio16 \<version>.vsix |

> [!NOTE]
> Support for Microsoft Visual Studio 2015 has been dropped. The last DIS version supporting Visual Studio 2015 is DIS version 2.34.

### Validator

#### New checks and error messages \[ID_30887\] \[ID_31170\]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 1.26.1 | InvalidPingGroupType | Ping group for '{connectionType}' connection is not a '{connectionType}' poll group. Group ID '{groupId}'. (Replaces legacy check 2701.) |
| 1.26.2 | PingSerialPairHasNoResponse | Ping pair for '{connectionType}' connection contains no response. Pair ID '{pairId}'. (Replaces legacy check 2704.) |
| 1.26.3 | MultiplePingPairsForConnection | Multiple ping pairs for connection with name '{connectionName}' and type '{connectionType}'. Connection ID '{connectionId}'. (Replaces legacy checks 2702/2703.) |
| 1.26.4 | MultiplePingPairsForConnection_Sub | Multiple ping pairs for connection '{connectionId}'. Pair '{pairId}'. (Replaces legacy checks 2702/2703.) |
| 3.35.1 | InvalidCondition | Invalid condition '{conditionString}'. Reason '{invalidityReason}'. QAction ID '{qactionId}'. |
| 3.35.2 | NonExistingId | Tag 'QAction/Condition' references a non-existing 'Param' with PID '{paramId}'. QAction ID '{qactionId}'. |
| 4.9.1 | InvalidCondition | Invalid condition '{conditionString}'. Reason '{invalidityReason}'. Group ID '{groupId}'. |
| 4.9.2 | NonExistingId | Tag 'Group/Condition' references a non-existing 'Param' with PID '{paramId}'. Group ID '{groupId}'. |
| 5.5.1 | InvalidCondition | Invalid condition '{conditionString}'. Reason '{invalidityReason}'. Trigger ID '{triggerId}'. |
| 5.5.2 | NonExistingId | Tag 'Trigger/Condition' references a non-existing 'Param' with PID '{paramId}'. Trigger ID '{triggerId}'. |
| 6.4.1 | InvalidCondition | Invalid condition '{conditionString}'. Reason '{invalidityReason}'. Action ID '{actionId}'. |
| 6.4.2 | NonExistingId | Tag 'Action/Condition' references a non-existing 'Param' with PID '{paramId}'. Action ID '{actionId}'. |
| 7.4.1 | InvalidCondition | Invalid condition '{conditionString}'. Reason '{invalidityReason}'. Timer ID '{timerId}'. |
| 7.4.2 | NonExistingId | Tag 'Timer/Condition' references a non-existing 'Param' with PID '{paramId}'. Timer ID '{timerId}'. |
| 7.4.3 | UnrecommendedCondition | Unrecommended condition on Timer. Timer ID '{timerId}'. |
| 9.7.1 | InvalidCondition | Invalid condition '{conditionString}'. Reason '{invalidityReason}'. Pair ID '{pairId}'. |
| 9.7.2 | NonExistingId | Tag 'Pair/Condition' references a non-existing 'Param' with PID '{paramId}'. Pair ID '{pairId}'. |

### XML Schema

#### Protocol Schema: New Protocol.ParameterGroups.Group@calculateAlarmState attribute \[ID_31600\]

The Protocol.ParameterGroups.Group element now has a calculateAlarmState attribute.

Possible values: true or false

#### Installation Package Manifest Schema: setAsDefault attribute replaced by SetAsDefault element \[ID_31603\]

The Manifest.Content.Visios.Visio.Version@setAsDefault attribute has now been replaced by the SetAsDefault element.

Also, in the VersionHistory, it is now allowed to set the ID of the CU part to 0.

## Changes

### Enhancements

#### IDE - DIS Validator: Navigate to QAction C# validator results \[ID_31384\]

When, in the DIS Validator tool window, you double-clicked on a validator result that described an error in the C# code of a QAction, up to now, Visual Studio would jump to the start of the \<QAction> tag in the protocol XML file. From now on, it will jump to the actual line containing the error in the C# file.
