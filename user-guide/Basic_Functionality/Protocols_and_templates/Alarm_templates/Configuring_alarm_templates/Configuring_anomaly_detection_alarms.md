---
uid: Configuring_anomaly_detection_alarms
---

# Configuring anomaly detection alarms for specific parameters

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. If you enable this, an alarm is generated whenever an anomaly of the relevant type is detected for those parameters. From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards<!--RN 37171-->, you can choose whether an alarm or a suggestion event is generated for a specific type of anomaly detection, e.g. have suggestions appear for downward level shifts while alarms occur for upward level shifts.

> [!NOTE]
> Suggestion events are cleared two hours after their creation time or their last update time. You can view them by creating a suggestion event tab in the Alarm Console. See [Adding and removing alarm tabs in the Alarm Console](xref:ChangingTheAlarmConsoleLayout#adding-and-removing-alarm-tabs-in-the-alarm-console).

## [From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards](#tab/tabid-1)

To configure anomaly detection alarms for specific parameters<!--RN 37171 + 37148-->:

1. In the alarm template editor, click the *Anomalies* button for the parameter in question. By default, this is set to *Disabled*.

1. In the *Anomaly Alarm Settings* pop-up window, you can select one of the preset options or configure the anomaly alarm settings according to your preference.

   > [!NOTE]
   > The configured anomaly alarm settings only take effect for trended parameters<!--RN 37670-->.

   - To choose one of the preset options, click the *Select preset* selection box in the top-left corner:

     - **All disabled**: No anomaly alarms are generated.

     - **All smart**: Anomaly alarms are generated based on what DataMiner Analytics determines to be an anomaly.

   - To customize the anomaly alarm settings:

     1. Configure alarms for specific types of anomaly detection:

        - *Level shift > Level increases*: Enables or disables alarms for level increase anomalies.

        - *Level shift > Level decreases*: Enables or disables alarms for level decrease anomalies.

        - *Outlier > Upward spikes*: Enables or disables alarms for upward spikes.

        - *Outlier > Downward spikes*: Enables or disables alarms for downward spikes.

        - *Variance change > Variance increases*: Enables or disables alarms for variance increases.

        - *Variance change > Variance decreases*: Enables or disables alarms for variance decreases.

        - *Trend change > Slope increases*: Enables or disables alarms for slope increases.

        - *Trend change > Slope decreases*: Enables or disables alarms for slope decreases.

        - *Flatline > Detect flatlines*: Enables or disables alarms for flatline anomalies.

        > [!NOTE]
        > If you, for example, select the checkbox next to *Slope increases* but clear the checkbox next to *Slope decreases*, an alarm will be generated when an anomalous slope increase is detected but a suggestion event will be generated if an anomalous slope decrease is detected. It is not possible to generate both an alarm and a suggestion event for the same type of anomaly detection.

     1. For anomaly detection of types *Level shift* and *Outlier*, specify when an alarm should occur.

        - **Smart**: Alarm thresholds are set based on what DataMiner Analytics determines to be an anomaly. This is the default option.

        - **Relative**: Alarm thresholds are set as a percentage, which represents the delta with the baseline value.

        - **Absolute**: Alarm thresholds are set as an absolute value, which represents the delta with the baseline value.

1. Click *Close* in the lower right corner to exit the *Anomaly Alarm Settings* pop-up window.

   In the alarm template editor, depending on your changes, the *Anomalies* button will now indicate the level of anomaly monitoring that has been configured:

   - **Disabled**: No anomaly alarms are generated for this parameter.

   - **Customized**: You have customized the anomaly alarm settings for this parameter.

   - **Smart**: Anomaly alarms are generated for this parameter based on what DataMiner Analytics determines to be an anomaly.

1. To save your changes, click *OK* or *Apply* in the lower right corner of the alarm template editor.

## [Prior to DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12](#tab/tabid-2)

To enable or disable different types of anomaly alarm monitoring:

1. Click the cogwheel button in the top-right corner of the alarm template editor.

1. Select the option *Advanced configuration of anomaly detection*. Several extra columns will be displayed in the template editor.

1. Click the toggle buttons in these columns to configure alarms for specific types of anomaly detection:

   - *Trend monitor*: Enables or disables alarms for trend changes.

   - *Variance monitor*: Enables or disables alarms for variance changes.

   - *Level shift*: Enables or disables alarms for level shift anomalies.

   - *Flatline monitor*: Enables or disables alarms for flatline anomalies. Available from DataMiner 10.2.6/10.3.0 onwards.

***
<br/>

> [!NOTE]
> The way DataMiner Analytics determines whether something is an anomaly is different depending on the DataMiner version:
>
> - From DataMiner 10.2.11/10.3.0 onwards, a behavioral change in the trend data of a parameter is only considered an anomaly if there have not been similar behavioral changes that occurred regularly or frequently in the historical behavior of the parameter.
> - From DataMiner 10.2.6 onwards, when you enable alarm monitoring for a specific type of anomaly, behavioral changes of a specific type on a trended parameter will always be considered to be behavioral anomalies if anomaly monitoring is enabled on this type and parameter, even if the behavioral change point is not significantly different from other behavioral changes in the recent history of the trended parameter.
> - Prior to DataMiner 10.2.6/10.3.0, a behavioral change in the trend data of a parameter is only considered an anomaly if it is sufficiently significant with respect to other behavioral changes in the recent history of the parameter.

> [!TIP]
> For more information on behavioral anomaly detection, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).
