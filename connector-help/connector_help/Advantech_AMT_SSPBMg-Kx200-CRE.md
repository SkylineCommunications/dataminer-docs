---
uid: Connector_help_Advantech_AMT_SSPBMg-Kx200-CRE
---

# Advantech AMT SSPB Mg-Kx200-CRE

This connector is designed to poll data, set data and monitor alarms of an Advantech AMT SSPB Mg-Kx200-CRE. This is a redundant 200W extended Ku-band HUB-mount solid state block upconverter satellite transmitter, operating in the Ku-band. The device is used in conjunction with the L-band transceiver, and is intended to be mounted on an antenna hub.

The main components of the device, which are monitored and polled by the connector, are the power supply, consisting of two power supply assemblies in the SSPB, the upconverter assembly, which converts and amplifies the incoming L-Band carrier signal into a Kx-band carrier, and the HPA assembly, which amplifies the RF signal from the upconverter to a power level sufficient for transmission. Integral to this module are three HPA stages and a power conditioner board. Other functionality includes internal power conditioning and overtemperature shutdown. There is also a controller board, where all of the controls, input/output communication and decision-making, with the exception of the critical module-level decisions, are managed by the microcontroller within the upconverter. Through the system control interface, the microcontroller board takes care of fault detection, monitoring, on/off switching, and changes in the unit's address.

Finally, if an external 10 MHz reference signal is used, this signal must be supplied at the input of the unit along with the L-Band input signal.

## About

Protocol type: SNMP.

This connector is divided into four sections:

- A read-only section that polls identification data of the device such as the serial number, software version used, power class, and so on.
- A second read-only section, except for one parameter, that polls the uplink converter statuses, such as redundancy, gain, Tx frequency, Rx frequency, attenuation, and so on.
- A read-only section that polls the device alarms, such as temperature alarms, voltage alarms, current alarms, and so on.
- A read and write configuration section that allows the user to set different parameters, such as RF status, gain, attenuation, frequency (Tx and Rx), redundancy mode, and so on.

### Version Info

| **Range** | **Description**                                                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. DCF integration featured from version 1.0.0.2 onwards. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: Default value: *161*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains identification information about the device, including the System Description, System Up Time, System Contact, System Name, System Location, Serial Number, Software Version, Power Class (dBm), Power Class (W), Frequency Shift, PA Present, HPA availability and switch position (Antenna or Load).

The page also contains three page buttons; **Security**, **Redundancy** and **Environmental**.

- The **Security** page button opens a pop-up page that includes security parameters that can be changed using a toggle button.
- The **Redundancy** page button opens a pop-up page that includes a few redundancy parameters and allows you to change the redundancy mode with a toggle button.
- The **Environmental** page button opens a pop-up page with environmental parameters, such as temperature, voltage and current readings.

### Interfaces

This page contains the **Interfaces Table.**

### Amplifier

This page contains readings of the **RF status** parameters. In most cases, it is also possible to set the parameters to different values or states, some within a given range and others to any range. For example, the values of the **Gains** (Gain A and Gain B) are read and can also be set to any value between 53.0 dB and 74.0 dB, and the values of **ALC power** and **ILP power** are read and and can be set without range constrictions.

The parameters are grouped together into groups. For example, the gain-related parameters are grouped in one group called **Gain**, the frequency-related parameters are grouped into one group called **Frequencies**, the power-related parameters are grouped into one group called **Power**, and so on.

**Alarm monitoring** **and trending** are activated on the parameters of which the polled readings are numeric values. Within the **Power** group, the **Forward Output Power** and the **Reflected Power** are represented in dBm and in Watts. Both have a LED bar representation of their measures below them, where the maximum range of the **Forward Output Power** and the **Reflected Power** are set dynamically to the readings of the **Power class(dBm)** and **Power Class (W)** on the **General page**, respectively. The minimum range, however, is set to zero dBm and its corresponding value in Watts, since there is no minimum power class.

The total elapsed time since the unit has been produced is also included on this page, and there is a redundancy page button identical to the one on the general page.

### Alarms

This page contains all the parameters that poll alarms read from the different components of the device. All the parameters are read-only, except for the **Fault Reset** button.

As on the Amplifiers page, the parameters are grouped together logically. In addition, some alarms combine two alarms in one. For example, the **Wave Guide (WG) Switch** alarm and **WG connectivity** alarm are grouped into one alarm, with an output as follows: Alarm - No Alarm - Disconnected. The **Redundancy Switch-**related alarms are also gathered into one group called **Redundancy Switch**, and the three alarms are named as follows: **Short** - **Disconnect** - **Position Error**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The 1.0.0.2 connector range of the Advantech AMT SSPB Mg-Kx200-CRE protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- **Input** interface, type **in**
- **Output** interface, type **out**

### Connections

Internal Connections

- Between **Input** and **Output** interfaces, an internal connection is created if the **RF Status** parameter is **On**.
