---
uid: Connector_help_Snell_Wilcox_IQSDA01
---

# Snell Wilcox IQSDA01

The IQSDA01 is a Intelligent Reclocking High Performance HD-SDI/SD-SDI Distribution Amplifier. The device provides up to seven re-clocked outputs for HD-SDI 1.5 Gbit/s or 270 Mbit/s SD-SDI signals, four re-clocked outputs for DVB-ASI signals, or even non re-clocking distribution of wide band signals. Its 140m HD input equalization performance makes it a capable HD-SDI DA.

## About

The IQSDA01 card can be inserted in a Snell & Wilcox IQ-Modular framework. Fitting up to 16 modules (3RU) with full redundancy in a hot swappable flexible architecture. This framework also allows to monitor all its cards by SNMP or the vendor specific RollCall protocol. Which is used by this connector for all communications. To do this the cards address will have to be provided when creating a new element.

Device features include:

- Intelligent HD-SDI and SD-SDI/DVB-ASI re-clocking distribution amplifier.

- Distributes DVB-ASI (outputs 1, 3, 5, 7) and other wide band signals.

- Equalizes up to 140 m at 1.5 Gbit/s and up to 350 m at 270 Mbit/s of Belden 1697A cable.

- Supported standards

- HD-SDI to SMPTE292M
  - SD-SDI to SMPTE259M-C
  - DVB-ASI

- RollCall monitoring

- 16 user configurable memories;

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

On this page you can find some important parameters like **Auto** (Input), **Force STD** & **Reclock Bypass**.
The page also contains page-buttons which open the **Logging** and **Menu** pages. And there are two buttons to restart or reset the device.
Futher there is also a **Display** parameter which should reflect the text on the front pannel of the device.
And finaly some version information including **Software Version** and **Serial**.

### Memory

On this page are the parameters to configure the user edditable memory slot.
Each slot has a **Save** and **Recall** button below it.

### Connection Info

On this page some extra parameters can be found about the connection. Most will have no importance to the operators, unless maybe during setup of elements or for finding connection problems.
The two most important parameters are: **Session Status** and **Card User Name**. The session status should shortly after startup be set to *Connected* and never change again. If no session can be established after startup, the status will remain *Not Initialized* and if a connection had been established, but was broken by the device, the value should change to *Disconnected*.

Note:
The **Session Status** refers to the logical connection instead of the physical connection. This means that it is possible that the device will go in timeout (physical connection lost), while the **Session Status** (logical) remains *Connected*. This situation would indicate that no response was received on messages send to the device. Though usually the logical session will also get disconnected when the physical connection is interrupted. In that case the connector will detect this when the device becomes accessible again (= physical connection restored and device out of timeout state) and shortly set the **Session Status** to *Disconnected,* until a new session is established*.* (Which should take less than 15 seconds.)

A other important parameter is the **Force Poll** button.
As can be expected all parameters will be refreshed after clicking this button.
Note: that this is the only real "polling" mechanism in the connector. All other parameter updates are event driven.
(The same happens else only after a new session is established. This can be either after element startup, or when the session was disconnected by the device.)

The last important parameter is the **Card User Name**.
This parameter contains the name which is also displayed in the software from Snell & Wilcox to identify the cards.

The other parameters **Unit Address** & **Unit Port** contain respectively the unit and port parsed from the elements bus address.
The parameters **Local Session Nr** and **Assigned Session Nr** can be used to identify the traffic between the element and the card during network analysis. Any non-zero **Assigned Session Nr** indicates that the **Session Status** is *Connected*. The Local Session Nr is always the combination of the unit address and port of the monitored card.

## Notes

As mentioned in the "Configuration" section, the element will automatically stop if the bus address could not be parsed.
This should prevents sets to a random element (or broadcasted to all elements.)

If the element was stopped for this reason, the log file will contain a message to indicate this.
