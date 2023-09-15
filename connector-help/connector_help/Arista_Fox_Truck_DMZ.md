---
uid: Connector_help_Arista_Fox_Truck_DMZ
---

# Arista Fox Truck DMZ

The Arista Fox Truck DMZ is a custom connector that is designed to interact with FOX Arista Switches in a **demilitarized zone** (DMZ).

## About

The DMZ switches (Arista Manager) have been provided with **custom scripts by FOX**. These scripts have different functions and are unique to FOX. The goal of this connector is to allow the execution of these scripts from DataMiner via JSON and then process the response.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *80*
- **Bus address**: *ByPassProxy*

## Usage

### General

This page allows you to configure the credentials to establish HTTP communication.

On the **Configuration** subpage, you can configure the following parameters:

- **JSON RPC**, **JSON Command ID** and **JSON Version**: These parameters are intended to make sure that the correct values are used in the JSON request, so that these do not need to be hard-coded in the logic of the connector.
- **Command Interval*:*** This parameter determines the frequency at which the sequential buffer containing the truck's information is sent through the **vantruck show TruckName** command. By default, this is set to 10 seconds to avoid flooding the device.
- **Debugging Message Status**: By default, this parameter is disabled, which means that any extra logging messages will not be added to the element log. However, in case you encounter issues with this connector, it may be useful to enable this parameter in order to add these messages to the log.
- **Commands Forwarding State**: Enable this parameter in order to forward commands executed on this element to the element(s) configured with the Target Element(s) parameter.
- **Target Element(s):** Set this parameter to the DMA ID/element ID or element name of the elements to which the commands executed on this element should be forwarded if the parameter above is enabled.

### Command Line

On this page, you can specify a command in the **Command** box and check the value that was sent and its response.

### Venues

This page contains a table listing all the current venues. If an entry has been removed, you can remove it manually in the table.

### Trucks

This page contains a table listing all the trucks, with the venues that the trucks can be connected to. In the table, you can enable or disable a truck for a particular venue, enable the **Cascade**, and update the truck Information using the **Refresh** button. Any truck that has been deleted can be deleted manually in the table. The table also contains other information such as the **Interface Name and Description**, **Interface In and Out Speed**, **VLAN Status**, **LLDP Neighbor** and **Last Update**.

NOTES:

- To select a venue while the **Venue Name** is already present in the Venue column, the **Cascade** option needs to be enabled.

- It is not possible to enable a truck for a venue while it is **Connected** or to disable it while it is **Disconnected**.

- If you click the **Enable** or **Disable** button to connect or disconnect a truck with a venue, the venue must not be empty.

- There is a hidden parameter (Northbound Receiver, with ID 18), which allows forwarding of commands to the DMZ switches. These are the commands that can be forwarded:

  - vantruck enable *truckName venueName*
  - vantruck disable *truckName venueName*
  - vantruck enable cascade *truckName venueName*
  - vantruck show *truckName*

### Audit

On this page, you can find a table that logs every command performed with the connector. It includes the timestamp when the command was executed, the status of the response and the message itself, as well as the name of the user who executed the command.

Via the **Auto Clear** page button, you can configure the automatic cleanup of the table, using the following parameters:

- **Auto Clear**: Use this parameter to enable or disable automatic cleanup.
- **Clean up Method**: Allows you to select if automatic cleanup should happen based on *Row Count*, based on *Row Age,* or based on a combination of both.
- **Maximum Rows**: Allows you to set the maximum number of rows to a number ranging from 10 to 2000 rows.
- **Clean Up Amount**: Allows you to set the number of rows that should be removed when the maximum has been reached to a number ranging from 5 to 1500 rows.
- **Maximum Age**: Determines the maximum age rows can have before they are removed, depending on the cleanup method.
