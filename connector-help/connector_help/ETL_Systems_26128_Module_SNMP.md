---
uid: Connector_help_ETL_Systems_26128_Module_SNMP
---

# ETL Systems 26128 Module SNMP

This protocol is used for DVE child elements representing antenna modules of the ETL Systems 26128 chassis. The DVEs are created by the parent element using the protocol [ETL Systems 26128 SNMP](xref:Connector_help_ETL_Systems_26128_SNMP), from range 1.0.1.x onwards.

All data in the element is obtained from the parent protocol, so no data traffic will be shown for the DVE in the Stream Viewer.

This module shows information useful for antenna modules. This means LNBs, amplifiers, attenuators and radio frequency detectors.

## About

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 1.1                         |
| 1.0.2.x          | 1.1                         |

## Configuration

Elements using this protocol are automatically created by the [ETL Systems 26128 SNMP](xref:Connector_help_ETL_Systems_26128_SNMP) protocol.

## How to use

The DVE consists of the following data pages:

- **General**: Displays general information about the module such as its temperature, supply voltages, attenuator statuses, amplifier statuses and information about the software.
- **LNB**: Allows you to monitor and configure the low-noise block downconverter. You can monitor and set its voltage, monitor the current flowing through its amps, turn the tone on or off, and check the latest Digital Satellite Equipment Control Command (DiSEqC Command).
- **Amplifiers**: Allows you to monitor the bias voltage and status of the amplifiers.
- **Attenuators**: Shows the status, level and bias voltage of the attenuators.
- **RF Detectors**: Allows you to monitor and configure several radio frequency detectors connected to the module. You can monitor their levels and status, and configure their high and low limits.
- **Output Levels**: Shows the levels of the outputs of the module.
