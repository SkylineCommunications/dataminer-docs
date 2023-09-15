---
uid: Connector_help_Axon_ACP_RRS18
---

# Axon ACP RRS18

The **Axon ACP RRS18** connector can be used to display and configure information of the Axon RRS18 central controller and the attached card types located in its different slots.

## About

This protocol can be used to monitor and control the Axon RRS main controller and the card types attached to the Axon frame. A **Serial** connection is used in order to successfully retrieve and configure the device's information. In addition, there are different **alarming** and **trending** possibilities for the supported Axon card types.

### Card Types & Firmware

The Axon RRS18 protocol can be used for different Axon cards. As there are sometimes small differences when it comes to indexes used by the Axon cards, the connector has been officially tested for the following firmware versions:

- **2IX**-xx: *2IX08v24* and *2IX11v02*
- **2TG**-xx: *2TG10v080*
- **ASI**-xx: *ASI10v08*
- **DAD**-xx: *DAD08v07, DAD26v01*
- **DIO**-xx: *DIO48v06*
- **RRS**-xx: *RRS18v36*
- **GDR**-xx: *GDR26v07*
- **GPI**-xx: *GPI16v10*
- **HAF-**xx: *HAF90v030*
- **HDR**-xx: *HDR07v04, HDR09v04*
- **HDS**-xx: *HDS05v26*
- **HEB**-xx: *HEB05v07*
- **HXH***-xx:* *HXH11v240*
- **SAV**-xx: *SAV08v07*
- **SDR**-xx: *SDR07v2*, *SDR08v10* and *SDR09v06*
- **SLI**-xx: *SLI10v29*

## Installation and configuration

### Creation

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **UDP** connection is selected automatically.

## Usage

The Axon ACP RRS18 protocol delivers two types of DataMiner Elements: a main element representing the main controller and one virtual element for each attached card (slot) of the frame.

### Main Element

The connector's main element contains the following pages:

- **RRS18**: The RRS18 page provides an overview of the Axon main rack controller. Aside from this, you can also specify a view in which the created virtual element for the main rack controller will be added.
- **Cards**: For every supported card type of the Axon frame, a page is available. When you open a page for a card type, an overview is given of all slots for this selected type of card.

### Virtual Elements

For every attached card in a slot of the Axon frame, a Dynamic Virtual Element is automatically created with a specific name (**Main Element Name** followed by the **Slot Number** in question, for instance *AxonS02*). Each of the DVEs contains the following main pages:

- **General**: The General page of the created DVE contains general information (*Slot Number*, *Card Name*, etc.) regarding the card type, of which some (for instance: *User Label*) is modifiable.
- **Alarm Priority**: The Alarm Priority page contains the specific priority settings of the Axon card in question.

Every supported card type of the Axon frame has its own specific features and capabilities. All of the card-related settings and statuses are provided on extra pages which depend on the type of Axon card. The following pages are included in the Axon protocol:

#### General Statuses and Settings

It is possible that the Axon card type contains some general statuses and settings that are not related to any of the card's specific functionality. For this reason, the **Status** and **Settings** pages were added to the Axon ERS1X protocol.

#### Card Specific Statuses

Some of the supported Axon card types have some statuses that have to do with the card's capability and usability. Therefore, these statuses are provided on card-related pages: **Add On**, **Delay Status**, **Input**, **MIB**, **Module** and **Output**.

#### Card Specific Settings

The Axon ERS1X protocol also provides some extra pages regarding specific settings for the related card types: **AES**, **Amplifier**, **Audio**, **Channel**, **Delay**, **Embedder**, **GPO**, **Inserter**, **Logo**, **Network**, **Text Ident** and **Video**.

## Monitoring

The Axon protocol provides a very useful DataMiner feature: every supported Axon card type can be provided with alarming and trending possibilities, which are specific for the type of card.
