---
uid: InfraOps_1.1.0
---

# InfraOps 1.1.0

## Changes

### Enhancements

#### Asset Manager: Location bubble-up through asset hierarchy [ID 45782]

When a child asset's location changes, the asset location is now automatically propagated up through the hierarchy, keeping the parent asset's location in sync.

#### Asset Manager: Port handling improvements [ID 45790]

The port data model for data ports and power ports has been improved. Port creation, editing, and connections now include improved validation and more consistent handling across import/export and interactive workflows.

#### Asset Manager: Pagination for large asset class lists [ID 45791]

The handling of large asset class lists has been improved by supporting pagination when assets are selected, preventing UI overload on systems with many asset classes.

### Fixes

#### Asset Manager: Asset class import without port types failed [ID 45781]

When an asset class was imported without port types, the import would fail. Now, the first available port type is selected by default instead.

#### Various small fixes across all InfraOps apps [ID 45783]

Various small fixes have been implemented to the low-code app panels and navigation across Asset Manager, Facility Manager, and Plan and Build.
