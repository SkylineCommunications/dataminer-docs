---
uid: Data_Sources
---

# Data Sources

> [!IMPORTANT]
> At present, this feature is only available in preview, if the [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

The *Data Sources* module offers a powerful solution for accessing data from diverse sources, across hardware, software, and cloud services. [Scripted connectors](xref:Scripted_Connectors) allow you to swiftly integrate new products and data sources into your operations with ease.

![Data Sources module](~/dataminer/images/Data_Sources.png)<br>*Data Sources module in DataMiner 10.4.5*

Scripted connectors, hosted on DataMiner, are executed every minute and can be written in Python or PowerShell. These scripts transmit JSON data through a local HTTP call to the [Data API](xref:Data_API), triggering the creation of an element through an automatically generated connector.

![Architectural Overview of Scripted Connectors & Data API](/dataminer/images/Data_API_Schematic.png)

This is an example JSON data snippet, storing the specified values for the server name and CPU utilization. This data, in turn, triggers a corresponding element to be generated in DataMiner.

```json
{
  "Server Name": "WebServer001",
  "CPU Utilization": 78.5
}
```

Subsequent updates trigger the automatic updating of these values.

> [!NOTE]
> Individual JSON objects, JSON arrays, and nested arrays are all supported.
