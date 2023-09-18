---
uid: Connector_help_Williams_Sound_LoopGuardian
---

# Williams Sound LoopGuardian

The **Williams Sound LoopGuardian** is a HTTP connector developed to monitor and control Loop Amplifier through NET server.

## About

This connector is intended to communicate with the device using HTTP as described in the device's documentation and API.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 0.10.3                      |

## Installation and configuration

### Creation

This connector uses a HTTP connection and requires the following input during element creation:

**HTTP CONNECTION**:

- **Type of Port:** TCP/IP
- **IP address/host**: e.g. *10.218.128.12*
- **IP port**: default: *8080*
- **Bus address***: Enabled,* default*: ByPassProxy*

## Usage

### General Device Information

In this page, general information about the devices is present. In the **Devices** table, user can find key details regarding the available devices. Some of those details include learning the device's **Communication Status**, **DVE/ID** and physical **Location** of the devices.

Use the **Device Config** page button to enable **Device Automatic Removal** parameter which enables the user to remove device's whose **Communication Status** (present in **Devices** table) is ***'**Not Responding**'***. Otherwise, the user can choose to Remove all the devices from the **Devices** table at once regardless of their **Communication Status**, by simply clicking on the **Remove All** button.

### Global Controls

This page consists of **User Presets** table and **Loop Information** table. In the **User Presets** table, the user will be able to make various changes to **User Preset IDs** such as changing the **Preset Name**, enable/disable it's display on user interface and saving the configuration.

### Input Channel Controls

On this page, the user will be able to monitor and control **General Input, Equalizer Input** and **Compressor Input** Channel Controls.

### Output Channel Controls

Similar to the **Input Channel Controls** page, the user will be able to monitor and control **General Output, Equalizer Output** and **AGC Output** Channel Controls.

### Connection Information

This page consists of the **System / Configuration Controls** table which helps the user to monitor and configure respective DVE element related settings.

### Security

In this page, the user can enter login credentials in the **Username** and **Password** parameters.
