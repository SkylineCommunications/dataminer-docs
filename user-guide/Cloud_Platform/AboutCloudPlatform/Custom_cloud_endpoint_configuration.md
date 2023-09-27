---
uid: Custom_cloud_endpoint_configuration
---

# Customizing the dataminer.services endpoint configuration

From version 2.10.0 of the [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) DataMiner Extension Module (DxM) onwards, this DxM hosts an HTTP(S) endpoint that allows other [DxMs](xref:DataMinerExtensionModules) to communicate with dataminer.services via DataMiner CloudGateway in an efficient and secure way without the need for direct internet access.

This endpoint is required for some features, such as [Remote Log Collection](xref:RemoteLogCollection). It only allows traffic to *\*.dataminer.services*.

By default, the *CloudEndpointOptions* are configured to use port TCP 5100 as mentioned in [Overview of IP ports used in a DMS](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms).

You can **adjust or completely disable** this endpoint for each DataMiner CloudGateway by overriding the configuration:

1. On each server with [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) installed, in the folder `C:\Program Files\Skyline Communications\DataMiner CloudGateway`, create or adjust the override *appsettings.custom.json* with the following contents:

   ```json
   {
     "CloudEndpointOptions": {
       "Enabled": <true/false>, 
       "Port": <integer>
     }
   }
   ```
  
1. Restart DataMiner CloudGateway on each server for the changes to take effect.

> [!NOTE]
> Make sure that the configured ports are also open on the internal network, so other DataMiner Extension Modules can access these endpoints hosted in DataMiner CloudGateway.

> [!IMPORTANT]
> Disabling the dataminer.services endpoint for each DataMiner CloudGateway will also disable features that depend on this DxM, such as Remote Log Collection. DataMiner CloudGateway can only start if the configured port is available on the hosting server.
