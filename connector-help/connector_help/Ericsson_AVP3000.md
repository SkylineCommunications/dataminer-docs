---
uid: Connector_help_Ericsson_AVP3000
---

# Ericsson AVP-3000

The **Ericsson AVP-3000** connector is a **HTTP** connector that is used for monitoring **Advanced Video Processor** configuration.

## About

With this **HTTP** **Advanced Video Processor** connector you can **control** the configuration if nothing goes wrong, **change** the configuration where possible and even **restore** the configuration if needed.

Ranges of the connector

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.1.x \[SLC Main\] | Initial version | Yes                 | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |

## Installation and configuration

The **Ericsson AVP-3000** connector has a **HTTP** Connection:

- **Port:** 80
- **Bus Address:** ByPassProxy (if it need to pass a proxy server)
- **IP Address:** The IP of the Device

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- (default: ByPassProxy)

### Configuration

On the General Page, there is a Page Button **Credentials..**.
On the Credentials page, enter the User Name and Password that are used for the HTTP Communication.

## Usage

### General

On this page you have an overview of the **Device Information** and all possible **Slots**.

### Stored Configurations

Here you see the **Last Loaded Configuration**, this is possible to **change** when you want to **restore** a configuration with one of the **possibilities** from the table.

### ASI Output 1 & 2

### Satellite Modulator - Output

Here you have a nice overview from all **Satellite Modulator Output** parameters. The **left Output** group shows you the basic output parameters, if you change the **Output Select** you will see that the **right** **Output** group, **L-Band Output** group and the **IF Output** group parameters change.

The right **Output** group shows all general parameters of **L-Band Output** group and **IF Output** group.

The parameters that are "**NA**" (Not Available) are **disabled** because they aren't requested.

### Satellite Modulator - Modulation

Here you have a nice overview from all **Satellite Modulator Modulation** parameters with the possibility to make changes to them.

### Satellite Modulator - Input

Here you have a nice overview from all Satellite Modulator Input parameters with the possibility to make changes to them.

### Transport Stream

Here you have a nice overview from all **Transport Stream** parameters with the possibility to make changes to them.

### Service

### Video Component - Input

This page shows us everything about the **Video Component Input**, here we can see and change the settings we want.

### Video Component - Output

This page shows us everything about the **Video Component Output**, here we can see and change the settings we want.

### Video Component - Encode

This page shows us everything about the **Video Component Encode**, here we can see and change the settings we want.

### Video Component - VBI

This page shows us everything about the **Video Component VBI**, here we can see and change the settings we want.

### Audio Component - Input

This page shows us everything about the **Audio Component Input**, here we can see and change the settings we want.

### Audio Component - Encode

This page shows us everything about the **Audio Component Encode**, here we can see and change the settings we want.

### Alarms

A page for the overview of all **Active Alarms** at the bottom you see page buttons which open a page with an overview of the **Alarms** of that **specific slot**. Standard the connector doesn't poll for these alarms so the bandwidth that the connector use will increase a lot.

### Slot Configuration

Here we made it possible that you can choose on which slot you would like to poll for the **Video Component (standard 3)** and the **Satellite Modulator (standard 6)**.

## Notes

When you change the **Last Loaded Configuration** it take some few seconds when the change happens, this is because the connector waits until the **restore** of the configuration is done and after that he refresh all the parameters.
