---
uid: General_Main_Release_10.4.0_CU21
---

# General Main Release 10.4.0 CU21 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU21](xref:Cube_Main_Release_10.4.0_CU21).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU21](xref:Web_apps_Main_Release_10.4.0_CU21).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLLogCollector: Memory dumps will be taken first & new option to skip the BPA tests [ID 43588]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Each time the *SLLogCollector* tool is run, by default, it will order the *Standalone BPA Executor* tool to execute all BPA tests available in the system. From now on, a checkbox will allow you to have those BPA tests skipped.

Also, when ordered to include memory dumps, up to now, the SLLogCollector tool would first run the BPA tests and collect all logging, and would then take the memory dumps. From now on, it will take the memory dumps first.

#### OPC communication is End of Life [ID 43785]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, OPC communication should no longer be used in DataMiner connectors. Instead, QActions should be used, for example like in the [Generic OPC Data Access](https://catalog.dataminer.services/details/f2642ea9-9eaa-42f3-880e-816470b06a61) connector.

#### Automation: Engine class now exposes the public property ScriptName [ID 43840]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the `Engine` class exposes the public property `ScriptName`.

This means that, in an Automation script, it will now be possible to retrieve the name of that script.

#### Email messages can now also be sent if recipients are only specified in the CC and/or BCC fields [ID 43844]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, an email message could only be sent if the recipients were specified in the *To* field.

From now on, it will also be possible to send email messages that only have recipients specified in the *CC* and/or *BCC* fields.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 43854]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

#### DataMiner upgrade: Enhanced warning when an upgrade package cannot be found [ID 43916]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when a DataMiner upgrade package could not be found, the following warning message would appear:

*"WARNING! Upgrade ID [guid] no longer exists"*

This message has now been replaced by the following one:

*"WARNING! Upgrade package with ID [guid] no longer exists"*

### Fixes

#### SLNet would wait too long before closing a connection [ID 43851]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In some rare cases, SLNet would incorrectly wait for 2 hours before closing a connection. As a result, SLNet and SLDataMiner would keep a large number of unused connections in memory for too long.

#### Timeout of queries against a Cassandra database was set incorrectly [ID 43912]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

The timeout of queries against a Cassandra database was set incorrectly. This timeout has now been set to 10 minutes.
