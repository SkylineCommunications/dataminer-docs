---
uid: Connector_help_LTN_Crystal_VMA_SCTE_Monitor
---

# LTN Crystal VMA SCTE Monitor

Crystal VMA (Video Metadata Analyzer) is a diagnostic and monitoring probe used to extract, log, and analyze metadata and ancillary data in video streams. The purpose of the VMA SCTE Monitor connector is to receive, store, and process SCTE 104 or SCTE 35 event markers and optionally define thresholds to generate alarms when certain limits are exceeded.

## About

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact**  |
|----------------------|---------------------|--------------|--------------------|
| 1.0.0.x              | Initial version     | \-           | \-                 |
| 1.0.1.x \[SLC Main\] | Display SCTE Events | 1.0.0.5      | Hides logger table |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart - Serial Connection - IP Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination. If you specify "any" as the host address, DataMiner listens on all IP addresses on the specified port.
  - **IP port**: Default: *8080*.
  - **Accepted address**: Allows you to specify one or more allowed IP addresses for the connection. The element will then only communicate with those IP addresses. This configuration makes it possible for several elements to listen on the same port but communicate exclusively with a different set of IPs.

### Initialization

On the **SCTE Events** page, check the configuration of the **SCTE Mode**. By default, the mode is initialized with **SCTE 104**. Based on the selected mode, the element will try to map the received events as SCTE 35 or SCTE 104 events.

## How to Use

Once the element has been created, the received VMA SCTE events will be added to the **VMA Event Table** on the General page. This table will list up to 1000 events, depending on the maximum number of events configured (range: 10 to 1000).

The received events will be mapped based on the selected **SCTE Mode**. The **SCTE Events** table will contain the mapped events and log these in Elasticsearch for additional processing (PID 8000000).

The element will listen for HTTP messages of type POST with route /Message. A reply will be sent to Crystal VMA. On the **Debug** page, you can check a received message and its response. Errors in the processing will be reported to Crystal VMA and logged.
