---
uid: Connector_help_AppearTV_Telenet_Light
---

# AppearTV Telenet Light

This driver allows you to monitor and control an AppearTV chassis. It displays an overview of configuration and status data for descrambler, input QAM and output QAM, as well as an overview of the active alarms.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.10 3.22              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the first controller.
- **IP port**: *80*
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## How to Use

This element consists of the following data pages:

- The **General page** contains the Module List table, which shows an overview of the implemented modules (cards) in the chassis.
- The **Alarms page** shows an overview of the active alarms.
- For each card type (Descrambling, Input QAM, Output QAM), there is a separate page that shows the **configuration and status data** for the corresponding cards.
- The **Output Status** page shows an overview of the services of the output slots.

## Notes

-  If the **status for a row is disabled in the configuration table**, there will be **no corresponding row in the status table.**
  If there is no status data for a certain module (i.e. the status table is empty), check in the configuration table of that module whether the status parameter for the corresponding row has been set to enabled.
- When the element has just been **restarted**, it is possible that the settings are carried out with a **delay.**
  After the element is restarted, first all queries are performed (configuration queries, status queries, alarm queries). Once all configuration queries have been executed, there is less communication with the device and settings should be implemented faster. At this point, only status queries (every 60 s), alarm queries (every 30 s) and a last update time check (every 30 s) are performed.
- **SOAP polling alarms** are always logged in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\****History****\alarmsHistory\_\[yyyyMMdd\].txt*.
- **SOAP responses** are only logged in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\****SOAP Responses****\get\_\[\].xml* if the parameter **Log SOAP Responses is enabled** (on the General page). The number after the underscore in the name of the command refers to the controller card (1 = main controller card, 2 = backup controller card) (e.g. getService\_**1**.xml)

## Implemented modules

### Input Modules

**INPUT QAM, INPUT DVB-C-IN**
\*SC/4QAM-MMI, \*DC/4QAM-MMI

### Output Modules

**OUTPUT QAM**
\*SC/16QAMOUTMX, \*DC/16QAMOUTMX

**OUTPUT QAMOUT-A**

**BULKDSCR-LATENS**
\*SC/BDESC25, \*SC/BDESC50, \*SC/BDESC100,
\*SC/BDESC150, \*SC/BDESC200, \*SC/BDESC250

**DESCRAMBLER**
\*SC/2C1
