---
uid: Connector_help_Newtec_M6100R2
---

# Newtec M6100R2

This driver allows you to monitor and configure the Newtec M6100R2 broadcast satellite modulator. Communication with the device happens via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.58.71682           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays general information about the modem, such as the Firmware Version, OS Version and HW Product Type.

The following subpages are available:

- **Info Destination**: Contains a table with notifications of the destination.
- **Remote Log**: Contains information and settings related to the log filter.
- **Reference Clock**: Contains information about the reference clock.
- **CLI/GUI/FTP:** Contains settings related to the graphical user interface, client user interface and file transfer protocol.
- **Operator:** Contains information and settings related to the operator.
- **Power Supply Failure**: Displays alarms related to the power supply.
- **Redundancy**: Contains information and settings related to redundancy.
- **Converter Alarm**: Displays alarms relating to the converter.
- **Device NTP Peer**: Contains a table with the Device NTP Peer addresses.
- **Device Sensors**: Contains information provided by the sensors, such as temperature and voltage.
- **Device Options**: Displays options of the device, with the sales code and corresponding description.

### TS Over IP Outputs

This page contains information related to the transport stream over IP, including monitoring information, and allows you to configure outputs and inputs.

The following subpages are available:

- **Input Alarms:** Contains information related to the alarms of the TS Over IP inputs.
- **Ethernet Link Management:** Allows you to configure the connections.
- **Outputs Alarms:** Contains information related to the alarms of the TS over IP outputs.

### TS Miscellaneous

This page contains page buttons to the following subpages:

- **Protocol TS:** Contains information and settings related to the input alarms.
- **BISS:** Contains information about the scrambling monitoring, alarm information and settings for the BISS.
- **TS Rate:** Contains information and settings related to the TS rate.
- **TS Analyser:** Contains information and settings related to the TS analyser.
- **TS Signaling:** Contains information and settings related to the TS signaling.

### Alarms

This page displays general alarms related to the device.

The following subpages are available:

- **Configuration:** Allows you to configure the alarm settings.
- **Definition/History/Log:** Displays alarms related to the definition, log and history.

### IP Functionality

This page allows you to configure the data interface and gateway. On the **Configuration IP Functionality** subpage, you can configure routes and IP interfaces.

### Ethernet Interface

This page displays general information about Ethernet interfaces.

The following subpages are available:

- **Management/Data:** Allows you to configure the Ethernet interfaces.
- **Configuration/Redundancy/Link/Monitorization/Alarms:** Displays alarm status information for the Ethernet interfaces, as well as various settings, e.g. related to redundancy and VLANs.

### ASI In Out

This page allows you to configure and monitor the ASI inputs and outputs.

The following subpages are available:

- **ASI Input:** Displays the alarms related to the inputs of the ASI.
- **ASI Connection Config:** Allows you to configure the ASI connections.
- **ASI Output Status:** Displays the alarms related to the outputs of the ASI.

### Multi Demodulator

This page displays the alarms relating to the multi demodulator. On the **Multi Demodulator Config** subpage, you can monitor multiple settings for the multi demodulator.

### Multiple Stream TS In Out

This page allows you to monitor and configure the TS multi stream.

The following subpages are available:

- **Multi Stream Input Alarms:** Displays the alarms related to the inputs.
- **Multi Stream Config:** Allows you to configure the outputs.
- **DVB Config:** Allows you to configure the outputs for DVB-S2.
- **S2 Extensions:** Contains extra settings.
- **Modulation Types and FEC:** Allows you to configure the modulation types and FEC for AMC and NBC.
- **Out Alarm Status:** Displays the alarms related to the outputs.

### DVB Modulators

This page allows you to monitor and configure the modulators.

The following subpages are available:

- **Extra Monitoring:** Allows extra monitoring of the modulators.
- **DVB Modulator Alarms:** Displays the alarms of the DVB modulators.

### IP MPE Encapsulation - Decapsulation

This page displays tables related to the IP MPE encapsulation and decapsulation, and the corresponding alarms.

### Configurations

This page allows you to boot, load, save or delete configurations.
