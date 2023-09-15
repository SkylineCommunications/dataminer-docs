---
uid: Connector_help_CEFD_SLM-5650A_SNMP
---

# CEFD SLM-5650A SNMP

The CEFD SLM-5650A SNMP connector controls the and monitors the **CEFD SLM-5650A** **satellite router** through SNMP.

## About

The **Comtech EF Data (CEFD) SLM-5650A satellite router** satisfies the requirements for government and military communications system applications that require state-of-the-art modulation and coding techniques to optimize satellite transponder bandwidth usage, while retaining backward compatibility. This connector provides an optimized user interface for the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**: (already filled in)

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.4.8p                      |

## Usage

### Admin - Access

On the access page several network related parameters can be configured. For instance, **Network Maintenance,** as well as the **Network Processor Interface,** the **System Account Access Information** and **Host Access List** are displayed and configurable.

### Admin - Remote

The Remote page displays and configures settings for remote operation of the device through SNMP.

Remark: use this page cautiously. Changing the SNMP settings may sever the connection to the connector.

### Config - Modem Operating Mode

The Modem Operating Mode is a key page within this connector. It displays and configures settings as the **Modem Operating Mode**, the **Transmit** settings, the **Receive** settings.

The Parameters in the **Transmit** settings as well as those in the **Receive** settings may depend on either the **Modem Operating Mode** or eachother. In either case, the connector will automatically select a correct configuration.
Dependencies for these parameters are as follows: (for both Rx as Tx)

- Overhead Type

- depends on: Modem Type

- FEC Type

- depends on: Modem Type

- Reed Solomon Encoder/ Decoder

- depends on: Modem Type)

- Reed Solomon Code Word

- depends on: Modem Type, Reed Solomon Encoder, Overhead

- Reed Solomon Interleaver Depth

- depends on: Modem Type, Reed Solomon Encoder

- Modulation/ Demodulation Type

- depends on: Modem Type, Fec Type

- Code Rate

- depends on: Modem Type, Fec Type, Overhead Type

- Scrambler/ Descrambler

- depends on: Modem Type, Reed Solomon Encoder, Overhead, Fec Type

### Config - Modem Utilities

The Modem Utilities page displays tools and utilities for both **Tx** and **Rx** on the Satellite Router. On this page The **modem configuration** can also be stored/ loaded and the **date** and **time** can be set.

### Config - Antenna Handover

The Antenna Handover page displays and configures settings concerning the **Antenna Handover.**

### Config - CnC

The Cnc page displays and configures settings for **Cnc**, its **Tx Power**, and **APC.**

### Config - AUPC

The AUPC page displays and configures settings for AUPC, related **Power Settings**, **Carrier Loss Action**, **Async** and **AUPC Logging**.
This page *can only be shown* when the modem operating mode is AUPC.

### Stats - Modem Status

The Modem Status page displays general information on the status of the router (and the router itself), as well as an overview on router Faults.

### Stats - Event Log

The Event Log page shows the **Event Log table**.

### Stats - Statistics

The Statistics page shows the **Statistics Log table**.

### Maintenance - Unit Info

The Unit Info page shows the **Firmware Info table.**

### Web UI

The Web UI page displays the User Interface of the device itself.

Remark: Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
