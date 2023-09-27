---
uid: Behavioral_anomaly_detection
---

# Behavioral anomaly detection

> [!TIP]
> This section contains information about behavioral anomaly detection in the Alarm Console. For more information on the functionality of this feature in general, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).

Whenever behavioral anomaly detection finds an anomalous level shift, trend change, or variance change for a parameter, a "suggestion event" is generated in the Alarm Console.

These suggestion events can be viewed in a dedicated suggestion events tab, as alarms with severity "Information" and source "Suggestion Engine”. See [Adding and removing alarm tabs in the Alarm Console](xref:ChangingTheAlarmConsoleLayout#adding-and-removing-alarm-tabs-in-the-alarm-console).

You can also configure alarm templates to have alarms generated instead of suggestion events, depending on the parameter and the type of anomaly. See [Configuring anomaly detection alarms for specific parameters](xref:Configuring_anomaly_detection_alarms).

Please note the following regarding suggestion events:

- Currently, no suggestion events are generated for outliers and unlabeled change points.

- Suggestion events generated to indicate a behavioral anomaly are automatically cleared 2 hours after their creation time or their last update time. From DataMiner 10.2.11/10.3.0 onwards, they are also cleared in case a new behavioral change is detected that ends the previous anomalous behavioral change. For example, when an alarm was created for an anomalous level increase at 1 PM, and a behavioral change point is detected at 2 PM when the level drops again, then the alarm created at 1 PM will be closed at 2 PM.

- Prior to DataMiner 10.2.11/10.3.0, suggestion events are created for all anomalous behavioral changes that do not have alarm monitoring enabled. From DataMiner 10.2.11/10.3.0 onwards, they are only created for the most significant changes. There is also a maximum of 500 suggestion events related to behavioral anomaly detection at the same time.
