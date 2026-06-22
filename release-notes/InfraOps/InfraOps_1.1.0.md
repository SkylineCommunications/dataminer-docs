---
uid: InfraOps_1.1.0
---

# InfraOps 1.1.0

## Changes

### Enhancements

#### Asset Manager: Location bubble-up through asset hierarchy [ID 45782]

When a child asset's location changes, the asset location is now automatically propagated up through the hierarchy, keeping the parent asset's location in sync.

### Fixes

#### Asset Manager: Asset class import without port types failed [ID 45781]

When an asset class was imported without port types, the import would fail. Now, the first available port type is selected by default instead.

#### Various small fixes across all InfraOps apps [ID 45783]

Various small fixes have been implemented to the low-code app panels and navigation across Asset Manager, Facility Manager, and Plan and Build.
