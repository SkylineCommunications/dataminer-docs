---
uid: DIS_2.24
---

# DIS 2.24

## New features

### IDE

#### C# editor: Class Library can now also be used in Automation scripts \[ID_23925\]

From now on, it is also possible to use code from Class Library packages in Automation scripts.

When DIS detects that code from a loaded Class Library package is used in EXE blocks of an Automation script, it will

- add a new EXE block to that script containing only the code necessary to be able to use the wanted functionally, and
- add references in the EXE blocks using that Class Library code to the newly added EXE block containing the Class Library code.

> [!NOTE]
> Using Class Library packages in Automation scripts will only work in conjunction with DataMiner version 9.6.13 or higher.

#### C# editor: New snippets \[ID_24066\]\[ID_24222\]

In the C# editor, you can now use the following additional snippets:

##### DIS \> Automation Script

- CreateInformationEvent
- EditSpectrumPreset
- EmailReports
- EmailReportsWithReservationGUID
- EmailWithCustomContent
- GetScriptDummy
- MaskElementsInView
- RunAutomationScript

##### DIS \> Protocol \> Class Library

- Get DMS With Monitor

### Validator

#### New and updated checks and error messages \[ID_22757\]\[ID_23419\]\[ID_23793\]\[ID_23935\]\[ID_24132\]

The following checks and error messages have been added, updated or removed.

