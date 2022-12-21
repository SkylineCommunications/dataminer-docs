---
uid: General_Main_Release_10.0.0_CU22
---

# General Main Release 10.0.0 CU22 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_32125]

A number of security enhancements have been made.

##### SLElement: Enhanced performance when working with tables using the 'naming' or 'namingformat' option [ID_30973]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

Due to a number of enhancements, overall performance of SLElement has increased, especially when working with tables using the `naming` or `namingformat` option.

#### SLElement: Enhanced service impact calculation [ID_31163]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

A number of enhancements have been made to the service impact calculation in SLElement.

#### Enhanced performance when initializing elements that are included in multiple services [ID_31611]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

Due to a number of enhancements, overall performance has increased when initializing elements that are included in multiple services.

#### SLLogCollector: Process list will now also include processes of which the name starts with 'DataMiner' [ID_31883]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

The SLLogCollector tool will now also list all processes of which the name starts with "DataMiner". This will allow you to also take memory dumps of processes like "DataMiner CloudGateway", "DataMiner CoreGateway", "DataMiner FieldControl", "DataMinerCube", etc.

Also, an issue was fixed where duplicate entries would appear in the list after a DMA restart while the tool was open.

#### SLElement: Enhanced performance when processing partially included services [ID_32080]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

Due to a number of enhancements, overall performance of SLElement has increased when processing partially included services.

#### Updated BPA tests [ID_32102]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

The following BPA tests have been updated:

- Cassandra DB Size
- Check Antivirus DLLs

#### SLElement: Enhanced performance when processing alarms [ID_32111]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

Due to a number of enhancements, overall performance of SLElement has increased when processing alarms.

#### SLElement: Enhanced performance when working with DCF interfaces [ID_32126] [ID_32127]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

Due to a number of enhancements, overall performance of SLElement has increased when working with DCF interfaces.

#### SLElement: Enhanced performance when resolving table relationships [ID_32176]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU13]/10.2.0 [CU1] - Feature Release Version 10.2.4 -->

Due to a number of enhancements, overall performance of SLElement has increased when resolving table relationships.

#### Enhanced smart-serial client throughput [ID_32219]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

Due to a number of enhancements, the overall throughput of smart-serial clients has increased.

#### SNMPAgent: Enhanced error handling [ID_32276]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

A number of enhancements have been made to the SLSNMPAgent process, especially with regard to error handling.

#### DataMiner backups will now by default also include SSL certificates and EPMConfig.xml files [ID_32504]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU13]/10.2.0 [CU1] - Feature Release Version 10.2.4 -->

Full backups and configuration backups will now by default also include the `EPMConfig.xml` files and all certificates used by protocols for encrypted communication with devices.

#### DataMiner Cube - Correlation: Using hidden elements when creating correlation rules [ID_32510]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU13]/10.2.0 [CU1] - Feature Release Version 10.2.4 -->

When creating a correlation rule in the Correlation app, it is now possible to use a hidden element in both the *Alarm Filter* section and the *Rule Condition* section.

#### Enhanced performance when stopping SNMP elements [ID_32523]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU13]/10.2.0 [CU1] - Feature Release Version 10.2.4 -->

Due to a number of enhancements, overall performance has increased when stopping SNMP elements.

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

#### Parameter changes will now only be pushed from SLProtocol to SLElement when needed [ID_34047]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, parameter changes would always be pushed from SLProtocol to SLElement. From now, those changes will only be pushed from SLProtocol to SLElement when needed.

#### Enhanced logging of issues occurring when parsing a compliance cache file entry [ID_34212]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When an issue occurred when parsing a compliance cache file entry, up to now, a log entry of type "error" would be added to the SLDataMiner.txt log file.

From now on, when an issue occurs when parsing a compliance cache file entry, the following log entry of type "info" will be added to the SLDataMiner.txt log file instead:

```txt
Warning: <function> is unable to parse compliance cache file entry at line <line number>. <line content>
```

#### HTTP elements will now resend a request after receiving ERROR_WINHTTP_SECURE_FAILURE [ID_34644]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When an HTTP element received an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, up to now, it would go into timeout.

From now on, when an HTTP element receives an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, it will resend the request for a number of times, taking into account the number of retries specified in the element's port settings.

### Fixes

#### SLLogCollector could fail to take process dumps [ID_31213]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU10] - Feature Release Version 10.2.1 -->

In some rare cases, SLLogCollector could fail to take process dumps.

#### Problem with SLDataMiner when a trigger to reload service settings was delayed & memory leak in SLElement [ID_31711]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When a trigger to reload service settings was delayed, in some cases, a run-time error could occur in the service thread of SLDataMiner.

Also, SLElement could leak memory when services were configured with a delayed trigger or a redundancy condition that persisted for a period of time.

