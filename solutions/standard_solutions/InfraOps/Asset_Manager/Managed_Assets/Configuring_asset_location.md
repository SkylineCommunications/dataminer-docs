---
uid: Configuring_asset_location
---

# Configuring the asset location

To configure the location information for an asset, in the [*Asset details* pane](xref:Managed_Assets#configuring-asset-details), click the pencil icon in the *Location Information* section.

Depending on the type of asset, different types of locations can be configured:

- **Asset Slot**: An asset with a lower hierarchy level (Card, Fan, Module, Power Supply, or SubCard) or "child" asset can be placed in an asset slot of a "parent" element with a higher hierarchy level. For this both the "child" asset and the "parent" asset must have the "Available", "In Planning", or "Build Plan Ready" state. See [Device type hierarchy roles](xref:AM_Configuring_device_types#device-type-hierarchy-roles).

  ![Asset location configuration](~/solutions/images/Asset_Location_config.png)

- **Container**: To assign an asset to a "container" type of facility, the container needs to be in the "Active" state, and the asset needs to be in the "Available", "In Planning", or "Build Plan Ready" state.

- **Desk**/**Rack**/**Room**: To assign an asset to a desk, a rack, or a room, the desk needs to be in the "Active" state, and the asset needs to be in the "Available", "In Planning", or "Build Plan Ready" state.

  Assigning an asset to a **rack** is only possible if its asset class has dimensions defined (more than 0U of height) and its device type is configured as a "Rack Unit consumer" (see [Configuring device types](xref:AM_Configuring_device_types)).

- **No Location**: This option allows you to remove the currently configured location. You can only do so if the asset is in the "Available", "In Planning", or "Build Plan Ready" state.

<!-- TBD: 
- Currently not mentioned: Building, Truck: should these be included as well?
- It looks like the state requirements for an asset to be assigned are always the same: Available, In Planning, or Build Plan Ready. Is this indeed the case? If so, it would be better if we just mentioned these states for all assets in general instead of repeating this every time. -->