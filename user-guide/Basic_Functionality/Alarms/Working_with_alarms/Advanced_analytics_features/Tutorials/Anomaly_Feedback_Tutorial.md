---
uid: Anomaly_Feedback_Tutorial
---

# Improving anomaly detection using feedback

DataMiner's [Behavioral Anomaly Detection](xref:Working_with_behavioral_anomaly_detection) automatically detects when a parameter in your system is behaving in an unexpected way. It does this by modeling the behavior of the parameter based on its recent history, and generating a suggestion event or alarm when that behavior deviates significantly from that model. However, in some cases, DataMiner may not work optimally out of the box and it may, for example, generate an anomaly too quickly.
In this tutorial we will learn how to improve the detection of new anomalies by providing feedback on detected anomalies.

This tutorial does not require any prior knowledge of anomaly detection in DataMiner. However, if you want to learn more about its basic features and how to configure alarming based on anomalies, we recommend you to complete the tutorial [Detecting anomalies with DataMiner](xref:Anomaly_Tutorial).

By default, behavioral anomaly detection is enabled on trended parameters. As in the tutorial [Detecting anomalies with DataMiner](xref:Anomaly_Tutorial) we will use [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter) to simulate parameters with historical trend data. The parameters used in this tutorial have trending enabled by default.

Estimated duration: 25 minutes

TODO: let someone else estimate too

TODO: probably also refer to some docs page on feedback?

## Prerequisites

- DataMiner TODO or higher with [Storage as a Service (STaaS)](xref:STaaS) or an [indexing database](xref:Supported_system_data_storage_architectures).

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Behavioral Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

This tutorial consists of the following steps:

