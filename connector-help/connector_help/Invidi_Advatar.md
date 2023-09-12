---
uid: Connector_help_Invidi_Advatar
---

# Invidi Advatar

The Advatarr technology is widely deployed by cable, satellite and telco operators. It allows television advertisers to accurately execute advertising campaigns. Operators can use it to address every subscriber on an individual, privacy-protected basis.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

## How to Use

The element consists of the following data pages:

- **General**: Provides a status overview of the connected interfaces. Each status parameter can have the value *Ok*, *Not-Applicable*, *Warning* or *Error*.
- **BDMS Statistics**: Contains information about the communications across the SOAP interface between the Business Data Management System (BDMS) and Advatar Adapter.
- **Cue Tones Statistics**: Lists the cue tones delivered on the network stream and processed through Advatar.
- **Discarded**: Lists the break windows not processed by the Advatar Adapter to create view lists/break descriptors.
- **Service Mux**: Lists the muxes communicating with the BDS, along with the services advertised by each of them.
- **SCTE35 Connection**: Displays the status of the connection to the SCTE35 receivers configured in the system.
- **Cue Connection Statistics**: Displays a statistics table for the received cues.
- **In-band Connection Statistics**: Displays a statistics table for in-band data (i.e. cues/view list/break descriptor/vote now) sent to the set-top boxes.
- **BDS Errors**: Lists the problems encountered by viewers, which may or may not affect operations.
- **Trap Table**: Lists the traps received from the device. An automatic cleanup mechanism is available that prevents endlessly growing tables.
