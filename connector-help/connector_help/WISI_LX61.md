---
uid: Connector_help_WISI_LX61
---

# WISI LX61

The Model EOS-6000 Optical A/B Switch is a high performance solution for network protection and optical redundancy. This device provides an automatic or manual fiber switching function.

## About

The **WISI LX61** connector is an SNMP based connector used to monitor and configure the EOS-6000 Optical A/B Switch.

## Installation and configuration

**SNMP CONNECTION**:

\- **IP address/host**: the polling IP of the device e.g. *172.27.64.56*

\- **Device address**: is used by the connector e.g. *0*

**SNMP Settings**:

\- **Port number**: the port of the connected device, default *161*

\- **Get community string**: the community string in order to read from the device. The default value is *public*.

\- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General

The general page gives you an overview of all the parameters.
On the left side you can see all the reading parameters, on the right side, you've got the parameters that can be set.
Alarming and trending is possible on the parameters.

The device also uses traps. When the connector receives a trap, the mentioned parameter will be updated.

### Web Interface

Use this page to have access to the Web Interface of the device. According to the IP address
