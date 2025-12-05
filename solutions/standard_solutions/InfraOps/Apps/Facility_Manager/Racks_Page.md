---
uid: Racks_Page
---

# Racks

The Racks page displays an overview of all configured racks, along with the rack capacity, power capacity, and space usage (%). The latter is calculated based on the size of the assets placed on the rack and its maximum power consumption. These are defined in the Asset Manager app, specifically with the [asset class configuration](xref:Asset_Class_Details).

Once you have configured your facilities and rooms in the Facility Manager app, the final step to add all infrastructure is typically [adding the racks](#adding-a-rack).

![Racks Page](~/solutions/images/Facility_Manager_Racks_Page.png)

## Adding a rack

1. In the top-left corner of the Racks page, click *New Rack*.

1. Configure the following fields, and then click *Save*:

   - **Rack Name**: Mandatory field.
   - **Rack Model**: Mandatory field.
   - **Rack Position**: If set to *Bottom*, slot 1 is at the bottom of the rack. If set to *Top*, slot 1 is at the top of the rack.
   - **Rack Label**: This is displayed in the Room Designer and Room Viewer, when the rack is placed on the room.<!-- TBD -->
   - **Maximum Power Capacity (kW)**: Consumed based on the assets that are placed on the rack.
   - **Maximum Rack Capacity (U)**: The number of rack units available for this rack.
   - **Room Name**/**Row Name**/**Zone Name**: The location where the rack is added.

   This will add the rack to the racks overview table.

1. To further configure the rack, click the details button (ⓘ) in the table.

   This will open a pane where you can configure additional details:

   - To add a description, click the pencil in the *Rack Info* section.

   - To specify the cooling flow, click the pencil in the *Rack Info* section, and select the flow:

     - *Front to Rear*: Air flows from the front of the rack to the rear, which is the standard configuration for most server and network equipment.
     - *Rear to Front*: Air flows from the rear of the rack to the front, which is less common but used in specific scenarios.
     - *Side to Side*: Air flows from one side of the rack to the other, typically used for certain network equipment.
     - *Top to Bottom*: Air flows from the top of the rack to the bottom, used in some specialized setups.
     - *Bottom to Top*: Air flows from the bottom of the rack to the top, often used in conjunction with raised floor cooling systems.

   - To specify the height, width, and depth (in cm), click the pencil button in the *Rack Measurements* section. This will be reflected in the Room Designer and Room Viewer.<!-- TBD -->

<!-- To add: Link Image & Gallery -->

<!-- Not yet reviewed: -->

Rack must be set to Active to allow asset assignment.
