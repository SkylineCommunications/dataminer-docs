---
uid: Connector_help_Rohde_Schwarz_THR9_FM_N+1_-_Transmitter
---

# Rohde Schwarz THR9 FM N+1 - Transmitter

This exported connector shows data from a transmitter module in a Rohde Schwarz THR9 FM N+1.

## About

This protocol can be used to monitor and perform basic configuration on the parent element and generated DVEs.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Tx - Transmitters

This page contains a summary table. It allows you to enable or disable the transmitter with the **Transmitter Operation Mode**. Some basic power parameters are displayed, such as the **Efficiency**, the **Nominal Power** and the actual power of the device.

### Tx - Exciter

On this page, the **Exciter Frequency** and **Output Attenuation** can be adjusted.

### Tx - Input/Output

This page provides a summary of the in-and outputs for the relevant DVE.

### Tx - Amplifier

This page provides information related to the values from amplifiers 1 and 2 (for each transmitter).

### Tx - Amplifier Status

This page provides information related to the status from amplifiers 1 and 2 (for each transmitter).

### Liquid Cooling

This page displays a summary of the liquid cooling state for each transmitter.

## Notes

When you create an **alarm template**, keep in mind that the value for the **State** columns is not the same for all rows; each row is a different parameter. The alarm template can be configured to have different alarms for different row values with the **filter** option.

For example, if there is a row with parameter *Transmitter Summary,* then it is logical that the **State** value *Ok* is a normal value. But if the row with parameter *Locally Controlled* has the value *Ok*, this could be an alarm value.
