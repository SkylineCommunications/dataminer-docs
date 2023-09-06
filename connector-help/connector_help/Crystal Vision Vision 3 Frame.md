---
uid: Connector_help_Crystal_Vision_Vision_3_Frame
---

# Crystal Vision Vision 3 Frame

This **SNMP** driver allows you to monitor a Crystal Vision Vision 3 Frame. Vision 3 is the rack frame for the Vision product range.
3U high and holding up to 20 cards, Vision 3 is suitable for higher bandwidth signals such as IP and 4K as well as SDI video and audio.

This driver also automatically creates Tandem 10 VF card DVEs if they are available in the **Frame Layout Table**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.12.18224             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                          |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Crystal Vision Vision 3 Frame - Tandem 10 VF](xref:Connector_help_Crystal_Vision_Vision_3_Frame_-_Tandem_10_VF) |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Default:161.

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

The element created with this driver consists of the following data pages:

- **General:** Displays system information such as the **System Description**, as well as the **Frame Layout Table**, which shows an overview of the frame cards available and whether a DVE is supported for them.

- **Frame Monitor:** Displays a table with status information about the frame, such as **CPU Fan Fault**, **Power Supply Faults**, etc.

- **Up Down A VF:** Displays status information about the Up Down A VF Card.

- **3GDA VF:** Displays status information about the 3GDA VF Card.

- **Tandem 10 VF:**

- On the left side of this page, you can find the tables that are exported to the **Tandem 10 VF** **DVEs**. This includes the **DeEmbedded Input Table** and **Discrete Inputs Table**, which allow you to enable or disable parameters such as **Invert**, **Dolby** or **ReSample** for each audio group or discrete input, and the **Delays Table** for de-embedded inputs and discrete inputs, where you can enable parameters such as **Frame Delay** and **User Delay.**
  - On the right, you can find all other configuration tables. The columns of these tables are exported as **standalone parameters** of the **Tandem 10 VF** **DVEs**.

- **DVE:** Allows you to enable or disable the **DVE Automatic Removal** feature. Also contains a table with the supported DVE cards.
