---
uid: Anomaly_Tutorial
---

# Detecting anomalies with DataMiner

This tutorial illustrates DataMiner's [Behavioral Anomaly Detection](xref:Working_with_behavioral_anomaly_detection) features and show how you can use these to detect certain failures in your operation.

By default, behavioral anomaly detection is active on trended parameters. It will monitor the parameters in real time and notify users about any detected anomalies. The feature models the behavior of a parameter based on its recent history. The tutorial will make use of [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter) to quickly simulate a parameter with historical trend data. Trending is activated by default on the parameters used in this tutorial.

Estimated duration: 45 minutes.

> [!TIP]
> For more information, such as technical limitations to anomaly detection, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).

## Prerequisites

- DataMiner 10.3.12 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra database](xref:Supported_system_data_storage_architectures).

- Behavioral Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

The tutorial consists of the following steps.

- [Step 1: Install the example package from the catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Discover anomaly detection in trend graphs](#step-2-discover-anomaly-detection-in-trend-graphs)
- [Step 3: Discover anomaly detection in the Alarm Console](#step-3-discover-anomaly-detection-in-the-alarm-console)
- [Step 4: Make DataMiner generate alarms for anomalies](#step-4-make-dataminer-generate-alarms-for-anomalies)
- [Step 5: Make DataMiner generate alarms for specific anomaly types](#step-5-make-dataminer-generate-alarms-for-specific-anomaly-types)
- [Step 6: Set custom alarm thresholds](#step-6-set-custom-alarm-thresholds-requires-dataminer-10312-or-higher)
- [Step 7: Final exercise](#step-7-final-exercise)

## Step 1: Install the example package from the catalog

1. Go to <https://catalog.dataminer.services/catalog/5467>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

## Step 2: Discover anomaly detection in trend graphs

1. In DataMiner Cube, select the element *Audio bit rate* in the Surveyor.

   This element simulates a parameter monitoring the bit rate of an audio channel on an encoder.

1. Click the *Generate Data* button to generate data for the parameter *Audio Bit Rate Channel 1*.

   > [!NOTE]
   > The protocols used in this tutorial can only load data for a parameter once. If you have made a mistake or want to retry an exercise, you can rerun the simulation by [duplicating](xref:Duplicating_elements) the element and generating the data again on the duplicated element.

1. Wait until the *Data Generated?* parameter displays *Yes*.

1. Click the trend icon ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Audio Bit Rate Channel 1* parameter.

1. Click *Month to date* to see data for the past month.

   You will see that the bitrate first remained stable around 96 kBps for the better part of two weeks before temporarily jumping up a few times to values around 256 kBps. Finally, after 5 jumps, there is one jump to over 1000 kBps.

   ![Audio bit rate with several jumps, some of which are marked as anomalous](~/user-guide/images/Audio_bit_rate.gif)

   Under each of the jumps up and down, a gray or black block is displayed. These blocks indicate a detected change in behavior, or **change point**.

   > [!TIP]
   > For more information on the possible types of change points, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection)

1. Hover the mouse pointer over a change point to see more detail about the type of change point (e.g. a level shift). If necessary, zoom in to see all details, such as the begin and end values.

   ![Zoomed in view of a change point to see all details](~/user-guide/images/Audio_Bit_Rate_Trending_ChangePoint_Details.png)

   > [!NOTE]
   > In the example, the blocks under the first two jumps have a darker color, because these are considered to be an anomaly. This is because when the first jump occurs, the parameter has never had similar behavior before. By the third jump, the algorithm has seen sufficient similar behavior to no longer consider the behavior anomalous. However, the jump towards the end is again considered anomalous, as it is much bigger than the previous ones.

## Step 3: Discover anomaly detection in the Alarm Console

1. In DataMiner Cube, select the element *Encryption Key Requests* in the Surveyor.

   This element simulates a parameter monitoring the number of encryption key requests received per minute by a CAS server.
  
1. Click the *Generate Data* button to generate data for the parameter *Encryption Key Requests*.

1. Wait until the *Data Generated?* parameter displays *Yes*.

1. Click the light bulb icon in the top right corner of the Alarm Console.

   This icon lights up in blue to indicate that DataMiner Analytics found something interesting. For more detailed info, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).

1. Click the menu item *2 anomalies were found in your trend data* (this can also be a a higher number if your system has detected anomalies on other elements).

   A new *Anomalies* tab will now be shown in the Alarm Console, listing the detected anomalies.

   ![Anomaly tab in the Alarm Console](~/user-guide/images/Encryption_Key_Requests_Lightbulb.gif)

1. Double-click one of the listed anomalies for the element *Encryption Key Requests* to view the trend graph of the parameter.

   The trend graph will show that the number of requests per minute remained relatively stable for a long time but suddenly increased spectacularly a few hours ago, indicating that unexpected activity may be going on in the network.

   ![The trend graph of the 'Encryption Key Requests' parameter showing the anomalous region](~/user-guide/images/Encryption_Key_Requests_Trend_Graph.png)

> [!NOTE]
> You can also find the anomalies using the *Suggestion events* tab. To do so, click the plus icon in the header of the Alarm Console, and then select *Show current* > *Suggestion events*. This will open a tab with all suggestion events, including the two anomalies on *Encryption Key Requests*. However, this tab page can show more than only the anomalies. See [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console) for more information.
>
> ![Suggestion events tab in the alarm console showing the anomalies on 'Encryption Key Requests'](~/user-guide/images/Encryption_Key_Requests_Suggestion_Events.gif)

## Step 4: Make DataMiner generate alarms for anomalies

As anomalies might flag potential problems in your operation, it can be useful to show alarms for these events.

1. Create an alarm template for the example element *Encryption Key Requests 2*:

   1. Right-click the element *Encryption Key Requests 2* in the Surveyor, and select *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.

      > [!NOTE]
      > This element is a copy of *Encryption Key Requests*, which generates the same data.

   1. Specify a name for the alarm template, e.g. *Alarming on anomalies*, and click *OK*.

   1. Select the checkbox in the *MON* column for the parameter *Encryption Key Requests*.

      This will enable alarm monitoring for this parameter.

   1. Scroll to the far right of the alarm template to find the *ANOMALIES* column.

      This column contains a button showing whether alarm monitoring on anomalies is currently enabled. By default, it will show *Disabled*.

   1. Click the button in the *ANOMALIES* column.

      This will open a new pop-up window where you can configure alarm monitoring for anomalies.

   1. In the dropdown box at the top, which by default shows *All disabled*, select *All smart*.

   1. Click *Close* to close the window.

   1. Click *OK* to save the alarm template.

      ![Anomaly alarm settings in DataMiner 10.3.12](~/user-guide/images/Anomaly_Alarming_Popup_All_Smart.gif)

      You have now enabled alarm monitoring for all types of anomalies detected on the parameter *Encryption Key Requests*. This means that anomalies that would previously be shown in the *Suggestion events* tab will now be shown in the *Active alarms* tab.

1. Simulate the data so anomalies are detected:

   1. In DataMiner Cube, select the element *Encryption Key Requests 2* in the Surveyor.

   1. Click the *Generate Data* button to generate data for the parameter *Encryption Key Requests*.

   1. Wait until the *Data Generated?* parameter displays *Yes*.

1. In the Alarm Console, check the *Active alarms* tab.

   ![Anomalies generated by "Encryption Key Requests 2" in the Active alarms tab](~/user-guide/images/Encryption_Key_Requests_Active_Alarms.gif)

   Two anomalies marked as critical will be displayed in the *Active alarms* tab. This severity is determined by how severe DataMiner considers the anomaly to be. Larger jumps will for instance be considered more severe than lower jumps. Note that the *Anomalies* tab, which you can open via the light bulb icon, still contains these events, while the *Suggestion events* tab now does not.

1. Double click one of the anomaly alarms to inspect the trend data.

   Note that the anomalies are now indicated in red at the bottom of the trend graph, corresponding to the critical severity of the alarm that was generated.

   ![Trend graph of the "Encryption Key Requests" parameter showing the anomalous region in red](~/user-guide/images/Encryption_Key_Requests_Trend_Graph_Alarms.gif)

## Step 5: Make DataMiner generate alarms for specific anomaly types

In some cases, it can be useful to only generate alarms for certain types of anomalies, for example the bit rate parameter from step 2 above. The jumps between different encoding bit rates might be expected, depending on the stream that gets encoded at that time, but you might want to get notified if the bit rate starts fluctuating a lot on a certain stream (e.g. because it is being encoded using a variable bit rate scheme instead of a constant bit rate scheme). You can do this by activating alarm monitoring for *variance changes* only:

1. Create an alarm template:

   1. Right-click the element *Audio bit rate (CBR-VBR)* in the Surveyor, and select *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.

   1. Specify a name for the alarm template, e.g. *Alarming on variance changes*, and click *OK*.

   1. Select the checkbox in the *MON* column for the parameter *Audio Bit Rate Channel 1*.

   1. Scroll to the far right of the alarm template to find the *ANOMALIES* column.

   1. Click the button in the *ANOMALIES* column.

   1. In the pop-up window, select *Variance increase* and *Variance decrease*.

      ![Configure alarming on variance increases and decreases](~/user-guide/images/Anomaly_Alarming_Popup_Variance_Changes.gif)

   1. Click *Close* to close the window.

   1. Click *OK* to save the alarm template.

1. Simulate the data so anomalies are detected:

   1. Select the element *Audio bit rate (CBR-VBR)* in the Surveyor.

   1. Click the *Generate Data* button to generate data for the parameter *Audio Bit Rate Channel 1*.

   1. Wait until the *Data Generated?* parameter displays *Yes*.

1. In the Alarm Console, check the *Active alarms* tab.

   A *variance increase* alarm will show up in this tab.

   ![Variance increase on "Audio bit rate (CBR-VBR)" in the Active alarms tab](~/user-guide/images/Audio_Bit_Rate_CBR_Alarm_Console_Variance_Increase.png)

1. Double-click the alarm.

   You will see that the alarm indeed corresponds to a region with a much higher fluctuation in bit rate than normal. Note that the other anomalies that are detected on the parameter only show up in the *Suggestion events* tab and not in the *Active alarms* tab.

   ![Trend graph of the "Audio Bit Rate Channel 1" parameter](~/user-guide/images/Audio_Bit_Rate_CBR_Trending_Variance_Increase.png)

> [!TIP]
> It would be very difficult to configure similar alarm monitoring behavior using static alarm thresholds. This shows the power of anomaly alarm monitoring for detecting sudden unexpected behavior. For a complete list of all options related to alarming on anomalies, see [Configuring anomaly detection alarms for specific parameters](xref:Configuring_anomaly_detection_alarms).

## Step 6: Set custom alarm thresholds

In the previous steps, DataMiner determined autonomously whether certain behavior was considered anomalous or not. This is definitely handy, as it requires very little configuration, but in some cases it might be required to give DataMiner a bit more input. In this step, you will configure specific thresholds for alarming on *level shifts* anomalies.

Let us look at the element *Cable Modems Out of Service*, containing a parameter representing the number of cable modems that are out of service at a CMTS. Press the *Generate Data* button and open the trend graph whenever the data generation is finished.

![Trend graph of 'Cable Modems Out of Service' without alarming configured](~/user-guide/images/CMOOS_Trend_Graph_No_Alarming.png)

As you can see, the data tends to follow a wave pattern with a low number of cable modems out of service during the day, and a high number at night. This is caused by a significant number of people turning off their cable modem at night, making the CMTS unable to connect to it. Moreover, in the last two days, you can see four periods where more modems were out of service than expected: the data suddenly jumps up with around 70 units before dropping again a few hours later. Unfortunately, DataMiner only detects the first and the third period as anomalous, as seen by the dark grey blocks in the trend graph. This is because DataMiner assumes too quickly that the observed behavior is not anomalous since it has seen it before.

The element *Cable Modems Out of Service 2* contains exactly the same data as above. You can configure thresholds for *level shift increase* anomalies in the alarm template so that alarms are generated during all four periods of anomalous behavior, as follows.

1. Right-click the element *Cable Modems Out of Service 2* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming with absolute thresholds*.
1. Turn on alarming on the parameter *Cable Modems Out of Service* by checking the box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it) and click the button in that column.
1. Check the box before *Level increases*.
1. In the drop-down list next to it, select *Absolute*.
1. Fill in 50 in the yellow box, corresponding to a major severity.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![Configure alarming on level increases of size 50 or higher](~/user-guide/images/Anomaly_Alarming_Popup_Level_Increase_50.gif)

Generate data on element *Cable Modems Out of Service 2* by pressing the corresponding button. When the data generation is done, open the trend graph. As you can see all four jumps upwards received a major alarm.

![Trend graph of 'Cable Modems Out of Service' with absolute thresholds configured for level shifts](~/user-guide/images/CMOOS_Trend_Graph_With_Absolute_Alarming.png)

That is great! However, one could argue that the third major alarm is less severe than the other three, as a lot of other cable modems are already offline when the jump happens. Indeed, hovering over the change point, we see that the parameter jumps from around 300 to around 385 at that point, representing an increase of around 28%, while the first, second and fourth jump represent increases of around 38%, 35% and 33%, respectively. Hence, we might only want a minor alarm for the third jump.

![Details of the third level shift, a jump from 301 to 386 units](~/user-guide/images/CMOOS_Trend_Graph_Details_Third_Level_Shift.png)

To generate this minor alarm, you can use *relative* thresholds, as follows.

1. Right-click the element *Cable Modems Out of Service 3* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming with relative thresholds*.
1. Turn on alarming on the parameter *Cable Modems Out of Service* by checking the box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it) and
click the button in that column.
1. Check the box before *Level increases*.
1. In the drop-down list next to it, select *Relative*.
1. Fill in 25 in the light blue box and 30 in the yellow box, corresponding to a minor and major severity, respectively.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![Configure alarming on level increases using relative thresholds](~/user-guide/images/Anomaly_Alarming_Popup_Level_Increase_Relative.gif)

Again, generate data on element *Cable Modems Out of Service 3* by pressing the corresponding button, and open the trend graph when the data generation is done. You should indeed see major alarms on the first, second and forth jump and a minor alarm on the third jump.

![Trend graph of 'Cable Modems Out of Service' with relative thresholds configured for level shifts](~/user-guide/images/CMOOS_Trend_Graph_With_Relative_Alarming.png)

In exactly the same way, one can configure alarming on *outlier* anomalies. A complete description can be found [here](xref:Configuring_anomaly_detection_alarms).

## Step 7: Final exercise

You have now learned everything there is to know about DataMiner's Behavioral Anomaly Detection features. But we have one last exercise for you, where you will need to apply everything you have learned earlier. Open the element *Signal Strength*. It represents the strength of a signal received by a satellite dish. Your task is to make sure alarms are generated when something goes wrong, without creating too many alarms.

As you can see on the image below, the data contains

- a period of about a week with higher fluctuations than normal, starting at October 11th on the picture,
- three short drops, on October 24th, October 25th and October 29th on the picture,
- two longer drops, on October 25th on the picture.

The alarms you have to generate for this exercise depend on your version of DataMiner. Note that the exercise for versions earlier than DataMiner 10.3.12 can also be done on a DataMiner version 10.3.12 or higher, but not the other way around. Remember that you can always duplicate the element to try a second time, if you did not yet reach optimal results on your first attempt.

You will have to configure the alarm template such that the following alarms are generated

- a *major* alarm for all three shorter drops,
- a *critical* alarm for both longer drops,
- a *critical* alarm at the start of the period with higher fluctuations.

Make sure that no extra alarm is generated. In particular, no alarm should be generated

- at the moment the higher fluctuations stop, around October 18th on the picture,
- for any other drop than indicated in the picture below.

Below is a picture of the situation you should achieve. Good luck!

![Trend graph of 'Signal strength' with the required alarms](~/user-guide/images/Signal_Strength_Goal.png)

If you complete one of the exercises above correctly, and send us a picture of the trend
graph along with a [.dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file) containing your element,
you will be rewarded with DevOps Points.

Adhere to the following email format:

- Subject: Tutorial - Anomalies tutorial
- To: [ai@skyline.be](mailto:ai@skyline.be)
- Body:
  - Exercise version: Mention whether you completed the exercise for DataMiner version 10.3.12 or higher, or for an earlier version (or both).
  - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email
  - Feedback (optionally): We value your feedback! Please share any thoughts or suggestions regarding this tutorial or the anomaly detection feature.
- Attachment:
  - A picture of the trend graph with the correct anomalies.
  - A [.dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file) containing your element with the correct alarms.

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.

### Look for anomalies detected in your operation

We believe DataMiner's behavioral anomaly detection feature will help you to detect incidents in your daily operation. However, no feature is perfect, and your feedback is always helpful! Help us by looking for a good example of a detected anomaly and/or an example where the detection can be improved (either no anomaly was detected, or an anomaly was detected for something that is not problematic). Send us your examples and be rewarded with DevOps Points.

Adhere to the following email format:

- Subject: Tutorial - Anomaly detection feedback
- To: [ai@skyline.be](mailto:ai@skyline.be)
- Body:
  - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
  - Feedback: Provide a short explanation of what we see on the examples you are sending us and why the detected anomaly is good or bad.
- Attachment:
  - A picture of the trend graph with the detected anomaly.
  - An [export of your trend graph](xref:Exporting_a_trend_graph) obtained by right-clicking the trend graph and selecting *Export to CSV*.

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of appreciation for your effort in helping to improve DataMiner.
