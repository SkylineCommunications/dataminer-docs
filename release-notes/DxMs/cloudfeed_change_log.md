---
uid: cloudfeed_change_log
---

# Cloud Feed change log

#### 2 October 2023 - Enhancement - CloudFeed 1.3.0 - Upgrade to .NET 6 [ID_36940]

DataMiner CloudFeed has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.


#### 22 August 2023 - Enhancement - CloudFeed 1.2.0 - Compatibility with newer DataMiner versions [ID_36482]

When you upgrade DataMiner to version 10.3.8/10.4.0 or later, CloudFeed should be upgraded to version 1.2.0 or later to ensure that alarm and change points events are processed correctly.

Also, a number of issues that could occur at CloudFeed startup have been fixed.


#### 17 May 2023 - Enhancement - CloudFeed 1.1.0 - Possibility for other processes to query the CloudFeed state [ID_35914]

Other DataMiner processes can now check the state of DataMiner CloudFeed. For now, DataMiner Cube will use this to check if the Relation Learning feature is available.


#### 17 May 2023 - Enhancement - CloudFeed 1.1.0 - CloudGateway as proxy for cloud connection [ID_35663]

The CloudFeed process can now use CloudGateway as a proxy for the cloud connection. This way, CloudFeed can be used on systems that are not allowed to have outbound connections to the cloud.

> [!NOTE]
> For this feature to work, traffic must be allowed via port 5100 on the internal network, and DataMiner CloudGateway 2.10.0 or higher must be installed.
