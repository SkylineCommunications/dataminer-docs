---
uid: Connector_help_Haivision_Kulabyte
---

# Haivision Kulabyte

The **Haivision Kulabyte** makes it possible to manage one or more encoder processes.

## About

The **Haivision Kulabyte** sends **REST** commands every minute in order to obtain its data. For each encoder process, a **Dynamic Virtual Element (DVE)** will automatically be created.

Note: For version 1.1.0.x, there is no DVE creation. This protocol version communicates directly with the encoder.

### Version Info

| **Range** | **Description**     |
|------------------|---------------------|
| 1.0.0.x          | Initial version     |
| 1.1.0.x          | HTTPS communication |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Kulabyte API v 3            |
| 1.1.0.x          | Kulabyte API v 4.4          |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy.*

Note: The 1.1.0.x version must use the path *https://\[polling IP\]:1080* as the path and port. The "*https://*" part must be typed into the **IP address/host** field in the element creation wizard.

### Configuration: Additional files

In order for this connector to be fully functional, the file "System.Web.Helpers.dll" must be available in the following folder: *C:\Windows\Microsoft.NET\Framework\v4.0.30319*.

Note: This is not required for the 1.1.0.x version.

### Configuration of the element

To set up communication with the API, credentials must be filled in on the page **Log In**.

## Usage (1.0.0.x range)

The **Haivision Kulabyte** protocol delivers two types of **DataMiner Elements**: a main element that contains all data, and a **Dynamic Virtual Element** for each encoder process.

### Main Element

The connector's main element contains the following pages:

- **Log In**: This page contains the credentials that must be filled in in order to have communication with the API.
- **Manage**: Overview of the encoders and the ECS. It's possible to add a new ECS to the table, which will generate a new **Dynamic Virtual Element**.
- **Presets**: This page contains settings related to the encoders.
- **Preferences**: This page contains default settings.

### Dynamic Virtual Elements

Each of the DVEs contains the following pages:

- **General Info**: This page contains monitoring data of the ECS.
- **Manage**: This page contains some default data of the ECS.

## Usage (1.1.0.x range)

The element contains the following pages.

### Log In Page

This page contains login credentials for the encoder.

### System Page

This page contains encoder system information. If there are Decklink cards detected, then the **Decklink Cards** table will show the card information.

The page also contains the following page buttons:

- **HTTP Response Codes**: Displays all the response codes for the connector polling.
- **ECS Version**: Displays version information for the encoder.
- **License Info**: Displays license information for the encoder.

### Channels Page

This page displays channel information for the encoder.

It also includes **Stop** and **Start** commands for the channels. The response from the encoder to these commands will appear in the **Channel Command Response** field.

In the **Preset** section, you can load presets into an encoder channel. To do so, first load a **channel**, then load a **preset**, then click the **Load Preset** button. Make sure that before you click the **Load Preset** button, you have set the channel and preset values by clicking the small green Set button. The response from the encoder to the load preset command will appear in the **Preset Load Information** field.

Note: This requires that some presets have been loaded. See the "Presets page" section below for more information on how to load presets.

### Presets page

Presets must be loaded from .xml files that you have either manually downloaded from the Kulabyte encoder of that you have created yourself using Haivision preset creation tools. The .xml files must be placed in a folder that is accessible from the DataMiner server. If no path is entered, the default path is created on the DataMiner server: *C:\Skyline DataMiner\Documents\Haivision Kulabyte\Presets XML Files*. Also, a UNC path may be used.

After the presets have been imported, the **Remove** button can be used to delete the preset from the **Presets** table. Clicking the **Details** button will show the contents of the preset .xml file in the **Preset Details** field.

The **Remove All** button will delete all the presets from the **Presets** table.

### Inputs page

This page displays a tree control with the following structure:

1. Channel 2

   1. Input 1
   1. Input 2

1. Channel 2

   1. Input 1
   1. Input 2

### Outputs page

This page displays a tree control with the following structure:

1. Channel 1

   1. Output 1

      1. Stream 1
      1. Stream 2

   1. Output 2

      1. Stream 1
      1. Stream 2

1. Channel 2

   1. Output 1

      1. Stream 1
      1. Stream 2

   1. Output 2
      1. Stream 1
      1. Stream 2

### Events page

This page displays the **events** that have been created on the encoder.
