---
uid: Connector_help_Generic_Rack_Layout_Manager
---

# Generic Rack Layout Manager

This connector is used in order to visualize devices in racks in DataMiner using DataMiner views and a visual overview.

## About

The **Generic Rack Layout Manager** application is able to automatically create views in DataMiner.

These views are based on a structure that is defined by element properties (**Deployment Building**, **Floor**, **Room**, **Aisle** and **Rack**).

The application will create the views accordingly and move the elements into their correct views.

### Version Info

| **Range**     | **Description**                                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                           | No                  | Yes                     |
| 2.0.0.x \[Obsolete\] | This range is used by DataMiner IDP.                       | No                  | Yes                     |
| 2.0.1.x \[Obsolete\] | This range is used by DataMiner IDP.Unicode support added. | No                  | Yes                     |
| 2.0.2.x \[Obsolete\] | Increased minimum DataMiner version to 10.0.0.0 - 9517 CU6 | No                  | Yes                     |
| 2.0.3.x \[SLC Main\] | Removed parameters                                         | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

In range 2.0.0.x, DataMiner IDP takes care of the element creation.

## Usage

### General

The **Protocols Table** collects all installed connectors on the system. For each connector, it is possible to indicate whether or not elements using this connector should be taken into account during provisioning of the **DataMiner Devices Table**.

For each connector that has the **Present in Rack** parameter set to *Yes*, all elements using the connector will be displayed in the **DataMiner Devices Table**. By default, the element name is used as display name, but this value can be overwritten through the **Device Custom Name** parameter.

You can select the rack that hosts the unit, the size of the unit (in RU) and its position within the rack. To disable visualization while maintaining the element table entry, you can set the **Rack Visibility** parameter to *Hidden.*

You can visualize units that do not have a corresponding DataMiner element by creating an entry in the **Other Devices Table**. The same configuration parameters apply.

The usage for connector range 2.0.0.x is explained in a separate section of the DataMiner Help.

### Overview

There are two tree control components on this overview page. The first tree control displays all the physical levels. On each level, you can see the sub-level items and also the included **DataMiner Devices** and **Other Devices** in the consecutive tabs.

The second tree control displays all the connectors with the linked elements.

### Physical Location

Racks can be added via the **Racks Table**. The size of the rack (in RU) and additional info can be specified. You also need to indicate in which aisle the rack is located. A drop-down box is available to select the correct aisle.

Views matching with the created rows will automatically be created under the correct linked view. For building entries, the view will end up under the view configured via **Parent Building View ID**.

In case a new rack is added, the view will be created and the Visio drawing of the rack will automatically be assigned. Any configuration changes will be applied in real time.
