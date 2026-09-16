---
uid: GQI_IGQISession
---

# IGQISession interface

## [NuGet: Skyline.DataMiner.Core.GQI.Extensions](#tab/tabid-1)

### Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

This interface defines properties with information about the query session in which an extension instance is used.

> [!NOTE]
> From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, when using the [GQI DxM](xref:GQI_DxM), this type can be used to inject the session context via the constructor of a GQI extension.

### Properties

| Property | Type | Description | Version |
| -------- | ---- | ----------- | ------- |
| SessionId | `Guid` | The unique identifier of the current GQI session. | 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 <!-- RN 45635 --> |
| Username | `string` | The username of the user who opened the current query session. This value identifies the user when connecting to SLNet and corresponds to the `DomainUserName` on the `IConnection` object. It can be used to perform security checks. | 10.6.3/10.5.0 [CU12]/10.6.0 [CU0] <!-- RN 44509 --> |
| Culture | [`CultureInfo`](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo) | The culture of the user who opened the current query session. | 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 <!-- RN 45348 --> |
| TimeZone | [`TimeZoneInfo`](https://learn.microsoft.com/en-us/dotnet/api/system.timezoneinfo) | The time zone of the user who opened the current query session. | 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 <!-- RN 45348 --> |
| User | [IGQIUser](xref:GQI_IGQIUser) | The user context associated with the current GQI session. | 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 <!-- RN 45635 --> |

## [SLAnalyticsTypes](#tab/tabid-2)

### Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface defines properties with information about the query session in which an extension instance is used.

Available from DataMiner 10.5.0 [CU12]/10.6.3 onwards.<!-- RN 44509 -->

### Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| Username | `string` | The username of the user who opened the current query session. This value identifies the user when connecting to SLNet and corresponds to the `DomainUserName` on the `IConnection` object. It can be used to perform security checks. |

***
