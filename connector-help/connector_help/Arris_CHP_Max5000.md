---
uid: Connector_help_Arris_CHP_Max5000
---

# Arris CHP Max5000

This connector is a **DVE manager** for the **Arris CHP Max5000**, which is a Converged Headend Platform and combines several cards into one management unit. These include hub, headend and digital transport cards. The connector not only gets information on the management units, but also on all the cards that are managed by them. Typical usage includes an SNMP-enabled controller (SMM), which can be linked to other non-SNMP controllers (CMM) inserted into a chassis (these can be single, or multiple daisy-chained), 2 redundant PSUs and fans per chassis, and a group of cards with transmission (DDF0), reception, or other control functions in mind.

## About

This is an SNMP-based connector, so data is retrieved and written on the device using **SNMP** polling.

This connector also exports several other connectors based on the information retrieved from the hardware. The list of exported connectors can be found in the "Exported Connectors" section of this page.

### Version Info

| **Range**            | **Key Features**                                                                       | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                        | \-           | \-                |
| 1.0.1.x              | Fixed duplicate parameter description (PID 1905 and 3502)                              | 1.0.0.9      | \-                |
| 1.0.2.x \[SLC Main\] | Changed MFVx Amplifier Table and DVE SFRX Optical Properties to standalone parameters. | 1.0.1.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.6.0                |
| 1.0.1.x   | 1.0.6.0                |
| 1.0.2.x   | 1.0.1.3                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

### Exported Connectors

| **Exported Connector**                                                                                      | **Description**                                   |
|------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| [Arris CHP Max5000 - CHP-SMM-2](xref:Connector_help_Arris_CHP_Max5000_-_CHP-SMM-2)                 | SNMP-enabled controller card                      |
| [Arris CHP Max5000 - CHP-CMM-1](xref:Connector_help_Arris_CHP_Max5000_-_CHP-CMM-1)                 | Basic controller card, no SNMP                    |
| [Arris CHP Max5000 - CHP-PS-AC1-SW](xref:Connector_help_Arris_CHP_Max5000_-_CHP-PS-AC1-SW)         | Power supply                                      |
| [Arris CHP Max5000 - CHP-DDFO](xref:Connector_help_Arris_CHP_Max5000_-_CHP-DDFO)                   | Transmission card                                 |
| [Arris CHP Max5000 - CHP-2RRXF-30-S](xref:Connector_help_Arris_CHP_Max5000_-_CHP-2RRXF-30-S)       | Redundant/non-redundant dual return path receiver |
| [Arris CHP Max5000 - CHP-4RRXF-30-L](xref:Connector_help_Arris_CHP_Max5000_-_CHP-4RRXF-30-L)       | Redundant/non-redundant quad return path receiver |
| [Arris CHP Max5000 - CHP-FANS](xref:Connector_help_Arris_CHP_Max5000_-_CHP-FANS)                   | Fans information per chassis                      |
| [Arris CHP Max5000 - CHP-D2RRX-85-XQ-S](xref:Connector_help_Arris_CHP_Max5000_-_CHP-D2RRX-85-XQ-S) | Optical receiver                                  |
| [Arris CHP Max5000 - CHP-OPTSWITCH-2-L](xref:Connector_help_Arris_CHP_Max5000_-_CHP-OPTSWITCH-2-L) | Optical switch                                    |
| [Arris CHP Max5000 - CHP-EDFA](xref:Connector_help_Arris_CHP_Max5000_-_CHP-EDFA)                   | Optical amplifier                                 |
| [Arris CHP Max5000 - CHP-CW4](xref:Connector_help_Arris_CHP_Max5000_-_CHP-CW4)                     | Optical transmitter                               |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: by default *161*
- **Get community string**: *public*
- **Set community string**: *private*

## Usage

### General Information

This is the default page of the connector. It is used for 2 main purposes: displaying generic data for the hardware, and controlling the DVE creation process.

The **DVE creation** process involves simply clicking the button for a particular card to create the corresponding element. However, this button will not be available if the card state is **Deleted**. You can also create all the viable DVEs with the **Create All DVEs** button. Any card that does not have a DVE protocol or is in the **Deleted** state will not have an element created. It is also possible to set a view for all the DVEs in the control table, with the **Change DVE view for All** parameter.

You can **remove** **a DVE** **element** in two ways (note that all trending data associated with the element will be lost when it is deleted):

- Manual deletion by means of the **Create Element** toggle button in the **DVE Control Table**.
- In case the card is removed physically, the element can only be deleted in the relevant DVE control table, which is available via the page buttons under the **DVE Control Table**.

### DVE pages

Each type of DVE card can be managed on a specific subpage, available via the page buttons located under the **DVE Control Table**. Deletion of a DVE element is also possible via these tables (unless the auto removal option is on at the time of removal). The following requirements apply:

- If a card is removed from the shelf, the physical table will detect the card as non-existent and will set that slot's state to **Deleted**. Once it is in that state, DVE creation will be impossible for that slot, and the element will be placed in a **Removed** internal state. The **Delete button** will then become available for the corresponding table and element, so that it can then be completely removed from the system.
  However, note that deleting a DVE causes the loss of all trending data associated with it, so make sure the data is no longer required before you delete the DVE.
- If a card is replaced by another one of a different type and the system detects this, the previous card type element will be set to the **Removed** internal state. The same rules then apply as for a removed card.

If a card is replaced by another of the same type, the element will not be removed, and no data will be lost. Also, if a card is removed for a period of time and then re-inserted, and the card type does not change and the element was not removed, then no trending data will be lost, as the element always remained in the system.

### Physical Entities

This page only contains the physical entity table. This is the base table for the Arris CHP Max5000, and not only contains the physical IDs for all managed cards, but also all hardware-related information.

Some columns in the table can be edited, such as **Alias**, **Serial Numbers**, etc.

### Shelves

This page contains information on the managed chassis. This information is not exported to the child elements and is only available here (since the chassis cannot currently be exported). The page contains both the general status and the configuration of the chassis.

### Slots

This page contains all the status and configuration tables for each slot. You can reset the modules on this page, access the factory reset option for each card, and configure test points. It is also possible to handle the time configuration for the cards, check their running temperatures and do software resets from the Common Table.

Note that the **Software Reset**, **Reset Module**, **Slot Reset** and **Factory Default** buttons will cause the system to reboot, and information will be unavailable during this action.

### SMM

This page contains information related to the SMM card, such as the **status**, **configuration files** and **firmware information**.

### CMM

This page contains information regarding all the CMM cards connected to this manager, such as the **backplane voltages**, **alarms** and **triggers**.

### Power Supplies

This page contains power supply information, specifically the **alarm status** for all the power supplies in the system. You can also check the output information, specifically the **Voltage**, **Current** and **Power** output of the system's power supplies.

### Transmission

This page contains transmission-related information, specifically for the transmitters from version 1.0.0.1 onwards. **Input**, **output** and **laser status** are shown here.

In addition, the **Distortion** and **Radio Frequency configuration** can be set here for all the cards.

In version 1.0.0.3 of this connector, this page has been revised so that both the radio frequency and optical transmission parameters are available. The page contains tables for both types, and page buttons for the specific configuration of each of the types.
