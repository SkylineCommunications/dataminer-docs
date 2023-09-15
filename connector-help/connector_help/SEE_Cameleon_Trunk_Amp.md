---
uid: Connector_help_SEE_Cameleon_Trunk_Amp
---

# SEE Cameleon Trunk Amp

The SEE Cameleon Trunk Amp connector is used to monitor a SEE Telecom Cameleon trunk amplifier.

## About

This connector needs a connection to be made to the ERHF, which communicates (RF) with all amplifiers that are related to the corresponding headend. The ERHF offers two communications ports, but the one on the back cannot be used, as it only allows synchronous communication, which means an enhanced card should be used (Pin17 is connected, which transfers the timing signals). When you open the ERHF, a connection can be made to a card to communicate asynchronously. This is the connection that should be used.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13*.
- **IP port**: The port of the destination.
- **Bus address**: The bus address that is configured on the device.

## Usage

### Main View page

This page displays general status information about the device. In addition, you can also find the battery disconnect feature here.

## Notes

As the address 4094 is used in a command to disconnect the battery, it cannot be assigned to a device. This has also been included in the protocol.
