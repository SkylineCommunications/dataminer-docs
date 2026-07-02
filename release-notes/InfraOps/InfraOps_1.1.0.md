---
uid: InfraOps_1.1.0
---

# InfraOps 1.1.0

## New features

#### Asset Manager: New asset and rack KPI panels [ID 45784]

KPI panels for assets and racks have been added to the overview, providing at-a-glance counts and utilization metrics.

## Changes

### Enhancements

#### Asset Manager: Location bubble-up through asset hierarchy [ID 45782]

When a child asset's location changes, the asset location is now automatically propagated up through the hierarchy, keeping the parent asset's location in sync.

#### Asset Manager: Improved DOM wrapper lifecycle handling [ID 45786]

The internal DOM wrapper lifecycle handling has been improved, enabling more consistent validation and cleanup during asset operations.

#### Asset Manager: Empty options added to dropdown selectors [ID 45788]

In the dropdown selectors in the Asset Manager app, empty options have now been added, making it possible to clear previously selected values.

#### New favicons and web app manifest [ID 45789]

New favicons and a web app manifest have been added to the InfraOps apps for better browser tab identification.

#### Asset Manager: Port handling improvements [ID 45790]

The port data model for data ports and power ports has been improved. Validation has been improved for port creation, editing, and connections, and handling is more consistent across import/export and interactive workflows.

#### Asset Manager: Pagination for large asset class lists [ID 45791]

The handling of large asset class lists has been improved by supporting pagination when assets are selected, preventing UI overload on systems with many asset classes.

### Fixes

#### Asset Manager: Asset class import without port types failed [ID 45781]

When an asset class was imported without port types, the import would fail. Now, the first available port type is selected by default instead.

#### Various small fixes across all InfraOps apps [ID 45783]

Various small fixes have been implemented to the low-code app panels and navigation across Asset Manager, Facility Manager, and Plan and Build.

#### Asset Manager: Changes not kept after editing ports [ID 45785]

When ports were edited on an existing asset, it could occur that the changes were not kept.

#### Asset Manager: Orphaned port references after deletion of asset with ports [ID 45786]

When an asset with ports was deleted, it could occur that the port references were not deleted even though they should have been.

#### Asset Manager: Incorrect filtering in asset selection dialog [ID 45787]

In the asset selection dialog, it could occur that the available assets were not correctly filtered.

#### Various fixes [ID 45789]

Several issues in the InfraOps low-code apps have been fixed:

- The Create Reservation dialog no longer worked correctly, preventing users from creating reservations.
- The GQI Get Assets data source did not return results correctly.
- Navigation links between app pages did not work correctly.

#### Asset Manager: Bulk duplication did not copy all information correctly [ID 45792]

When assets were duplicated in bulk, it could occur that holder assignments and destination location data were not correctly copied to the duplicates. This issue has been resolved, and the duplicate detection logic for assets with identical names has also been improved.
