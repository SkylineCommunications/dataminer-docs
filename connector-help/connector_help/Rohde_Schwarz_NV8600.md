---
uid: Connector_help_Rohde_Schwarz_NV8600
---

# Rohde Schwarz NV8600

The **Rohde Schwarz NV8600** is a device used as DVB-T2 transmitter, composed of the following three components: a pump unit, an exciter, and a transmitter unit.

## About

The connector communicates with the Rohde Schwarz equipment through **SNMP** communication using **three distinct polling timers**: one every hour for semi-static configuration, one every 30 seconds for configurable input from the end user that is not strictly time-bound, and one every 10 seconds for time-sensitive displayed parameters such as event logs or fault-related parameters.

SNMP traps can be retrieved, if this is enabled on the device.

### Version Info

| **Range** | **Description**  |
|------------------|------------------|
| 1.0.0.x          | Initial version. |

### Product Info

| **Range** | **Device Firmware Version**                                                                   |
|------------------|-----------------------------------------------------------------------------------------------|
| 1.0.0.x          | NetCCU800 1.44.1 (could be compatible with later/earlier software versions of the NetCCU800). |

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

The connector has several pages, which can be categorized in the following five categories: General, Transmitter, Pump, Exciter, and Web Interface.

For each category, the following pages have been configured:

- **General**

- General Page
  - SNMP/Traps Configuration Page

- **Pump**

- Pump Unit Information/Status Page
  - Pump Unit Measurements Page
  - Pump Events Display/Configuration Page

- **Transmitter (TX)**

- TX Unit Information Page
  - TX Unit/Rack/RF Probes Status Page
  - TX Amplifiers Page
  - TX Events Display/Configuration Page
  - TX NetCCU Logbook Page
  - TX Ost Logbook Page

- **Exciter**

- Exciter Unit Page
  - Exciter Configuration Page
  - Exciter Input/Source Config Page
  - Exciter Events Display/Configuration Page
  - Exciter Logbook Page

- **Web Interface**

### General Page

On the left side of this page, general information is displayed regarding the device, such as:

- **Serial number**
- **SW Identification number**
- **SW Version number**
- **HW Identification number**
- **HW Version number**

On the right side of the page, it is possible to configure several parameters related to the **Software:**

- **Software restart**
- **Software update start**
- **Software update mode**
- **Software update device name**
- **Software update device group**

There is also a page button available, **Date and Time Conf**., that leads to a page where both the date/time of the device and its NTP configuration can be configured.

### SNMP Traps/Configuration Page

On this page, the number of triggered traps is displayed by the **Trap Counter Event** parameter. In addition, you can also view the existing active and inactive events in the **General** **Events** table, and configure the settings for the device's trap sink in the **Trap Sink Table**.

The page also contains a page button named **Trap Settings**, which leads to a page with parameters for specific device configuration of Rohde & Schwarz equipment.

### Pump Unit Information/Status Page

This page displays information related to the device's pump unit. General information is displayed in the **Product** **Information Table**, and status information is shown in the **Status Table.**

Via the **Pump Commands** page button, you can access the **Commands Pump Unit Table**, which allows the configuration of some general settings.

### Pump Unit Measurements Page

On this page, you can consult all measurements related to the pump unit in the **Measure Values Table**. It displays the **temperature, pump flow** and **fan rotation** readings of the device.

### Pump Events Display/Configuration Page

On this page, you can configure the existing trap configuration in terms of priority and masking, and check if there has been any triggered event.

### TX Unit Information Page

On this page, you can find general information about the transmitter unit of the device in the **Product** **Info Table**. The table mentions every subcomponent of the transmitter (Tx) unit, as well as general information regarding hardware and software.

Via the **Tx/Ost Commands** page button, you can configure general parameters determining the behavior of the transmitter (Tx) and its Output stage (Ost)**.**

### TX Unit/Rack/RF Probes Status Page

This page displays the status of the TX Unit in the **Status TX Unit** table. You can also find status information for its subcomponents, i.e. the device's rack and RF probes, in the **Rack Table** and the **RF Probes Table** respectively.

The RF Probes Table, in contrast to other tables, also allows you to configure the behavior of the RF Probe(s).

### TX Amplifiers Page

This page displays the status of the transmitter amplifiers, with information regarding currents, supply voltage, voltage and current drive control, as well as the phase variance.

### TX Events Display/Configuration Page

On this page, you can configure the existing trap configuration in terms of priority and masking, and check if there has been any triggered event.

### TX NetCCU Logbook Page

This page displays the **NetCCU Logbook Table**, an ordered list of events that concern the transmitter's unit. These can be faults, warnings or information from the unit itself. The list has a limit of 255 events.

To access the logbook configuration, click the **NetCCU **Lb** Conf** page button.

### OST Logbook Page

This page displays the **OST Logbook Table**, an ordered list of events that concern the transmitter's output (Ost) stage. These can be faults, warnings, or information from the OST itself. The list has a limit of 255 events.

To access the logbook configuration, click the **OST Lb Conf** page button.

### Exciter Unit Page

This page displays three tables: the **Product Information Table,** the **Exciter Status Table** and the **Identification State Table.**

Via the **Exciter Commands** page button, you can set commands to configure the exciter unit.

### Exciter Configuration Page

On this page, you can configure several aspects of the behavior of the exciter unit. This can be done in the following tables:

- **Config Table**: Allows general configuration of the exciter unit.
- **Identification Table:** Allows the configuration of identification aspects.
- **Precorrection Table:** Allows the configuration of precorrection parameters.
- **SFN Delay Table**: Allows the configuration of the SFN delay.

### Exciter Input/Source Configuration Page

This page displays the status of the exciter's input data in the **Input Table**. In addition, it contains four page buttons in the top right corner that allow the configuration of the source signal: the **Channel,** the **Frame**, the **Layer 1** and the Physical Layer Pipe 1 (**Plp1**).

You can also configure a test signal on this page, in the **Test Signal Table**.

### Exciter Logbook Page

This page displays the **Logbook Table**, an ordered list of events related to the exciter. These can be faults, warnings or information from the unit itself. The list has a limit of 255 events.

To access the logbook configuration, click the **Lb Event Conf** page button.

### Web Interface Page

The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
