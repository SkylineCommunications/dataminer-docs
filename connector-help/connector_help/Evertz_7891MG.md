---
uid: Connector_help_Evertz_7891MG
---

# Evertz 7891MG

The **Evertz** **7891MG** connector is used to monitor and control an Evertz chassis containing different Evertz 7700/7800 series cards.

## About

The chassis must include an **Evertz** **7800-FC** card in order to be functional. Data about the location of other cards is polled from this card. The **Evertz 7800-FC** is placed in slot 1; other cards are inserted into slots 2 to 15. A DVE will be created for each (supported) card. Data is polled via **SNMP**. Traps are supported to reduce the amount of polling. When a trap is received, the corresponding parameter is polled again to update its value.

### Version Info

| **Range** | **Description**                       | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                      | No                  | Yes                     |
| 2.0.0.x          | Connector connects directly to the card. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.5 Build 81                |
| 2.0.0.x          | Version 1.0 build 263       |

### Exported connectors

| **Exported Connector** | **Description**     |
|-----------------------|---------------------|
| Evertz 7891MG - Card  | Used for the 7891MG |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

This connector displays information about the Frame Controller (**Evertz 7800-FC**) and the inserted cards.

### General

This page displays general parameters for the **Evertz 7800-FC** controller, such as the **Temperature**, **Power Supply**, etc.

### Input Cards

This page lists all the modules embedded in the chassis and their corresponding slots. If cards have been changed, press the **Refresh Cards** button to see the changes immediately. If you activate the **Automatically Delete DVE Elements** toggle button, cards that get removed from the frame will not be moved to the **Input Cards table**.

### SNMP Trap Settings

On this page, you can add or remove trap destinations, and enable or disable specific kinds of traps. You can also enable or disable the **Log Traps** option, which logs traps in a local file in the folder Documents\Evertz 7891MG\\Element Name". The **Hosting DMA IP** parameter is used to check which Agent is hosting the element and compare this against the entries in the **Trap Destination Table**.

### SNMP Polling Settings

This page contains the **Polling Time table**, where you can configure the polling frequency of each group independently, and enable or disable polling for each group.

## Notes

In the 2.0.0.x range of the connector, no DVEs are created, as the connector now connects directly to the device instead of to the frame.

## Revision History

DATE VERSION AUTHOR COMMENTS

28/11/2018 1.0.0.1 RBL, Skyline Initial version
