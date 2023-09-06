---
uid: Connector_help_Village_Island_Flexviewer
---

# Village Island Flexviewer

Village Island Flexviewer is responsible for monitoring every stream (audio, video and others) that is available through the multiviewer device. It also captures alarms and receives the traps related to those alarms.

## About

A minimum version (10.0.3.0 - 8964) is required for this connector.

Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.1   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (default: *162*)

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (default: *8000*)

### Web Interface

There is a Web Interface to the device available. The IP corresponds to the polling IP in the element wizard and the port is saved in parameter 50 (8070).

## How to use

- **General Page:** Contains application and licenses information.
- **Sources:** Displays all active sources and their details.
- **Elementary Streams:** Holds the information about every type of elementary stream (audio, video, other).
- **Alarms:** Contains all the "active" and "past" alarms of the last 5 seconds.
- **Traps:** Displays the traps received and their bindings. The oldest traps can be deleted by either considering a maximum number of traps in the table or after a user-defined time has passed since their reception.
