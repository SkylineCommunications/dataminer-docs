---
uid: Behavioral_anomaly_detection
---

# Behavioral anomaly detection

This section contains information about behavioral anomaly detection in the Alarm Console. For more information on the functionality of this feature in general, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).

Whenever behavioral anomaly detection finds an anomalous level shift, trend change, or variance change for a parameter, a "suggestion event" is generated in the Alarm Console. These suggestion events can be viewed in a dedicated suggestion events tab, as alarms with severity "Information" and source "Suggestion Engine”. See [Adding and removing alarm tabs in the Alarm Console](xref:ChangingTheAlarmConsoleLayout#adding-and-removing-alarm-tabs-in-the-alarm-console). You can also configure alarm templates to have alarms generated instead of suggestion events, depending on the parameter and the type of anomaly. See [Configuring anomaly detection alarms for specific parameters](xref:Configuring_alarm_templates#configuring-anomaly-detection-alarms-for-specific-parameters).

Please note the following regarding suggestion events:

- Currently, no suggestion events are generated for outliers and unlabeled change points.

- Suggestion events generated to indicate a behavioral anomaly are automatically cleared 2 hours after their creation time or their last update time.
