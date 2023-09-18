---
uid: Connector_help_Skyline_Smart_Serial_Client_Example
---

# Skyline Smart Serial Client Example

This is a smart serial example protocol, which can be used to simulate a serial device. This protocol queries the target device and can be used to gain an understanding of the smart serial communication implementation in a DataMiner protocol.

## About

Load the included *Data.xml* file into the "Skyline Smart Serial Server Example" protocol and set up both protocols to communicate with each other.

The protocol contains one page with two buttons. Both buttons can be used to query the device (or in this case the simulation).

- The first button will poll each parameter individually using a separate command each time.
- The second button will poll all parameters at the same time using a single command.

Refer to the additional document "Serial Protocol Description" for more information on all the commands and responses used in this example protocol.

## Installation and configuration

### Creation

#### Smart Serial Connection

This connector uses a smart serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- **Type of port**: The type of port used for communication with the device, e.g. *TCP/IP.*
- **IP address/host**: The polling IP of the device, e.g. *127.0.0.2.*
  Ensure that the configured IP address is outside the local IP address range recognized by DataMiner. Use any address in the 127.0.0.\* range except for 127.0.0.1. This is necessary because of the way DataMiner receives and forwards smart serial data internally, and is only required when both client and server are running on the same host.
- **IP Port:** The polling port of the device, e.g. *12345*.

### Configuration

You will also need to configure an element using the "Skyline Smart Serial Server Example" protocol. Use the IP configuration mentioned above when running both server and client protocols on the same host. You can use the example values above if they are not yet in use.

In addition, make sure to import the data from the *Data.xml* file.

## Usage

### Help Page

This page displays information about the connector and its functionality.

### Basic Serial Page

This page displays two buttons that are used to poll the displayed parameters.

- The first button polls each parameter individually using a separate smart serial command.
- The second button polls all parameters at once using a single smart serial command.

Refer to the "Serial Protocol Description" file for more details.

## Notes

Some of the implemented functionality also requires specific triggers and actions. Be aware of this when examining the protocol.

Refer to the protocol development documentation for further information.
