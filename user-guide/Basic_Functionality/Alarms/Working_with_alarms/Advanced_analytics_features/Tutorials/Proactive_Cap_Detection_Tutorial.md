---
uid: Proactive_Cap_Detection_Tutorial
---

# Staying ahead of issues with proactive cap detection

In this tutorial, you will learn how to use DataMiner's [proactive cap detection](xref:Proactive_cap_detection) feature to be notified about potential upcoming issues. This feature uses [trend predictions](xref:Working_with_trend_predictions) to automatically analyze which parameters are at risk of exceeding critical thresholds in the near future, and will notify users about them.

By default, proactive cap detection is enabled for all trended parameters. Trending is activated by default for the parameters used in this tutorial. For more information about the technical limitations, see the [proactive cap detection](xref:Proactive_cap_detection) page.

Estimated duration: TODO

> [!NOTE]
> The content and screenshots for this tutorial were created in **DataMiner 10.5.1**.

## Prerequisites

- DataMiner 10.5.1 or higher with [Storage as a Service (STaaS)](xref:STaaS) or an [indexing database](xref:Supported_system_data_storage_architectures).

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Proactive cap detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Detecting parameters that are about to hit upper and lower bounds](#step-2-detecting-parameters-that-are-about-to-hit-upper-and-lower-bounds)
- [Step 3: Detecting parameters that are about to hit alarm thresholds](#step-3-detecting-parameters-that-are-about-to-hit-alarm-thresholds)
- [Step 4: Configuring proactive cap detection in the alarm template](#step-4-configuring-proactive-cap-detecting-in-the-alarm-template)
- [Step 5: Final exercise](#step-5-final-exercise-optional)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/44542748-20d5-4d37-92bc-8d09dbd6984e>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create several DataMiner elements in your system that will be used throughout the rest of this tutorial. The elements will be located in the view *DataMiner Catalog* > *Augmented Operations* > *Proactive Cap Detection Tutorial*.

   ![Elements](~/user-guide/images/Proactive_Cap_Detection_Tutorial_Elements.png)

## Step 2: Detecting parameters that are about to hit upper and lower bounds

In this step, we will explore what potential issues DataMiner's proactive cap detection can spot and how you can be notified about them before they become problematic. We will focus on what DataMiner does out-of-the-box without any configuration. In later steps, we will explore how proactive cap detection leverages information in your alarm template and how you can configure it.

1. In DataMiner Cube, select the view *Content Management Servers* in the Surveyor.

   This view shows a simulation of three servers hosting a large website. To serve the website efficiently and reliably, each server has a cache of frequently accessed content. You can see the evolution of the size of each of these caches on the trend graph in the view.

   ![Cache utilization of three content management servers after failure](~/user-guide/images/Proactive_Cap_Detection_Tutorial_CMS_After_Failure.png)

1. When looking at the graph, you can see that the cache utilization of the first server (blue line) goes up and down periodically and often reaches quite high values, without ever getting completely full. The third server (purple line), on the other hand, has a much lower cache utilization and is fairly stable.

   The second server (green line) also typically has a stable, fairly low level of cache utilization. However, about two days ago, the cache suddenly started to grow, reaching 100% within two days, which significantly affected the performance of the server and thus the reliability of the website.

   We would have liked to receive a notification about the growing cache size of server 2 before it was actually full, in order to fix the issue before it propagated. Many classical strategies would not have worked, or would have been difficult in this case.
   - **Alarm Templates**: one could set an alarm threshold for these parameters in the alarm template. However, since server 1 often reaches high values for cache utilization without being problematic, setting the threshold too low would result in many false alarms, while setting the threshold higher, would result in a notification only shortly before the cache of server 2 is full.
   - **Manual inspection of the parameters**: by manually inspecting the parameters one could detect the changing behavior of the cache utilization of server 2. However, this is time-consuming, and if operators were to view the graph with an unfortunate window size, as in the picture below, they might miss the problem.

     ![Cache utilization of three content management servers before failure](~/user-guide/images/Proactive_Cap_Detection_Tutorial_CMS_Before_Failure.png)

   - **Anomalies**: DataMiner's [behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection) detects a trend change at the moment when the cache utilization of the second server starts to increase, as you can see on the trend graph of *Cache Utilization (after failure)* of *Proactive Tutorial - CMS 2* (see the picture below). However, it was not marked as anomalous (light gray color) because the algorithm did not have enough data before the trend change. Experiments show that it would have been marked as anomalous though if more data had been available. See the [Anomaly Detection Tutorial](xref:Anomaly_Tutorial) for a hands-on first introduction to anomaly detection in DataMiner.

     ![Trend change detected on cache utilization of Proactive Tutorial - CMS 2](~/user-guide/images/Proactive_Cap_Detection_Tutorial_CMS_Server2_TrendChange.png)

1. Open the tab *before failure* on the view *Content Management Servers*.

   This tab shows the situation before the cache utilization of server 2 reached 100%. As noted above, when you look at the metrics in this window, it is not immediately clear that the blue line is about to go down again, while the green one will continue to rise.

1. Have a look at the dashed lines on the right hand side, and scroll a bit to the right by clicking on the trend graph and dragging left.

   These dashed lines show how DataMiner predicts that the metrics will evolve in the near future. Note that it correctly indicates that the blue line will not continue to rise, but that the green line will soon hit 100%, as indicated by the yellow triangle above the trend graph.

   ![Prediction of cache utilization of the three content management servers](~/user-guide/images/Proactive_Cap_Detection_Tutorial_CMS_Before_Failure_Prediction.png)

   This prediction is also used to notify users of such parameters that are about to hit the upper or lower limit of their range.

1. Click the light bulb icon in the upper right corner of the Alarm Console.

   This icon lights up blue to indicate that DataMiner Analytics has found something interesting. For more detailed information, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).

1. Click the menu item *1 alarm is predicted in the near future* (this can also be a higher number if your system predicts alarms on other elements).

   A new *Predicted alarms* tab will appear in the Alarm Console, listing a predicted alarm for the second server's cache utilization.

   ![Predicted alarm in the Alarm Console for the cache utilization of the second content management server](~/user-guide/images/Proactive_Cap_Detection_Tutorial_CMS_AlarmConsoleLightBulb.gif)

   This tab shows a predicted alarm for each metric that is likely to hit the upper or lower limit of its range in the near future (as well as certain alarm thresholds, see later in this tutorial). Note that these predicted alarms are not real alarms, only *suggestion events*, and are not shown in the *Active alarms* tab.

> [!NOTE]
> You can also find the predicted alarms using the *Suggestion events* tab. To do so, click the plus icon in the header of the Alarm Console, and then select *Show current* > *Suggestion events*. This will open a tab with all suggestion events, including the predicted alarm above. However, this tab page can show more than only the predicted alarms. See [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console) for more information.
>
>
> ![Suggestion events tab in the alarm console showing a predicted alarm](~/user-guide/images/Proactive_Cap_Detection_Tutorial_CMS_AlarmConsoleSuggestionEvents.gif)

## Step 3: Detecting parameters that are about to hit alarm thresholds

In the previous step, we showed what proactive cap detection can detect out-of-the-box, without any configuration, by relying on a parameter's upper and lower range limits. In this step, we will see how proactive cap detection uses the alarm thresholds configured in the alarm template to improve its suggestions.

1. Open the element *Proactive Tutorial - SFP Monitor*. This element simulates the *Optical RX Power* metric of an SFPs (Small Form-Factor Pluggable), a device used together with network switches to connect fiber-optic or copper cables (see [this use-case](https://community.dataminer.services/use-case/ai-assisted-sfp-monitoring/) for more information).
1. Open the trend graph of the parameter *Optical RX Power* on *Port 1* by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png).

1. Click *Month to date* to see the data for the past month.

   You can see that the power remained stable until about three weeks ago (until November 11th in the picture), at which point it suddenly dropped and then continued to gradually degrade. If the value of this parameter would get too low, it could lead to a connection failure. Therefore, we would like to be warned about cases like this.

   ![Optical RX Power of Port 1 over the past month](~/user-guide/images/Proactive_Cap_Detection_Tutorial_SFP_Trend_Graph.png)

   The *Suggestion events* and *Proactive alarms* tab do not currently show any events for this parameter, because it does not have a lower limit. However, we can set alarm thresholds in the alarm template.

1. Right-click the element *Proactive Tutorial - SFP Monitor* in the Surveyor, and select *Protocols & Templates* > *Assign alarm templates* > *New alarm template*
1. Enter a name for the alarm template, e.g. *RX Monitoring*, and click *OK*
1. Select the checkbox in the *MON* column for the parameter *SFPs: Optical RX Power*.

    This enables alarm monitoring for this parameter.
1. Enter a threshold of -10 in the *CRIT LO* column.
1. Click *OK* to save the alarm template.

    A critical alarm threshold is now configured on the parameter *Optical RX Power* of the SFP monitor.

1. Click the *Generate Extra Data* button on the element *Proactive Tutorial - SFP Monitor*.

   This will generate data a few more data points for *Optical RX Power* of *Port 1*, causing DataMiner to re-evaluate its prediction. This is equivalent to waiting a few minutes for more data points to come in.

   > [!IMPORTANT]
   > Throughout the rest of this tutorial, when generating data, always wait until the *Data Generated?* parameter displays *Yes* before proceeding to the next step.

1. Reopen the *Predicted alarms* tab (if necessary) by clicking the light bulb icon in the upper right corner of the Alarm Console and selecting the item *2 alarms are predicted in the near future*.

   The tab now also lists a *Predicted Critical Low* event for *Optical RX Power Port 1*, as DataMiner now predicts that the parameter will cross the critical low threshold that we configured above in the near future, even though the parameter has not crossed the threshold yet.

   The advantage of using these predicted alarms here, is that you will be notified earlier, and thus that you can use less strict thresholds in your alarm template. This way you avoid false positives, while still receiving notifications when parameters are likely to cross a critical threshold in the near future.

   Note again that this predicted alarm is a *suggestion event*, not a real alarm, and therefore will not be appear in the *Active alarms* tab.

   ![Predicted critical low alarm on Optical RX Power Port 1](~/user-guide/images/Proactive_Cap_Detection_Tutorial_SFP_PredictedAlarms.png)

> [!NOTE]
> By default, predicted alarms are generated only for critical alarm thresholds (as well as upper and lower range limits of the parameter). However, other thresholds can be configured by setting the *Minimum alarm severity* option under *System Center* > *System settings* > *analytics config* > *Proactive cap detection* or, as we will see below, by changing the alarm template. For more information, see the [proactive cap detection](xref:Proactive_cap_detection) page.

## Step 4: Configuring proactive cap detecting in the alarm template

In the previous steps, the predicted alarms we generated were not shown in the *Active alarms* tab in the Alarm Console, as they were suggestion events, and not real alarms. In this step, you will learn how to create real alarms for them. This can be useful to avoid having to keep an eye on two tabs in the Alarm Console at the same time.

1. Hover your mouse over the predicted alarm on *Optical RX Power* in the *Predicted alarms* tab in the Alarm Console. In the ![Feedback](~/user-guide/images/Feedback_Column.png) column, click ![the thumbs up icon](~/user-guide/images/Thumbs_Up.png).

   This lets DataMiner know that you found the predicted alarm useful, and makes it more likely to show similar events in the future. Selecting ![the thumbs down icon](~/user-guide/images/Thumbs_Down.png) would make DataMiner less likely to trigger similar events.

   ![Giving thumbs up on the predicted alarm on Optical RX Power](~/user-guide/images/Proactive_Cap_Detection_Tutorial_SFP_PositiveFeedback.gif)

   Note that next to the ![thumbs up](~/user-guide/images/Thumbs_Up.png) and ![thumbs down](~/user-guide/images/Thumbs_Down.png) icons, a light bulb icon has appeared. This icon proposes certain follow-up actions based on your feedback. We will use it to change the alarm template of *Proactive Tutorial - SFP Monitor*.

1. Click the light bulb icon and select *Improve alarm template* from the list of follow-up actions.

   This will open a pop-up window with the proposed configuration for proactive alarming. In this case, DataMiner proposes to create a real alarm, instead of a suggestion event, with severity *Critical* whenever it predicts that the parameter will cross the *Critical Low* threshold.

   ![Proposed proactive alarming settings for Optical RX Power](~/user-guide/images/Proactive_Cap_Detection_Tutorial_SFP_Popup.gif)

1. Click on the text *Critical Low (-10 dBm)*.

   Here, you can select the thresholds for which to create predicted alarms. These thresholds are the alarm thresholds configured in the alarm template (*Critical Low*, *Major Low*, *Minor Low*, *Warning Low*, *Warning High*, *Minor High*, *Major High* and *Critical High*), and the upper and lower range limits of the parameter defined in the protocol. In this case only *Critical Low* is shown, as this is the only threshold configured in the alarm template and no range is specified in the protocol for the parameter.

1. Change the severity of the alarm that is triggered to, for instance, *Major* by clicking on the text *Critical*.

   ![Changing severity of the alarm that will be triggered to major](~/user-guide/images/Proactive_Cap_Detection_Tutorial_SFP_AlarmSeverity.gif)

1. Accept the suggested improvement by clicking *Update alarm template* in the lower right corner of the pop-up window.

   The suggestion event now becomes a real alarm with severity *Major* and is also visible in the *Active alarms* tab.

   ![The predicted alarms in the Active alarms tab](~/user-guide/images/Proactive_Cap_Detection_Tutorial_SFP_MajorAlarm.png)

   The options for proactive alarming can also be accessed directly from the alarm template.

1. Right-click the element *Proactive Tutorial - SFP Monitor* and select *Protocols & Templates* > *Assign Alarm Template* > *RX Monitoring*.
1. Scroll to the far right of the alarm template and find the *ANALYTICS* column.

   This column contains a button that indicates whether any alarm monitoring has been enabled for anomalies or proactive cap detection. Right now it shows *Customized*, since alarm monitoring for proactive cap detection is enabled, but not for anomalies.

1. Click the button in the *ANALYTICS* column.

   The same pop-up will open as in the previous window.

> [!NOTE]
> For a full overview of the Augmented Operations alarm settings, see [Configuring Augmented Operations alarm settings](xref:Configuring_anomaly_detection_alarms).

## Step 5: Final exercise (optional)

In this final step, you will apply what you have learned earlier in a practical exercise.

Open the element *Proactive Tutorial - AMS Server*, simulating the free disk space of several drives of a server. Data for a new drive will be generated every time you click the *Generate Data* button. The data will be very similar for each drive you generate, allowing you to try several times to get the desired result. The *Free Disk Space* parameter's range has a lower limit of 0&nbsp;GB.

Your goal is to configure proactive alarming in the alarm template so that you get a real alarm (i.e. not just a suggestion event) with severity *Warning* before the disk gets full, as in the picture below. Good luck!

![Predicted alarm with severity warning for Free Disk Space on AMS Server](~/user-guide/images/Proactive_Cap_Detection_Tutorial_AMS_Alarm.png)

> If you are a member of the [DevOps Program](https://community.dataminer.services/dataminer-devops-professional-program/) and you have completed the exercise above, send us screenshots of your alarm template and your alarm console to earn DevOps Points.
>
> Use the following email format:
>
> - Subject: Tutorial - Proactive Tutorial
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email
>   - Feedback (optional): We value your feedback! Please share any thoughts or suggestions regarding this tutorial or the proactive cap detection feature.
> - Attachment:
>   - A screenshot of the *Active alarms* tab in the Alarm Console with the predicted alarm.
>   - A screenshot of the proactive alarming settings in the alarm template editor, showing the settings you used to generate the requested alarm.
>
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.

> [!IMPORTANT]
> We want to keep improving our proactive cap detection capabilities, and your feedback is very helpful for this. That is why you can also earn DevOps Points by sending us good examples of detected predicted alarms and/or situations where the proactive cap detection can be improved (e.g. no alarm was predicted, or an alarm was predicted for something that is not problematic).
>
> Use the following email format to send us your examples:
>
> - Subject: Tutorial - Proactive cap detection feedback
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback: Provide a short explanation of what is shown in the examples you are sending us and why the predicted alarm is good or bad.
> - Attachment:
>   - A picture of the trend graph of the parameter on which the alarm was predicted or not predicted.
>   - An [export of your trend graph](xref:Exporting_a_trend_graph), obtained by right-clicking the trend graph and selecting *Export to CSV*.
>
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points.
