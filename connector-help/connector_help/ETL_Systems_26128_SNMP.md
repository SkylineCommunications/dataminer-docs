---
uid: Connector_help_ETL_Systems_26128_SNMP
---

# ETL Systems 26128 SNMP

This SNMP connector for the ETL Systems 26128 chassis will create elements for all the supported (inserted) modules.

## About

The ETL Systems 26128 chassis has 18 card slots. Slot 1 and 18 contain the power supplies of the chassis. Information about these two modules is displayed by the main element. For the other modules that are supported and present in the chassis, monitoring is possible via separate elements.

This SNMP connector for the ETL Systems 26128 chassis will create elements for all the supported (inserted) modules. In version range **1.0.1.x**, this is done via automatic creation of DVEs. The DVEs use the **ETL Systems 26128 Module SNMP** connector. Please refer to the "Exported Connectors" table below for more information. In version range **1.0.0.x**, the creation of the elements representing modules must be triggered manually via the **Create Elements** button. The latest connector version in this range only creates elements for **AMP112** modules.

### Version Info

| **Range** | **Description**                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                          | No                  | Yes                     |
| 1.0.1.x          | Based on 1.0.0.1 Added creation of DVEs (different layout of main page). | No                  | Yes                     |
| 1.0.2.x          | Based on 1.0.1.9 Number of attenuators and amplifiers is now dynamic.    | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |
| 1.0.1.x          |                             |
| 1.0.2.x          | v4.0                        |

### Exported connectors

| **Exported Connector**                                                                      | **Description**                                                                                     |
|--------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|
| [ETL Systems 26128 Module SNMP](xref:Connector_help_ETL_Systems_26128_Module_SNMP) | From version 1.0.1.1 onwards, for each module inserted in the ETL Systems 26128, a DVE is exported. |

## Installation and configuration

### Creation

During creation of the element, the **IP Address/Host** for the SNMP connection must be provided. The default community strings are "public" and "private", respectively. These have to match the community string set on the device.

When using a connector from the 1.0.0.x range, please also upload the latest version of the protocol **AMP 112 SNMP** and set it as **Production**. Otherwise DataMiner will not be able to create the elements representing the modules.

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port on the device where the SNMP service is running, by default *161*.
- **Get community string**: The community string used for data reading, by default *public*.
- **Set community string**: The community string used to set values, by default *private*.

## Usage

### General

This page displays the status (**Internal Voltage** and **Temperature)** of the power supply modules of the chassis.

### Modules

This page lists all the module slots (from 1 to 18) and the name and type of the module in each slot. If no module is present, the module type will display "Empty". You can also alter the Module Name in this table.

The **Module Name** is used in the creation of the elements. In version range **1.0.0.x**, the name cannot be changed via the table once the elements have been created. In version range **1.0.1.x**, changing the Module Name in the table will cause the **Element Name** to be changed. Please take into account that the name must always be unique within the DataMiner System. If the proposed new name is not unique, the change will not be implemented.

### Web Interface

This page allows you to access the web interface of the device through DataMiner.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
