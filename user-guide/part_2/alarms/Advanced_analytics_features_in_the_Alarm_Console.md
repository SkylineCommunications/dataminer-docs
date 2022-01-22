---
uid: Advanced_analytics_features_in_the_Alarm_Console
---

## Advanced analytics features in the Alarm Console

A number of features in the Alarm Console make use of the artificial intelligence capabilities provided by DataMiner Analytics. These features are only available on systems with a Cassandra database. They can each be activated or deactivated in System Center, via *System Center \> System settings* > *analytics config*.

These features are:

- Alarm focus (available from DataMiner 10.0.0/10.0.2 onwards). See [Filtering alarms on alarm focus](Working_with_the_Alarm_Console.md#filtering-alarms-on-alarm-focus).

- Behavioral anomaly detection (available from DataMiner 10.0.0/10.0.2 onwards). See [Behavioral anomaly detection](#behavioral-anomaly-detection).

- Proactive cap detection (available from DataMiner 10.1.0/10.0.11 onwards). See [Proactive cap detection](#proactive-cap-detection).

- Automatic incident tracking (available from DataMiner 10.1.0/10.0.11 onwards). See [Automatic incident tracking](#automatic-incident-tracking).

- Pattern matching (supports alarm monitoring from DataMiner 10.1.0/10.0.13 onwards). See [Monitoring of trend patterns](#monitoring-of-trend-patterns).

### Behavioral anomaly detection

For more information on the functionality of this feature in general, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).

Whenever behavioral anomaly detection finds an anomalous level shift, trend change or variance change for a parameter, a "suggestion event" is generated in the Alarm Console. These suggestion events can be viewed in a dedicated suggestion events tab, as alarms with severity "Information" and source "Suggestion Engine”. See [Adding and removing alarm tabs in the Alarm Console](Working_with_the_Alarm_Console.md#adding-and-removing-alarm-tabs-in-the-alarm-console). You can also configure alarm templates to have alarms generated instead of suggestion events, depending on the parameter and the type of anomaly. See [Configuring anomaly detection alarms for specific parameters](xref:Configuring_alarm_templates#configuring-anomaly-detection-alarms-for-specific-parameters).

Please note the following regarding suggestion events:

- Currently, no suggestion events are generated for outliers and unlabeled change points.

- Suggestion events generated to indicate a behavioral anomaly are automatically cleared 2 hours after their creation time or their last update time.

### Proactive cap detection

This DataMiner Analytics feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc. However, note that some events simply cannot be predicted. For example, a spike in a trend graph caused by randomly pulling out a cable can never be predicted by looking at historical trend data, so proactive cap detection will not know about this in advance.

#### Specifications

For the best results, both real-time and average trending should be activated on a parameter for which you want proactive cap detection to be available. To calculate its predictions, DataMiner Analytics will make use of the available real-time data, 5-minute average data, 1-hour average data and daily average data. It can predict at most 200 data points into the future. This is further limited by the available data: if there is a data set of a specific number of points, DataMiner Analytics can never predict further than that number of points divided by ten. For example, if the database contains one year of hourly averages and no daily averages, then DataMiner Analytics computes 365 daily averages and is able to predict issues 36 days into the future.

This feature is currently only available for trended parameters with numeric values, and not for partial table parameters. Because of memory constraints, proactive cap detection is also only possible for up to 100 000 parameters per DMA. If there are more parameters for which proactive cap detection would be possible, no predictions will be available for these and the Analytics log file will mention that the number of tracked parameters exceeded the maximum.

In addition, proactive cap detection is currently only supported for parameters for which there are explicitly specified value bounds. It will predict when a parameter will cross one of these bounds:

- A high and/or low data range value specified in the protocol, or,

- A (by default) critical alarm limit of type normal (i.e. not rate or baseline) specified in the alarm template, or,

- A data range indirectly derived from the protocol info. Currently this is limited to the values 0 and 100 for percentage data for which no historical values were encountered outside the \[0,100\] interval.

However, note that in case there is both a data range in the protocol and an alarm threshold in an alarm template, the alarm template will get precedence.

#### Configuration in System Center

In DataMiner Cube, you can enable this feature in System Center, via *System settings* > *analytics config* > *proactive cap detection*. The following settings are available there:

- *Enabled*: Allows you to activate or deactivate this feature.

- *Minimum alarm severity*: Allows you to configure the lowest alarm threshold severity that will be taken into account for proactive cap detection. If this is for example set to *Major*, proactive cap detection will alert the operator whenever a parameter is predicted to go out of range or is predicted to trigger a major or critical alarm.

#### Suggestion events

The notifications generated by the proactive cap detection feature are displayed in the suggestion events tab of the Alarm Console, along with the notifications for behavioral anomaly detection (see [Adding and removing alarm tabs in the Alarm Console](Working_with_the_Alarm_Console.md#adding-and-removing-alarm-tabs-in-the-alarm-console)) and pattern matching (see [Monitoring of trend patterns](#monitoring-of-trend-patterns)). These are alarms with severity "Information" and source "Suggestion Engine”.

The value of the suggestion event mentions what kind of issue is expected, e.g. a critical high or low alarm or an above or below range violation. The value also mentions between which times the issue is expected to occur. The closer to the predicted time, the more accurate this prediction will be, so the suggestion event will be automatically updated with more accurate information when appropriate. As soon as the predicted time of the incident has passed, the suggestion event will be cleared.

### Automatic incident tracking

This DataMiner Analytics feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. Unlike Correlation tracking, this happens completely automatically, without any configuration by the user. Based on what it has learned from past alarm activity in your system and based on a broad range of auxiliary data, DataMiner Analytics automatically detects which alarms share a common trait and groups them as one incident.

To activate this feature, in the Alarm Console hamburger menu, select *Automatic incident tracking*. However, note that the feature must also be activated in System Center. See [Configuration in System Center](#configuration-in-system-center). From DataMiner 10.2.0/10.2.1 onwards, it is enabled by default in new installations and in systems upgrading from DataMiner versions that did not support automatic incident tracking yet.

Several factors are taken into account for the grouping:

- The polling IP (for timeout alarms only)

- Service information

- The IDP location (only in case the IDP Solution is deployed)

- Element information

- Parameter information

- Time

- Alarm focus information

- Alarm, element, service or view properties, if these have been configured for incident tracking (see [Configuration of incident tracking based on properties](#configuration-of-incident-tracking-based-on-properties)).

If no suitable match is found, alarms will not be grouped. Also, since only alarms with a focus score are taken into account, automatic incident tracking does not apply to information events, suggestion events or notice messages.

The grouping of alarms into incidents is updated in real time whenever appropriate:

- New alarms are added to existing groups if they match.

- A group is cleared if its base alarms are cleared or if the reason for its original creation comes to an end.

- If a group is cleared, any alarms in the group that are still active may be regrouped if other matching alarms exist, either in a new group or in an existing one.

In the Alarm Console, alarm groups are displayed as a special kind of alarm entries:

- The icon of an alarm group is similar to that of a correlated alarm.

- The alarm color of an alarm group entry reflects the highest severity of the alarms within the group, but the severity of the group itself is *Suggestion*.

- The parameter description of the entry is *Alarm Group*.

- The value of the entry is the reason why the alarms are grouped. If there is no single obvious reason, the value will be Group with multiple reasons.

- The root time of the group is the time when the most recent alarm in the group occurred, at the moment when the group was created.

- If alarms are added to a group or removed from a group, the alarm type will be updated from *New alarm* to *Base alarms changed*.

- You can expand the group to view all alarms within it.

- If all alarm entries within an alarm group are masked, the group is automatically masked as well. However, as soon as one of the entries is unmasked, the group is also unmasked.

> [!NOTE]
> - Using automatic incident tracking with history sets is supported; however, keep in mind that this may trigger the creation and immediate clearing of a large number of alarm groups.
> - When an element is stopped or paused, the alarms associated with that element will not be taken into account when grouping alarms. Also, alarms associated with elements that are stopped or paused will be removed from any existing alarm group.

#### Configuration in System Center

In DataMiner Cube, you can enable this feature in System Center, via *System settings* > *analytics config* > *automatic incident tracking*. The following settings are available there:

- *Enabled*: Allows you to activate or deactivate this feature. Note that when you upgrade to DataMiner 10.0.11, the feature is automatically disabled, unless it has previously been activated as a soft-launch feature.

- *Leader DataMiner ID*: The DMA performing all incident tracking calculations. By default, this is the DMA with the lowest DataMiner ID at the time when alarm grouping is enabled.

- *Maximum group size*: Available from DataMiner 10.1.11/10.2.0 onwards. When an alarm group reaches the maximum size specified in this setting, a new group will be created with all remaining alarms that belong to the same incident. Default value: 1000.

- *Maximum time interval*: The maximum time interval between alarms that can be grouped as one incident. If the root times of alarms are further apart than the configured interval, the alarms will not be grouped.

- *Maximum group events rate*: Available from DataMiner 10.2.1/10.2.0 onwards. The maximum number of alarm group events that can be generated per second. This setting is used to avoid possible performance issues during alarm floods. If more events are generated per second than the specified number, the generation of events is slowed down, and a notice alarm is generated. As soon as the number of generated events drops below the threshold again, the notice alarm is cleared and events are again generated as quickly as possible. Default value: 100.

#### Configuration of incident tracking based on properties

From DataMiner 10.2.0/10.1.4 onwards, automatic incident tracking can also take into account alarm, element, service or view properties, if these have been configured as detailed below. Alarms are grouped as soon as they have the same value for one of the configured alarm, service or view properties, the same focus value and approximately the same timestamp. For element properties, alarms are grouped depending on a threshold that must be specified in the analytics configuration detailed below. Alarms for elements with the same property value will only be grouped if the proportion of elements in alarm among all elements with that property value is greater than the configured threshold.

The following basic configuration is needed in Cube:

- For the alarm properties that should be taken into account, the option *Update alarms on value changed* must be selected. See [Adding a custom alarm property](Changing_custom_alarm_properties.md#adding-a-custom-alarm-property).

- For the element, service and view properties that should be taken into account, the option *Make this property available for alarm filtering* must be selected. See [Adding a custom property to an item](xref:Managing_element_properties#adding-a-custom-property-to-an-item).

In addition, the following configuration is needed in the file *C:\\Skyline DataMiner\\analytics\\configuration.xml*:

- For each alarm, element, view or service property that should be taken into account for incident tracking, add an \<item> tag within the \<Value> tag in the following section of *configuration.xml* file.

    ```xml
    <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::vector&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt;,class std::allocator&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt; &gt; &gt; &gt;">
      <Value>
        [One <item> tag per property that has to be taken into account. See below.]
      </Value>
      <Accessibility>2</Accessibility>
      <Name>GenericProperties</Name>
    </item>
    ```

- For an **element property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the element property and \[THRESHOLD\] with the desired threshold. Alarms for elements with the same property value will only be grouped if the proportion of elements in alarm among all elements with that property value is greater than this threshold.

    ```xml
    <item type="skyline::dataminer::analytics::workers::configuration::GenericElementPropertyVisitorConfiguration">
      <enable>true</enable>
      <threshold>[THRESHOLD]</threshold>
      <name>[PROPERTY_NAME]</name>
    </item>
    ```



- For an **alarm property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the alarm property.

    ```xml
    <item type="skyline::dataminer::analytics::workers::configuration::GenericAlarmPropertyVisitorConfiguration">
      <enable>true</enable>
      <name>[PROPERTY_NAME]</name>
    </item>
    ```

- For a **view property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the view property.

    ```xml
    <item type="skyline::dataminer::analytics::workers::configuration::GenericViewPropertyVisitorConfiguration">
      <enable>true</enable>
      <name>[PROPERTY_NAME]</name>
    </item>
    ```

- For a **service property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the service property.

    ```xml
    <item type="skyline::dataminer::analytics::workers::configuration::GenericServicePropertyVisitorConfiguration">
      <enable>true</enable>
      <name>[PROPERTY_NAME]</name>
    </item>
    ```

- After you have edited the configuration file, **restart the SLAnalytics process** to make sure your changes take effect.

### Monitoring of trend patterns

From DataMiner 10.0.7 onwards, DataMiner can recognize patterns in trend graphs. From DataMiner 10.0.13 onwards, you can also activate alarm monitoring of trend patterns, so that a "suggestion event" type alarm is triggered whenever a specific pattern is detected (see [Suggestion events](#suggestion-events) ).

You can activate this type of monitoring by selecting a pattern in a trend graph, creating a tag for it, and activating the option *Generate an alarm when detected.* For more detailed information on how to do this, see [Working with pattern matching](xref:Working_with_pattern_matching).

The following limitations apply:

- If you tag a pattern for a parameter of which the polling time is specified in the protocol, the pattern must have less than 5000 real-time points. If the polling time is not specified in the protocol, the pattern must be shorter than 24 hours. When you select a longer pattern, alarm monitoring will not be available.

- For the monitoring of trend patterns, DataMiner will use a maximum of 2 GB of internal memory.

    - As soon as DataMiner uses more than 1.5 GB of internal memory for this feature, the following notice will be displayed in the Alarm Console:

        *Pattern matching memory high, adding more patterns or parameters might reduce matching accuracy.*

        This notice will appear at most every 2 weeks or after a DataMiner restart.
        In order to reduce memory usage, you can either remove patterns for which monitoring has been activated or restrict the number of parameters for which it has been activated (e.g. by specifying a display key in case of table parameters).

    - As soon as DataMiner uses more than 2 GB of internal memory for this feature, the following notice will be displayed in the Alarm Console:

        *Pattern matching memory critical, patterns with suggestion events enabled may not match properly.*

        This notice will appear at most every 2 weeks or after a DataMiner restart.
        Also, when you create a pattern in this case, DataMiner will not activate monitoring, even if you selected the *Generate an alarm when detected* option.

    - DataMiner checks all changes made to parameters for which patterns are being monitored in real time. If there are more than 6000 parameter changes per second, the following notice will be displayed in the Alarm Console:

        *High load on pattern matching functionality: reduced pattern match accuracy.*
