---
uid: Anomaly_Feedback_Tutorial
---

# Improving anomaly detection using feedback

DataMiner's [behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection) automatically detects when a parameter in your system is behaving in an unexpected way. It does this by modeling the behavior of the parameter based on its recent history, and generating a suggestion event or alarm when that behavior deviates significantly from that model. However, in some cases, DataMiner may not work optimally out of the box and it may, for example, generate an anomaly too quickly.

In this tutorial, you will learn how to improve the detection of new anomalies by providing feedback on detected anomalies.

This tutorial does not require any prior knowledge of anomaly detection in DataMiner. However, if you want to learn more about its basic features and how to configure alarming based on anomalies, we recommend completing the [*Detecting anomalies with DataMiner* tutorial](xref:Anomaly_Tutorial).

By default, behavioral anomaly detection is enabled on trended parameters. Similar to the [*Detecting anomalies with DataMiner* tutorial](xref:Anomaly_Tutorial), [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter) are used to simulate parameters with historical trend data. The parameters used in this tutorial have trending enabled by default.

Estimated duration: 25 minutes.

> [!NOTE]
> The content and screenshots for this tutorial were created in DataMiner 10.4.11.

## Prerequisites

- DataMiner 10.4.11 or higher with [Storage as a Service (STaaS)](xref:STaaS) or an [indexing database](xref:Supported_system_data_storage_architectures).

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Behavioral Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

This tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Remove unwanted anomalies by giving negative feedback](#step-2-remove-unwanted-anomalies-by-giving-negative-feedback)
- [Step 3: Fine-tune anomaly detection](#step-3-fine-tune-anomaly-detection)
- [Step 4: Use suggested improvements for alarm templates](#step-4-use-suggested-improvements-for-alarm-templates)
- [Step 5: Final exercise](#step-5-final-exercise-optional)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/4d0fa49c-6355-42d5-943d-e747b6c62906>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create several DataMiner elements in your system that will be used throughout the rest of this tutorial. The elements will be located in the view *DataMiner Catalog* > *Augmented Operations* > *Anomaly Feedback Tutorial*.

   ![Elements](~/user-guide/images/Anomaly_Feedback_Tutorial_Elements.png)

## Step 2: Remove unwanted anomalies by giving negative feedback

In this step, you will **give negative feedback to unwanted level shift anomalies** on an audio bit rate parameter, and you will see that, over time, DataMiner learns from this feedback and stops marking similar level shifts as anomalies.

1. In DataMiner Cube, select the element *Anomaly Feedback Tutorial - Audio Bit Rate* in the Surveyor.

   This element simulates an encoder with multiple audio channels, and is used to monitor the bit rate of these channels.

1. Click the *Generate Single Channel* button.

   This will generate bit rate data for a single channel in the table *Audio Channels* above.

   > [!IMPORTANT]
   > Throughout this tutorial, when generating data, always wait until the *Data Generated?* parameter displays *Yes* before proceeding to the next step.

   ![Generate Single Channel](~/user-guide/images/Generate_Single_Channel.png)

1. Open the trend graph for the bit rate of the newly generated audio channel by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Channel 1* parameter in the *Audio Channels* table.

1. Click *Week to date* to see the data for the past week.

   You will see that the bit rate remained very stable just above 96 kBps, then suddenly drops slightly and starts to fluctuate more. This behavior is typical when switching an audio bit rate parameter from Constant Bit Rate (CBR) encoding to either Average Bit Rate (ABR) or Variable Bit Rate (VBR) encoding. ABR and VBR allow greater, temporary deviations from the target bit rate. A drop or a jump at the moment of the switch, as we see here, is common but not guaranteed.

   Just below the bit rate drop, two black blocks are displayed, indicating two detected changes in behavior, or change points. This means two anomalies were detected at that moment. If you hover the mouse over them, you will see that one is a variance change, corresponding to the parameter becoming less stable, and the other is a level shift, corresponding to the drop.

   > [!NOTE]
   > Since the two anomalies occur around the same time, the labels that appear when you hover over the change points might overlap, causing one label to be hidden. To view both labels clearly, zoom in by pressing CTRL while scrolling up. After zooming in, you can revert back by clicking the *Week to date* button again.

   ![Bit rate with drop and transition from stable signal to less stable signal](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_double_anomaly.png)

1. Click the light bulb icon in the top-right corner of the Alarm Console.

   This icon lights up in blue to indicate that DataMiner Analytics found something interesting. For more detailed info, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).

1. Click the menu item *2 anomalies were found in your trend data* (this can also be a higher number if your system has detected anomalies on other elements).

   A new *Anomalies* tab will now be shown in the Alarm Console, listing the two detected anomalies.

   ![Bit rate with drop and transition from stable signal to less stable signal](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_double_anomaly_alarm_console.png)

   In the *Value* column of the Alarm Console, similar to the trend graph, you will see that the detected level shift was very small: `Level decreased by 0.0331 kBps (from 96.0089 kBps to 95.9758 kBps)`. This corresponds to a drop of approximately 0.003 kBps.

   The reason such a small drop was detected is that, although minor, it exceeds the variability of the parameter before the drop. However, a drop of this size is unlikely to be relevant to an operator. Therefore, we want to remove this anomaly, while still keeping the variance change to detect other instances of switching between CBR and VBR encoding.

1. To give negative feedback to the level shift anomaly, hover the mouse pointer over the suggestion event in the *Anomalies* tab and click ![the thumbs down icon](~/user-guide/images/Thumbs_Down.png) in the ![Feedback](~/user-guide/images/Feedback_Column.png) column.

   Anomaly detection will learn from this feedback, making it less likely to trigger similar anomalies in the future. This applies to the same parameter instance, other instances of the parameter within the same table, and other elements using the same protocol.

   ![Giving negative feedback to the level shift anomaly](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_level_shift_negative_feedback.gif)

1. Optionally, you can clear the suggestion event by clicking the light bulb next to the ![thumbs down](~/user-guide/images/Thumbs_Down.png) button and selecting *Clear event*.

   The light bulb displays suggested follow-up actions based on your feedback. More actions will be explained later. Clearing the alarm does not affect how your feedback is processed by anomaly detection, but it does clean up your Alarm Console.

1. A single instance of negative feedback is insufficient for anomaly detection to learn effectively. So, you will repeat the feedback process a few times:

   1. Go to the *DATA* page of the *Anomaly Feedback Tutorial - Audio Bit Rate* element.

   1. Click the *Generate 3 Channels* button to generate three more audio channels with data similar to the first one, each with a variance change and a level shift anomaly.

   1. In the Alarm Console, give the level shifts detected for *Bit Rate Channel 2*, *Bit Rate Channel 3*, and *Bit Rate Channel 4* negative feedback, and optionally clear them using the light bulb icon.

      ![Giving negative feedback to all three level shift anomalies](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_level_shift_negative_feedback_3.gif)

1. On the *DATA* page of the *Anomaly Feedback Tutorial - Audio Bit Rate* element, generate an additional audio channel by pressing *Generate Single Channel*. For this channel, only a variance change is generated and no level shift because DataMiner's anomaly detection has learned from the previously submitted feedback that level shifts of this size are not interesting.

   ![Alarm Console with a variance change for Channel 5, but no level shift](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_no_level_shift_alarm_console.png)

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Channel 5* parameter in the *Audio Channels* table.

   ![Bit rate of Channel 5 with level shift as a change point, but not as an anomaly](~/user-guide/images/Audio_Bit_Rate_CBR_VBR_level_shift_no_anomaly.gif)

   In the trend graph, you can see that a level shift was still detected. However, the change point below the bit rate drop is light gray this time, which indicates a lower level of importance, meaning it is not marked as an anomaly. So, while the change is still detected, it is no longer seen as unexpected by DataMiner.

   > [!TIP]
   > For more information about the difference between change points and anomalies, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).

## Step 3: Fine-tune anomaly detection

In the previous step, you used negative feedback to remove certain anomalies detected for a bit rate parameter of an audio encoder. In this step, you will **use both negative and positive feedback to fine-tune which anomalies DataMiner detects** for a parameter monitoring the download bit rate in a terrestrial network.

1. Select the element *Anomaly Feedback Tutorial - Average Download Bit Rate* in the Surveyor.

   This element simulates parameters monitoring the average download bit rate in a terrestrial network for each sector (i.e. per town or neighborhood). This bit rate can fluctuate over time, depending on the level of traffic generated by connected households or companies. However, a significant sudden drop may indicate an outage.

1. Click the *Generate Data* button to generate data for a network sector.

1. Open the trend graph for the bit rate of the newly generated network sector channel by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Sector 1* parameter in the *Network Sectors* table.

   As expected, the download bit rate fluctuates significantly but gradually over the past week. However, in the last hour, the bit rate drops by 15 Mbps. This drop is detected as an anomaly. You can tell DataMiner detects this as anomaly because of:

   - The black block displayed below the drop in the trend graph.

     ![Average download bit rate within Sector 1 with a drop at the end](~/user-guide/images/Average_Download_Bit_Rate_Sector_1_trend_graph.png)

   - The level shift entry in the *Anomalies* tab of the Alarm Console.

     ![Anomalies tab in the Alarm Console with anomaly detected for Average Download Bit Rate of Sector 1](~/user-guide/images/Average_Download_Bit_Rate_Sector_1_alarm_console.png)

   While the drop is significant and caught by anomaly detection, 15 Mbps may not be large enough to cause concern in this context. Similar to the previous step, we want to prevent this anomaly from being flagged, but we still want to be notified of larger drops in the future.

1. In the *Anomalies* tab of the Alarm Console, hover the mouse pointer over the level shift anomaly detected for the *Average Download Bit Rate Sector 1* parameter and select ![the thumbs down icon](~/user-guide/images/Thumbs_Down.png) in the ![Feedback](~/user-guide/images/Feedback_Column.png) column.

   This negative feedback will help the anomaly detection learn and make it less likely to trigger similar anomalies in the future. However, significantly larger drops will still be detected.

1. On the *DATA* page of the *Anomaly Feedback Tutorial - Average Download Bit Rate* element, click the *Generate Data* button again to generate data for a new network sector.

1. Open the trend graph for the bit rate of the newly generated network sector channel by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Sector 2* parameter in the *Network Sectors* table.

   The data looks similar, but this time a much larger drop of approximately 50 Mbps occurs at the end, which could indicate a network problem. You will want to be notified about such larger drops in the future.

   ![Average download bit rate within Sector 2](~/user-guide/images/Average_Download_Bit_Rate_Sector_2_trend_graph.png)

1. In the *Anomalies* tab of the Alarm Console, hover the mouse pointer over the level shift anomaly detected for the *Average Download Bit Rate Sector 2* parameter and select ![the thumbs up icon](~/user-guide/images/Thumbs_Up.png) in the ![Feedback](~/user-guide/images/Feedback_Column.png) column.

   By providing different feedback for smaller and larger drops, DataMiner's anomaly detection will gradually learn which sizes of drops you want to be notified about.

1. On the *DATA* page of the *Anomaly Feedback Tutorial - Average Download Bit Rate* element, click the *Generate Data* button twice to generate data for two more network sectors.

   Both network sector 3 and 4 experience only small drops in bit rate.

1. In the *Anomalies* tab of the Alarm Console, hover the mouse pointer over the level shift anomaly detected for *Average Download Bit Rate Sector 3* and *Average Download Bit Rate Sector 4* and select ![the thumbs down icon](~/user-guide/images/Thumbs_Down.png) in the ![Feedback](~/user-guide/images/Feedback_Column.png) column.

   ![Anomalies tab in the Alarm Console with negative feedback for anomalies of sectors 3 and 4](~/user-guide/images/Average_Download_Bit_Rate_Sector_3_and_4_alarm_console.png)

1. On the *DATA* page of the *Anomaly Feedback Tutorial - Average Download Bit Rate* element, click the *Generate Data* button to generate data for a fifth network sector.

   You will see in the trend graph that network sector 5 experiences another small drop in bit rate. However, this time, no anomaly is generated for this size of decrease.

   ![Trend graph of Average Download Bit Rate for Sector 5 with a small drop at the end](~/user-guide/images/Average_Download_Bit_Rate_Sector_5_trend_graph.gif)

1. On the *DATA* page of the *Anomaly Feedback Tutorial - Average Download Bit Rate* element, click the *Generate Data* button to generate data for a sixth and final network sector.

   This sector experiences a large drop, and an anomaly is generated for it.

   This demonstrates that DataMiner's anomaly detection algorithm has learned when to generate an anomaly based on your feedback.

> [!TIP]
> You can easily check whether a parameter has a change point or an anomaly within the last hour by looking at the trend icons displayed in front of the parameters. These icons show the type of change point detected, if any, while their color indicates whether the change point was marked as an anomaly. See [Working with trend icons](xref:Working_with_trend_icons) for more information.
>
> ![Trend icons indicating all sectors have a change point in the last hour and all but the fifth were anomalous](~/user-guide/images/Average_Download_Bit_Rate_Trend_Icons.png)

## Step 4: Use suggested improvements for alarm templates

As mentioned earlier, a light bulb icon may appear next to the ![thumbs up](~/user-guide/images/Thumbs_Up.png) and ![thumbs down](~/user-guide/images/Thumbs_Up.png) icons after you give feedback. This light bulb proposes certain follow-up actions that might make sense based on your feedback. For example, in [Step 2](#step-2-remove-unwanted-anomalies-by-giving-negative-feedback), you used it to clear a suggestion event.

In this step, you will use the light bulb feature to configure an alarm template for anomalies. This will allow you to get a similar result as in [Step 3](#step-3-fine-tune-anomaly-detection), while requiring less feedback and providing you with more control over the process.

1. Select the element *Anomaly Feedback Tutorial - Task Manager* in the Surveyor.

   This element simulates the Windows Task Manager, monitoring the memory usage of several processes. You want to be notified if this memory usage suddenly jumps up a lot.

   As you can see by right-clicking the element in the Surveyor and selecting *Protocols & Templates* > *View alarm template 'Template'*, the element has an empty template associated to it. This allows DataMiner to suggest improvements to the template after you provide feedback.

1. Click the *Generate Data* button to generate data for a first process.

1. Open the trend graph for the memory of the newly generated process by clicking ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Google Chrome* parameter in the *Task Manager* table.

   You will see that the memory usage has fluctuated a bit over the past week, but has remained fairly stable overall. In the last hour, however, it jumps up significantly. As you can see from the black square displayed below the trend graph and by the entry in the Alarm Console, this jump has been detected as an anomaly.

   ![Memory usage of Google Chrome with jump at the end](~/user-guide/images/Memory_Usage_Google_Chrome_Trend_Graph.png)

1. As this is an example of the kind of anomaly you want to be notified of, in the *Anomalies* tab of the Alarm Console, hover the mouse pointer over the level shift anomaly detected for *Memory Usage Google Chrome* and select ![the thumbs up icon](~/user-guide/images/Thumbs_Up.png) in the ![Feedback](~/user-guide/images/Feedback_Column.png) column.

   ![Anomalies tab in the Alarm Console with anomaly detected for Average Download Bit Rate of Sector 1](~/user-guide/images/Memory_Usage_Google_Chrome_Alarm_Console.png)

1. Select the light bulb icon that has appeared next to the ![Feedback](~/user-guide/images/Feedback_Column.png) column.

1. Select *Improve alarm template* from the list of follow-up actions.

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
