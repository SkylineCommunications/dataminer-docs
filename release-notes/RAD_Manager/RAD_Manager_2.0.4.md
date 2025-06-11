---
uid: RAD_Manager_2.0.4
---

# RAD Manager 2.0.4

## Changes

### Enhancements

#### Select production version for connector by default [ID 42898]

When adding a group for each element with a given connector, by default the 'Production' version of the connector is selected now, instead of the version that appears first in alphabetical order.

### Bug fixes

#### Reload anomaly score graph after retraining a parameter group [ID 42903]

​After retraining a RAD parameter group, the anomaly score graph would not be correctly reloaded in some cases, due to a caching mechanism in the background. The graph will now always be correctly reloaded after retraining.
