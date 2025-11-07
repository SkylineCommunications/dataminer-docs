---
uid: General_Main_Release_10.5.0_CU9
---

# General Main Release 10.5.0 CU9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU9](xref:Cube_Main_Release_10.5.0_CU9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU9](xref:Web_apps_Main_Release_10.5.0_CU9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLLogCollector: Memory dumps will be taken first & new option to skip the BPA tests [ID 43588]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Each time the *SLLogCollector* tool is run, by default, it will order the *Standalone BPA Executor* tool to execute all BPA tests available in the system. From now on, a checkbox will allow you to have those BPA tests skipped.

Also, when ordered to include memory dumps, up to now, the SLLogCollector tool would first run the BPA tests and collect all logging, and would then take the memory dumps. From now on, it will take the memory dumps first.

#### Swarming: Clearer error message when file contents cannot be retrieved [ID 43774]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When, during a swarming operation, a file cannot be loaded, from now on, a clearer error message will be logged. The message will now include the reason of the failure, and, if the error occurred because the file was locked, the process locking the file will also be mentioned.

Also:

- If SLDataMiner is unable to load a certain file, it will shut down gracefully, and the DataMiner Agent will be stopped.
- If a process other than SLDataMiner is unable to load a certain file, then it will retry loading the file 10 times, and if, after all those retries, it is still not able to load the file, it will stop trying, and retry again when it needs to send a request to the storage module.

#### NATSMigration tool will now also check for outdated DLL files in the ProtocolScripts folder [ID 43778]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the *NATSMigration* tool will also check for outdated DLL files in the `C:\Skyline DataMiner\ProtocolScripts` folder.

When an outdated DLL file is found, the migration will be aborted. For the migration to succeed, the user will have to remove the outdated DLL file and update the protocol in question.

#### OPC communication is End of Life [ID 43785]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, OPC communication should no longer be used in DataMiner connectors. Instead, QActions should be used, for example like in the [Generic OPC Data Access](https://catalog.dataminer.services/details/f2642ea9-9eaa-42f3-880e-816470b06a61) connector.

#### Automation: Engine class now exposes the public property ScriptName [ID 43840]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the `Engine` class exposes the public property `ScriptName`.

This means that, in an Automation script, it will now be possible to retrieve the name of that script.

#### PDF reports configured in the Dashboards app can now also be sent if recipients are only specified in the CC and/or BCC fields [ID 43844]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, an PDF report configured in the Dashboards app could only be sent if recipients were specified in the *To* field.

From now on, it will also be possible to send PDF reports if recipients are only specified in the *CC* and/or *BCC* fields.

> [!NOTE]
> Currently, PDF reports configured in DataMiner Cube still require recipients to be specified in the *To* field.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 43854]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

#### SLDMS: Broadcast event DMS_INVALIDATE_HOSTING_AGENT_CACHE has been removed [ID 43896]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when the SLDMS process had updated its local hosting agent cache information about an element, service, or redundancy group, it would publish a DMS_INVALIDATE_HOSTING_AGENT_CACHE request across the cluster so that other agents could also update this information.

This redundant broadcast event has now been removed.

#### DataMiner upgrade: Enhanced warning when an upgrade package cannot be found [ID 43916]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when a DataMiner upgrade package could not be found, the following warning message would appear:

*"WARNING! Upgrade ID [guid] no longer exists"*

This message has now been replaced by the following one:

*"WARNING! Upgrade package with ID [guid] no longer exists"*

#### NATSMigration tool will now log clearer HTTP errors when it is not able to connect to BrokerGateway [ID 43931]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When the *NATSMigration* tool is not able to connect to BrokerGateway, it will now add clearer HTTP errors to the error log.

#### DxMs upgraded [ID 43961]

