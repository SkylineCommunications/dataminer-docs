---
uid: Flushing_in-flight_events
---

# Flushing in-flight events from x (DMA y) is taking a long time

In an error message of this type:

- "x" is the name of the DataMiner Agent for which handling of events is delayed.

- "y" is its DataMiner ID.

- The Agent on which the notice was created is the one experiencing the delay.

## Symptom

Delays in seeing data for the remote Agent while viewing through the Agent on which the notice was created.

## Possible cause

Handling events is stuck or slow.

## Resolution

The notice will automatically clear once waiting for the events completes or times out (see [Timed out while flushing events](xref:Timed_out_while_flushing_events)).
