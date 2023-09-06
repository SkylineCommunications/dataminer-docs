---
uid: Connector_help_Motorola_GX2-CM100_B
---

# Motorola GX2-CM100 B

The Motorola GX2-CM100 B control module supervises all of the application modules and power supplies with the GX2-HSG chassis, while also serving as the communication gateway between the modules and the various user interfaces. It reports any alarms to the network management system.

This SNMP-based connector is used to monitor and configure the Motorola GX2-CM100 B. Different connectors will be exported for the supported cards. A list can be found in the section "Exported Connectors" below.

## About

### Version Info

| **Range** | **Key Features**                                                                                                                                                                                                                                                                                                                                          | **Based on** | **System Impact**                                                                              |
|-----------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|------------------------------------------------------------------------------------------------|
| 2.0.0.14  | Power levels added to the following cards: -GX2-OSW10B-R- GX2-OA508B21- GX2-LM1000B13- GX2-DRR-4X- GX2-DRR-4X-PIN- GX2-DRR-2X65- GX2-EM1000C7/16- GX2-DM1000B10/CH25-R- GX2-DM1000B10/CH27-R- GX2-DM1000B10/CH55-R                                                                                                                                        | \-           | \-                                                                                             |
| 2.0.0.15  | Added cards: - GX2-GS1000B9/10/CH21- GX2-GS1000B9/10/CH22- GX2-GS1000B9/10/CH27- GX2-GS1000B9/10/CH31- GX2-GS1000B9/10/CH50- GX2-DRR3X42- GX2-RX1000Includes all the parameters from all the cards. The connector has been made more readable and custom tables have been created for some of the cards.                                                  | 2.0.0.14     | \-                                                                                             |
| 2.0.0.17  | Added option to select which DVEs are exported.                                                                                                                                                                                                                                                                                                           | 2.0.0.15     | \-                                                                                             |
| 2.0.1.1   | Added cards:- GX2-GS1000B9/10/CH41- GX2-DM2000B10/CH21-RExported connector nomenclature changed to be in compliance with the current guidelines: "\[Name of main DVE connector\] - \[Name of device\]".Added feature to prevent DVEs from being automatically deleted and added option to select which DVEs are exported.                                 | \-           | Elements need to be recreated to use this version. Older connector versions should be deleted. |
| 2.0.2.x   | Fixed GX2Rx200 DVEs. For the fix, some exported parameter descriptions had to be modified (the Rx1 prefix was added). GX2Rx200 is a dual return path receiver, so it had both Rx1 and Rx2. Only Rx1 was included in the DVE. In order to add Rx2, for the sake of consistency, Rx1 was added as a prefix in the description of the existing descriptions. | \-           | Description changes for GX2Rx200 DVEs only.                                                    |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | P                      |
| 2.0.1.x   | P                      |

### Version Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**               |
|-----------|---------------------|-------------------------|-----------------------|---------------------------------------|
| 2.0.0.14  | No                  | No                      | \-                    | See "Exported Connectors" list below. |
| 2.0.0.15  | No                  | Yes                     | \-                    | See "Exported Connectors" list below. |
| 2.0.0.17  | No                  | Yes                     | \-                    | See "Exported Connectors" list below. |
| 2.0.1.1   | No                  | Yes                     | \-                    | See "Exported Connectors" list below. |
| 2.0.2.x   | No                  | Yes                     | \-                    | See "Exported Connectors" list below. |

### Exported connectors

