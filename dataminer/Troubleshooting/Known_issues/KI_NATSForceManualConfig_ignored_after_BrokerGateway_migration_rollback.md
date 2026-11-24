---
uid: KI_NATSForceManualConfig_ignored_after_BrokerGateway_migration_rollback
description: Learn why the NATSForceManualConfig setting can be ignored after a failed BrokerGateway migration is rolled back, and how to work around this.
---

# NATSForceManualConfig ignored after BrokerGateway migration rollback

## Affected versions

From DataMiner 10.5.0 [CU1]/10.5.4 onwards.

## Cause

When a BrokerGateway migration is rolled back, the BrokerGateway flag is switched back to `false`. NATSCustodian then resets the NATS configuration without checking `NATSForceManualConfig`. As a result, an automatically generated NATS configuration may end up mixed together with the original manual configuration, causing the central brokers to reject them.

## Fix

No fix is available yet. <!-- Task 312586 -->

## Workaround

Before you start a BrokerGateway migration, preferably save a backup of `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config` on **every DataMiner Agent in the cluster**. If the migration is rolled back, you can then restore this backup on each Agent and restart NATS.

If no backup is available, do the following on **every DataMiner Agent in the cluster**:

1. Remove the routes from `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`.

1. Restart NATS.

> [!TIP]
> Start with one Agent and check that the issue is resolved there before applying the workaround to the other Agents.

In some cases, the DataMiner Agents may also need to be restarted.

## Description

This issue can occur in a DataMiner System where `NATSForceManualConfig` is set to `true` and a [BrokerGateway migration](xref:BrokerGateway_Migration) failed and was rolled back to the old NATS setup.

In that case, the following symptoms may occur:

- Creating a new element fails with the error "Unable to save the element on the DMA".

- Runtime errors occur in SLASPConnection.

- Certain NATS nodes cannot communicate with each other.

- SLDataMiner reports "NATS connection closed while sending this request".

- The NATS log keeps showing "remote leafnode has same cluster name".

