---
uid: Configuring_data_offloads
keywords: central database
---

# Configuring data offloads

## Configuring offloads to files

Offloading data to files is supported from DataMiner 10.2.0/10.1.1 onwards. To do so:

1. Go to System Center > *Database* > *Offload* and select *File* in the dropdown box at the top.

1. Configure the data offloads as detailed below and set a maximum size for the combined offload files.

Offload files are located in the following folder: `C:\Skyline DataMiner\System Cache\Offload`.

- Alarm properties are located in the subfolder `Alarm_Property`.
- Alarms are located in the root folder (`C:\Skyline DataMiner\System Cache\Offload`).
- Real-time trend data are located in the subfolder `Data`.
- Average trend data are located in the subfolder `Dataavg`.

Each DMA in the cluster will generate its own files. The files available on a specific DMA will contain information about the elements hosted on that DMA.

> [!NOTE]
> Offload files are typically generated with a .csv extension. However, files generated for alarm properties will have a .dat extension, even though they contain plain text.

## Configuring the offload rate

The offload rate for trend data and alarm data can be configured in System Center.

1. In DataMiner Cube, go to *System Center \>* *Database \> Offload*.

1. To set a custom offload interval, at the top of the *Offloads* section, specify a different interval between 1 and 1440 minutes (i.e. 1 day).

   This is the offload rate at which the data will actually be sent to the offload database. The default interval is 5 minutes.

1. To configure **alarm data** offloads, in the *Offloads* section, select *Alarm data*. You can then fine-tune this configuration as follows:

   - If a particular table should not be included in the offloads, clear the selection from this table.

   - To customize the name of the table containing particular data in the offload database, specify a custom name next to *Remote table name*.

1. To configure **real-time trend data** offloads, in the *Offloads* section, select *Trend data* > *Enable data offload*. You can then specify the following options:

   - The **offload type**: *All parameter values* or *All changed parameter values.*

     > [!NOTE]
     > When *All parameter values* is selected, data will still be offloaded even when the parameter value has not changed. However, real-time data is written to the database with the timestamp of the last change, so that there can be multiple consecutive entries with exactly the same timestamp in that case. For example, for the parameter change illustrated below, if *All parameter values* is selected, the offloaded data will be 1 record, of value 1. With *All changed parameter values*, the offloaded data will be all 20 values needed to draw the graph.
     >
     > ![Example trend graph](~/dataminer/images/Trending_offload_example.png)

   - The **interval** at which these offloads are generated: A number of minutes between 1 and 1440 (i.e. 1 day).

   - The offload **start time**, i.e. the time when the offload to the database first begins, in the format hh:mm:ss. This setting is only implemented at startup, so if you change the setting while the DMA is running, the DMA will need to be restarted for the change to take effect.

   - **Remote table name**: Allows you to customize the name of the table containing this data in the offload database. The default name is *Data*.

1. To configure **average trend data** offloads, select *Trend data* > *Enable dataavg offload.* You can then fine-tune this configuration as follows:

   - Next to *Offload*, specify which average trended record should be offloaded.

     The available **time frame records** depend on the trend window configuration. For a default configuration, the following options are available: *All time frame records* (default setting), *Only short time frame records (5 min)* and *Only long time frame records (60 min)*.

     > [!NOTE]
     > For more information on the trend window configuration, see [MaintenanceSettings.Trending](xref:MaintenanceSettings.Trending).

   - **Remote table name**: Allows you to customize the name of the table containing this data in the offload database. The default name is *DataAvg*.

1. To offload **snapshots** (i.e. parameter information for parameters for which the snapshot option has been set in the protocol), select *Parameter value* and *Enable snapshot offload*. The snapshot offloads can then be further fine-tuned as follows:

   - Select to offload *All parameter values* or only *All changed parameter values*.

   - Specify the offload **rate** (by default once every five minutes).

   - Specify the offload **start time**, in the format hh:mm:ss.

   - To customize the name of the table containing the snapshot data in the offload database, specify a custom name next to **Remote table name**.

   - If all previous values should be removed from the database each time a new snapshot is offloaded, make sure the option *Only keep the latest parameter value in the database* is selected. If this option is not selected, all values will be kept.

     This option corresponds with the `clean="true"` configuration in the *Offload* tag in *DB.xml*. If it is activated, DataMiner will truncate the data table in the offload database before new information is added. This way, the table always contains the latest snapshot information only.

   > [!TIP]
   > In an information template, you can configure specific parameters to be included in offload database snapshots. See [Creating an information template](xref:Creating_an_information_template).

> [!NOTE]
>
> When real-time or average trending is offloaded:
>
> - If there are more than 10&nbsp;000 lines to write to an offload file, so that multiple offload files need to be generated per configured interval, these files will have a different name format from other offload files. While usually offload file names refer to a date and time, those files will instead refer to a specific time tick. This is necessary to prevent name conflicts when multiple files are generated per second. Aside from the different name format, these files are the same as other offload files.
> - If less than 10&nbsp;000 lines are written to an offload file, there will usually be a delay of approximately 150 seconds before the offload file is generated. However, note that this does not affect the records within the file; these will reflect the configured offload interval. If the interval is small enough, this does mean that a file could contain changes for multiple intervals. If more than 10&nbsp;000 lines are written, offload files are written immediately.

## Disabling data offloads to the offload database on element level

By default, data offloads are enabled for every element. In every *Element.xml* file, you should find the following setting:

```xml
<Element>
  ...
    <CentralOffload>true</CentralOffload>
  ...
</Element>
```

If, for a particular element, you want to disable data offloads to the offload database, you can modify this setting as follows:

1. Stop DataMiner.

1. In `C:\Skyline DataMiner\Elements\`, go to the subfolder of the element and open *Element.xml*.

1. Set the *\<CentralOffload>* tag to *false*.

   ```xml
   <Element>
     ...
       <CentralOffload>false</CentralOffload>
     ...
   </Element>
   ```

1. Save the file and restart DataMiner.

    The data associated with this element will no longer be offloaded.

## Configuring trend templates to exclude/include data in offloads

It is possible to configure whether real-time and/or average trending for particular parameters should be included in offloads. This can be done directly in the trend template containing these parameters:

1. Open the appropriate trend template in the Protocols & Templates module in Cube.

1. Click the options button in the top right corner and select *Allow offload database configuration*.

1. For each parameter, in the *Offload real-time* and *Offload average* columns, click the buttons until the correct configuration is displayed.

1. Click *OK* to save your changes.