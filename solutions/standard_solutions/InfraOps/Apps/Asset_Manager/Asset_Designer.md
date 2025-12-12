---
uid: Asset_Designer
---

# Asset Designer

On the Asset Designer page, you can configure the asset classes used in your system. This is typically the first step when configuring the Asset Manager app. You can import the classes via CSV or from GitHub, but you can also you can manually create classes.

## Importing asset classes

To start importing asset classes, click *Import/Export Asset Classes* in the top-right corner. You can then choose between *Import Netbox Asset Classes* or *Import/export Asset Classes to/from CSV*.

The **Import Netbox Asset Classes** option allows you to import assets from Netbox using the following GitHub repositories:

- [devicetype-library](https://github.com/netbox-community/devicetype-library/tree/master/device-types).

- [netbox-devicetype-library](https://github.com/nrkno/netbox-devicetype-library/tree/master/device-types).

To do so, you will first have to select up to 60 files from the repositories, then click *Selected files*, and then click *Import*.

The **Import/export Asset Classes to/from CSV** allows you to select whether to import or export the asset classes. To import them, keep the *Import* option selected, select and upload your CSV file, and click *Import*.

## Manually creating an asset class

1. In the header bar, select *New Asset Class*.

1. Specify the following details

   - **Asset Class Name**: A unique descriptive identifier for the asset class.

   - **Device Type**: The device type. This is intended to provide a higher-level classification (e.g. encoder, video router) and to determine how the asset class and its associated assets behave within the system. For info on how to manage these device types, see [Configuring device types](#configuring-device-types).

   - **Manufacturer**: Allows you to select a manufacturer. You can select any of the organizations configured in the [People and Organization](xref:People_Organizations) app.

   ![Asset Class Wizard](~/solutions/images/Asset_Manager_Asset_Class_Wizard.png)

1. Click *Save*.

## Activating an asset class

When an asset class has been imported or created, it will first be set to the Draft state. To activate it, click the state cell in the table and select *Set to Active*:<!-- TBD: limitations of draft state? -->

![Asset Class State context menu](~/solutions/images/Asset_Manager_Asset_Class_State_Context_Menu.png)

## Configuring device types

Device types can be managed via the **Device Types** button in the header bar of the Asset Designer page.

The solution includes a predefined set of device types, which you can extend as needed:

![Device Type side panel](~/solutions/images/Asset_Manager_Device_Type_Side_Panel.png)

### Adding a device type

To add a device type, click **New Device Type**.

This will open a wizard where you can configure the following fields:

- **Device Type Name**: A unique name for the device type

  If it includes the name "Connection Panel", it can be used as such. More details on the Connection section. <!-- TBD -->

- **Device Type Description**: Optional description of the device type.

- **Tags**:

  - **Accepts Data Connection**: Indicates whether the assets with this device type are allowed to receive data connections.
  - **Power Provider**: Indicates whether the assets with this device type are allowed to provide energy to other assets.
  - **Rack Unit Consumer**: Indicates whether the assets with this device type will consume rack units when placed in a rack.

- **Use Hierarchy Level**: If this option is enabled, you will be able to select the **hierarchy role** of the asset, which can be *Chassis*, *Card*, *SubCard*, *Module*, *Fan*, or *PowerSupply*.

![Device Type Wizard](~/solutions/images/Asset_Manager_Device_Type_Wizard.png)

### Device type hierarchy roles

The hierarchy roles that you can select for a device type respect the following structure:

<pre style="font-family: monospace; font-size: 14px;">
<span style="color:blue;">Chassis (Asset)</span>
<span style="color:blue;">├── Module (Asset)</span>
<span style="color:orange;">│   └── Port</span>
<span style="color:green;">├── Card Slot (Holder)</span>
<span style="color:blue;">│   └── Card (Asset)</span>
<span style="color:green;">│       ├── SubCard Slot (Holder)</span>
<span style="color:blue;">│       │   └── SubCard (Asset)</span>
<span style="color:green;">│       │       ├── Port Holder (Holder)</span>
<span style="color:blue;">│       │       │   └── Module (Asset)</span>
<span style="color:orange;">│       │       │       └── Port</span>
<span style="color:orange;">│       │       └── Port</span>
<span style="color:green;">│       ├── Port Holder (Holder)</span>
<span style="color:blue;">│       │   └── Module (Asset)</span>
<span style="color:orange;">│       │       └── Port</span>
<span style="color:orange;">│       └── Port</span>
<span style="color:green;">├── Fan Slot (Holder)</span>
<span style="color:blue;">│   └── Fan (Asset)</span>
<span style="color:green;">├── PowerSupply Slot (Holder)</span>
<span style="color:blue;">│   └── PowerSupply (Asset)</span>
<span style="color:green;">├── Port Holder (Holder)</span>
<span style="color:blue;">│   └── Module (Asset)</span>
<span style="color:orange;">│       └── Port</span>
<span style="color:orange;">└── Port</span>
</pre>

The hierarchy levels determine which assets can be assigned to other assets:

- A *Chassis* asset can have assets assigned to it of level *Card*, *Fan*, *PowerSupply*, or *Module*.

- A *Card* asset can have assets assigned to it of level *SubCard* or *Module*.

- A *SubCard* asset can have a *Module* asset assigned to it.

- It is not possible to assign assets to assets of level *Fan*, *PowerSupply*, or *Module*.

### Defining the number of slots for an asset class

<!-- the section below still needs to be reviewed -->

If you have created an asset class using a device type with a hierarchy level, for example a Chassis asset, you can define the number of slots available for each hierarchy level.

![Chassis Asset Class details](~/solutions/images/Asset_Manager_Chassis_Asset_Class_Details.png)

![Cards side panel](~/solutions/images/Asset_Manager_Cards_Side_Panel.png)

Assets created based on this Asset Class will have the same number of slots configured on the Asset Class (this can still change this default configuration). To configure Device Types, the user needs to select the button on the top left side. There, we also have the option to configure Cable and Port Types.
