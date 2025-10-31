---
uid: Monitoring_of_trend_patterns
---

# Monitoring of trend patterns

You can activate alarm monitoring of the patterns DataMiner detects in trend graphs, so that a "suggestion event" type alarm is triggered whenever a specific pattern is detected (see [Suggestion events](xref:Proactive_cap_detection#suggestion-events)).

You can activate this type of monitoring by selecting a pattern in a trend graph, creating a tag for it, and activating the option *Continuously detect patterns in the background* (or *Generate an alarm when detected* in DataMiner versions prior to 10.3.6/10.4.0<!-- RN 36114 -->). For more detailed information on how to do this, see [Defining a pattern](xref:Defining_a_pattern).

The following limitations apply:

- If you tag a pattern for a parameter of which the polling time is specified in the protocol, the pattern must have less than 5000 real-time points. If the polling time is not specified in the protocol, the pattern must be shorter than 24 hours. When you select a longer pattern, alarm monitoring will not be available.

- For the monitoring of trend patterns, DataMiner will use a maximum of 2 GB of internal memory.

  - As soon as DataMiner uses more than 1.5 GB of internal memory for this feature, the following notice will be displayed in the Alarm Console:

    *Pattern matching memory high, adding more patterns or parameters might reduce matching accuracy.*

    This notice will appear at most every 2 weeks or after a DataMiner restart. In order to reduce memory usage, you can either remove patterns for which monitoring has been activated or restrict the number of parameters for which it has been activated (e.g. by specifying a display key in case of table parameters).

  - As soon as DataMiner uses more than the maximum allowed internal memory for this feature, the following notice will be displayed in the Alarm Console:

    *Pattern matching memory critical, patterns with suggestion events enabled may not match properly.*

    This notice will appear at most every 2 weeks or after a DataMiner restart. Also, when you create a pattern in this case, DataMiner will not activate monitoring, even if you selected the option *Generate an alarm when detected*. The default maximum internal memory allocation is 2 GB. From DataMiner 10.3.1/10.4.0 onwards<!--RN 34803-->, the setting can be adjusted via *System Center* > *System settings* > *analytics config* > *Maximum memory usage*.

  - DataMiner checks all changes made to parameters for which patterns are being monitored in real time. If there are more than 6000 parameter changes per second, the following notice will be displayed in the Alarm Console:

    *High load on pattern matching functionality: reduced pattern match accuracy.*

Please note the following regarding suggestion events:

- Suggestion events triggered when a specific pattern is detected for [dynamic virtual elements](xref:Dynamic_virtual_elements) are generated on the child element. However, from DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 39707-->, suggestion events for [virtual functions](xref:srm_definitions#virtual-function) are generated on the parent element. Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9, these suggestion events are generated on the child element as well.

- From DataMiner 10.5.5/10.6.0 onwards<!--RN 42287-->, suggestion events for the same [multivariate pattern](xref:Working_with_pattern_matching#multivariate-patterns) are grouped together into a single incident in the Alarm Console. If [automatic updates are enabled](xref:DMA_configuration_related_to_client_applications#managing-client-versions), this grouping may already occur from DataMiner 10.5.4 onwards, depending on the selected [Cube update track](xref:Upgrading_Cube#selecting-your-cube-update-track)<!-- RN 42274 -->.
