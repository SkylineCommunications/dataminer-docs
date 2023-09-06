---
uid: Connector_help_Skyline_PTP
---

# Skyline PTP

The **Skyline PTP** driver is used as an **application** in the **DataMiner PTP Solution** to monitor the different PTP devices in a network.

A **Visio** file is provided along with this driver and provides full access to all functionality of the PTP Solution.

## About

### Version Info

| **Range**            | **Key Features**                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Overview of PTP devices.Monitoring of active grandmaster. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                      | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Standard DataMiner PTP Device (mediation protocol)PTP_SetupWizard (configuration Automation script)PTP_SetupWizard_Roles (configuration Automation script) | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

Note that this element should not be created manually, but should instead be created using the **PTP_SetupWizard** Automation script. For more information, refer to the Initialization section below.

### Initialization

The configuration of the Skyline PTP application and the full DataMiner PTP Solution must be done using the PTP_SetupWizard and PTP_SetupWizard_Roles Automation scripts.

The **PTP_SetupWizard** script must be executed initially to configure the DataMiner PTP Solution. This script will:

- Create the Top view for the PTP Solution items.
- Create the Skyline PTP element.
- Execute the initial configuration of the Skyline PTP element.
- Execute the PTP_SetupWizard_Roles Automation script.

The **PTP_SetupWizard_Roles** script is used to configure the PTP devices and update this in the Skyline PTP element. This script is executed from the PTP_SetupWizard script once the initial configuration is done. However, it can also be manually executed later to update the PTP devices managed by the Skyline PTP application.The PTP_SetupWizard_Roles script will:

- Configure the PTP devices in the Skyline PTP application with their respective roles.
- Update the PTP Role element property on each PTP device added to the PTP Solution.
- Create a PTP information template for each protocol that has at least 1 element added as PTP device in the Solution.

When both of these scripts have been executed, the PTP Solution should be fully configured and the Skyline PTP element will start monitoring the PTP topology.

### Redundancy

There is no redundancy defined.

## How to use

The data pages of the Skyline PTP element are not intended to be used. All the necessary data can be found on the Visual pages.

For more information on how to use these pages, refer to the DataMiner PTP section in the DataMiner Help.
