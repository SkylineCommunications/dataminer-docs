---
uid: RAD_Manager_2.0.3
---

# RAD Manager 2.0.3

## Changes

### Enhancements

#### Improvements to the caching mechanism for anomaly scores

Various improvements have been made to the caching mechanism of the *Get Relational Anomaly Score* ad hoc data source. As a result, after you zoom in and out on the parameter trend graph, the anomaly score graph below it will be updated more quickly.

#### Added time range picker for trend graph [ID 42838]

A time range picker has been added above the parameter trend graph, allowing the user to show more than one week of trend data on the trend graph.

### Fixes

#### Anomaly score graph time range not aligned with trend graph time range [ID 42838]

If anomaly scores were not available in the beginning or the end of the time range shown in the trend graph, up to now, the time range of the anomaly score graph below it could be smaller than that of the trend graph. Now the time range of the two graphs will always be aligned.
