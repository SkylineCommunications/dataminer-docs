---
uid: Connector_help_Blackmagic_Design_HyperDeck
---

# Blackmagic Design HyperDeck

The **Blackmagic Design HyperDeck** disk recorders let you record the highest quality uncompressed or compressed ProRes and DNxHD video formats using fast 2.5" SSDs.

## About

This connector communicates with the device using serial commands as described in the device's manual. For more information please refer to the website <https://www.blackmagicdesign.com/products/hyperdeckstudio>

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.3                         |

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **Type of Port:** TCP/IP
- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The IP port of the device, by default 9993*.*
- **Bus address**: Not used*.*

## Usage

### General

This page displays general information from the deck.

### Settings

On this page it's possible to change some of the Remote Control, Notification and Configuration settings of the deck.

### Slots

Page shows the two available slots and its status.

### Clips

This page can be used to control the clips available in each one of the slot disks.

### Debug

Page available to send manually commands to the deck. a pre-defined list of the available commands is already available.
