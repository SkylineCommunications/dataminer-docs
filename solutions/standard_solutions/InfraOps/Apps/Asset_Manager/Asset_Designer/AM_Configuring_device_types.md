---
uid: AM_Configuring_device_types
---

# Configuring device types

Device types can be managed via the **Device Types** button in the header bar of the Asset Designer page.

The solution includes a predefined set of device types, which you can extend as needed:

![Device type pane](~/solutions/images/Asset_Manager_Device_Type_Side_Panel.png)

## Adding a device type

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

![Device type wizard](~/solutions/images/Asset_Manager_Device_Type_Wizard.png)

## Device type hierarchy roles

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
