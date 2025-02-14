---
uid: VerifyNatsCluster
---

# NATS cluster verification

From DataMiner 10.5.4/10.5.0 [CU1], the *NATS cluster verification* prerequisite check is included in upgrade packages. It verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents. 
It also checks if communication between all NATS nodes is possible.
The same prerequisite will also be available as BPA.
This prevents situations where a DataMiner System becomes non-functional after an upgrade because of preexisting issues with NATS. If this check fails, please troubleshoot NATS before continuing the upgrade.

> [!TIP]
> For more information on how to troubleshoot NATS, see [Troubleshooting – NATS](xref:Investigating_NATS_Issues).