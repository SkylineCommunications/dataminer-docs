---
uid: GQI_GQILogLevel
---

# GQILogLevel enum

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Specifies constants that define the log level used by [IGQILogger](xref:GQI_IGQILogger).

Available from DataMiner 10.4.5/10.5.0 onwards.<!-- RN 39043 -->

## Fields

| Field | Description |
|-------|-------------|
| Verbose     | Detailed information for debugging, usually not used in production. |
| Debug       | Internal system events for debugging and troubleshooting. |
| Information | General operational messages to track application behavior. |
| Warning     | Potential issues that may need attention. |
| Error       | Unexpected failures or malfunctions in the application. |
| Fatal       | Critical errors that require immediate action, often leading to application termination. |
