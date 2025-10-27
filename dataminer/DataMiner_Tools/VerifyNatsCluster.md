---
uid: VerifyNatsCluster
---

# Verify NATS Cluster

From DataMiner 10.5.0 [CU6]/10.5.9 onwards<!-- RN 42206 + 43359 -->, the *VerifyNatsCluster* prerequisite check is included in upgrade packages. It verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents and whether communication between all NATS nodes is possible.

The same prerequisite is also available as a BPA test in System Center. See [NATS cluster verification](xref:BPA_Check_Agent_Presence).

This prerequisite check prevents situations where a DataMiner System becomes non-functional after an upgrade because of pre-existing issues with NATS. If this check fails, [troubleshoot NATS](xref:Investigating_NATS_Issues) before continuing the upgrade.
