---
uid: Connector_help_Rohde_Schwarz_THU9_DVE
---

# Rohde & Schwarz THU9 DVE

The Rohde & Schwarz THU9 connector consists of two parts, the controller and the transmitters. The controller contains the DVE Table, which can be used to create the transmitters.

## About

The information displayed in this connector is divided over seven pages:

- **For the controller:**

  - **GeneralMain**: Contains general information about the loaded transmitters, and the available modes to put these in. Also displays a summary of the cooling, with three subpages:

    - Notifications
    - Pumps
    - Fans

  - **Cooling**: Contains detailed information about all the cooling elements (Inlet, Outlet, Coolant Pressure, Coolant Configuration, General and Temperature Configuration).

  - **Transmitter Tables**: Contains all tables used to display the information in the DVE Table and therefore to create the transmitters. (This page will not be displayed, because it is not relevant, as it is only used to fill in the DVE Table.)

  - **DVE Module**: Contains the DVE Table, which is used to create the corresponding transmitters (only the columns BusAddress, Name and element ID are displayed).

- **For the transmitters:**

  - **General***:* Contains general information about the most important parameters and different modes.

  - **Transmitter Information**: Contains detailed information about the transmitter and the available exciters. When only one exciter is available, only the left exciter (ExA) will be filled in. When both exciters are available, both exciters will be filled in (ExA and ExB).

    - Amplifiers: Subpage displaying the state of the amplifiers

  - **Status**: Displays the state of the available parameters. When only one exciter is available, some parameters (ExB parameters) will not be filled in.

### Version Info

| **Range** | **Description**                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                         | No                  | No                      |
| 1.1.0.1          | Branch version based on 1.0.0.x.DVE functionality added. | No                  | No                      |

### Product Info

| **Connector Version** | **Device Firmware Version** |
|--------------------|-----------------------------|
| 1.0.0.1            | tce900-103250               |
| 1.1.0.1            | tce900-103250               |

### Exported connectors

| **Exported Connector** | **Description**                                                                                                                                  |
|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| Transmitter           | The controller can have multiple transmitters. The necessary transmitters will be exported according to the information the controller receives. |

## Configuration and Installation

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage Controller

### GeneralMain

This page contains general information about the controller. Here you can set the **Transmitter Mode** to *Auto* or *Changeover*. You can also select the **transmitter to load** and the **Operation mode.**

The page also displays a cooling summary with some subpages: **Notifications**, **Pumps** and **Fans**.

### Cooling

This page contains detailed information about all the cooling elements (Inlet, Outlet, Coolant Pressure, Coolant Configuration, General and Temperature Configuration).

You can also set **temperatures** and **pressure** here.

### Transmitter Tables

This page contains all tables used to display the information in the DVE Table and therefore to create the transmitters. This page will not be displayed in DataMiner, because it is not relevant to the user, as the page is only used to fill in the DVE Table.

### DVE Modules

This page contains the DVE Table, which is used to create the corresponding transmitters (only the columns **BusAddress**, **Name** and **element ID** are displayed).

## Usage Transmitter

### General

This page contains general information about the transmitter.

Here you can set the **Amplifier Mode** and **Operation Mode**, and set the transmitter's **Forward Power Threshold**.

### Transmitter Information

This page contains detailed information about the transmitter and the available exciters. When only one exciter is available, only the **left exciter (ExA)** will be filled in. When both exciters are available, **both exciters** will be filled in (**ExA** and **ExB**).

On this page, the **Transmitter Power**, **Active Input** and **Preferred input** can be set.

The page has one subpage, **Amplifiers**, which displays the state of the amplifiers.

### Status

This page displays the state of the available parameters. When only one exciter is available, some parameters (ExB parameters) will not be filled in.
