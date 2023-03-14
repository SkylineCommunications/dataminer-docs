---
uid: VerifyNatsIsRunning
---

# VerifyNatsIsRunning

Starting from DataMiner 10.2.7 Feature Release or 10.2.0 CU14 Main Release, a DataMiner upgrade package contains the *VerifyNatsIsRunning* prerequisite. It verifies whether the crucial *NATS* service used by DataMiner is running on all required DataMiner Agents. This prevents situations where a DataMiner System becomes non-functional after an upgrade because of pre-existing issues with *NATS*. If this check fails, please troubleshoot *NATS* before contuing to upgrade. Find more information on how to troubleshoot on the page [Investigating NATS Issues](xref:Investigating_NATS_Issues)

>[!IMPORTANT]
> Upgrading from a version before DataMiner 10.1.0 CU12 Main Release or DataMiner 10.2.3 Feature Release to DataMiner 10.2.7 Feature Release might cause issues due to files changing between these releases.
> To work around this, choose to upgrade to at least DataMiner 10.2.8 CU0 Feature Release or upgrade to any Main Release version.
