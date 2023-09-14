---
uid: Connector_help_Teleste_DVX002
---

# Teleste DVX002

The **Teleste DVX002** connector can be used to display and configure information of the attached modules.

## About

This protocol can be used to monitor and control the modules attached to the Teleste DVX frame. A serial connection is used in order to successfully retrieve and configure the information of the device. There are also different alarming and trending possibilities available for the supported Teleste modules.

### Module Types

The protocol supports the following types:

- HDP
- DBM100
- HDO202
- HDO610
- HDO802
- HDO902
- DVO101
- DVO151
- DVO202
- DVO718M
- DVO771
- DVO902
- DVP432
- DVX911

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the Moxa connected to the DVX Bus, e.g. *10.11.12.13.*
- **IP port**: The port of the Local TCP connection used by the Moxa.

### Configuration

On the **General page** of the element, you need to configure the rack layout by adding new rack numbers with the **Add New Rack** button. For maximum performance, it is advisable to add only those racks that contain real modules. You can also set a rack inactive with the **Rack Active** toggle button in case the rack is empty.

## Usage

The Teleste DVX protocol creates a main element (rack configuration and module overview) and virtual elements for each supported module (slot) of the frame (Main Element Name followed by the Rack and Slot Number in question, for instance: *DVX 01 R0.S01*).

### Main Element

The connector's main element contains the following pages:

- **General**: Configuration of rack layout. Only an active rack that is set active will be polled. A new rack can be added with the **Add New Rack** button.
- **Module Overview**: For every card type of the active DVX frames, an entry is created in the **Devices Table**. With the **Remove Missing Modules** dropdown menu you can select **Remove All** or select a specific missing module. Setting this value will respectively remove all the missing modules or only remove the selected module. The missing module(s) will be removed from the device table and the related DVE(s) will be deleted.

### Virtual Elements

Each of the DVEs contains the following main page:

- **General**: The General page of the created DVE contains some general information (**Rack** and **Slot Number**, **HW Version**, etc.) regarding the card type, of which some parameters (for instance **Alias Name**) are modifiable.

Every supported module type of the DVX frame has its own specific features and capabilities. All of the module-related settings and statuses are provided on extra pages, which depend on the type of Teleste module.

The DVEs also have a **Refresh** button on every page, which can be used to refresh all the information of the selected DVE.

## Monitoring

The Teleste DVX002 protocol provides a very useful DataMiner feature: alarming and trending can be applied to every supported Teleste Module, specific for the module type.
