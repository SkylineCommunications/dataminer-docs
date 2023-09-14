---
uid: Connector_help_Tryo_Communications_SDA+15W_Outdoor
---

# Tryo Communications SDA+15W Outdoor

The **Tryo Communications SDA+15W Outdoor** is used as a transmitter that transmits electromagnetic waves carrying messages and signals.

## About

This connector polls data from the **Tryo Communications SDA+15W Outdoor** via **SNMP** and displays the information on multiple pages with various tables and standalone parameters. Some parameters can be used to update data within the device by means of an SNMP set. The connector also handles traps, by parsing a trap for the OID of the parameter that caused the trap and repolling the parameter for an updated value.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.1                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *public*.

### LITE Mode

LITE mode reduces the number of polled parameters of this protocol in order to save bandwidth over GSM connections. To enable this functionality, use the toggle button on the **SNMP Config** subpage.

The following parameters are polled in this mode: Frequency, Service Mode, Temperature Status, Modulator Internal Temperature, SWR Status, GPS Lock, User RF Status, Secondary Input Storage Time, Transit Delay, C/N Ratio, Carrier Status, Satellite Receiver Frequency, TS Bit-Rate, Number of Satellites, Number of Satellites in sight, RF User, Power and RF SWR.

## Usage

### MDVB General

This page displays general information about the device, such as the **Manufacturer**, **Device Name** and **Device Type**.

### SNMP Configuration

This page allows you to view and configure SNMP settings, including the **Read and Set Community** and the **LITE Mode**.

### Time and Date

This page corresponds to the **Time and Date** tab in the web interface, where you can configure the time and date of the device, as well as see the last time the device was synced.

### SUMMIT General

This page displays general information about the **SUMMIT** of the device, such as the **SUMMIT Version.** It also allows you to set the **Service Mode** and **RF User Setting.**

### SUMMIT Status

This page contains status information for the **CPU**, **Driver** and **Exciter** of the device.

### Power Amplifier

This page contains status information for the **Power Amplifier** of the device.

### System

This page contains status information on the overall condition of the system.

### Configuration General

This page contains basic settings for the device, such as **Precorrector Data**, **Starting Delay** and **Clock-Config PPS Edge.**

### Control Configuration

This page contains advanced settings for the device, such as **Control Crest Factor**, **Gain Offset** and **Control RF Frequency.**

### DAB Configuration

This page contains configurable parameters for the **DAB** of the device, such as **PPL Status**, **Input Switching Type** and **Input Stream Selection.**

### Satellite Receiver Configuration

This page contains configurable parameters for the **Satellite Receiver**, such as **LNB Voltage**, **Demodulator Standard** and **TS PID.**

### EDI Configuration

This page contains configurable parameters for the **EDI** feature of the device, such as **Reception Mode**, **Port** and **Receiver Latency.**

### Interface Configuration

Similar to the **EDI** page, this page contains configurable parameters for the interface of the device, such as **Mode**, **DHCP** and **IP Address.**

### Status General

This page contains basic status parameters for the device, such as **Hardware Version**, **Process Load** and **Internal PLL.**

### Monitoring Status

This page contains more advanced status parameters, such as **Monitoring Crest Factor**, **AGC** and **Input Level.**

### EDI Status

This page contains status parameters for the **EDI** feature of the device, such as **UDP Reception**, **Type** and **Reed Solomon.**

### DAB Status

This page contains status parameters for the **DAB** of the device, such as **ETI Input**, **Input Packet** and **Header CRC**.

### Satellite Receiver Status

This page contains **Satellite Receiver** settings, such as **Input RF Level**, **Symbol Rate** and **TS Bit-Rate**

### GPS Status

This page contains status parameters for the GPS feature of the device, such as **Type**, **Antenna Status** and **Longitude.**

### RF Detector

On this page, you can view and configure parameters related to the **RF Detector** of the device.

### SD General

This page contains two tables:

- **Power Amplifier Table**: Displays the power amplifier status.
- **M**e**asurement table:** Displays measurements for different parameters of the device.

### PAU General

This page contains the **PAU General Table**, with basic information about the **PAU** of the device.

### Fan

This page contains two tables:

- **Fan Information Table**: Displays the fan **Version.**
- **Fan Configuration Table**: Allows you to view and configure properties of the fan in the device.

### RF

Similar to the **Fan** page, this page also contains two tables:

- **RF Information Table:** Displays the **Version** and **Sub-Band**.
- **Gain Control Table**: Displays different properties of the **RF** feature of the device.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
