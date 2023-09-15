---
uid: Connector_help_AppearTV_Manager
---

# AppearTV Manager

The **AppearTV Manager** is an Application for managing and creating elements using the **AppearTV General Platform**.
The application is used to have an overview of all the devices and services. On top of this application there is a Visio layer to visualize all the elements, DVE Map & services.

## About

The **AppearTV Manager** application makes it possible to search the network for AppearTV Chassis. Therefore you need the **Skyline IP Network Discovery** protocol be installed.

When the Chassis elements are already created on the DMA, you can also use the sync option to sync the Application with the DMA.

## Configuration

The AppearTV Manager is a virtual connector, so you do not have to fill in any configuration parameters during element creation.

## Visual Overview

### Devices/Map page

All DVEs (slot cards) of all the AppearTV Chassis elements in the system are mapped out in categories. Those categories are: Input, Decoding, (pre-) Processing, Encoding/Transcoding, (post-) Processing & Mux/Output.

In each shape you have some additional KPIs such as **Chassis Name**, **Slot Number** and **Number of Ports**. When clicking a DVE shape, the DVE will be opened.

### Devices/Rack page

An overview is available of all the physical racks. In each rack you can see the different chassis devices.

When you click "*Arrange*" in the context-menu (right-click-menu), you can drag drop the units to another position in the racks.

This way you can create a visual rack overview that matches the physical setup and it will be easier to find devices that are in alarm.

The **Rack Names** can be configured ont the Visio page Discovery/Settings Racks...

When clicking a Device in the rack overview, the Chassis element will be opened. (extra information about the chassis connector: see **AppearTV General Platform** )

### Services/Overview page

An overview is available with all created DataMiner services. For each services you can see the amount of alarms. Critical (Cr), Major (Ma), Minor (Mi) & Warning (Wa).

When clicking on a Service shape, The Service card will be opened.

### Services/Config page

Here you will find a list of all the created services. The service names are configurable.

### Discovery/Settings page

This page is used for configuration of the network search for Chassis devices.

#### General

**Progress** & **Detected Devices** are parameters that will update while the Scan is running.

**Detection Status** & **Result**, contain the state, and the amount of discovered devices. The two buttons are to **start** or **Abort** the scan.

Note that an element should be running with the **Skyline IP Network Discovery** protocol in order to be able to use the Detection mechanism.

(extra information about the Detection connector: see **Skyline IP Network Discovery**)

#### Settings

Before you start the scan, you need to make sure the IP range is configured. The scan will check all the IPs in the range if there are devices available.

You can edit the range by supplying the **IP Address** and **Subnet Mask** or you can fill in the **Start-** and **Stop Ip Address**.

The parameter **Elementname Prefix** is used to supply a prefix for all the detected devices. Default: *AppearTV*.

The page button **Racks...** opens the Rack Configuration table. You can Add/Delete Racks and change the name, description and Rack dimension. (These racks are visible on the Visio page **Devices/Racks**)

### Discovery/List page

After a Scan is performed, the detected devices will be populated in the Table with all devices. The IP is used as index of the table. if the chassis is has DUAL Ip, you can see the second ip in the table.

You can change all configurations for each entry in the table. The buttons in the table let you **Create** or **Delete** the actual elements.

When an element is not created, you can also remove the entry from the list by using the **Remove Entry** button.

On Top of the page we have the **Create**- and **Delete All Elements** buttons. Using these buttons, alle elements will be created/deleted. The elements will be created with protocol **AppearTV General Platform** version: **production**.

There is also the **Synchronize** button which can be useful if this application is installed on a system that already contains a lot of **AppearTV General Platform** Chassis elements.

## Data Display

On the data pages of the element, you can configure some additional parameters.

### Device Detection page

With **Elements View** you can choose in which view the generated elements will be placed.

All other parameters are also available in the Visual Overview layer.

### Services page

With **Service Visio** you can choose if a Visio file needs to be assigned to the the service. The Visio file name can be configured in **Service Visio Name**.

The **Service View** will let you select in which view the services should be placed after they are created.

In the **service Table** you can see extra columns **Filter 1**, **2** and **3**. These columns are not available in the Visual Overview layer, but they are just to see the result of the **Filter Config...**

When opening the **Filter Config...** popup page you see a table with configurations for the extra filters.

There are three filters: **Filter 1**, **2** and **3**. each filter can be of type *Disabled*, *Property*, *Card* or *Service Name.* Next to the type you have also the **Filter Value** and **Set Service Property**.

When the Set Service Property is enabled, then the result value of the filter will be updated in the property of the service. The property name will be *Filter 1*, *Filter 2* or *Filter 3*.

Below is an overview of the different filter types combined with their Filter Values:

1\) Disabled: The filter is inactive, Filter value is not needed.

2\) Property: when this type is selected, the property from the chassis (provide property name in Filter Value) will be in the Filter.

3\) Card: when this type is selected, the filter result value will contain a self defined value when a filter matches in the Card types. Format: "*Satellite:\*Sat\*;Analog:\*Analog\*;Other:\**"

The format is a ';' separated string each time containing a 'filter-value' (\* is used as wildcard) : the value that you want in the filter.

4\) Service Name: This is the same behavior as type *Card*. except now the filtering is looking in the service name instead of the Card types.

The button **Apply Filters** will force the execution of the filtering mechanism.
