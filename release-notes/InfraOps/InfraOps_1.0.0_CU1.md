---
uid: InfraOps_1.0.0_CU1
---

# InfraOps 1.0.0 CU1

## Changes

### Enhancements

#### Asset Manager: Holder label improvements [ID 45778]

Holder labels can now be configured with more flexibility, and the edit and delete holder dialogs have been streamlined.

#### Asset Manager: Location bubble-up through asset hierarchy [ID 45782]

When a child asset's location changes, the asset location is now automatically propagated up through the hierarchy, keeping the parent asset's location in sync.

### Fixes

#### Asset Manager: Managed Assets GQI data source returned incorrect results and linked elements were not displayed correctly [ID 45779]

It could occur that the GQI data source for the Managed Assets page returned incorrect results. In addition, the linked elements section could be displayed incorrectly in the asset details panel. Both issues have been resolved.

#### Asset Manager: Holders defined on asset class not copied to newly created assets [ID 45780]

It could occur that holders defined on an asset class were not copied correctly to newly created assets. To prevent this issue, validation logic has been added during asset creation from asset classes.

#### Asset Manager: Asset class import without port types failed [ID 45781]

When an asset class was imported without port types, the import would fail. Now, the first available port type is selected by default instead.

#### Various small fixes across all InfraOps apps [ID 45783]

Various small fixes have been implemented to the low-code app panels and navigation across Asset Manager, Facility Manager, and Plan and Build.
