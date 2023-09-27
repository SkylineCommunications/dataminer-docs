---
uid: Monitoring_of_trend_patterns
---

# Monitoring of trend patterns

From DataMiner 10.0.7 onwards, DataMiner can recognize patterns in trend graphs. From DataMiner 10.0.13 onwards, you can also activate alarm monitoring of trend patterns, so that a "suggestion event" type alarm is triggered whenever a specific pattern is detected (see [Suggestion events](xref:Proactive_cap_detection#suggestion-events)).

You can activate this type of monitoring by selecting a pattern in a trend graph, creating a tag for it, and activating the option *Continuously detect patterns in the background* (or *Generate an alarm when detected* in DataMiner versions prior to 10.3.6/10.4.0<!-- RN 36114 -->). For more detailed information on how to do this, see [Defining a pattern](xref:Defining_a_pattern).

The following limitations apply:

- If you tag a pattern for a parameter of which the polling time is specified in the protocol, the pattern must have less than 5000 real-time points. If the polling time is not specified in the protocol, the pattern must be shorter than 24 hours. When you select a longer pattern, alarm monitoring will not be available.

- For the monitoring of trend patterns, DataMiner will use a maximum of 2 GB of internal memory.

  - As soon as DataMiner uses more than 1.5 GB of internal memory for this feature, the following notice will be displayed in the Alarm Console:

    *Pattern matching memory high, adding more patterns or parameters might reduce matching accuracy.*

    This notice will appear at most every 2 weeks or after a DataMiner restart. In order to reduce memory usage, you can either remove patterns for which monitoring has been activated or restrict the number of parameters for which it has been activated (e.g. by specifying a display key in case of table parameters).

  - As soon as DataMiner uses more than 2 GB of internal memory for this feature, the following notice will be displayed in the Alarm Console:

    *Pattern matching memory critical, patterns with suggestion events enabled may not match properly.*

    This notice will appear at most every 2 weeks or after a DataMiner restart. Also, when you create a pattern in this case, DataMiner will not activate monitoring, even if you selected the option *Generate an alarm when detected*.

  - DataMiner checks all changes made to parameters for which patterns are being monitored in real time. If there are more than 6000 parameter changes per second, the following notice will be displayed in the Alarm Console:

    *High load on pattern matching functionality: reduced pattern match accuracy.*
