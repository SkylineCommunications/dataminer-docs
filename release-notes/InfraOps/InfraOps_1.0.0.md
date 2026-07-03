---
uid: InfraOps_1.0.0
---

# InfraOps 1.0.0

## New features

#### Asset Manager: Initial functionality [ID 45769]

The new Asset Manager app is used to model and manage asset inventories, from asset classes and individual assets down to their ports, connections, and rack placements.

With this initial release, you can:

- Create and manage assets through interactive dialogs, capturing network details (IPv4/IPv6, MAC, hostname), location, lifecycle, custody, and ownership.
- Define asset classes as reusable templates, specifying device types, hierarchy roles, physical dimensions (height/width/depth), power consumption, weight, and lifecycle dates (EOL, EOS, nominal lifetime).
- Import asset classes from Netbox repositories on GitHub.
- Import and export assets via CSV, with validation and error reporting.
- Configure slots (cards, modules, fans, power supplies) on chassis-level asset classes, and assign child assets to those slots.
- Visualize the full asset hierarchy in an interactive node-edge graph.
- Create and manage data ports and power ports per asset class and asset.
- Establish data and power connections between assets, with a dedicated Connections page for filtering and overview.
- View connection panels visually for patch panel-style assets.
- Optionally track connection history.
- Assign assets to racks and reserve rack slots, with optional linking to Plan and Build jobs.
- Visualize racks, rows, and rooms, each on a dedicated page.
- Compare two racks side by side.
- Link one or more DataMiner elements to an asset, and set an element to be the primary element for the asset.
- Duplicate existing assets for rapid provisioning.
- Manage the asset lifecycle through defined state transitions (Draft, Active, Installed, Decommissioned, etc.).
- Define and edit custom properties on assets.
- View statistics about assets and racks.

#### Facility Manager: Initial functionality [ID 45770]

The new Facility Manager app gives a hierarchical view of physical infrastructure, from facilities and floors all the way down to individual rack positions.

With this initial release, you can:

- Create and manage the full hierarchy: Facilities → Floors → Rooms → Zones → Rows → Racks → Desks.
- Define facility types: Building, Container, or Truck.
- Set geographic coordinates (latitude/longitude) on facilities and view them on a Google Maps component.
- Configure rack details including measurements, cooling capacity, space, and power.
- Configure zone thermal types (Warm/Cold) with cooling usage tracking based on assigned asset power consumption.
- Design room layouts, including placement of racks and zones.
- Upload and manage plan images for facilities, floors, rooms, zones, rows, and desks via the Web File Manager.
- Assign and remove racks, rows, zones, and desks to/from rooms.
- View usage KPIs: facility count, rack units, and power consumption.
- Manage lifecycle states for facilities and rooms (Draft → Active → Deprecated).

#### Plan and Build: Initial functionality [ID 45771]

The new Plan and Build app covers planning, tracking, and organizing build activities across managed infrastructure.

With this initial release, you can:

- Create and manage infrastructure jobs (installation, provisioning, upgrades, maintenance, etc.).
- Configure a job name prefix (e.g., `JOB #`) for consistent identification.
- Assign jobs to team members and track progress through configurable states.
- Associate jobs with specific facility locations and assets.
- Link jobs to rack slot reservations created from Asset Manager.
- Export job cabling plans for field teams.
- View jobs in a list or on a timeline.
- View job statistics.
