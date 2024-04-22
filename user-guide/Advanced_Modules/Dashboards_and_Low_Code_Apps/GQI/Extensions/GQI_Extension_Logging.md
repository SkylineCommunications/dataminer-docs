---
uid: GQI_Extensions_Logging
---

# Logging in GQI extensions

From DataMiner 10.4.5/10.5.0 onwards<!-- RN 39043 -->, GQI extensions like Ad Hoc data sources and custom operators can log there own messages in addition to the [GQI core logging](xref:GQI_Logging).

## How to log

In order to log messages from within an Ad Hoc data source or custom operator, the extension needs to implement the [IGQIOnInit](xref:GQI_IGQIOnInit) interface. This building block adds the [OnInit](xref:GQI_IGQIOnInit#oninitoutputargs-oninitoninitinputargs-args) lifecycle method that gives access to the [IGQILogger](xref:GQI_IGQILogger) object via the [Logger property](xref:GQI_OnInitInputArgs#properties) on the [OnInitInputArgs](xref:GQI_OnInitInputArgs).

The [IGQILogger](xref:GQI_IGQILogger) object can then be used throughout the lifetime of the extension to log messages and exceptions. See the [example](#example) on how this can be done.

## Where to find the logs

A new log file will be created for every extension in their respective subfolder:

- For Ad hoc data sources: *C:\Skyline DataMiner\Logging\GQI\Ad hoc data sources*
- For custom operators: *C:\Skyline DataMiner\Logging\GQI\Custom operators*

The log file name is formatted as *Script_Library_Type.txt*.

## The log format

The log format is:

```log
[Timestamp Level] [Session] [Node] Message
```

A concrete example could be:

```log
[1993-02-21 12:34:56.789 WRN] [c6a3d4bf] [71ba5588] This is an important warning!
```

It consists of these distinct parts:

- **Timestamp**: the moment when the message is logged formatted as *yyyy-MM-dd HH:mm:ss.fff*.
- **Level**: abbreviation of the [log level](xref:GQI_GQILogLevel).
- **Session**: an identifier for the current query session of the extension instance. Can be used to differentiate logs from operators that are used in multiple, possibly concurrent query sessions.
- **Node**: an identifier for the query node of the extension instance. Can be used to differentiate logs from operators that are used more than once in the same query.
- **Message**: any message that GQI or the extension wants to log.

> [!NOTE]
> Whenever an extension instance accesses the logger property, the current GQI user will be logged immediately to give additional context that is otherwise not available for individual log messages. You can see this in the logs of the [example](#example).

## Example

The following example illustrates a simple Custom operator that logs every cell value of a given column.

:::code language="csharp" source="./SLC-GQIO-LogCellValues.cs":::

When Kevin, a user in our system, applies the operator to the following data:

| Row key | Color |
| ------- | ----- |
| 1 | Alizarin |
| 2 | Burgundy |
| 3 | Carmine |

and selects the *Color* column as argument, we can find these logs in *C:\Skyline DataMiner\Logging\GQI\Custom operators\ExampleScript_ExampleLibrary_LogOperator.txt*:

```log
[2024-04-22 10:19:13.143 INF] [c6a3d4bf] [71ba5588] Logs for user Kevin
[2024-04-22 10:19:13.143 INF] [c6a3d4bf] [71ba5588] Column to log: Color
[2024-04-22 10:19:13.184 DBG] [c6a3d4bf] [71ba5588] Value for '1' is 'Alizarin'
[2024-04-22 10:19:13.188 DBG] [c6a3d4bf] [71ba5588] Value for '2' is 'Burgundy'
[2024-04-22 10:19:13.189 DBG] [c6a3d4bf] [71ba5588] Value for '3' is 'Carmine'
```
