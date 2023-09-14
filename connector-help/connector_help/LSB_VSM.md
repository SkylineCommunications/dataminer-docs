---
uid: Connector_help_LSB_VSM
---

# LSB VSM

The LSB VSM connector can be used to control and monitor the LSB (Lawo) Virtual Studio Manager.

The connector uses the **Pro-bel SW-P-08** protocol to request and update information from the VSM. The VSM supports many different matrix layers. This connector is capable of handling 4 of them.

LSB VSM uses a **smart-serial** connection, which means that it will register itself to receive updates from VSM as soon as there is a change in the system.

## About

### Version Info

| **Range**     | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version (customer-specific)                 | No                  | Yes                     |
| 2.0.0.x              | \- Based on 1.0.0.x - Generic version               | No                  | Yes                     |
| 2.0.1.x \[SLC Main\] | \- Based on 2.0.0.x - Added DCF support for layer 1 | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**     |
|------------------|---------------------------------|
| 1.0.0.x          | 16.1.2 Pro-bel SW-P-08 Issue 31 |
| 2.0.0.x          | 16.1.2 Pro-bel SW-P-08 Issue 31 |
| 2.0.1.x          | 16.1.2 Pro-bel SW-P-08 Issue 31 |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The main IP of the VSM.
  - **IP port**: The TCP port used to connect to VSM.

#### Serial Redundant connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The redundant IP of the VSM.
  - **IP port**: The TCP port used to connect to VSM.

### Configuration of matrix layers

This connector supports 4 matrix layers in total. When you want to poll a matrix layer from VSM, the number of this layer first needs to be configured.

Once this has been configured, the matrix layer will be polled from VSM, and VSM will also send updates when there is any change to this layer.

### Configuration of matrix

The **matrix UI** can be enabled or disabled in this connector. This is especially useful in case of a very big matrix where the table layout is preferred over the matrix UI itself. Currently, the matrix UI supports a maximum of 1024 inputs and 1200 outputs.

The **Matrix State** is a general parameter, which means that it will affect all 4 matrices. If it is disabled, the matrix UI pages will not be displayed.

## Usage

### General

The General page contains the parameters used to configure the different **matrix layers** and the **matrix UI**.

This page will also display the number of **inputs** and **outputs** per matrix.

### Layer 1 Details / Layer 2 Details / Layer 3 Details / Layer 4 Details

These pages contain the **inputs** and **outputs** tables, which display the matrix connections.

### Layer 1 Matrix / Layer 2 Matrix / Layer 3 Matrix / Layer 4 Matrix

These **matrix** pages show the **matrix UI** for each layer.

Note that these are only available when the **Matrix State** is *Enabled*.

## DataMiner Connectivity Framework

The 2.0.1.x connector range of the LSB VSM protocol supports the usage of DCF.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

- Layer 1 input interfaces of type **in** are defined in the **Layer 1 Inputs Table**, corresponding to layer 1 matrix inputs.
- Layer 1 output interfaces of type **out** are defined in the **Layer 1 Outputs Table**, corresponding to layer 1 matrix outputs.

### Connections

Internal connections are created between all active **Matrix Layer 1** crosspoints.
