---
uid: Connector_help_Arris_DreamGallery_Varnish
---

# Arris DreamGallery Varnish

The Arris DreamGallery Varnish is part of the Arris DreamGallery connector. This connector will display the varnish stats.

## About

The Arris DreamGallery Varnish connector will get the varnish stats and will display them on the Varnish page. To get these stats there is a serial connection used where there will be an SSH connection created on.

## Installation and configuration

### Creation

This connector uses a **serial** connection and needs following user information:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **IP port**: the port of the connected device, default value: *22*
- **Bus address**: the bus address of the connected device

## Usage

### Varnish Page

On this page the varnish stats are displayed.

### Settings Page

On this page the settings to set up the SSH connection are available. The **User** **Name** and **Password** parameter need to be filled in, in order for the SSH connection to be set up.

Once this connection is set up, the varnish stats can be retrieved.
