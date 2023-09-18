---
uid: Connector_help_Eaton_Blade_UPS
---

# EATON Blade UPS

The **Eaton Blade UPS** connector can be used to display and configure information of the Eaton Blade UPS models ranging from 5 to 60 kW.

## About

An **SNMP** connection is used in order to retrieve and configure the information of the device.

In addition, the connector offers several possibilities for **alarm monitoring** and **trending** of the supported Eaton UPS.

### Version Info

| **Range** | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version               | No                  | No                      |
| 2.0.0.x          | Adaptation for SNMP version 1 | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.6.0.5a                    |
| 2.0.0.x          | 1.3                         |

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

This page displays general information about the device, such as the **System Name**, **System Description**, **System Location**, **Manufacturer**, **OEM Code**, **Status** and **OS Version**.

### Network

On this page, you can view and set up the network parameters in the **IF Table**, which contains the **Admin Status**, **Operational Status**, **Type**, **Physical Address** and **Description**.

### UPS

This page displays information related to the **Inputs** and **Outputs**, including the **Frequency**, **Number of Phases** and **Load.** Two tables display the **Voltage**, **Power** and **Current** per phase for the input and output, respectively.

The page also contains topology-related parameters, such as **Power Strategy** and **Unit Number**, as well as page buttons that open the following subpages:

- **Environment Sensors**: Displays the **Ambient** and **Remote** **Temperature** and **Humidity**, as well as thresholds for the minimum and maximum allowed values for these parameters.
- **UPS Config**: Displays the **UPS configuration**, with parameters such as **Input/Output Voltage**, **Output Watts**, **Output Frequency** and the **Voltage Output** thresholds.
- **Control Output**: Allows you to configure the **Output ON/OFF Delay**, **Output ON/OFF Trap Delay**, **Bypass Delay** and the parameter **Load Shed Secs with Restart**.

Note: **Control output parameter responses** will be available if these parameters have been **previously configured on the device**. Otherwise, you can find answers of type **"NO SUCH OBJECT" in the stream viewer** for the element.

### Battery

This page contains information related to the technical specifications of the batteries, such as the **Voltage**, **Current**, **Capacity** and **Management Status.**

The page also allows you to set different **tests** on the batteries and view the results of these tests.

### Alarm

This page contains the **Alarm Table**, which displays alarms and complete information about the origin of faults.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
