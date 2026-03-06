---
uid: SatOps_1.0.0
---

# SatOps 1.0.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.5.0](xref:MediaOps_Plan_1.5.0) or higher.

## New features

#### Satellite Inventory: Initial functionality [ID 44951]

The Satellite Inventory app enables satellite operators to model and manage their full satellite inventory, including satellites, beams, transponders, transponder plans, and corresponding transponder slots.

With this initial release, you can:

- Create, edit, and manage satellites, beams, and transponders through guided and interactive dialogs.
- Import satellite demo data from a predefined template for quick environment setup.
- Define time-boxed transponder plans with configurable slot sizes, generate transponder slots from those plans, and also configure a permanent base plan.
- Visualize the satellite hierarchy (satellite, beams, transponders) in an interactive node edge graph.
- Visualize transponder plan layouts using a CSS grid representation and inspect individual transponder slots from a dedicated panel.
- Display satellite coverage areas and beam footprints on a geographical map using KML files.
- Navigate directly from a transponder in the Satellite Inventory to the corresponding view in the Satellite Scheduling app and vice versa.
- Keep transponder resources in sync with MediaOps Plan's Resource Studio, including automatic activation and deprecation of these (unmanaged) resources.

#### Satellite Scheduling: Initial functionality [ID 44952]

The Satellite Scheduling app allows you to browse, book, and manage transponder capacity across your satellite fleet using a transponder timeline component.

With this initial release, you can:

- View all transponder slots and their corresponding bookings on a transponder timeline, with user-friendly coloring that makes it easy to spot which jobs book which capacity of the transponder.
- Automatically be in line with the plan that is active at a specific time, as the base plans and time-boxed plans are taken into account to determine which slots are available at any time. You can even book slots over two subsequent plans, as long as their slot configuration allows it.
- Scroll vertically and horizontally via easy keyboard and mouse commands (Alt-Scroll and Ctrl-Scroll).
- Select an available transponder slot through a dedicated Slot Picker page with filtering by satellite and transponder, which is integrated with MediaOps Plan's Scheduling app.
- Benefit from optimized data source performance, enabling fast loading of all booked and available slots.
- Navigate to the corresponding's transponder configuration panel in the Satellite Inventory with a click on the transponder's title.
