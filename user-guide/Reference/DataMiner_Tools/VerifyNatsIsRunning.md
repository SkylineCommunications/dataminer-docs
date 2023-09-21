---
uid: VerifyNatsIsRunning
---

# Verify NATS is Running

In DataMiner 10.2.7 and 10.2.0 [CU14], a prerequisite check is added to upgrade packages. It verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents. This prevents situations where a DataMiner System becomes non-functional after an upgrade because of preexisting issues with NATS. If this check fails, please troubleshoot NATS before continuing the upgrade.

> [!TIP]
> For more information on how to troubleshoot NATS, see [Investigating NATS Issues](xref:Investigating_NATS_Issues).

>[!IMPORTANT]
> Upgrading from a version prior to Main Release Version 10.1.0 [CU12] or Feature Release Version 10.2.3 to DataMiner 10.2.7 might result in issues due to files changing between these releases. To avoid this, upgrade to Feature Release Version 10.2.8 [CU0] or any Main Release Version.
