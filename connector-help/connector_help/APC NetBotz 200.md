---
uid: Connector_help_APC_NetBotz_200
---

# APC NetBotz 200

The American Power Conversion (APC) NetBotz Rack Monitor 200 is a central hardware appliance for an APC environmental monitoring and control system. The rack-mountable NetBotz 200 includes six sensor ports for connecting temperature and humidity sensors, door switch sensors, and third-party dry contact sensors. Using other ports on the NetBotz 200, you can connect up to eight temperature and humidity sensors with digital display. This driver uses **SNMP polling**to retrieve sensor information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.5.6                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages described below.

### General Page

This page contains information such as the **Device Name, Product Number, Device Firmware Version, Device Hardware Version, Date of Manufacture** and **Device Serial Number.** Italso allows you to configure the **EMS Configuration Name.**

### Modules Page

This page displays a table with information on the modules attached to the system. For each module, you can find information such as the **Module Name, Module Location, Serial Number,** etc.

### Beacon Page

This page contains the **Beacon Configuration Table**, which displays configuration information for each beacon.

### Alarm Device Page

On this page, you can find the **Alarm Device Table**, which allows control of individual device alarms.

### EMS Page

This page displays information about the Environmental Management System, such as:

- **EMS Communication State**: The status of communication between the Agent and the device:

- *Communication* means that communication is established.
  - *No Communication*means that communication has never been established.
  - *Communication Lost*means that communication was established but lost.

- **Probe Count**: The total number of temperature/humidity probes (both local and remote) supported by the device.

- **Input Contacts Count**: The number of input contacts the device supports.

- **Output Relay Count**

- **Outlet Count**

- **Sensor Count**

- **ARUs Count**

- **T/H Probes Count**

- **Alarm Devices Count**

- **System Temperature Units**

- **Check Log Light:** *Light off* means there are no new log entries;*Lights on* means new log entries are present.

- **Hardware Status**:

- *No Error* indicates no error conditions have been detected in the EMS hardware.
  - *Current Limit Error* indicates a current limit error condition related to the Alink port
  - *Incorrect Hardware Plugged* indicates incorrect hardware is plugged into an EMS port.
  - *Limit and Incorrect Hardware Errors* indicates that both of the previously mentioned error conditions are present.

### Probe Page

This page contains the Probe Configuration Table, which displays both status parameters and settings for the individual probes:

- Status parameters include the **Probe Temperature**, **Humidity Status** and **Probe Communication Status**.

- Configurable settings include:

- **Probe Delta Temperature**
  - **Probe Delta Humidity**
  - **ST Incr. Temp. Variance**: Short-term increasing temperature variance used for rate of change alarms.
  - **ST Incr. Temp. Time**: Short-term increasing temperature time used for rate of change alarms.
  - **ST Decr. Temp. Variance**
  - **ST Decr. Temp. Time**
  - **LT Incr. Temp. Variance**:Long-term increasing temperature variance used for rate of change alarms.

### Sensors Page

This page contains the following tables:

- **MEM Sensor Configuration**: Allows you to retrieve configuration information from sensors attached to the system. This includes configurable settings such as **Sensor Location** and **Sensor Name**, and status information such as **Sensor Temperature**, **Sensor Humidity**, etc.

- **EMS Sensor Status:** Displays information on individual sensors, such as:

- **Sensor State:** Displays*Sensor Faulted EMS* if there is a fault in the sensor,*Sensor OK EMS* if there is no faultand*Sensor Not Installed EMS* if the sensor is not installed.
  - **Sensor Normal State:** Displays if the normal state of the sensor is*closed*or*open**.***
  - **Sensor Alarm Delay**

- **EMS Sensor Control**: Allows you to control/reset individual sensors.

- **EMS Sensor Configuration**: Allows you to configure individual sensors.

### Inputs Page

This page contains the following tables:

- **Input Contact Configuration**: Allows you to configure the parameters **Input Contact Name** and **Input Normal State** for each probe and also displays the **Input Contact State** of each probe.
- **Input Status**: Displays status information such as the **Input Name, Input Location, Input State, Input Analog Value, Input Alarm** and **Input Communication Status** for each probe. From version 1.0.0.4 onwards, the display key for this table can be configured as **MEM Input ID** (primary key) or the **Input Name**.
- **Input Configuration**: Allows you to configure several parameters for each probe, such as **Input Type** (*Dry Contact*, *Digital*, *Analog mA*, *Analog Volts*), **Alarm Generation, MEM Input Normal State, Abnormal Severity** and **Number Calibration Points**.You can also configure each **Calibration Point.**

### Outputs Page

This page contains the following tables:

- **Output Relay Control**: Allows you to control the individual output relays. For each relay you can check the **Output Relay State** and configure the **Relay Output Name**, **Output Relay Normal State** and **Relay Output Command**.
- **Output Configuration**: Allows you to retrieve output configuration information and configure the **Output Name**, **Output Location**, **Normal State** and **Output Action.**

### Outlets Page

This page contains the following tables:

- **Output Configuration**:Allows you to configure the **Outlet Conf. Name, Outlet Normal State** and **Outlet Command** for the individual outlets.
- **MEM Outlet Configuration**: Displays outlet configuration information and allows you to configure the **Outlet Location, MEM Outlet Normal State** and **Outlet Action.**
