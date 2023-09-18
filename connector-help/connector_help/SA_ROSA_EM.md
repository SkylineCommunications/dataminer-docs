---
uid: Connector_help_SA_ROSA_EM
---

# SA ROSA EM

This connector can be used to display and configure information related to the Rosa EM device and devices connected to it. The displayed information is organized in the same way as in the Rosa EM web application. In addition, this connector also allows the user to perform SNMP sets on the Rosa device and devices connected to it.

## About

The Rosa EM connector is used to monitor and control a Rosa EM device and devices connected to it. An **SNMP** connection is used in order to retrieve and configure the information of the device.

### Version Info

| **Range** | **Description**                                              | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                              | No                  | Yes                     |
| 2.0.0.x          | SNMP implementation for a number of devices. DVE generation. | No                  | Yes                     |
| 2.0.1.x          | Connector review                                                | No                  | Yes                     |
| 3.0.0.x          | Cellnex Version                                              | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.0.1.x          | V0401.90                    |
| 3.0.0.x          | Unknown                     |

### Device types

The Rosa EM connector can be used to monitor and control the following devices:

- [Switch (Switch)](xref:Connector_help_SA_ROSA_EM_-_Switch)
- [DCM (Digital Content Manager)](xref:Connector_help_SA_ROSA_EM_-_DCM)
- [D9054 (Encoder)](xref:Connector_help_SA_ROSA_EM_-_D9054)
- [D9034 (Encoder)](xref:Connector_help_SA_ROSA_EM_-_D9034)
- [D9036 (Encoder)](xref:Connector_help_SA_ROSA_EM_-_D9036)
- [Redus MK II (Switch)](xref:Connector_help_SA_ROSA_EM_-_Redus_MK_II)
- [Stream Table (Encoder)](xref:Connector_help_SA_ROSA_EM_-_Stream_Table)
- [Vikinx (Matrix)](xref:Connector_help_SA_ROSA_EM_-_Vikinx)
- [RF Gateway (RF Gateway)](xref:Connector_help_SA_ROSA_EM_-_RFGW)

For the Vikinx device, only basic information will be displayed.

For all the devices connected to the SA ROSA EM, except the Vikinx, DVEs will be created. The SA ROSA EM - Vikinx connector is a standalone connector that is not exported by the SA ROSA EM.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address**: The polling IP of the Rosa device, e.g. *10.55.48.31*.
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port connected to the device, by default *161*.
- **Get Community String**: The community string in order to read from the device. Default value is *public*.
- **Set Community String**: The community string in order to set to the device. Default value is *private*.

## Usage

The Rosa EM connector implements two types of elements: a main element that represents the Rosa EM device and one virtual element for each device connected to the Rosa EM. The name of each created virtual element has the following format: "*Main Element Name.Virtual Element Name*".

### Main Element

The main element contains the following pages:

- **Settings:** This page contains toggle buttons that can be used to enable the polling for a specific device connected to the Rosa EM. The value for the toggle buttons is by default *Disabled*.
- **Rosa EMIO Properties:** Main properties for the Rosa EM device.
- **Rosa EMIO Digital Inputs:** Table containing all the digital inputs related to the Rosa EM device.
- **Rosa EMIO Digital Outputs:** Table containing all the digital outputs related to the Rosa EM device.
- **Rosa EMIO Analog Inputs:** Table containing all the analog inputs related to the Rosa EM device.
- **Rosa EMIO Analog Outputs:** Table containing all the analog outputs related to the Rosa EM device.
- **Rosa EMIO Inputs Outputs:** Overview of the number of analog/digital inputs and analog/digital outputs related to the Rosa EM device.
- **Rosa EMIO Parameters:** This page displays two tables related to the Rosa EM: the internal temperature table and the 3.3 V On-Board Table.
- **Rosa EM General Parameters:** This page displays all the information related to the Rosa System. The main values related to the Rosa EM System are shown on the page itself, other values can be found on the following pop-up pages: System, Alarm Processing, License, Client Connections, SNMP, Notification Info, Notify Group, Member Info, Paging Service, Email Service, SMS Service, Operator, HFC Plant, Debug, Device Polling, Config Backup, Time Synchro, Apollo Config, Alarm Buffering, Persistence, IP Config, Second NIC, Routing and Services.
- **Vikinx devices:** This page displays a table containing the Vikinx devices connected to the Rosa EM. The device address (index) of the table has to be used to create another element for a specific Vikinx device.
- **RFGW Devices:** This page displays a table containing the RF Gateway devices connected to the Rosa EM. The page buttons in the column on the right open additional pop-up pages that contain tables with information from devices connected to the main element. This information is also displayed in each virtual element. The **RFGW Inactive** button can be used to remove devices from the table.
- **Main table from Devices:** This page displays a table for each type of device connected to the Rosa EM. This information can be used to obtain a general overview of all the devices connected to the main element. In case a device is no longer available, each table has a page button with which you can manually delete all data regarding that device. The device reference is the value of the instance column (the first one).
- **Additional tables:** Additional pop-up pages that contain tables with information from devices connected to the main element. This information is also displayed in each virtual element.
