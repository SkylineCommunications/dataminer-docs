---
uid: Starting_a_restored_DataMiner_Agent_in_a_cluster
---

# Starting a restored DataMiner Agent in a cluster

If you have restored a DMA in a cluster without using the Taskbar Utility, or if you have restored a DMA in a cluster to a new blank DataMiner Agent instead of restoring an existing Agent, you will need to follow the procedure below to start the DMA and add it to the DMS.

## Starting the DMA

1. Either shut down the original server, or disconnect it from the network.

1. If necessary, change the IP address and the computer name of the new server. If you wish, you can use the same IP address and/or computer name as the original server. However, this is not required by the DataMiner software.

1. Connect the new server to the network.

1. Make sure that *DMS.xml* has been deleted from the directory `C:\Skyline DataMiner\`.

1. Start the DataMiner software.

## Adding the restored DMA to the DMS

Follow the procedure for [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent).

At the end of this procedure, DataMiner will start synchronizing with the other DMAs. This process could take a while. The progress can be followed in the *Information Events* tab of the Alarm Console.
