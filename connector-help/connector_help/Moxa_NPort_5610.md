---
uid: Connector_help_Moxa_NPort_5610
---

# Moxa NPort 5610

The Moxa NPort 5610 connector is used to monitor the multiple serial inputs of the device and configure the basic device settings. The Moxa NPort 5610 is an 8-port RS-232 Rack Mount Serial Device Server.

## About

The connector uses an SNMP connection to retrieve the general device info and monitoring of the serial interfaces. The configuration of the interfaces is done using HTTP calls.

### Version Info

| **Range**     | **Description**                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x              | Initial version.                                                                                                               | No                  | No                      |
| 2.0.0.x              | Extended previous range by adding a second connection to configure the serial interfaces over HTTP.                            | No                  | No                      |
| 2.0.1.x \[SLC Main\] | Cassandra compliant. Added Operating Settings table, Monitor Line table, Monitor Async table and Monitor Async-Settings table. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |
| 2.0.0.x          | 3.2 Build 07020913          |
| 2.0.1.x          | 3.2 Build 07020913          |

## Installation and configuration

### Creation

#### SNMP connection (1.0.1.x and 2.0.x.x range)

This connector uses a Simple Network Management Protocol (SNMP) connection to retrieve the general device info and monitor the interface bitrates. This connection requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device. Required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

#### Serial connection (2.0.x.x range)

This connector uses a serial connection to configure the serial interfaces and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device. Required.
  - **IP port**: The IP port of the device, by default *80*.

## Usage

### General

This page is used to update the **Device Name** and contains the **Bitrates** table. This table displays the Ethernet interface as well as the serial interfaces on the device, along with the current bitrates of each interface.

### Serial Settings

This page contains the **Serial Settings Table**, which provides an overview of the multiple serial interfaces on the serial gateway (ports 1-8) and allows the configuration of these interfaces.
The **Save/Restart** button at the top of the page is used to commit the changes to the device.

### Operating Settings

This page contains the **Operating** **Settings Table**, which allows you to check and modify settings of the interfaces.
The **Save/Restart** button at the top of the page is used to commit the changes to the device.

### Monitor

This page contains the read-only **Monitor Line**, **Monitor Async** and **Monitor Async-Settings** tables.

### Web Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
