---
uid: Configuring_data_offloads
---

# Configuring data offloads

In this section:

- [Configuring the offload rate](#configuring-the-offload-rate)

- [Disabling data offloads to the offload database on element level](#disabling-data-offloads-to-the-offload-database-on-element-level)

- [Configuring trend templates to exclude/include data in offloads](#configuring-trend-templates-to-excludeinclude-data-in-offloads)

## Configuring the offload rate

The offload rate for trend data and alarm data can be configured in System Center.

1. In DataMiner Cube, go to *System Center \>* *Database \> Central* (prior to DataMiner 10.0.13) or *System Center \>* *Database \> Offload* (from DataMiner 10.0.13 onwards).

1. To set a custom offload interval, at the top of the *Offloads* section, specify a different interval between 1 and 1440 minutes (i.e. 1 day).

   This is the offload rate at which the data will actually be sent to the offload database. The default interval is 5 minutes.

1. To configure alarm data offloads, in the *Offloads* section, select *Alarm data*. You can then fine-tune this configuration as follows:

   - If a particular table should not be included in the offloads, clear the selection from this table.

   - To customize the name of the table containing particular data in the offload database, specify a custom name next to *Remote table name*.

1. To configure real-time trend data offloads, in the *Offloads* section, select *Trend data* > *Enable data offload*. You can then specify the following options:

   - The offload type: *All parameter values* or *All changed parameter values.*

     > [!NOTE]
     > When *All parameter values* is selected, data will still be offloaded even when the parameter value has not changed. However, real-time data is written to the database with the timestamp of the last change, so that there can be multiple consecutive entries with exactly the same timestamp in that case.

   - The interval at which these offloads are generated: A number of minutes between 1 and 1440 (i.e. 1 day), or instantly.

     > [!NOTE]
     > Though the offload rate can be customized with this option, the forwarding rate, i.e. the rate at which trend data is actually forwarded to the offload database, is fixed at every 5 minutes up to DataMiner 9.6.0. From DataMiner 9.6.1 onwards, this rate can be configured at the top of the *Offloads* section.

   - The time when the offload to the database first begins, in the format hh:mm:ss. This setting is only implemented at startup, so if you change the setting while the DMA is running, it will need to be restarted for the change to take effect.

   - *Snapshot mode*: When this mode is selected, only parameters for which the snapshot option has been set in the protocol are offloaded.

     > [!NOTE]
     > From DataMiner 9.5.4 onwards, snapshot mode is activated with a separate option below. In addition, from this version onwards, information templates allow you to select whether parameters should be included in offload database snapshots. See [Creating an information template](xref:Creating_an_information_template).

   - *Remote table name*: Allows you to customize the name of the table containing this data in the offload database. The default name is *Data*.

1. To configure average trend data offloads, select *Trend data* > *Enable dataavg offload.* You can then fine-tune this configuration as follows:

   - Next to *Offload*, specify which average trended record should be offloaded.

     The available time frame records depend on the trend window configuration. For a default configuration, the following options are available: *All time frame records* (default setting), *Only short time frame records (5 min)* and *Only long time frame records (60 min)*.

     > [!NOTE]
     > For more information on the trend window configuration, see [MaintenanceSettings.xml](xref:MaintenanceSettings_xml).

   - *Remote table name*: Allows you to customize the name of the table containing this data in the offload database. The default name is *DataAvg*.

1. From DataMiner 9.5.4 onwards, to offload snapshots (i.e. parameter information for parameters for which the snapshot option has been set in the protocol), select *Parameter value* and *Enable snapshot offload*. The snapshot offloads can then be further fine-tuned as follows:

   - Select to offload *All parameter values* or only *All changed parameter values*.

   - Specify the offload rate (by default once every five minutes).

   - Specify the offload start time, in the format hh:mm:ss.

   - To customize the name of the table containing the snapshot data in the offload database, specify a custom name next to *Remote table name*.

   - If all previous values should be removed from the database each time a new snapshot is offloaded, make sure the option *Only keep the latest parameter value in the database* is selected. If this option is not selected, all values will be kept.

     > [!NOTE]
     > This option corresponds with the `clean="true"` configuration in the Offload tag in DB.xml. If it is activated, DataMiner will truncate the data table in the offload database before new information is added. This way, the table always contains the latest snapshot information only.

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

1. In *C:\\Skyline DataMiner\\Elements\\,* go to the subfolder of the element and open *Element.xml*.

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

From DataMiner 9.5.4 onwards, it is possible to configure whether real-time and/or average trending for particular parameters should be included in offloads. This can be done directly in the trend template containing these parameters:

1. Open the appropriate trend template in the Protocols & Templates module in Cube.

1. Click the options button in the top right corner and select *Allow central database offload configuration* (prior to DataMiner 10.1.0/10.1.1) or *Allow offload database configuration* (from DataMiner 10.1.0/10.1.1 onwards).

1. For each parameter, in the *Offload real-time* and *Offload average* columns, click the buttons until the correct configuration is displayed.

1. Click *OK* to save your changes.
