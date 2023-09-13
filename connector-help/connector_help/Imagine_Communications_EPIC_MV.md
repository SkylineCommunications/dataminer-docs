---
uid: Connector_help_Imagine_Communications_EPIC_MV
---

# Imagine Communications EPIC MV

This driver allows you to check and adjust the configuration of an Imagine Communications EPIC multi-viewer. You can switch layout on displays and set up picture-in-picture (PiP).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | EMVRA version 1.0      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This driver uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default: *52414*.

### Initialization

Make sure .NET 4.0 or higher is installed, as this driver requires that System.Web.Extensions.dll is available.

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## How to Use

This is a **smart-serial** driver that uses the EPIC-MV Remote API (**EMVRA**) to communicate. The driver will load the entire configuration after startup and at regular intervals. Change the layout using the **Displays** table or adjust PiP configuration in the **Picture in Picture Elements** table.

The element created with this driver consists of the data pages detailed below.

### General

This page displays basic information about the device and the API.

The **Multi Viewers** table describes the multi-viewers participating in the system. The **PiP Sharing Sources** table lists the MV IDs of the PiP-sharing multi-viewers in this configuration.

### Displays

The **Displays** table is a list of the available displays and the active layout. There is also a list of PiP IDs active on the display and the resolution of the display.

The **Layouts** page button leads to the **Display Layouts** subpage.

### Display Layouts

This page contains a collection of all available layouts. Only their name is displayed.

### Picture in Picture

The **Picture in Picture Elements** table contains the PiP objects for the active layout. If PiP objects are part of an active layout, they can be configured.

Click the **Configuration** page button to go to the **Picture in Picture Configuration** subpage and configure the suffix of the PiP display key.

### Picture in Picture Configuration

Additional information can be added to the PiPs of a specific display. This feature might not be applicable for every setup. To add this information, choose the **Display ID** and click **Create**. The PiPs of that display will then be loaded into the **Configuration** table. Edit the **Service Key**, **Order** and **Quality** according to your preference, and the specified **Format** will be applied to the selected **Display ID**.

### Alarms

This page contains a list of all individual alarms and their conditions. Their status is also summarized in the **Picture in Picture** table.

### Sources

The **Sources** table contains source objects with information about the multi-viewer video/audio sources assignable to PiPs. All available sources have an entry, but the presence/applicability of some attributes depends on the type of source. Depending on the **Source Type**, some parameters might not apply, in which case they will have the value *Not Applicable*. Parameters that do apply but have no value will remain *Unavailable*.

### Web Interface

This page displays the web interface of the device, if the client is in the same network as the device. Microsoft Silverlight support might be required.

### Web Interface (Magellan Logs)

This page opens the web interface of the device, pointing to port 8002, if the client is in the same network as the device. This displays the Magellan Logs of this equipment. Microsoft Silverlight support might be required.
