---
uid: DataAPI_about
---

# About Data API & Scripted Connectors

## Scripted Connectors

Scripted Connectors are executed by the Data Aggregator DxM and operate independently from DataMiner. To use Scripted Connectors, Data Aggregator must be installed on the same server as DataMiner. Consequently, the scripts are stored on the same machine as DataMiner. It's worth mentioning that the execution of Scripted Connectors is carried out separately from any other DataMiner processes.

Once added, Scripted Connectors run every minute.

These connectors can be written in PowerShell and Python. Data Aggregator comes with Python 3.12.0. If a Scripted Connector requires additional Python packages, you can [install extra Python packages](xref:Data_Sources_install_setup).

The scripts then send JSON data through a local HTTP call to the Data API.

## Data API

The Data API provides an HTTP API that accepts requests with a JSON formatted body. When necessary, the Data API creates an element to store the values from the JSON formatted body.

The HTTP request should include the following HTTP header fields:

- The **identifier** is stored as the General Parameter *Data API Identifier* and must be unique in the DMS cluster. The identifier serves as the initial name of the element. It's important to note that the element can be renamed later at any time, as the Data API uses the *Data API Identifier*.
- The **type** is the name of the auto-generated connector.

The HTTP body is a JSON formatted structure with key-value pairs. This action prompts the creation of a corresponding element in DataMiner, where the specified values for *Server Name* and *CPU Utilization* are stored in parameters with the same names.

The values can be either strings or doubles, and they are trended by default.

```json
{
  "Server Name": "WebServer001",
  "CPU Utilization": 78.5
}
```

### Auto-generated connectors

The Data API creates auto-generated connectors and provisions elements with them. These connectors are read-only and can be identified by a blue DataMiner icon in the [Protocol and templates](xref:protocols) app.

If there is no auto-generated connector for the specified *type* yet, the Data API generates a new auto-generated connector.

However, if there is already an auto-generated connector for the specified *type*, the Data API updates the existing auto-generated connector when the JSON formatted body contains keys for which no parameters exist yet in the auto-generated connector.

You you can manage alarm templates, trend templates, information templates and Visio files for auto-generated connectors via the [Protocol and templates](xref:protocols) app. Elements created by the Data API come with an initial trend template in which all parameters have trending enabled.

### Support for tables

The Data API translates JSON arrays from the HTTP body into to a table in the corresponding element.

```json
{
  "People": [
    {
      "Id": 1,
      "Name": "John",
      "Age": 25,
      "Height": 1.75
    },
    {
      "Id": 2,
      "Name": "Alice",
      "Age": 30,
      "Height": 1.60
    },
    {
      "Id": 3,
      "Name": "Bob",
      "Age": 28,
      "Height": 1.82
    }
  ]
}
```

The above JSON array is translated into a table *People* with the columns ID, Name, Age and Height. The field *Id* always serves as the primary key for the table.

The Data API also supports nested arrays by transforming them into multiple tables connected through a foreign key. Here's an example of a JSON structure that will be changed into three individual parameters and two tables, with the tables linked through a foreign key.

```json
{
  "Device": "Backbone Switch",
  "Ping": 3,
  "IP": "10.10.10.10",
  "MAC Address": "08-58-F2-F9-36-94",
  "VLANS": [
    {
      "Id": 1001,
      "Type": "10GBE",
      "Description": "Access Points",
      "Connected devices": [
        {
          "Id": "AP1",
          "Description": "Access Point Hall"
        },
        {
          "Id": "AP2",
          "Description": "Access Point Board Room"
        }
      ]
    },
    {
      "Id": 1002,
      "Type": "100MB",
      "Description": "IOT",
      "Connected devices": [
        {
          "Id": "T1",
          "Description": "Temperature sensor"
        },
        {
          "Id": "H1",
          "Description": "Humidity sensor"
        }
      ]
    }
  ]
}

```

The information from the *VLANs* array will be distributed into two tables: *VLANs* and *Connected Devices*.

- The **VLANs** table includes the columns *Id [IDX]*, *Type* and  *Description*.
- The **Connected Devices** table has the columns *Id [IDX]*, *Description*, and *VLAN_Foreign Key*. The creation of the *VLANs_Foreign Key* is handled by the Data API, using the linked table's name and storing the foreign key to the *VLANs* table.

## Element layout

Elements generated using the Data API follow a predetermined layout.

Every individual parameter is placed on the first page named *Parameters*, while each table is positioned on a separate dedicated page.

## Limitations

When working with the Data API and Scripted Connectors, it's essential to be aware of specific limitations:

- Scripted Connectors
  - Operate on a fixed frequency of one minute.
  - Lack support for arguments.
  - Are locally stored on the server.
  - Are not synchronized in a DMS cluster.
  - Cannot be employed to manage data sources.
- Data API
  - Does not handle requests with payloads exceeding 1MB.
  - Does not accept requests from external systems.
  - Expects a field Id in JSON Arrays, serving as the primary key in the element's table.
- Parameters in auto-generated connectors
  - Lack units, and this configuration cannot be adjusted.
  - Are automatically assigned to pages in the element layout, and this allocation cannot be modified.

Certain limitations are expected to be lifted in future versions.