<!-- RN 43961: MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner Orchestrator 1.8.0

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### QActions: Variables will now also be logged when a NotifyProtocol call fails [ID 43967]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When SLScripting executes a NotifyProtocol call, this can potentially lead to issues in SLProtocol when the variables are not in the correct format. Entries like `NotifyProtocol with xxx failed. 0x800xxxxx` can then appear in the error logging.

As entries like the one mentioned above make it hard to investigate exactly why a NotifyProtocol call has failed, from now on, these log entries will also include the values of the variables that were used in the NotifyProtocol call.

> [!NOTE]
> When a NotifyProtocol call returns a `0x800706BA, RPC_S_SERVER_UNAVAILABLE` error, that means that the SLProtocol process was not active and that the NotifyProtocol call was not the cause of the issue. Therefore, the values of the variables will not be included with this specific error is thrown.

#### BrokerGateway uninstall will delete the entire C:\\ProgramData\\Skyline Communications\\DataMiner BrokerGateway\\ folder [ID 43985]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

From now on, when BrokerGateway is uninstalled, the entire `C:\ProgramData\Skyline Communications\DataMiner BrokerGateway\` folder will be deleted.

### Fixes

#### Parameter or DCF information would become unavailable to remotely hosted elements after a DataMiner connection had been re-established [ID 43765]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

After a DataMiner connection had been re-established (due to e.g. a network issue, a failover switch, etc.), in some rare cases, an issue could occur that would cause parameter or DCF information to be unavailable to remotely hosted elements.

#### MessageBroker client could get stuck while trying to fetch information from BrokerGateway [ID 43832]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When, on systems using the BrokerGateway-managed NATS solution, BrokerGateway is not running the local DataMiner Agent, the MessageBroker client could get stuck while trying to fetch information from BrokerGateway.

#### SLNet would wait too long before closing a connection [ID 43851]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In some rare cases, SLNet would incorrectly wait for 2 hours before closing a connection. As a result, SLNet and SLDataMiner would keep a large number of unused connections in memory for too long.

#### Events would be generated with incorrect hosting agent information [ID 43862]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When elements were swarmed or migrated via a DELT package, in some cases, events would not be generated with the correct hosting agent information.

#### BrokerGateway would incorrectly be allowed to make automatic changes to the appsettings.runtime.json file when HasManualConfig was set to true [ID 43893]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When BrokerGateway could not find any local IP address in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json` configuration file, up to now, it would incorrectly add a local IP address to that file, even when the `HasManualConfig` setting was set to true.

From now on, when the `HasManualConfig` setting is set to true, BrokerGateway will not be allowed to make any automatic changes to the `appsettings.runtime.json` configuration file.

#### Timeout of queries against a Cassandra database was set incorrectly [ID 43912]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

The timeout of queries against a Cassandra database was set incorrectly. This timeout has now been set to 10 minutes.

#### Visual Overview in web apps: Cube running as a service within SLHelper would not load the common server settings from ClientSettings.json [ID 43941]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when DataMiner Cube was running as a service within the SLHelper process, it would not load the common server settings from `C:\Skyline DataMiner\users\ClientSettings.json` when it is unable to retrieve its own user settings.

From now on, regardless of whether DataMiner Cube can retrieve its own user settings, it will load the common server settings from `C:\Skyline DataMiner\users\ClientSettings.json`.

#### Notices regarding incorrect baseline values would no longer be generated when an element was started after being swarmed or migrated [ID 43970]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When an element that had been swarmed or migrated by means of a DELT package was started up, up to now, the following notices would no longer be generated when incorrect baseline values were found:

- `The fixed value (%g) is invalid. It is lower than nominal value (%g), and in the higher range. This value will not be used for alarm creation.`
- `The fixed value (%g) is invalid. It is higher than nominal value (%g), and in the lower range. This value will not be used for alarm creation.`

These notices will now be generated again.

#### Automation script matrix actions related to swarmed or migrated elements could fail [ID 43971]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, after elements had been swarmed or migrated by means of a DELT package, in some cases, Automation script matrix actions associated with those elements could fail.
