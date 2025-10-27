---
uid: Timed_out_while_flushing_events
---

# Timed out while flushing events from x. Outdated data might be displayed for this Agent until the connection is refreshed

In a notice of this type:

- "x" is the name of the DataMiner Agent for which events might be outdated.
- The Agent on which the notice was created is the one where the stored events might be outdated.

## Symptom

Outdated events (e.g. alarm events or element states) might be displayed for the specified Agent when viewed through the DataMiner Agent on which the notice was created.

## Possible cause

Handling events is stuck or slow.

## Resolution

1. Use the SLNetClientTest tool to connect to the Agent on which the notice was generated.

   See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Use *Diagnostics* > *SLNet* > *DropSLNetConnections* to trigger a reconnection with the other Agents in the cluster.

   As part of this reconnection, the notice will automatically be cleared.
