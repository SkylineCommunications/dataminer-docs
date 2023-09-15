---
uid: Connector_help_iDirect_X5_Satellite_Router
---

# iDirect X5 Satellite Router

This is a serial connector that uses Telnet to retrieve certain parameters of the router.

## About

Several parameters have been pointed out to be retrieved using a Telnet connection. Unsolicited messages from the device are disabled with the *xoff* command. This means the protocol type could be made serial rather than smart-serial.

## Installation and configuration

This connector uses a serial connection and requires the following input during element creation:

**SERIAL Connection**:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13.*
- **IP port**: The Telnet port of the connected device, by default *23.*
- **Retries:** Set to zero by default, as the login is required when the connection is lost.

**Authentication:**

- **Username**: The username required to access the device. No communication attempts will be made until this is provided.
- **Password**: The password associated with the username.

## Usage

### General

This is currently the only page for this protocol. At the top of the page, you can find the login input and status, and below this are the available parameters.

Note that changing the username while connected will force an exit, after which the login process will start over.

**Login Status**:

- **Connected**: The protocol is logged in.
- **Not Connected**: The protocol has not yet connected. It will wait until a username is entered.
- **Access Denied**: Username and password combination is wrong.

Currently available parameters:

- **Rx SNR**
- **Rx Power**
- **Rx Freq Offset**
- **Rx Freq**
- **Tx Power**
- **Tx Max Power**
- **Tx Freq**
- **Current Beam ID**
- **Falcon Image version**
- **Linux Image Version**
- **Board Temperature**
