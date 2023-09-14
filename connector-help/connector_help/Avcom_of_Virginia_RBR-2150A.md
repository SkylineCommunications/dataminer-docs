---
uid: Connector_help_Avcom_of_Virginia_RBR-2150A
---

# Avcom of Virginia RBR-2150A

The RBR Series is a Beacon Receiver based on the high-performing single-board Spectrum Analyzers and Beacon Receiver (SBS) products.

This protocol is used to monitor and configure a **Beacon Receiver**.

## About

The communication between the device and DataMiner Element is done via a **Serial** connection.

This protocol use an API to retrieve data from the device. The API is written in C and the protocol use a dll to have access those methods.

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | 1.10rc3                   |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

SERIAL CONNECTION:

- **Type of Port:** TCP/IP
- **IP address/host**: The polling IP of the device. e.g: 10.10.10.10
- **IP port**: The IP port of the device. e.g: 2880

### Initialization

To use this connector, add the DLL file "aovsbs2.dll" to the folder `C:\Skyline DataMiner\ProtocolScripts\`.

## Usage

The protocol has two pages, the **General** page where the user can see general information about the device and the **Beacon Receiver** page where the user can configure the **Beacon Receiver**.

### General

On General page, you can see general information like Firmware Version, Build DateTime also he can configure the Network Details. The Network Details has these parameters:

- Hostname
- IP Mode (Manual or DHCP)
- IP Address
- Subnet mask
- Default Gateway
- TCP Port

You can also reboot the device by clicking the *Reboot* button.

### Beacon Receiver

On this page, you can configure the **Beacon Receiver** also he can see the measurement values like:

- Measured Frequency
- Frequency Drift
- Frequency at Lock
- Current C/N0
- ...

You can also start and stop the **Beacon Receiver**.
