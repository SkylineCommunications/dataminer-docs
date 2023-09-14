---
uid: Connector_help_Kathrein_ML
---

# Kathrein ML

This **SNMP** protocol is designed to monitor several Kathrein HMS (Hybrid Management Sublayer) transponders.

## About

The compact transponders, TVM 840H and TVM 840V, are designed for the compact receiver platform ORA 820 and the compact amplifiers from the VGF 8000 series and VGF 81 series.
The CATV/GGA transponders, TVT 10 and TVL 40L, are used in the CATV 862 MHz system and in the GGA 6/8 fiber nodes and the appropriate amplifier points.

The transponders are frequency agile and include, along with alarm messages, so-called inventory data such as unit type, order number and construction year. They allow remotely controlled functions and measurements. All configuration data is securely saved in all Kathrein transponders. Each transponder is equipped with a virtual IP address and is managed by a Phoenix Gateway.

This connector can be used to monitor parameters of the transmitter and configure it.

### Version Info

| **Range** | **Description**                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial protocol                                 | No                  | Yes                     |
| 1.1.0.x          | No                                               | Yes                 |                         |
| 1.1.1.x          | VGR09C instead of VGR09D, separated Pilot module | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | Unknown                     |
| 1.1.1.x          | Unknown                     |

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

### Main View

This page displays an overall overview of general parameters and alarm states related to the device, such as **Location**, **Forward** **Modules**, **Internal** **Temperature**, **AC Voltage**, **Slot** **States**, **IP Address**, **Pilot Alarms**, **Receive levels** and **Control Voltages**.

### Control

This page contains control parameters (**Location**, **Internal Temperature** and **AC Voltage**) and alarm statuses (**Housing open**, **Red** and **Yellow Pilot Alarm**, **Power Supply Alarm** and the **Alarm Detection Control**) of the Network Elements' housing.

In addition, the **Reset** button allows you to reboot the device.

### Power Supply

All parameters regarding the power supplies are listed on this page: **DC Voltage**, **External Voltages** and **DC Current**.

### Forward

In the **Common** sections of this page, you can find the **Slot** and **Type** of each of the two forward path amplifiers. The **State** sections include the **Config**, **Defective**, **Handheld** **Connected** and **Temperature states**.

For each forward amplifier, a **Configuration** page button is available, which opens a subpage with values regarding the **Input and Interstage Attenuation**, **Input and Interstage Slope**, **Equalizer**, **Offset**, **AGSC**, **Power** **Splitter** and **Redundancy**. You can also alter the **Switching** **Mode** and the **Input** of each forward amplifier module on these subpages.

### Pilot

In the **Common** section of this page, you can find the used **Slot** and **Type** of the pilot module. The **State** parameters are similar to those for the forward amplifier module: **Config Changed**, **Defective**, **Handheld Connected**, **Controller Defective**, **Upper Alarm**, **Lower Alarm**, **AGSC Failed** and **Control Voltage**.

The **Configuration** page button displays values for **Configuration Offset**, **AGSC Control**, **Pilot Range**, **Frequency**, **Offset** and **Lower and Upper Adjustments**.

### Return

In the **Common** section of this page, you can find the **Slot** information and the **Type** of the return path amplifier. Also in this section, you can set the **Slope** and **Attenuation**, as well as change the **Primary** and **Secondary** **Switch** to *Attenuated*, *Connected* or *Disconnected*.

The **State** parameters on this page show if an alarm is active: **Config Changed**, **Defective**, **Handheld Connected** and **Controller Defective** **Return Amplifier.**

The **Extra** subpage contains three settings for the normalization switch. The **return path** can be set, and the **value** and **state** of the **Ingress Control Switch 2** can be modified.

The **Nominal Value** for **Ingress Control Switch** **1** and **3** can be set on the subpage **Normalize Return**.

### Configuration

This page displays information about the current configuration. If there is a **Slot Conflict** or if a **Module is Deleted**, an alarm will be displayed.

### RF Monitoring

This page displays the RF parameters of the forward and return path.

For the forward amplifier, the **Frequency** value and **Receive Level** are displayed.

These same parameters are displayed for the return amplifier, but in addition, the following parameters can also be set: **Provisioned Return Power**, **Maximum Return Power** and **SA Phoenix Polling IP.** This last setting allows you to enter the polling address of the Phoenix Gateway that the Kathrein ML is connected to. When a value is entered, the received return path level will be requested from the SA Phoenix and displayed.

### Administration

This page displays a number of general parameters: **Vendor**, **Model Number**, **Serial Number**, **Vendor** **Info** and **Mac Address**.

The following statistics are also available: **Forward Path LOS Events**, **Forward Path Framing Errors**, **CRC Errors**, and the number of **Invalid MAC Commands**.

Below this, you can adjust the **Backoff Period**, and view the **Maximum Variable Bindings** that can be accepted by the unit as well as the **Maximum Payload Size.**

The page has two subpages:

- On the subpage **MAC Control**, the following parameters can be set: **Maximum MAC Layer Retries** , **ACK Timeout Window**, **Backoff Minimum Exponent**, **Backoff Maximum Exponent**. The range and a detailed explanation of these settings can be found on the page itself.
- The **Multicast Group** subpage contains a table with all the **Multicast Addresses**. If you select a multicast address, you can then edit it.
