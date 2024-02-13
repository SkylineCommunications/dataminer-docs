---
uid: Get_behavioral_change_events
---

# Get behavioral change events

Available from DataMiner 10.3.3/10.4.0 onwards. The *Get behavioral change events* data source retrieves all behavioral change points detected in the DataMiner System. These events are detected on your trend data by *Behavioral Anomaly Detection*, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection). <!-- RN 35027 -->

By default, the data contains the following columns:

- **Parameter ID**: the ID of the parameter on which the change point was detected.
- **Anomalous**: whether the change point was marked as an anomaly.
- **Change type**: the type of change point that was detected.
- **Increase**: whether the detected change point represents an increase (e.g. a level shift up) or a decrease (e.g. a level shift down).
- **Start time**: the time at which the change began.
- **End time**: the time at which the change ended.

The following columns are also available after a *Select* operation:

- **Element ID**: the ID of the element on which the change point was detected.
- **Change Point ID**: the ID of the change point.
- **Start value**: the parameter value at the start of the change point.
- **End value**: the parameter value at the end of the change point.
- **Significance**: a number indicating how significant the change point is relative to the historically detected change points.
- **Severity**: a number indicating the severity of the change point relative to the historical trend data.
- **Creation time**: when the change point was first detected.
- **Last update**: when the change point was last updated.

When one or more table rows are selected, the following feeds are available in the *feeds* section of the data pane:

- **Parameters**: the parameters on which the selected the change points were detected.
- **Timespans**: the time ranges from the start time to the end time of the selected change points.
- **Elements**: the elements on which the selected change points were detected.
- **Indices**: the primary key of the table rows on which the selected change points were detected, if any.
