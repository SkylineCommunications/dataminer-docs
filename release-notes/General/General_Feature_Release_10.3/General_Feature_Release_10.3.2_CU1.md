---
uid: General_Feature_Release_10.3.2_CU1
---

# General Feature Release 10.3.2 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.2](xref:Cube_Feature_Release_10.3.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Fixes

#### Web apps: Problem when executing a GQI query [ID_35539]

<!-- MR 10.3.0 [CU0] - FR 10.3.2 [CU1] -->

When a web app (e.g. Dashboards) tried to execute a GQI query, in some cases, a `Node: 'X' is not supported by the current server version.` error could be thrown (`'X'` being the node that caused the error).
