---
uid: Connector_help_General_Dynamics_Model_930A
---

# General Dynamics Model 930A

This connector monitors the activity of the General Dynamics Model 930A access control system, which is used for satellite tracking and control. It is specifically suited for single AC fixed antennas and includes an Antenna Control Unit (ACU), Internal Tracking Receiver (TRU), and Power Drive Unit (PDU).

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         | **Based on** | **System Impact**                                                                                       |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          | \-           | \-                                                                                                      |
| 2.0.0.x              | SNMP version                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             | \-           | \-                                                                                                      |
| 2.0.1.x              | **Fix:** - Polarization Mode and Jog Elevation Set. **Changes:** - Parameter name SS Current Freq changed to RX Current Frequency3 - Parameter name Encoder Offset changed to Elevation Encoder Offset. - Parameter name Encoder Rotation changed to Elevation Encoder Rotation. - RX Signal range changed from \[-99.9, 0\] to \[-90,10\]. - Low Signal range changed from \[-99.9,0\] to \[-90,10\]. - Acquire Signal range changed from \[-99.9,0\] to \[-90,10\]. - Azimuth Encoder Offset range changed from \[0,360\] to \[-180, 180\]. - Encoder Offset range changed from \[-5,95\] to \[-180,180\]. - Polarization Encoder Offset range changed from \[0,360\] to \[-180,180\]. | 2.0.0.5      | DMS filters, Automation scripts, Visio files, reports, web API usage, etc. may need to be reconfigured. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.279                  |
| 2.0.0.x   | \-                     |
| 2.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Displays information about the ACU, the device status, the current mode, and the satellite that is being tracked. The subpages display information about the **ACU**, **Satellites**, **Time**, and **Network**.
- **RF**: Contains the Global RF and the Log Amp Attenuation values and configuration. The subpages contain tables for the **RF Parameters**, **RF POL Parameters**, and **Bands**.
- **Position** **Designate**: Displays the current position of the satellite. It also allows you to set the azimuth and elevation. The **GEO** and **Polarization** configuration is available on subpages.
- **Site**: Displays information about the site and the antenna.
- **Presets**: Allows you to check the current presets configuration and set the preset position.
- **Stow/Deploy**: Allows you to set and configure the Stow and Deploy modes.
- **Offset**: Allows you to set and configure the manual offset.
- **Steptrack/Optrack**: Allows you to set and configure the Steptrack and Optrack Modes.
- **MemTrack**: Allows you to set and configure the MemTrack modes.
- **Travel Limits**: Displays the travel limits.
- **Encoder**: Displays encoder information such as the Encoder Type, Encoder Offset, Encoder Azimuth, and Encoder Elevation.
- **Axes**: Displays the Azimuth Axis and the Elevation Axis information of the device.
