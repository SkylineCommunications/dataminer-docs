---
uid: Connector_help_Rohde_Schwarz_TMV9_DAB_Dual_Drive
---

# Rohde Schwarz TMV9 DAB Dual Drive

The R&S TMV9 transmitter is used for multiplexed Digital Audio Broadcasting in a Single Frequency Network (SFN). It consists of a source switch system, 2 exciters with 2 ETI inputs, a group of amplifiers, a transmitter controller unit (TCU), and an antenna system.

## About

This **SNMP** connector is used to monitor and configure the **Rohde Schwarz TMV9 Dual Drive** transmitter.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 22.0.1                      |

### Exported connectors

| **Exported Connector**         | **Description**                                                                                      |
|-------------------------------|------------------------------------------------------------------------------------------------------|
| TMV9 DAB Dual Drive - Exciter | In range **1.0.0.x**, the transmitter has two exciters. For each exciter, a DVE element is exported. |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general parameters related to the device, such as **system information and control**, **software updates**, **device and product info**, **Tx common control, functions and notifications**, **GPS**, **UPS**, **date and time** configuration and **options management**.

### DAB Input

This page contains the **DAB Input Notification** table, the **DAB Input Common** table, the **DAB Input ETI** table and the **DAB Input EDI** table.

### DAB Status

This page contains the **DAB Status Notification** table, the **DAB Active Configuration** table, the **DAB Active Localization** table, the **DAB Active Modulation** table, the **DAB Active TII** table, the **DAB Status SFN** table, and the **DAB Status SFN Input** table.

### DAB Setup

This page contains the **DAB Configuration** table, the **DAB Localization** table, the **DAB Modulation** table, the **DAB TII** table, the **DAB Setup SFN** table, and the **DAB Test** table

### DAB Dual Drive General

This page contains the general status parameters and the **Exciter Switch Auto Status** state parameter.

It also contains a page button that allows access to the **General Event Enable** and **General Event Priority** parameters.

### DAB Dual Drive Exciter A

This page contains the Exciter A status parameters and the **Exciter A Input A,** **Exciter A Input B** and **Exciter A** **Status** state parameters.

It also contains a page button that allows access to the **Exciter A Event Enable** and **Exciter A** **Event Priority** parameters.

### DAB Dual Drive Exciter B

This page contains the Exciter B status parameters and the **Exciter B Input A,** **Exciter B Input B** and **Exciter B** **Status** state parameters.

It also contains a page button that allows access to the **Exciter B Event Enable** and **Exciter B** **Event Priority** parameters.

### Cooling

This page includes all pressure- and temperature-related parameters. It allows you to monitor the **inlet and outlet temperature state**, the **coolant pressure and temperature state** and the **coolant temperature** **configuration**.

### Tx Transmitter

On this page, you can monitor the **transmitter state** and both monitor and configure the **transmitter notifications** and **commands**.

### Tx Exciter

This page is similar to the Tx Transmitter page, displaying the **Exciter Notification**, **Commands** and **State** tables.

### Tx Input Interfaces

This page contains a set of tables with information on all inputs, namely the **Input Interfaces** **Notification**, **IP**, **TS** **Feed**, **General** **Setup** and **Monitor** tables.

### Tx Input SAT

This page displays all SAT information and settings for every input, in the **Input SAT Feed** **Tuner**, **LNB**, **CAM**, **IP Output**, **General** and **Extras** tables.

### Tx Input Automatic

This page contains the **Automatic Notification** and **Automatic Configuration** tables, which allow full control over input automatic configuration.

### Tx Frequency Regulation

This page contains the **Notification** and **Setup** tables, allowing you to both monitor and configure the frequency regulation parameters. Additional information is also available in the **Frequency Regulation** **State** **Table**.

### Tx SFN

Similar to the Tx Frequency Regulation page, this page contains the **SFN Notification** and **Setup** tables, as well as the **SFN State** monitoring table.

### Tx Precorrection

This page contains a **Notification** table as well as **Linear** and **Non-Linear** **Setup** and **State** tables. It also includes the **Crest Factor Reduction** table for both monitoring and control.

### Tx Output Stage

On this page, you can monitor and configure the **Notification** and **Commands** tables, as well as monitor the **State** table.

### Tx Amplifier

On this page, you can configure the **amplifier status notifications** and monitor the **State** and **PMx** tables.

### Tx Presets

On this page, you can **load and save presets** for every transmitter.

### Tx RF Sensors

This page contains the **Tx RF Sensors Notification Table** as well as the general **Tx RF Sensors Table**. The latter allows you to monitor and configure a large set of sensor-related parameters.

### MTx

This page displays the **MTx** **Notification** **Table.** In addition, it contains all information about **NPlus1**, including the **NPlus1** **Configuration** and **Status** monitoring, which can be accessed via page buttons.

### DVE Modules

This page contains the **DVE Table**. The DVEs representing the exciters are created with the data in this table.

### Web Interface

This page provides access to the web interface of the Rohde Schwarz TMV9 DAB Dual Drive transmitter. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
