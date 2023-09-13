---
uid: Connector_help_Ovarro_Kingfisher
---

# Ovarro Kingfisher

The Ovarro Kingfisher is a remote telemetry unit used to connect digital inputs, digital outputs, and analog inputs, such as relays, temperature sensors, etc.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**    | **Exported Components**                                                                                                                                                                                                                                                                                         |
|-----------|---------------------|-------------------------|--------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | Ovarro Kingfisher Sensor | \- [Ovarro Kingfisher - Analog Input](/Driver%20Help/Ovarro%20Kingfisher%20-%20Analog%20Input.aspx) - [Ovarro Kingfisher - Digital Output](/Driver%20Help/Ovarro%20Kingfisher%20-%20Digital%20Output.aspx) - [Ovarro Kingfisher - Digital Input](xref:Connector_help_Ovarro_Kingfisher_-_Digital_Input) |

## Configuration

### Connections

#### Serial Connection - IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  -**IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (default: 473).
  - **Bus address:** The RTU ID used for messaging the device.

## How To use

The Ovarro Kingfisher supports a limited number of commands. For that reason, the information that can be retrieved is the current value of the 192 registers that are part of a Kingfisher. These are displayed on the **Raw Registers** page.

Extra functionality is present to support the adding of cards of different types (analog, digital input, and digital output) to be better able to monitor the device and send commands to it.

You can use the connector either as a standalone connector with DVEs, or with the Ovarro Kingfisher Sensor, which adds an extra layer of information.

Below, you can find information about the main pages of the connector.

### General

The General page contains the RTU ID, which is a copy of the bus address value. It gets updated every time the bus address is changed.

There is also a toggle button that determines whether DVEs are used or not. This toggle button is disabled by default, as the preferred way of using this connector is with the Ovarro Kingfisher Sensor connector.

### Status

The Status page contains information about the device, such as the existence of card alarms and the status of fans. This information is parsed from the raw register values.

### Cards

The Cards page shows the cards monitored by this element. These cards can be added either via a context menu or via the provisioning mechanism on the **Card Provisioning** page.

This page also allows you to clear all card data or manually delete a specific card.

The cards can be represented either as DVEs or as an Ovarro Kingfisher Sensor element, depending on the mode selected on startup. The pages **Digital Input Cards**, **Digital Output Cards**, and **Analog Input Cards** contain further details about the values of each card, based on their raw register values.

When you add a card via the context menu, keep in mind that a digital card supports a single register that will be split into 16 I/O, and each analog card supports 8 registers that should be specified separated by semicolons (";") and that cannot be repeated.

### Card Provisioning

The Card Provisioning page shows a JSON example that you can use to provision cards without the need to manually add them. This can be helpful in large deployments as this provisioning can also be triggered via InterApp messaging.

The **Configuration** subpage contains the necessary information to be able to read from a JSON file.

The **Provisioning Sensors** subpage is where the provisioning can be triggered. A list of the provisioned Ovarro Kingfisher Sensor elements will also be shown here, depending on the selected mode. In order for this provisioning to work, a connector version of the Ovarro Kingfisher Sensor connector must be set to production.

### Raw Registers

The Raw Registers page contains a table with the values of the current and previous raw register values.

### Debug

The Debug page contains multiple commands that can be sent to an Ovarro Kingfisher element outside of the regular timed ones. It also has a subpage where you can set bits on specific registers, a functionality that is also available when using digital output cards.
