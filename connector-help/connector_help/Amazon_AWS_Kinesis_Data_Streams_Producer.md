---
uid: Connector_help_Amazon_AWS_Kinesis_Data_Streams_Producer
---

# Amazon AWS Kinesis Data Streams Producer

The purpose of this connector is to be able to offload data (trending, alarms, information events, etc.) towards AWS Kinesis through a DataMiner element. The connector will process DataMiner offload files and push the contents of these offload files in a JSON format towards the AWS Kinesis Data Streams service.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                     |
|-----------|----------------------------------------------------------------------------|
| 1.0.0.x   | AWS4 - 20131202 <https://docs.aws.amazon.com/kinesis/latest/APIReference/> |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Format: "*kinesis.\<region\>.amazonaws.com*", e.g. "*kinesis.eu-west-2.amazonaws.com*".
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

HTTP POST messages are used to communicate with the Amazon AWS Kinesis API.

### Initialization

Before polling can start, the credentials for the AWS service first have to be entered on the Configuration page of the element. The Access Key and Secret Key must always be filled in.

On the same page, the target delivery stream needs to be configured for each supported data type.

### Redundancy

There is no redundancy defined.

## How to use

The purpose of this connector is to be able to offload data (trending, alarms, information events, etc.) towards AWS Kinesis through a DataMiner element. The connector will process DataMiner offload files and push the contents of these offload files in a JSON format towards the AWS Kinesis Data Streams service.

Two types of input data are supported by the connector:

- DataMiner central DB offload files

  - In v1.0.0.1, the following types are supported:

    - Data
    - DataAvg
    - Alarm

  - The path can be configured on the Configuration page.

- Custom offload files

  - Custom files from another source (i.e. other element). Data is already in the correct format for a PutRecords request.
  - The path can be configured on the Configuration page.
  - Not yet implemented in v1.0.0.1.

The element also displays various statistics for the key metrics, which allow you to monitor the offload process.

Whenever an impacting event takes place, an information event is generated (long-term storage on the DMA) and a new row will be added to the events table. This table only contains a limited number of events. Older events are removed according to the configuration of the connector.

## Notes

When the central DB offload CSV files are processed, each CSV row gets translated to a JSON object. It is this JSON object that will be offloaded as a record towards the AWS Kinesis Delivery Stream.

You can find the JSON schema definitions of these objects below.

### Data (real-time trend data)