#### SLA: Problem when an update of an SLA setting coincided with a window change [ID_31750]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When an update of an SLA setting (e.g. *Base timestamp*, *Monitor span*, *Window size*, *Window Unit*, *Window type*, *Validity start* or *Validity end*) coincided with a window change, in some rare cases, the next window would incorrectly be taken instead of the window that triggered the change. This would cause calculations to incorrectly use a timestamp in the future.

#### SLElement: Problem with invalid parameter IDs in the Generic DVE Linker Table [ID_31805]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When creating resources, the *[Generic DVE Linker Table]* is used to link a row from the *[Generic DVE Table]* to any other table. Up to now, in some cases, invalid parameter IDs in the *[FK Table]* column would result in invalid relations being constructed in SLElement's memory.

From now on, the values from the *[FK Table]* will be checked against the protocol's parameters and a functioning link will only be made when a table with such a parameter ID exists in the element.

#### DataMiner Cube - Settings: Filtered alarm tabs configured to show active alarms and masked alarms would incorrectly only show active alarms [ID_31815]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When, in the *Settings* app, you had configured a filtered alarm tab to contain both active alarms and masked alarms, that alarm tab would incorrectly only show active alarms.

#### Scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed [ID_31877]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

In some cases, scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed.

#### Visual Overview: Hidden pages of an embedded Visio file would incorrectly be displayed when viewed in a web app [ID_31881]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When an embedded multi-page Visio file with hidden pages was viewed in a web app, the hidden pages would incorrectly be displayed.

#### DataMiner Cube - Visual Overview: DCF signal paths would not be visualized correctly on pages with a grid layout [ID_31888]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

In some cases, a DCF signal path would not be visualized correctly on Visio pages with a grid layout.

#### SLNet would thrown an 'Arithmetic operation resulted in an overflow' exception when performance information was being calculated [ID_31894]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

In some cases, SLNet would thrown an "Arithmetic operation resulted in an overflow" exception when performance information was being calculated.

#### Exported protocols would incorrectly have the same Protocol.Description and Protocol.Type as their parent protocol [ID_31904]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

Up to now, the *Protocol.Description* and *Protocol.Type* values in an exported protocol would incorrectly be identical to those of the parent protocol. From now on, the *Protocol.Description* and *Protocol.Type* elements of an exported protocol will contain the export name and the virtual type instead.

#### Problem when reading out a parameter or element latch [ID_31932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When DataMiner was started or when an element was started, in some cases, the following event could appear in the Windows event viewer:

```txt
Could not read element latch for DMAID/EID. 0x80131533
```

#### DataMiner Cube - Visual Overview: Trend graph would incorrectly not be loaded when clicking a trend icon [ID_31978]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When, in a visual overview that showed a table with trended columns, you opened a trend graph by clicking a trend icon, in some cases, the trend graph would incorrectly not be loaded and a "Trending is currently not enabled for this parameter" message would appear.

#### Failover: Initial file synchronization would incorrectly not be performed [ID_31991]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

When a standalone DataMiner Agent had been added to a Failover setup, in some cases, the initial file synchronization from online agent to offline agent would incorrectly not be performed.

#### Problem when creating separate SLScripting processes for every protocol being used [ID_32015]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

In the *DataMiner.xml* file, you can configure to have separate SLScripting processes created for every protocol being used. When this option was enabled, up to now, when SLScripting processes would crash, in some cases, they would either not get recreated or too many SLScripting processes would get created.

#### SoftLaunchOptions.xml would be parsed incorrectly [ID_32019]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version TBD -->

In some cases, the contents of the *SoftlaunchOptions.xml* file would be parsed incorrectly.

#### DataMiner Cube: Information templates could no longer be edited when connected to a DataMiner Agent installed on Windows Server 2016 [ID_32035]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

In DataMiner Cube, in some cases, it would no longer be possible to edit information templates; especially when connected to a DataMiner Agent installed on Windows Server 2016.

#### DataMiner Cube - Alarm Console: Alarms coming in while grouping or sorting an alarm tab would incorrectly not appear in that alarm tab [ID_32051]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU11] - Feature Release Version 10.2.2 -->

In some rare cases, alarms coming in while you were grouping or sorting the alarms on an alarm tab would incorrectly not appear on that alarm tab, especially on heavy-duty systems.

#### DataMiner Cube - Alarm Console: 'Audible alert' option was not saved correctly when an alarm tab was added to a workspace [ID_32191]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

When you undocked an alarm tab in which the *audible alert* option was selected, and then saved the workspace, the *audible alert* option would not be saved correctly.

#### DataMiner Cube - Alarm Console: Making an alarm tab show history alarms instead of active alarms would cause the name of the alarm tab to be updated incorrectly [ID_32215]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

