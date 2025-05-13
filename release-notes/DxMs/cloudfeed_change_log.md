---
uid: cloudfeed_change_log
---

# Cloud Feed change log

#### 2 April 2025 - Fix - CloudFeed 1.4.4 - Problem during startup caused by inability to contact CloudGateway [ID 42599]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

When, during startup, CloudFeed was not able to contact CloudGateway, in some cases, it would stop working.

#### 28 August 2024 - Enhancement - CloudFeed 1.4.0 - More data will now be offloaded [ID 40413]

DataMiner CloudFeed has been upgraded. It now offloads alarm events, change point events, SRM events, element configuration events, and feedback events.

> [!IMPORTANT]
> From CloudFeed version 1.4.0 onwards, the minimum required DataMiner version is DataMiner 10.4.10.

#### 2 May 2024 - Enhancement - CloudFeed 1.3.1 - Upgrade to .NET 8 [ID 39033]

DataMiner CloudFeed has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 2 October 2023 - Enhancement - CloudFeed 1.3.0 - Upgrade to .NET 6 [ID 36940]

DataMiner CloudFeed has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

#### 22 August 2023 - Enhancement - CloudFeed 1.2.0 - Compatibility with newer DataMiner versions [ID 36482]

When you upgrade DataMiner to version 10.3.8/10.4.0 or later, CloudFeed should be upgraded to version 1.2.0 or later to ensure that alarm and change points events are processed correctly.

Also, a number of issues that could occur at CloudFeed startup have been fixed.

#### 17 May 2023 - Enhancement - CloudFeed 1.1.0 - Possibility for other processes to query the CloudFeed state [ID 35914]

Other DataMiner processes can now check the state of DataMiner CloudFeed. For now, DataMiner Cube will use this to check if the Relation Learning feature is available.

#### 17 May 2023 - Enhancement - CloudFeed 1.1.0 - CloudGateway as proxy for cloud connection [ID 35663]

The CloudFeed process can now use CloudGateway as a proxy for the cloud connection. This way, CloudFeed can be used on systems that are not allowed to have outbound connections to the cloud.

> [!NOTE]
> For this feature to work, traffic must be allowed via port 5100 on the internal network, and DataMiner CloudGateway 2.10.0 or higher must be installed.

#### 18 July 2022 - New feature - CloudFeed 1.0.6 - Proxy support [ID 33955]

Proxy support has been added for DataMiner CloudFeed. When you configure this, all outgoing traffic towards the public internet will pass through the proxy server.

The proxy settings are configured in a single settings file that is reused for all DxMs. This *appsettings.proxy.json* file is located in the `C:\ProgramData\Skyline Communications\DxMs Shared\` folder on the DMA. It should have the following content:

```json
{
   "ProxyOptions": {
      "Enabled": true,
      "Address": "<address of the proxy server>"
   }
}
```

When you have configured the file, you will need to restart the CloudFeed, CloudGateway, and ArtifactDeployer services for the changes to take effect.
