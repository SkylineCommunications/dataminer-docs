---
uid: Connector_help_MCL_MXCVPC
---

# MCL MXCVPC

This a serial connector that can be used to monitor and configure the MCL MXCVPC.

## About

### Version Info

| **Range** | **Key Features**                              | **Based on** | **System Impact**                                                             |
|-----------|-----------------------------------------------|--------------|-------------------------------------------------------------------------------|
| 1.0.0.x   | Initial version. CSP command set.             | \-           | \-                                                                            |
| 2.0.0.x   | New communication protocol. SABus command set | 1.0.0.5      | This range cannot be used on a device that only supports the CSP command set. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following information during element configuration:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.

## How to use

This is a serial connector that provides information about available **High Power Amplifiers (HPA)**, **Variable Phase Combiners (VPC)** and **Waveguide Switches** devices. Information about the different kinds of devices is displayed on different, corresponding pages: **HPA**, **VPC** and **WGSW**.

When a negative acknowledge (NAK) response is received in the communication, the connector displays the reason for the NAK response and the date and time when the NAK response is received. You can find this information on the General page, along with report-related parameters.
