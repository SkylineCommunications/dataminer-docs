---
uid: Connector_help_Sennheiser_SR2050
---

# Sennheiser SR2050

The Sennheiser SR 2050 IEM is a 2-channel/stereo monitoring transmitter that can directly monitor received sound signals without any need for cables or monitor speakers. The transmitter can also be used for any application where talkback signals are to be transmitted.

This connector will monitor the different attributes configured in the SR 2050 IEM.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.8.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses a serial connection to send the requests and an UDP/IP connection with a listening socket to receive the corresponding responses.

The following input is required during element creation:

- *Serial Connection:*

- **Type of port:** By default UDP/IP.
  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201.*
  - **IP port**: The IP port of the destination (default: *53212*).

- *IP Connection - Listener:*

- **Type of port**: By default UDP/IP.
  - **IP address/host**: *any*.
  - **IP port**: The IP port of the destination (default: *53212*).

**Note:** The option "any" defines that the element will have an UDP socket listening for any incoming request on the IP address of the DataMiner Agent where the element resides and on the configured IP port.This is needed because the product always replies to a specific port and not to the port that originated the communication, so that two connections are required to process the requests and receive the responses.

## How to use

- **General**: This page shows basic information about the device such as the firmware version and transmitter name.
- **State**: This page shows the warnings indicated by the transmitter and the current audio modulation (AF).
- **Configuration**: This page allows you to monitor and set attributes like Sensitivity, Mode, and Mute. It also contains an overview of the frequency values. The Frequencies List table indicates all the possible frequencies that have been pre-defined (fixed values) and that correspond to a specific bank and channel number. You can select one of these fixed frequencies (by clicking the Set Frequency button), or you can define a new frequency (which must be a multiple of 25 kHz).
- **Error Log**: This page shows a table logging all error messages sent by the transmitter, including a description, the origin of the error, the date of the event, etc. This can be used for debugging.
