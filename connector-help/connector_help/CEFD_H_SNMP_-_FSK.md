---
uid: Connector_help_CEFD_H_SNMP_-_FSK
---

# CEFD H SNMP - FSK

The CEFD H SNMP - FSK connector is used by virtual elements created by the **CEFD H SNMP** connector. It displays information on the FSK functionality of the CEFD H SNMP connector.

NOTE: In the ranges **1.x.x.x** and **2.0.0.x**, the created DVE protocol is called **CEFD H SNMP (FSK)** instead.

## About

This connector is **exported** by the CEFD H SNMP connector. It provides information on the FSK functionality and allows the user to monitor and control **BUC and LNB components**.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | 2.4.1                       |
| 1.2.0.x          | 2.6.1                       |
| 2.0.0.x          | 2.6.1                       |
| 2.0.1.x          | 2.6.1                       |

## Installation and configuration

### Creation

In order to generate the DVE using this connector, enter the FSK **Element Name** on the **FSK page** of the [CEFD H SNMP](xref:Connector_help_CEFD_H_SNMP) connector, ranges 1.1.0.x, 1.2.0.x, 2.0.0.x and 2.0.1.x.

## Usage

### BUC

This page contains the following BUC parameters:

- **BUC Power Supply**: Allows you to enable or disable the BUC power control.
- **BUC 10Mhz Reference State**: Allows you to enable or disable the reference.
- **BUC Low Current Limit**: Allows you to set the BUC minimum threshold current.
- **BUC High Current Limit**: Allows you to set the BUC maximum threshold current.
- **BUC FSK Communications**: Allows you to enable or disable FSK communication.
- **BUC FSK Address:** Allows you to specify a BUC address as a value between 1 and 15.
- **BUC** **RF Output**: Allows you to enable or disable Tx carrier output power.
- **BUC Attenuation**: Allows you to set the attenuation level in dB.
- **BUC Power Supply Option**: Indicates if the BUC Power Supply Option has been installed.
- **BUC** **Voltage**: Displays the BUC voltage in V.
- **BUC Current**: Displays the BUC current in mA.
- **BUC Temperature**: Displays the BUC temperature in degrees Celsius.
- **BUC Phase Lock Loop**: Only valid when FSK/BUC is turned on.
- **BUC Power Level**: Displays the BUC output power level.
- **BUC Power Class**: Displays the BUC power class in Watts.
- **BUC Software Version**: Displays the BUC software version.
- **BUC LO Frequency**: Allows you to set the BUC local oscillator frequency (range: 3000 - 65000 MHz).
- **BUC LO Mix**: Determines whether the L-Band carrier is added or subtracted from the LO.
- **BUC Tx RF Frequency**: Displays the BUC Tx satellite frequency.

### LNB

This page contains the following LNB parameters:

- **LNB DC** **Power**: Allows you to enable or disable the LNB power control.
- **LNB** **Reference State**: Allows you to enable or disable the reference.
- **LNB** **Current Low Threshold**: Allows you to set the LNB minimum threshold current.
- **LNB Current High Threshold**: Allows you to set the LNB maximum threshold current.
- **LNB Current**: Displays the LNB current in mA.
- **LNB Voltage:** Displays the LNB voltage in V.
- **LNB LO Frequency**: Allows you to set the receiver local oscillator frequency.
- **LNB LO Mix**: Determines whether the L-Band carrier is added or subtracted from the LO.
- **LNB Rx RF Frequency**: Displays the terminal receiver frequency.
