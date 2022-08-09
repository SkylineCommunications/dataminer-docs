---
uid: DIS_2.30
---

# DIS 2.30

## New features

### IDE

#### Protocol solutions will now by default have a Documentation folder \[ID_27596\]

When you create a new protocol solution or convert an existing protocol to a protocol solution, from now on, a “Documentation” folder will automatically be added to the solution.

In this folder, you can store all information about the protocol in question.

#### Broken references to DataMiner DLLs will now automatically be detected and fixed \[ID_27604\]

When it creates a QAction project, DIS will look for the DataMiner DLLs in the C:\\Skyline DataMiner\\ folder. If it does not find them there, it will check the DIS extension folder. However, the name of that folder is a unique ID that differs from one installation to another and from one update to another. As a result, a QAction project can easily contain broken DLL references.

From now on, when DIS detects a broken DLL reference, it will automatically try to update the path to that DLL.

### Validator

#### New checks and error messages \[ID_26852\]\[ID_27639\]\[ID_27819\]

The following checks and error messages have been added.

| Check ID | Error message name                  | Error message                                                                                                                                              |
|----------|-------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.23.6   | InvalidCombinationOfSyntax1And2 | Connections can not be defined simultaneously via 'Protocol/Type' and 'Protocol/Connections'.                                                              |
| 1.23.7   | UnrecommendedSyntax2                | Unrecommended use of the 'Protocol/Connections' syntax.                                                                                                    |
| 3.10.1   | NonExistingParam                    | The SLProtocol.FillArrayNoDelete method references a non-existing table.                                                                                   |
| 3.10.2   | ParamMissingHistorySet              | The SLProtocol.FillArrayNoDelete overload with DateTime argument requires the historySet attribute to be set to true.                                      |
| 3.10.3   | HardCodedPid                        | Unrecommended use of magic number in FillArrayNoDelete.                                                                                                    |
| 3.11.1   | NonExistingParam                    | The SLProtocol.FillArrayWithColumn method references a non-existing table.                                                                                 |
| 3.11.2   | ParamMissingHistorySet              | The SLProtocol.FillArrayWithColumn overload with DateTime argument requires the historySet attribute to be set to true.                                    |
| 3.11.3   | HardCodedPid                        | Unrecommended use of magic number in FillArrayWithColumn.                                                                                                  |
| 3.16.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(115/\*NT_SET_ELEMENT_STATE\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.       |
| 3.17.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(116/\*NT_SET_ALARM_STATE\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.         |
| 3.18.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(73/\*NT_GET_PARAMETER\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.                    |
| 3.19.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(117/\*NT_ASSIGN_ALARM_TEMPLATE\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.   |
| 3.20.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(128/\*NT_UPDATE_PORTS_XML\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.        |
| 3.21.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(62/\*NT_EDIT_PROPERTY\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.            |
| 3.22.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(14/\*NT_TRENDING_ASSIGN_TEMPLATE\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}. |
| 3.23.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(127/\*NT_UPDATE_DESCRIPTION_XML\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.  |
| 3.24.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(76/\*NT_ASSIGN_SIMULATION\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.        |
| 3.25.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(69/\*NT_GET_VALUE\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.                        |
| 3.26.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(48/\*NT_GET_ALARM_INFO\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.                   |
| 3.27.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(144/\*NT_GET_ELEMENT_NAME\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.                |
| 3.28.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(232/\*NT_SERVICE_SET_VDX\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.         |
| 3.29.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyProtocol(292/\*NT_SNMP_SET\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.                         |
| 3.30.1   | DeltIncompatible                    | Invocation of method 'SLProtocol.NotifyProtocol(295/\*NT_SNMP_GET\*/, ...)' is not compatible with 'DELT'. QAction ID {qactionId}.                         |
| 3.6.1    | NonExistingParam                    | The SLProtocol.GetParameter method references a non-existing parameter.                                                                                    |
| 3.6.2    | HardCodedPid                        | Unrecommended use of magic number in SLProtocol.GetParameter.                                                                                              |
| 3.7.1    | NonExistingParam                    | The SLProtocol.SetParameter method references a non-existing parameter.                                                                                    |
| 3.7.2    | HardCodedPid                        | Unrecommended use of magic number in SLProtocol.SetParameter.                                                                                              |
| 3.7.3    | ParamMissingHistorySet              | The SLProtocol.SetParameter overload with DateTime argument requires the historySet attribute to be set to true.                                           |
| 3.8.1    | NonExistingParam                    | The SLProtocol.SetRow method references a non-existing table parameter.                                                                                    |
| 3.8.2    | HardCodedPid                        | Unrecommended use of magic number in SLProtocol.SetRow.                                                                                                    |
| 3.8.3    | ParamMissingHistorySet              | The SLProtocol.SetRow overload with DateTime argument requires the historySet attribute to be set to true.                                                 |
| 3.9.1    | NonExistingParam                    | The SLProtocol.FillArray method references a non-existing table.                                                                                           |
| 3.9.2    | ParamMissingHistorySet              | The SLProtocol.FillArray overload with DateTime argument requires the historySet attribute to be set to true.                                              |
| 3.9.3    | HardCodedPid                        | Unrecommended use of magic number in SLProtocol.FillArray.                                                                                                 |

### XML Schema

#### Protocol Schema: Miscellaneous updates \[ID_27564\]\[ID_27566\]\[ID_27709\]\[ID_27772\]

The Protocol XML schema has been updated.

- The visibleInUI attribute has been removed from Protocol.PortSettings (i.e. the port settings of the main connection). This attribute is now only available in Protocol.Ports.PortSettings (i.e. the port settings of the additional connections).
- The backup attribute has been removed from Protocol.Params.Param.
- PortSettings.FlowControl.DefaultValue, PortSettings.FlowControl.Range.From and PortSettings.FlowControl.Range.To can now all be set to “no”.
- Protocol.Params.Param.Interprete.Exceptions.Exception.Display is now of type non-empty string.

#### UOM Schema: New units added \[ID_27568\]

The following units have been added to the UOM Schema:

- mV/deg C/Cell (millivolt per degree Celsius per Cell)
- Flashes/s (flashes per second)
- Streams (streams)
- Channels (channels)

## Changes

### Enhancements

#### Validator: Enhanced endless loop check \[ID_27554\]

Up to now, in some cases, false positives could be raised when there was an Action of type “make” or “crc” and a trigger on the related command.

Also, when a (potential) endless loop is detected, from now on, the result of the check will contain the protocol implementation path rather than the DataMiner processing order path.

#### Validator - Major Change Check: Miscellaneous enhancements \[ID_27720\]

A number of enhancements have been made to the Major Change Check functionality.

- The following error will no longer be raised for parameters that are not available in SLElement.

    | Check ID | Error message name | Error message |
    |----------|--------------------|---------------|
    | 2.14.1 | UpdatedValue | Description tag on Param '{paramId}' was changed from '{previousDescription}' into '{newDescription}'. |

- Connection checks are now all implemented in a common check. Up to now, the main connection and the additional connections were checked separately.

    | Check ID | Error message name | Error message |
    |----------|--------------------|---------------|
    | 1.8.4 | *Replaced by 1.23.9* |         |
    | 1.11.2 | *Replaced by 1.23.9* |        |
    | 1.23.9 | ConnectionTypeChanged | {connectionType} Connection '{connectionId}' with name '{connectionName}' was changed into '{newConnectionType}'. |
    | 1.11.1 | *Replaced by 1.23.8* |        |
    | 1.23.8 | ConnectionsOrderChanged | Order of connections changed from '{oldOrder}' to '{newOrder}'. |
    | 1.11.3 | *Replaced by 1.23.10* |           |
    | 1.23.10 | ConnectionAdded | {connectionType} Connection '{connectionId}' with name '{connectionName}' was added. |

- The following check has been made case-insensitive.

    | Check ID | Error message name | Error message |
    |----------|--------------------|---------------|
    | 2.22.1 | RemovedFromPage | Param '{paramPid}' was removed from page '{pageName}'. |

- Display key checks on the naming option and NamingFormat are now combined.

    | Check ID | Error message name | Error message |
    |----------|--------------------|---------------|
    | 2.17.1 | *Replaced by 2.39.4* |       |
    | 2.18.1 | *Replaced by 2.39.4* |     |
    | 2.39.4 | FormatChanged | Table display key was changed from {oldSyntax} '{oldFormat}' to {newSyntax} '{newFormat}'. Table PID '{tablePid}'. |
    | 2.17.4 | *Replaced by 2.39.5* |           |
    | 2.18.2 | *Replaced by 2.39.5* |         |
    | 2.39.5 | FormatRemoved  | Table display key previously defined via '{oldSyntax}' was removed. Table PID '{tablePid}'. |

### Fixes

#### Class Library: Name of an element with a RealConnection could no longer be updated  \[ID_27783\]

In some cases, the name of an element with a RealConnection (SNMP, HTTP, SERIAL, etc.) could no longer be updated.

#### Class Library: A matrix output could not be disconnected when it was connected to the first input \[ID_27784\]

Due to an error in the Matrix Helper class, in some cases, an output could not be disconnected when it was connected to the first input.