| ID      | Check                                                             | Error message                                                                                                                                                                                                                |
|---------|-------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.11.4  | CheckAdvancedAttribute                                            | Empty attribute 'Protocol/Type@advanced'.                                                                                                                                                                                    |
| 1.11.5  | CheckAdvancedAttribute                                            | Untrimmed attribute 'Protocol/Type@advanced'. Current value '{attributeValue}'.                                                                                                                                              |
| 1.11.6  | CheckAdvancedAttribute                                            | Untrimmed value '{untrimmedValue}' in attribute 'Protocol/Type@advanced'.                                                                                                                                                    |
| 1.11.7  | CheckAdvancedAttribute                                            | Unknown connection type '{connectionType}' in Connection '{connectionId}'.                                                                                                                                                   |
| 1.23.1  | CheckConnections                                                  | Connection {connectionId} has mismatching names: '{names}'.                                                                                                                                                                  |
| 1.23.2  | CheckConnections                                                  | Invalid connection name '{connectionName}' for a '{connectionType}' connection. Connection ID '{connectionId}'.                                                                                                              |
| 1.23.3  | CheckConnections                                                  | Duplicated Connection Name '{name}'.                                                                                                                                                                                         |
| 1.23.4  | CheckConnections                                                  | Duplicated Connection Name '{name}'. Connection IDs '{connectionIds}'.                                                                                                                                                       |
| 1.23.5  | CheckConnections                                                  | Connection count in 'Protocol/Type' tag '{connectionCount}' doesn't match with PortSettings count '{portSettingCount}'.                                                                                                      |
| 2.13.2  | CheckDisplayTag                                                   | Invalid page button caption format '{displayValue}'. Suggested fix '{suggestedValue}'. Param ID '{paramId}'.                                                                                                                  |
| 2.13.3  | CheckDisplayTag                                                   | Missing tag 'Discreet/Display' in Param '{paramId}'.                                                                                                                                                                         |
| 2.13.4  | CheckDisplayTag                                                   | Empty tag 'Discreet/Display' in Param '{paramId}'.                                                                                                                                                                           |
| 2.13.5  | CheckDisplayTag                                                   | Untrimmed tag 'Discreet/Display' in Param '{paramId}'. Current value '{untrimmedValue}'.                                                                                                                                     |
| 2.37.1  | Error message “InvalidValue” renamed to “TogglebuttonRecommended” |                                                                                                                                                                                                                              |
| 2.37.9  | CheckTypeTag                                                      | Invalid value '{paramType}' in 'Param/Type' for '{measurementType}'. Param ID '{paramId}'.                                                                                                                                   |
| 2.37.10 | CheckTypeTag                                                      | Empty tag 'Measurement/Type' in Param '{paramId}'.                                                                                                                                                                           |
| 2.37.11 | CheckTypeTag                                                      | Invalid value '{measurementType}' in tag 'Measurement/Type'. Param ID '{paramId}'.                                                                                                                                           |
| 2.37.12 | CheckTypeTag                                                      | Untrimmed tag 'Measurement/Type' in Param '{paramId}'. Current value '{untrimmedValue}'.                                                                                                                                     |
| 2.51.1  | CheckDiscreetsTag                                                 | Missing 'Measurement/Discreets' tag for '{paramDisplayType}' Param with ID '{pid}'.                                                                                                                                          |
| 2.52.1  | CheckDiscreetTag                                                  | Missing 'Discreet' tag(s) in 'Measurement/Discreets' tag. Param ID '{pid}'.                                                                                                                                                  |
| 3.2.1   | CheckTriggersAttribute                                            | Missing attribute 'triggers' in QAction '{qactionId}'.                                                                                                                                                                       |
| 3.2.2   | CheckTriggersAttribute                                            | Empty attribute 'triggers' in QAction '{qactionId}'.                                                                                                                                                                         |
| 3.2.3   | CheckTriggersAttribute                                            | Invalid value '{triggersValue}' in attribute 'triggers'. QAction ID '{qactionId}'.                                                                                                                                           |
| 3.2.4   | CheckTriggersAttribute                                            | Attribute 'triggers' references a non-existing 'Param' with ID '{pid}'. QAction ID '{qactionId}'.                                                                                                                            |
| 3.2.5   | CheckTriggersAttribute                                            | Attribute 'triggers' references a non-existing 'Group' with ID '{triggerId}'. QAction ID '{qactionId}'.                                                                                                                      |
| 3.2.6   | CheckTriggersAttribute                                            | Duplicate ID '{duplicateId}' in 'QAction@triggers'. QAction ID '{qactionId}'.                                                                                                                                                |
| 4.2.1   | CheckParamTag                                                     | Tag 'Content/Param' references a non-existing 'Param' with ID '{pid}'. Group ID '{groupId}'.                                                                                                                                 |
| 4.2.2   | CheckParamTag                                                     | Empty tag 'Param' in Group '{groupId}'.                                                                                                                                                                                      |
| 4.2.3   | CheckParamTag                                                     | Invalid value '{value}' in tag 'Content/Param'. Group ID '{groupId}'.                                                                                                                                                        |
| 4.3.1   | CheckActionTag                                                    | Tag 'Content/Action' references a non-existing 'Action' with ID '{actionId}'. Group ID '{groupId}'.                                                                                                                          |
| 4.3.2   | CheckActionTag                                                    | Empty tag 'Content/Action' in Group '{groupId}'.                                                                                                                                                                             |
| 4.3.3   | CheckActionTag                                                    | Invalid value '{value}' in tag 'Content/Action'. Group ID '{groupId}'.                                                                                                                                                       |
| 4.4.1   | CheckPairTag                                                      | Tag 'Content/Pair' references a non-existing 'Pair' with ID '{pairId}'. Group ID '{groupId}'.                                                                                                                                |
| 4.4.2   | CheckPairTag                                                      | Empty tag 'Content/Pair' in Group '{groupId}'.                                                                                                                                                                               |
| 4.4.3   | CheckPairTag                                                      | Invalid value '{value}' in tag 'Content/Pair'. Group ID '{groupId}'.                                                                                                                                                         |
| 4.5.1   | CheckSessionTag                                                   | Tag 'Content/Session' references a non-existing 'HTTP Session' with ID '{sessionId}'. Group ID '{groupId}'.                                                                                                                  |
| 4.5.2   | CheckSessionTag                                                   | Empty tag 'Content/Session' in Group '{groupId}'.                                                                                                                                                                            |
| 4.5.3   | CheckSessionTag                                                   | Invalid value '{value}' in tag 'Content/Session'. Group ID '{groupId}'.                                                                                                                                                      |
| 4.6.1   | CheckTriggerTag                                                   | Tag 'Content/Trigger' references a non-existing 'Trigger' with ID '{triggerId}'. Group ID '{groupId}'.                                                                                                                       |
| 4.6.2   | CheckTriggerTag                                                   | Empty tag 'Content/Trigger' in Group '{groupId}'.                                                                                                                                                                            |
| 4.6.3   | CheckTriggerTag                                                   | Invalid value '{value}' in tag 'Content/Trigger'. Group ID '{groupId}'.                                                                                                                                                      |
| 4.7.1   | CheckConnectionPidAttribute                                       | Empty attribute 'connectionPid' in Group '{groupId}'.                                                                                                                                                                        |
| 4.7.2   | CheckConnectionPidAttribute                                       | Invalid value '{connectionPid}' in attribute 'connectionPid'. Group ID '{groupId}'.                                                                                                                                          |
| 4.7.3   | CheckConnectionPidAttribute                                       | Attribute 'connectionPid' references a non-existing 'Param' with ID '{pid}'. Group ID '{groupId}'.                                                                                                                           |
| 7.3.2   | CheckOptionsAttribute                                             | {timerOption}' option refers to a non-existing {referItemType} '{referItemId}'.                                                                                                                                              |
| 7.3.3   | CheckOptionsAttribute                                             | {optionName}' option has an invalid value '{optionValue}'.                                                                                                                                                                   |
| 7.3.5   | CheckOptionsAttribute                                             | Invalid value for Timer@options attribute. Timer ID '{timerId}'. Current Value '{attributeValue}'.                                                                                                                           |
| 7.3.6   | CheckOptionsAttribute                                             | Option '{optionName}' requires the 'ip' option in Timer@options. Timer ID '{timerId}'.                                                                                                                                       |
| 7.3.7   | CheckOptionsAttribute                                             | Invalid value for 'ignoreIf' option. Expected format: 'ignoreIf:\<columnIdx>,\<value>'. Current value '{ignoreIfValue}'.                                                                                                     |
| 7.3.8   | CheckOptionsAttribute                                             | Invalid value for 'each' option. Expected format: 'each:\<period>'. Current value '{optionValue}'.                                                                                                                           |
| 7.3.9   | CheckOptionsAttribute                                             | Invalid value for 'dynamicThreadPool' option. Expected format: 'dynamicThreadPool:\<threadPoolSizeMonitorPid>'. Current value '{optionValue}'.                                                                               |
| 7.3.10  | CheckOptionsAttribute                                             | Invalid value for 'instance' option. Expected format: 'instance:\<tablePid>,\<columnIdx>'. Current value '{optionValue}'.                                                                                                    |
| 7.3.11  | CheckOptionsAttribute                                             | Invalid value for 'ip' option. Expected format: 'ip:\<tablePid>,\<columnIdx>'. Current value '{optionValue}'.                                                                                                                |
| 7.3.12  | CheckOptionsAttribute                                             | Invalid value for 'pollingRate' option. Expected format: 'pollingRate:\<interval>,\<maxCount>,\<releaseCount>'. Current value '{optionValue}'.                                                                               |
| 7.3.13  | CheckOptionsAttribute                                             | Invalid value for 'qaction' option. Expected format: 'qaction:\<qactionId>'. Current value '{optionValue}'.                                                                                                                  |
| 7.3.14  | CheckOptionsAttribute                                             | Invalid value for 'qactionBefore' option. Expected format: 'qactionBefore:\<qactionId>'. Current value '{optionValue}'.                                                                                                      |
| 7.3.15  | CheckOptionsAttribute                                             | Invalid value for 'qactionAfter' option. Expected format: 'qactionAfter:\<qactionId>'. Current value '{optionValue}'.                                                                                                        |
| 7.3.16  | CheckOptionsAttribute                                             | Invalid value for 'threadPool' option. Expected format: 'threadPool:\<size>,\<calculationInterval>,\<usagePid>,\<waitingPid>,\<maxDurationPid>,\<avgDurationPid>,\<counterPid>,\<queueSize>'. Current value '{optionValue}'. |
| 7.3.17  | CheckOptionsAttribute                                             | Option '{optionName}' requires the 'each' option in Timer@options. Timer ID '{timerId}'.                                                                                                                                     |
| 7.3.18  | CheckOptionsAttribute                                             | Option '{optionName}' requires the 'threadPool' option in Timer@options. Timer ID '{timerId}'.                                                                                                                               |
| 7.3.19  | CheckOptionsAttribute                                             | dynamicThreadPool' option refers to a non-existing parameter: '{paramId}'.                                                                                                                                                   |
| 7.3.20  | CheckOptionsAttribute                                             | Required value '{placeholderName}' is not defined.                                                                                                                                                                           |
| 7.3.21  | CheckOptionsAttribute                                             | Invalid value for 'ping' option. Current value: '{optionValue}'.                                                                                                                                                             |
| 7.3.22  | CheckOptionsAttribute                                             | Unknown option '{optionName}' detected.                                                                                                                                                                                      |
| 7.3.23  | CheckOptionsAttribute                                             | Duplicate option '{optionName}' detected.                                                                                                                                                                                    |
| 7.3.24  | CheckOptionsAttribute                                             | Unknown option '{optionName}' detected in 'ping' option.                                                                                                                                                                     |
| 7.3.25  | CheckOptionsAttribute                                             | Duplicate option '{optionName}' detected in 'ping' option.                                                                                                                                                                   |
| 7.3.26  | CheckOptionsAttribute                                             | Enabling the calculation of the thread pool statistics by defining an interval can have an impact on performance.                                                                                                            |
| 7.3.27  | CheckOptionsAttribute                                             | The use of the timeoutPid option in the ping option is obsolete.                                                                                                                                                             |
| 7.3.28  | CheckOptionsAttribute                                             | The use of the qaction option is obsolete.                                                                                                                                                                                   |
| 7.3.29  | CheckOptionsAttribute                                             | {timerOption}' option refers to a non-existing column idx '{columnIdx}' in table '{tablePid}'.                                                                                                                               |
| 7.3.30  | CheckOptionsAttribute                                             | {timerOption}' option refers to a non-existing column 1-based position '{columnPosition}' in table '{tablePid}'.                                                                                                             |
| 8.4.1   | CheckPasswordAttribute                                            | Attribute 'password' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'.                                                                                                                       |
| 8.5.1   | CheckUsernameAttribute                                            | Attribute 'userName' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'.                                                                                                                       |
| 8.6.1   | CheckProxyServerAttribute                                         | Attribute 'proxyServer' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'.                                                                                                                    |
| 8.7.1   | CheckProxyUserAttribute                                           | Attribute 'proxyUser' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'.                                                                                                                      |
| 8.8.1   | CheckProxyPasswordAttribute                                       | Attribute 'proxyPassword' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'.                                                                                                                  |
| 8.9.1   | CheckPidAttribute                                                 | Attribute 'Request@pid' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                                                    |
| 8.9.2   | CheckPidAttribute                                                 | Empty attribute 'Request@pid' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                                                 |
| 8.9.3   | CheckPidAttribute                                                 | Invalid value '{pidValue}' in attribute 'Request@pid'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                                    |
| 8.10.1  | CheckPidAttribute                                                 | Attribute 'Request/Data@pid' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                                               |
| 8.10.2  | CheckPidAttribute                                                 | Empty attribute 'Request/Data@pid' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                                            |
| 8.10.3  | CheckPidAttribute                                                 | Invalid value '{pidValue}' in attribute 'Request/Data@pid'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                               |
| 8.11.1  | CheckPidAttribute                                                 | Attribute 'Request/Headers/Header@pid' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                                     |
| 8.11.2  | CheckPidAttribute                                                 | Empty attribute 'Request/Headers/Header@pid' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                                  |
| 8.11.3  | CheckPidAttribute                                                 | Invalid value '{pidValue}' in attribute 'Request/Headers/Header@pid'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                     |
| 8.12.1  | CheckPidAttribute                                                 | Attribute 'Request/Parameters/Parameter@pid' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                               |
| 8.12.2  | CheckPidAttribute                                                 | Empty attribute 'Request/Parameters/Parameter@pid' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                            |
| 8.12.3  | CheckPidAttribute                                                 | Invalid value '{pidValue}' in attribute 'Parameter@pid'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                                  |
| 8.13.1  | CheckStatusCodeAttribute                                          | Attribute 'Response@statusCode' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                                            |
| 8.13.2  | CheckStatusCodeAttribute                                          | Empty attribute 'Response@statusCode' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                                         |
| 8.13.3  | CheckStatusCodeAttribute                                          | Invalid value '{statusCode}' in attribute 'Response@statusCode'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                          |
| 8.14.1  | CheckPidAttribute                                                 | Attribute 'Response/Content@pid' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                                           |
| 8.14.2  | CheckPidAttribute                                                 | Empty attribute 'Response/Content@pid' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                                        |
| 8.14.3  | CheckPidAttribute                                                 | Invalid value '{pidValue}' in attribute 'Response/Content@pid'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                           |
| 8.15.1  | CheckPidAttribute                                                 | Attribute 'Response/Headers/Header@pid' references a non-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                                    |
| 8.15.2  | CheckPidAttribute                                                 | Empty attribute 'Response/Headers/Header@pid' in HTTP Session '{sessionId}'. Connection ID '{connectionId}'.                                                                                                                 |
| 8.15.3  | CheckPidAttribute                                                 | Invalid value '{pidValue}' in attribute 'Response/Headers/Header@pid'. HTTP Session ID '{httpSessionId}'. Connection ID '{connectionId}'.                                                                                    |
| 9.2.1   | CheckContentTag                                                   | Missing clear response routine for pair '{pairId}'.                                                                                                                                                                          |
| 9.2.2   | CheckContentTag                                                   | Missing clear response '{responseIdToClear}' routine after response '{responseIdOnWhichToTrigger}'.                                                                                                                          |
| 10.3.1  | CheckParamTag                                                     | Tag 'Content/Param' references a non-existing 'Param' with ID '{referencedPid}'. Command ID '{commandId}'.                                                                                                                   |
| 10.3.2  | CheckParamTag                                                     | Empty tag 'Param' in Command '{commandId}'.                                                                                                                                                                                  |
| 10.3.3  | CheckParamTag                                                     | Invalid value '{value}' in tag 'Content/Param'. Command ID '{commandId}'.                                                                                                                                                    |
| 10.4.1  | CheckAsciiAttribute                                               | Empty attribute 'ascii' in Command '{commandId}'.                                                                                                                                                                            |
| 10.4.2  | CheckAsciiAttribute                                               | Invalid value '{asciiValue}' in attribute 'ascii'. Command ID '{commandId}'.                                                                                                                                                 |
| 10.4.3  | CheckAsciiAttribute                                               | Attribute 'ascii' references a non-existing 'Param' with ID '{pid}'. Command ID '{commandId}'.                                                                                                                               |
| 11.3.1  | CheckParamTag                                                     | Tag 'Content/Param' references a non-existing 'Param' with ID '{referencedPid}'. Response ID '{responseId}'.                                                                                                                 |
| 11.3.2  | CheckParamTag                                                     | Empty tag 'Param' in Response '{responseId}'.                                                                                                                                                                                |
| 11.3.3  | CheckParamTag                                                     | Invalid value '{value}' in tag 'Content/Param'. Response ID '{responseId}'.                                                                                                                                                  |
| 12.1.1. | Error message “DuplicatedValue” removed.                          |                                                                                                                                                                                                                              |
| 12.1.2  | CheckNameAttribute                                                | Missing attribute 'Ports/PortSettings@name' in Connection '{connectionId}'.                                                                                                                                                  |
| 12.1.3  | CheckNameAttribute                                                | Empty attribute 'Ports/PortSettings@name' in Connection '{connectionId}'.                                                                                                                                                    |
| 12.1.4  | CheckNameAttribute                                                | Untrimmed attribute 'Ports/PortSettings@name' in Connection '{connectionId}'. Current value '{attributeValue}'.                                                                                                              |
| 13.2.1  | CheckPathAttribute                                                | Attribute 'Relation@path' references a non-existing 'Table' with PID '{pid}'.                                                                                                                                                |
| 13.2.2  | CheckPathAttribute                                                | Missing attribute 'Relation@path'.                                                                                                                                                                                           |
| 13.2.3  | CheckPathAttribute                                                | Invalid value '{pathValue}' in attribute 'Relation@path'.                                                                                                                                                                    |
| 13.2.4  | CheckPathAttribute                                                | Empty attribute 'Relation@path'.                                                                                                                                                                                             |
| 16.1.1  | CheckDynamicIdAttribute                                           | Attribute 'dynamicId' references a non-existing 'Table' with PID '{tablePid}'. ParameterGroup ID '{parameterGroupId}'.                                                                                                       |
| 16.1.2  | CheckDynamicIdAttribute                                           | Invalid value '{attributeValue}' in attribute 'dynamicId'. ParameterGroup ID '{parameterGroupId}'.                                                                                                                           |
| 16.1.3  | CheckDynamicIdAttribute                                           | Empty attribute 'dynamicId' in ParameterGroup '{groupId}'.                                                                                                                                                                   |
| 17.1.1  | CheckTableAttribute                                               | Attribute 'ExportRule@table' references a non-existing 'Table' with PID '{pid}'.                                                                                                                                             |
| 17.1.2  | CheckTableAttribute                                               | Missing attribute 'ExportRule@table'.                                                                                                                                                                                        |
| 17.1.3  | CheckTableAttribute                                               | Invalid value '{tableValue}' in attribute 'ExportRule@table'.                                                                                                                                                                |
| 17.1.4  | CheckTableAttribute                                               | Empty attribute 'ExportRule@table'.                                                                                                                                                                                          |
| 19.1.1  | CheckNameAttribute                                                | Missing attribute 'PortSettings@name' in Connection '{connectionId}'.                                                                                                                                                        |
| 19.1.2  | CheckNameAttribute                                                | Empty attribute 'PortSettings@name' in Connection '{connectionId}'.                                                                                                                                                          |
| 19.1.3  | CheckNameAttribute                                                | Untrimmed attribute 'PortSettings@name' in Connection '{connectionId}'. Current value '{attributeValue}'.                                                                                                                    |

