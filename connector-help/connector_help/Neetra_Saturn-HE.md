---
uid: Connector_help_Neetra_Saturn-HE
---

# Neetra Saturn-HE

The Neetra DAB+ air-cooled transmitters line makes it possible to implement low-/medium-/high-power broadcasting sites with optimal space requirements. The central control unit that collects all the operating parameters from the amplifiers and from the antenna system provides a single control point with access to all information on currents of power devices, power supply voltages, temperatures of the heat sinks, amplifier output power, and the RF power reading of the output antenna system.

This connector allows you to control the Neetra Saturn-HE via an SNMP connection. The connector layout resembles the web interface of the device.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                           | **Based on** | **System Impact**                                                      |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------|--------------|------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                                                                           | \-           | \-                                                                     |
| 1.0.1.x \[SLC Main\] | Changed some parameter descriptions (DAB Modulator, on the Main page) to make them more user-friendly after DAB Modulator software update. | 1.0.0.4      | The parameter name change can affect filters, Automation scripts, etc. |

### Product Info

| **Connector Range** | **Device Firmware Version**                                                                                                                              |
|---------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x             | DAB Modulator = 6.17 DAB Amplifier Control (transmitters with more than 1 amplifier) = 10.14 DAB MPL (DAB transmitters with only 1 amplifier) = 2.18     |
| 1.0.1.x             | DAB Modulator = **7.12** DAB Amplifier Control (transmitters with more than 1 amplifier) = 10.14 DAB MPL (DAB transmitters with only 1 amplifier) = 2.18 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page contains general information about the equipment, such as **System Description**, **Contact**, **Name** and **Location**.

For information about the **DAB Configuration** page button, refer to the note about polling below.

### DAB Modulator

On this page (and its subpages), you can configure and control the DAB Modulator, with parameters such as the **Output Frequency**, **Mode**, **GPS** information and **Precorrection**.

### DAB Amplifier Control

On this page (and its subpages), you can monitor and control the transmitters that have more than one amplifier.
You can monitor up to eight slaves and change the amplifier settings, such as **Output Power**, **Frequency** and **Minimum and Maximum Thresholds**.

### DAB MPL

On this page (and its subpages), you can monitor and control DAB transmitters with only one amplifier.
You can monitor all the **voltages** and **currents**, change the **frequency** and **mode** settings, etc.

### Web Interface

This page provides access to the web interface of the device. However, this is only available if the LAN where it is accessed has access to the IP of the device.

## Note about polling

This connector was originally designed to poll all the modules: **DAB Modulator**, **Amplifier** and **MPL**. However, as not all modules are always available/configured, it is not always necessary to poll all the data. This is why in later versions of the connector you can improve connector performance by disabling the polling of information. You can do so via the **DAB Configuration** page button on the General page.

Since it is not possible to retrieve how many slaves are configured (and what their position is) or how many MPL alarms there will be (based on Vx and Ix information), you can also manually prevent the polling of certain features and thus improve connector performance.
