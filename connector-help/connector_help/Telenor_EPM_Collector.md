---
uid: Connector_help_Telenor_EPM_Collector
---

# Telenor EPM Collector

This connector is used to gather STB data coming from MAM events and Agama firehose export files. The MAM events are forwarded to the collector by elements using the **Telenor EPM MAM Consumer** connector. The Agama files are forwarded to the collector by elements using the **Telenor EPM Agama Consumer** connector. This data is then aggregated to higher topology levels in the **Telenor EPM Manager** connector. Because of the large amount of data they contain, the collector elements are not intended to be opened. The manager UI gives better access to the data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                           |
|-----------|------------------------------------------------------------------|
| 1.0.0.x   | There are no known firmware versions that the connector depends on. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                   | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Telenor EPM Agama Consumer Telenor EPM MAM Consumer Telenor EPM Manager | \-                      |

## Configuration

### Connections

#### IP Connection - Agama Data

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The connector will be listening for incoming data from the Agama consumer, so this field must be set to *any*.
- **IP port**: The IP port of the server where data from the Agama consumer will enter. You can freely choose the value, but remember to open the TCP port in the firewall if the data comes from a different server.

#### IP Connection - MAM Data

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The connector will be listening for incoming data from the MAM consumer, so this field must be set to *any*.
- **IP port**: The IP port of the server where data from the MAM consumer will enter. You can freely choose the value, but remember to open the TCP port in the firewall if the data comes from a different server.

### Initialization

On the **General** page, configure the **County ID** for which this collector will be gathering data.

In the **Provisioning Share Location** parameters, fill in the location of the LPI and SDP folders along with the credentials to access these.

With the **Starting Period Minute**, indicate when the first new period with Agama data after the hour starts (e.g. if a new period starts every xx:01, set the parameter to 1). Indicate in **Period Length** how long a period takes (e.g. 4 minutes). After a period window is closed, it will take some time before the Agama files are created and transferred to the collector. With **Period Margin**, you can configure how long the connector should wait for these files before filling in default N/A values. After the period margin has passed, data will be written into the parameter tables within 10 seconds.

The consumer elements could be located on a different server and the collector element has the *any* IP configured on the connection settings. As a server could have different network cards, it is not easy to automatically detect which IP the consumers should use to reach the collector. This can be configured in the appropriate **Listening Socket** parameters. Fill in the socket that the consumers need to use to reach the collector in the format *IP:Port*. The port needs to be exactly the same as defined in the connections configured during element creation.

## How to Use

### General

From the consumer element, MAM events will enter during the defined period and Agama files should enter during the period margin. After the period margin has been reached, the data will be set into the parameter tables.

The MAM events are considered the main source for OTT data. In other words, if Agama files contain data about an asset and MAM did not report that asset, then that Agama data will be ignored. As it is possible that a MAM heartbeat is missed, you can use the parameter **Remove OTT Entry when Missing** to configure during how many periods MAM data can be absent while Agama data still gets filled in for that asset, before the asset is removed. The asset will be removed immediately in case a MAM stop event is received.

Agama files are considered the main source for non-OTT data, such as Live DVB-C. In other words, if MAM reported a channel that Agama did not report during the period, then that channel will be ignored.

As it is possible to zap through channels, the **Minimum Agama Activity** setting helps you to avoid collecting channels that were only watched for a brief moment. It allows you to configure how long a channel needs to be watched before it is taken into account.

### Channel Details

The channel details are used to make the mapping of a channel. This is for Live DVB-C, Live IPTV, OTT Live/Start-Over and OTT Catchup. You can load these by clicking the **Load** button. The details will be loaded from the configured LPI folder in the sublocation *\enrichment\services\channels.csv*.

The content of that file must be comma-separated and must contain the following headers:
*ChannelID,ChannelName,CS_Type,DVB-C-Live-TV,IPTV-Live-TV,OTT-Live-TV,Start-over,Catchup,MultiCast,MC_Port,SID,TS_ID,ONid,MPEG-DASH OTT Live/Start-Over URL,HLS OTT Live/Start-Over URL,MPEG-DASH OTT Catch-Up URL,HLS OTT Catch-Up URL*

### Asset Details