The following legacy Validator return codes have been removed:

- 1502
- 1503
- 1504
- 2503
- 2505
- 2517
- 2518
- 2519
- 2520
- 2521
- 2522
- 2965
- 5200
- 5201
- 5202

### XML Schema

#### UOM Schema: New units added \[ID_23740\]

The following units have been added to the UOM Schema:

- kvar (kilovolt ampere reactive)
- NanoCPUs (nano CPUs)

#### Automation Schema: Additional values for DMSScript.Exe.Param@type attribute \[ID_23952\]

The *DMSScript.Script.Exe.Param@type* attribute can now be set to the following additional values:

| Value       | Description |
|-------------|--------------------------|
| libraryName | The name of the library. |
| precompile  | Whether this C# action must be compiled as a library. Default: “false”. |
| scriptRef   | A reference to another library.<br> Format: The name of the Automation script, followed by a colon and the name of the library (e.g. ScriptName:LibraryName).<br> To refer to a library in the current Automation script, you can replace the name of the Automation script by the \[AutomationScriptName\] placeholder (e.g. “\[AutomationScriptName\]:MyCSharpAction”). |

#### Automation Schema: List of possible bit flags added to documentation tag of the DMSScript.Exe.Param@options attribute \[ID_23953\]

In the Automation Schema, the documentation tag of the *DMSScript.Exe.Param@options* attribute now contains a list of all hexadecimal bit flags that can be represented by the decimal value specified in that attribute:

