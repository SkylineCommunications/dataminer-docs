---
uid: Connector_help_Generic_Truck_Manager
---

# Generic Truck Manager

This is a virtual connector that can be used to manage and monitor trucks.

## About

The truck manager is capable of creating and editing existing truck properties. You can manually connect or disconnect trucks from a venue through a single interface to facilitate the monitoring of all existing trucks. The manager can also automatically detect if a truck is connected or disconnected to a venue via the switch LLDP.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

When the element has been created, several parameters on the **Configuration** page need to be configured before it can be used.

## Usage

### Trucks and Venues

This page contains the **Trucks Overview** table and **Venues** table, which list all existing trucks and venues. There is also a **Refresh** button, which can be used at any time to gather the latest information. This includes information on trucks, venues, switches and the sync with external elements. The **Add New Truck** page button is also located here, and will open a window where you can specify the details for a new truck/view.

### Switches

This page contains the Switches table, which lists the Arista switches inside any truck. The table contains information about each switch, such as the element ID, the parent view ID, and the System Name parameter of that element.

### Audit Trail

This page displays the Audit Trail table, which contains a log of all actions that have taken place on the manager.

### Configuration

This page contains all the parameters that need to be configured, such as **Parent Truck** and **Venue ID** and **Name**, **Default Visio File Name** for new and existing trucks, and the **DMA/Element ID** of both DMZ switches.
