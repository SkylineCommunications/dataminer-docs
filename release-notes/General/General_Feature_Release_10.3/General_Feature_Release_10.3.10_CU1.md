---
uid: General_Feature_Release_10.3.10_CU1
---

# General Feature Release 10.3.10 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.10](xref:Cube_Feature_Release_10.3.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.10](xref:Web_apps_Feature_Release_10.3.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### STaaS: Enhanced performance when sending data to the cloud [ID_37141]

<!-- MR 10.4.0 - FR 10.3.10 [CU1] -->

Because of a number of enhancements, overall performance has increased when sending data to the cloud.

### Fixes

#### Problem when migrating average trend data from Cassandra Cluster to STaaS [ID_37410]

<!-- MR 10.4.0 - FR 10.3.10 [CU1] -->
<!-- Not added to MR 10.4.0 -->

When migrating data from a Cassandra Cluster setup to STaaS, average trend data would be migrated incorrectly.

#### STaaS: Problem when assigning/removing an alarm template to/from a DVE child element [ID_37443]

<!-- MR 10.4.0 - FR 10.3.10 [CU1] -->
<!-- Not added to MR 10.4.0 -->

On systems with *Storage as a Service*, the data would not get saved correctly when you assigned an alarm template to a DVE child element or when you removed an alarm template from a DVE child element.