- 0x000: None
- 0x008: Debug mode
- 0x010: AllowUndef
- 0x020: RequireInteractive
- 0x040: SupportsBackForward
- 0x080: SkipElementChecks
- 0x100: SavedFromCube
- 0x200: SkipInfoEventsSet
- 0x400: HasFindInteractiveClient

#### Protocol Schema: Key reference constraint added to overridePID attribute of Protocol.Display.Pages.Page.Visibility element \[ID_23959\]

In the Protocol Schema, a key reference constraint has been added to the *overridePID* attribute of the *Protocol.Display.Pages.Page.Visibility* element.

The Schema will now verify whether the value specified in that *overridePID* attribute refers to a parameter ID defined in the protocol.

#### Protocol Schema: Protocol.Topologies.Topology.Cell.Exposer@enabled is now a mandatory attribute \[ID_24377\]

In the Protocol Schema, the *enabled* attribute of the *Protocol.Topologies.Topology.Cell.Exposer* element is now a mandatory attribute.

### Class Library

#### DMS Monitors \[ID_24066\]

The new Monitor Extension methods provide stable logic to handle eventing. They encapsulate DataMiner subscriptions and handle all correct cleanup and stability guidelines, leaving a developer free to focus on what must happen when an event is triggered.

Currently, the supported methods provide the ability to monitor changes in the full DMS and trigger a C# method to run for:

