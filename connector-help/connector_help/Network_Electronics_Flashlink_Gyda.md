---
uid: Connector_help_Network_Electronics_Flashlink_Gyda
---

# Network Electronics Flashlink Gyda

This connector can be used to monitor Network Electronics Flashlink Gyda controller devices via SNMP.

Based on the retrieved data and on the version of the connector, different connectors can be exported representing specific modules.

## About

### Version Info

| **Range** | **Description**                                                                                                                                                                                                      | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                                                      | No                  | Yes                     |
| 2.0.0.x          | 2 exported protocols: **Network Electronics Flashlink LB-OE** and **Network Electronics Flashlink LB-EO**.                                                                                                           | No                  | Yes                     |
| 3.0.0.x          | 1 exported protocol (**Network Electronics Flashlink Gyda Cards**) for several modules: *3G HD O/E L (2), HD-OE, DA 3G HD, HD-SDI-CHO 2x1, SDI CHO 2x1, LB-OE, ETH100, DA HD SDI, UPC HD XMUX, DA-SDI, FRS-HD*, etc. | No                  | Yes                     |

### Exported connectors

| **Exported Connector**                                                                                            | **Description**               |
|------------------------------------------------------------------------------------------------------------------|-------------------------------|
| [Network Electronics Flashlink LB-OE](xref:Connector_help_Network_Electronics_Flashlink_LB-OE)             | Only supported in range 2.0.0 |
| [Network Electronics Flashlink LB-EO](xref:Connector_help_Network_Electronics_Flashlink_LB-EO)             | Only supported in range 2.0.0 |
| [Network Electronics Flashlink Gyda Cards](xref:Connector_help_Network_Electronics_Flashlink_Gyda_Cards) | Only supported in range 3.0.0 |

## Configuration

### Connections

#### SNMP Main Connection

The **Network Electronics Flashlink Gyda** is an SNMP connector. The IP has to be configured during creation of the element.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## How to use

The element consists of the following data pages:

- **Module Overview**: Lists the currently attached modules, with information such as the module type, module alarm status, etc.
- **Cards**: Displays detailed information related to the OE and EO cards, including the card position, status, etc.
- **Tables**: Displays additional tables with detailed information about the different inputs/outputs available to each card.
