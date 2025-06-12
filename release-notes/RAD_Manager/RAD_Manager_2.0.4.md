---
uid: RAD_Manager_2.0.4
---

# RAD Manager 2.0.4

## Changes

### Enhancements

#### Production version of connector now selected by default [ID 42898]

When a group is added for each element with a specific connector, by default the "Production" version of that connector is now selected, instead of the version that appears first in alphabetical order.

### Fixes

#### Anomaly score graph not reloaded correctly after retraining a parameter group [ID 42903]

​After a RAD parameter group was retrained, it could occur that the anomaly score graph was not reloaded correctly. This was caused by a caching mechanism in the background. The graph will now always be correctly reloaded after retraining.