- Standalone parameter value changes
- Table cell value changes
- Parameter alarm level changes
- Table cell alarm level changes
- Single element alarm changes
- Single element name changes
- All elements (DMS-level) alarm changes
- All elements (DMS-level) name changes

> [!NOTE]
> Class Library Monitors will only work in conjunction with DataMiner version 9.6.3 or higher.

#### New Rates namespace \[ID_24283\]

A new *Rates* namespace has been added. This namespace contains classes and methods that can be used to calculate all kind of rates, including bit rates for SNMP interface tables.

## Changes

### Enhancements

#### IDE - Function editor: Enhancements \[ID_23978\]

A number of enhancements have been made to the function editor:

- When you create a new function file by selecting *File \> New \> File \> General \> DataMiner \> DataMiner Function Template*, you now have to first specify the function file version (e.g. 1.0.0.1) and select the associated protocol XML file.
- When you add a function to a function file, or you edit an existing function, you can now select a profile and an entry point, and configure the interfaces.
- When you add a table to a page, you can now select which columns to include.

> [!NOTE]
> The XML editor now also features on-the-fly XML Schema validation when editing function XML files.

#### Class Library: Table cell subscriptions will now be established using the primary key \[ID_24456\]

Up to now, table cell subscriptions were established using the display key. From now on, they will be established using the primary key.

### Fixes

#### IDE: Problem when parsing MIB files \[ID_24266\]

In some cases, an error could occur when parsing a MIB file.

#### Class Library: element.IsStartupComplete method would throw an exception when executed on an element that had been stopped \[ID_24290\]

In some cases, the IDmsElement IsStartupComplete method would throw an exception when it was executed on an element that had been stopped.

#### Class Library: Problem when updating properties \[ID_24291\]

In some cases, it would not be possible to update properties that had a value equal to NULL.

#### Class Library: Problem when requesting an element with duplicate properties \[ID_24293\]

When an element was requested via IDms, in some cases, an exception could be thrown when the element had duplicate properties.

From now on, when an element has duplicate properties, no exception will be thrown, but an entry will be added to the *C:\\Skyline DataMiner\\Logging\\ClassLibrary.txt* log file.

#### Class Library: GetAlarmTemplates() and GetTrendTemplates() would not work when the protocol was a production protocol \[ID_24357\]

In some cases, it would not be possible to retrieve the alarm template or the trend template of a protocol via IDms when that protocol was a production protocol.

Also, the IDmsProtocol interface now has a new “ReferencedVersion” property.
