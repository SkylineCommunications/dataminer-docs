---
uid: Connector_help_Mitsubishi_FX3U-ENET-ADP
---

# Mitsubishi FX3U-ENET-ADP

This connector can be used to monitor and configure an Ethernet interface block FX3U-ENET.

## About

The Mitsubishi FX3U-ENET-ADP Ethernet module is an interface module on the PLC side for connecting the FX3G/FX3U/FX3UC series PLC with the host system, such as a personal computer workstation, and other PLCs using the TCP/IP or UDP/IP communication protocol via Ethernet (100BASE-TX, 10BASE-T).

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

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### Import CSV

On this page, you can set the file path to read and fill in the respective tables.

### Data Register

This page displays the **Data Register Table**, with values from the device. Depending on the client access (read only or read/write) of the memory address, you can set a new value to that parameter.

Table polling can be enabled or disabled.

### Internal Relay

This page displays the **Internal Relay Table**, with values from the device. Depending on the client access (read only or read/write) of the memory address, you can set a new value to that parameter.

Table polling can be enabled or disabled.

### Effekt

On this page, the parameters **Engine Effekt Tag** and **Engine Effekt Reference Tag** must be filled in with the corresponding tags from the **Data Register Table.**

If these parameters have the correct tags, the parameters **Effekt** and **SRW** will be calculated as follows:

- Effekt = Sqrt(Engine Effekt \* Engine Effekt Reference ) \* 1.126
- IF Engine Effekt Reference \> 0 Then SWR = Engine Effekt / Engine Effekt Reference
  Else
  SWR = 0
  Endif
