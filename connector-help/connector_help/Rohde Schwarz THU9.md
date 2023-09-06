---
uid: Connector_help_Rohde_Schwarz_THU9
---

# Rohde & Schwarz THU9

The R&S THU9 is a high-power transmitter that makes terrestrial broadcasting of TV signals extremely efficient.

This connector allows you to monitor and control the THU9 device.

## About

### Version Info

| **Range** | **Description**                                          |
|-----------|----------------------------------------------------------|
| 1.0.0.x   | Initial version.                                         |
| 1.1.0.x   | Branch version based on 1.0.0.x.DVE functionality added. |
| 2.0.0.x   | Dual connector implementation using Generic IRT MIB.     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | tce900-103250          |
| 1.1.0.x   | tce900-103250          |
| 2.0.0.x   | tce900-112242          |

### Exported connectors

| **Exported Connector** | **Description**                                                                                                                                                       |
|------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Transmitter            | In range **1.1.0.x**, the controller can have multiple transmitters. DVEs for the transmitters will be exported according to the information the controller receives. |
| Exciter                | In range **2.0.0.x**, the transmitter has two exciters. Each exciter is exported as a DVE.                                                                            |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage: Range 1.0.0.x

### General page

This page displays general information regarding the device, especially **Transmitter** **A** and **B**, and **Cooling**.

There are also page buttons that lead to cooling information for the device's **Fans** and **Pumps** andto event **Notifications**.

### Transmitter A page

This page displays information concerning **transmitter** **A**.

There are different blocks of parameters related to different aspects of this transmitter:

- **Power**: Displays information concerning the power of the transmitter.
- **General**: Displays general information regarding the transmitter.
- **Exciter A**: Displays the information of exciter A of the transmitter. It also allows you to activate this exciter by pressing the **Activate** button. In addition, the preferred input for the exciter can be selected.
- **Exciter B**: Displays the same kind of information as the **Exciter A** section, but with regard to exciter B.

Underneath these blocks, a page button is available, **Amplifiers**, which opens a pop-up page with information on the status of the transmitter A amplifiers.

### Transmitter B page

This page displays the same kind of information as the **Transmitter** **A** page, but with regard to transmitter B.

### Status page

This page displays four blocks of parameters, two for each transmitter.

The **Transmitter** **A** and **B** blocks display information about the status of different aspects of the transmitter.

The **Transmitter** **A** and **B** **Inputs** blocks display information about the status of the inputs of each transmitter.

### Cooling page

This page displays cooling state information, as well as configurable items.

On the left side of the page are four blocks: three regarding cooling state information and one with configurable parameters. The parameters include **Inlet/Outlet Temperature State** information and **Coolant Pressure State** information. At the bottom, **Coolant Configuration** parameters are displayed.

On the right side of the page, there are two blocks of configurable parameters: one block contains **General Configuration** parameters and the other contains **Temperature Information**.

### Webpage

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage: Range 1.1.0.x

### General Page

This page contains general information about the controller.

In addition, the page allows you to set the **Transmitter Mode** to *Auto* or C*hangeover*, and to select the **Transmitter to Load** and the **Operation Mode**.

The page also displays a cooling summary with several subpages: **Notifications**, **Pumps**, and **Fans.**

### Cooling

This page contains detailed information about the cooling elements (**Inlet**, **Outlet**, **Coolant Pressure**, **Coolant Configuration**, **General** and **Temperature Configuration**).

In addition, the **temperatures** and **pressure** can be set here.

### Transmitter Tables

This page contains the tables used to display the information in the DVE table and thus to create the transmitters. However, as the page is not actually relevant to the user, because it is only used to fill in the DVE table, this page is not displayed in DataMiner.

### DVE Modules

This page contains the **DVE Table**. The DVEs representing the transmitters are created with the data in this table. Only the columns **Bus Address**, **Name** and **Element ID** are displayed.

## Usage: Range 2.0.0.x

### General

This page contains general information about the device.

The page also displays the **System Summary** and **State Summary** of the transmitter.

### Transmitter

This page contains detailed information about the transmitter: **Transmitter Configuration**, **Transmitter State**,and **Transmitter Notifications**.

The page includes several subpages:

- **Presets**: Allows you to load and save custom configurations in the device internal memory.
- **RF Sensors**: Displays the state of the RF sensors and allows you to configure RF sensors limits.
- **Amplifiers**: Displays the state of the amplifiers.
- **Output**: Displays the transmitter output state, including the **Modulation**, **Forward Power**, **Reflected Power**, and **Amplifier Efficiency**.

### Exciter A

This page displays information concerning **Exciter** **A**,including the **Exciter State** and the **Exciter Configuration** parameters.

This page includes several subpages:

- **Correction**: Allows you to set up and view the pre-correction parameters.
- **Linear**: Allows you to set up and view the linear pre-correction parameters.
- **Non Linear**: Allows you to set up and view the non-linear pre-correction parameters.
- **Regulation**: Allows you to set up and view the frequency regulation parameters.
- **SFN**: Allows you to set up and view the time synchronization parameters.
- **Input**: Allows you to set up and view the input selection parameters.

### Exciter B

This page displays the same kind of information as the **Exciter** **A** page, but with regard to **Exciter B**.

### Cooling

This page contains detailed information about all the cooling elements: **Inlet** **Temperature**, **Outlet Temperature**, **Coolant Pressure**, **Coolant Configuration**, **Fans**,and **Pumps**.

### DVE Modules

This page contains the **DVE Table**. The DVEs representing the transmitters are created with the data in this table.

### Polling Configuration

From version 2.0.0.4 onwards, a **Polling Configuration** table is available where you can define the polling intervals for the following groups of parameters:

- **General Time**
- **General**
- **Transmitter State**
- **Transmitter Configuration**
- **Transmitter/Output**
- **Transmitter/Amplifiers**
- **Transmitter/RF Sensors State**
- **Transmitter/RF Sensors Configuration**
- **Transmitter/Presets**
- **Exciter A State**
- **Exciter A Configuration**
- **Exciter A/Input Selection**
- **Exciter A/Input Configuration**
- **Exciter A/SFN State**
- **Exciter A/SFN Configuration**
- **Exciter A/Regulation**
- **Exciter A/Pre-Correction State**
- **Exciter A/Pre-Correction Configuration**
- **Exciter A/Linear Correction State**
- **Exciter A/Linear Correction Configuration**
- **Exciter A/Non Linear Correction State**
- **Exciter A/Non Linear Correction Configuration**
- **Exciter B State**
- **Exciter B Configuration**
- **Exciter B/Input Selection**
- **Exciter B/Input Configuration**
- **Exciter B/SFN State**
- **Exciter B/SFN Configuration**
- **Exciter B/Regulation**
- **Exciter B/Pre-Correction State**
- **Exciter B/Pre-Correction Configuration**
- **Exciter B/Linear Correction State**
- **Exciter B/Linear Correction Configuration**
- **Exciter B/Non Linear Correction State**
- **Exciter B/Non Linear Correction Configuration**
- **Coolant State**
- **Coolant Configuration**
- **Cooling/Pumps**
- **Cooling/Fans**
- **Cooling/Configuration**

By default, polling for these groups is enabled, and they have the same polling intervals as in previous versions of the connector: 1 second for very fast parameters, 5 seconds for fast parameters, 1 minute for medium parameters, and 5 minutes for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

### Web Interface

On this page, you can access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
