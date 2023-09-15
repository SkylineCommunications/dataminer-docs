---
uid: Connector_help_Temix_L-Band_Line_Amplifier
---

# Temix L-Band Line Amplifier

This protocol allows you to monitor and manage a Temix L-Band Amplifier (AMP-L9I-V-25-A). This is a fixed gain amplifier that includes a variable attenuator. It has standard L-band input (950 MHz to 1950 MHz), which is amplified with a 25 dB gain, while it is possible to select any attenuation value in the range 0-30 dBm, in steps of 0.5 dB. The final amplification ranges from -5d B up to 25 dB.

This protocol communicates with the Temix LBA using SNMP. SNMP traps can be retrieved if this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | REV 1.00               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device.
- **Set community string**: The community string used when setting values on the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays general information about the device, such as the product name and uptime. It also allows you to view and edit the Device **Contact** information, **Name** and **Location**.

You can also view and configure the **L-Band Attenuation** value. The default attenuation value is 0 dB, meaning that the final gain is 25 dB. You can increment the attenuation up to 30 dB, which means a final gain of -5 dB, in 0.5 dB steps. After you have changed the attenuation setting, the new value will be stored and recalled as the default value at each system startup.

Finally, you can also check the **Summary Alarm** state of the device here.

### Attenuation Presets

This page contains a list of attenuation presets. Each preset can have a **Description** and **Attenuation** value. You can change the current attenuation value to the value of the preset using the **Set** button. You can delete a preset with the **Delete** button.

### Trap receivers

This page contains a list of SNMP trap receivers. You can check and configure the **State**, **IP address** and **Trap Community** per trap.
