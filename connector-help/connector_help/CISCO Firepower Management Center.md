---
uid: Connector_help_CISCO_Firepower_Management_Center
---

# CISCO Firepower Management Center

The Cisco FMC centralizes firewall administration and intrusion prevention. It provides an overview of firewall components, analytic tools to monitor traffic, reporting events, and abnormalities.

## About

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact** |
|----------------------|-----------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | HTTP initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.0.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: Default: *false*.

### Initialization

Log in on the **Settings** page with the **Username** and **Password** required to generate the access token, refresh token, and UUID of the Firewall Management Center device.

Once access is granted, the connector will start to poll data from the device. The access token is refreshed every 30 minutes.

### Redundancy

There is no redundancy defined.

## How to use

### General Page

This page displays general system information.

### Audit Record Page

This page displays the **Audit Record** Table.

### Deployment Page

This page displays the **Deployable Device** Table.

### Device Page

This page displays the **Device Record**, **Device Groups Record**, and **Device HA Pairs** Table.

### Integration Page

This page displays the **Cloud Events Config** and **External Lookup** Table.

### Application Page

This page displays the **Application Categories** and **Application Productivities** Table.

### Object Manager Page

This page displays the **Object Hosts** and **URL Categories Table**.

### Policy Page

This page displays the **Policy Assignment Table**.

### Settings Page

On this page, you can set the username and password of the device to get access and the domain UUID.
