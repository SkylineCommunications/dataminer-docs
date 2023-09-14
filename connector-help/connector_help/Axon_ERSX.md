---
uid: Connector_help_Axon_ERSX
---

# Axon ERSX

The **Axon ERSX** connector can be used to display and configure information of the Axon ERS central controller and the attached card types located in its different slots.

## About

This protocol can be used to monitor and control the Axon ERS main controller and the card types attached to the Axon frame. An **SNMP** connection is used in order to successfully retrieve and configure the device's information. In addition, there are different **alarming** en **trending** possibilities for the supported Axon card types.

### Protocol Version

Each version of the Axon ERSX protocol consists of a unique set of numbers. The first two numbers of the protocol version represent the **ERS Number** and **Firmware** of the main controller. The last two numbers of the protocol version represent the firmware range.

For instance: 10.98.0.1

- 10: Indicates that the supported main controller in the related protocol version is of type ERS10.
- 98: Indicates that firmware version 98 is supported for the ERS10 main controller in the related protocol.
- 0: Indicates firmware range 1 of the card types in the related protocol version.
- 1: Indicates the update number of the related protocol.

### Card Types & Firmware

The Axon ERSX protocol can be used for different Axon cards. However, since the OIDs change in different firmware versions of the same Axon card type, this protocol only supports some card types and their firmware. The supported Axon card types and firmware for the related protocol version can be found in the table below.

| Traps     | 2IX08 | 2IX11 | 2TG10 | ASI10 | DAD08 | DAD26 | DIO48 | GDR26 | GPI16 | HAF90 | HDR07 | HDR09 | HDS05 | HEB05 | SAV08 | SDR07 | SDR08 | SDR09 | SLI10 | GDR10 |     |
|-----------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----|
| 10.98.0.1 |       | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |
| 10.98.0.2 |       | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |
| 10.98.0.3 |       | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 09    | 06    | 29    |     |
| 10.98.0.4 | X     | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 09    | 06    | 29    |     |
| 10.98.1.4 | X     | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |
| 11.88.0.1 | X     | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    | 38  |
| 11.98.0.1 |       | 24    | 02    | 80    | 08    |       | 01    | 06    | 07    | 10    | 30    | 04    |       | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |
| 11.98.0.2 |       | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |
| 11.98.0.3 |       | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |
| 11.98.0.4 |       | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 09    | 06    | 29    |     |
| 11.98.0.5 | X     | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 09    | 06    | 29    |     |
| 11.98.1.5 | X     | 24    | 02    | 80    | 08    | 07    | 01    | 06    | 07    | 10    | 30    | 04    | 04    | 26    | 07    | 07    | 02    | 10    | 06    | 29    |     |

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device (default: *161*).
- **Get community string:** The community string needed to read from the device. The default value is *public.*
- **Set community string:** The community string needed to set to the device. The default value is *public.*

## Usage

The Axon ERSX protocol delivers two types of DataMiner Elements: a main element representing the main controller and one virtual element for each attached card (slot) of the frame.

### Main Element

The connector's main element contains the following pages:

- **ERSX**: The ERSX page provides an overview of the Axon main rack controller. Aside from this, you can also specify a view in which the created virtual element for the main rack controller will be added.
- **Cards**: For every supported card type of the Axon frame, a page button is provided on the Cards page. When you open a page for a card type, an overview is given of all slots for this particular card type. You can also specify a view in which all created virtual elements for this type of card will be added.

### Virtual Elements

For every attached card in a slot of the Axon frame, a Dynamic Virtual Element is created with a specific name (**Main Element Name** followed by the **Slot Number** in question, for instance *AxonS02*). Each of these DVEs contains the following main pages:

- **General**: The General page of the created DVE contains general information (*Slot Number*, *Card Name*, etc.) regarding the card type, of which some (for instance: *User Label*) is modifiable.
- **Alarm Priority**: The Alarm Priority page contains the specific priority settings of the Axon card in question.

Every supported card type of the Axon frame has its own specific features and capabilities. All of the card-related settings and statuses are provided on extra pages which depend on the type of Axon card. The following pages are included in the Axon ERSX protocol:

#### General Statuses and Settings

It is possible that the Axon card type contains some general statuses and settings that are not related to any of the card's specific functionality. For this reason, the **Status** and **Settings** pages were added to the Axon ERSX protocol.

#### Card Specific Statuses

Some of the supported Axon card types have some statuses that have to do with the card's capability and usability. These statuses are shown on card-related pages: **Add On**, **Delay Status**, **Input**, **MIB**, **Module** and **Output**.

#### Card Specific Settings

The Axon ERSX protocol also provides some extra pages regarding specific settings for the related card types: **AES**, **Amplifier**, **Audio**, **Channel**, **Delay**, **Embedder**, **GPO**, **Inserter**, **Logo**, **Network**, **Text Ident** and **Video**.

## Monitoring

The Axon ERSX protocol provides a very useful DataMiner feature: every supported Axon card type can be provided with alarming and trending possibilities, specific for the type of card.
