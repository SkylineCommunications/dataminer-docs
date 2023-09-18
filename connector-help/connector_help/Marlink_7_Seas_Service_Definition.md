---
uid: Connector_help_Marlink_7_Seas_Service_Definition
---

# Marlink 7Seas Service Definition

## About

The **Marlink 7 Seas Service Definition** will retrieve key parameters from the on-shore modem included in the service. The on-shore modem is identified by its **property "Installation Name"** which is not an empty string.

There is an overview available for the GPS coordinates in the GPS Trace table.

## Installation and configuration

### Creation

You need to create a new service and in the advanced section of the wizard, the service definition needs to be selected.

**Service:**

- **Service Definition**: Select this service definition.
- **Elements**: included elements*.*

### Timing

All data from the **active on-shore modem** gets retrieved from the device using a 5min timer and when the service receives a status change from the element.

Every 30minutes, the GPS Table will be updated with current Longitude and Latitude values and also when the "Service Severity" has changed.

### Usage

The **Service** contains4 pages:

- **General**: Shows the service severity state
- **Active On-Shore Modem**: Shows the key parameters from the modem
- **Admin**: Shows a table of all included elements and their service state
- **General Parameters**: Shows internal general parameters.
