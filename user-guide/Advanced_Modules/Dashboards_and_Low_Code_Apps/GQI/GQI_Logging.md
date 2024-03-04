---
uid: GQI_Logging
---

# GQI Logging

Logging for GQI is available from DataMiner 10.4.0/10.4.4 onwards.<!-- RN 38870 -->

Errors and warnings are logged to log files in the *C:\Skyline DataMiner\Logging\GQI* folder.
If this folder does not exist, it will be created automatically with the first log.

> [!NOTE]
> The logs are buffered and written asynchronously, so it may take a few seconds for them to appear in the file.

## Minimum log level

> [!TIP]
> You can lower the minimum log level to **Debug** to log more details that can be useful for technical support to investigate potential issues.

GQI uses *Serilog* to write the log files.
This logging framework defines 6 log levels:

1. Verbose
1. Debug
1. Information
1. Warning
1. Error
1. Fatal

The [minimum log level](https://github.com/serilog/serilog/wiki/Configuration-Basics#minimum-level) can be changed such that only logs for that level an up will be logged. By default the minimum log level is **Information**.

For GQI, this can be configured in the *appSettings* section in *C:\Skyline DataMiner\Files\SLHelper.exe.config*.

```xml
<appSettings>
    ...
    <add key="serilog:minimum-level" value="Information" />
    ...
</appSettings>
```

> [!NOTE]
> Any changes to the configuration file will be reset after an upgrade or downgrade.
