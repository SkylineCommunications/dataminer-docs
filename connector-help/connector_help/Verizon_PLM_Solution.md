---
uid: Connector_help_Verizon_PLM_Solution
---

# Verizon PLM Solution

The Verizon PLM Solution is a DataMiner connector used to manage resource reservations representing the Verizon platform PLM activities.

## About

The Verizon System contains a series of platform resources (i.e. Circuit, NMS, Hub Network, Line Card, Chassis, etc.) that require the systematic scheduling of maintenance activities. For this purpose, the DataMiner SRM module is used, specifically to create resource reservations.

This Solution allows interaction with planned maintenance (PLM) activities associated with platform resources. Each resource with at least one PLM item (activity) scheduled is placed in the PLM-POOL and treated as a PLM resource. All scheduled PLM items are linked to this one PLM resource. The scheduling of PLM items is done using the SRM resource reservation capabilities.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays an overview of the system, including the number of **Active, Scheduled, Completed** and **Total** PLM activities.

### PLM

With this connector, PLM items can be retrieved in order to be displayed in the **PLM Overview** table. A get operation will retrieve all reservations associated with all PLM resources in the PLM-POOL.

Get operations will happen:

- After startup, if PLM Status is *Enabled* in the Configuration section
- Based on the PLM timer, if PLM Status is *Enabled* in the Configuration section.
- When the **Update** button is pressed in the Configuration section.

The Solution allows you to create PLM items directly from the connector interface. The following workflow can be used to create a PLM item:

1. Right-click and select **Add PLM** in the context menu.

1. Fill in the following fields in the pop-up window:

   - Title: The title of the PLM item.
   - Start date and time
   - End date and time
   - Resource: The resource name to assign the PLM item to.
   - Resource Type: The type associated with the resource.

The Solution also allows you to delete PLM items directly from the connector interface. This is possible via the context menu, using the following options:

- Delete Item(s)
- Delete All Completed
- Delete All

For all delete operations, a confirmation box will be displayed.

### Configuration

This page displays the **Configuration** options, including **Polling Status, Auto-Delete Status** and **Auto-Delete Delay**.

## Revision History

DATE VERSION AUTHOR COMMENTS
13/11/2018 1.0.0.1 AIG, Skyline Initial version
