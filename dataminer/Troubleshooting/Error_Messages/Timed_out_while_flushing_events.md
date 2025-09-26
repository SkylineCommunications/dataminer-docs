---
uid: Timed_out_while_flushing_events
---

# Timed out while flushing events from x. Outdated data might be displayed for this agent until the connection is refreshed

In a notice of this type:

- "x" is the name of the DataMiner agent for which events might be outdated.
- The agent on which the notice was created is the one where the stored events might be outdated.

## Symptom

Outdated events (e.g. alarm events or element states) might be displayed for the specified agent when viewed through the DataMiner agent where the notice was created.

## Possible cause

- Handling events is stuck or slow

## Resolution

Use the SLNetClientTest tool to connect to the agent where the notice was generated on.

Use *Diagnostics > SLNet > DropSLNetConnections* to trigger a reconnect with the other agents in the cluster.

The notice will automatically clear as part of reconnecting the agents.
