---
uid: Advanced_analytics_features_in_the_Alarm_Console
keywords: alarm focus, AI
---

# Advanced analytics features in the Alarm Console

A number of features in the Alarm Console make use of the artificial intelligence capabilities provided by DataMiner Analytics. These features are only available on systems using [Storage as a Service](xref:STaaS) (recommended) or using a self-managed Cassandra-compatible database. For systems with self-managed DataMiner storage, pattern matching is only available if this includes an [indexing database](xref:Indexing_Database).

All features can be activated or deactivated in System Center, via *System Center* > *System settings* > *analytics config*.

The following advanced analytics features **assist at identifying incidents in the alarm data**:

- [Alarm focus](xref:Alarm_focus).

- [Automatic alarm grouping](xref:Automatic_alarm_grouping).

The following advanced analytics features generate [suggestion events](xref:Alarm_types#suggestion-events) that inform users about new insights into the data behavior of a trended parameter:

- [Behavioral anomaly detection](xref:Behavioral_anomaly_detection).

- [Proactive cap detection](xref:Proactive_cap_detection).

- [Pattern matching](xref:Monitoring_of_trend_patterns).

- [Relational anomaly detection](xref:Relational_anomaly_detection) (from DataMiner 10.5.3/10.6.0 onwards).

Note that from DataMiner 10.5.4/10.6.0 onwards, deactivating one of these features in System Center will also remove all corresponding alarms or suggestion events from the Alarm Console.<!-- RN 42096 -->
