---
uid: Connector_help_Network_Critical_SmartNA-X
---

# Network Critical SmartNA-X

The **Smart Network Access Modular System X (SmartNA-X)** is the most flexible and customisable 1G and 10G TAP solution available. It's designed to work as an enterprise solution custom fit for any data centre, no matter the size. With advanced packet filtering capabilities and flexible port maps it has the ability to filter 10G traffic to 1G tools or aggregate 1G links to a 10G port.

## About

The **Network Critical SmartNA-X** uses SNMP to provides a modular, scalable and customizable 1/10G packet broker and TAP solution for monitoring and security tools.

### Range of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.106                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device *(172.20.19.106).*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

### General

This page shows General Parameters related to the device such as: **Name**, **Description**, **Location**, **Service**, **Contact**. It has two dynamic Pages: *Control* that contains: **Reboot** **Cards** and **SNMP** **Notifications,** *Network* where Parameters like **IPv4** and **IPv6**, **IPv4** **Subnet** **Mask**, **IPv4** **Default** **Gateway**, **IPv4** **DNS**, **IPv6** **Gateway** can be configured and *Trap*: these parameters can be configured: **Generate Traps**, **Trap Suppression Level**, **Zero IP Address**, and **Flash Update**, but in order to achieve that, **Trap Polling** should be enabled( by default is disabled)

### Security

It displays the **User Entries Table** and 3 more Parameters that by default will not be polled(The polling depend if the **System** **Access Polling** Parameter is enabled). Those Parameters are: **System Access Interface**, **System Access Username** and **System Access IP Address**.

### Interface

It contains the **Interface Table.**

### Rack

This page allow the user to check the **Number** of: **Slots**, **Fans**, **Expansion** **Slots**, **Power** **Supplies**, besides of these: **Software** and **Hardware** **Revision**. **Rack** **Temperature**, **Serial** **Number**, **Backplane** **Type** and the **Model**. Two Pages will Pop up: *Status* that displays: **Power Supply 1 and 2 State**, **Device** **Status**, and the **Temperature State**, the another page is: *Configuration*: the user can configure: **Card** and **System** **Reboot**, **Card** **Temperature** **High** **Threshold**, **Traffic** **Usage** **Low** and **High** **Thresholds** and **System** **Temperature** **High** **Threshold**.

### Slots

This page gather three Tables: **Slots State**, **Fans** and **Slot** **Configuration** **Tables**.

### Cards

The following Tables appear in this page: **Card Attributes**, **Card Status** and **Card Configuration**.

### Ports

This page shows the **Maximum number of Ports** supported by the device plus two Tables: **Ports State** and **Ports Configuration Tables**. One dynamic Page is found here and includes the number of: **Normal Ports**, **Backplane Ports**, **Aggregation Ports**, **Aggregation and Filtering Ports** and **Aggregation Filtering and Load Balancing Ports** (by default these Parameters are not being polled, if they need to be polled, **Port Attributes Polling** need to be **enabled**).

### Web Interface

This page gives access to the device Web GUI.
Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
