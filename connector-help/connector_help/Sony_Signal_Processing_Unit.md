---
uid: Connector_help_Sony_Signal_Processing_Unit
---

# Sony Signal Processing Unit

The **Sony NXL-FR16** and **Sony NXL-FR318** are processing units (chassis), to which the following cards can be attached:

- IP converter boards: Sony NXL-IP40F/41F/42F/45F/50Y

## About

### Version Info

| **Range**            | **Key Features**                                       | **Based on** | **System Impact**                                                                                                                                                                                               |
|----------------------|--------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                       | \-           | \-                                                                                                                                                                                                              |
| 1.0.1.x              | Support for monitoring of Sony 2110 Device Interfaces. | 1.0.0.14     | NMI logic made generic to support other types of interfaces. NMI table renamed to ipAvInterfaces. Columns of Device table referring to NMI now have more generic naming/description. Export rules were adapted. |
| 1.0.2.x \[SLC Main\] | Added DCF support.                                     | 1.0.1.9      | \-                                                                                                                                                                                                              |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V2.61                  |
| 1.0.1.x   | V2.61                  |
| 1.0.2.x   | V2.61                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                      |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Sony Signal Processing Unit - NXLK-IP41F Sony Signal Processing Unit - NXLK-IP42F Sony Signal Processing Unit - NXLK-IP40F Sony Signal Processing Unit - NXLK-IP50Y Sony Signal Processing Unit - NXLK-IP45F |
| 1.0.1.x   | No                  | Yes                     | \-                    | Sony Signal Processing Unit - NXLK-IP41F Sony Signal Processing Unit - NXLK-IP42F Sony Signal Processing Unit - NXLK-IP40F Sony Signal Processing Unit - NXLK-IP50Y Sony Signal Processing Unit - NXLK-IP45F |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | Sony Signal Processing Unit - NXLK-IP41F Sony Signal Processing Unit - NXLK-IP42F Sony Signal Processing Unit - NXLK-IP40F Sony Signal Processing Unit - NXLK-IP50Y Sony Signal Processing Unit - NXLK-IP45F |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Range 1.0.0.x

The element created with this connector has the following data pages:

- **General**: This page contains general information, such as the **System Description**, **System Up Time**, **System Contact**, **Name**, and **Location**. It also displays an overview of the **OSI Model** of the availability of each layer and the **Electricity Consumption**, **PSU Fan A Total Up Time**, **PSU Fan B Total Up Time**, **Chassis Fan A Total Up Time**, and **Chassis Fan B Total Up Time**.
- **Network**: This page displays the **Interfaces** and **Address Translation** tables. The operational status of the interfaces can also be updated based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables. The **Product Information Table** is used to extrapolate data to create the DVEs.
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.
- **DVE**: This page displays the **DVE** tables and the setting to automatically delete DVEs.
- **NMI**: On this page, the **NMI** table allows you to check which interface element is connected to which card. The **Resubscribe** button can be used to reset all the created subscriptions.
  In this range, the only supported IP IV interface is the **Sony NMI** device.

### Range 1.0.1.x

The element created with this connector has the following data pages:

- **General**: This page contains general information, such as the **System Description**, **System Up Time**, **System Contact**, **Name**, and **Location**. It also displays an overview of the **OSI Model** of the availability of each layer and the **Electricity Consumption**, **PSU Fan A Total Up Time**, **PSU Fan B Total Up Time**, **Chassis Fan A Total Up Time**, and **Chassis Fan B Total Up Time**.
- **Network**: This page displays the **Interfaces** and **Address Translation** tables. The operational status of the interfaces can also be updated based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables. The **Product Information Table** is used to extrapolate data to create the DVEs.
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.
- **DVE**: This page displays the **DVE** tables and the setting to automatically delete DVEs.
- **IP IV Interface**: On this page, the **IP IV Interfaces** table allows you to check which interface element is connected to which card. The **Resubscribe** button can be used to reset all the created subscriptions.
  In this range, the supported IP IV interfaces are the **Sony NMI** device and **Sony 2110** device.

## Notes

**IMPORTANT NOTE:
**The index of the Product Information Table and the Device table has a difference of -1 with the DVE element names. DVEs have an element name of the format **MainElementName-Module_Slot No**, with "Slot No" being **PK Product Information Table** **- 1**.

**Example:**
Main Element: Sony NXL-FR316

Product Information table:
Key Module DVE Element Name
2 NXLK-IP40F Sony NXL-FR316-NXLK-IP40F_1
