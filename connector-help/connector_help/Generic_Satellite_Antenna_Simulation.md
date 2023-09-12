---
uid: Connector_help_Generic_Satellite_Antenna_Simulation
---

# Generic Satellite Antenna Simulation

This driver simulates a satellite antenna. The antenna can be fixed or steerable (linked to an ACU element). If the simulated signal is locked, an internal DCF connection is created to simulate the antenna signal flow.

You can create DCF output signal interfaces by adding entries in the **Polarization Settings** table. You can simulate a signal flow by indicating whether the antenna is fixed or defining a linked ACU element.

Several ACU protocols are supported by means of the **ACU Protocol Parameters** table, where you can define the position parameter IDs.

## About

### Version Info

| **Range**            | **Key Features**                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version, with DCF support for outputs      | \-           | \-                |
| 1.0.1.x              | DCF integration and ACU subscription               | \-           | \-                |
| 1.0.2.x \[SLC Main\] | Polarization page added and Service Chains removed | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

## How to Use

### General

This page contains the following settings:

- **Satellite** information: **Name**, **Description**, **Dish Size** and minimum and maximum **Orbital Position Limit**.

- **ACU DMA Element ID**: Indicates whether this antenna is fixed or linked to an ACU element.

- **ACU Target**: This subpage contains the target position settings (Azimuth, Elevation and Polarization) the linked ACU element should have. For each position, a tolerance can be set.

- **Signal Status**: Contains the current simulated signal flow status:

- ***Unknown***: Unable to retrieve the current ACU position.
  - ***Unlocked***: The antenna is steerable, but the ACU is not positioned to the defined target.
  - ***Locked***: The antenna is fixed, or the antenna is steerable and the ACU is positioned to the defined target, or the antenna is steerable, but no target position was provided.

- **Polarization Settings**: Moved to Polarization page and divided into uplink and downlink in range 1.0.2.x.

- **Polarization**: Defines if the signal polarization is Horizontal, Vertical, Circular Left or Circular Right.
  - **Band Type**: Defines whether this is the main or the high or low frequency band.
  - **LO Frequency**: Local oscillator frequency.
  - **Minimum RF**
  - **Maximum RF**

### Connections

This page contains the following settings:

- **Input Connections** table: Lists the input connections.
- **Output Connections** table: Lists the output connections.

### ACU Protocol Parameters

This page contains a list of supported ACU protocols. The parameters of the first ACU protocol that matches the protocol name and version of the linked ACU element will be used. For each ACU protocol, the Name, Version (the "\*" wild card can be used multiple times, to select multiple versions) and the Azimuth, Elevation and Polarization Parameter ID can be set. By default the **Advantech AMT Intrac 405** protocol is supported.

### Service Chains

This page contains the **Uplink** and **Downlink** services of the present Antenna.

Each table contains information about the service such as the **Service ID** and the **State of the Service**. This information was added to the Downlink Polarization Settings and Uplink Polarization Settings tables in range 1.0.2.x.

### Polarization

This page shows the **Downlink Polarization Settings** and the **Uplink Polarization Settings** tables. Here you can define the signal polarization, band type, RF parameters and services for uplink and downlink.

### Antenna

This page shows the name of the antenna.

## DataMiner Connectivity Framework

The 1.0.2.x range of the Generic Satellite Antenna Simulation protocol supports the usage of DCF and can only be used on a DMA with **9.0 CU9** as the minimum version. DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- ***Input RF/Output RF***: These interfaces are created automatically to simulate the signal flow whenever a downlink/uplink polarization is created.
- ***Output/Input*** interfaces: Based on the downlink and uplink polarization tables, output or input interfaces are created, respectively.

### Connections

#### Internal Connections

- Internal connections are automatically created between RF interfaces and all polarization signals when the signal is locked, and removed when it is not.
