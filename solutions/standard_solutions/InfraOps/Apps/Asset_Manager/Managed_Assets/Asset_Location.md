---
uid: Asset_Location
---

# Asset Location

An asset can be assigned to the following locations:

- Asset Slot: The “child” Asset that will be placed on the Asset Slot, needs to be in the Available, In Planning and Build Plan Ready states and his Device Type needs to have a Hierarchy Level defined (either Card, Fan, Module, Power Supply or Sub-Card). For the “parent” Asset that will receive “child” Asset will also need to be in the Available, In Planning and Build Plan Ready states and his Device Type needs to have a Hierarchy Level defined. Here the rules for hierarchy were explained in detail earlier (for example, a Card can only be placed in a Chassis).

- Container: The Container needs to be in the Active state, and the Asset needs to be in the Available, In Planning and Build Plan Ready states.

- Desk: The Desk needs to be in the Active state, and the Asset needs to be in the Available, In Planning and Build Plan Ready states.

- No Location: Option used to remove existing location (or when it wasn’t defined yet), the asset needs to be Available, In Planning and Build Plan Ready states.

- Rack: The Rack needs to be in the Active state, and the asset needs to be Available, In Planning and Build Plan Ready states, its Asset Class needs to have dimensions defined (more than 0U of height), and it needs to have the tag “Rack Unit consumer” on the Device Type.

- Room: The Room needs to be in the Active state, and the Asset needs to be in the Available, In Planning and Build Plan Ready states.
