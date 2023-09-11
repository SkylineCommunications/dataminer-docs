---
uid: General_Feature_Release_10.3.9_CU2
---

# General Feature Release 10.3.9 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.9](xref:Cube_Feature_Release_10.3.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.9](xref:Web_apps_Feature_Release_10.3.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Fixes

#### Failover: NATS servers would incorrectly use the virtual IP address of a Failover setup to establish the route to the online agent [ID_37073]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 [CU2] -->

When the NATS server builds the route connections to the agents in a Failover setup, in some cases, when establishing the route to the online agent, it used the virtual IP address of the Failover setup instead of the primary address of the online agent.

From now on, *NATS Custodian* will check whether the routes list contains any virtual IP addresses. If so, it will replace each virtual IP address with the correct primary address of the online agent when performing the NATS configuration checks. However, it will not restart NATS.
