---
uid: Connector_help_TDF_Incident_Ticketing
---

# TDF Incident Ticketing

The TDF Incident Ticketing connector is used in the TDF ServiceNow ticketing solution as a gateway to communicate with the ServiceNow service.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **General** page, you will need to specify the credentials to access the ServiceNow service and the custom parameters that should be sent in the incident query.

### Redundancy

There is no redundancy defined.

## How to use

The Ticketing solution for the TDF Shortwave Radio Project uses the ServiceNow Ticketing feature.

Each time an alarm appears in the DataMiner Alarm Console, you can right-click it and select the option **ServiceNow** \> **Create Ticket** to trigger the **TDFServiceNowCreate** Automation script (for this feature, the Hyperlinks.xml file must be edited).

This Automation script will try to link the selected alarm to the corresponding booking. If the booking is not found, the script will list the bookings for that day and give the option to select the booking.

You can then edit some parameters, and when you confirm the ticket creation, the **TDF Incident Ticketing** will create a new ticket in ServiceNow by sending a POST action (Incident Query). The reply will contain the ticket number, which will be added in the alarm property **ServiceNow Ticket**.