| **Exported connectors**                                                                                                | **Description**                                                                 |
|------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------|
| GX2-LM1000-B                                                                                                           | *Before range 2.0.1.x*1310 nm Forward Path Broadcast Transmitter                |
| GX2-CM100B-R                                                                                                           | *Before range 2.0.1.x*Controller Module                                         |
| GX2-DRR-4X                                                                                                             | *Before range 2.0.1.x*Digital Return Path Receiver                              |
| GX2-DRR-2X85                                                                                                           | *Before range 2.0.1.x*Digital Return Path Receiver                              |
| GX2-GS1000B                                                                                                            | *Before range 2.0.1.x*1550 nm Forward Path Full Spectrum DWDM Transmitter       |
| GX2-PSAC10D-R                                                                                                          | *Before range 2.0.1.x*AC Power Supply                                           |
| GX2-OA100B18-R                                                                                                         | *Before range 2.0.1.x*Erbium Doped Fiber Amplifiers                             |
| GX2-OSW10B-R                                                                                                           | *Before range 2.0.1.x*Optical Switch                                            |
| GX2-DRR-3X                                                                                                             | *Before range 2.0.1.x*Digital Return Path Receiver                              |
| GX2-RX200BX4                                                                                                           | *Before range 2.0.1.x*Quad Return Path Receiver                                 |
| GX2-RX200BX2                                                                                                           | *Before range 2.0.1.x*Dual Return Path Receiver                                 |
| GX2-EA1000B6-12-CH21                                                                                                   | *Before range 2.0.1.x*1550 nm Forward Path Full Spectrum DWDM Transmitter       |
| GX2-LM1000-E                                                                                                           | *Before range 2.0.1.x*1310 nm Forward Path Broadcast Transmitter                |
| GX2-EM1000C                                                                                                            | *Before range 2.0.1.x*1550 nm Forward Path Broadcast Transmitter                |
| GX2-DM2000                                                                                                             | *Before range 2.0.1.x*1550 nm Forward Path Full Spectrum DWDM Transmitter       |
| GX2-DM1000B10                                                                                                          | *Before range 2.0.1.x*1310 nm Forward Path Full Spectrum DWDM Transmitter       |
| GX2-RX1000                                                                                                             | *Before range 2.0.1.x*Digital Return Path Receiver                              |
| [Motorola GX2-CM100 B - GX2-LM1000-B](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-LM1000-B)                 | *From range 2.0.1.x onwards*1310 nm Forward Path Broadcast Transmitter          |
| [Motorola GX2-CM100 B - GX2-CM100B-R](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-CM100B-R)                 | *From range 2.0.1.x onwards*Controller Module                                   |
| [Motorola GX2-CM100 B - GX2-DRR-4X](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-DRR-4X)                     | *From range 2.0.1.x onwards*Digital Return Path Receiver                        |
| [Motorola GX2-CM100 B - GX2-DRR-2X85](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-DRR-2X85)                 | *From range 2.0.1.x onwards*Digital Return Path Receiver                        |
| [Motorola GX2-CM100 B - GX2-GS1000B](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-GS1000B)                   | *From range 2.0.1.x onwards*1550 nm Forward Path Full Spectrum DWDM Transmitter |
| [Motorola GX2-CM100 B - GX2-PSAC10D-R](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-PSAC10D-R)               | *From range 2.0.1.x onwards*AC Power Supply                                     |
| [Motorola GX2-CM100 B - GX2-OA100B18-R](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-OA100B18-R)             | *From range 2.0.1.x onwards*Erbium Doped Fiber Amplifiers                       |
| [Motorola GX2-CM100 B - GX2-OSW10B-R](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-OSW10B-R)                 | *From range 2.0.1.x onwards*Optical Switch                                      |
| [Motorola GX2-CM100 B - GX2-DRR-3X](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-DRR-3X)                     | *From range 2.0.1.x onwards*Digital Return Path Receiver                        |
| [Motorola GX2-CM100 B - GX2-RX200BX4](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-RX200BX4)                 | *From range 2.0.1.x onwards*Quad Return Path Receiver                           |
| [Motorola GX2-CM100 B - GX2-RX200BX2](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-RX200BX2)                 | *From range 2.0.1.x onwards*Dual Return Path Receiver                           |
| [Motorola GX2-CM100 B - GX2-EA1000B6-12-CH21](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-EA1000B6-12-CH21) | *From range 2.0.1.x onwards*1550 nm Forward Path Full Spectrum DWDM Transmitter |
| [Motorola GX2-CM100 B - GX2-LM1000-E](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-LM1000-E)                 | *From range 2.0.1.x onwards*1310 nm Forward Path Broadcast Transmitter          |
| [Motorola GX2-CM100 B - GX2-EM1000C](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-EM1000C)                   | *From range 2.0.1.x onwards*1550 nm Forward Path Broadcast Transmitter          |
| [Motorola GX2-CM100 B - GX2-DM2000](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-DM2000)                     | *From range 2.0.1.x onwards*1550 nm Forward Path Full Spectrum DWDM Transmitter |
| [Motorola GX2-CM100 B - GX2-DM1000B10](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-DM1000B10)               | *From range 2.0.1.x onwards*1310 nm Forward Path Full Spectrum DWDM Transmitter |
| [Motorola GX2-CM100 B - GX2-RX1000](xref:Connector_help_Motorola_GX2-CM100_B_-_GX2-RX1000)                     | *From range 2.0.1.x onwards*Digital Return Path Receiver                        |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information regarding the **Modules**.

### DVE Modules Tables

This page contains the following **DVE Modules Tables**:

- **GX2-OSW100B-R**
- **GX2-OA100B18-R**
- **GX2-CM100B-R**
- **GX2-PSAC10D-R**

### DVE Transmitters Modules Tables

This page contains the following **DVE Modules Tables**:

- **GX2-RX1000**
- **GX2-DM2000**
- **GX2-EM1000C**
- **GX2-LM1000-E**
- **GX2-LM1000-B**
- **GX2-GS1000B**
- **GX2-EA1000B6-12-CH21**

### DVE Receivers Modules Tables

This page contains the following **DVE Modules Tables**:

- **GX2-DM1000B10**
- **GX2-RX200BX2**
- **GX2-RX200BX4**
- **GX2-DRR-3X**
- **GX2-DRR-2X85**
- **GX2-DRR-4X**
