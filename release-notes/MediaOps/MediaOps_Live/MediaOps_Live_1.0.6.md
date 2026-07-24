---
uid: MediaOps_Live_1.0.6
---

# MediaOps Live 1.0.6 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Changes

### Fixes

#### Discrete parameters with numeric values caused orchestration events to fail [ID 45773]

When discrete parameters were used with numeric values (e.g., to indicate video formats), it could occur that orchestration events failed. Now the validation correctly supports both numeric and string discrete parameters.
