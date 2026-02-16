---
uid: Proactive_Cap_Detection_Tutorial
---

# Staying ahead of issues with proactive cap detection

In this tutorial, you will learn how to use DataMiner's [proactive cap detection](xref:Proactive_cap_detection) feature to be notified about potential upcoming issues. This feature uses [trend prediction](xref:Trend_prediction) to automatically analyze which parameters are at risk of exceeding critical thresholds in the near future, and will notify users about them.

By default, proactive cap detection is enabled for all trended parameters. Trending is activated by default for the parameters used in this tutorial. For more information about the technical limitations, see the [proactive cap detection](xref:Proactive_cap_detection) page.

Estimated duration: 30 minutes.

> [!NOTE]
> The content and screenshots for this tutorial were created in **DataMiner 10.5.1**.

> [!TIP]
> See also: [Kata #53: Stay ahead of issues with proactive cap detection](https://community.dataminer.services/courses/kata-53/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- DataMiner 10.5.1 or higher with [Storage as a Service (STaaS)](xref:STaaS) (recommended) or an [indexing database](xref:Supported_system_data_storage_architectures).

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Proactive cap detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Detect parameters that are about to hit upper and lower bounds](#step-2-detect-parameters-that-are-about-to-hit-upper-and-lower-bounds)
- [Step 3: Detect parameters that are about to hit alarm thresholds](#step-3-detect-parameters-that-are-about-to-hit-alarm-thresholds)
- [Step 4: Configure proactive cap detection in the alarm template](#step-4-configure-proactive-cap-detection-in-the-alarm-template)
- [Step 5: Final exercise](#step-5-final-exercise-optional)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/44542748-20d5-4d37-92bc-8d09dbd6984e>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create several DataMiner elements in your system that will be used throughout the rest of this tutorial. The elements will be located in the view *DataMiner Catalog* > *Augmented Operations* > *Proactive Cap Detection Tutorial*.

   ![Elements](~/dataminer/images/Proactive_Cap_Detection_Tutorial_Elements.png)

## Step 2: Detect parameters that are about to hit upper and lower bounds

In this step, you will learn what potential issues DataMiner's proactive cap detection can spot and how you can be notified about them before they become problematic. This step focuses on DataMiner's out-of-the-box capabilities. Later steps will cover how proactive cap detection leverages information in your alarm template and how you can configure it.

1. In DataMiner Cube, select the view *Content Management Servers* in the Surveyor.

   This view shows a simulation of three servers hosting a large website. Each server has a cache of frequently accessed content to serve the website efficiently and reliably. The trend graph in this view displays the evolution of cache sizes for the three servers.

   ![Cache utilization of three content management servers after failure](~/dataminer/images/Proactive_Cap_Detection_Tutorial_CMS_After_Failure.png)

1. Analyze the trend graph:

   - Server 1 (blue line): The cache utilization fluctuates periodically, often reaching high values, without ever reaching full capacity (100% utilization).

   - Server 2 (green line): The cache utilization is initially stable, but then begins growing rapidly over the course of two days, reaching 100%. This significantly affects server performance and website reliability.

   - Server 3 (purple line): The cache utilization remains low and fairly stable.

   Conclusion: Receiving a notification about server 2's growing cache size before it reached 100% would have allowed the issue to be fixed before it propagated.

1. Consider these common approaches and their limitations:

   - **Alarm templates**: In an alarm template, you can configure an alarm threshold for the parameters. However, since server 1 often reaches high cache utilization without causing issues, setting the threshold too low would generate many false alarms, while setting it higher would result in a notification only shortly before server 2's cache is full.

   - **Manual inspection of the parameters**: By manually inspecting the parameters, you could detect the changing behavior of server 2's cache utilization. However, this approach is time-consuming, and if you view the graph with an unfortunate window size, as shown in the picture below, you might overlook the problem.

     ![Cache utilization of three content management servers before failure](~/dataminer/images/Proactive_Cap_Detection_Tutorial_CMS_Before_Failure.png)

   - **Anomalies**: DataMiner's [behavioral anomaly detection](xref:Behavioral_anomaly_detection) identifies a trend change at the moment when server 2's cache utilization starts to increase, as shown below:

     ![Trend change detected on cache utilization of Proactive Tutorial - CMS 2](~/dataminer/images/Proactive_Cap_Detection_Tutorial_CMS_Server2_TrendChange.png)<br>*Proactive Cap Detection Tutorial > Content Management Servers > Proactive Tutorial - CMS 2 > Cache Utilization (after failure)*

     However, the light gray color used for the change point indicates it was not flagged as anomalous. This is because the algorithm lacked sufficient data before the trend change. Experiments show that, with more data, the anomaly would have been detected. For a hands-on introduction to anomaly detection in DataMiner, refer to the [anomaly detection tutorial](xref:Anomaly_Tutorial).

1. Navigate to *Content Management Servers* > *VISUAL* > *Before failure*.

   This tab displays the situation before the cache utilization of server 2 reached 100%. As mentioned earlier, when you look at the metrics in this window, it is not immediately clear that the blue line will decrease again, while the green line will continue to rise.

1. Scroll slightly to the right by clicking and dragging the trend graph, and take a look at the dashed lines on the right-hand side.

   ![Prediction of cache utilization of the three content management servers](~/dataminer/images/Proactive_Cap_Detection_Tutorial_CMS_Before_Failure_Prediction.png)

   These dashed lines represent DataMiner's predictions for the near future. Note that it correctly indicates that the blue line will not continue to rise, but that the green line will soon hit 100%, as indicated by the yellow triangle above the trend graph.

   This prediction is also used to notify users when parameters are about to hit the upper or lower limit of their range.

1. Click the light bulb icon in the top-right corner of the Alarm Console.

   This icon lights up blue to indicate that DataMiner Analytics has identified something interesting. For more detailed information, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).

1. Click the menu item *1 alarm is predicted in the near future* (this can also be a higher number if your system predicts alarms for other elements).

   A new *Predicted alarms* tab will now be shown in the Alarm Console, listing the predicted alarm for the server 2's cache utilization.

   ![Predicted alarm in the Alarm Console for the cache utilization of the second content management server](~/dataminer/images/Proactive_Cap_Detection_Tutorial_CMS_AlarmConsoleLightBulb.gif)

   This tab shows predicted alarms for metrics that are likely to hit the upper or lower limits of their range in the near future (along with certain alarm thresholds, discussed later in this tutorial).

   > [!NOTE]
   >
   > - These predicted alarms are not actual alarms, but suggestion events, and will not be shown in the *Active alarms* tab.
   > - You can also find predicted alarms using the *Suggestion events* tab. To access this, click the plus icon ("+") in the Alarm Console header, and select *Show current* > *Suggestion events*. This will open a tab with all suggestion events, including the predicted alarm above. However, this tab page can show more than just the predicted alarms. See [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console) for more information.
   >
   >
   > ![Suggestion events tab in the alarm console showing a predicted alarm](~/dataminer/images/Proactive_Cap_Detection_Tutorial_CMS_AlarmConsoleSuggestionEvents.gif)

## Step 3: Detect parameters that are about to hit alarm thresholds

In the previous step, you explored how proactive cap detection can identify issues out-of-the-box, without any configuration, by relying on a parameter's upper and lower range limits. In this step, you will see how proactive cap detection uses the alarm thresholds configured in the alarm template to improve its suggestions.

1. Navigate to the *DATA* > *General* page of the *Proactive Tutorial - SFP Monitor* element. This element simulates the *Optical RX Power* metric of an SFP (Small Form-Factor Pluggable), a device used together with network switches to connect fiber-optic or copper cables. For more details, see [this use case](https://community.dataminer.services/use-case/ai-assisted-sfp-monitoring/).

1. Click the trend icon ![the trend icon](~/dataminer/images/trend_icon_unknown.png) next to *Port 1*.

1. Click *Month to date* to see data for the past month.

   You will see that the power remained stable until around November 11th. At that point, it suddenly dropped and continued to gradually degrade. If the value of this parameter drops too low, it could lead to a connection failure. Therefore, you should configure a warning for scenarios like this.

   ![Optical RX Power of Port 1 over the past month](~/dataminer/images/Proactive_Cap_Detection_Tutorial_SFP_Trend_Graph.png)

   In the Alarm Console, you will see that no events for this parameter are shown in the *Suggestion events* and *Proactive alarms* tabs because the parameter does not have a lower limit. This can be resolved by setting alarm thresholds in an alarm template.

1. Right-click the element *Proactive Tutorial - SFP Monitor* in the Surveyor, and select *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.

1. Enter a name for the alarm template, e.g., *RX Monitoring*, and click *OK*.

1. Select the checkbox in the *MON* column for the parameter *SFPs: Optical RX Power*.

   This will enable alarm monitoring for this parameter.

1. Enter a threshold of -10 in the *CRIT LO* column.

1. Click *OK* to save the alarm template.

   The critical alarm threshold is now applied to the *Optical RX Power* parameter of the SFP monitor.

1. On the *DATA* > *General* page of the *Proactive Tutorial - SFP Monitor* element, click the *Generate Extra Data* button.

   This will generate additional data points for the *Optical RX Power* of *Port 1*, causing DataMiner to re-evaluate its predictions. This simulates waiting a few minutes for more data points to arrive.

   > [!IMPORTANT]
   > Throughout the rest of this tutorial, when generating data, always wait until the *Data Generated?* parameter displays *Yes* before proceeding to the next step.

1. Click the light bulb icon in the top-right corner of the Alarm Console and select *2 alarms are predicted in the near future* to access the *Predicted alarms* tab.

   You will now see a *Predicted Critical Low* event for *Optical RX Power Port 1*. DataMiner predicts that the parameter will cross the critical low threshold you just configured in the near future.

   The advantage of these predicted alarms is that they notify you in advance, allowing you to use less strict thresholds in your alarm template. This approach helps you avoid false positives while still receiving notifications when parameters are likely to cross a critical threshold soon.

   ![Predicted critical low alarm on Optical RX Power Port 1](~/dataminer/images/Proactive_Cap_Detection_Tutorial_SFP_PredictedAlarms.png)

   > [!NOTE]
   > Predicted alarms are not actual alarms, but suggestion events, and will not be shown in the *Active alarms* tab.

By default, predicted alarms are generated only for critical alarm thresholds (as well as the upper and lower range limits of the parameter). However, you can configure predictions for other thresholds by changing the *Minimum alarm severity* option under *System Center* > *System settings* > *analytics config* > *Proactive cap detection*. Alternatively, you can adjust the alarm template (see step 4). For more information, see the [proactive cap detection](xref:Proactive_cap_detection) page.

## Step 4: Configure proactive cap detection in the alarm template

As predicted alarms are suggestion events and not actual alarms, they are shown in the *Predicted alarms* tab, not in the *Active alarms* tab of the Alarm Console. In this step, you will learn how to configure real alarms for these predictions. This can be useful to avoid monitoring two separate tabs in the Alarm Console at the same time.

1. Hover your mouse over the predicted alarm for *Optical RX Power* in the *Predicted alarms* tab of the Alarm Console. In the ![Feedback](~/dataminer/images/Feedback_Column.png) column, click ![the thumbs up icon](~/dataminer/images/Thumbs_Up.png).

   This feedbacks informs DataMiner that you found the predicted alarm useful, which makes it more likely that similar events will be generated in the future. Selecting ![the thumbs down icon](~/dataminer/images/Thumbs_Down.png) would make decrease the likelihood of similar events being triggered.

   ![Giving thumbs up on the predicted alarm on Optical RX Power](~/dataminer/images/Proactive_Cap_Detection_Tutorial_SFP_PositiveFeedback.gif)

   Next to the thumbs up and thumbs down icons, a light bulb icon will appear. This icon offers follow-up actions based on your feedback. You will use it to change the alarm template for *Proactive Tutorial - SFP Monitor*.

1. Click the light bulb icon and select *Improve alarm template* from the list of follow-up actions.

   This will open a pop-up window with the proposed configuration for your augmented operations alarms. In this case, DataMiner proposes creating a real alarm with critical severity whenever it predicts the parameter will cross the *Critical Low* threshold.

   ![Proposed proactive alarming settings for Optical RX Power](~/dataminer/images/Proactive_Cap_Detection_Tutorial_SFP_Popup.gif)

1. Click the underlined text "Critical Low (-10.00 dBm)".

   Here, you can select the thresholds for which predicted alarms should be triggered. These alarm thresholds are those configured in the alarm template (*Critical Low*, *Major Low*, *Minor Low*, *Warning Low*, *Warning High*, *Minor High*, *Major High* and *Critical High*), and the upper and lower range limits of the parameter defined in the protocol. In this case, only *Critical Low* is shown because it is the only threshold configured in the alarm template and no range is specified in the protocol for the parameter.

1. Change the severity of the triggered alarm by clicking the text *Critical* and selecting, for example, *Major*.

   ![Changing severity of the alarm that will be triggered to major](~/dataminer/images/Proactive_Cap_Detection_Tutorial_SFP_AlarmSeverity.gif)

1. Accept the suggested improvement by clicking *Update alarm template* in the lower-right corner of the pop-up window.

   The suggestion event now becomes a real alarm with severity *Major* and is also visible in the *Active alarms* tab.

   ![The predicted alarms in the Active alarms tab](~/dataminer/images/Proactive_Cap_Detection_Tutorial_SFP_MajorAlarm.png)

   > [!NOTE]
   > The options for proactive alarming can also be accessed directly from the alarm template.

1. Right-click the element *Proactive Tutorial - SFP Monitor* in the Surveyor and select *Protocols & Templates* > *View alarm template 'RX Monitoring'*.

1. Scroll to the far-right side of the alarm template and locate the *ANALYTICS* column.

   This column contains a button that indicates whether alarm monitoring has been enabled for anomalies or proactive cap detection. Currently, it displays *Customized*, since alarm monitoring is enabled for proactive cap detection, but not for anomaly detection.

1. Click the button in the *ANALYTICS* column.

   The same *Augmented Operations Alarm Settings* pop-up window will open.

> [!NOTE]
> For a full overview of the Augmented Operations alarm settings, see [Configuring Augmented Operations alarm settings](xref:Configuring_anomaly_detection_alarms).

## Step 5: Final exercise (optional)

In this final step, you will apply what you have learned in this tutorial through a practical exercise.

1. Open the element *Proactive Tutorial - AMS Server*. This element simulates the free disk space of several drives on a server.

1. Click the *Generate Data* button to generate data for a new drive. Each drive's data will be very similar, allowing you to try get the desired result several times.

1. Use the alarm template to configure proactive alarming for the *Free Disk Space* parameter. The parameter's range has a lower limit of 0 GB.

   Your goal is to configure proactive alarming so that a real alarm (i.e., not just a suggestion event) with severity *Warning* is triggered before the disk becomes full. Refer to the image below for the desired outcome.

![Predicted alarm with severity warning for Free Disk Space on AMS Server](~/dataminer/images/Proactive_Cap_Detection_Tutorial_AMS_Alarm.png)

> If you are a member of the [DevOps Program](https://community.dataminer.services/dataminer-devops-professional-program/) and you have completed the exercise above, send us screenshots of your alarm template and your Alarm Console to earn DevOps Points.
>
> Use the following email format:
>
> - Subject: Tutorial - Proactive Tutorial
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback (optional): We value your feedback! Please share any thoughts or suggestions regarding this tutorial or the proactive cap detection feature.
> - Attachment:
>   - A screenshot of the *Active alarms* tab in the Alarm Console with the predicted alarm.
>   - A screenshot of the proactive alarming settings in the alarm template editor, showing the settings you used to generate the requested alarm.
>
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.

> [!IMPORTANT]
> We want to keep improving our proactive cap detection capabilities, and your feedback is very helpful for this. That is why you can also earn DevOps Points by sending us good examples of detected predicted alarms and/or situations where the proactive cap detection can be improved (e.g., no alarm was predicted or an alarm was predicted for something that is not problematic).
>
> Use the following email format to send us your examples:
>
> - Subject: Tutorial - Proactive cap detection feedback
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback: Provide a short explanation of what is shown in the examples you are sending us and why the predicted alarm is good or bad.
> - Attachment:
>   - A picture of the trend graph of the parameter for which the alarm was predicted or not predicted.
>   - An [export of your trend graph](xref:Exporting_a_trend_graph), obtained by right-clicking the trend graph and selecting *Export to CSV*.
>
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points.
