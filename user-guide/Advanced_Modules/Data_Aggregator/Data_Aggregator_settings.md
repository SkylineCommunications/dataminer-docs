---
uid: Data_Aggregator_settings
---

# Data Aggregator settings

Below you can find an overview of the different settings you can configure in the file *appsettings.custom.json*:

- [HTTP listening](#http-listening)

- [Multi-DMS connection](#multi-dms-connection)

- [Throttling](#throttling)

- [GQI queries](#gqi-queries)

- [Jobs](#jobs)

- [Export](#export)

## HTTP listening

Configure which URL or URLs Data Aggregator should listen to. To specify multiple URLs, use semicolons (";") as separators.

For example:

```json
{
  "Urls": "http://127.0.0.1:5000"
}
```

> [!IMPORTANT]
> Make sure the specified port is available and not used by any other process.

> [!NOTE]
>
> - Once the [Data Aggregator setup](xref:Data_Aggregator_install_setup) is complete, if you browse to the configured URL and port, a web UI is displayed where you can start the queries manually, cancel ongoing queries, and check information such as the time it takes to finish a query, the total number of rows, and the number of rows received per second.
> - Using the REST API, you can also do certain actions like getting the status of the jobs or manually triggering a specific job. More information is available via the URL `[Your configured URL]/swagger/index.html`, e.g. `http://127.0.0.1:5000/swagger/index.html`.
> - Keep in mind that **if there is no firewall in place, anyone can use the web UI and the REST API**, as no authentication is required to use Data Aggregator.

## Multi-DMS connection

For every DataMiner System you want Data Aggregator to connect to, you will need to specify the following fields under *BrokerOptions.Clusters*:

- **ID**: A unique ID.

- **URIs**: A string array containing the NATS endpoints. Every DMA in the DMS can be specified here.

- **CredsFile**: The path to the *.creds* file containing the authentication information. On a DataMiner Agent, you can typically find this here: `C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds`.

  > [!NOTE]
  > When you make the following changes to a DMS, you will need to replace the *.creds* file:
  >
  > - Changing the IP address of one or more DataMiner Agents.
  > - Adding or removing one or more DataMiner Agents to/from the DMS.

In addition, you will also need to configure the following fields under *BrokerOptions*:

- **ConnectTimeoutSeconds**: The connection timeout time, in seconds.

- **RequestTimeoutSeconds**: The request timeout time, in seconds. This must be higher than the maximum time to receive the first page of the result of any of the configured GQI queries.

For example:

``` json
{
  "BrokerOptions": {
    "Clusters": [
      {
        "ID": "DMS 1",
        "URIs": [ "nats://10.11.3.32:4222", "nats://10.11.4.32:4222" ],
        "CredsFile": "C:\\DataAggregator\\creds\\DMS1.creds"
      },
      {
        "ID": "DMS 2",
        "URIs": [ "nats://10.11.3.83:4222", "nats://10.11.4.83:4222" ],
        "CredsFile": "C:\\DataAggregator\\creds\\DMS2.creds"
      },
      {
        "ID": "DMS 3",
        "URIs": [ "nats://10.11.5.83:4222" ],
        "CredsFile": "C:\\DataAggregator\\creds\\DMS3.creds"
      }
    ],
    "ConnectTimeoutSeconds": 5,
    "RequestTimeoutSeconds": 60
  }
}
```

## Throttling

To avoid executing too many queries simultaneously, you can configure throttling. This way you can prevent that your queries take up too many resources from the DataMiner Systems you are querying.

For this purpose, specify the following fields under *DataFetchQueueOptions*:

- **MaxConcurrent**: The total maximum number of simultaneous queries.

- **MaxConcurrentPerCluster**: The maximum number of simultaneous queries per DataMiner System.

For example:

``` json
{
  "DataFetchQueueOptions": {
    "MaxConcurrent": 10,
    "MaxConcurrentPerCluster": 2
  }
}
```

## GQI queries

The GQI queries themselves should be configured in separate JSON files. See [Configuring GQI queries for Data Aggregator](xref:Data_Aggregator_queries).

In *appsettings.custom.json*, you should then add the files using the **QueryID** and **QueryFile** fields under *QueryReaderOptions.Queries*.

For example:

``` json
{
  "QueryReaderOptions": {
    "Queries": [
      {
        "QueryID": "Query1",
        "QueryFile": "C:\\Queries\\Query1.query.json"
      },
      {
        "QueryID": "Query2",
        "QueryFile": "C:\\Queries\\Query2.query.json"
      }
    ]
  },
  "QueryExecutorOptions": {
    "PageSize": 100,
    "TimeoutSeconds": 60
  }
}
```

## Jobs

The configured GQI queries can be used in one or more DataMiner jobs.

Each job can execute an array of queries, each linked to a DataMiner System, so that it is possible to have a query for a specific DataMiner System.

The results of each query are added into one table, so that each job results in one table.

Multiple jobs can be configured, each with their own optional [cron trigger](#cron-trigger). You can also overwrite the global export options for a specific job and overwrite the global *QueryExecutorOptions* for a specific query.

In *appsettings.custom.json*, you can for example configure this as follows:

``` json
{
  "SchedulerOptions": {
    "Jobs": [
      {
        "Name": "Session records",
        "Queries": [
          {
            "ClusterID": "DMS 1",
            "QueryID": "Query1"
          },
          {
            "ClusterID": "DMS 2",
            "QueryID": "Query2"
          },
          {
            "ClusterID": "DMS 3",
            "QueryID": "Query1",
            "QueryExecutorOptions": {
              "PageSize": 1,
              "TimeoutSeconds": 60
            }
          }
        ],
        "CronTriggers": [ "0 0 */12 * * ?" ],
        "CSVExporterOptions": {
          "Enabled": true,
          "Path": "%ProgramData%\\Skyline Communications\\DataMiner DataAggregator\\Results\\Session records",
          "DeleteAfterXDays": 100
        },
        "WebSocketExporterOptions": {
          "Enabled": true
        }
      }
    ]
  }
}
```

### Cron trigger

Each job can have one or more cron triggers. A cron trigger uses cron expressions to let the job's queries run periodically at fixed times, dates, or intervals. Configuring a cron expression is similar to configuring Unix cron jobs, with slight differences (Data Aggregator makes use of *Quartz.NET*):

- Unix: (minute, hour, day, month, day_of_week, year)

- Quartz.NET: (*second*, minute, hour, day, month, day_of_week, year)

For example:

- Every 5 minutes: `"0 0/5 * * * ?"`

- Every 12 hours: `"0 0 */12 * * ?"`

- Every 5 minutes at 10 seconds after the minute (i.e. 10:00:10 AM, 10:05:10 AM, etc.): `"10 0/5 * * * ?"`

- At 10:30, 11:30, 12:30, and 13:30, on every Wednesday and Friday: `"0 30 10-13 ? * WED,FRI"`

- Every half hour between the hours of 8 AM and 10 AM on the 5th and 20th of every month: `"0 0/30 8-9 5,20 * ?"`

  Note that in this case the trigger will NOT fire at 10:00 AM, just at 8:00, 8:30, 9:00, and 9:30.

> [!NOTE]
> Some scheduling requirements are too complicated to express with a single trigger, e.g. "every 5 minutes between 9:00 AM and 10:00 AM, and every 20 minutes between 1:00 Pm and 10:00 PM". That is why in *appsettings.custom.json*, *CronTriggers* is an array, allowing you to specify multiple triggers.

> [!TIP]
> For more information about the syntax, visit the [Quartz.NET website](https://www.quartz-scheduler.net/documentation/quartz-3.x/how-tos/crontrigger.html).
>
> You can also make use of this [online tool](https://crontab.guru/) to configure your own cron expression. However, note that this uses the **Unix format**, while Data Aggregator uses *Quartz.NET*, which has an additional value for the seconds.

## Export

Data Aggregator can export the data results in different ways, depending on how you configure *appsettings.custom.json*.

> [!NOTE]
> Instead of the display values, Data Aggregator exports the raw values, so that the values can easily be imported and processed elsewhere.

### Configuring when to export

The export starts when the received data reaches a certain number of rows. You can configure this with the *ExporterOptions.Threshold* field:

For example:

``` json
{
  "ExporterOptions": {
    "Threshold": 100
  }
}
```

### Export to CSV files

Under *CSVExporterOptions*, you can enable CSV export and configure the settings for the export:

- **Enabled**: Set this to *true* to export to CSV.

- **Path**: The folder where the CSV files will be saved.

- **DeleteAfterXDays**: The number of days after which the CSV files should be automatically deleted.

For example:

``` json
{
  "CSVExporterOptions": {
    "Enabled": true,
    "Path": "%ProgramData%\\Skyline Communications\\DataMiner DataAggregator\\Results",
    "DeleteAfterXDays": 100
  }
}
```

### Export to WebSocket connection

Under *WebSocketExporterOptions*, you can enable the export over the WebSocket connection as follows:

``` json
{
  "WebSocketExporterOptions": {
    "Enabled": true
  }
}
```

The WebSocket connection is available as a SignalR WebSocket connection on the `/webSocketHub` endpoint. Data messages will trigger the `data` event.

Open-source client libraries of SignalR are available on the [SignalR website](https://signalr.net). For example, using the `@microsoft/signalr` npm package:

``` ts
const connection = new signalR.HubConnectionBuilder().withUrl("/webSocketHub").build();
connection.on("data", function (data: DataAggregatorTable) {
});
```

The data is structured as follows:

``` ts
class DataAggregatorTable {
    JobID: number;
    Name: string;
    CreatedUTC: number;
    Columns: DataAggregatorTableColumn[];
    Rows: DataAggregatorTableRow[];
}
class DataAggregatorTableColumn {
    Name: string;
}
class DataAggregatorTableRow {
    Cells: DataAggregatorTableCell[];
}
class DataAggregatorTableCell {
    Value: string;
}
```
