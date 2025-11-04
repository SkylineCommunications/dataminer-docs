---
uid: General_Feature_Release_10.6.1
---

# General Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.1](xref:Cube_Feature_Release_10.6.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.1](xref:Web_apps_Feature_Release_10.6.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboard reports can now be generated in PDF, HTML, and/or CSV format [ID 43887]

<!-- MR 10.6.0 - FR 10.6.1 -->

Up to now, a report of a dashboard could only be generated in PDF format (.pdf). Now, it is possible to generate a report in PDF, archived HTML format (.mhtml) and/or CSV format.

MHTML files include all necessary information to allow the report to be rendered in a web browser: HTML code, images, CSS stylesheets, etc.

Also, the default file name has been changed from `Report.pdf` to `<dashboard name>.pdf`, `<dashboard name>.mhtml`, or `<dashboard name>.csv.zip`.

## Changes

### Enhancements

#### DataMiner Objects Models: DomInstances CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects [ID 43852]

<!-- MR 10.7.0 - FR 10.6.1 -->

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

#### DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43890] [ID 44050]

<!-- MR 10.6.0 - FR 10.6.1 -->

DataMiner Systems will now use the BrokerGateway-managed NATS solution by default. Also, it will no longer be possible to migrate from the BrokerGateway-managed NATS solution (nats-server service) back to the legacy SLNet-managed NATS solution (NAS and NATS services).

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

- From now on, when an attempt is made to communicate using the legacy SLNet-managed NATS solution, the following exception will be thrown and logged:

  `Unable to find file. SLCloud configured messageBrokers are unsupported as of DataMiner 10.6.0.`

- NATSRepair.exe will no longer check if the *BrokerGateway* flag in *MaintenanceSettings.xml* is set to true.

#### DataMiner upgrade: Prerequisite check 'VerifyBrokerGatewayMigration' will verify whether all DMS in the cluster are using the BrokerGateway-managed NATS solution [ID 43861]

<!-- MR 10.6.0 - FR 10.6.1 -->

During a DataMiner upgrade, the *VerifyBrokerGatewayMigration* prerequisite check will verify whether all DataMiner Agents in the cluster are using the BrokerGateway-managed NATS solution. If not, the check will fail, and the upgrade will not be able to continue.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

#### Automation: All methods that use parameter descriptions have now been marked as obsolete [ID 43948]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

All methods in the `Skyline.DataMiner.Automation` namespace that use parameter descriptions have now been marked as obsolete.

### Fixes

#### SLElement could stop working when DVE elements were deleted [ID 43947]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when DVE elements were deleted while multiple DVE elements were having their state changed to deleted/stopped, in some cases, SLElement could stop working.

#### SLNet: Information messages triggered in a QAction would incorrectly only be forwarded to the DMA hosting the element in question [ID 43958]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a QAction triggered an information message with regard to a particular element, SLNet would incorrectly only forward that message to the DataMiner Agent that hosted that element. As a result, that information message would not appear in client applications connected to any of the other DataMiner Agents in the system.

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.

#### Failover: 'C:\\Skyline DataMiner\\Elements' folder on offline Agents could unexpectedly be cleared [ID 44005]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In Failover clusters, in some rare cases where specific conditions related to DVE element handling and naming conflicts were met, the `C:\Skyline DataMiner\Elements` folder on offline Agents could unexpectedly be cleared, sometimes leaving no elements behind.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.
- Check the offline Agent's Recycle Bin for entries named "Element   deleted", indicating a deletion occurred without a known element name.