The asset details are used to make the mapping of an OTT VOD asset. You can load these by clicking the **Load** button. The details will be loaded from the configured LPI folder in the sublocation *\enrichment\services\assets.csv* and *\enrichment\services\providers.csv*.

The content of the *assets.csv* file must be separated by semicolons (";") and must contain the following headers:
*Asset Id;Timestamp;Provider Id;Log Title Nb;Telenor Common Id;Stream Id;Dash Url;HLS Url*

The content of the *providers.csv* file must be separated by semicolons (";") and must contain the following headers:
*ProviderNumber;ProviderId;ProviderName*

To be able to easily detect if a URL is for a VOD asset, the asset details will be analyzed, and one or more signatures will be created and added to the **Asset Signatures** table. This table is displayed to make it possible to investigate problems in case mapping is not working as expected.

### Aggregation Threshold

On this page, you can configure the different thresholds that will be used during aggregation to higher levels. For example, if you set **QoE Unavailable Live IPTV Aggregation Threshold** to *20%*, the device will be considered to have an unavailable service during the period if the reported unavailable QoE value is greater than or equal to *20%*.

### Error Codes

The **Error Codes** table allows you to determine to which category an error code belongs. For example, when you configure **Error Code** to *E2309* with **Category** *OTT Live/Start-Over Setup Error,* the device will be considered to have an OTT Live/Start-Over Setup Error as soon as an error code E2309 enters for the device during the period interval.

### Custom Logging

Because of the large amount of data that would otherwise flood the log file, it is preferable to use a filtered way of logging and focus on part of the data. You can configure this with the custom logging.

In the **Log Request Destination Type**, you can select where the content should be written: in the *Protocol Log* file where all other element logging is recorded, in a separate *Custom File*, or in a *Table*.

When the logging is written to a custom file, the default location for this file is *C:\Skyline DataMiner\Telenor\Elements\\elementname\>\Logging*. However, you can specify a custom location with the **Log Request Custom Folder** setting. Custom log files are by default kept for 7 days, after which they are automatically deleted, but you can customize this number of days with the **Log Request Remove Custom File After** setting. File deletion will only be active when custom logging is created.

You can configure what should be logged in the **Log Request** table. To add a row, click the **Add Row** button.

You can subscribe to a type of MAM event, or choose MAM-specific content to look for a certain filter value in all incoming events, or focus on rejected content to only see what data has been ignored and the specific reason why. MAM logging can have a **Filter Value** to only log events that contain a certain value.

You can also subscribe to Agama files. Agama Basic shows the summary of when the different types of Agama files were received, without showing content. Either the header line of a specific file can be shown, or the entire content. There is no need to specify both *Header* and *Content*, because when *Content* is selected, the header line is included. It is also possible to view only rejected content to see what data has been ignored and the specific reason why. Agama logging does not support a **Filter Value** as most content consists of numbers only.

Logging for a *Specific Device* is also supported. To use this, select this type of logging and fill in the device ID in the Filter Value. All incoming data about this device across the different MAM events and Agama files will be logged, including the reason why some data has been rejected.
The **Full Content** with all incoming data can be logged, but this is not advised as it will log everything. This could only be handy when there is no data present at all, to investigate if any data enters the element.

The **Log Result** table will display the logging in case the **Log** **Request Destination Type** is set to *Table*. This type of logging can be useful to quickly investigate something when there is no file access. The number of rows is limited to 2000. The oldest rows get overwritten when there are there are new entries. You can clean the table by clicking the **Clear Results** button.

### Other pages

The other pages contain the raw data, e.g. all devices, households, channels, etc. These pages are not meant to be consulted. To view this data, use the manager UI instead.

## Notes

### Blacklisting

If devices are linked to different households in the provisioning files, these devices will not be added to the collector. You can force the collector to ignore a device by adding the device ID as an entry in the *blacklisted.csv* file, which is located in the configured SDP folder. This allows you to exclude test devices, or to exclude devices where the user has not given permission to gather data in the context of the GDPR legislation.

### Alarm monitoring

Alarm monitoring is not possible on the data of the device, household, and channels. This is because these levels contain thousands of entries. Monitoring just one parameter would result in such a large number of alarms, that it would flood both server and client. There is no practical use for this monitoring, and it would be impossible to still detect the root cause of the issue. However, note that trending is still possible.
