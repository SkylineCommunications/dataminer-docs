---
uid: Connector_help_Grass_Valley_sQ_1000_Server
---

# Grass Valley sQ 1000 Server

The **Grass Valley sQ 1000 Server** connector is used to monitor the Grass Valley sQ 1000 series media servers.

The Grass Valley sQ 1000 series media servers are SD/HD/4K UHD media servers for news and sports editing, replay and playout. These servers are intelligent, scalable and media-optimized storage systems, delivering sustained multi-year 24x7 operation for high-pressure fast-turnaround workflows for news and sports.

## About

This connector uses an **SNMPv1** interface to communicate with a **Grass Valley sQ 1000 Server** device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element configuration:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays generic **system information** and **status** parameters such as the system version, the system status, the crate temperature, the power supply status and the CPU load on each of the system core processors.

### Interfaces Page

This page displays a table containing **statistics** for each of the **system interfaces**.

### Cards Page

This page displays a table with (status) information on each of the system slot cards.

### Video Page

This page contains the following two tables:

- The **Video Channel** table, which contains **statistical performance information** related to the video channels available in the system.
- The **Video Disk Enclosure** table, which contains **status information** on the system video disk enclosures.

### Clipnet Page

This page displays **performance** **indicators** related to the **Clipnet system ports**.

The reset button at the top of this page can be used to restart all Clipnet-related counters.

### Traps Page

The **Active Trap Events** table on this page displays the metadata related to the **current events in the system that can trigger alarms**, such as an ongoing slot fault situation, etc.

### Web Interface

This page can be used to access the device web user interface. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the user interface.
