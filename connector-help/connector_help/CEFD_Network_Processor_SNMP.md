---
uid: Connector_help_CEFD_Network_Processor_SNMP
---

# CEFD Network Processor SNMP

This series of Outdoor Block Upconverters provides one RF composite output covering two satellite transponder frequencies and accepts two separate and independent L-band IF inputs in an integral, self-contained weather-proof package designed for outdoor antenna mounting.

## About

The **CEFD Network Processor SNMP** connector controls and monitors the slope and attenuation of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.12.1A                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

On this page, you can find the **Event Logs** table, as well as the **Logging Status, Logging Level** and **Boot From** parameters.

The page also contains the following buttons:

- **Clear Log**: Clears the log table.
- **Restore Factory Defaults**: Restores the device settings to the factory defaults.
- **Reboot Now**: Reboots the device.
- **Time**: Displays the Time configuration subpage, where you can among others configure the **Time Zone** and the **Primary Internet Server**.
- **Upgrade**: Displays a subpage with device upgrade information, such as the current images to upgrade to.
- **SNMP**: Displays a subpage with the configurable SNMP settings, such as the **Read/Write Community** strings, **System Contact**, **Trap IP Address**, etc.
- **Security**: Displays the **Username/Password** for SNMPv3, as well as a button to **generate a new host key**. Note: Clicking this button will **reboot the device** and cause the element to go into **timeout for about 1 minute**.
- **FAST Features**: Displays a subpage that shows which features are or are not installed.
- **Mode**: Opens a subpage with the **Routing/Bridging Mode** configuration and a parameter that allows you to enable **Bridge to Multipoint**.

### LAN

This page displays various LAN interface options, such as the **Traffic IP Address**, **Subnet Mask**, **MAC**, **IP Addressing Mode**, **Proxy ARP Status**, etc.

It also contains the Ethernet Ports and ARP Info tables. Click the **Add Row** page button to open a subpage that allows you to add an ARP row.

### WAN

This page contains **Quality of Service Status** and **Mode** as well as a button to start a loopback test (**Start Test**) and the **Loopback results**. It also includes the **Differentiated Services** and **QoS Stats** tables.

### Routing

This page contains the **Route Info** table as well as the following page buttons:

- **IGMP**: Opens a subpage with IGMP controls such as **Status**, **Query Interval**, **Robustness**, etc.
- **OSPF**: Opens a subpage with OSPF controls such as **Status**, **Network Address**, **Priority**, **Dead Interval**, etc.
- **Add Row**: Opens a subpage that allows you to add a routing row. After you have filled in all the parameters, click **Add Row** to add the new row.

### Statistics

This page contains the **Ethernet Stats Info** table as well as the following buttons:

- **Clear**: Clears the counters for the **Ethernet Stats Table**.
- **Clear All Counters**: Clears the counters for all stats tables.
- **WAN**: Opens a subpage with various WAN-related statistics, as well as a button to clear the counters.
- **IP**: Opens a subpage with various router/end station statistics, as well as a button to clear the counters.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
