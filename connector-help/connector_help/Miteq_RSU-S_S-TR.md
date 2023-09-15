---
uid: Connector_help_Miteq_RSU-S_S-TR
---

# Miteq RSU-S_S-TR

The **Miteq RSU-S_S-TR** connector monitors and controls a changeover unit through SNMP.

## About

The connector polls relevant information from the device every 10 seconds, 15 seconds, 30 seconds or 1 minute, depending on the information, and updates the user interface with the values received from the device.

### Version Info

| **Range**            | **Key Features**     | **Based on** | **System Impact** |
|----------------------|----------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitoring & control | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 163509 V3.005.25       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

The connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION**:**

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community** **string**: The community string in order to read from the device. The default value is *public.*
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## Usage

The connector has several data display pages. More information about these pages can be found below.

### General Page

This page displays the **System** **Uptime**, the **System Contact**, the **System** **Name**, the **System** **Location** and the number of **System Services**.

In addition, the (configurable) **System Clock** of the device is displayed, as well as the **Firmware Revision**. You can also enable or disable newer firmware on the device.

### Interface Card Page

This page displays statistical information on the interface card of the device, and allows you to configure the **Administrative State** of the interface card.

### Device Settings/Status Page

This page displays settings and status information for the device, such as the **Converters' Status** (for both the primary and the secondary converters), the **Redundancy Status** (the device's control scheme, the redundancy mode and the serial link status), the current **Gain Configuration**, the **Fault Status** of the device (both for the converters and for the unit in general) and the **Power Supply Status**.

In addition, the page allows you to configure which converter is **Online** or in **Standby**, and to configure the **RSU Control Mode**, the **Redundancy Mode**, the **Serial Link** configuration, the current **Gain Configuration**, and the **Converter Configuration** in terms of **Frequency** and **Attenuation.**

Finally, via a page button, you can configure a **Nominal Voltage** value for monitoring purposes.

### IP/SNMP Settings Page

This page displays the configurable IP/SNMP settings of the device.

The following IP settings can be configured: the **IPv4 Address** of the device, the **Subnet Address Mask** and the **Gateway Address.**

The following SNMP settings can be configured: the **SNMP System Contact**, the **SNMP System Name**, the **SNMP System Location**, the **Read** and **Write Community Strings** and the IPv4 **Trap Destination** address.

The page button **SNMP Information** displays statistical SNMP information of the device and allows you to **enable/disable authentication traps**.

### Miscellaneous Settings Page

The page displays miscellaneous configurable settings of the device. It allows you to enable/disable **Telnet Access**, set the **Alarm Refresh Rate**, and configure the **Web-Login Timeout**, the **Unit Name** and the **Device Password.**

In addition, you can use the **Send Test Trap** button to trigger a remote SNMP trap for testing purposes.

### Device Event Log Page

The page displays a list of **error event logs** registered by the device.

### Active Faults Page

The page displays the currently active faults for the **Primary** and **Backup Power Supply**, the **Converter BUS**, the **Converter Contact**, the **Transfer Switch**, and the **Primary** and **Backup Unit Form-C Contacts.**

### Web Interface Page

The page displays the webpage of the device.
