---
uid: Connector_help_Rohde_Schwarz_DAB_NV8203
---

# Rohde Schwarz DAB NV8203

This connector is used to monitor the DAB transmitter (including power values, exciter and amplifier states, input signal states, CCU monitoring, summary faults and logbook). It also allows automatic input selection and configuration.

## About

This is an **SNMPv2** protocol. Traps are not implemented.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**                                                  |
|------------------|------------------------------------------------------------------------------|
| 1.0.0.x          | Software Identification Number: 2095.8613.00 Software Version Number: 1.33.0 |

## Installation and Configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays the most important parameters related to the normal operation of the device.

It also contains a page button to display some system information parameters such as **System Name**, **Software Version**, **Contact**, etc.

### UPS

This page displays parameters related to the status of the UPS.

### Logbook: x

There are three logbook pages, each containing one logbook, a parameter indicating the number of entries in the log and two buttons to respectively refresh and clear the logbook. Note that clearing the logbook should also automatically refresh it.

As polling of the logbook happens only at slow intervals, by default once every hour, use the **Refresh** button to make sure the logbook is refreshed.

Available logbooks are:

- CCU
- Exciter A
- Output Stage A

### Exciter Status

This page displays the parameters from the **Exciter Status Table**, which provide information on the transaction status. The parameters on this page are:

- Active Tx Mode
- Active TII Main Id
- Active TII Sub Id
- Frame Structure Match
- Delay Difference
- SFN Deviation Time
- Tx Compensation Delay
- Tx Processing Delay
- Active Tx Offset Delay
- Overall Signal Delay
- PRBS Synchronized
- Bit Error Rate
- Ensemble Name
- Ensemble ID
- Fail Delay

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

In version **1.0.0.2** of this connector, the **Nominal Power** parameter (PID 100), which had to be configured manually, is removed and **replaced** by parameter **Rf Probes Ant Fwd Nominal** (PID: 2000). This parameter is retrieved from the device, so that no extra configuration is required.
