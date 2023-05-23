---
uid: Connect_to_cloud_via_proxy
---

# Connecting to dataminer.services via proxy server

From DataMiner CloudFeed 1.0.6, CloudGateway 2.7.0, and ArtifactDeployer 1.4.1 onwards, proxy support is available for these DxMs. This means that you can enable a proxy server so that all outgoing traffic towards the public internet will pass through that proxy server.

Use the [Proxy Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) to install these modules on your proxy server.

The proxy server has to support both HTTP and WebSocket traffic.

> [!NOTE]
> Prior to CloudFeed 1.1.0, it was also necessary to configure the file `C:\ProgramData\Skyline Communications\DxMs Shared\appsettings.proxy.json` for this. However, CloudFeed 1.1.0 makes it possible to use CloudGateway as a proxy for the cloud connection, so that no more manual configuration is needed. If you want to connect via proxy server, you should therefore make sure you have CloudFeed 1.1.0 or higher installed.
