---
uid: Connector_help_Audemat_Aztec_FMB80
---

# Audemat Aztec FMB80

The Audemat Aztec FMB80 is a full-featured dynamic RDS/RBDS encoder designed to bring convenience and ease of use to RDS datacasting.

## About

This connector uses **SNMP** to manage the Audemat Aztec FMB80 encoder.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                    |
|------------------|----------------------------------------------------------------|
| 1.0.0.x          | Application Software Version RDS5002.8 System Version ECI2691L |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information such as **Description**, **Object ID**, **Up Time**, etc.

The page also contains the **Poll Parameters** toggle button, which allows you to enable or disable polling of all the parameters using the slow timer.

### Equipment Info

This page displays basic information about the device, such as the **Name**, **Serial Number**, **System Date**, **Time** and **Day**.

### Event Info

This page displays the current event **Code**, **Reference**, **Value**, **Description**, **Time**, **Date**, etc.

### Versions

This page displays a list with all the current versions for different items, such as the **Application Software**, **FTP**, **Web**, **Azio**, **File System**, **UDP**, **Boot**, etc.

### Timers

This page displays the timeout timers for the device, with their **Status** and **Timeout Period**.

### Traps

This page will display any incoming trap for particular parameters, with a clear button to clear the alarm if an alarm template is active.

### FTP Server

This page contains all FTP-related information, such as **Version**, **Client Retry**, **Client Kill**, etc.

### HTTP Client

This page contains information about the HTTP client that the device is using, including the **Version**, **Client Retry**, **Client Kill**, **Proxy Command**.

### SNMP Agent

This page contains all SNMP-related info, including the **Agent Status**, the **Community Set/Get**, whether **Traps** are on, and the **IP**.

### UDP

This page displays the **Port**, **User Level**, **Filter**, **Mode** and **Protocol** for UDP 1-5.

### SMTP Mail Client

This page displays SMTP-related parameters, such as the **Status**, **IP**, **Retry** and **Retry Timeout**, as well as **POP3 IP**, **Mail User** and **Password**.

### Web Parameters

This page contains the web configuration parameters, such as **Server Activation**, **Counter**, **Telnet and Console Port Secure Access**, etc.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
