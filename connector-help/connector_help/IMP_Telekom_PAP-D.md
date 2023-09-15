---
uid: Connector_help_IMP_Telekom_PAP-D
---

# IMP Telekom PAP-D

The **IMP Telekom PAP-D** connector monitors and configures the **IMP DVB_T PAP-D ChangeOver Unit**.

## About

The **IMP Telekom PAP-D** connector gets and sets the changeover configuration between several transmitterss. The connector uses SNMP (including traps) to retrieve data.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V2.0                        |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page contains most of the configurable parameters and general information.

### Transmitter A

This page contains parameters specific to **Transmitter A**.

### Transmitter B

This page contains parameters specific to **Transmitter B**.

### Webpage

This page contains the linked web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
