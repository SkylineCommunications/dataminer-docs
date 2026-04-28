---
uid: GQI_IGQISession
---

# IGQISession interface

## [NuGet: Skyline.DataMiner.Core.GQI.Extensions](#tab/tabid-1)

### Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

This interface defines properties with information about the query session in which an extension instance is used.

### Properties

| Property | Type | Description | Version |
| -------- | ---- | ----------- | ------- |
| Username | `string` | The username of the user that opened the current query session. This value identifies the user when connecting to SLNet and corresponds to the `DomainUserName` on the `IConnection` object. It can be used to perform security checks. | 10.6.3/10.5.0 [CU12]/10.6.0 [CU0] <!-- RN 44509 --> |
| Culture | [`CultureInfo`](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo) | The culture of the user that opened the current query session. | 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] <!-- RN 45348 -->
| TimeZone | [`TimeZoneInfo`](https://learn.microsoft.com/en-us/dotnet/api/system.timezoneinfo) | The timezone of the user that opened the current query session. | 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] <!-- RN 45348 --> |

## [SLAnalyticsTypes](#tab/tabid-2)

### Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface defines properties with information about the query session in which an extension instance is used.

Available from DataMiner 10.5.0 [CU12]/10.6.3 onwards.<!-- RN 44509 -->

### Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| Username | `string` | The username of the user that opened the current query session. This value identifies the user when connecting to SLNet and corresponds to the `DomainUserName` on the `IConnection` object. It can be used to perform security checks. |

***