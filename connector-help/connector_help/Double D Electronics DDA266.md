---
uid: Connector_help_Double_D_Electronics_DDA266
---

# Double D Electronics DDA266

The **DDA266 Diversity Controller** manages the switchover between two separate uplink sites, according to received signal (beacon) levels.

The **Double D Electronics DDA266** connector is used to monitor and control DDA266 Diversity Controllers.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.1x                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus/unit address of the device.

## How to use

The **General** page displays device name and software version information.

On the **Switching Control** page, it is possible to change/configure the **Control** and **Operation** modes of the device. Note that setting the Operation mode to *Automatic* will not work in some cases (if both sites are transmitting, if there is a specific (configurable) pattern of switches, or if at least one polarization is not in maintenance mode). On this page, **before you try to** **switch to site 1** **or** **2**, make sure to select the **Polarization** and **Chains** that need to be switched.
