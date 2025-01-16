---
uid: General_Feature_Release_10.5.3
---

# General Feature Release 10.5.3 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.3](xref:Cube_Feature_Release_10.5.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.3](xref:Web_apps_Feature_Release_10.5.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Enhanced error and exception handling when updating or clearing correlation alarms [ID 41675]

<!-- MR 10.5.0 - FR 10.5.3 -->

Error and exception handling has been enhanced in order to prevent duplicate or sticky correlation alarms due to errors or exceptions thrown when updating or clearing correlation alarms.

#### Amazon Keyspaces Service is now end-of-life [ID 41874]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 -->

Support for Amazon Keyspaces Service is now officially end-of-life.

We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. If you want to use self-hosted storage, install a [Cassandra Cluster](xref:Cassandra_database) database.

For more information, see [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)

#### SLLogCollector now collects data regarding the GQI DxM [ID 41880]

<!-- MR 10.5.0 - FR 10.5.3 -->

SLLogCollector packages now include the following data regarding the GQI DxM:

- *appsettings.json*
- Log file
- Version

#### SLLogCollector packages now also contain the ClusterEndpoints.json file [ID 41887]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

SLLogCollector packages now also include the *ClusterEndpoints.json* file.

### Fixes

#### Elements no longer visible after having been swarmed [ID 41635]

<!-- MR 10.5.0 - FR 10.5.3 -->
<!-- Not added to MR 10.5.0 -->

In some rare cases, when an element had been swarmed, it would no longer be visible in client apps like DataMiner Cube.

#### Missing DATAMINER_NOTIFICATION_QUEUE thread [ID 41699]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner was restarted, an issue could occur, causing the DATAMINER_NOTIFICATION_QUEUE thread not to be registered in processes like SLDMS, SLElement or SLDataGateway. These missing threads could then lead to a number of symptoms like empty element data cards or not being able to swarm back elements.

#### Problem with incorrect virtual element states [ID 41705]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some rare cases, the element state of a DVE or Virtual Function element would end up incorrect in the SLNet cache, causing some caches to not be initialized correctly.

#### Service & Resource Management: Problem when a previously deleted booking was created again [ID 41718]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a previously deleted booking was created again with the same ID, up to now, that booking would incorrectly not be retrieved.

#### GQI: Min and Max aggregation of a datetime column would incorrectly result in a number column [ID 41789]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, when a Min or Max aggregation was performed on a datetime column, the aggregated column would incorrectly be a number column instead of datetime column.

#### Uploading the same version of a DVE connector twice would incorrectly cause the production version of DVE child elements to be changed [ID 41798]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When the same version of a DVE connector was uploaded twice, the production version of all DVE child elements using another version of that connector as production version would incorrectly have their production version set to the newly uploaded version.
