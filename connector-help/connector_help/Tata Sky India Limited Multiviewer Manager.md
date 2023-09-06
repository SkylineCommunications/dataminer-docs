---
uid: Connector_help_Tata_Sky_India_Limited_Multiviewer_Manager
---

# Tata Sky India Limited Multiviewer Manager

This virtual connector is part of a solution present on TATA Sky India's system. The main goal is to orchestrate the process of tuning different channels in different devices.The Multiviewer is responsible for the orchestration and displaying of the channels to the user.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.X \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                             | **Exported Components** |
|-----------|---------------------|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation Scripts:TSK-AS-Multiviewer (Solution available on GitHub)Service Provision Element - Tata Sky India Limited MCR DC Provision Connector | \-                      |

## Configuration

### Connections

Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Automation Scripts

TSK-AS-Multiviewer (Solution available on GitHub) needs to be import to the system.

### Visio Files

It is available a Visio File to be able to check the VLC video streams.

## How to Use

On the General Page, the user is able to select the preset that desires. This preset will affect the Channel List that the connector will iterate on.To start the iteration process, the user as to click on the button Play. To pause the process, it has also available the Stop button.The iteration process consists of sending each channel of the list, one by one, to the IRD device, the Mtx (matrix) or to the STB the desired channel and values to be set.

The multiviewer sends the channel and respective information to the different automation scripts that are responsible for the sets on the devices.
