---
uid: Connector_help_Evertz_500FC
---

# Evertz 500FC

The purpose of this protocol is to monitor the status of the **Evertz 500FC** device and to allow the user to configure it and its associated modules to receive traps containing alarm information.

## About

This is an **SNMP** connector. General system information and alarm status are retrieved via simple parameters and tables. **DVEs** are created for the following different types of modules: the **DA2Q** modules, **DA2Q-HD** modules, **DA-3G** modules, **DA2Q-3G** modules and **ACO2-HD** modules.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.222.*
- **Device address:** Not required.

SNMP Settings:

- **Port number:** The port of the connected device, e.g. *161.*
- **Get community string:** The community string used when reading values from the device, e.g. *public.*
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

## Usage

### General

On this page, general system parameters are displayed: **Device Description**, **FC Card Type**, **Lock Status**, **DVB Support**, **Software Build**.

The page also allows the user to make an upgrade on the slots via the **Module Upgrade**, **Product Name Upgrade** and the **Upgrade FC** button. The result of the upgrade is retrieved with the **Slots Upgrade Success** parameter.

The page also contains a number of page buttons:

- #### Traps Info: Displays the Traps Table, which allows the user to configure how each of the trap types is sent. In the same table, the Fault Present column shows any current faults for the associated trap type.

- #### Version Info: Displays the Version Table, which contains the Sw Revision/Build Numbers.

- #### Product: Displays the Product Location table, which indicates the type of module for each of the 16 available modules. Insertion/Removal Counters are also displayed.

### Monitor

This page displays several tables with information concerning the inserted modules.

- The **DA2Q Monitor Table** displays the **DA2Q M310 Status CH1/CH2, DA2Q Input Video Rate CH1/CH2** and the **DA2Q Mode Status**.
- The **DA2Q-HD Monitor Table** displays the **DA2Q-HD Bypass Select CH1/CH2, DA2Q-HD DVB Support CH1/CH2, **DA2Q-HD** Input Video Rate CH1/CH2** and the **DA2Q-HD** **Mode Status**.
- The **DA2Q-3G Monitor Table** displays the **DA2Q-3G Lock Status CH1/CH2, DA2Q-3G Input Video Rate CH1/CH2,** and the **DA2Q-3G** **Bypass Select**.
- The **DA-3G Monitor Table** displays the **DA-3G Lock Status, DA-3G Input Video Rate,** and the **DA-3G** **Bypass Select**.
- The **ACO2-HD Control Table** displays the **ACO2-HD Operating Mode, ACO2-HD DVB ASI Mode,** and the **ACO2-HD** **Output Select AC01/AC02**.

### Fault Management

#### On this page, a number of additional tables are displayed:

- The **DA2Q MGMT Fault Table** shows the trap information for the inserted DA2Q modules.
- The **DA2Q-HD** **MGMT Fault Table** shows the trap information for the DA2Q-HD modules**.**
- The **DA2Q-3G MGMT Fault Table** shows the trap information for the DA2Q-3G modules*.*
- The **DA-3G** **MGMT Fault Table** shows the trap information for the DA-3G modules**.**
- The **ACO2-HD** **MGMT Fault Table** shows the trap information for the ACO2-HD modules.
