---
uid: RAD_Manager_2.0.3
---

# RAD Manager 2.0.3

## Changes

### Enhancements

#### Improvements to the caching mechanism for anomaly scores

Various improvements have been made to the caching mechanism of the *Get Relational Anomaly Score* ad-hoc data source. As a result, the update to the anomaly score graph after zooming in and out on the parameter trend graph above it, will be faster.

#### Added time range picker for trend graph [ID 42838]

A time range picker has been added above the parameter trend graph, allowing the user to show more than one week of trend data on the trend graph.

### Bug fixes

#### Always show full time range on anomaly score graph [ID 42838]

The time range shown on the anomaly score graph is now always aligned with the time range shown on the parameter trend graph above it. Before, it would show a smaller time range if anomaly scores were not available in the beginning or the end of the time range.
