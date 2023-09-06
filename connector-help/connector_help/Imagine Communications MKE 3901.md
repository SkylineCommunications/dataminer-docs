---
uid: Connector_help_Imagine_Communications_MKE_3901
---

# Imagine Communications MKE 3901

**Imagine Communications MKE 3901** is a mixer/keyer module of the **IconMaster Control Switcher**. This device makes it possible to perform different transitions, such as **Key Transitions** and **Audio-Over Transitions**.

## About

This driver allows you to access various information on the device. The data is retrieved using SNMP. There are different possibilities available for alarm monitoring and trending.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains information such as the **Slot Number**, **Unit Name**, **Software Version** and **Operation Standard**. It also allows you to configure the network settings, i.e. **IP Address**, **Subnet Mask** and **Gateway**.

### Source

On this page, you can configure the source for the **Preset** and **Program**. **Transitions** can be also configured: **Speed**, **Shape** and **Breakaway**. If the **Take** parameter is set to *Enabled*, the next transition will start immediately.

### Status

This page displays the status of different parameters such as **Preset**, **Program**, **Reference**, **Hardware** and **Breakaway**.
