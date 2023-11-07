---
uid: Configuring_anomaly_detection_alarms
---

# Configuring anomaly detection alarms for specific parameters

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. If you enable this, an alarm is generated whenever an anomaly of the relevant type is detected for those parameters.

> [!NOTE]
> Suggestion events are cleared two hours after their creation time or their last update time. You can view them by creating a suggestion event tab in the Alarm Console. See [Adding and removing alarm tabs in the Alarm Console](xref:ChangingTheAlarmConsoleLayout#adding-and-removing-alarm-tabs-in-the-alarm-console).

## [From DataMiner 10.3.12/10.4.0 onwards](#tab/tabid-1)

To configure anomaly detection alarms for specific parameters<!--RN 37171 + 37148-->:

1. In the alarm template editor, click the button in the *Anomalies* column for the parameter in question. By default, this is set to *Disabled*.

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
        > For example, if you select *Slope increases* but not *Slope decreases*, an alarm will be generated when an anomalous slope increase is detected, but a suggestion event will be generated if an anomalous slope decrease is detected. It is not possible to generate both an alarm and a suggestion event for the same type of anomaly detection.

     1. Optionally, for anomaly detection of type *Level shift* or *Outlier*, set custom alarm thresholds that determine when an alarm should occur.

        By default, *Smart* is selected in the dropdown menu, which means alarm thresholds are automatically set based on what DataMiner Analytics determines to be an anomaly. To set your own custom alarm thresholds, select one of the following options instead:

        - **Relative**: Allows you to set the alarm thresholds as a percentage, which represents the delta with the baseline value.

          For example, if you input "30" for the *Major* alarm severity in the case of *Outlier > Upward spikes*, a 50% upward spike will trigger a *Major* alarm as it surpasses the predefined 30%. A 20% spike, such as 100 to 120, will not trigger any alarms, since it is below the set 30%.

        - **Absolute**: Allows you to set the alarm thresholds as an absolute value, which represents the delta with the baseline value.

          For example, if you input "40" for the *Major* alarm severity in the case of *Outlier > Upward spikes*, a parameter jump from 100 to 150 will trigger a *Major* alarm as it surpasses the predefined 40. A jump from 100 to 130, however, will not trigger any alarms, since it is below the set 40.

        ![Alarm thresholds](~/user-guide/images/Anomaly_Alarm_Settings.png)<br/>*Anomaly alarm settings in DataMiner 10.3.12*

        > [!NOTE]
        > Any customized behavioral anomaly monitoring setup containing relative or absolute thresholds will be lost if you downgrade to DataMiner version 10.3.11 or older. These versions do not support this extended anomaly configuration, and the thresholds will be automatically determined by DataMiner Analytics, similar to the default *Smart* option<!--RN 37434-->.

1. Click *Close* in the lower right corner to exit the *Anomaly Alarm Settings* pop-up window.

   In the alarm template editor, depending on your changes, the button in the *Anomalies* column will now indicate the level of anomaly monitoring that has been configured:

   - **Disabled**: No anomaly alarms are generated for this parameter.

   - **Customized**: You have customized the anomaly alarm settings for this parameter.

   - **Smart**: Anomaly alarms are generated for this parameter based on what DataMiner Analytics determines to be an anomaly.

1. To save your changes, click *OK* or *Apply* in the lower right corner of the alarm template editor.

## [DataMiner versions using automatic client updates, prior to DataMiner 10.3.12/10.4.0](#tab/tabid-2)

To configure anomaly detection alarms for specific parameters<!--RN 37171 + 37148-->:

1. In the alarm template editor, click the button in the *Anomalies* column for the parameter in question. By default, this is set to *Disabled*.

1. In the *Anomaly Alarm Settings* pop-up window, you can select one of the preset options or configure the anomaly alarm settings according to your preference.

   > [!NOTE]
   > The configured anomaly alarm settings only take effect for trended parameters<!--RN 37670-->.

   - To choose one of the preset options, click the *Select preset* selection box in the top-left corner:

     - **All disabled**: No anomaly alarms are generated.

     - **All smart**: Anomaly alarms are generated based on what DataMiner Analytics determines to be an anomaly.

   - To customize the anomaly alarm settings, click the toggle buttons next to the specific types of anomaly detection:

     - *Level shift*: Enables or disables alarms for level shift anomalies.

     - *Trend change*: Enables or disables alarms for trend changes.

     - *Variance change*: Enables or disables alarms for variance changes.

     - *Flatline*: Enables or disables alarms for flatline anomalies. Available from DataMiner 10.2.6/10.3.0 onwards.

1. Click *Close* in the lower right corner to exit the *Anomaly Alarm Settings* pop-up window.

   In the alarm template editor, depending on your changes, the button in the *Anomalies* column will now indicate the level of anomaly monitoring that has been configured:

   - **Disabled**: No anomaly alarms are generated for this parameter.

   - **Customized**: You have customized the anomaly alarm settings for this parameter.

   - **Smart**: Anomaly alarms are generated for this parameter based on what DataMiner Analytics determines to be an anomaly.

1. To save your changes, click *OK* or *Apply* in the lower right corner of the alarm template editor.

## [Prior to DataMiner 10.3.12/10.4.0](#tab/tabid-3)

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
