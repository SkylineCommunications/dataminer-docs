---
uid: Maintaining_cloud_connection_when_restoring
---

# Maintaining the dataminer.services connection when restoring a DMA

When you restore a DataMiner Agent on a new server, you need to follow the steps below to make sure its connection to dataminer.services remains valid.

> [!NOTE]
> This procedure only applies for DataMiner Agents that are connected to dataminer.services. If your DMA is not connected yet, we highly recommend that you [connect to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) after the migration in order to gain access to additional DataMiner features.

1. Copy the contents of the folder `C:\ProgramData\Skyline Communications\DataMiner CloudGateway\Data\CcaGatewayPersisted` from the old server to the new server.

   The DataMiner Agent needs the data in this folder in order to maintain its connection to the cloud.

1. Shut down the old server.

   This is crucial to prevent conflicts or issues with the cloud connection.

1. Renew the session on the new server using the *Renew Cloud Session* button in the *CcaGateway* window of SLNetClientTest tool. See [Debugging the dataminer.services connection](xref:SLNetClientTest_debugging_cloud_connection).

   It is important that this happens after the old server is shut down, to ensure there is a valid connection and the session can be renewed. This step is particularly important in cases where the old server has refreshed its tokens after the *CcaPersistedData* folder was copied. By renewing the session on the new server after the old server is shut down, you can ensure that the new server has the most up-to-date tokens.
