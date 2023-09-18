---
uid: Connector_help_Harmonic_HLP4200
---

# Harmonic HLP4200

The **Harmonic HLP4200** chassis is a piece of hardware that supports plug-in modules used in HFC headend systems.

The management functions are supported by a plug-in controller that communicates with other plug-in modules via an I2C bus and direct I/O lines.

The chassis and modules support the functions as follows:

1. Plug-in module presence.
1. Plug-in module identification.
1. Plug-in module control and monitoring.

## About

This connector retrieves data from the device(s) through a serial interface and displays information on installed modules for each device address.

The data specific for each module is organized on the **Devices** page.

For each module, a **DVE** is created that includes:

- **General page** (with all generic data from the module).
- Specific pages for parameters specific to the device type of the generated DVE. Where possible, these parameters can also be set.

## Installation and configuration

### Creation

This connector uses two serial connections and requires the following input during element creation:

**SERIAL CONNECTION 1**:

- **Type of port:** The type of port used for the communication with the device, e.g. *TCP/IP.*
- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP Port:** The polling port of the device, e.g. 4010.

**SERIAL CONNECTION 2**:

- **Type of port:** The type of port used for the communication with the device, e.g. *TCP/IP.*
- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP Port:** The polling port of the device, e.g. *975.*

### Resources

There is no automatic chassis discovery available for this protocol. This means that the operator must manually add the chassis to be polled. The discovery and polling of the modules is performed automatically for each manually configured chassis.

## Usage

### Module Overview Page

This page displays two tables:

- **Chassis Overview**: Displays a list of installed chassis. You must fill in this list manually.
- **Module Overview**: Displays a list of installed modules. You can automatically poll this list from the configured devices by clicking a button.

To add a chassis to the protocol, click the **Add Chassis** button. The parameters **Module Chassis Address** and **Master CPS Slot** must be correct in order for the discovery process to occur correctly.

To automatically query the configured chassis for installed modules, make sure the correct chassis information is present in the **Chassis Overview** table and click the button **Load Modules** to start the module discovery process. This will insert the list of modules currently installed in the configured chassis into the **Module Overview** table. When this table is filled in entirely and the **Get Modules Status** parameter is set to *Ready*, click the **Poll Modules** button to poll each individual module and get its respective data. This process also inserts each individual module into its respective table on the **Devices Page**. Both the **Poll Modules** and the **Load Modules** button will only create a new table entry if such an entry does not exist yet. If a table entry already exists, but its values were changed, the entry is updated instead of being removed and substituted with a new table entry.

You can remove chassis or modules from their respective tables whenever necessary.

### Devices Page

This page displays each module installed in the configured chassis. Each different module type has its own table and each individual module is represented by an individual row in the relevant table. Each table displays different data related to the corresponding module type.

For each individual table row on this page, a **DVE** element is created. Each DVE element displays data according to its module type. Changes made to the data in the DVE element are reflected on the **Devices Page** and vice-versa.

## Notes

If the **Chassis Overview** table is already configured with the correct chassis address and an element restart occurs, the modules are loaded and polled automatically without any operator intervention.
