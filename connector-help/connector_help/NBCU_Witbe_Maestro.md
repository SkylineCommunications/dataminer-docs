---
uid: Connector_help_NBCU_Witbe_Maestro
---

# NBCU Witbe Maestro

The Witbe Maestro protocol works with the Witbe Maestro API to send/retrieve tests requests and results.

## About

### Version Info

| **Range**            | **Key Features**                                                                                           | **Based on** | **System Impact**                                                                        |
|----------------------|------------------------------------------------------------------------------------------------------------|--------------|------------------------------------------------------------------------------------------|
| 1.0.0.x              | \- Sends assets for testing. - Proprietary to NBCU and requires the use of the NBCU VOD Manager.           | \-           | \-                                                                                       |
| 1.0.1.x \[SLC Main\] | Monitoring of tests on the device added.                                                                   | 1.0.0.x      | The Test table has changed and will not process previous data retrieved from the device. |
| 2.0.0.x              | (PENDING) Changes are being implemented to allow the Witbe driver to work with or without the VOD Manager. | \-           | \-                                                                                       |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a smart-serial connection to retrieve the Witbe results and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The DataMiner IP.
  - **IP port**: The IP port of the destination (default: *8000*).

#### HTTP Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the Witbe Robot.
- **IP port**: The IP port of the destination.
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To communicate with the Witbe Maestro Robot, specify the **Email** and **Password** on the General page and click **Login**. Once the driver has successfully logged in, it will retrieve the catalog list available in Witbe.

### Redundancy

There is no redundancy defined.

## How to use

The Witbe Maestro driver will receive notifications from the VOD Manager in the parameter with ID = 3. These notifications must contain the information of the assets that need to be tested.

The driver will send a single test for each available device, and once a result is received, it is sent to the VOD Manager.

In range 1.0.1.x, the driver will receive data to monitor the current test on the device. It will monitor the average test time per device and the time since the last test.
