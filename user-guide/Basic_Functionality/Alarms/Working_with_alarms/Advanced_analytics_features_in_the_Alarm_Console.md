---
uid: Advanced_analytics_features_in_the_Alarm_Console
keywords: alarm focus, AI
---

# Advanced analytics features in the Alarm Console

A number of features in the Alarm Console make use of the artificial intelligence capabilities provided by DataMiner Analytics. These features are only available on systems using [Storage as a Service](xref:STaaS) or using a self-hosted Cassandra-compatible database. For systems with self-hosted DataMiner storage, pattern matching is only available if this includes an [indexing database](xref:Indexing_Database).

All features can be activated or deactivated in System Center, via *System Center \> System settings* > *analytics config*.

The following advanced analytics features **assist at identifying incidents in the alarm data**:

- Alarm focus (available from DataMiner 10.0.0/10.0.2 onwards). See [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus).

- Automatic incident tracking (available from DataMiner 10.1.0/10.0.11 onwards). See [Automatic incident tracking](xref:Automatic_incident_tracking).

The following advanced analytics features **generate suggestion events** that inform users about new insights on the data behavior of a trended parameter. These suggestion events are displayed in the *Suggestion events* tab of the Alarm Console. See [Changing the alarm console layout](xref:ChangingTheAlarmConsoleLayout).

- Behavioral anomaly detection (available from DataMiner 10.0.0/10.0.2 onwards). See [Behavioral anomaly detection](xref:Behavioral_anomaly_detection).

- Proactive cap detection (available from DataMiner 10.1.0/10.0.11 onwards). See [Proactive cap detection](xref:Proactive_cap_detection).

- Pattern matching (supports alarm monitoring from DataMiner 10.1.0/10.0.13 onwards). See [Monitoring of trend patterns](xref:Monitoring_of_trend_patterns).
