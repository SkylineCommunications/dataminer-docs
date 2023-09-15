---
uid: Connector_help_Skyline_Example_Serial_Client_Basic
---

# Skyline Serial Client Example Basic

This is a basic example serial client protocol, which can be used in conjunction with the "Skyline Smart Serial Server Example" protocol. This protocol queries the target device in a basic way and can be used to gain a basic understanding of the serial communication implementation in a DataMiner protocol.

## About

Load the included *Data.xml* file into the "Skyline Smart Serial Server Example" protocol and set up both protocols to communicate with each other.

The protocol contains one page with two buttons. Both buttons can be used to query the device (or in this case the simulation).

- The first button will poll each parameter individually using a separate command/response pair each time.
- The second button will poll all parameters at the same time using a single command/response pair.

Refer to the additional document "Serial Protocol Description" for more information on all the commands and responses used in this example protocol.

Alternatively, the "Skyline Example Best Practice Server" can be used for testing instead. In that case, load the included Stream data file into the "Best Practice - Generic Server" protocol and set up both protocols to communicate with each other.

## Installation and configuration

### Creation

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of port**: The type of port used for communication with the device, e.g. *TCP/IP.*
- **IP address/host:** The polling IP of the device, e.g. *127.0.0.1.*
- **IP Port**: The polling port of the device, e.g. *12345*.

### Configuration

You will also need to configure an element using the "Skyline Smart Serial Server Example" protocol. The same IP address/port configuration should be used for both elements. You can use the example values above if they are not yet in use.

In addition, the data from the *Data.xml* file also needs to be imported. If you are using the alternative, "Best Practice - Generic Server", please import the data from the *StreamDataBasic.txt* file instead.

## Usage

### Help Page

This page displays information about the connector and its functionality.

### Basic Serial Page

This page displays two buttons that are used to poll the displayed parameters.

- The first button polls each parameter individually using a separate serial pair.
- The second button polls all parameters at once using the same serial pair.

Please refer to the "Serial Protocol Description" file for more details.

## Notes

Refer to the protocol development documentation for further information.