- [Step 1: Install the example package from the catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Getting rid of unwanted anomalies](#step-2-getting-rid-of-unwanted-anomalies)
- [Step 3: Fine-tune anomaly detection](#step-3-fine-tune-anomaly-detection)
- [Step 4: Use suggested improvements for alarm templates](#step-4-use-suggested-improvements-for-alarm-templates)
- [Step 5: Final exercise](#step-5-final-exercise-optional)

## Step 1: Install the example package from the catalog

1. Go to <TODO: correct link>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create several DataMiner elements on your system that will be used throughout the rest of this tutorial. The elements will be located in the view *DataMiner Catalog* > *Augmented Operations* > *Anomaly Feedback Tutorial*.

## Step 2: Getting rid of unwanted anomalies

In this step, we will give negative feedback on unwanted level shift anomalies on an audio bit rate parameter, and we will see that, over time, DataMiner learns from this feedback and stops marking similar level shifts as anomalies.

1. In DataMiner Cube, select the element *Anomaly Feedback Tutorial - Audio Bit Rate* in the Surveyor.

   This element simulates an encoder with multiple audio channels, and is used to monitor the bit rate of these channels.

1. Click the *Generate Single Channel* button. This will generate bit rate data for a single channel in the table *Audio Channels* above.
1. Wait until the *Data Generated?* parameter shows *Yes*.
1. Open the trend graph for the bit rate of the newly generated audio channel by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) in the first row of the table *Audio Channels*.
1. Click on *Week to date* to see the data for the past week.

   You can see that the bitrate remained very stable just above 96 kBps before suddenly dropping a bit and starting to fluctuate more. This behavior is typical when an audio bit rate parameter switches from Constant Bit Rate (CBR) encoding to either Average Bit Rate (ABR) encoding or Variable Bit Rate (VBR) encoding, as the latter two allow a greater temporary deviation from the target bit rate. A drop or a jump at the moment of the switch, as we see here, is also often present, but not always.

   Below the bit rate drop, there are two black squares indicating that two anomalies were detected at that point. If you hover the mouse over them, you can see that one is a variance change, corresponding to the parameter becoming less stable, and the other is a level shift, corresponding to the drop.

   ![Bit rate with drop and transition from stable signal to less stable signal](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_double_anomaly.png)

1. Click on the light bulb icon in the top right corner of the Alarm Console and select the menu item *2 anomalies were found in your trend data* (this may be a a higher number if your system has detected anomalies on other elements). This will open the *Anomalies* tab in the Alarm Console, where you will also find the two detected anomalies.

   ![Bit rate with drop and transition from stable signal to less stable signal](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_double_anomaly_alarm_console.png)

   Both in the Alarm Console and in the trend graph, you can see that the level shift that was detected is very small: it corresponds to a drop of around 0.003 kBps. The reason such a small drop was detected, is that, even though it is very small, it is still larger than the variability of the parameter before the drop. However, a drop of this size is unlikely to be relevant to an operator. Therefore, we want to get rid of it, while still keeping the variance change to detect other instances of switching between CBR and VBR encoding.

1. Give negative feedback to the level shift anomaly by hovering over the suggestion event in the *Anomalies* tab, and pressing the thumbs down icon on the right hand side of the alarm console.

   Anomaly detection will learn from this feedback and will be less likely to trigger similar anomalies in the future, both on the same parameter instance, on other instances of the parameter in the same table, and on other elements using the same protocol.

   ![Giving negative feedback to the level shift anomaly](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_level_shift_negative_feedback.gif)

1. Optionally, you can clear the suggestion event by clicking the light bulb next to the thumbs down button, and selecting *Clear event*.

   This light bulb shows you suggested follow-up actions based on your feedback. We will see some more actions later. Clearing the alarm does not affect how your feedback is processed by anomaly detection, but it does clean up your alarm console.

1. A single instance of negative feedback is a bit too little for anomaly detection to learn effectively. So, we will repeat the process a few times. Press the button *Generate 3 Channels* to generate three more audio channels with data similar to the first one, each one with a variance change and a level shift anomaly.

1. Give negative feedback to all three level shifts, and optionally clear them through the light bulb icon.

   ![Giving negative feedback to all three level shift anomalies](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_level_shift_negative_feedback_3.gif)

1. Generate an additional audio channel by pressing *Generate Single Channel*. Note that for this channel, only a variance change anomaly is generated, and no longer a level shift anomaly, because anomaly detection has learned from the provided feedback that level shifts of this size are not interesting.

   ![Alarm Console with a variance change for Channel 5, but no level shift](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_no_level_shift_alarm_console.png)

   If we open the trend graph of *Channel 5*, we do see that a level shift is still detected as a change point, but that it is not marked as an anomaly, as shown by the light gray square under the trend graph. This means that the change is still detected, but that it is no longer seen as unexpected by DataMiner. For more information on the difference between change points and anomalies, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).

   ![Bit rate of Channel 5 with level shift as a change point, but not as an anomaly](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_level_shift_no_anomaly.gif)

TODO: in KATA, emphasize that every user (that can see the alarm) can give feedback, but that it is applied system-wide (not per user)

## Step 3: Fine-tune anomaly detection

In the previous step, we used only negative feedback to get rid of certain anomalies on a bit rate parameter of an audio encoder. In this step, we will use both negative and positive feedback to fine-tune which anomalies DataMiner will detect on a parameter monitoring the download bit rate in a terrestrial network.

1. Select the element *Anomaly Feedback Tutorial - Average Download Bit Rate* in the Surveyor.

   This element simulates parameters monitoring the average download bit rate in a terrestrial network per sector (i.e. per town or neighborhood). This bit rate can fluctuate over time, depending on whether connected households or companies are generating heavy traffic, or not. If there is a significant sudden drop however, it may be an indication of an outage.

1. Generate data for a network sector by clicking the *Generate Data* button.

1. Wait until the *Data Generated?* parameter shows *Yes*.

1. Open the trend graph for the bit rate of the newly generated network sector channel by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) in the first row of the table *Network Sectors*.

   As expected, you will see that the download bit rate fluctuates significantly but gradually over the last week. However, in the last hour the bit rate dropped with 15 Mbps. This drop is detected as an anomaly, as you can see by the black square below the trend graph, or in the *Anomalies* tab in the alarm console.

   ![Average download bit rate within Sector 1 with a drop at the end](~/user-guide/images/Average_Download_Bit_Rate_Sector_1_trend_graph.png)

   ![Anomalies tab in the Alarm Console with anomaly detected for Average Download Bit Rate of Sector 1](~/user-guide/images/Average_Download_Bit_Rate_Sector_1_alarm_console.png)

   While the drop is arguably significant (and thus caught by anomaly detection), it can be argued that 15 Mbps is not large enough to be a problem in this context. Similar to the previous step, we want to avoid getting this anomaly. However, we still want to be notified of larger jumps down.

1. Give negative feedback to the suggestion event by pressing the thumbs down button in the *Anomalies* tab in the alarm console.

   This will make it less likely that similar anomalies will be detected. However, significantly larger drops will still be detected.

1. Generate data for a new network sector by clicking the *Generate Data* again and wait until the *Data Generated?* parameter shows *Yes*.

1. Open the trend graph of *Average Download Bit Rate* for *Sector 2*.

   Notice that the data looks very similar, but this time there is a much larger drop at the end, around 50 Mbps. This drop could certainly indicate a network problem, and hence we want to be notified about similar drops in the future.

   ![Average download bit rate within Sector 2](~/user-guide/images/Average_Download_Bit_Rate_Sector_2_trend_graph.png)

1. Give positive feedback to the suggestion event of *Sector 2* by pressing the thumbs up button in the *Anomalies* tab of the alarm console.

   By giving different feedback for smaller and larger drops, anomaly detection will learn over time what size of drops you want to be notified about.

1. Click the *Generate Data* button twice again to generate data for two new network sectors.

1. Both of these network sectors again only have small drops. Give negative feedback on the anomalies generated for these sectors.

   ![Anomalies tab in the Alarm Console with negative feedback for anomalies of sectors 3 and 4](~/user-guide/images/Average_Download_Bit_Rate_Sector_3_and_4_alarm_console.png)

1. Generate data for a fifth sector by pressing *Generate data* one more time.

   Again, the network sector only has a relatively small drop, as you can see in the trend graph. However, this time no anomaly is generated anymore for this drop!

   ![Trend graph of Average Download Bit Rate for Sector 5 with a small drop at the end](~/user-guide/images/Average_Download_Bit_Rate_Sector_5_trend_graph.gif)

1. Generate data for a sixth sector. Notice that this sector again has a large drop, and that an anomaly is generated for this sector.

   This illustrates that DataMiner's anomaly detection algorithm has learned when to generate an anomaly and when not, based on your feedback.

> [!TIP]
> You can easily see whether a parameter has a change point or an anomaly in the last hour by looking at the trend icons displayed in front of the parameters. The icon indicates the type of change point that was detected, if any, while the color indicates whether the change point was marked as an anomaly. See [Working with trend icons](xref:Working_with_trend_icons) for more information.
>
> ![Trend icons indicating all sectors have a change point in the last hour and all but the fifth were anomalous](~/user-guide/images/Average_Download_Bit_Rate_Trend_Icons.png)

## Step 4: Use suggested improvements for alarm templates

As we mentioned earlier, a light bulb icon can appear next to the thumbs up and thumbs down icons after you give feedback. This light bulb proposes certain follow-up actions that might make sense based on your feedback. For example, in [Step 2](#step-2-getting-rid-of-unwanted-anomalies) we used it to clear a suggestion event. In this step we will use it to configure an alarm template for anomalies. This will allow us to get a similar result as in [Step 3](#step-3-fine-tune-anomaly-detection), while requiring less feedback and providing you with more control over the process.

1. Select the element *Anomaly Feedback Tutorial - Task Manager* in the Surveyor.

   This element simulates the Windows Task Manager, monitoring the memory usage of several processes. We want to be notified if this memory usage suddenly jumps up a lot.

   As you can see by right-clicking the element in the Surveyor and selecting *Protocols & Templates* > *View alarm template 'Template'*, the element has an empty template associated to it. This allows DataMiner to suggest improvements to the template when providing feedback.

1. Click the *Generate Data* button to generate data for a first process.

1. Wait until the *Data Generated?* parameter shows *Yes*.

1. Open the trend graph for the memory of the newly generated process by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) in the row next to *Google Chrome*.

   You will see that the memory usage has fluctuated a bit over the last week, but has remained fairly stable overall. In the last hour, however, it jumped up significantly. As you can see from the black square below the trend graph and in the alarm console, this jump has been detected as an anomaly.

   ![Memory usage of Google Chrome with jump at the end](~/user-guide/images/Memory_Usage_Google_Chrome_Trend_Graph.png)

1. Since this is an example of the kind of anomaly we want to detect, press the thumbs up button for the corresponding suggestion event in the *Anomalies* tab in the Alarm Console.

   ![Anomalies tab in the Alarm Console with anomaly detected for Average Download Bit Rate of Sector 1](~/user-guide/images/Memory_Usage_Google_Chrome_Alarm_Console.png)

1. Notice that a light bulb with suggested follow-up actions appears next to the feedback buttons. Click on this light bulb and select *Improve alarm template...*

   This will open a popup with suggested improvements to the [anomaly detection alarms settings](xref:Configuring_anomaly_detection_alarms) in the alarm template. In this case, it will suggest enabling *smart* alarming for level increases, as we have given positive feedback for that type of anomaly. This means that in the future, instead of a suggestion event, an alarm will be generated when an anomaly is detected.

   ![Popup suggesting to turn on alarming for level increases](~/user-guide/images/Memory_Usage_Task_Manager_Template_Improvement.gif)

1. Accept the suggested improvements by clicking *Update alarm template*. Note that the suggestion event now turns into a real alarm.

1. Click *Generate Data* again to generate memory usage data for the *Java Runtime* process.

1. Open the trend graph for the memory usage of *Java Runtime*.

   Notice that also here, the data ends with a jump up, but a much smaller one. However, DataMiner still detects it as an anomaly. Moreover, since we enabled alarming in the previous step, a critical alarm is generated.

   ![Memory usage of Java Runtime with relatively small jump at the end](~/user-guide/images/Memory_Usage_Java_Runtime_Trend_Graph.png)

1. Click the thumbs down button for the alarm on *Java Runtime* in the *Anomalies* tab in the Alarm Console.

1. Again, a light bulb icon appears with the suggestion to improve the alarm template. Click on this light bulb and select *Improve alarm template...*

   A popup will appear suggesting to set an absolute threshold of 200 MB for level increases. This would mean that level increase anomalies would only be generated if the memory usage jumped up 200 MB or more. This threshold is chosen automatically based on our previous feedback: it makes sure that jumps like the one for *Google Chrome* are still alarmed, but jumps of a smaller size like the one for *Java Runtime* are not.

   ![Popup suggesting to set an absolute threshold for level increases](~/user-guide/images/Memory_Usage_Java_Runtime_Template_Improvement.gif)

1. Accept the suggested improvements by clicking *Update alarm template*. Note that the alarm on *Java Runtime* now disappears, and the alarm on *Google Chrome* changes to a critical alarm.

1. Click *Generate Data* a third time to generate memory usage data for *Microsoft Visual Studio*.

1. Open the trend graph for the memory usage of *Microsoft Visual Studio*.

   Note that the jump here is large in absolute terms: the jump size is just over 400 MB. However, it is still relatively small compared to the value it started from: it represents an increase of about 23% compared to the starting value of about 1750 MB.

   ![Memory usage of Microsoft Visual Studio a big jump at the end in absolute numbers, but relatively small compared to the baseline](~/user-guide/images/Memory_Usage_Visual_Studio_Trend_Graph.png)

1. Again, click the thumbs down button for the alarm on *Microsoft Visual Studio* in the *Anomalies* tab of the Alarm Console.

1. A new improvement to the alarm template is suggested. Open the popup by clicking the light bulb and selecting *Improve alarm template...*

   Note that this time, alarming based on a relative threshold of 40% is proposed. This threshold means that anomaly alarms will be generated whenever the relative size of the jump with respect to the starting value is greater than 40%. A relative threshold is chosen over an absolute threshold here because an absolute threshold cannot satisfy both our negative feedback on this last jump and the negative feedback on the slightly smaller jump for the *Google Chrome* process. However, alarming on a relative threshold can satisfy both, since the jump for *Google Chrome* was large relative to the value at the start of the jump, while the jumps for *Java Runtime* and *Microsoft Visual Studio* were small relative to their start values.

   ![Popup suggesting to set a relative threshold for level increases](~/user-guide/images/Memory_Usage_Visual_Studio_Template_Improvement.gif)

   > [!TIP]
   > Click the clock icon next to the line on *level increases* to compare the proposed configuration with the currently active configuration.
   >
   > ![The current configuration and the previous configuration](~/user-guide/images/Alarm_Template_Anomaly_Configuration_History_Button.gif)

1. Accept the suggested improvements *Update alarm template*. Again, the alarm for *Microsoft Visual Studio* disappears, while the alarm for *Google Chrome* remains.

1. Press the button *Generate Data* twice more to generate data for *Explorer* and *Microsoft Excel*. Note that the first one generates an anomaly alarm for a jump from about 50MB to about 150 MB, representing an increase of about 100MB, or 200%. The latter one jumps from about 150 MB to about 175 MB, only representing an increase of about 25 MB, or about 15%. Therefore, no anomaly is generated for this one.

## Step 5: Final exercise (optional)

In this final step, you will repeat [Step 3](#step-3-fine-tune-anomaly-detection), but you will give different feedback and thereby get a different result.

For this exercise, use the element *Anomaly Feedback Tutorial - Average Download Bit Rate 2*. It will generate the same data as *Anomaly Feedback Tutorial - Average Download Bit Rate*, but it uses a protocol with another name so that you start again with a clean slate. Moreover, it has an empty alarm template configured so that you can get suggestions to improve the alarm template.

The goal of the exercise is to get alarms or suggestion events for jumps down greater than 20 Mbps, but not for jumps down smaller than 20 Mbps. You are free to use only feedback, or combine feedback with the suggested alarm template improvements as in [Step 4](#step-4-use-suggested-improvements-for-alarm-templates).

> If you are a member of the DevOps Program and you have completed the exercise above, send us screenshots of the alarm console with the feedback you gave to earn DevOps Points.
>
> Use the following email format:
>
> - Subject: Tutorial - Anomaly Feedback Tutorial
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email
>   - Feedback (optionally): We value your feedback! Please share any thoughts or suggestions regarding this tutorial or the anomaly detection feature.
> - Attachment:
>   - A picture of the *Anomalies* tab in the alarm console with the feedback you gave on the anomalies.
>
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.

> [!IMPORTANT]
> We want to keep improving our Behavioral Anomaly Detection capabilities, and your feedback is very helpful for this. That is why you can also earn DevOps Points by sending us good examples of detected anomalies and/or situations where the anomaly detection can be improved (e.g. no anomaly was detected, or an anomaly was detected for something that is not problematic).
>
> Use the following email format to send us your examples:
>
> - Subject: Tutorial - Anomaly detection feedback
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback: Provide a short explanation of what is shown in the examples you are sending us and why the detected anomaly is good or bad.
> - Attachment:
>   - A picture of the trend graph with the detected anomaly.
>   - An [export of your trend graph](xref:Exporting_a_trend_graph), obtained by right-clicking the trend graph and selecting *Export to CSV*.
>
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points.