```json
{
  "definitions": {},
  "$schema": "",
  "$id": "http://example.com/root.json",
  "type": "object",
  "title": "Realtime Trend Data Record",
  "description": "This record originates from a DataMiner parameter object that has been enabled for real-time trending. (Storing each parameter value change.)",
  "required": [
    "DOCUMENT_TYPE",
    "DMAID",
    "EID",
    "PID",
    "INDEX",
    "VALUE",
    "TIMESTAMP",
    "TIMESTAMP_UNIX",
    "ISTATUS",
    "ISTATUS_DESC",
    "ELEMENT_NAME",
    "PARAMETER_NAME"
  ],
  "properties": {
    "DOCUMENT_TYPE": {
      "$id": "#/properties/DOCUMENT_TYPE",
      "type": "string",
      "title": "The Document_type schema",
      "description": "Type of JSON record"
    },
    "DMAID": {
      "$id": "#/properties/DMAID",
      "type": "number",
      "title": "The Dmaid schema",
      "description": "The ID value of the DataMiner Agent generating the record.",
      "examples": [
        35712
      ]
    },
    "EID": {
      "$id": "#/properties/EID",
      "type": "number",
      "title": "The Eid schema",
      "description": "The ID value of the element generating the record.",
      "examples": [
        1743
      ]
    },
    "PID": {
      "$id": "#/properties/PID",
      "type": "number",
      "title": "The Pid schema",
      "description": "The ID value of the parameter generating the record.",
      "examples": [
        7017
      ]
    },
    "INDEX": {
      "$id": "#/properties/INDEX",
      "type": "string",
      "title": "The Index schema",
      "description": "IMPORTANT: If it concerns a dynamic table parameter with “advanced naming” enabled, then this field will contain the primary key instead of the display key.",
      "examples": [
        "Bristow Group-Lagos BRC-62964"
      ]
    },
    "VALUE": {
      "$id": "#/properties/VALUE",
      "type": "string",
      "title": "The Value schema",
      "description": "The parameter value of the record.",
      "examples": [
        "0.123"
      ]
    },
    "TIMESTAMP": {
      "$id": "#/properties/TIMESTAMP",
      "type": "string",
      "title": "The Timestamp schema",
      "description": "Date/time when the parameter value was updated.",
      "examples": [
        "2019-11-25T15:10:00"
      ]
    },
    "TIMESTAMP_UNIX": {
      "$id": "#/properties/TIMESTAMP_UNIX",
      "type": "integer",
      "title": "The Timestamp_unix schema",
      "description": "Unix Date/time when the parameter value was updated.",
      "examples": [
        1574694600
      ]
    },
    "ISTATUS": {
      "$id": "#/properties/ISTATUS",
      "type": "number",
      "title": "The Istatus schema",
      "description": "A value indicating the status of the record.",
      "examples": [
        0
      ]
    },
    "ISTATUS_DESC": {
      "$id": "#/properties/ISTATUS_DESC",
      "type": "string",
      "title": "The Istatus_desc schema",
      "description": "A textual description indicating the status of the record.",
      "examples": [
        "Realtime trending point"
      ]
    },
    "ELEMENT_NAME": {
      "$id": "#/properties/ELEMENT_NAME",
      "type": "string",
      "title": "The Element_name schema",
      "description": "The name of the DataMiner element object that generated this record.",
      "examples": [
        "FST_IS1002_N1_IDRCT_EH_EH"
      ]
    },
    "PARAMETER_NAME": {
      "$id": "#/properties/PARAMETER_NAME",
      "type": "string",
      "title": "The Parameter_name",
      "description": "The name of the DataMiner parameter object that generated this record.",
      "examples": [
        "Remote QoS Downstream Requested Bristow Group-Lagos BRC-62964"
      ]
    },
    "ELEMENT_PROPERTIES": {
      "$id": "#/properties/ELEMENT_PROPERTIES",
      "type": "object",
      "title": "The Element_properties schema",
      "description": "Extra (optional) element property objects that can be added to the record."
    }
  }
}
```

### DataAvg (average trend data)

