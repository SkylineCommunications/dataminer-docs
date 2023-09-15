---
uid: Connector_help_Rohde_Schwarz_AVG050
---

# Rohde Schwarz AVG050

The R&S AVG050 is a dual DVB-S/S2 demodulator equipped with diverse inputs and outputs.

## About

This connector can be used to configure and monitor R&S AVG050 devices. It features real-time monitoring, and allows you to fully control the device, from the general configuration to specific operation procedures.

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Important Note

The device sends traps with empty community strings, which cannot be processed by DataMiner 9.0. This has been fixed in feature release 9.0.5.

Moreover, in DataMiner 9.0.0, WinSNMP blocks traps that have an empty community string, so that the traps do not even make it to DataMiner. In feature release 9.0.3, we have moved away from WinSNMP, so that traps are not blocked from that version onwards.

## Usage

### Device Info

This page displays the main device information, including the **System Description**, **Name**, **Location** and **Contact**, the **device status**, and the device **FANs status** and **temperature.**

It also contains subpages with information about the **boards** and the **hardware** and **SNMP** configuration.

### IP Network

On this page, you can configure and monitor the **ethernet interfaces** of the device, i.e. **Ethernet Rear**, **Ethernet Front 1** and **Ethernet Front 2**.

### Reference Time

This page contains all the necessary information to monitor and control the **NTP servers**.

### BISS-E Key Distribution

On this page, you can monitor and configure the BISS-E Key Distribution.

### DVB-S/S2 Rx 1

On this page, you can monitor and configure the **SAT 1 interface**. This includes the configuration of the **LNB Mode**, **LNB Frequency**, **LNB ADV** and **Demodulator**, as well as general monitoring of the demodulator.

### DVB-S/S2 Rx 2

On this page, you can monitor and configure the **SAT 2 interface**. This includes the configuration of the **LNB Mode**, **LNB Frequency**, **LNB ADV** and **Demodulator**, as well as general monitoring of the demodulator.

### ASI/IP-TS Input

On this page, you can monitor and configure the **ASI Input 1 and 2**, as well as the **TS Over IP Input 1** and **TS Over IP Input 2** interfaces.

### Input Redundancy

On this page, you can monitor and configure **TS Redundancy** 1 and 2.

### CAM 1

On this page, you can monitor and configure **CAM (Conditional Access Module) 1** and **BISS 1**. The page also includes the **Input Service List** table.

### CAM 2

On this page, you can monitor and configure **CAM (Conditional Access Module) 2** and **BISS 2**. The page also includes the **Input Service List** table.

### TS Output

On this page, you can monitor and configure **TS Over IP Output 1** and **ASI Output 1** and **2.**

### IS DVB-S/S2 Rx

This page includes the **TS ID**, **Nit Pid** and **Input Service List** of interface **DVB-S/S2 Rx 1** and **DVB-S/S2 Rx 2**.

### IS ASI/TS-Input

This page includes the **TS ID**, **Nit Pid** and **Input Service List** of interface **ASI 1** and **ASI 2**.

### IS TS Over IP

This page includes the **TS ID**, **Nit Pid** and **Input Service List** of interface **TS Over IP 1** and **TS Over IP 2**.

### Logbook

This page contains all logging information for the device, and allows you to control the log information, e.g. by clearing the log. This page is only polled on startup and must be manually refreshed afterwards.

### Web page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
