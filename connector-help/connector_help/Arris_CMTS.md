---
uid: Connector_help_Arris_CMTS
---

# Arris CMTS

This device manages and controls the **Arris cable modem** in HFC networks.

With this connector, you can keep track of the **cable modems** that are **online**, **starting**, and **offline**. You can also monitor the basic **downstream** and **upstream** channel parameters.

## About

### Version Info

| **Range**            | **Description**                                                                              | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                             | No                  | No                      |
| 1.1.0.x              | Release version.                                                                             | No                  | No                      |
| 1.0.2.x \[Obsolete\] | Release version with C4 and CCAP model device autodetection.                                 | No                  | No                      |
| 1.0.3.x \[Obsolete\] | Display key column added (Signal Quality Table), naming format for correct alarm monitoring. | No                  | No                      |
| 1.0.4.x              | Cassandra compliant.                                                                         | No                  | Yes                     |
| 1.0.5.x \[SLC Main\] | DCF feature added.                                                                           | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version** |
|-----------|-----------------------------|
| 1.0.0.x   | \-                          |
| 1.1.0.x   | \-                          |
| 1.0.2.x   | \-                          |
| 1.0.4.x   | \-                          |
| 1.0.5.x   | \-                          |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP connection

- **IP address/host:** The polling IP of the device.

SNMP settings:

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

Once created, the element can be used immediately.

### General

This page displays general information, such as the **device name**, **location** and **contact**, and **uptime**. The page also indicates which cable modems are **online**, **offline**, and **initializing**. The nominal values used to calculate the percentages on this page can be configured.

### Cable Mac Statistics

This page displays information regarding the cable MAC domains summary and cable MAC channel summary and its rates.

### Configuration -- Upstream Channels

On this page, you can monitor parameters such as **frequency**, **bandwidth**, **modulation**, **slot size**, and **name** of the available upstream channels.

### Configuration -- Downstream Channels

On this page, you can monitor parameters such as **frequency**, **bandwidth**, **modulation**, **interleave**, and **power** of the available downstream channels.

### Measurements -- Upstream Channels

On this page, you can monitor parameters such as cable model upstream channel **offline**, **online**, and **initializing** elements, the **channel capacity**, **bitrate**, and **utilization**, as well as the **signal to noise ratio**, **error**, **unerror**, and **corrected bits**, and the **consecutive/non-consecutive alarm state**.

### Measurements -- Downstream Channels

On this page, you can monitor parameters such as cable model downstream channel **offline**, **online**, and **initializing** elements, the **channel capacity**, **bitrate**, and **RF** **utilization**, as well as the **signal to noise ratio**, **error**, **unerror**, and **corrected bits**, and the **consecutive/non-consecutive alarm state**.

### Measurement - Gigabit Interfaces

On this page, you can monitor parameters such as **bitrate**, **utilization**, **capacity**, **status**, and **state** for the interfaces of type Gigabit.

### Interfaces

This page displays information about the interfaces, such as the **type**, **bandwidth**, **state**, **administrative** **status**, and **operational status**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, otherwise it will not be possible to open the web interface.

## Notes

Since version 1.0.2.1 of this connector, CMTS type detection between C4 and CCAP models has been implemented. This detection is based on the SNMP MIB-2 sysDescr OID object.
