---
uid: VerifyNatsIsRunning
---

# Verify NATS is Running

From DataMiner 10.2.7/10.2.0 [CU14] up to and including 10.5.0 [CU2]/10.5.5<!-- RN 42206 -->, the *VerifyNatsIsRunning* prerequisite check is included in upgrade packages. It verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents. This prevents situations where a DataMiner System becomes non-functional after an upgrade because of preexisting issues with NATS. If this check fails, [troubleshoot NATS](xref:Investigating_NATS_Issues) before continuing the upgrade.

If you have [migrated your system to BrokerGateway](xref:BrokerGateway_Migration), and the automatic NATS configuration has not been disabled (using [NATSForceManualConfig](xref:SLNetClientTest_disabling_automatic_nats_config)), this prerequisite check will verify if the single source of truth for the NATS communication (i.e. ClusterEndpointConfiguration.json) is present and contains at least one viable endpoint entry.<!-- RN 40641 -->

From DataMiner 10.5.0 [CU3]/10.5.6 onwards<!-- RN 42206 -->, this check is replaced by the [Verify NATS Cluster](xref:VerifyNatsCluster) check.

> [!TIP]
> For more information on how to troubleshoot NATS, see [Troubleshooting – NATS](xref:Investigating_NATS_Issues).

> [!IMPORTANT]
> Upgrading from a version prior to Main Release Version 10.1.0 [CU12] or Feature Release Version 10.2.3 to DataMiner 10.2.7 might result in issues due to files changing between these releases. To avoid this, upgrade to Feature Release Version 10.2.8 [CU0] or any Main Release Version.
