---
uid: Connector_help_DNF_Controls_USP-8D
---

# DNF Controls USP-8D

The **DNF Controls USP-8D** can be configured by and can configure the DNF Controls USP-8D **Control Console**.

## About

The DNF Controls USP-8D connector is polled by the DNF Controls USP-8D Control Console.
Since the latter device cannot be accessed by SNMP, the device polls the element instead of the other way around.
Sets can be performed from the connector, and will be updated, depending on the interval between gets on the Control Console.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V 2.2                       |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of ...

It is, however required to enable the **SNMP Agent** in **Advanced element settings** in the **edit** menu.

- Virtual IP Address - The IP address you will access with the device.
- Subnet Mask - The subnet mask for this IP

## Usage

### Controls

The controls page contains the **Operation Status** and **Config Status** parameters.

### Web Interface

The device's web page. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The **Config Status** parameter is dependent on the **Thomson Netprocessor 9030** protocol's **Current Config** parameter.
