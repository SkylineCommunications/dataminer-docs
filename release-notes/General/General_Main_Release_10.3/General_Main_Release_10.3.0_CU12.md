---
uid: General_Main_Release_10.3.0_CU12
---

# General Main Release 10.3.0 CU12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLNetClientTest tool: Message builder now allows creating an instance of an abstract type or interface [ID_38236]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The message builder in the SLNetClientTest tool allows you to build SLNet messages from scratch, filling out values for the properties in `DMSMessage` objects.

Up to now, if these properties were for an abstract type or interface, it was not possible to fill out a value. From now on, it will be possible to select a concrete type, create an instance, and edit the properties of that object.

#### DataMiner upgrade: Enhanced robustness of MSI package installations [ID_38376]

<!-- MR 10.3.0 [CU12] - FR 10.4.2 [CU0] -->

Up to now, during a DataMiner upgrade, in some cases, MSI packages would fail to install and throw one of the following errors:

- `The Installer has insufficient privileges to access this directory: ...`
- `Service ... could not be installed. Verify that you have sufficient privileges to install system services.`

From now on, when one of the above-mentioned errors is thrown, it will no longer be necessary to restart the entire upgrade procedure. Instead, a retry will be attempted during the running upgrade.

### Fixes

#### DataMiner installer: Some modules would not get installed while performing a full installation of a new DMA [ID_37719]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when you ran the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, some modules would incorrectly not get installed as they were configured to only be installed when upgrading an existing DataMiner Agent.

From now on, when you run the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, all installation steps will be performed, including the upgrade actions.

#### DataMiner clients using a gRPC connection would not always detect a disconnect [ID_38215]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, DataMiner clients using a gRPC connection would not detect a disconnect.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.

#### Failover: NATS would incorrectly be reconfigured when both agents were offline [ID_38349]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When both agents in a Failover setup were offline, in some cases, they would incorrectly reconfigure the NATS settings.

#### Automation: Script object cleanup routine could cause an error to occur [ID_38370]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a script is executed in SLAutomation, a record is added to a *Running Scripts* list. If that script is executed synchronously, that record will be deleted once the script ends. However, if the script is executed asynchronously, the record will be deleted by a separate cleanup routine. This cleanup routine is triggered when another script has been executed or when you retrieve a list of all running scripts. When the cleanup routine is run, all records of the finished scripts are cleaned up.

In some rare cases, the above-mentioned cleanup routine was started too early, causing an error to occur in SLAutomation.
