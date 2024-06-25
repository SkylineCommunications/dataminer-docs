---
uid: GQI_IGQILogger
---

# IGQILogger interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Contains functionality to log messages and exceptions. See [Logging](xref:GQI_Extensions_Logging) for more detailed information and a practical example of how the `IGQILogger` interface can be used.

Available from DataMiner 10.4.5/10.5.0 onwards.<!-- RN 39043 -->

## Properties

| Property | Type | Description |
|----------|------|-------------|
| MinimumLogLevel | [GQILogLevel](xref:GQI_GQILogLevel) | The minimum log level. Default: `GQILogLevel.Information` |

## Methods

> [!NOTE]
> The *IGQILogger* logger methods are inspired by [Serilog](https://github.com/serilog/serilog).

### void Verbose(string message)

Logs a message with the [GQILogLevel.Verbose](xref:GQI_GQILogLevel) level.

Should be used to output extensive information about a running block of code that is useful for thorough debugging but that should not be available in production.

### void Verbose(Exception exception, string message)

Logs a message with the [GQILogLevel.Verbose](xref:GQI_GQILogLevel) level.

Should be used to output extensive information about a running block of code that is useful for thorough debugging but that should not be available in production.

### void Debug(string message)

Logs a message with the [GQILogLevel.Debug](xref:GQI_GQILogLevel) level.

Should be used to log internal system events that aid in debugging and troubleshooting, providing insights into the application's execution flow.

### void Debug(Exception exception, string message)

Logs a message with the [GQILogLevel.Debug](xref:GQI_GQILogLevel) level.

Should be used to log internal system events that aid in debugging and troubleshooting, providing insights into the application's execution flow.

### void Information(string message)

Logs a message with the [GQILogLevel.Information](xref:GQI_GQILogLevel) level.

Should be used to record general operational messages to track the behavior of the application during runtime.

### void Information(Exception exception, string message)

Logs a message with the [GQILogLevel.Information](xref:GQI_GQILogLevel) level.

Should be used to record general operational messages to track the behavior of the application during runtime.

### void Warning(string message)

Logs a message with the [GQILogLevel.Warning](xref:GQI_GQILogLevel) level.

Should be used to log potential issues or situations that may require attention, indicating unexpected behavior without halting the application.

### void Warning(Exception exception, string message)

Logs a message with the [GQILogLevel.Warning](xref:GQI_GQILogLevel) level.

Should be used to log potential issues or situations that may require attention, indicating unexpected behavior without halting the application.

### void Error(string message)

Logs a message with the [GQILogLevel.Error](xref:GQI_GQILogLevel) level.

Should be used to record unexpected failures or malfunctions in the application, signaling issues that need to be addressed.

### void Error(Exception exception, string message)

Logs a message with the [GQILogLevel.Error](xref:GQI_GQILogLevel) level.

Should be used to record unexpected failures or malfunctions in the application, signaling issues that need to be addressed.

### void Fatal(string message)

Logs a message with the [GQILogLevel.Fatal](xref:GQI_GQILogLevel) level.

Should be used to log critical errors that result in the loss of essential functionality, requiring immediate action to resolve.

### void Fatal(Exception exception, string message)

Logs a message with the [GQILogLevel.Fatal](xref:GQI_GQILogLevel) level.

Should be used to log critical errors that result in the loss of essential functionality, requiring immediate action to resolve.
