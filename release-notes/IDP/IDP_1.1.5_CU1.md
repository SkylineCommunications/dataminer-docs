---
uid: IDP_1.1.5_CU1
---

# IDP 1.1.5 CU1

## Fixes

#### Devices discovered despite disabled CI types \[ID 24905\]

When all CI types were disabled, it could occur that devices were discovered nevertheless.

#### Update Property script not executed for every element provisioned at the same time \[ID 25063\]

If multiple elements were provisioned at the same time, it could occur that the Update Property script was not executed for all of the elements.
