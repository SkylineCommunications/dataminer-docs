---
uid: InfraOps_1.1.0_CU1
---

# InfraOps 1.1.0 CU1

## Fixes

#### Rack position validation not working correctly with non-rack-consuming assets [ID 45794]

When non-rack-consuming assets (e.g., patch panels) were assigned to racks, false conflicts could occur. To prevent this, the rack position validation has been adjusted to only apply to assets with the *RackUnitConsumer* device type.
