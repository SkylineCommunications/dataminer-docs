---
uid: InfraOps_1.0.0_CU1
---

# InfraOps 1.0.0 CU1

## Changes

### Enhancements

#### Asset Manager: Holder label improvements [ID 45778]

Holder labels can now be configured with more flexibility, and the edit and delete holder dialogs have been streamlined.

### Fixes

#### Asset Manager: Managed Assets GQI data source returned incorrect results and linked elements were not displayed correctly [ID 45779]

It could occur that the GQI data source for the Managed Assets page returned incorrect results. In addition, the linked elements section could be displayed incorrectly in the asset details panel. Both issues have been resolved.

#### Asset Manager: Holders defined on asset class not copied to newly created assets [ID 45780]

It could occur that holders defined on an asset class were not copied correctly to newly created assets. To prevent this issue, validation logic has been added during asset creation from asset classes.
