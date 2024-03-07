---
uid: Dashboards_and_Low_Code_Apps_Logging
---

# Logging

The logging for Dashboards and Low Code Apps is located in `C:\Skyline DataMiner\Logging\Web`. There are two distinct types of logging, each serving specific purposes:

- WebAPI logging

- Client metric logging (available from DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards)

## WebAPI logging

This category of logging records various events occurring within the WebAPI. Depending on the configuration, different types of logs can be enabled or disabled:

- Debug logging provides information about various actions taken when handling a request from a client. It captures details about connections, unexpected errors, and so forth.

- Allowed operation logging is utilized to record information about requests permitted or blocked by the Web Application Firewall (WAF) of a shared dashboard. It offers insights into unexpectedly blocked calls. It also logs information about WAF rules that take a long time to execute.

> [!NOTE]
> This type of logging is available starting from DataMiner 10.2.0/10.1.8 onwards.

## Client metric logging

Client metric logging is employed to record different performance and issue indicators of clients connecting to Dashboards and Low Code Apps. These logs encompass everything from unexpected errors to the load time of a dashboard or LCA page. This logging data is stored in the `client` subfolder of the web logs.

> [!NOTE]
> This type of logging is available starting from DataMiner 10.3.0[CU14]/10.4.0[CU2]/10.4.5 onwards.

## Configuration

Both types of logging can be configured through a shared configuration file named `log.conf`, located in the root folder of the web logs. This file comprises various customizable settings:

| Setting Name                  | Setting Type | Default Value        | Description                                                                                                                      |
| ----------------------------- | ------------ | -------------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| EnableDebugLogging            | Boolean      | false                | Enables or disables the logging of debug information.                                                                            |
| EnableAllowedOperationLogging | Boolean      | false                | Enables or disables the logging of WAF information.                                                                              |
| EnableClientMetricLogging     | Boolean      | true                 | Enables or disables the logging of client. This in available from DataMiner 10.3.0[CU14]/10.4.0[CU2]/10.4.5 onwards. metrics.                                                                               |
| MaxFileSize                   | Number       | 52428800 (50MB)      | Maximum size of a single log file.                                                                                               |
| FilesToKeep                   | Number       | 14                   | Number of files to keep for each type of log.                                                                                    |
| RollingInterval               | String       | Day                  | Time period included in each log file.                                                                                           |
| AsyncBufferSize               | Number       | 10000                | Size of the buffer of the worker writing the log file to disk.                                                                   |
| BlockWhenAsyncBufferIsFull    | Boolean      | false                | If true, the logger will wait until there is room in the buffer; otherwise, log entries will be dropped when the buffer is full. |
| HealthCheckInterval           | Number       | 2500                 | Number of log entries before a health check of the logger is performed.                                                          |
| FlushToDiskInterval           | Timespan     | 00:00:01             | Timespan between the log being written to memory and the result being flushed to disk.                                           |
| Filename                      | String       | web.log              | Filename of the WebAPI log files.                                                                                                |
| ClientMetricFilename          | String       | web.clientmetric.log | Filename of the client metric log files.                                                                                         |

> [!NOTE]
> Before DataMiner 10.1.12/10.2.0, the config file was named `SLWAF.conf`.
