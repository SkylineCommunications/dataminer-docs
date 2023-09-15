---
uid: Connector_help_Skyline_Smart_Serial_Server_Example
---

# Skyline Smart Serial Server Example

This is a smart serial example protocol, which can be used to simulate a serial device. This connector receives incoming serial commands and, if configured to do so, replies with the corresponding outgoing serial response. This connector can be used in conjunction with the "Skyline Example Serial Client" (Basic or Advanced) to test its functionality. It is also possible to use the "Skyline Example Smart Serial Client" protocol for this; however, some additional prerequisites apply in that case.

## About

In order to use this protocol, you will need to load the included *Data.xml* file into the protocol.

The protocol contains a Help page and one additional page. The latter contains a table, two buttons and three parameters, one of which can be set. Set the **Import XML** parameter with the full path of the *Data.xml* file and click the **Import** button.

There is also a "Serial Protocol Description" document available with this protocol, which can provide additional information on the available serial commands and responses.

## Installation and configuration

### Creation

#### Smart Serial Connection

This connector uses a smart serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- **Type of port**: The type of port used for communication with the device, e.g. *TCP/IP.*
- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1.*
- **IP Port:** The polling port of the device, e.g. *12345*.

Because of the way DataMiner handles smart serial communication, there are additional requirements when using a smart serial client. The following configuration should be set up in order to enable this behavior:

- **Type of port**: The type of port used for the communication with the device, e.g. *TCP/IP.*
- **IP address/host**: The polling IP of the device, e.g. *any.* Use the IP address *any* to ensure that this protocol will receive smart serial communications from the local DMA.
- **IP Port:** The polling port of the device, e.g. *12345*.

Note: Make sure that the smart serial client element is configured with an IP address outside the local IP address range recognized by DataMiner. Use any address in the 127.0.0.\* range except for 127.0.0.1. This is necessary because of the way DataMiner receives and forwards smart serial data internally and is only required when both client and server are running on the same host.

### Configuration

In order to test this protocol and see it in action, a client protocol is required. Use the "Skyline Example Serial Client" protocol (Basic or Advanced) or the "Skyline Example Smart Serial Client" protocol for this. Use the IP configuration mentioned above when running both server and client protocols on the same host. You can use the example values above if they are not yet in use.

In addition, make sure to import the *Data.xml* file and make sure that the corresponding commands and responses are loaded into the table.

## Usage

### Help Page

This page displays information about the connector and its functionality.

### Command Info Page

This page displays the **Commands and Responses Table**, two buttons and three parameters, one of which can be set.

When an incoming serial request is received by the protocol, the Commands and Responses Table will be checked. If the received command is present in the table, the protocol will send the corresponding serial response. Both the most recently received **Incoming Data** as well as the most recently sent **Outgoing Data** are displayed on this page as well.

The **Import XML** parameter displays the full file system path to the *Data.xml* file used to load the commands and responses into the table. Set the correct path and press the **Import** button to load the data into the table.

## Notes

Some of the implemented functionality also requires specific triggers and actions. Be aware of this when examining the protocol.

Refer to the protocol development documentation for further information.
