---
uid: Connector_help_Rohde_Schwarz_AVHE100_-_AVS100
---

# Rohde Schwarz AVHE100 - AVS100

The R&S AVS100 audio/video server is a platform running software applications for signal processing and control.

## About

This connector was designed to monitor and receive statistics from the **AVS100**.

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

This page contains parameters related to the AVS device system, such as the **Description**, **AVS Type**, **Current SW Version**, etc.

It also displays the **Maintenance State**, **Status Info** and **Software Update** parameters.

### Port \[0..11\]

This page displays information related to the network adapters, such as the **External Name**, **Interface Name**, **Interface State**, **Link Speed**, etc.

### AVS Modules

This page displays the HW parameters. There are also several page buttons that provide access to information on specific modules.

### AVS Module \[0..5\]

This page contains module-specific info, such as **Enabled Type**, **Present Type**, **Generic Status**, **Fan Status**, etc.

### AVS Cross-Flow

This page contains the parameters related to cross-flow, including **Cross-Flow Mode**, **Parameter Error**, **Proc State**, etc.
