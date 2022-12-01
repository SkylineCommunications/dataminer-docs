---
uid: Custom_cloud_endpoint_configuration
---

# Customizing the cloud endpoint configuration

From [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) 2.9.6 onwards, an HTTP(S) endpoint will be hosted in this module. 
This allows other [DataMiner Extension Modules](xref:DataMinerExtensionModules#dataminer-extension-modules-dxms) to communicate with the cloud via the [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) in an efficient and secure way without needing direct internet access. 

This endpoint is required for some features like for example [Remote Log Collection](xref:RemoteLogCollection#RemoteLogCollection), so that log files can be uploaded towards the cloud. 

Note this endpoint only allows traffic to _*.dataminer.services_, which you can see in the default _CloudEndpointOptions_ configuration under _FirewallRules_.

By default, the _CloudEndpointOptions_ are configured to use port tcp/5100 as mentioned in [Overview of IP ports used in a DMS](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms).
This endpoint can be adjusted or completely disabled for each [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) by overriding the configuration as shown below. Note that disabling the cloud endpoint on all CloudGateways also directly results in disabling the functionality of features like [Remote Log Collection](xref:RemoteLogCollection#RemoteLogCollection), as an example. In order for the module to start, the configured port must be available on the hosting server.

Make sure that the configured ports also are open on the internal network, so other DxMs can access these endpoints hosted in the CloudGateways. 

1. On each server with [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) installed, in the folder `C:\Program Files\Skyline Communications\DataMiner CloudGateway`, create or adjust the override *appsettings.custom.json* with the following contents:

  ```json
  {
    "CloudEndpointOptions": {
      "Enabled": <true/false>, 
      "Port": <integer>
    }
  }
  ```
  
2. Restart the CloudGateway service for the changes to take effect.