When you created an "active alarms" tab for a certain object (element, service or view) by dropping that object onto the Alarm Console, and then made the tab show history alarms instead of active alarms, the automatically generated tab name was incorrectly set to "Alarms of the last 0 hours" instead of "~Last hour (up till X)".

#### DataMiner Cube - Alarm Console: Not possible to change the 'automatic incident tracking' option in an alarm tab that was enforced by group settings [ID_32218]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

In an alarm tab that was enforced by group settings, up to now, it would not be possible to change the *automatic incident tracking* option.

#### Problem with SLPort when stopping an element with a serial or smart-serial connection [ID_32221]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

In some cases, an error could occur in SLPort when an element with a serial or smart-serial connection was stopped.

#### Problem when retrieving trend data in the Monitoring app [ID_32366]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

In some cases, it was no longer possible to retrieve trend data in the Monitoring app due to a parsing problem in GetParameterResponseMessage and GetAlarmStateResponseMessage.

#### DataMiner Cube - Alarm Console: Newly created private alarm filter would not be automatically selected in the filter selection box [ID_32401]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

When, in the Alarm Console, you created a new private alarm filter, in some cases, that new filter would not automatically be selected after saving it. The filter selection box would incorrectly show "\<Click to select\>” instead of the name of the newly created filter.

#### DataMiner Cube - Alarm Console: Problem with 'new alarms' counter when alarms were grouped by service [ID_32427]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

When, in an alarm tab in which the alarms were grouped by service, an alarm affecting at least two services was cleared, then the *new alarms* counter in the tab header would show an incorrect number of alarms.

#### Alerter: Sound files not loaded correctly [ID_32431]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

In some cases, the sound files configured in Alerter could not be loaded correctly to the client, so that these no longer worked.

#### Not possible to create element with invalid XML character in name [ID_32455]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

In some cases, it was no longer possible to create elements with an invalid XML character in the element name, even if that character was supported in Cube (e.g. "&").

#### DataMiner Cube: Problem when accessing an information template, a trend template or an alarm template from within the Alarm Console [ID_32457]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU12] - Feature Release Version 10.2.3 -->

In the Alarm Console, you can right-click an alarm and select *Change > Information*, *Change > Trending* or *Change > Alarm range* to access the information template, the trend template or the alarm template for the parameter associated with the alarm. In some rare cases, you could only do so once. When you tried to access an information template, a trend template or an alarm template a second time by right-clicking *Change > Information*, *Change > Trending* or *Change > Alarm range*, a blank window would incorrectly appear.

#### SLProtocol would leak memory when using a 'change after response' trigger [ID_32572]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU13]/10.2.0 [CU1] - Feature Release Version 10.2.4 -->

When using a “change after response” trigger, SLProtocol would leak memory on every incoming response. See the following example.

```xml
<Trigger id="2">
    <On id="1">parameter</On>
    <Time>change after response</Time>
    <Type>action</Type>
    <Content>
        <Id>2</Id>
    </Content>
</Trigger>
```

#### QActionHelper DLL file could incorrectly be loaded twice [ID_32647]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU15]/10.2.0 [CU3] - Feature Release Version 10.2.6 -->

In some rare cases, protocols could incorrectly load the QActionHelper DLL file twice.

#### DataMiner Cube - Asset Manager: UI could become unresponsive when the database configuration was being retrieved [ID_32766]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU13]/10.2.0 [CU1] - Feature Release Version 10.2.4 -->

When, in DataMiner Cube, you opened the Asset Manager app, in some cases, the UI could become unresponsive when the database configuration was being retrieved.

#### Protocols: WebSocket ports incorrectly interpreted as HTTP ports [ID_33220]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU16]/10.2.0 [CU4] - Feature Release Version 10.2.7 -->

When you created an element with a protocol in which a WebSocket connection was configured as shown in the example below, up to now, the connection would incorrectly be interpreted as an HTTP port instead of a WebSocket port.

```xml
<Connections>
    <Connection id="0" name="WebSocket Interface">
        <Http>
            <CommunicationOptions>
                <WebSocket>true</WebSocket>
                <NotifyConnectionPIDs>
                    <Connections>6</Connections>
                </NotifyConnectionPIDs>
            </CommunicationOptions>
        </Http>
    </Connection>
</Connections>
```

#### Replicated main DVE element would incorrectly execute a sequence twice [ID_33270]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU16]/10.2.0 [CU4] - Feature Release Version 10.2.6 -->

When, inside a replicated DVE parent element, the exporting DVE table that contained the column with DVE element IDs also contained a column with a `<Sequence>`, then that sequence would incorrectly be executed twice on the replicated element.

#### Values in a decimal logger table column would lose their decimals when the element was restarted or the database was queried [ID_33315]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU16]/10.2.0 [CU4] - Feature Release Version 10.2.7 -->

