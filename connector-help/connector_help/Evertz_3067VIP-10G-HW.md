---
uid: Connector_help_Evertz_3067VIP-10G-HW
---

# Evertz 3067VIP-10G-HW

This connector can be used to monitor and configure the Evertz 3067VIP-10G-HW. This is a virtualized media processing platform that allows users to move to an infrastructure where essential core broadcast services can be applied on a generic hardware platform when required.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

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

The connector polls most of the tables using subtable functionalities to reduce the amount of time it takes to poll tables and also to poll essential rows.

In range **1.0.0.x**, the following information should be noted related to the data pages:

- Every table has a **"User Field 1" column**, which can be used to **add a description for each row.**
- **Input Monitor**: This page includes the Input Stream Monitor, Video Input Monitor, Input Audio Monitor, and Input ANC Monitor tables. The **Input Stream Monitor Table** is where you can **set the custom description for all input tables**.
- **Audio Notify**: This page includes the Audio Monitoring Control 1 & 2 and Audio Channel/Group Notify tables. Each row in the **Audio Notify** table represents an input instead of an input fault, with the columns representing each of the instance types, and can be used for alarming. The **Audio Notify Trap Visibility** table is where **Audio Send** **Traps** can be triggered.
- **Video Notify**: This page includes the Video Monitoring and Video Notify tables. Each row in the **Video Notify** table represents an input instead of an input fault, with the columns representing each of the instance types, and **can be used for alarming**. The **Video Notify Trap Visibility** table is where **Video Send** **Traps** can be triggered to enable trap support.
- **Advanced** **Notify**: This page includes the Advanced Notify and Advanced Notify Trap Visibility tables. Each row in the Advanced Notify represents an input instead of an input fault. The **individual fault statuses** can be found in the **columns**. The Advanced Notify Trap Visibility table is where **Advanced Video Send** **Traps** can be triggered.
- **Traps**: This page includes the Traps Log table and trap control parameters. The Trap Descriptions Location **must have a path to the "traps.xml" defined** for **proper descriptions** to be given in the traps table and for **instant updates on each table**.
