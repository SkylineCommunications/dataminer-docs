---
uid: KI_NATS_config_not_updated_after_adding_DMA
---

# NATS configuration not updated after adding DMA to DMS

## Affected versions

All DataMiner versions prior to 10.3.0 [CU12]/10.4.0 [CU0]/10.4.3.

In DataMiner 10.3.0 [CU11]/10.4.2, there is a higher chance that you might encounter this issue.

## Cause

When a DataMiner Agent is added to a DMS, a race condition can cause the in-memory DMS configuration to not be updated. As NATSCustodian uses this DMS configuration info to determine DMS changes, it does not see any changes and therefore does not trigger a reconfiguration of the NATS cluster.

## Workaround

Restart the DataMiner Agent you have added to the DMS. This will force a refresh of the cache, which will resolve this issue.

## Fix

Install DataMiner 10.3.0 [CU12], 10.4.0 [CU0], or 10.4.3.<!-- RN 38620 -->

## Description

When a DataMiner Agent is added to a DMS, the other DataMiner Agents of that DMS do not show up in the NATS configuration of the first DataMiner Agent. This may cause unexpected behavior, such as the DataMiner Agent not responding to specific triggers that require NATS communication with other Agents.

To check if you have indeed encountered this issue in a DMS, you can send a *GetInfoMessage(DmsConfiguration)* message to it with SLNetClientTest tool:

1. [Connect to the DMA you have added using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab.

1. In the *Message Type* drop-down list, select *GetInfoMessage*.

1. In the *Type* dropdown, select *DmsConfiguration*.

1. Click *Send Message*.

1. In the *Properties* tab, select the latest message, and then select the *Grid* tab on the right.

1. Expand *IPAddresses* and check if only the IP address of the added DMA is included in the list.

   If only that IP address is included, this indicates that this issue is most probably present.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
