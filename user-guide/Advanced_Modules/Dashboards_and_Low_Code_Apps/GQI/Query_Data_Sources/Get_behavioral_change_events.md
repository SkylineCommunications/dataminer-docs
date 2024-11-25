---
uid: Get_behavioral_change_events
---

# Get behavioral change events

Available from DataMiner 10.3.3/10.4.0 onwards.<!-- RN 35027 --> The *Get behavioral change events* data source retrieves all behavioral change points detected in the DataMiner System. These events are detected in your trend data by [DataMiner Behavioral Anomaly Detection](xref:Working_with_behavioral_anomaly_detection).

By default, the data contains the following columns:

- **Parameter ID**: The ID of the parameter for which the change point was detected.
- **Anomalous**: Whether the change point was marked as an anomaly.
- **Change type**: The type of change point that was detected.
- **Increase**: Whether the detected change point represents an increase (e.g. a level shift up) or a decrease (e.g. a level shift down).
- **Start time**: The detected start time of the change point.
- **End time**: The detected end time of the change point.

The following columns are also available after a [Select](xref:GQI_Select) operation:

- **Element ID**: The ID of the element for which the change point was detected.
- **Change Point ID**: The ID of the change point.
- **Start value**: The parameter value at the start of the change point for level shifts and outliers, or the slope or variance at the start of the change point for trend changes or variance changes, respectively.
- **End value**: The parameter value at the end of the change point for level shifts and outliers, or the slope or variance at the end of the change point for trend changes or variance changes, respectively.
- **Significance**: A number indicating how significant the change point is compared to previously detected change points.
- **Severity**: A number indicating the severity of the change point compared to past trend data.
- **Creation time**: The time when the change point was first detected.
- **Last update**: The time when the change point was last updated.

When one or more table rows are selected, the following component data is available in the *Components* or *Feeds* section (depending on your DataMiner version<!--RN 41141-->) of the *Data* pane:

- **Parameters**: The parameters for which the selected change points were detected.
- **Timespans**: The time ranges from the start time to the end time of the selected change points.
- **Elements**: The elements for which the selected change points were detected.
- **Indices**: The primary key of the table rows for which the selected change points were detected, if any.
