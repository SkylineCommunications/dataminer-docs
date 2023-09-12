---
uid: Connector_help_Harmonic_Spectrum_XE
---

# Harmonic Spectrum XE

The Harmonic Spectrum XE is a compressed playout system. It integrates a Channel-in-a-Box (CiaB) playout with transcoding and encoding. It is also built for scalability in manipulation and automation.

This driver allows you to manage the jobs and workflows associated with the channel streams.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

A user name and password are required for this driver to work. Specify these on the **General** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following pages:

- **General**: Allows you to configure the user name and password for the polling, and provides information regarding **Time Management** and **Mount Points**.
- **Workflows**: Displays information on each workflow in the system, which consists mainly of **versioning** and **permissions**.
- **Jobs**: Displays information regarding the currently available jobs. Note that this information may take some time to load.
- **Logs**: Contains the currently open logs in the system, including alarms.
