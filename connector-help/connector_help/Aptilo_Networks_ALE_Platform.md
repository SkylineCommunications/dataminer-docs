---
uid: Connector_help_Aptilo_Networks_ALE_Platform
---

# Aptilo Networks ALE Platform

The **Aptilo Networks ALE Platform** is used to monitor the ALE Architecture. This is a purpose-built carrier-grade system for control of billing, user services and access in wireless networks. Monitoring is possible via the Management Layer, which is connected to the three functional ALE Architecture layers. The layered architecture supports high scalability, availability and flexible geographical deployment while providing an efficient, centralized operational interface for the system administrators.

## About

The **Aptilo Networks ALE Platform** protocol is used to monitor the services via **SNMPv2**. SNMP **Get** commands are used to read information from the device. The connector also receives unsolicited messages from the device via SNMP **Traps**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | ALE 4.1 build 41324         |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.1.15.6*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Authentication

This page displays information about the authentication, including a trap that indicates if the authentication service is down.

### Statistics

This page displays the **Request & Response Rate** for both the **Radius Accounting** and the **Radius Authentication.**

### Core

This page displays two tables with information related to the **Core Services** and the **Disk Partitioning** respectively.

### Database

This page displays all the information about the **Databases**.

### Backup

This page displays all the information regarding the **Backup**.

### Policy

This page contains custom-designed counters specific for a customer solution.

### Call Data Records

This page contains all the information about the **Call Data Record** generation by the system.

### CDR Sessions

This page displays the **CDR Events** table.

With the **FTP Connection** page button, you can configure the **FTP Connection Settings**. Those **FTP Connections Settings** include a parameter that enables/disables the polling of the FTP Server. By default, this is *Disabled*. As soon as it is *Enabled*, polling will start, but only if all the other parameters were entered corrrectly (username, password, folder). As such, it is recommended to enter all the settings before enabling FTP polling. The **IP address** at startup is the IP address of the element (sometimes the FTP's IP address is the same as the element's IP). If it is different, change the IP address to the correct address. The **Polling Time** denotes how frequently the FTP server will be polled in order to retrieve the required number of records. The **Record Time Span** determines how much information all the records contain (by default this is set to 5 minutes of events).

With the **Old Records** page button, historic data can be retrieved from the FTP Server.

### System

This page contains general information about the system, including the **interfaces**.

### IP

This page contains all the information about the **routing**, the **IP interfaces**, **IP addresses**, etc.

### ICMP

This page displays two tables, containing the **Generic System-Wide Counters** and **System-Wide Per-Version-Message Counters** respectively.

### TCP

This page contains all the information regarding the **TCP** communication.

### UDP

This page contains all the information regarding the **UDP** communication.

### SNMP

This page displays all the **incoming and outgoing packet data.**

### Host

This page contains information about the **Uptime**, **Memory Size** and **Storage**.

### Radius

This page contains information about the **Authentication** **Server** and the **Accounting** **Server**.