```json
{
  "definitions": {},
  "$schema": "",
  "$id": "http://example.com/root.json",
  "type": "object",
  "title": "Average Trend Data Record",
  "description": "This record originates from a DataMiner parameter object that has been enabled for average trending. (Storing avg/min/max parameter value per time window.)",
  "required": [
    "DOCUMENT_TYPE",
    "DMAID",
    "EID",
    "PID",
    "INDEX",
    "AVGTREND",
    "TIMESTAMP",
    "TIMESTAMP_UNIX",
    "ISTATUS",
    "ISTATUS_DESC",
    "ELEMENT_NAME",
    "PARAMETER_NAME"
  ],
  "properties": {
    "DOCUMENT_TYPE": {
      "$id": "#/properties/DOCUMENT_TYPE",
      "type": "string",
      "title": "The Document_type schema",
      "description": "Type of JSON record.",
      "default": ""
    },
    "DMAID": {
      "$id": "#/properties/DMAID",
      "type": "number",
      "title": "The Dmaid schema",
      "description": "The ID value of the DataMiner Agent generating the record.",
      "examples": [
        35712
      ]
    },
    "EID": {
      "$id": "#/properties/EID",
      "type": "number",
      "title": "The Eid schema",
      "description": "The ID value of the element generating the record.",
      "examples": [
        1743
      ]
    },
    "PID": {
      "$id": "#/properties/PID",
      "type": "number",
      "title": "The Pid schema",
      "description": "The ID value of the parameter generating the record.",
      "examples": [
        7017
      ]
    },
    "INDEX": {
      "$id": "#/properties/INDEX",
      "type": "string",
      "title": "The Index schema",
      "description": "IMPORTANT: If it concerns a dynamic table parameter with “advanced naming” enabled, then this field will contain the primary key instead of the display key.",
      "examples": [
        "Bristow Group-Lagos BRC-62964"
      ]
    },
    "AVGTREND": {
      "$id": "#/properties/AVGTREND",
      "type": "object",
      "title": "The Avgtrend schema",
      "description": "The average, minimum and maximum value this parameter had over the previous time window (ISTATUS property contains info on the time window size)",
      "required": [
        "AVG",
        "MIN",
        "MAX"
      ],
      "properties": {
        "AVG": {
          "$id": "#/properties/AVGTREND/properties/AVG",
          "type": "string",
          "title": "The Avg Schema",
          "description": "The average value of the parameter calculated over the previous time window.",
          "examples": [
            "0.02343"
          ]
        },
        "MIN": {
          "$id": "#/properties/AVGTREND/properties/MIN",
          "type": "string",
          "title": "The Min Schema",
          "description": "The minimum value of the parameter encountered during the previous time window.",
          "examples": [
            "0.021"
          ]
        },
        "MAX": {
          "$id": "#/properties/AVGTREND/properties/MAX",
          "type": "string",
          "title": "The Max Schema",
          "description": "The maximum value of the parameter encountered during the previous time window.",
          "examples": [
            "0.024"
          ]
        }
      }
    },
    "TIMESTAMP": {
      "$id": "#/properties/TIMESTAMP",
      "type": "string",
      "title": "The Timestamp schema",
      "description": "Date/time when the average trend record is generated.",
      "examples": [
        "2019-11-25T15:10:00"
      ]
    },
    "TIMESTAMP_UNIX": {
      "$id": "#/properties/TIMESTAMP_UNIX",
      "type": "integer",
      "title": "The Timestamp_unix schema",
      "description": "Unix Date/time when the average trend record is generated.",
      "examples": [
        1574694600
      ]
    },
    "ISTATUS": {
      "$id": "#/properties/ISTATUS",
      "type": "integer",
      "title": "The Istatus schema",
      "description": "A value indicating the status of the record. (Extra context on the record.)",
      "examples": [
        5
      ]
    },
    "ISTATUS_DESC": {
      "$id": "#/properties/ISTATUS_DESC",
      "type": "string",
      "title": "The Istatus_desc schema",
      "description": "A textual description indicating the status of the record. (Extra context on the record.)",
      "examples": [
        "AVG Trending point (timewindow last 5 minutes)"
      ]
    },
    "ELEMENT_NAME": {
      "$id": "#/properties/ELEMENT_NAME",
      "type": "string",
      "title": "The Element_name",
      "description": "The name of the DataMiner element object that generated this record.",
      "examples": [
        "FST_IS1002_N1_IDRCT_EH_EH"
      ]
    },
    "PARAMETER_NAME": {
      "$id": "#/properties/PARAMETER_NAME",
      "type": "string",
      "title": "The Parameter_name schema",
      "description": "The name of the DataMiner parameter object that generated this record.",
      "examples": [
        "Remote QoS Downstream Requested Bristow Group-Lagos BRC-62964"
      ]
    },
    "ELEMENT_PROPERTIES": {
      "$id": "#/properties/ELEMENT_PROPERTIES",
      "type": "object",
      "title": "The Element_properties schema",
      "description": "Extra (optional) element property objects that can be added to the record."
    }
  }
}
```

### Alarm (alarm data)