When, in a logger table, a column with `<ColumnDefinition>DECIMAL</ColumnDefinition>` contained a value with decimals, then those decimals would be lost when the element was restarted or the database was queried.

#### Protocols: \<UserSettings\> element would not be taken into account when a new element was created [ID_33394]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU16]/10.2.0 [CU4] - Feature Release Version 10.2.7 -->

When a *protocol.xml* file using the latest `<Connections>` syntax contained a `<UserSettings>` element, the user settings specified in the `<UserSettings>` element would incorrectly not be taken into account when a new element was created.

#### Automation: SetParameterByPrimaryKey would fail to update a write-only parameter when using the parameter name as argument [ID_33511]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU16]/10.2.0 [CU4] - Feature Release Version 10.2.7 -->

When, from an Automation script, a write parameter in a column of a table inside an element was updated using a ScriptDummy.

SetParameterByPrimaryKey call with the parameter name as argument, the update would fail when that write parameter did not have a matching read parameter.

#### Problem when deleting a DVE child element or a virtual function [ID_33519]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU16]/10.2.0 [CU4] - Feature Release Version 10.2.7 -->

When a DVE child element or a virtual function was deleted, all data related to the main DVE element and the other DVE child elements and virtual functions would incorrectly also be deleted from the service cache. As a result, alarm updates would no longer affect the services.

#### Problem with SLElement when resolving foreign keys took a long time and the the element debug log level was equal to or higher than 1 [ID_33826]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the element debug log level was equal to or higher than 1, an error could occur in SLElement when resolving foreign keys took a long time.

#### SLSNMPManager: StackOverflow exception while trying to resolve the next Request ID [ID_33901]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, SLSNMPManager could throw a StackOverflow exception while trying to resolve the next Request ID.

#### Protocols: Additional connections with a “Type” defined would incorrectly be ignored [ID_33941]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU17]/10.2.0 [CU5] - Feature Release Version 10.2.8 [CU0] -->

Additional connections that had a `<Type>` defined would incorrectly no longer be taken into account.

In the following example, the second connection would incorrectly be ignored.

```xml
<Connections>
    <Connection id="0" name="HTTP Connection">
        <Type>http</Type>
        ...
    </Connection>
    <Connection id="1" name="WebSocket Interface">
        <Type>http</Type>
        ...
```

> [!NOTE]
> Specifying a type with `<Type>` for one connection and specifying a type with e.g. `<Http>` for another connection is not supported.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### Problem with SLProtocol when performing a 'replace data' action [ID_34255]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

In some cases, an error could occur in SLProtocol when performing a 'replace data' action that had to replace multiple bytes.

#### SNMP polling issues in case protocol contained wildcards in parameter OIDs [ID_34343]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 [CU1] -->

In some specific cases, wildcards in the parameter OIDs in a protocol caused polling to return no data. This only occurred when a parameter with a wildcard OID referred to another parameter that was not displayed.

#### SLSNMPManager: Trap binding of type 'IP Address' would incorrectly be parsed as an empty string [ID_34481]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a trap binding of type "IP Address" came in while the SLSNMPManager SNMPv3 process was processing traps on the default port 162, that binding would be incorrectly parsed as an empty string.

#### Not all data would be cleaned up after deleting elements in bulk on systems with a MySQL or Microsoft SQL Server database [ID_34542]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When, on systems with a MySQL or Microsoft SQL Server database, elements had been deleted in bulk (e.g. via an Automation script), in some cases, real-time trending, average trending, alarms, information events and certain reporter caching tables would incorrectly not be cleaned up.

#### Mediation protocols: 'Recursion detected in the mediation links tree' error [ID_34736]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When a mediation protocol contained a *Params.Param.Mediation.LinkTo* element that pointed to a protocol that had the same *ElementType* value as the one specified in the *baseFor* attribute of its *Protocol* element, then the following error would be logged in the *SLDataMiner.txt* log file:

```txt
Recursion detected in the mediation links tree
```

As this error was caused by an internal lookup issue that had no effect whatsoever with regard to mediation layer functionality, from now on, it will no longer be logged.

#### HTTP requests would incorrectly not be retried when WinHTTP threw a SEC_E_BUFFER_TOO_SMALL error [ID_34888]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When an HTTP request is sent, in some cases, WinHTTP can incorrectly throw a `SEC_E_BUFFER_TOO_SMALL` error when the server is using TLS 1.2.

From now on, when this error is thrown, DataMiner will retry the HTTP request the number of times specified for the HTTP connection in question.

#### Elements would not show up in client applications due to an incorrect credential library GUID stored in their Element.xml file [ID_34956]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

In some cases, an incorrect credential library GUID could get stored in the *Element.xml* file of certain elements. As a result, although they were active and working as expected, those elements would not get loaded into SLNet and would not show up in client applications such as DataMiner Cube.
