---
uid: Connector_help_Skyline_Software_Panel
---

# Skyline Software Panel

This is a generic connector that can be used to interact with button panel connectors (also known as hardware panels). This connector allows you to create logic for the buttons of a button panel.

From DataMiner 10.0.3 onwards, you can also generate a button panel UI component in a DataMiner dashboard (if the soft-launch option *ReportsAndDashboardsButtonPanel* is enabled). This will provide an interactive representation of the button panel, making a real physical panel unnecessary.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                             | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Page system for button panel. Supported actions for buttons: - Page jump - DataMiner parameter get - DataMiner parameter set - DataMiner element alarm state | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

An element using this connector should be **created by a manager element** that runs the [Skyline Panel Manager](xref:Connector_help_Skyline_Panel_Manager) connector. This way, the manager can automatically provision the correct capabilities to the software panel, as well as make the link with the hardware, if desired.

If you use a DataMiner dashboard, you can provision a CSS file on the **Layout** page. This CCS can be used to override the default looks of the panel UI if needed.

## How to use

### General

This page contains the main information of the panel. It contains the **Main Button Panel** table and the **Pages** table.

- The **Main Button Panel** table contains a list of all buttons that are defined over all the pages. Each button has an **Advanced Layout**, which contains the layout properties of the button, and a **Linked Action**, which contains the action that this button must execute when used.
- The **Pages** table contains the current pages that are defined for the button panel. New pages can be created via the button **Add Page**. Pages can be sorted with the **Move Up** and **Move Down** buttons that are available for each page.

### Debug

On this page, you can find information about the connected hardware panel, if any. It shows information such as the DMA and element ID of the connected panel, as well as the messages that have been received from that panel.

### Capabilities

On the **Capabilities** page, you can find more information about the setup for the software panel. It shows all the capabilities of the button panel (button panel type, number of buttons, composition of these buttons on the panel, properties of the buttons, etc.).

**Capabilities** will automatically be loaded when a panel manager is used (see Configuration section above), but you can also provision these manually by entering the file path of the capability file and clicking **Provision via File**. There is also the option to request the capabilities straight from the hardware panel, if that command has been implemented in the relevant connector and a link has been made between the hardware and software panel.

### Subscriptions

This page contains the current subscriptions that are being tracked by the element. Each subscription has a key that consists of the DMA ID, element ID, and parameter ID (as well as the table index, if applicable). Each entry contains the latest value that was retrieved from the subscription, as well as a concatenation of all the buttons that are currently subscribed to on this parameter.

### Layout

For the dashboard UI, custom CSS code can be applied to add to the basic CSS functionalities that are already stored by default. You can load CSS files by entering a file path and clicking the **Provision via File** button.

## Notes

We recommend that you combine this connector with the [Skyline Panel Manager](xref:Connector_help_Skyline_Panel_Manager) connector, which can create, link, and manage both hardware and software panels.
