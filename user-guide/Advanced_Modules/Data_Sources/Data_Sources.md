---
uid: Data_Sources
---

# Data Sources

The Data Sources module offers a powerful solution offering flexible access to data from any source imaginable, across hardware, software and cloud services. Scripted Connectors allow you to swiftly and effortlessly integrate new products and data sources into your operations.

Scripted Connectors are hosted on DataMiner and execute every minute. These connectors can be written using Python or PowerShell. The scripts, in turn, transmit JSON data through a local HTTP call to the Data API. Subsequently, this action initiates the generation of an element through an automatically created connector.

![Architectural Overview of Scripted Connectors & Data API](/user-guide/images/Data_API_Schematic.png)

This excerpt is an example of the JSON data that triggers a corresponding element to be generated in DataMiner, storing the specified values for the *Server Name* and *CPU Utilization*.

```json
{
  "Server Name": "WebServer001",
  "CP Utilization": 78.5
}
```

Subsequent updates trigger the automatic updating of these values. It's worth noting that our system supports not only individual JSON objects but also JSON arrays and nested arrays.

For more detailed information about the capabilities and possibilities, take a dive into [About Data API & Scripted Connectors](xref:Data_Sources)
