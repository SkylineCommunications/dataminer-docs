---
uid: GQI_Logging
---

# GQI logging

Logging for GQI is available from DataMiner 10.4.0/10.4.4 onwards.<!-- RN 38870 -->

Errors and warnings are logged to log files in the following folder:

- If the [GQI DxM](xref:GQI_DxM) is used: `C:\ProgramData\Skyline Communications\DataMiner GQI\Logs`
- If GQI runs in the SLHelper process: `C:\Skyline DataMiner\Logging\GQI`

If this folder does not exist, it will be created automatically with the first log.

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39355-->, information about SLNet requests is also logged to the log files in the logging folder, if the minimum log level is set to *Debug* or lower.

> [!NOTE]
> The logs are buffered and written asynchronously, so it may take a few seconds for them to appear in the file.

> [!TIP]
> For information about logging for ad hoc data sources and custom operators, see [GQI extensions logging](xref:GQI_Extensions_Logging).

## Metrics

From DataMiner 10.4.0 [CU3]/10.4.5 onwards<!-- RN 39098 -->, metrics such as the duration of individual GQI requests are also logged, in the following folder:

- If the [GQI DxM](xref:GQI_DxM) is used: `C:\ProgramData\Skyline Communications\DataMiner GQI\Metrics`
- If GQI runs in the SLHelper process: `C:\Skyline DataMiner\Logging\GQI\Metrics`

These can be used to investigate potential performance issues.

Currently, the following kinds of metrics are logged:

- **RequestDuration**: Measures the time between the arrival and resolution of any request that is handled by GQI. This can be helpful to trace issues in a specific time interval.
- **FirstPageDuration**: Measures the execution time for queries optimized for lazy loading. It measures the duration from the start of the retrieval of the first page until the moment when that first page is fully created. No metrics are logged for subsequent pages.
- **AllPagesDuration**: Measures the execution time for queries optimized to get all results at once. It measures the combined duration from the start of the retrieval of each page until the moment when that page is fully created.

> [!NOTE]
>
> - For the *FirstPageDuration* and *AllPagesDuration* metrics, a query identifier is logged that can be used to find the query source. For example, `"Query":"db/My Dashboard/f985ce2c-2b1d-4aff-81e7-8f81cfe01d6e"` indicates that the query originated from a dashboard called "My Dashboard" where a query is stored with that GUID.
> - For the sake of efficiency, timestamps for metrics are logged in Unix time, which is defined as the number of milliseconds since January 1st, 1970, at midnight (UTC). Converters can be found online.

## Minimum log level

GQI uses *Serilog* to write the log files. This logging framework defines six log levels:

1. Verbose
1. Debug
1. Information
1. Warning
1. Error
1. Fatal

The [minimum log level](https://github.com/serilog/serilog/wiki/Configuration-Basics#minimum-level) determines from which log level onwards logs are included in the log file. By default, the minimum log level is **Information**, so only logs of level Information, Warning, Error, and Fatal are included.

You can change the minimum log level to include less or more information in the log file. For example, to investigate potential issues, it can be useful to lower the minimum log level to *Debug*.

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39355-->, when you change the minimum log level to *Debug* or lower, information about requests sent to SLNet is also logged.

### Changing the minimum log level

Below, you can find how to change the log level for the GQI logic itself. For GQI in SLHelper, this also sets the default minimum log level for GQI extensions. See [GQI extension logging](xref:GQI_Extensions_Logging#changing-the-minimum-log-level) for more details on how to change the minimum log level for extensions for the GQI DxM.

#### [GQI DxM](#tab/gqi-dxm)

In the [app settings](xref:GQI_DxM#configuration), add the following:

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Debug",
      "Override": {
        "Microsoft": "Information",
      }
    }
  }
}
```

#### [GQI in SLHelper](#tab/gqi-slhelper)

Change the configuration in the *appSettings* section in `C:\Skyline DataMiner\Files\SLHelper.exe.config`. For example:

```xml
<appSettings>
    ...
    <add key="serilog:minimum-level" value="Information" />
    ...
</appSettings>
```

> [!IMPORTANT]
> Prior to DataMiner 10.4.6/10.5.0, a change to the minimum log level requires an SLHelper restart. From DataMiner 10.4.6/10.5.0 onwards<!--RN 39309-->, it is no longer necessary to restart SLHelper. The change takes effect immediately upon saving the *SLHelper.exe.config* file.

For some requests, from DataMiner 10.4.0 [CU3]/10.4.5 onwards<!-- RN 39098 -->, the query name is included in the logging. However, if you set the minimum log level to *Debug*, the full query is logged instead.

> [!NOTE]
> Any changes to the configuration file *SLHelper.exe.config* are reset after a full DataMiner upgrade or downgrade.

***
