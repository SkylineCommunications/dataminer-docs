---
uid: Connector_help_Rohde_Schwarz_THR9_FM_N+1
---

# Rohde Schwarz THR9 FM N+1

The **Rohde Schwarz THR9 FM N+1** is an FM Audio Transmitter system capable of configuring multiple transmitters in an N+1 setup in a single rack.

## About

This protocol can be used to monitor and perform basic configuring on the parent element and generated DVEs.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

### Exported connectors

| **Exported Connector**                                                                                              | **Description**    |
|--------------------------------------------------------------------------------------------------------------------|--------------------|
| [Rohde Schwarz THR9 FM N+1 - Transmitter](xref:Connector_help_Rohde_Schwarz_THR9_FM_N%2B1_-_Transmitter) | Transmitter Module |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

The **Rohde Schwarz FHR9 FM N+1** protocol generates a virtual element (**DVE**) for each transmitter in the rack/frame, defined by the **Rohde Schwarz THR9 FM N+1 Transmitter** protocol. Each DVE automatically receives a specific name based on the slot number of the device and the main element's name, e.g. "*Rohde Schwarz FHR9 FM N+1.Transmitter A2"*.

### Main Element

#### Devices

On this page, the **Transmitter Control Table** provides a summary of all available transmitters in the rack, mentioning among others the **Redundancy Mode**, the **Amplifier Type** and the **State of the DVE.**

#### Backup Configuration

On this page, you can configure the redundancy settings. Tooltips provide information about each parameter.

In the **Program Table**, you can add or remove a transmitter from the N+1 configuration with the **Program Changeover. Program Operation Mode** is used to enable or disable a transmitter.

If a transmitter has been taken over by the backup transmitter, this is shown with the **Loaded Transmitter** parameter. Enabling or disabling the N+1 configuration is done with the **Operation Mode**.

#### Liquid Cooling

This page provides a summary of the cooling of each slot in the rack.

Note that the index is not a concatenation of the transmitter index and the parameter number, but a concatenation of the rack **slot number** and the **parameter number**.

#### Liquid Cooling Pump

This page provides a summary of the liquid pump state information, such as the **communication state**, **summary state** and the **current flow rate**.

#### Transmitter pages

These pages provide a summary related to the following items:

- **Mobile Transmitters**
- **Tx - Transmitters**
- **Tx - Exciters**
- **Tx - Input/Output**

### Virtual Elements

#### Tx - Transmitters

This page contains a summary table, and allows you to enable or disable the transmitter with the **Transmitter Operation Mode**. Some basic power parameters are displayed, such as the **Efficiency**, the **Nominal Power** and the actual power of the device.

#### Tx - Exciter

On this page, the **Exciter Frequency** and **Output Attenuation** can be adjusted.

#### Tx - Input/Output

This page provides a summary of the in-and outputs for the relevant DVE.

#### Tx - Amplifier

This page provides information related to the values from amplifiers 1 and 2 (for each transmitter).

#### Tx - Amplifier Status

This page provides information related to the status from amplifiers 1 and 2 (for each transmitter).

#### Liquid Cooling

This page provides a summary about the liquid cooling state (for each transmitter).

### Notes

When creating an **alarm template**, keep in mind that the value for the **State** columns is not the same for all rows; each row is a different parameter. The alarm template can be configured to have different alarms for different row values with the **Filter** option.

For example, if there is a row with parameter *Transmitter Summary,* then it is logical that the **State** value *Ok* is a normal value. But if the row with parameter *Locally Controlled* has the value *Ok*, this could be an alarm value.
