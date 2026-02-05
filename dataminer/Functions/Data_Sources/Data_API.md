---
uid: Data_API
---

# Data API

> [!IMPORTANT]
> At present, this feature is only available in preview, if the [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

The Data API furnishes an HTTP API capable of processing requests with a JSON-formatted body. When necessary, the Data API creates an element to store the values derived from the JSON-formatted body.

The HTTP request should include the following HTTP header fields:

- The **identifier**, stored as the General Parameter "Data API Identifier", must be unique within the DMS cluster. The identifier serves as the initial name of the element, which can be renamed later at any time as the Data API uses the *Data API Identifier*.

- The **type** denotes the name of the auto-generated connector.<!-- RN 37898 -->

The HTTP body comprises a JSON-formatted structure with key-value pairs, triggering the creation of a corresponding element in DataMiner. This process captures the specified values for *Server Name* and *CPU Utilization*, stored in parameters with the same names.

These values can be either strings or doubles, and they are trended by default.

```json
{
  "Server Name": "WebServer001",
  "CPU Utilization": 78.5
}
```

## Auto-generated connectors

The Data API creates auto-generated connectors and provisions elements with them. These connectors are read-only and can be identified by a blue DataMiner icon in the [Protocols & Templates](xref:protocols) module.

If no auto-generated connector for the specified type exists yet, the Data API generates a new one. However, if an auto-generated connector already exists for the specified type, the Data API updates it when the JSON-formatted body contains keys for which no parameters exist in the connector.

You can manage alarm templates, trend templates, information templates, and Visio files for auto-generated connectors through the [Protocols & Templates](xref:protocols) module. Elements created by the Data API include an initial trend template where all parameters have trending enabled.

## Support for tables

The Data API translates JSON arrays from the HTTP body into a table in the corresponding element.

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

This JSON array is transformed into a table called "People" with columns *ID*, *Name*, *Age*, and *Height*. If a field named *Id* (case-insensitive) is specified, it will serve as the primary key for the table. Otherwise, an auto-increment value will be used as the primary key.

The Data API also supports nested arrays, transforming them into multiple tables connected through a foreign key.

For example, the JSON structure below will be changed into three individual parameters and two tables, with the tables linked through a foreign key:

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

The information from the *VLANS* array in this example is distributed into two tables: *VLANS* and *Connected Devices*.

- The **VLANS** table includes the columns *Id [IDX]*, *Type*, and  *Description*.

- The **Connected Devices** table includes the columns *Id [IDX]*, *Description*, and *VLAN_Foreign Key*. The Data API handles the creation of the *VLANs_Foreign Key*, using the linked table's name and storing the foreign key to the *VLANS* table.

## Element layout

Elements generated using the Data API adhere to a predetermined layout.

Individual parameters are placed on the first page named "Parameters", while each table is positioned on a separate dedicated page.

## Settings

Each DataAPI module includes a default configuration file, *appsettings.json*, in which the module settings are defined. This file is located in the module’s installation directory.
To customize these settings, you should use an *appsettings.custom.json* file in the same directory. If this file does not yet exist, you will need to create it yourself.

Note that although it is possible to change the settings directly in *appsettings.json*, these changes will be overwritten when the software is upgraded.
To ensure your custom settings are preserved, please always use *appsettings.custom.json*.

### MessageBroker timeout

The MessageBroker request timeout can be configured via the *appsettings.json* and *appsettings.custom.json*. If no value is configured for this, DataAPI uses 30 seconds as the default.

Example:

```json
{
   "Communication": {
      "MessageBrokerRequestTimeoutSeconds": 60
    }
}
```
