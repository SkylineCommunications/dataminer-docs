---
uid: Racks_Page
---

# Racks Page

Final step from a hierarchical level, here racks can be configured. It displays the Space and Power Capacity, along with their Usage (%). It’s calculated based on the size of the assets placed on the rack (amount of Rack Units) and its Maximum Power Consumption.

This can be defined on the Asset Designer, specifically, on the Asset Class (see also [Asset Class Details](xref:Asset_Class_Details)):

![Racks Page](~/solutions/images/Facility_Manager_Racks_Page.png)

After creating a Rack (Name and Model are mandatory fields), the user can configure the following fields:

- Name and Model

- Description

- Label: Displayed on the Room Designer and Room Viewer, when the rack is placed on the room

- Position: If set to ‘Bottom’, the Slot 1 starts from the bottom. If set to “Top”, Slot 1 starts from the top of the rack

- Height, Width and Depth (cm): This will be reflected on the Room Designer and Viewer

- Maximum Power Capacity (kW): Consumed based on the assets that are placed on the rack

- Maximum Rack Capacity (U): Amount of Rack units available for this rack

- Cooling Flow:

    - Front to Rear: Air flows from the front of the rack to the rear, which is the standard configuration for most server and network equipment.

    - Rear to Front: Air flows from the rear of the rack to the front, which is less common but used in specific scenarios.

    - Side to Side: Air flows from one side of the rack to the other, typically used for certain network equipment.

    - Top to Bottom: Air flows from the top of the rack to the bottom, used in some specialized setups.

    - Bottom to Top: Air flows from the bottom of the rack to the top, often used in conjunction with raised floor cooling systems.

- Room, Row and Zone

Rack must be set to Active to allow asset assignment.
