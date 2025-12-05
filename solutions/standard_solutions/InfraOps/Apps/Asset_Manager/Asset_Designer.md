---
uid: Asset_Designer
---

# Asset Designer

To start, the user will need to configure his Asset Classes. To facilitate this, it’s possible to import asset classes via CSV, or import assets from Netbox using the following GitHub repositories:

- [devicetype-library](https://github.com/netbox-community/devicetype-library/tree/master/device-types).

- [netbox-devicetype-library](https://github.com/nrkno/netbox-devicetype-library/tree/master/device-types).

After creating/importing any Asset Class, the initial state for it is “Draft”. It can be activated by clicking the state cell in the table:

![Asset Class State context menu](~/solutions/images/Asset_Manager_Asset_Class_State_Context_Menu.png)

To manually create an Asset Class, by pressing the “New Asset Class”, the user will need to insert the following details:

![Asset Class Wizard](~/solutions/images/Asset_Manager_Asset_Class_Wizard.png)

- Asset Class Name: A unique descriptive identifier for the Asset Class

- Manufacturer: Retrieved directly from the **Organizations** section under the People and Organization app.

- Device Type: Defined by selecting the **Device Types** button in the top-left corner of the page. This field serves two purposes:

    - Provides a higher-level classification (e.g., Encoder, Video Router).

    - Determines how the Asset Class and its associated assets behave within the system.

The Inventory and Asset Management solution includes a predefined set of Device Types, which users can extend as needed:

![Device Type side panel](~/solutions/images/Asset_Manager_Device_Type_Side_Panel.png)


![Device Type Wizard](~/solutions/images/Asset_Manager_Device_Type_Wizard.png)

- Device Type Name: Unique descriptive field for the Device Type

    - If it includes the name “Connection Panel”, it can be used as such. More details on the Connection section

- Device Description

- Tags:

    - Accepts Data Connection: Allows the Asset to receive Data connections

    - Power Provider: Allow the Asset to provide energy to other assets

    - Rack Unit Consumer: If enabled, the Asset will consume Rack Units when placed on a Rack

- Use Hierarchy Level

- Hierarchy Role: When enabled, the Asset can be a Chassis, a Card, a Subcard, a Module, a Fan or a Power Supply

This respects the following structure:


<pre style="font-family: monospace; font-size: 14px;">
<span style="color:blue;">Chassis (Asset)</span>
<span style="color:blue;">├── Module (Asset)</span>
<span style="color:orange;">│   └── Port</span>
<span style="color:green;">├── Card Slot (Holder)</span>
<span style="color:blue;">│   └── Card (Asset)</span>
<span style="color:green;">│       ├── Sub-Card Slot (Holder)</span>
<span style="color:blue;">│       │   └── Sub-Card (Asset)</span>
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
<span style="color:green;">├── Power Supply Slot (Holder)</span>
<span style="color:blue;">│   └── Power Supply (Asset)</span>
<span style="color:green;">├── Port Holder (Holder)</span>
<span style="color:blue;">│   └── Module (Asset)</span>
<span style="color:orange;">│       └── Port</span>
<span style="color:orange;">└── Port</span>
</pre>

- A Chassis Asset can have Assets assigned to it, that are: Cards, Fans, Power Supplies and Modules

- A Card Asset can have Assets assigned to it, that are: Sub-Cards and Modules

- A Sub-Card can have Modules assigned to it

- Fans, Power Supplies and Modules can’t have assets assigned to them

If a user creates an Asset Class that has hierarchy, a Chassis for example, they will be able to define the number of slots available for each Hierarchy Level:

![Chassis Asset Class details](~/solutions/images/Asset_Manager_Chassis_Asset_Class_Details.png)

![Cards side panel](~/solutions/images/Asset_Manager_Cards_Side_Panel.png)

Assets created based on this Asset Class will have the same number of slots configured on the Asset Class (this can still change this default configuration). To configure Device Types, the user needs to select the button on the top left side. There, we also have the option to configure Cable and Port Types.