```json
{
  "definitions": {},
  "$schema": "",
  "$id": "http://example.com/root.json",
  "type": "object",
  "title": "Alarm Data Record",
  "required": [
    "DOCUMENT_TYPE",
    "DMAID",
    "EID",
    "PID",
    "ALARMID",
    "PREVKEY",
    "VALUE",
    "SEVERITY_ID",
    "SEVERITY",
    "SEVERITY_LEVEL_ID",
    "SEVERITY_LEVEL",
    "TOA",
    "TOA_UNIX",
    "TYPE_ID",
    "TYPE",
    "OWNER",
    "STATUS_ID",
    "STATUS",
    "USERCOMMENT",
    "UPLOADED",
    "SOURCE_ID",
    "SOURCE",
    "USERSTATUS_ID",
    "USERSTATUS",
    "ROOTKEY",
    "INDEX",
    "RCALEVEL",
    "DISPLAY_INDEX",
    "ELEMENT_NAME",
    "PARAMETER_NAME",
    "DISPLAY_VALUE",
    "CREATIONTIME",
    "CREATIONTIME_UNIX"
  ],
  "properties": {
    "DOCUMENT_TYPE": {
      "$id": "#/properties/DOCUMENT_TYPE",
      "type": "string",
      "title": "The Document_type Schema",
      "description": "Type of JSON record.",
      "examples": [
        "ALARM"
      ]
    },
    "DMAID": {
      "$id": "#/properties/DMAID",
      "type": "number",
      "title": "The Dmaid Schema",
      "description": "The ID value of the DataMiner Agent generating the record.",
      "examples": [
        "35708"
      ]
    },
    "EID": {
      "$id": "#/properties/EID",
      "type": "number",
      "title": "The Eid Schema",
      "description": "The ID value of the element generating the record.",
      "examples": [
        "240"
      ]
    },
    "PID": {
      "$id": "#/properties/PID",
      "type": "number",
      "title": "The Pid Schema",
      "description": "The ID value of the parameter generating the record.",
      "examples": [
        "145"
      ]
    },
    "ALARMID": {
      "$id": "#/properties/ALARMID",
      "type": "number",
      "title": "The Alarmid Schema",
      "description": "The ID of the alarm record (unique in combination with the DMAID property).",
      "default": "",
      "examples": [
        "1082431"
      ]
    },
    "PREVKEY": {
      "$id": "#/properties/PREVKEY",
      "type": "number",
      "title": "The Prevkey Schema",
      "description": "The ID of the previous alarm in the alarm tree.",
      "examples": [
        "0"
      ]
    },
    "VALUE": {
      "$id": "#/properties/VALUE",
      "type": "string",
      "title": "The Value Schema",
      "description": "Value of the alarm.",
      "examples": [
        "259"
      ]
    },
    "SEVERITY_ID": {
      "$id": "#/properties/SEVERITY_ID",
      "type": "number",
      "title": "The Severity_id Schema",
      "description": "A value indicating the severity of the alarm.",
      "examples": [
        "1"
      ]
    },
    "SEVERITY": {
      "$id": "#/properties/SEVERITY",
      "type": "string",
      "title": "The Severity Schema",
      "description": "A textual description indicating the severity of the alarm.",
      "examples": [
        "Critical"
      ]
    },
    "SEVERITY_LEVEL_ID": {
      "$id": "#/properties/SEVERITY_LEVEL_ID",
      "type": "number",
      "title": "The Severity_level_id Schema",
      "description": "A value indicating the range of the alarm. (5 = no range available.)",
      "examples": [
        "6"
      ]
    },
    "SEVERITY_LEVEL": {
      "$id": "#/properties/SEVERITY_LEVEL",
      "type": "string",
      "title": "The Severity_level Schema",
      "description": "A textual description indicating the range of the alarm. (5 = no range available.)",
      "default": "",
      "examples": [
        "High"
      ]
    },
    "TOA": {
      "$id": "#/properties/TOA",
      "type": "string",
      "title": "The Toa Schema",
      "description": "Date/time when the alarm appeared in the DataMiner System.",
      "examples": [
        "2019-11-25T15:10:00"
      ],
      "pattern": "^(.*)$"
    },
    "TOA_UNIX": {
      "$id": "#/properties/TOA_UNIX",
      "type": "number",
      "title": "The Toa_unix Schema",
      "description": "Unix Date/time when the alarm appeared in the DataMiner System.",
      "default": "",
      "examples": [
        "1574694600"
      ]
    },
    "TYPE_ID": {
      "$id": "#/properties/TYPE_ID",
      "type": "number",
      "title": "The Type_ID Schema",
      "description": "A value indicating the type of alarm.",
      "examples": [
        "10"
      ]
    },
    "TYPE": {
      "$id": "#/properties/TYPE",
      "type": "string",
      "title": "The Type Schema",
      "description": "A textual description indicating the type of alarm.",
      "examples": [
        "New alarm"
      ]
    },
    "OWNER": {
      "$id": "#/properties/OWNER",
      "type": "string",
      "title": "The Owner Schema",
      "description": "User who has taken ownership of the alarm.",
      "examples": [
        ""
      ]
    },
    "STATUS_ID": {
      "$id": "#/properties/STATUS_ID",
      "type": "number",
      "title": "The Status_ID Schema",
      "description": "A value indicating the status of the alarm.",
      "examples": [
        "12"
      ]
    },
    "STATUS": {
      "$id": "#/properties/STATUS",
      "type": "number",
      "title": "The Status Schema",
      "description": "A textual description indicating the status of the alarm.",
      "examples": [
        "Open"
      ]
    },
    "USERCOMMENT": {
      "$id": "#/properties/USERCOMMENT",
      "type": "string",
      "title": "The Usercomment Schema",
      "description": "Comment entered by a user.",
      "examples": [
        ""
      ]
    },
    "UPLOADED": {
      "$id": "#/properties/UPLOADED",
      "type": "string",
      "title": "The Uploaded Schame",
      "description": "Currently not used.",
      "examples": [
        ""
      ]
    },
    "SOURCE_ID": {
      "$id": "#/properties/SOURCE_ID",
      "type": "number",
      "title": "The Source_ID Schema",
      "description": "A value indicating the module that generated the alarm.",
      "examples": [
        "16"
      ]
    },
    "SOURCE": {
      "$id": "#/properties/SOURCE",
      "type": "string",
      "title": "The Source Schema",
      "description": "A textual description indicating the module that generated the alarm.",
      "examples": [
        "DataMiner System"
      ]
    },
    "USERSTATUS_ID": {
      "$id": "#/properties/USERSTATUS_ID",
      "type": "number",
      "title": "The Userstatus_ID Schema",
      "description": "A value indicating the current ownership status.",
      "examples": [
        "19"
      ]
    },
    "USERSTATUS": {
      "$id": "#/properties/USERSTATUS",
      "type": "string",
      "title": "The Userstatus Schema",
      "description": "A textual description indicating the current ownership status.",
      "examples": [
        "Acknowledged"
      ]
    },
    "ROOTKEY": {
      "$id": "#/properties/ROOTKEY",
      "type": "number",
      "title": "The Rootkey Schema",
      "description": "the ID of the original alarm in the alarm's history tree.",
      "examples": [
        "1082431"
      ]
    },
    "INDEX": {
      "$id": "#/properties/INDEX",
      "type": "string",
      "title": "The Index schema",
      "description": "IMPORTANT: If it concerns a dynamic table parameter with “advanced naming” enabled, then this field will contain the primary key instead of the display key.",
      "default": "",
      "examples": [
        "Bristow Group-Lagos BRC-62964"
      ]
    },
    "RCALEVEL": {
      "$id": "#/properties/RCALEVEL",
      "type": "number",
      "title": "The Rcalevel Schema",
      "description": "The proximity of the alarm to the root cause of the problem, i.e. the position of the alarm in the Root Cause Analysis connectivity chain.",
      "default": "",
      "examples": [
        "-1"
      ]
    },
    "DISPLAY_INDEX": {
      "$id": "#/properties/DISPLAY_INDEX",
      "type": "string",
      "title": "The Display_index Schema",
      "description": "If the alarm is associated with a cell of a dynamic table with “advanced naming” enabled, then this field will contain the display key.",
      "default": "",
      "examples": [
        "Bristow Group-Lagos BRC-62964"
      ]
    },
    "ELEMENT_NAME": {
      "$id": "#/properties/ELEMENT_NAME",
      "type": "string",
      "title": "The Element_name Schema",
      "description": "The name of the DataMiner element object that generated this record.",
      "examples": [
        "FST_IS1002_N1_IDRCT_EH_EH"
      ]
    },
    "PARAMETER_NAME": {
      "$id": "#/properties/PARAMETER_NAME",
      "type": "string",
      "title": "The Parameter_name Schema",
      "description": "The name of the DataMiner parameter object that generated this record.",
      "default": "",
      "examples": [
        "Remote QoS Downstream Requested Bristow Group-Lagos BRC-62964"
      ]
    },
    "DISPLAY_VALUE": {
      "$id": "#/properties/DISPLAY_VALUE",
      "type": "string",
      "title": "The Display_value Schema",
      "description": "Value in text format.  Example: If, in case of a discrete parameter, Value is 0, then chDisplayValue could contain “False”, i.e. the meaning of that value in text for­mat.",
      "examples": [
        "259"
      ]
    },
    "CREATIONTIME": {
      "$id": "#/properties/CREATIONTIME",
      "type": "string",
      "title": "The Creationtime Schema",
      "description": "Date/time when the alarm was generated.",
      "default": "",
      "examples": [
        "2019-11-25T15:10:00"
      ]
    },
    "CREATIONTIME_UNIX": {
      "$id": "#/properties/CREATIONTIME_UNIX",
      "type": "number",
      "title": "The Creationtime_unix Schema",
      "description": "Unix Date/time when the alarm was generated.",
      "default": "",
      "examples": [
        "1574694600"
      ]
    },
    "ELEMENT_PROPERTIES": {
      "$id": "#/properties/ELEMENT_PROPERTIES",
      "type": "null",
      "title": "The Element_properties Schema",
      "description": "Extra (optional) element property objects that can be added to the record"
    }
  }
}
```
