---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-DDFO
---

# Arris CHP Max5000 - CHP-DDFO

The CHP-DDF0 card is a group of transmitter cards, which have a system naming of the format CHP-DDFO-####-10-S. These cards are responsible for data transmission, and as such most of their configuration options relate to that. Alarm status is also available for this card.

## About

This is an **SNMP** connector, which uses SNMP polling to communicate with the physical devices.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.6.0                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000), from version 1.0.0.1 onwards.

## Usage

### General

This page contains card-specific hardware information and configuration options. **Names**, **Serial Number**, **Revisions** and the **generic hardware information** can be seen and configured here.

### Status

This page displays the general status of the card, which includes **slot information**, **up time** and **alarming**.

Specific card information can also be found here, namely the **Laser Status** and the **Transmitter Input** status.

From version 1.0.0.3 onwards, the **Optical Transmitter Laser** information is also available on this page.

### Configuration

This page provides access to general configuration and actions, such as the **Module Reset**, **Factory Default** reset and **Slot Reset** for the relevant card. You can also change the status of the **Front Panel Lock**, and **Blink** the card's front status LED.

The page also contains specific card configuration options:

- **Transmitter Output Table:** Allows the configuration of **power adjustments** and **offsets** for the card's output.
- **Radio Frequency Configuration Table:** Allows the configuration of the laser's **power ratios** and **gains**, **wavelength** and the **Smart Transmitter** function.
- **Transmitter Distortion Table:** Allows the configuration of the **fiber length** and **filter slope**, to allow distance-related signal compensation.
- **Slot Test Point Table:** Allows you to determine which channel will be used for test points.

Version 1.0.0.3 of the connector introduces several large changes, including the addition of tables related to the optical transmitters. Because of this, this page looks different from that version onwards. It now displays the system configuration, including the **Date/Time**, the **Alarm Detection** and a **Software Reset**. While the **Slot Test Point Table** remains on this page, the other RF tables from version 1.0.0.1 have been moved to a specific subpage, accessible via the **RF Transmitters...** page button. Their functionality remains the same. An additional page button allows access to the **Optical Transmitters**' new tables, allowing you to turn them on/off, and to change the card's input configuration.
