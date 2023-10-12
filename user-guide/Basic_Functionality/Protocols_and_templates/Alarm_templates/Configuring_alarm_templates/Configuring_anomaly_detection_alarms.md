---
uid: Configuring_anomaly_detection_alarms
---

# Configuring anomaly detection alarms for specific parameters

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. If you enable this, an alarm is generated whenever an anomaly of the relevant type is detected for those parameters.

To enable or disable different types of anomaly alarm monitoring:

1. Click the cogwheel button in the top-right corner of the alarm template editor.

1. Select the option *Advanced configuration of anomaly detection*. Several extra columns will be displayed in the template editor.

1. Click the toggle buttons in these columns to configure alarms for specific types of anomaly detection:

   - *Trend monitor*: Enables or disables alarms for trend changes.

   - *Variance monitor*: Enables or disables alarms for variance changes.

   - *Level shift*: Enables or disables alarms for level shift anomalies.

   - *Flatline monitor*: Enables or disables alarms for flatline anomalies. Available from DataMiner 10.2.6/10.3.0 onwards.

> [!NOTE]
> The way DataMiner Analytics determines whether something is an anomaly is different depending on the DataMiner version:
>
> - From DataMiner 10.2.11/10.3.0 onwards, a behavioral change in the trend data of a parameter is only considered an anomaly if there have not been similar behavioral changes that occurred regularly or frequently in the historical behavior of the parameter.
> - From DataMiner 10.2.6 onwards, when you enable alarm monitoring for a specific type of anomaly, behavioral changes of a specific type on a trended parameter will always be considered to be behavioral anomalies if anomaly monitoring is enabled on this type and parameter, even if the behavioral change point is not significantly different from other behavioral changes in the recent history of the trended parameter.
> - Prior to DataMiner 10.2.6/10.3.0, a behavioral change in the trend data of a parameter is only considered an anomaly if it is sufficiently significant with respect to other behavioral changes in the recent history of the parameter.

> [!TIP]
> For more information on behavioral anomaly detection, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).
