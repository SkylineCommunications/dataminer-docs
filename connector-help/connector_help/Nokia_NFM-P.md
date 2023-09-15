---
uid: Connector_help_Nokia_NFM-P
---

# Nokia NFM-P

Nokia NFM-P connector is used by Kordia to track the alarm events in the NFM-P network via XML API and JMS subscription. The XML API is an NFM-P interface that provides an XML interface ot the NFM-P through which an OSS client application can retrieve NFM-P network management information, receive event notifications from the NFM-P server using a persistent or non-persistent JMS connection.

## About

### Version Info



| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Not applicable         |

### System Info

Style: Heading 3 Accent 1

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections



#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

In addition to the above HTTP settings, All the arguments in the JMS Configuration page has to be provided in a newly created element.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector uses SOAP calls to retrieve the device information and JMS connection to receive alarm events.

- You can find the system relation information on the **General** paga of this connector. JMS Connection parameter shows the status of the connection, if it is Active or Inactive.
- The **JMS Configuration** page contains the mandatory input arguments that must be provided to establish a JMS connection.
- On the **Alarms** page, you can find the list of alarms in the Alarm Events table. There is a Refresh button on the same page that can be used to get all alarms on the NFM-P main server and refresh the Alarm Events table. Note: Since the volume of the alarms might be high, this can have a performance impact on the system, if triggered frequently.
- The **Events Received** page displays a table which temporarily stores the event messages before processing them. Note: It is a volatile table and hence trending and alarming cannot be enabled.


