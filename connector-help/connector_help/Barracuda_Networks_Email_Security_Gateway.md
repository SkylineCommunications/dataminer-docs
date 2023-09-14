---
uid: Connector_help_Barracuda_Networks_Email_Security_Gateway
---

# Barracuda Networks Security Email Gateway

The Barracuda Email Security Gateway is an email security gateway that manages and filters all inbound and outbound email traffic to protect organizations from email-borne threats and data leaks.

## About

This connector uses an **SNMP** connection to retrieve the status of the gateway.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.1                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device. (Default: *161)*.
- **Get community string**: The community string used when reading values from the device. (Default: *public)*.
- **Set community string**: The community string used when setting values on the device. (Default: *private*.

## Usage

### General Page

This page displays the default system parameters included with every SNMP device.

### Inbound Messages Page

This page displays individual parameters related to **blocked**, **quarantined**, **allowed**, and **rate controlled incoming emails**.

### Outbound Messages Page

This page displays the individual parameters related to **blocked**, **encrypted**, **quarantined**, **rate controlled**, **redirected**, and **sent outgoing emails**.

### Performance Page

This page displays performance statistics such as **storage**, **queue size**, **average latency**, **load**, **temperature**, and **last message delivery**.

### System Statistics Page

This page displays individual system statistics parameters provided in the UCD-SNMP MIB file.

### Load Average Page

This page displays the **Load Average** table, which provides information for 1-min, 5-min, and 15-min system load averages.

### Disk Page

This page displays the **Disk Information** table, which includes information about remaining and used disk space.

### Memory Page

This page displays individual memory parameters such as **real memory**, **swap space**, **shared memory**, **swap memory** and **cached memory**.

### Interfaces Page

This page displays a table with the state and statistics of the interfaces available in the email gateway.

### Extensible Commands Page

This page displays a table of extensible commands returning output and result codes. These commands are configured via the agent's **snmpd.conf** file.
