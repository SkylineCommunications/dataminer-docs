---
uid: Connector_help_KPN_Digitenne_Overview_Manager
---

# KPN Digitenne Overview Manager

This connector is used to aggregate the status of the different streams and locations in the digitenne network. It also shows a table listing all the outages generated on the digitenne network of KPN (critical alarms on transmitter level).

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

If a **prefix** is defined on the **General** page, all the **Function** **properties** need to have this prefix on the services that need to be monitored (e.g. "DVB Encoding" for an encoding service if the prefix is set to DVB).

The **services** that need to be monitored need to have the **Function**, **Service ID**, and **Stream ID**property. For the services that are located in a transmitter location, the **Location** property needs to be used to provide info on the location.

## How to Use

On the **Streams**, **Services**, and **Locations** pages, you can find the aggregated status based on all the monitored services.

The **Encoding**, **Multiplexing**, **WEAS** **MCC**, **Location** **RX**, and **Location** **TX** pages contain all the monitored services (filled in based on the services found in the system with the appropriate **Function** property).

The **Outage** page contains a table listing all the outages.
