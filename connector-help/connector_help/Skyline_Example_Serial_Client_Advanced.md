---
uid: Connector_help_Skyline_Example_Serial_Client_Advanced
---

# Skyline Serial Client Example Advanced

This is an advanced example serial client protocol, which can be used in conjunction with the "Skyline Smart Serial Server Example" protocol. This protocol queries the target device in a number of different ways and can be used to gain some advanced understanding of the serial communication implementation in a DataMiner protocol.

## About

Load the included *Data.xml* file into the "Skyline Smart Serial Server Example" protocol and set up both protocols to communicate with each other.

The protocol contains three pages that display a list of parameters and a button. Clicking the button will poll the device (or in this case the simulation). Each page implements a different serial pair with its own particularities.

Refer to the additional document "Serial Protocol Description" for more information on all the commands and responses used in this example protocol.

## Installation and configuration

### Creation

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of port**: The type of port used for communication with the device, e.g. *TCP/IP*.
- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1*.
- **IP Port:** The polling port of the device, e.g. *12345*.

### Configuration

You will also need to configure an element using the "Skyline Smart Serial Server Example" protocol. The same IP address/port configuration should be used for both elements. You can use the example values above if they are not yet in use.

In addition, the data from the *Data.xml* file also needs to be imported. If you are using the alternative "Best Practice - Generic Server", import the data from the *StreamDataBasic.txt* file instead.

## Usage

### Help Page

This page displays information about the connector and its functionality.

### Advanced - Fixed Length and CRC Page

This page displays a list of parameters and a button. The button is used to poll the device (or in this case the simulation) and retrieve the data to fill into the displayed parameters.

This particular pair implements a fixed length parameter of type response that is used to store the whole response from the polled device. This serial pair also implements a CRC check.

### Advanced - Variable Length Response Page

This page displays a list of parameters and a button. The button is used to poll the device (or in this case the simulation) and retrieve the data to fill into the displayed parameters.

This pair uses a variable length parameter of type response, of which the length is sent by the device and stored in an auxiliary parameter.

### Advanced - Variable Length Parameter

This page displays a list of parameters and a button. The button is used to poll the device (or in this case the simulation) and retrieve the data to fill into the displayed parameters.

This pair implements a variable length parameter (LengthType = next param) and a trailer data field.

## Notes

Some of the implemented functionality also requires specific triggers and actions. Be aware of this when examining the protocol.

Refer to the protocol development documentation for further information.
