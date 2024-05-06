---
uid: GQI_Logging
---

# GQI logging

Logging for GQI is available from DataMiner 10.4.0/10.4.4 onwards.<!-- RN 38870 -->

Errors and warnings are logged to log files in the folder `C:\Skyline DataMiner\Logging\GQI`.

If this folder does not exist, it will be created automatically with the first log.

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39355-->, [information about SLNet requests](#log-entries-related-to-slnet-requests) is also logged to the log files in the `C:\Skyline DataMiner\Logging\GQI` folder, if the minimum log level is set to *Debug* or lower.

From DataMiner 10.4.0 [CU3]/10.4.5 onwards, metrics such as the duration of individual GQI requests are also logged, in the folder `C:\Skyline DataMiner\Logging\GQI\Metrics`.

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

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39355-->, when you change the minimum log level to *Debug* or lower, information about requests sent to SLNet is also logged. See [Log entries related to SLNet requests](#log-entries-related-to-slnet-requests).

To change the minimum log level, change the configuration in the *appSettings* section in *C:\Skyline DataMiner\Files\SLHelper.exe.config*. For example:

```xml
<appSettings>
    ...
    <add key="serilog:minimum-level" value="Information" />
    ...
</appSettings>
```

For some requests, from DataMiner 10.4.0 [CU3]/10.4.5 onwards, the query name is included in the logging. However, if you set the minimum log level to *Debug*, the full query is logged instead.

> [!NOTE]
> Any changes to the configuration file are reset after a full DataMiner upgrade or downgrade.

## Log entries related to SLNet requests

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39355-->, when you set the [minimum log level](#minimum-log-level) to *Debug* or lower, information about requests sent to SLNet is also logged.

The types of log entries related to SLNet requests include:

- `Started SLNet request <RequestID> with <MessageCount> messages`

  This type of entry will be added to the log when GQI starts a request to SLNet, before the messages included in the request are sent.

  - *RequestID*: A unique ID that will allow you to find all log entries associated with one particular SLNet request.

  - *MessageCount*: The number of SLNet messages included in the request.

- `Sending SLNet message <RequestID>.<Index>: <Description>`

  This type of entry will be added to the log for each individual message in an SLNet request.

  - *RequestID.Index*: The unique ID of the message, consisting of the *RequestID* (which identifies the request) and an *Index* (i.e. the sequence number of the message).

  - *Description*: The string representation of the actual SLNet message, which should give a short but meaningful description of the message.

- `Finished SLNet request <RequestID> in <Duration>ms`

  This type of entry will be added to the log when GQI finishes a request to SLNet, regardless of whether the request was successful or not.

  - *RequestID*: The unique ID of request.

  - *Duration*: The duration of the request, including the time it took for GQI to process it (in milliseconds).
