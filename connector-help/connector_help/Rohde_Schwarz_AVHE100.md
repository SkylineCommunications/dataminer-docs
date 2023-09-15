---
uid: Connector_help_Rohde_Schwarz_AVHE100
---

# Rohde Schwarz AVHE100

The fully integrated and highly compact R&S AVHE100 headend solution for encoding and multiplexing minimizes complexity for terrestrial and satellite DVB systems. It is an IP-based system solution featuring all-in-one integrated encoding and multiplexing and using R&S CrossFlowIP technology.

## About

This connector was designed to monitor the different properties of the R&S AVHE100 system.

### Version Info

| **Range** | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                   | No                  | Yes                     |
| 2.0.0.x          | Version from Bayerischer Rundfunk | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                 |
|------------------|-----------------------------------------------------------------------------|
| 1.0.0.x          | Dolbyr Digital / Dolbyr Digital Plus Encoder Version 3.10.2 - Build 2971695 |
| 2.0.0.x          | Dolby Version 1.1.5 - Build 2012-04-09                                      |

### Exported connectors

| **Exported Protocol - Range 1.0.0.x** | **Description**                                      |
|---------------------------------------|------------------------------------------------------|
| Rohde Schwarz AVHE100 - AVS100        | A separate connector that represents the AVS100 device. |
| Rohde Schwarz AVHE100 - AVG100        | A separate connector that represents the AVG100 device. |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

- SNMP CONNECTION:

  - **IP address/host**: The polling IP of the device.

  SNMP Settings:

  - **IP port**: The IP port of the device, by default *161*.
  - **Get community string**: The community string used when reading values from the device, by default *public*.
  - **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage - range 1.0.0.x

### General

This page contains system information parameters, divided in several sections:

- **System General**: Description, Last Update, Operation Mode.
- **Cross-Flow IP**: Active System, Manual Select Mode, etc.
- **Multisystem Redundancy**: Mode, State, Sum Connection State, etc.

### Objects

This page contains the **Object Table** as well as page buttons that provide access to the **Device AVG DVE** and **Device AVS DVE** tables.

### Active Configurations

This page contains the **Configurations Table**, which contains the activated configurations. There are also page buttons that provide access to the **Active Recoders** and **Active Mux** tables.

### NWA

This page contains the **NWA table**, which displays the active NWAs.

### Input

This page contains the **Input table**, which displays the active inputs.

### Output

This page contains the **Output table**, which displays the active outputs.

### NTP

This page contains the parameters related to the configured NTP, including client-side and server 1 and 2 parameters.

## Usage - range 2.0.0.x

### General

This page contains system and DMA information parameters, i.e. **System Name**, **Element ID**, **Element Name** and **IP Address**.

### Configurations

This page contains the **Configurations** **Table**.

### Parameters

This page contains the **Parameters** **Table**.

### System

This page contains additional system parameters, i.e. **System Overall Status**, **Software Version** and **System License and SLA Status**.

### Automation

This page contains the **Execution Automation Event** and the **Timestamp Automation Event** parameters.
