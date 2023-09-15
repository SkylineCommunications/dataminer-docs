---
uid: Connector_help_Middle_Atlantic_UPS-S1500R
---

# Middle Atlantic UPS-S1500R

The Middle Atlantic UPS-S1500R connector can be used to monitor and configure private UPS parameters and general parameters of the device. This connector is used to monitor and configure the UPS-S1500R rack-mounted uninterruptible power supply (UPS) from Middle Atlantic Products, which can provide backup power for any device.

## About

The UPS-S1500R connector was created to poll general and also internal information, such as information on the **Input** and **Output**, **Configuration** and **Control**, and the **Battery**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.9                       |

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

This page displays the **Battery and UPS status**, as well as general **System Data**. You can also change the **Location** and **Contact** information to identify the system here.

### Status

This page displays the **Voltage**, **Frequency**, and **Temperature** of the system.

### Information

This page displays physical information on the system. You can also specify a **Name** for the system here.

### Interface

On this page, you can set the **Desired State** and view the **Operational Status** and **IP** information.

### Battery

This page displays information on the **Voltage** and **Current**. It also contains the parameters **Time on Battery** and **UPS Batteries Last Replaced.**

### Configuration

This page allows you to configure the device, including the settings **Transfer Voltage**, **Sleep Time**, **Run Time**, **Sensitivity** and **Return Delay**.

### Control

This page allows you to **Reboot** the device, turn it **Off** and **On**, and set a number of other simple commands to control the system's functions, such as **Sleep Mode** and **Conserve Battery**.

### Test

On this page, you can configure and schedule the **Test Diagnostics**.

### Capabilities

On this page, the **Conceptual Table** allows you to dynamically configure MIB values, as far as allowed by the system**.**

### Device Entry

This page contains a list of equipment plugged into the UPS.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
