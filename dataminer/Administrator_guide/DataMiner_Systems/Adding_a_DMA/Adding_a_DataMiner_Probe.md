---
uid: Adding_a_DataMiner_Probe
---

# Adding a DataMiner Probe

## Prerequisites

- Verify the prerequisites listed on [Adding a DataMiner Agent to a DataMiner System](xref:Adding_a_DataMiner_Agent_to_a_DataMiner_System).

## Procedure

To add a DataMiner Probe to a DMS, follow the same procedure as when you [add a DMA in Cube](xref:Adding_a_regular_DataMiner_Agent), with one difference:

- In the *Add DataMiner Agent* pop-up window, select the checkbox *Add as an external DataMiner Agent*.

Note that given the special nature of DMPs, there are differences compared to regular DataMiner Agents:

- DMPs are only displayed in the *manage* tab of the *Agents* page. There it is possible to modify the settings or change the state of a DMP, like for any other Agent.

- If you click the client communication indicator in the top right corner of the Cube interface, DMPs are not displayed in the list of DMAs in the system.

- The client manages the connection to the DMP. If the connection cannot be set initially, you can try to reconnect until a stable connection has been made.
