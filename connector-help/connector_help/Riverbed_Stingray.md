---
uid: Connector_help_Riverbed_Stingray
---

# Riverbed Stingray

This connector enables DataMiner to monitor the Riverbed Stingray device, which is a traffic manager/shaper.

## About

This connector works via SNMP. The data it retrieves can be found on several pages and all numeric parameters can be monitored and trended.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 10.0r1                      |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page shows general information about the device: the **Software Version**, **Number of Child Processes**, **Up Time** and **Time Since Last Configuration Update.** In addition, basic information of the system is polled, such as the **System Free Memory** and **System CPU Usage**.

With the toggle button **Logging of Received Traps**, you can enable the logging of information on received traps in the element log file. The file will mention when each trap was received, which pages were repolled because of it, and the log line that belongs to the trap.

### Virtual Servers

This page shows the **Number of Virtual Servers** and the **Virtual Server Table**, which contains information on every virtual server of the device.

### Pools

This page shows the **Number of Pools** and the **Pool Table**, which contains information on every pool of the device.

### Nodes

This page shows the **Number of Nodes** and the **Node** **Table**, which contains information on every node of the device.

### Traffic

This page shows the **Number of Traffic IPs** and **Number of Traffic IPs Raised.** Next to this, the **Traffic IP Table** displays information about the traffic for all IP addresses.

### Service Level

This page shows the **Number of Service Levels** and the **Service Levels Table**, which contains information on every service level of the device.

### Bandwidth Class

This page shows the **Number of Bandwidth Classes** and the **Bandwidth Class Table**, which contains information on every bandwidth class of the device.

### Interfaces

This page shows the **Number of Interfaces** and the **Interface Table**, which contains statistics for the network interfaces on this system.

Click the page button below the table to see the data of the **Generic Interfaces Table**, which is part of the standard MIB2 and not made specifically for this device by the enterprise.

### Location

This page shows the **Location Table**, which contains information on statics for GLB services on a per location basis.

### Web Interface

Opening this page opens the web interface of the device. With this web interface, you can for example configure for which events the device needs to send SNMP traps, which can be intercepted by this connector. The connector detects the type of the trap and makes sure that the parameters mentioned in the trap will be repolled immediately.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
