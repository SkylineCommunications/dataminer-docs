---
uid: Connector_help_RAD_Data_Communications_ETX-203AX
---

# RAD Data Communications ETX-203AX

This connector can be used to monitor RAD ETX-203AX modems via SNMP.

## About

### Version Info

| **Range**            | **Key Features**                                                | **Based on** | **System Impact**                                                                                                     |
|----------------------|-----------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | SNMP polling.                                                   | \-           | \-                                                                                                                    |
| 1.0.1.x \[Obsolete\] | DCF compatibility.                                              | 1.0.0.4      | \-                                                                                                                    |
| 1.0.2.x \[Obsolete\] | Additional columns in Service Stats table and Interfaces table. | 1.0.1.3      | Impact on custom reports or scripts calling Service Statistics or Interfaces table IDX or displayed columns directly. |
| 1.0.3.x \[SLC Main\] | Subtable filtering on Alarm Event Log table                     | \-           | Impact on custom reports or scripts calling Alarm Event Log displayed columns directly via IDX.                       |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | /                      |
| 1.0.1.x   | /                      |
| 1.0.2.x   | /                      |
| 1.0.3.x   | /                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page contains general information about the device, such as the **System Uptime**. On the **System** and **Physical Entities** subpages, you can find further information about system parameters and software versions. There are also subpages for the **Ports**, **SNMP** and **SNTP** configuration

### Interfaces

This page contains a list of all the device interfaces. When a lot of interfaces are available, you can filter the list to reduce SNMP load via the subpage **Interface Filtering**.

Switching between filtered and full polling can be done by toggling **Interface Polling Mode**. Full polling will always poll the full interface table. Filtered polling will take into account the filters from the Interface Filtering subpage.

These filters can be added manually, but they can also be provisioned by managing elements via InterApp. **Filter Update Mode** can be set to select whether filters will be added manually by a user or should be provisioned from another source. Please note that it is not possible to use both filter update modes at the same time. Provisioning will be blocked in *Manual* mode and no manual actions are possible in *Provision* Mode

### Radius Authentication

This page shows the configuration table for the **Radius Authentication Server**.

### Services

This page shows a list of services on the device, with information about bit rates and discard rates for each service.

### Flow

This page contains a table that lists the flows in the device. By default, this table will poll nothing. You can set up polling by adding regex filters on the **Flow Table Filter** subpage. The table will only poll entries for which the flow name matches one of the regex filters. Multiple regex filters can be imported at the same time in a .txt file, containing one regex filter per line.

### Ethernet

This page contains the **Ethernet OAM Service** and **Ethernet OAM Service Intervals** tables.

### Traps

This page lists **Trap Destinations** with the corresponding settings.

### Connectivity Fault Management

This page contains multiple tables regarding CFM on the device.

### Alarms

This page shows a list of the **Active Alarms** on the device and the **Alarm Attributes**.

### DCF

This page contains a list of DCF physical interfaces based on the list of device interfaces on the **Interfaces** page. These are the interfaces of type Ethernet CSMACD and SHDSL.

By default, the DCF Table keeps all the interfaces it received even after they have been removed; however, if the filter from the **Interface Filtering** subpage is used, it will also affect the interfaces available to DCF.

Activating or deactivating filter mode will disconnect all DCF connections.

In addition to the interfaces, DCF will also show items from the **Flow** table.
