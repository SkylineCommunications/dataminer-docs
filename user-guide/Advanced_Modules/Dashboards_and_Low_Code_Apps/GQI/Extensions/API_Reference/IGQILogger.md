---
uid: GQI_IGQILogger
---

# IGQILogger interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Contains functionality to log messages and exceptions. The log files will be placed within the `C:\Skyline DataMiner\Logging\GQI\Extensions` folder.

## Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| MinimumLogLevel | GQILogLevel | Set or get the current minimum log level. The default value is `Information`. |

GQILogLevel exposes the following log levels:
- **Verbose**: Detailed information for debugging, usually not used in production.
- **Debug**: Internal system events for debugging and troubleshooting.
- **Information**: General operational messages to track application behavior.
- **Warning** Indicates potential issues that may need attention.
- **Error**: Signals unexpected failures or malfunctions in the application.
- **Fatal**: Critical errors requiring immediate action, often leading to application termination.

## Methods

> [!NOTE]
> The IGQILogger logger methods are inspired by [Serilog](https://github.com/serilog/serilog).

### void Verbose(string message)

Outputs extensive information about a running block of code, useful for thorough debugging but typically disabled in production to avoid excessive logging.

### void Verbose(Exception exception, string message)

Outputs extensive information about a running block of code, useful for thorough debugging but typically disabled in production to avoid excessive logging.

### void Debug(string message)

Logs internal system events that aid in debugging and troubleshooting, providing insights into the application's execution flow.

### void Debug(Exception exception, string message)

Logs internal system events that aid in debugging and troubleshooting, providing insights into the application's execution flow.

### void Information(string message)

Records general operational messages to track the behavior of the application during runtime.

### void Information(Exception exception, string message)

Records general operational messages to track the behavior of the application during runtime.

### void Warning(string message)

Logs potential issues or situations that may require attention, indicating unexpected behavior without halting the application.

### void Warning(Exception exception, string message)

Logs potential issues or situations that may require attention, indicating unexpected behavior without halting the application.

### void Error(string message)

Records unexpected failures or malfunctions in the application, signaling issues that need to be addressed.

### void Error(Exception exception, string message)

Records unexpected failures or malfunctions in the application, signaling issues that need to be addressed.

### void Fatal(string message)

Logs critical errors that result in the termination of the application or loss of essential functionality, requiring immediate action to resolve.

### void Fatal(Exception exception, string message)

Logs critical errors that result in the termination of the application or loss of essential functionality, requiring immediate action to resolve.
