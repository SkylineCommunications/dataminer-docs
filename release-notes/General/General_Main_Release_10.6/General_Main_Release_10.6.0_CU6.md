---
uid: General_Main_Release_10.6.0_CU6
---

# General Main Release 10.6.0 CU6 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU6](xref:Cube_Main_Release_10.6.0_CU6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU6](xref:Web_apps_Main_Release_10.6.0_CU6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43526] [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Main_Release_10.6.0_changes#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43526-id-43856-id-43861-id-44035-id-44050-id-44062)

## Changes

### Enhancements

#### DataAPI: Enhanced handling of element creations failing because another element with the same name already exists [ID 45643]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When DataAPI creates an element, in some cases, the element is not immediately fully synchronized in DataMiner. Subsequent requests then detect that an element with the same name already exists and fail, even though DataAPI itself created that element.

To determine whether DataAPI created an element, the request must confirm that it is genuinely the same element. Up to now, when a name collision occurred, the request would simply fail with no way to identify its own recently created element.

From now on, DataAPI will verify whether the existing element is one it created earlier by matching and tracking both the identifier and the type (i.e., the protocol). When both match, the request is allowed to proceed. If not, it is treated as a conflict and will be rejected.

#### ConfigureIIS.bat script will now ensure a dedicated Application Pool for the API application [ID 45842]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *ConfigureIIS.bat* script will now ensure a dedicated Application Pool for the API application. This will avoid needless restarts of the API when files running under the same DefaultAppPool would change inside WebPages.

This new application pool is called *DataMiner WebAPI AppPool*. it is solely intended to serve as pool for the web API, and will not recycle periodically.

### Fixes

#### Problem when using the 'Get parameter table by alias' data source against a STaaS database [ID 45766]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *Get parameter table by alias* data source retrieves a parameter table from the indexing database using the specified alias.

Up to now, this data source would only check whether the DataMiner System included an indexing database. It would not check the type of the database. As it currently only supports Elasticsearch and OpenSearch, up to now, exceptions would be thrown when it was used to retrieve data from a STaaS database.

From now on, the *Get parameter table by alias* data source will only be available when the DataMiner System includes an indexing database of type Elasticsearch or OpenSearch.

#### Automatic alarm grouping: Memory leak caused by alarm duplication on element restart [ID 45831]

<!-- MR 10.6.0 [CU6] - FR 10.6.9 -->

When an element was frequently stopped and restarted, up to now, alarms would accumulate as duplicates in the internal alarm grouping counters, causing a memory leak in the SLAnalytics process. Alarms would incorrectly not be removed from the element's alarm counter when the element stopped, and were re-added as new entries each time the element restarted.

From now on, alarms will be properly removed from the element alarm counter when an element stops. An additional safeguard has also been added to prevent duplicate alarm entries from being inserted into the counter if the same alarm tree already exists.
