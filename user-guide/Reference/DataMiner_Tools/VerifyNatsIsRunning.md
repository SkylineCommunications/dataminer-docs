---
uid: VerifyNatsIsRunning
---

# Verify NATS is Running

From DataMiner 10.2.7/10.2.0 [CU14] up to and including 10.5.3/10.5.0 [CU0], the *VerifyNatsIsRunning* prerequisite check is included in upgrade packages. It verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents. This prevents situations where a DataMiner System becomes non-functional after an upgrade because of preexisting issues with NATS. If this check fails, [troubleshoot NATS](xref:Investigating_NATS_Issues) before continuing the upgrade.

From DataMiner 10.5.4/10.5.0 [CU1] onwards, this check is replaced by the [Verify NATS Cluster](xref:VerifyNatsCluster) check.

> [!IMPORTANT]
> Upgrading from a version prior to Main Release Version 10.1.0 [CU12] or Feature Release Version 10.2.3 to DataMiner 10.2.7 might result in issues due to files changing between these releases. To avoid this, upgrade to Feature Release Version 10.2.8 [CU0] or any Main Release Version.
