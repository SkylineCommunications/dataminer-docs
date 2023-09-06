---
uid: Connector_help_ATX_Networks_MP3
---

# ATX Networks MP3

The MP3 chassis is a 3RU design that comes in both a passive and an active configuration. The passive and active chassis can accommodate up to 24 single-width passive modules (DC logic A/B RF switch; 2, 4, 8, dual 4-way and triple 2-way splitters\combiners; DC and triple DCs) or up to 12 dual-width modules (16-way splitters\combiners). The active chassis can accommodate the same modules as the passive chassis, with in addition up to 12 dual-width modules (amplifiers, power supply, optical receiver\transmitter, RF switch).

This connector was designed to monitor the different properties of the device, such as the voltage, current, power and temperature. **SNMPv1 GET** commands are used to read the information from the device.

## About

### Version Info

| **Range** | **Description**                                              | **DCF Integration** | **Cassandra Compliant** |
|-----------|--------------------------------------------------------------|---------------------|-------------------------|
| 2.0.0.x   | DVE creation                                                 | No                  | Yes                     |
| 2.0.1.x   | Fix not all inputs being shown in the RF Switch Input Table. | No                  | Yes                     |

### Device Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | 1.0.9                  |
| 2.0.1.x   | 1.0.9                  |

### Exported Connectors

| **Exported Connector**     | **Description**                                                |
|----------------------------|----------------------------------------------------------------|
| ATX Networks MP3 - MPAC    | A separate connector that represents the MPAC Power Supply.    |
| ATX Networks MP3 - QMP1000 | A separate connector that represents the QMP1000 RF Amplifier. |
| ATX Networks MP3 - MPRF AB | A separate connector that represents the MPRF AB RF Switch.    |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page contains system information parameters, such as the **Description**, **Up Time**, **Contact**, **Name**, **Location**, and **Services**.

### Settings

On this page, you can manage the creation of DVEs. For each of the different cards, a page button displays the corresponding DVE table. The cards are divided into the following categories:

- **Optical Receivers**: MPSARXL2, MPSRX, MPRXRR, MPRX2 and MPRX
- **RF Amplifiers**: MPSA and QMP
- **Power Supply**: MPAC
- **Optical Transmitters**: MPTX
- **RF Switch**: MPRF

The following parameters are used for DVE management:

- **Automatic DVE Deletion**: This parameter is *Disabled* by default. If it is *Enabled*, all rows in the **DVE Control Table** with the state **Delete** **Row** will be deleted automatically. This means that all templates linked to those cards will also be deleted.

- **DVE Actions**: Provides two options:

- *Enable All*: Creates all DVEs at once. Note that it could take some time to display all the DVEs.
  - *Disable All:* Deletes all DVEs and all corresponding templates.

- **Change View for all DVEs**: This drop-down list contains all the views on the DMA. If a new value is selected, all DVEs will be placed in the new view. If a change was performed on the DMA, such as the renaming or deleting of a view, you should click the **Refresh button** in order to synchronize the drop-down list with the changes on the DMA.

- **DVE Control Table**: This table contains all the cards present in the chassis. **Individual DVEs** can be created using the column **Element Creation**. Rows that have the state *Delete Row* can be removed manually. With the **Rename** column, you can rename each of the DVEs, though you must respect the following limitations when you do so:

- Spaces are not allowed in the new name.
  - Null values are not allowed as the new name.
  - The following characters must not be included in the new name value: **\\ / : ? " \> \< \| ; ø**

### Physical Entity

This page contains the **Physical Entity Table**. This table displays all the modules from every slot of the device and is used to create the **DVE Control Table**.

### Module

This page displays the **Model**, **Description**, **Name**, **Alias**, **Manufacturer**, **Asset ID**, **Serial** **Number**, **Hardware** **Revision**, and **Software** **Revision** of the **chassis**.

In addition, there are two page buttons:

- **Fans**: Displays the Fans Unit Table, which allows you to monitor the fan status.
- **Headend**: Displays the **Headend Information Table**, where you can monitor the **heatsink temperature**.

### Power Supply

This page contains two tables:

- **Power Supply Unit Table:** Includes the Input Current, Input Power, Description, and the Input Voltage.
- **Power Supply Output Table:** Displays the Output Voltage, Output Current, and Output Power.

### RF Amplifier

This page displays the **RF Amplifier Output Table,** which allows you to check the **Output Level** and **Attenuator Control**.

### RF Switch

This page contains 3 tables: the **RF Switch Unit Table**, **RF Switch Input Table**, and **RF Switch Output Table**.

### Optical Transmitter

This page contains 3 tables: the **Optical Transmitter Unit Table**, **Optical Transmitter Input Table**, and **Optical Transmitter Laser Table**.

### Optical Switch

This page contains 3 tables: the **Optical Switch Unit Table**, **Optical Switch Input Table**, and **Optical Switch Output Table**.

### Optical Receiver

This page contains the **Optical Receiver Input Table** and the **Optical Receiver Output Table**.
