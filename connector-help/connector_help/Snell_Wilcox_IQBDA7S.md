---
uid: Connector_help_Snell_Wilcox_IQBDA7S
---

# Snell Wilcox IQBDA7S

The IQBDA7S provides either dual analog inputs with seven outputs per input, or a single analog input with 14 outputs.

## About

The IQBDA7S card can be inserted in a Snell & Wilcox IQ-Modular framework. Fitting up to 16 modules (3RU) with full redundancy in a hot swappable flexible architecture. This framework also allows to monitor all its cards by SNMP or the vendor specific RollCall protocol. Which is used by this connector for all communications. To do this the cards address will have to be provided when creating a new element.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- IP address/host: The polling IP of the device. (This is the IQ-Modular framework.)
- IP port: The IP port of the device. The default value is *2050*.
- Bus address: Indicates the slot and port on which the IQAVDR card can be found.
  The format of the bus address is UU.PP, where UU should be replaced by the unit address and PP should be replaced by the Port.
  Both values should be hex encoded. Example: "15.0A"

Note:
If you have installed the "RollCall Control Panel" software (, by Snell & Wilcox) and have the interface of the card open, then the full address should be visible under the tab "Connected Units". This could look like "0000:11:01". You need the "11:01" but should replace the semicolumn with a dot '.' to "11.01". (Note also that the network address should always be "0000" because the connector does not support communication over bridges.

### Configuration

The connector needs no configuration except for the card address, which needs to be configured in the **bus address** field in the element wizard.
If the value cannot be parsed as a valid slot number the connector will automatically and immideatly stop after startup. This to make sure that no commands (and espetially sets) are send to a random device.

The log file will contain a message indicating that the connector failed to parse the bus address and the expected format of the address.

## Usage

### General

On this page you can find two parameters to set the Gain: **Channel Left** & **Channel Right**.
There are also two parameters to enable/disable logging: **Log: Silence Left** and **Log: Silence Right**.
Futher there is also a **Display** parameter which should reflect the text on the front pannel of the device.
And finaly the **Software Version** and **Serial No** + a parameter to restore the units presets. (**Preset Unit**).

### Menu

On this page are several parameters related to stored variables.

### Connection Info

On this page some extra parameters can be found about the connection. Most will have no importance to the operators, unless maybe during setup of elements or for finding connection problems.
The two most important parameters are: **Session Status** and **Card User Name**. The session status should shortly after startup be set to *Connected* and never change again. If no session can be established after startup, the status will remain *Not Initialized* and if a connection had been established, but was broken by the device, the value should change to *Disconnected*.

Note:
It is possible that the device will go in timeout, while the **Session Status** remains *Connected*. This would indicate that no response was received on messages send to the device. However that doesn't necessarily mean that the session itself would be closed by the device. The session will only be closed if during a period of network problems messages from the card (containing parameter updates) would be lost. (And thus not acknowledged.) In that case the connector will detect this when the device becomes accessable again and shortly set the **Session Status** to *Disconnected,* untill a new session is established*.*

A other important parameter is the **Force Poll** button.
As can be expected all parameters will be refreshed after clicking this button.
Note: that this is the only real "polling" mechanism in the connector. All other parameter updates are event driven.
(The same happens else only after a new session is established. This can be either after element startup, or when the session was disconnected by the device.)

The last important parameter is the **Card User Name**.
This parameter contains the name which is also displayed in the software from Snell & Wilcox to identify the cards.

The other parameters **Unit Address** & **Unit Port** contain respectively the unit and port parsed from the elements bus address.
The parameters **Local Session Nr** and **Assigned Session Nr** are ussually of totaly no importance, except maybe to indentify the trafic from/to the card in a wireshark capture. Basically the **Local Session Nr** equals the **Unit Port** and a non-zero **Assigned Session Nr** indicates that the **Session Status** is *Connected*.

## Notes

As mentioned in the "Configuration" section, the element will automatically stop if the bus address could not be parsed.
This should prevents sets to a random element (or broadcasted to all elements.)

If the element was stopped for this reason, the log file will contain a message to indicate this.
