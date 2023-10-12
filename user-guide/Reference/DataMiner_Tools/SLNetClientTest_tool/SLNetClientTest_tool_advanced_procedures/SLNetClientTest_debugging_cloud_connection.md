---
uid: SLNetClientTest_debugging_cloud_connection
---

# Debugging the dataminer.services connection

When there is a problem with the connection to dataminer.services, you can debug this using the *CcaGateway* window in the SLNetClientTest tool. This is both possible when the DataMiner Agent is online or offline (from DataMiner 10.3.8/10.4.0 onwards<!-- RN 36611 -->).

## Accessing the CcaGateway window

When the DataMiner Agent is **online**:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *CcaGateway*.

When the DataMiner Agent is **offline**:

- Go to *Offline Tools* > *CcaGateway (offline)*.

## CcaGateway window UI

Below you can find an overview of the different fields in the CcaGateway window and how these can be used.

> [!CAUTION]
> The majority of these fields are only intended to be used by Skyline DevOps Engineers. Do not make any changes in this window unless you have been explicitly asked to do so by a Skyline DevOps Engineer.

![CcaGateway window](~/user-guide/images/CcaGatewayWindow.png)<br>
*CcaGateway window in DataMiner 10.3.8*

1. The *Request Info* box shows the status of the last request done using this window. This can be used to see potential errors in communication.

1. The *DCP Connect Endpoint* box shows the current connection endpoint used to make and maintain the cloud connection.

1. The *DCP Tunnel Endpoint* box shows the current endpoint used to make the tunnel connection.

1. The *DCP API Endpoint* box shows the current endpoint used to make API calls.

1. The *Load* button loads the current value in the *DCP Connect Endpoint*, *DCP Tunnel Endpoint*, and *DCP API Endpoint* fields.

1. The *Set* button should only be used by Skyline DevOps Engineers. It can be used to change the *DCP Connect Endpoint*, *DCP Tunnel Endpoint*, and *DCP API Endpoint* value to the value that is currently filled in in the corresponding boxes.

1. The *Get Global State* button retrieves the state of the dataminer.services connection and displays it in the box on the right. This can be useful to retrieve the cloud identity of your system, which may be needed for support.

1. The *Register DMS* button behaves the same way as the *Connect* button in DataMiner Cube. We strongly recommend using DataMiner Cube instead. See [Connecting to dataminer.services](xref:Connect_to_dataminer_services).

1. The *Unregister DMS* button removes the connection to dataminer.services and thereby disconnects your DMS from the cloud. **Do not use this option unless you are specifically asked by a Skyline DevOps engineer. This action cannot be undone.**

1. The *Renew Cloud Session* button refreshes the cloud session. However, we strongly recommend using the *Renew* button on the *Cloud* page in System Center for this instead (note that this is only displayed if the connection is not valid).

1. The *Validate Cloud Session* button checks the status of the current dataminer.services connection. You can also see this in Cube, where it is visualized by either a green checkmark or a red x.

1. The *Link Accounts Session* button is used to link a DataMiner account to a dataminer.services account. However, we recommend using the procedure detailed under [Linking your DataMiner and DCP account](xref:Linking_your_DataMiner_and_DCP_account) instead.

1. The *Get Node Info* button retrieves information on the CloudGateway installation. This button is now **deprecated**.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
