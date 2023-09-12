---
uid: Connector_help_British_Telecom_ABR_Application
---

# British Telecom ABR Application

The **British Telecom ABR Application** driver is used to test BT's online TV service.

## About

This driver uses TCP/IP communication and the Selenium framework for web applications to test the online service.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### TCP/IP connection

This driver uses a TCP/IP connection and requires the following input during element creation.

TCP/IP CONNECTION:

- **IP address/host**: The IP of the remote server, e.g. *10.11.12.13*.
- **IP port**: *4444*.

The driver also uses the **WebDriver.dll** and **WebDriverSupport.dll** files from the Selenium software.

## Usage

### Channels

This page displays a **Settings** page button that allows the user to enter the necessary credentials to log in to BT's webpage and the remote server, and also to specify the file location from which to load the **Channel Listing**.

The **Selenium IE Driver** parameter displays if the selenium process is running on the remote server.

The **Channels Table** displays each channel's information along with a button that will trigger the test on the remote server.
