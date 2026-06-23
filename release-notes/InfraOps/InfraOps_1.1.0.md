---
uid: InfraOps_1.1.0
---

# InfraOps 1.1.0

## Changes

### Enhancements

#### Asset Manager: Location bubble-up through asset hierarchy [ID 45782]

When a child asset's location changes, the asset location is now automatically propagated up through the hierarchy, keeping the parent asset's location in sync.

#### New favicons and web app manifest [ID 45789]

New favicons and a web app manifest have been added to the InfraOps apps for better browser tab identification.

#### Asset Manager: Port handling improvements [ID 45790]

The port data model for data ports and power ports has been improved. Port creation, editing, and connections now include improved validation and more consistent handling across import/export and interactive workflows.

#### Asset Manager: Pagination for large asset class lists [ID 45791]

The handling of large asset class lists has been improved by supporting pagination when assets are selected, preventing UI overload on systems with many asset classes.

### Fixes

#### Asset Manager: Asset class import without port types failed [ID 45781]

When an asset class was imported without port types, the import would fail. Now, the first available port type is selected by default instead.

#### Various small fixes across all InfraOps apps [ID 45783]

Various small fixes have been implemented to the low-code app panels and navigation across Asset Manager, Facility Manager, and Plan and Build.

#### Various fixes [ID 45789]

Several issues in the InfraOps low-code apps have been fixed:

- The Create Reservation dialog no longer worked correctly, preventing users from creating reservations.
- The GQI Get Assets data source did not return results correctly.
- Navigation links between app pages did not work correctly.
