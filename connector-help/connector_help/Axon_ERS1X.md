---
uid: Connector_help_Axon_ERS1X
---

# Axon ERS1X

The **Axon ERS1X** connector can be used to display and configure information of the Axon ERS central controller and the attached card types located in its different slots.

## About

This protocol can be used to monitor and control the Axon ERS main controller and the card types attached to the Axon frame. An **SNMP** connection is used in order to successfully retrieve and configure the device's information. In addition, there are different **alarming** and **trending** possibilities for the supported Axon card types.

### Card Types & Firmware

The Axon ERS1X protocol can be used for different Axon cards. However, since the OIDs change in different firmware versions of the same Axon card type, this protocol only supports the following card types and firmware:

- **2IX**-xx: *2IX08v24* and *2IX11v02*
- **2TG**-xx: *2TG10v080*
- **ASI**-xx: *ASI10v08*
- **DAD**-xx: *DAD08v07, DAD26v01*
- **DIO**-xx: *DIO48v06*
- **ERS**-xx: *ERS11v098*
- **GDR**-xx: *GDR26v07*
- **GPI**-xx: *GPI16v10*
- **HAF-**xx: *HAF90v030*
- **HDR**-xx: *HDR07v04, HDR09v04*
- **HDS**-xx: *HDS05v26*
- **HEB**-xx: *HEB05v07*
- **SAV**-xx: *SAV08v07*
- **SDR**-xx: *SDR07v2*, *SDR08v10* and *SDR09v06*
- **SLI**-xx: *SLI10v29*

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device (by default: *161*).
- **Get community string:** The community string needed to read from the device. The default value is *public.*
- **Set community string:** The community string needed to set to the device. The default value is *private.*

## Usage

The Axon ERS1X protocol delivers two types of DataMiner Elements: a main element representing the main controller and one virtual element for each attached card (slot) of the frame.

### Main Element

The connector's main element contains the following pages:

- **ERS1X**: The ERS1X page provides an overview of the Axon main rack controller. Aside from this, you can also specify a view in which the created virtual element for the main rack controller will be added.
- **Cards**: For every supported card type of the Axon frame, a page button is provided on the Cards page. When you open a page for a card type, an overview is given of all slots for this selected type of card. In addition, you can also specify a view in which all created virtual elements for this type of card will be added.

### Virtual Elements

For every attached card in a slot of the Axon frame, a Dynamic Virtual Element is automatically created with a specific name (**Main Element Name** followed by the **Slot Number** in question, for instance *AxonS02*). Each of the DVEs contains the following main pages:

- **General**: The General page of the created DVE contains general information (*Slot Number*, *Card Name*, etc.) regarding the card type, of which some (for instance: *User Label*) is modifiable.
- **Alarm Priority**: The Alarm Priority page contains the specific priority settings of the Axon card in question.

Every supported card type of the Axon frame has its own specific features and capabilities. All of the card-related settings and statuses are provided on extra pages which depend on the type of Axon card. The following pages are included in the Axon ERS1X protocol:

#### General Statuses and Settings

It is possible that the Axon card type contains some general statuses and settings that are not related to any of the card's specific functionality. For this reason, the **Status** and **Settings** pages were added to the Axon ERS1X protocol.

#### Card Specific Statuses

Some of the supported Axon card types have some statuses that have to do with the card's capability and usability. Therefore, these statuses are provided on card-related pages: **Add On**, **Delay Status**, **Input**, **MIB**, **Module** and **Output**.

#### Card Specific Settings

The Axon ERS1X protocol also provides some extra pages regarding specific settings for the related card types: **AES**, **Amplifier**, **Audio**, **Channel**, **Delay**, **Embedder**, **GPO**, **Inserter**, **Logo**, **Network**, **Text Ident** and **Video**.

## Monitoring

The Axon ERS1X protocol provides a very useful DataMiner feature: every supported Axon card type can be provided with alarming and trending possibilities, which are specific for the type of card.
