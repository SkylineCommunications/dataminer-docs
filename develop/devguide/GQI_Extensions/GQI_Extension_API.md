---
uid: GQI_Extension_API
---

# GQI extension API

In order to create a GQI extension, you use the GQI extension API. This API can be referenced in two ways:

- Via the `Skyline.DataMiner.Core.GQI.Extensions` NuGet package.
  - This is the recommended API when creating GQI extensions from DataMiner 10.6.6/10.5.0 [CU15]/10.6.0 [CU3] onwards<!-- RN 44760+45341 -->. Newer GQI features will only be supported by this API.
  - Requires DIS.
  - Package compatibility for a specific DataMiner version can be viewed on the [NuGet page](https://www.nuget.org/packages/Skyline.DataMiner.Core.GQI.Extensions).
  - Namespace: `Skyline.DataMiner.Core.GQI.Extensions.*`.

- Via the `Skyline.DataMiner.Files.SLAnalyticsTypes` NuGet package or SLAnalyticsTypes.dll assembly reference.
  - This is currently still the default API when using the DIS template. This API is end of life and does not support GQI features added from DataMiner 10.6.6/10.5.0 [CU15]/10.6.0 [CU3] onwards.
  - Namespace: `Skyline.DataMiner.Analytics.GenericInterface.*`.

> [!TIP]
> To ease the transition of extensions that were built against the legacy API, it is possible to combine both APIs within extension libraries and within extensions. If a data source is implemented with both the Core.GQI package and the legacy API, GQI uses the Core.GQI implementation when it is supported.
