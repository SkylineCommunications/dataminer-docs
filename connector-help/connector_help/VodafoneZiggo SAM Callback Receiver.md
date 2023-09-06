---
uid: Connector_help_VodafoneZiggo_SAM_Callback_Receiver
---

# VodafoneZiggo SAM Callback Receiver

This connector is responsible for updating the Incident ID property on alarms of the SAM system. The incident ID and the associated alarm ID are sent to the connector from an external ticketing system.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                     | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Updates Incident ID property on alarms.Displays a log of the latest JSON messages received from the external system. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No additional actions need to be taken after creating an element.

### Redundancy

There is no redundancy defined.

## How to use

You can find all the information needed to monitor incoming messages on the **General** data page.

The connector expects JSON messages to be written to the parameter with **ID 2**. The JSON messages must have the following structure:

{ 'IncidentID': \<string with incident id\>, 'AlarmID': \<string with the alarm ID with the following format: AgentID/AlarmID\>}

For example:

{ 'IncidentID': 'VZINC0006', 'AlarmID': '305/269767'}
