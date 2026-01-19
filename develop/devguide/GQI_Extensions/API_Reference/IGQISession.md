---
uid: GQI_IGQISession
---

# IGQISession interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface defines properties with information about the query session in which an extension instance is used.

Available from DataMiner 10.6.3/10.5.0 CU12/10.6.0 CU0 onwards.<!-- RN 44509 -->

## Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| Username | `string` | The username of the user that opened the current query session. This value identifies the user when connecting to SLNet and corresponds to the `DomainUserName` on the `IConnection` object. It can be used to perform security checks. |

