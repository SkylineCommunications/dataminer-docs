---
uid: Connector_help_Harris_VEA6800+
---

# Harris VEA6800+

The **Harris VEA6800+** connector has an **SNMP** connection towards the 6800+ frame to monitor a device slot in the frame. Alarm monitoring and trending can be activated on all important parameters.

## About

With this connector, you can monitor the Harris amplifier card. This connector supports monitoring of both ETH cards and ICE cards depending on the element configuration.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during the creation of the element:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, by default *161.*
- **Bus address**: This is a combination of the frame number, slot number and card type (ETH or ICE): "*\<frameNumber\>.\<slotID\>.\<cardType\>*" (e.g. frame 1, slot 12, ETH Card = bus address *1.12.ETH).*

## Usage

### General

On this page, three read-only parameters are available:

- **Device Name** displays the card name of the selected card from the bus address.
- **Module Status** indicates if the card is *Online* or *Offline*.
- **General Alarm Level** indicates the general alarm level of the card.

For **Module Status** and **General Alarm Level**, alarm monitoring and trending is enabled, which can be activated in the DataMiner alarm and trend templates.
