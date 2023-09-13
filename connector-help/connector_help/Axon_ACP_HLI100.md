---
uid: Connector_help_Axon_ACP_HLI100
---

# Axon ACP HLI100

The HLI100 is a dual logo inserter with a preset-based logo recall function through a flexible user interface and local storage. The HLI100 is capable of inserting two logos and can be used for channel branding with the option to alter the main channel logo on the fly, preset-based, and simultaneously add a "theme logo" that is triggered as a one-shot with predefined fade-in and fade-out times.

The **Axon ACP HLI100** driver can be used to display and configure information related to this device.

## About

### Version Info

| **Range** | **Key Features**                                                     | **Based on** | **System Impact**                                                                                                             |
|-----------|----------------------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.1   | Initial version                                                      | \-           | \-                                                                                                                            |
| 1.0.1.1   | Scheduling for logo presets added. Logo presets now shown in tables. | 1.0.0.1      | Single logo presets A and B are no longer shown as individual parameters. Trend and alarm information for these will be lost. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1508                   |
| 1.0.1.x   | 1508                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Creation

The element using this driver can be automatically created by the parent element using the **Axon ACP Frame Manager** driver, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection

- **IP address/host**: The polling IP or URL of the destination
  - **Bus address**: The bus address of the device is the slot number/position of the card in the frame.

#### Serial IP Connection - Broadcast Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: any
  - **Bus address**: The bus address of the device is the slot number/position of the card in the frame.

### Initialization

**Important**: For correct polling and editing of the logo presets, the parameter **Preset Edit View** on the **Logo Settings page** must be set to ***Independent***.

## How to use

The element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **Status**
- **Network Status**
- **Video Settings**
- **Logo Settings**
- **Logo Generator A (only 1.0.1.x)**
- **Logo Generator B (only 1.0.1.x)**
- **Logo Scheduler A (only 1.0.1.x)**
- **Logo Scheduler B (only 1.0.1.x)**
- **WHP296 Options**
- **GPIO Options**
- **Network**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

The setting of some parameters depends on another parameter's current value. For example, on the Network page, in order to set the Netmask, Network Mask Prefix, the Standard Gateway, etc., the IP Configuration has to be in Manual mode. To obtain more detailed information about certain dependencies between parameters, double-click the parameter to view the parameter details. In certain cases, a pop-up window will appear with a reminder about how to set a parameter to the appropriate value before you set other parameters.

From the **1.0.1.x** range onwards, the **Logo Generator A** and **Logo Generator B** pages list the logo presets in a table.

In the **1.0.0.x** range, changes have also been made to the **logo presets** on the Logo Settings page. These are shown as individual parameters, and only the settings of the one being edited are shown.
The H-Pos and V-Pos settings need to be applied before the preset logo is updated. You can do so with the Pos Update button. Because of limitations on the device, wait a few seconds before you make another change.

From version **1.0.1.x** onwards, the **Logo Scheduler A** and **Logo Scheduler B** pages allow you to schedule the logos to rotate on a round-robin based scheme.

## DataMiner Connectivity Framework

The **1.0.0.x** **and 1.0.1.x** range of the Axon ACP HLI100 protocol support the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Physical Interfaces

- **SDI Input**: A single fixed interface of type **input**.
- **SDI Output 1**: A single fixed interface of type **output**.
- **SDI Output 2**: A single fixed interface of type **output**.
- **SDI Clean Output**: A single fixed interface of type **output**.
- **SDI Output Preview**: A single fixed interface of type **output**.

### Connections

#### Internal Connections

- Between **SDI Input** and **SDI Output 1**
- Between **SDI Input** and **SDI Output 2**
- Between **SDI Input** and **SDI Clean Output**
- Between **SDI Input** and **SDI Output Preview**
