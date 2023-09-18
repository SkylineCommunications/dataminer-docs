---
uid: Connector_help_CEFD_Memotec_HX_Load_Balancer_SNMP
---

# CEFD Memotec HX Load Balancer SNMP

The **CEFD Memotec HX Load Balancer SNMP** connector can be used to monitor and control the CEFD Memotec HX Load Balancer.

## About

The connector uses **SNMP** to retrieve data from the **load balancer** and configure parameters of the device, and can also receive traps notifications.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                               |
|------------------|-----------------------------------------------------------|
| 1.0.0.x          | 1.2.28-201805012049E4.x86_64 1.2.59a-201806191849N4x86_64 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general (read-only) information on the device, such as the **Serial Number**, **Firmware Version**, **Current Time**, **License Info**, etc.

### Admin

This page contains configuration parameters for the device, including the **SNMP Configuration**, **Time**, **Host/DNS** and **Web Management Interface** settings.

### Admin Networking

On this page, you can configure network administration parameters for both **Management** and **Auxiliary** interfaces, including a **Routes Table** (for the management interfaces) and **Hosts Table** (for both interfaces). There are two buttons to add routes and hosts to these tables.

- The **Add Route** subpage allows you to add a new route to the **Routes Table**. To add a new route, the following parameters are required: **Destination Network**, **Destination Mask** and **Gateway**.
- The **Add Host** subpage allows you to add a new host to the **Hosts Table**. To add a new host, the following parameters are required: **IP Address**, **Fully Qualified Name** and **Short Name**.

### Interfaces

This page displays an overview of all the available interfaces in the **User Ports Table** and **Balancing Ports Table**.

For each of these tables, the following parameters can be configured: **Port Name, Port State, MTU, Speed** and **Flow Control**.

### Load Balancing

On this page, you can manage load balancing features, using the **Load Balancing Options** parameters and the **Load Balancing Ports Settings** table.

The **Load Balancing Port Settings Table** allows you to configure the following parameters: **Maximum Data Rate**, **SNMP Polling State**, **Polling Device Type**, **Device 1 IP Address**, **Device 2 IP Address** and **SNMP Poll Community**.

### Advanced - Settings

On this page, you can configure advanced settings like the **Path Redundancy**, **Flows** and **Load Balancing Ports Continuity Check**.

- The **Path Redundancy** includes the **User Traffic Analysis Period** and the **Period to Skip After Switch**.
- The **Flows** parameters include the **Flow Aging** **Period** and the **Round Robin Assignment**.
- The **Load Balancing Ports Continuity Check** includes the **Probe Period** and **Probes Lost for Failure**.

### Advanced - Redundancy

This page contains advanced configuration settings for redundancy features, including **Device Redundancy, Host/DNS Settings, Auxiliary Interface** and **Host Entries**:

- The **Device Redundancy** parameters include the **Redundancy State, Primary Appliance, Secondary Appliance, Authentication Key** and **Automatic Synchronization**.
- The **Host/DNS** settings include the following parameters: **Host Name** and **Domain**.
- The **Auxiliary Interface** parameters include **DHCP**, **IP Address** and **Mask**.
- The **Host Entries** parameters include the **Description, IP Address, Host Long Name** and **Host Short Name**.

### Status - Interfaces

This page contains three tables with information about the status of all the available interfaces: the **User Interfaces Status,** **Balancing Interfaces Status** and **Management and Auxiliary Port Status** tables.

For each table, the following parameters are displayed: **Port Name, Status, Speed, Flow Control, MTU** and **MAC Address**.

### Statistics - Interfaces

This page contains a detailed statistics overview for all the available interfaces of the device. The information is displayed in two tables: **User** **Interfaces Statistics** and **Balancing Interfaces Statistics**.

For each table, the following parameters are displayed: **Received Packets, Received Bytes, Received Errors, Transmitted Packets, Transmitted Bytes, Transmitted Errors, Dropped Packets**, etc.

### Statistics - Throughput

This page displays statistics about the throughput for all the available interfaces. This information is displayed in two tables: **User** **Interfaces Throughput** and **Balancing Interfaces** **Throughput**.

### Statistics - Redundancy

This page contains a summary of redundancy settings of the device. It includes the following parameters: **Host Name, Primary Appliance, Secondary Appliance, Redundancy State, Path Redundancy State, Auxiliary Port Status, Number of In and Out Bytes** and **Current Active User Ports**.

### Operations

This page contains controls to reset or clear some of the device settings.

It includes a set of buttons that allow you to perform the following operations: **Reset HX Load Balancer Hardware**, **Restart Load Balancing Service**, **Reset Flow Assignments**, **Clear Load Balancing Statistics** and **Reset the Device Configuration** to the fabric default values.

### Notifications (Traps)

This page contains the **Traps Table**, with information about the incoming trap notifications, as well as controls to manage trap parsing to this table.

Note: **Traps** **related to load balancer settings are not stored in the table**. Instead, these trigger the polling of specific parameters.

The following table displays the traps that are processed by this protocol:

| **Trap**                                                                                      | **OID**                      | **Balancer Setting** |
|-----------------------------------------------------------------------------------------------|------------------------------|----------------------|
| The unit is starting following power-up or reboot.                                            | 1.3.6.1.4.1.6247.78.10.2.1   | No                   |
| One or more cores in the unit has exceeded its maximum temperature threshold.                 | 1.3.6.1.4.1.6247.78.10.2.2   | No                   |
| The FX-WOC acceleration service has started.                                                  | 1.3.6.1.4.1.6247.78.10.2.31  | No                   |
| The FX-WOC acceleration service was restarted because of a software fault.                    | 1.3.6.1.4.1.6247.78.10.2.32  | No                   |
| The FX-WOC has incompatible configuration settings.                                           | 1.3.6.1.4.1.6247.78.10.2.33  | No                   |
| The FX-WOC has shut down WCCP because of excessive connection errors to content servers.      | 1.3.6.1.4.1.6247.78.10.2.34  | No                   |
| The FX-WOC has abnormally restarted the Multicator service.                                   | 1.3.6.1.4.1.6247.78.10.2.35  | No                   |
| The FX-WOC has experienced an unexpected drop from the WCCP service group.                    | 1.3.6.1.4.1.6247.78.10.2.36  | No                   |
| The FX-WOC is nearing its active flow capacity.                                               | 1.3.6.1.4.1.6247.78.10.2.37  | No                   |
| The FX-WOC has gone into bypass.                                                              | 3.6.1.4.1.6247.78.10.2.38    | No                   |
| The FX-WOC acceleration service is restarting because an invalid internal state was detected. | 3.6.1.4.1.6247.78.10.2.39    | No                   |
| The FX-WOC sends this out to diagnose the sending of SNMP traps.                              | 3.6.1.4.1.6247.78.10.2.40    | No                   |
| The SNMP notification indicating a user port modification.                                    | 1.3.6.1.4.1.6247.78.11.1.0.1 | Yes                  |
| The SNMP notification indicating a user port status change.                                   | 1.3.6.1.4.1.6247.78.11.1.0.2 | Yes                  |
| The SNMP notification indicating a balanced port status change.                               | 1.3.6.1.4.1.6247.78.11.1.0.3 | Yes                  |

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

21/03/2018 1.0.0.1 HPE, Skyline Initial version
