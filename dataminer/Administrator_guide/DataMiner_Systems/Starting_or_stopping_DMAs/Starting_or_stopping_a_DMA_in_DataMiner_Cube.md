---
uid: Starting_or_stopping_a_DMA_in_DataMiner_Cube
keywords: start, restart, shutdown
---

# Starting or stopping a DMA in DataMiner Cube

1. Go to *Apps* > *System Center* > *Agents.*

1. In the *Manage* tab, select the DataMiner Agent you want to (re)start or stop, and click one of the following buttons in the pane on the right:

   | Button  | Description                                                                       |
   |-----------|-----------------------------------------------------------------------------------|
   | Stop      | Stops the DataMiner software on the selected DataMiner Agent.                     |
   | (Re)start | Starts or restarts the DataMiner software on the selected DataMiner Agent.        |
   | Shut down  | Shuts down the server hosting the selected DataMiner Agent.                       |
   | Reboot    | Restarts the operating system of the server hosting the selected DataMiner Agent. |

> [!NOTE]
>
> - If you shut down a DMA, you will not be able to start it again by remote control. Someone will have to go where the server is located and start it manually.
> - On DataMiner Agents running recent Windows operating systems, the startup type of the DataMiner services is set to "Automatic (Delayed Start)" by default. This means that DataMiner waits until all Windows services are up and running before launching its own services.
> - If you are using a [DaaS system](xref:Creating_a_DMS_in_the_cloud), your DMS is fully hosted and maintained by Skyline Communications. As such, from DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40013-->, the *Stop*, *Shut down*, and *Reboot* buttons are no longer available for DaaS.
