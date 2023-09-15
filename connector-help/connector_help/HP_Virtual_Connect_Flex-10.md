---
uid: Connector_help_HP_Virtual_Connect_Flex-10
---

# HP Virtual Connect Flex-10

The **HP Virtual Connect Flex-10** connector is an SNMP based connector used to monitor and configure the **HP Virtual Connect Flex-10**.

## About

The **HP Virtual Connect Flex-10** provides a monitoring interface for the **HP Virtual Connect Flex-10** Switch.

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.0.1.x          | DCF integration | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

The **HP Virtual Connect Flex-10** is an SNMP connector. The IP has to be configured during creation of the element.

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

The **General** page displays the general information of the device, for example **Product Name**, **System** **Uptime**. Some of these parameters can also be changes, like for example the **System Contact..**.

### Detailed Interface Info Page

This page presents a table with information with **Detailed Interface Info**.

### Detailed Interface Info - Rx Page

This page presents a table with information with **Detailed Interface Receiving Info**.

### Detailed Interface Info - Tx Page

This page presents a table with information with **Detailed Interface Transmitting Info**.

### VLan Page

This page presents a table with information regarding the **Ethernet Network**.

### Profile Table Page

This page presents tables with information regarding **Profiles** and **Profile Network Mapping**.

### Web Interface

This page show the device **Web Interface**.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
