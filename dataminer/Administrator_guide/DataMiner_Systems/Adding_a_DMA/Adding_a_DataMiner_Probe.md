---
uid: Adding_a_DataMiner_Probe
description: Add a DataMiner Probe to a cluster in the same way as a regular DMA, but select to add it as an external DataMiner Agent.
---

# Adding a DataMiner Probe as a node in a cluster

## Prerequisites

Verify the prerequisites listed under [Adding a node to a DataMiner cluster](xref:Adding_a_DataMiner_Agent_to_a_DataMiner_System).

## Procedure

To add a DataMiner Probe to a cluster, follow the same procedure as when you [add a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent), with one difference:

- In the *Add DataMiner Agent* pop-up window, select the checkbox *Add as an external DataMiner Agent*.

Note that given the special nature of DMPs, there are differences compared to regular DataMiner Agents:

- DMPs are only displayed in the *manage* tab of the *Agents* page. There it is possible to modify the settings or change the state of a DMP, like for any other Agent.

- If you click the client communication indicator in the top right corner of the Cube interface, DMPs are not displayed in the list of DMAs in the system.

- The client manages the connection to the DMP. If the connection cannot be set initially, you can try to reconnect until a stable connection has been made.
