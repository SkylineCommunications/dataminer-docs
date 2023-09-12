---
uid: Connector_help_Sony_PWS-4500
---

# Sony PWS-4500

This is an SNMP connector that is used to monitor and configure the Sony PWS-4500 equipment.

The information on the parameters is retrieved via **SNMP** communication.

## About

### Version Info

| **Range**            | **Key Features**                             | **Based on** | **System Impact**                                                                                                                                                  |
|----------------------|----------------------------------------------|--------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                             | \-           | \-                                                                                                                                                                 |
| 1.0.1.x              | Support for monitoring of Sony 2110 devices. | 1.0.0.18     | Renamed NMI table to IP AV Interfaces table. Parameters related to NMI logic were renamed to a more generic name to provide support for other cards in the future. |
| 1.0.2.x \[SLC Main\] | Added DCF support                            | 1.0.1.13     | \-                                                                                                                                                                 |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.10                   |
| 1.0.1.x   | 1.10                   |
| 1.0.2.x   | 1.10                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

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

#### Serial FTP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION: (see "Initialization")

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, e.g. *port 21.*

### Initialization

For the serial connection to work, you need to fill in the parameters **FTP Username** and **FTP Password** on the **FTP Configuration** page of the element.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## How to use

### Range 1.0.0.x

The element created using this connector has the following data pages:

- **General**: This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.
- **Network**: This page displays the **Interfaces** table. This table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.
- **Storage Information**: This page displays the **System Frequency**, **Storage Capacity** (Total, Remaining, Remaining Percentage), and the **Port Information.**
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.
- **FTP Configuration**: On this page, you can configure the **FTP Username** and **FTP Password**. These credentials can be **verified** with a button.
- **Configuration File**: DataMiner can **request** and **store** **configuration files** from the PWS-4500. To request a file, specify a **Configuration File Title** and **Configuration File Name**. The configuration files will be uploaded to and stored in the DMA Documents folder under the connector name "Sony PWS-4500".
- **License Info**: This page contains the **License Info** table. This table contains **Code**, **Installation**, and **Activation** information.
- **Options Board Info**: This page contains the **Options Board** table. This table contains **Board**, **Type**, **ID**, **Suffix**, and **Status** information.
- **NMI**: On this page, the NMI table allows you to check which NMI element is connected to which IP converter board. You can also **add** or **delete** NMI interfaces here, as well as **resubscribe** to the NMI elements.

### Range 1.0.1.x

The data pages for this range of the connector are the same as detailed above, except for the **NMI** page, which has been renamed to the **IP IV Interfaces** page:

- **IP AV Interfaces**: On this page, the IP IV Interfaces table allows you to check which interface element is connected to which IP converter board. You can also **add** or **delete** IP AV interfaces here, as well as **resubscribe** to the IP AV Interface elements.
