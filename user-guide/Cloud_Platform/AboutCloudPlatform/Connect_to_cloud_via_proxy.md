---
uid: Connect_to_cloud_via_proxy
---

# Connecting to dataminer.services via proxy server

From DataMiner CloudFeed 1.0.6, CloudGateway 2.7.0, and ArtifactDeployer 1.4.1 onwards, proxy support is available for these DxMs. This means that you can enable a proxy server so that all outgoing traffic towards the public internet will pass through that proxy server.

The proxy server has to support both HTTP and WebSocket traffic.

To configure this:

1. In the folder `C:\ProgramData\Skyline Communications\DxMs Shared\` on the DMA, configure the file *appsettings.proxy.json* as follows:

   ```json
   {
      "ProxyOptions": {
         "Enabled": true,
         "Address": "<the address of the proxy server>"
      }
   }
   ```

1. Restart the CloudFeed, CloudGateway, and ArtifactDeployer services for the changes to take effect.
