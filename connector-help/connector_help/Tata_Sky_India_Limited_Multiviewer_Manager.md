---
uid: Connector_help_Tata_Sky_India_Limited_Multiviewer_Manager
---

# Tata Sky India Limited Multiviewer Manager

This virtual connector is part of a solution present on TATA Sky India's system. Its main goal is to orchestrate the process of tuning different channels in different devices.

The multiviewer is responsible for the orchestration and displaying of the channels to the user.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                              | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation script: TSK-AS-Multiviewer (Solution available on GitHub) Service Provision Element - Tata Sky India Limited MCR DC Provision Connector | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Make sure the **TSK-AS-Multiviewer Automation script** (Solution available on GitHub) is imported in the system.

A **Visio file** is also available that allows you to check the VLC video streams.

## How to Use

On the **General** page, you can select the desired preset. This preset will affect the channel list that the connector will iterate on.

To start the iteration process, click the **Play** button. To pause the process, use the **Stop** button.

The iteration process consists of sending the desired channel and values to be set for each channel of the list, one by one, to the IRD device, the Mtx (matrix), or the STB.

The multiviewer sends the channel and respective information to the different Automation scripts that are responsible for the sets on the devices.
