---
uid: General_Main_Release_10.4.0_CU14
---

# General Main Release 10.4.0 CU14 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU14](xref:Cube_Main_Release_10.4.0_CU14).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU14](xref:Web_apps_Main_Release_10.4.0_CU14).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 42307]

<!-- 42307: MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

A number of security enhancements have been made.

### Fixes

#### Mobile Visual Overview: Problem when the same mobile visual overview was requested by multiple users of the same user group [ID 41881]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.4 -->

When multiple users of the same user group requested the same mobile visual overview, in some rare cases, a separate DataMiner Cube instance would incorrectly be created on the DataMiner Agent for each of those users, potentially causing the creation of one Cube instance to block the creation of another Cube instance.

#### Problem with aggregation alarms on Cassandra Cluster and STaaS [ID 42095]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, aggregation alarms would not work as intended on DataMiner Systems using a Cassandra Cluster database or Storage as a Service (STaaS).

#### Mobile Visual Overview: Problem with SLHelper when removing mobile visual overview sessions [ID 42296]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When mobile visual overview sessions were removed from a DataMiner Agent, in some cases, the SLHelper process could temporarily block other requests.

#### GQI DxM: Problem when executing a query using ad hoc data sources with real-time updates enabled [ID 42310]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU1] - FR 10.5.4 -->

When a query using ad hoc data sources was executed with real-time updates enabled, up to now, the following message could incorrectly appear:

```txt
Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.
```
