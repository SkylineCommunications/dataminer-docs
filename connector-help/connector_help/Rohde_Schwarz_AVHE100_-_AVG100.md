---
uid: Connector_help_Rohde_Schwarz_AVHE100_-_AVG100
---

# Rohde Schwarz AVHE100 - AVG100

The R&S AVG100 audio/video gateway converts HD-SDI, SD-SDI, ASI and AES EBU input formats to IP format.

## About

This connector was designed to monitor and receive statistics from the **AVG100**.

The connector is generated automatically by the connector [Rohde Schwarz AVHE100](xref:Connector_help_Rohde_Schwarz_AVHE100).

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | DVE creation    | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

This connector is used by DVEs that are **automatically generated** when DVE creation is enabled for the corresponding card in the **Device AVS DVE** **Table** of the parent element.

## Usage

### General

This page contains parameters related to the AVG device system, such as the **Description**, **AVG Type**, **Extended Status**, etc.

### Port \[0..10\]

This page displays information related to the network adapters, such as the **External Name**, **Interface Name**, **Interface State**, **Link Speed**, etc.

### AVG Modules

This page displays the HW parameters, including the number of enabled modules and present modules, the communication status, and the **Is Alive** status.

There are also several page buttons that provide access to information on specific modules.

### AVG Module \[0..4\]

This page contains module-specific info, including **Enabled Type**, **Present Type**, **State** and **State Text**.
