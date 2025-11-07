---
uid: General_Feature_Release_10.6.1
---

# General Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 43890] [ID 44035] [ID 44050] [ID 44062]](#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-43890-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.1](xref:Cube_Feature_Release_10.6.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.1](xref:Web_apps_Feature_Release_10.6.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43526] [ID 43856] [ID 43861] [ID 43890] [ID 44035] [ID 44050] [ID 44062]](#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-43890-id-44035-id-44050-id-44062)
- [Dashboard reports can now be generated in PDF, HTML, and/or CSV format [ID 43887]](#dashboard-reports-can-now-be-generated-in-pdf-html-andor-csv-format-id-43887)

## New features

#### DataMiner Objects Models: DomInstances CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects [ID 43852]

<!-- MR 10.6.0 - FR 10.6.1 -->

The `DomInstances` CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects. This will reduce the amount of data transferred and can significantly improve performance in cases where clients only need a few fields from each instance.

New `Read` and `PreparePaging` overloads will accept a `SelectedFields<DomInstance>` object. To select a field, add the exposer from `DomInstanceExposers` or add the `FieldDescriptorID` to the `SelectedFields<DomInstance>` object.

> [!NOTE]
>
> - The `Id` is always available on a `PartialObject`. You do not need to add the `Id` exposer to `SelectedFields<DomInstance>`.
> - Selecting the `FieldValues` or `FullObject` exposer is not supported and will result in a failed read operation.

The `Read` and `PreparePaging` methods will return a list of `PartialObject<DomInstance, DomInstanceId>`, which provides:

- `ID`: The `DomInstance` ID.
- `GetValue` and `TryGetValue`, which retrieve the value of a selected exposer or a single-value `FieldDescriptorID`.
- `GetValues` and `TryGetValues`, which retrieve a list of values for a selected `FieldDescriptorID` (for fields with multiple values, or when multiple sections are allowed).

When retrieving values, the following behavior will apply:

- **Multiple values**: Use `GetValues<T>`/`TryGetValues<T>` to obtain a `List<T>`. `GetValues<T>` throws `InvalidOperationException` if the values are not of type `T`; `TryGetValues<T>` returns `false` in that case.
- **Single value**: Use `GetValue<T>`/`TryGetValue<T>` for fields with a single value. `GetValue<T>` throws `InvalidOperationException` if the value is not of type `T` or when there are multiple values available for that field descriptor; `TryGetValue<T>` returns `false`.
- **No value**: `GetValue<T>` returns `default(T)` (equivalent to an empty list for list types). `TryGetValue<T>` returns `false`. `GetValues<T>` returns `null`. `TryGetValues<T>` returns `false`.

> [!IMPORTANT]
> A `FieldDescriptor` ID must be unique across section definitions in a DOM module.

#### Dashboard reports can now be generated in PDF, HTML, and/or CSV format [ID 43887]

<!-- MR 10.6.0 - FR 10.6.1 -->

Up to now, a report of a dashboard could only be generated in PDF format (.pdf). Now, it is possible to generate a report in PDF, archived HTML format (.mhtml) and/or CSV format.

MHTML files include all necessary information to allow the report to be rendered in a web browser: HTML code, images, CSS stylesheets, etc.

Also, the default file name has been changed from `Report.pdf` to `<dashboard name>.pdf`, `<dashboard name>.mhtml`, or `<dashboard name>.csv.zip`.

## Changes

### Enhancements

#### DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 43890] [ID 44035] [ID 44050] [ID 44062]

<!-- MR 10.6.0 - FR 10.6.1 -->

DataMiner Systems will now use the BrokerGateway-managed NATS solution by default. BrokerGateway will manage NATS communication based on a single source of truth that has the complete knowledge of the cluster, resulting in more robust, carefree NATS communication. In addition, TLS will be configured automatically, and a newer version of NATS will be used that has better performance and is easier to upgrade.

- During a DataMiner upgrade, the *VerifyBrokerGatewayMigration* prerequisite check will verify whether all DataMiner Agents in the cluster are using the BrokerGateway-managed NATS solution. If not, the check will fail, and the upgrade will not be able to continue.

- It will no longer be possible to migrate from the BrokerGateway-managed NATS solution (nats-server service) back to the legacy SLNet-managed NATS solution (NAS and NATS services).

- The *Verify NATS Migration Prerequisites* BPA test has now been removed. As from this DataMiner version, all DataMiner Systems are expected to use the BrokerGateway-managed NATS solution by default.

- DataMiner upgrades will no longer automatically install NAS and NATS.

- SLReset will now consider the BrokerGateway-managed NATS solution as the default solution, and will remove the `C:\Skyline DataMiner\NATS` folder (if present).

- SLLogCollector will no longer collect any data from the `C:\Skyline DataMiner\NATS` folder.

- In the *MaintenanceSettings.xml* file, the following tags will now be considered obsolete:

  - BrokerGateway
  - NATSDisasterCheck
  - NATSLogFileAmountToKeep
  - NATSLogFileCleanupMs
  - NATSResetWindow
  - NATSRestartTimeout

- DataMiner upgrade packages will no longer perform the *MigrateBrokerGatewaySoftLaunch* upgrade action. This action would move the BrokerGateway soft-launch option to the *MaintenanceSettings.xml* file.

- From now on, when an attempt is made to communicate using the legacy SLNet-managed NATS solution, the following exception will be thrown and logged:

  `Unable to find file. SLCloud configured messageBrokers are unsupported as of DataMiner 10.6.0.`

- NATSRepair.exe will no longer check if the *BrokerGateway* flag in *MaintenanceSettings.xml* is set to true.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

#### Automation: All methods that use parameter descriptions have now been marked as obsolete [ID 43948]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

All methods in the `Skyline.DataMiner.Automation` namespace that use parameter descriptions have now been marked as obsolete.

#### NATSRepair.exe can no longer be run when automatic NATS configuration is disabled [ID 44061]

<!-- MR 10.6.0 - FR 10.6.1 -->

From now on, it will no longer be possible to run *NATSRepair.exe* when automatic NATS configuration is disabled. If so, *NATSRepair.exe* will immediately stop without performing any actions.

See also: [Disabling automatic NATS configuration](xref:SLNetClientTest_disabling_automatic_nats_config)

#### DataMiner backup: Temp file will now be created on the target path instead of the C drive [ID 44063]

<!-- MR 10.6.0 - FR 10.6.1 -->

When a backup package was being created, up to now, the temporary file would be stored on the C drive. From now on, this temporary file will be stored on the target path (i.e. local path or network path).

> [!NOTE]
>
> - When DataMiner and Cassandra are installed on the same machine, and the Cassandra data directory is on the C drive, the temporary snapshot for Cassandra will be created in that data directory before it is added to the backup package on the target path. This is default Cassandra behavior. If you wish to avoid this, move the Cassandra data directory to another drive, or consider moving to STaaS or self-managed clustered storage as Cassandra Single is End of Engineering.
> - Backups for which only a network path has been specified may take a bit more time as the temporary file will now be created on that network path. Backups for which both a local path and a network path have been specified will not take longer as the temporary file will be created on the local path and then simply copied to the network path.

### Fixes

#### Service templates: Problem when parsing conditions to dynamically include or exclude child elements [ID 43120]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In some cases, conditional triggers to dynamically include or exclude child elements would be parsed incorrectly, especially when the first condition was a NOT clause.

#### SLElement could stop working when DVE elements were deleted [ID 43947]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when DVE elements were deleted while multiple DVE elements were having their state changed to deleted/stopped, in some cases, SLElement could stop working.

#### SLNet: Information messages triggered in a QAction would incorrectly only be forwarded to the DMA hosting the element in question [ID 43958]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a QAction triggered an information message with regard to a particular element, SLNet would incorrectly only forward that message to the DataMiner Agent that hosted that element. As a result, that information message would not appear in client applications connected to any of the other DataMiner Agents in the system.

#### Correlation alarms triggered by a correlation rule with the 'Auto clear' option set would not be cleared automatically [ID 43974]

<!-- MR 10.6.0 - FR 10.6.1 -->

When, in a correlation rule, a *New alarm* or an *Escalate event* action was configured with the *Auto clear* option set, in some cases, the new correlated alarms triggered by that correlation rule would incorrectly not be automatically cleared.

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.

#### Failover: 'C:\\Skyline DataMiner\\Elements' folder on offline Agents could unexpectedly be cleared [ID 44005]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In Failover clusters, in some rare cases where specific conditions related to DVE element handling and naming conflicts were met, the `C:\Skyline DataMiner\Elements` folder on offline Agents could unexpectedly be cleared, sometimes leaving no elements behind.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.
- Check the offline Agent's Recycle Bin for entries named "Element   deleted", indicating a deletion occurred without a known element name.

#### SLProtocol would silently fail to parse the Protocol.Advanced@stuffing attribute when its value contained spaces [ID 44010]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, SLProtocol would silently fail to parse the *stuffing* attribute of the *Protocol.Advanced* tag when its value contained spaces.

#### DataMiner backup would fail with an incorrect Elasticsearch error due to a Db.xml parsing issue [ID 44044]

<!-- MR 10.6.0 - FR 10.6.1 -->

Up to now, if the *Db.xml* file contained an invalid `<Database>` tag, a DataMiner backup procedure would fail with the incorrect error `An error occurred when dumping the elastic database`, even on systems that did not include an Elasticsearch database.

From now on, when an invalid `<Database>` tag is found in the *Db.xml* file during a DataMiner backup procedure, an `invalid tag` error will be logged and the backup procedure will continue without any exception being thrown.
