---
uid: SLLogCollector
description: SLLogCollector is available by default on each DataMiner Agent, allowing easy log and memory dump collection to troubleshoot DataMiner issues.
---

# SLLogCollector

SLLogCollector is a tool that can be used to easily collect log information and memory dumps from a DataMiner Agent. Log collection can be very useful to troubleshoot issues in DataMiner.

This log collector tool is available on every DMA in the folder `C:\Skyline DataMiner\Tools\SLLogCollector`.

From DataMiner 10.1.0 \[CU2\]/10.1.5 onwards, you can also access SLLogCollector from the shortcut menu of the [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility). To do so, right-click the taskbar utility icon and select *Launch* > *Tools* > *Log Collector*.

If SLLogCollector is not installed on your DataMiner Agent, you can download it from [DataMiner Dojo](https://community.dataminer.services/download/sllogcollector/).

> [!NOTE]
>
> - This tool requires .Net Framework 4.8 or higher.<!-- RN 38966 -->
> - If our DataMiner Support team has requested that you run this tool, they will also provide a link to a secure SharePoint site where you can upload the resulting package.
> - From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40815-->, you can no longer use the built-in Windows file archiver to open and extract the SLLogCollector archives. Use a third-party tool such as [7-Zip](https://www.7-zip.org/) instead.

## Running the tool

To use the SLLogCollector tool:

1. In the folder mentioned above, double-click `SL_LogCollector.exe`.

1. From DataMiner 10.1.0 \[CU11]/10.2.2 onwards, optionally, create a CollectorConfig XML file to fine-tune which resources are collected. See [Using a custom CollectorConfig XML file](#using-a-custom-collectorconfig-xml-file).

1. Configure the necessary options:

   - From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!-- RN 43588 -->, if you do not want to execute the BPA tests available in the system, clear the *Run BPAs* checkbox.

     If this checkbox is selected, or in earlier DataMiner versions starting from DataMiner 10.3.3/10.4.0<!-- RN 35436 -->, each time the *SLLogCollector* tool is run, it will order the [*Standalone BPA Executor* tool](xref:Standalone_BPA_Executor) to execute all BPA tests available in the system. The files containing the test results will have names using the `<BPA Name>_<Date(yyyy-MM-dd_HH)>` format and can be found in the `C:\Skyline DataMiner\Logging\WatchDog\Reports\Pending Reports` folder.

   - To only collect logging for the period since DataMiner was last started, select *Exclude logging of previous run of DataMiner*.

   - To collect memory dumps as well as logging, select *Include memory dump*. Then select for which process(es) memory dumps should be collected and when these should be collected.

     > [!NOTE]
     > When you select the option to collect memory dumps and one or more runtime errors are present, processes affected by these runtime errors are automatically selected.

   - Use the radio buttons to select the location where the log package will be saved. By default, logs are saved to `%USERPROFILE%\Desktop\SL_LogCollector`.

1. When the configuration is complete, click *Start*.

   > [!NOTE]
   > If you just want to use the default settings and save the package to your desktop, there is no need to configure any of the options mentioned in the previous step. All you need to do is click the *Start* button. In case of RTEs, memory dumps are included automatically.
   >
   > ![SLLogCollector](~/dataminer/images/SLLogCollector.png)

1. To view information on the actions of the tool, expand the *Console* section at the bottom of the window. For more detailed information, click the *Show detailed log* button.

## Running the tool via command line

From DataMiner 10.1.11/10.2.0 onwards, you can also run the tool via command line, using the options listed below.

| Option | Description |
|--------| ----------- |
| `-c`<br>`--console` | Runs the console version of the tool. Always specify this option if you want to run the tool via command line. |
| `-h`<br>`-?`<br>`--help` | Shows help. |
| `-f=VALUE`<br>`--folder=VALUE` | Determines the folder where the logging should be saved. Default: `C:\Skyline_Data\` |
| `-d=VALUE`<br>`--dumps=VALUE` | Allows you to specify the process names or IDs for which dumps should be taken. "VALUE" should be a comma-separated list of names or IDs. |
| `-m=VALUE`<br>`--memory=VALUE` | If this option is added, an additional dump will be taken after the process reaches the amount of memory (in MB) specified as "VALUE". |
| `-b=VALUE`<br>`--bpas=VALUE` | If "VALUE" is set to true (default), BPA tests are executed before log collection. If set to false, they are not executed. Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards.<!-- RN 43588 -->|

For example:

```txt
SL_LogCollector.exe -c -d=25784,2319
SL_LogCollector.exe -c -h
```

> [!NOTE]
> By default (from DataMiner 10.3.3/10.4.0 onwards<!-- RN 35436 -->), each time the *SLLogCollector* tool is run, it will order the [*Standalone BPA Executor* tool](xref:Standalone_BPA_Executor) to execute all BPA tests available in the system. The files containing the test results will have names using the `<BPA Name>_<Date(yyyy-MM-dd_HH)>` format and can be found in the `C:\Skyline DataMiner\Logging\WatchDog\Reports\Pending Reports` folder. From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!-- RN 43588 -->, an option is available that makes it possible to skip these BPA tests (see table above).

## Using a custom CollectorConfig XML file

From DataMiner 10.1.0 \[CU11]/10.2.2 onwards, you can use a custom CollectorConfig XML file to indicate which resources need to be collected. This file should be placed in the folder `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs`. By default, this folder will contain a *Default.xml* file, listing a default list of resources to be collected.

> [!NOTE]
> From DataMiner 10.2.0 [CU11]/10.3.2 onwards, instead of in the default folder `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs`, you can place the custom CollectorConfig XML file in a `LogConfig` folder within the same folder as `SL_LogCollector.exe`. <!-- RN 34739 -->

To customize the collected resources, add your own custom XML file to this folder, specifying the "collectors" that should be used.

Here is an example of such a configuration file:

```xml
<ResourceCollectorConfig>
   <Collectors>
      <File name="Collector1">
         <Source>C:\Windows\System32\LogFiles\Apache</Source> <!--Search in this folder-->
         <Destination>Cassandra\Apache</Destination> <!--Place the results here-->
        <Patterns>
           <Pattern amount="1">cassandra-stderr*</Pattern> <!--take the most recent cassandra-stderr*-->
           <Pattern amount="1">cassandra-stdout*</Pattern> <!--take the most recent cassandra-stdout*-->
           <Pattern amount="1">commons-daemon*</Pattern><!--take the most recent cassandra-daemon*-->
        </Patterns>
      </File>
      <Http name="Collector2">
         <Source>http://127.0.0.1:8222</Source> <!--The host info-->
         <Destination>NATS\APICalls</Destination> <!--Relative path to save the result file-->
         <Endpoints>
            <Endpoint name="connz"> <!--An endpoint named connz that will be contacted-->
               <Requests>
                  <Request>subs=detail&amp;sort=bytes_to&amp;auth=1</Request><!--a query to send to connz-->
               </Requests>
            </Endpoint>
            <Endpoint name="routez"> <!--An endpoint named routez that will be contacted-->
               <Requests>
                  <Request></Request> <!--empty request-->
               </Requests>
            </Endpoint>
         </Endpoints>
      </Http>
      <Exe name="Collector3">
         <Source>C:\Program files\Cassandra\Bin</Source> <!--The location of the executable-->
         <Executable>nodetool.bat</Executable> <!--The executable-->
         <Destination>Nodetool</Destination> <!--The relative path to save the result-->
         <Commands>
            <Command>status</Command> <!--A command called status to be passed to the executable-->
            <Command>cfstats</Command> <!--A command called cfstats to be passed to the executable-->
         </Commands>
      </Exe>
   </Collectors>
</ResourceCollectorConfig>
```

In this example, three collectors have been defined, each of a different type:

- Collector1 is a collector of [type "File"](#collectors-of-type-file) and will order SLLogCollector to **retrieve a set of files** (e.g., log files).

- Collector2 is a collector of [type "Http"](#collectors-of-type-http) and will order SLLogCollector to **send an HTTP request** to a server and to store the response.

- Collector3 is a collector of [type "Exe"](#collectors-of-type-exe) and will order SLLogCollector to **run an executable file** and to store the output.

### Collectors of type File

Collectors of type "File" can be used to retrieve files matching a specific pattern. You can configure them using the following XML elements and attributes:

| Element/attribute | Type | Mandatory | Description |
|-------------------|------|-----------|-------------|
| File@name         | String | Yes | The name for the collector. |
| File.Source       |  | Yes | The folder in which SLLogCollector will search for files and folders. |
| File.Destination  |  | Yes | The (relative) path to the destination folder in the archive. |
| File.Patterns     |  | Yes | The element containing all search patterns. |
| File.Patterns.Pattern |  | Yes | A [Microsoft .Net search pattern](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0#System_IO_Directory_EnumerateFiles_System_String_System_String_) to filter file names or file paths. |
| File.Patterns.Pattern@amount | Int | No | The X most recent items to be copied. |
| File.Patterns.Pattern@recursive | Bool | No | Whether to search recursively or not. Default: false. |
| File.Patterns.Pattern@isFolder | Bool | No | If true, SLLogCollector will search for folders matching the pattern and will copy the entire content of the matching folders. Default: false. |

### Collectors of type Http

Collectors of type "Http" can be used to send an HTTP request to a server and store the response. You can configure them using the following XML elements and attributes:

| Element/attribute | Type | Mandatory | Description |
|-------------------|------|-----------|-------------|
| Http@name | String | Yes | The name for the collector. |
| Http.Source |  | Yes | The IP address and port to which the requests have to be sent. Format: `http://ip:port` |
| Http.Destination |  | Yes | The (relative) path to the destination folder in the archive. |
| Http.Endpoints |  | Yes | The element containing all endpoints. |
| Http.Endpoints.Endpoint |  | Yes | The element grouping all information on a particular endpoint. |
| Http.Endpoints.Endpoint@name | String | Yes | The name of the endpoint. |
| Http.Endpoints.Endpoint.Requests |  | Yes | The element containing all requests to be sent to the endpoint. |
| Http.Endpoints.Endpoint.Requests.Request |  | Yes | The request to be sent. |
| Http.Endpoints.Endpoint.Requests.Request.fileName | String | No | The name of the file in which the response has to be saved. Default: `<Endpoint.name> <Endpoint.Requests.Request>.txt` |

### Collectors of type Exe

Collectors of type "Exe" can be used to run an executable file and store the output. You can configure them using the following XML elements and attributes:

| Element/attribute | Type | Mandatory | Description |
|-------------------|------|-----------|-------------|
| Exe@name | String | Yes | The name for the collector. |
| Exe.Source |  | Yes | The folder in which the executable is located. |
| Exe.Executable |  | Yes | The name of the executable. |
| Exe.Destination |  | Yes | The (relative) path to the destination folder in the archive. |
| Exe.Commands |  | Yes | The element containing all commands to be run. |
| Exe.Commands.Command |  | Yes | The command to be run. |
| Exe.Commands.Command@fileName | String | No | The name of the file in which the result has to be saved. Default: `<executable> <command>.txt` |

## Troubleshooting

In some cases, SLLogCollector can seem to get stuck when collecting files. This usually has one of the root causes detailed below.

### Nodetool missing JAVA_HOME

**Issue**: When nodetool cannot resolve a *JAVA_HOME* variable (either in the session or system-wide), it goes into an error mode without exiting, which can block SLLogCollector.

**Symptoms**: In the *Details* window of the Windows Task Manager, there is a *cmd.exe* entry with the following string in the *Command line* column: `C:\WINDOWS\system32\cmd.exe /c ""C:\Program Files\Cassandra\bin\nodetool.bat" status"`

**Workaround**: Either define *JAVA_HOME* in the environment variables of the PC, or replace `if NOT DEFINED JAVA_HOME goto :err` with `if NOT DEFINED JAVA_HOME set JAVA_HOME=C:\Program Files\Cassandra\Java` in *nodetool.bat*.

**Solution**: Install DataMiner 10.3.0 [CU15], 10.4.0 [CU3], 10.4.6, or higher.<!-- RN 39409 -->

### Large number of files

**Issue**: When certain folders, e.g., the SRM debug location or the Logging\FormatterExceptions folder, contain a large number of files, it can take a long time before SLLogCollector has managed to copy these over.

**Symptoms**: One core of the CPU shows high usage. Under `C:\ProgramData\Skyline\DataMiner\SL_LogCollector\Temp_<guid>`, Files are slowly being added to the `\Logs\Skyline DataMiner\Logging\FormatterExceptions` or `\Logs\Skyline DataMiner\SRM...` folder.

**Workaround**: Manually clean up folders that contain an excessive number of files.

<!-- **Solution**: TBD - RN 39894 -->

### HTTP request timeouts

**Issue**: In case of a large database cluster (usually OpenSearch or Elasticsearch), SLLogCollector takes a long time to cycle through every combination of IP/Request/Endpoint. Each of these can take up to 5 minutes.

**Symptoms**: After you have waited 5 minutes, the SLLogCollector logging shows warnings containing URLs.

**Workaround**: Remove the corresponding HTTP collector from the SLLogCollector default config:

1. Open the file `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs\default.xml` in a code editor (e.g., Notepad++).

1. Search for the `<Http name="ElasticApi">` tag.

1. Remove the content starting from that tag up to and including the closing `<\Http>` tag.

1. Save the file and restart SLLogCollector.

<!-- **Solution**: TBD - task 241544 -->

### Other issues

If SLLogCollector seems stuck, but none of the issues mentioned above apply for your situation, follow the steps below to gather information so we can investigate the issue:

1. Open a command prompt as administrator.

1. Enter the following command to navigate to the Procdump folder: `cd C:\Skyline DataMiner\Tools\Procdump`.

1. Enter the following command to create a dump file: `procdump -ma <PID of SL_LogCollector>`.

   In the command above, replace `<PID of SL_LogCollector>` with the PID indicated in the *PID* column for *SL_LogCollector* in the *Details* tab of the Windows Task Manager.

   The resulting file will be placed in the folder `C:\Skyline DataMiner\Tools\Procdump\`.

1. Send the resulting .dmp file to <support@dataminer.services>.
