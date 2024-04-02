---
uid: GQI_Logging
---

# GQI logging

Logging for GQI is available from DataMiner 10.4.0/10.4.4 onwards.<!-- RN 38870 -->

Errors and warnings are logged to log files in the folder *C:\Skyline DataMiner\Logging\GQI*.

If this folder does not exist, it will be created automatically with the first log.

> [!NOTE]
> The logs are buffered and written asynchronously, so it may take a few seconds for them to appear in the file.

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

To change the minimum log level, change the configuration in the *appSettings* section in *C:\Skyline DataMiner\Files\SLHelper.exe.config*. For example:

```xml
<appSettings>
    ...
    <add key="serilog:minimum-level" value="Information" />
    ...
</appSettings>
```

> [!NOTE]
> Any changes to the configuration file are reset after a full DataMiner upgrade or downgrade.
