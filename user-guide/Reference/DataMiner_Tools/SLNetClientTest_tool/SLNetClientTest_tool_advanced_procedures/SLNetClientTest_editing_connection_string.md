---
uid: SLNetClientTest_editing_connection_string
---

# Editing the connection string between two DataMiner Agents

In most cases, when you add a DataMiner Agent to a DataMiner System, all other DataMiner Agents in the DataMiner System connect to it using its primary IP address. However, in case e.g. NAT (Network Address Translation) is being used, you may need to configure the connection strings by hand.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Edit Connection Uris.*

1. In the *Connection String Configuration* dialog box, right-click in the list, and select *Add New Destination*.

1. In the *Edit Connection String* dialog box, configure the following settings.

   - *From*: The DataMiner Agent from which will be connected.

   - *To*: The primary IP address of the DataMiner Agent to which will be connected.

     > [!NOTE]
     >
     > - For a DMA connecting to a Failover pair, this will be the virtual IP address of that destination pair. For a main Failover DMA connecting to its backup or vice versa, this will be the sync IP of that target machine.
     > - From DataMiner 10.0.0 CU15/10.1.0 CU4/10.1.7 onwards, wildcards are supported in this field. If there is no exact match, the connection string will be set for all matching destinations.

   - *Update All Connections To This Agent*: Select this option if you want to update all connection strings to the DataMiner Agent specified in *To*.

   - *New Connection String*: The IP address to be used when connecting to the DataMiner Agent specified in *To*. Syntax example: `http://[IP address to connect]:8004/SLNetService`.

     > [!NOTE]
     > From DataMiner 10.3.0/10.3.2 onwards, you can configure a gRPC connection string. To do so, provide the full URL including the API Gateway, for example `https://10.4.2.92/APIGateway`. You will need to do so for each DMA in the system.

   - *Username* and *password*: The credentials to implement this change, if necessary.

1. Click *OK* to save the configuration.

1. If no further connection strings need to be configured, click *Done*.

> [!NOTE]
> From DataMiner 10.0.0 CU15/10.1.0 CU4/10.1.7 onwards, if DataMiner fails to automatically detect the SLNet target port (via port 80 or 443), the connection attempt will continue on the default port 8004. To skip this auto-detection and immediately use the default port 8004, you can set the connection string to *auto://nodetect*. This can for instance be useful in case port 80 is blocked between the DMAs.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
