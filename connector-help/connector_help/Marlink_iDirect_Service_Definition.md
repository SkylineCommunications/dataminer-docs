---
uid: Connector_help_Marlink_iDirect_Service_Definition
---

# Marlink iDirect Service Definition

The **Marlink iDirect Service Definition** will retrieve GPS coordinates and key parameters from the iDirect remote included in the service.

## About

In each service element, there is an overview available for the GPS coordinates in the GPS Trace table, and key parameters are added to each row.

Every 30minutes, the GPS Table will be updated with current Longitude and Latitude values and also when the "Service Severity" has changed.

The **iDirect Platform Virtual** elements, are DVE elements created by the **iDirect Platform** connector.

## Installation and configuration

### Creation

You need to create a new service and in the advanced section of the wizard, the service definition needs to be selected.

**Service:**

- **Service Definition**: Select this service definition.
- **Elements**: included elements*.*

## Usage

The **Service** contains4 pages:

- **General**: Shows the service severity state and latest GPS coordinates
- **GPS**: Shows the GPS trace table
- **Admin**: Shows a table of all included elements and their service state
- **General Parameters**: Shows internal general parameters.
