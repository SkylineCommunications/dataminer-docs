---
uid: Connector_help_EM_Solutions_Cobra_Terminal
---

# EM Solutions Cobra Terminal

The **EM Solutions Cobra Terminal** is a maritime Ka-band satcom terminal designed to operate in the commercial and military Ka-bands and certified for operation on GX and WGS satellites.

## About

The connector uses **SNMP** to retrieve data from the **Cobra Terminal**. Certain parameters of the device can also be configured from this connector.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Venom v2.6.2 (980f0fc)      |

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

This page contains the description parameters for this **ACU** along with an overview of the terminal's operating state.

### Status

This page contains the **INU** (Internal Navigation Unit) and **Motion Control** parameters.

In addition, **Modem**, **Beacon Tracking** and **Tx Status** information is available via page buttons.

### RF

This page displays information related to the **Reference Selection Board**, as well as the **BUC** status.

### Environmental

This page provides status information related to **Temperature** and **Voltages**.

### Satellite Selection

On this page, you can select the **Network/Satellite** configuration.

Information related to the satellite service is also available, such as the **Satellite Longitude**, **Tx Polarization**, **Rx Polarization** and **RF Band**.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
