---
uid: General_Main_Release_10.4.0_CU15
---

# General Main Release 10.4.0 CU15

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU15](xref:Cube_Main_Release_10.4.0_CU15).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU15](xref:Web_apps_Main_Release_10.4.0_CU15).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced ClearAllKeys() function [ID 42368]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

Because of a number of enhancements, overall performance of the SLProtocol function `ClearAllKeys()` has increased.

#### MessageBroker: Enhanced performance when checking for local IP addresses [ID 42570]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

As the MessageBroker prefers to set up NATS connections using local IP addresses, up to now, it would request the local IP addresses from the DNS for every item in the list of NATS endpoints. From now on, it will request the local IP addresses from the DNS only once.

The IP addresses returned by the DNS will be cached for one minute only. This will prevent providing outdated information when connections have to be set up later on.

#### Cassandra Cluster: Enhanced performance when importing DELT packages [ID 42613]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

Because of a number of enhancements, overall performance has increased when importing DELT packages on systems with a database of type *Cassandra Cluster*, especially when those packages contain a large amount of trend data.

#### Additional SLNet log files [ID 42625]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

From now on, SLNet logging will not only be kept in the *SLNet.txt* log file. Certain entries will now also be kept in one of the following new log files, which will all be located in the `C:\Skyline DataMiner\Logging\SLNet\` folder.

| Log file | Contents |
|----------|----------|
| FacadeHandleMessage.txt | All SLNet log entries created by the `Facade.HandleMessage` method. |
| ReducedLog.txt          | All SLNet log entries that have not been added to any of the other new log files. |
| RepositoriesMessage.txt | All SLNet log entries created by the `SLNet.Repositories` method. |
| StartupLog.txt          | The first 1000 SLNet log entries added to the *SLNet.txt* log file after SLNet was started. |

> [!NOTE]
>
> - The existing *SLNet.txt* log file will remain unchanged.
> - Contrary to the *SLNet.txt* log file, which can have up to 3 rollover files (*[logfile]0.txt*), the above-mentioned new log files can only have one single rollover file each.

#### Enhanced performance when logging in using external authentication via SAML [ID 42668]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.5 [CU0] -->

Because of a number of enhancements, overall performance has increased when logging in using external authentication via SAML.

#### Protocols: Configuring an override parameter to replace the nominal smart baseline value of a column parameter [ID 42712]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In the [type](xref:Protocol.Params.Param.Alarm-type) attribute of the *Protocol.Params.Param.Alarm* tag, it is now possible to configure an override parameter for a column parameter.

If an override parameter is configured in the protocol, the smart baseline calculation will first check if a value is configured in the override parameter and if a value is present. If that value is not an exception value, it will take this value and copy it to the nominal value parameter instead of trying to calculate a nominal value whenever the smart baseline timer elapses.

To configure an override parameter, use the following syntax:

```xml
<Alarm type="absolute:NOMINAL_VALUE_PID,FACTOR_PID,OVERRIDE_PID">
```

> [!NOTE]
>
> - The `FACTOR_PID` is optional and can be left empty.
> - The ID of the override parameter (`OVERRIDE_PID`) is the third value in the comma-separated list. The `OVERRIDE_PID` value must be (a) the parameter ID of a column in the same table as the source column or (b) the parameter ID of a standalone column. Any other parameter ID will not work.

#### Security enhancements [ID 42747] [ID 42843]

<!-- 42747: MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 [CU0] -->
<!-- 42843: MR 10.3.0 [CU22]/10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 [CU0] -->

A number of security enhancements have been made.

### Fixes

#### Problem with SLProtocol when a protocol version was overwritten while an element using that protocol version was starting up [ID 42344]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When a protocol version was overwritten while an element using that protocol version was starting up, in some cases, the SLProtocol process could stop working. Also, this could result in alarms like the following being generated:

`Unexpected Exception [Exception from HRESULT: 0x8004024C]: The element is unknown.`

#### DataMiner not able to start up after installation [ID 42431]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

After installation, in some cases, DataMiner would not be able to start up because the *MessageBrokerConfig.json* file could not be found in the `C:\ProgramData\Skyline Communications\DataMiner\` folder.

#### Redundancy groups: Matrix parameter updates in a derived element would incorrectly not get applied in the source element (and vice versa) [ID 42598]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When, within a redundancy group, a matrix parameter in a derived element was updated, in some cases, that same matrix parameter would incorrectly not get updated in the source element (and vice versa).

#### SLHelper - GQI: Log entry of caught exception would incorrectly not include all details [ID 42608]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

On systems using the SLHelper process for GQI-related operations, up to now, an exception thrown when using a custom implementation of an ad hoc data source would be caught, but the log entry would incorrectly not include the full message. From now on, the log entry will include all details of the exception that was thrown.

#### Problem when starting an element with DCF connections towards a previously deleted element [ID 42632]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When an element that had DCF connections towards a previously deleted element was started, in some cases, an "unhandled exception" notice could appear in the Alarm Console. Also, as a result of the exception, the element's connection information would not be available in SLNet and DataMiner Cube, and no connection lines would be displayed for the connections in question.

#### SNMP forwarding: Inconsistent messages in alarm storm information events [ID 42642]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

SNMP managers generate an information event each time an alarm storm starts and ends.

Up to now, the word "SNMP manager" would not be spelled consistently in both messages. The information event announcing the start of an alarm storm would start with `Alarmstorm for SNMP Manager: ...`, while the information event announcing the end of an alarm storm would start with `Alarmstorm for SNMPManager: ...`

From now on, both information events will start with `Alarmstorm for SNMP Manager: ...`

#### Problem with trend windows after switching from daylight saving time to standard time [ID 42685]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some rare cases, trend windows could get stuck in SLDataGateway after switching from daylight saving time to standard time.

#### SLNet protocol cache would incorrectly retain the names of deleted protocols [ID 42710]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some rare cases, the SLNet protocol cache would incorrectly retain the names of deleted protocols.

#### 'Register DataMiner as Service.bat' would incorrectly register services as 32-bit services [ID 42713]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

In some cases, the Windows batch file *Register DataMiner as Service.bat* would incorrectly assume that a machine was running a 32-bit operating system. As a result, it would incorrectly register services as 32-bit services.

As 32-bit Windows systems are no longer supported, from now on, the *Register DataMiner as Service.bat* file will no longer check the architecture of the operating system.

#### Problem with Annotations module [ID 42777]

<!-- MR 10.4.0 [CU15] - FR TBD -->

When working with the *Annotations* module, in some cases, it would not be possible to edit annotations.

#### Antivirus software could incorrectly flag DcomConfig.exe as a virus and remove it from the system [ID 42979]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 [CU0] -->

Since DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5, some antivirus software could incorrectly flag `C:\Skyline DataMiner\tools\DcomConfig.exe` as a virus and remove it from the system. As a result, DataMiner upgrades would fail.
