---
uid: Connect_to_cloud_via_proxy
---

# Connecting to dataminer.services via proxy server

From DataMiner CloudFeed 1.0.6, CloudGateway 2.7.0, and ArtifactDeployer 1.4.1 onwards, proxy support is available for these DxMs. This means that you can enable a proxy server so that all outgoing traffic towards the public internet will pass through that proxy server. You can use the [Proxy Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) to install these modules on your proxy server.

The proxy server has to support both HTTP and WebSocket traffic.

To configure this:

1. [Connect to dataminer.services](xref:Connect_to_dataminer_services).

1. In the folder `C:\ProgramData\Skyline Communications\DxMs Shared\` on the DMA, configure the file *appsettings.proxy.json* as follows:

   ```json
   {
      "ProxyOptions": {
         "Enabled": true,
         "Address": "<the address of the proxy server>"
      }
   }
   ```

1. Restart the CloudGateway service for the changes to take effect.

   > [!NOTE]
   > If you are using a version of CloudFeed prior to 1.1.0 or a version of ArtifactDeployer prior to 1.4.5, you will need to restart these DxMs as well.