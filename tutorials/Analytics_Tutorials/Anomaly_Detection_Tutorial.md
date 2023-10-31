---
uid: Anomaly_Tutorial
---

# Detecting anomalies with DataMiner

This tutorial illustrates DataMiner's [Behavioral Anomaly Detection](xref:Working_with_behavioral_anomaly_detection)
features and teaches you how you can use it to detect and alarm on certain failures in your operation.

## Prerequisites

- DataMiner version 10.2.0 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a
  [self-hosted Cassandra-compatible databse](xref:Supported_system_data_storage_architectures).
  For step&nbsp;3, DataMiner 10.3.12 or higher is required.
- A recent Cube version (10.3.2343.2020 or higher)
- Install the package [Anomaly Detection Tutorial](https://catalog.dataminer.services/catalog/5467) from DataMiner Catalog
- If you changed the default settings:
  - Make sure Behavioral Anomaly Detection is turned on in *System Center* > *System settings* > *analytics config*.
  - Make sure [time to live](xref:Setting_the_default_sliding_window_size_for_real-time_trending)
    for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

The tutorial consists of the following steps.

1. [Getting to know anomaly detection](#step-1-getting-to-know-anomaly-detection)
1. [Creating alarms from anomalies](#step-2-creating-alarms-from-anomalies)
1. [Setting custom alarm thresholds](#step-3-setting-custom-alarm-thresholds-requires-dataminer-10312-or-higher) (requires DataMiner 10.3.12 or higher)
1. [Finishing excercise](#step-4-finishing-exercise)

## Step 1: Getting to know anomaly detection

In this step we will illustrate anomaly detection with a few examples, and walk you through where you can find
and follow up on the detected anomalies. By default, Behavioral Anomaly Detection is active on every trended
parameter
in your system (except for a few technical limitations, see [here](xref:Working_with_behavioral_anomaly_detection)). It
will monitor your parameters in real-time and it will notify you about anomalies as soon as it detects one. The
feature models the behavior of a parameter based on its recent history. In this tutorial, we
will make use of [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter)
to quickly simulate a parameter with historical trend data. Trending is already turned on by default on all parameters used
in this tutorial.

### Step 1.1: Anomalies in the trend graph

Now, let us look at an example.

1. Open the element *Audio bit rate*. It simulates a parameter monitoring the bit rate of an audio channel on an encoder.
1. Generate data for the parameter *Audio Bit Rate Channel 1* by pressing the *Generate Data* button.
1. Wait a few seconds until the *Data Generated?* parameters jumps to *Yes*.

> [!TIP]
> The protocols used in this tutorial can only load data for a parameter once. However, if you made a mistake or want
> to retry an exercise, you can rerun the simulation by [duplicating](xref:Duplicating_elements) the element
> and generating the data again on the duplicated element.

You have now loaded in data for the *Audio Bit Rate Channel 1* parameter. Let us have a look
[trend graph](xref:Manipulating_trend_graphs)
by pressing ![the trend icon](~/user-guide/images/trend_icon_unknown.png)
next to our parameter. Then, press 'Month to date' to have a look at the whole last month of data. As you can see,
the bitrate first remained stable around 96 kBps for the better part of two weeks before temporarily jumping up a few
times
to values around 256 kBps. Finally, after 5 jumps, there is one jump to over 1000 kBps.

![Audio bit rate with several jumps, some of which are marked as anomalous](images/Audio_bit_rate.gif)

Under each of the jumps up
and jumps down a little grey or black block is displayed. These blocks indicate the detection of a change in behavior,
called a **change point**. Hovering over the change point, you get a
little more detail such as the type of the change point (a *level shift* in this case). Typically, one will have to zoom
in to be able to see all details, such as the begin and end values (see the picture below).
You can find out more about the types of change points DataMiner detects on
[this page](xref:Working_with_behavioral_anomaly_detection).

![Zoomed in view of a change point to see all details](images/Audio_Bit_Rate_Trending_ChangePoint_Details.png)

Note that the blocks under the first two jumps have received a darker color than the subsequent ones. This is because
at the time the first jump occurs, the parameter has never had similar behavior before, and as such DataMiner's
anomaly detection algorithm marked the changepoint as an **anomaly**. By the time of the third jump, the algorthm has
seen sufficient similar behavior to not consider the behavior as anomalous anymore. However, the jump
towards the end is again considered anomalous, as it is much bigger than the previous ones.

### Step 1.2: Anomalies in the alarm console

Apart from these indication at the bottom of the trend graph, you can also find the recent anomalies in the alarm
console, allowing you to more easily monitor for anomalies across your entire system. Let us look at another example.

1. Open the element *Encryption Key Requests*, which simulates a parameter monitoring the number of encryption key
requests received per minute by a CAS server.
1. Generate data for the parameter *Encryption Key Requests* by pressing the *Generate Data* button.
1. Wait a few seconds until the *Data Generated?* parameters jumps to *Yes*.
1. In the header on the right-hand side of your alarm console, a [light bulb](xref:Light_Bulb_Feature) is now shown in
blue, indicating that it found something interesting. Click this light bulb.
1. A menu is now shown with (among others) an item saying '2 anomalies are found on your system' (or a higher number
if your system detected anomalies on other elements). Click this menu item.
1. A new tab called *Anomalies* is now shown in your alarm console containing two anomalies on our element
*Encryption Key Requests*.

![Anomaly tab in the alarm console showing the anomalies on 'Encryption Key Requests'](images/Encryption_Key_Requests_Lightbulb.gif)

By double clicking on one of the anomalies, you can view the trend graph of the parameter. As you can see, the
number of requests per minute remained relatively stable for a long time, but suddenly increased spectacularly a few
hours ago, possibly indicating some unexpected activity is going on in the network.

![The trend graph of the 'Encryption Key Requests' parameter showing the anomalous region](images/Encryption_Key_Requests_Trend_Graph.png)

Alternatively, you can also find the anomalies using the *Suggestion events* tab.

1. Press the plus icon in the header of the alarm console.
1. Under 'Show current', click 'Suggestion events'.
1. A new tab called 'Suggestion events' is now opened, containing the two anomalies on *Encryption Key Requests*.

This tab page shows more than only the anomalies. See [this page](xref:Advanced_analytics_features_in_the_Alarm_Console)
for more information on what other events are shown.

![Suggestion events tab in the alarm console showing the anomalies on 'Encryption Key Requests'](images/Encryption_Key_Requests_Suggestion_Events.gif)

## Step 2: Creating alarms from anomalies

As you have seen above, DataMiner detects anomalous behavior out-of-the-box and shows them in the trend graph
and in a separate tab in the alarm console. However, as these anomalies might flag potential problems in your operation,
it can be useful to show the detected events on a few critical parameters next to your other alarms. In this
step, we will show you how to do that.

### Step 2.1: Generating alarms from all anomalies on a parameter

Let us return to the previous example. The element *Encryption Key Requests 2* is a copy generating
the exact same data as *Encryption Key Requests*.
Create an [alarm template](xref:About_alarm_templates) so that the anomalies detected
on this parameter are shown in the *Active alarms* tab as follows.

### [DataMiner 10.3.12 or higher](#tab/all-smart-new-version)

1. Right-click the element *Encryption Key Requests 2* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming on anomalies*.
1. Turn on alarming on the parameter *Encryption Key Requests* by checking the corresponding box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it).
It contains a button showing whether alarming on anomalies is currently
enabled. By default, it will show *Disabled*.
1. Click the button in the *ANOMALIES* column. This will open a new pop-up window to configure
alarming on anomalies.
1. From the drop-down list saying *All disabled* at the top, select *All smart*.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![The pop-up to configure alarming on anomalies on DataMiner 10.3.12 or higher](images/Anomaly_Alarming_Popup_All_Smart.gif)

### [Earlier versions](#tab/all-smart-old-version)

1. Right-click the element *Encryption Key Requests 2* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming on anomalies*.
1. Turn on alarming on the parameter *Encryption Key Requests* by checking the corresponding box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it).
It contains a button showing whether alarming on anomalies is currently
enabled. By default, it will show *Disabled*.
1. Click the button in the *ANOMALIES* column. This will open a new pop-up window to configure
alarming on anomalies.
1. From the drop-down list saying *All disabled* at the top, select *All enabled*.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![The pop-up to configure alarming on anomalies on earlier DataMiner versions than 10.3.12](images/Anomaly_Alarming_Popup_All_Smart_Legacy.gif)

***

You have now enabled alarming on all types of anomalies detected on the parameter *Encryption Key Requests*. This means
that the anomalies that would previously be shown in the *Suggestion events* tab, will now be shown in the active alarms
tab. Now, simulate the data by pressing the *Generate data* button on *Encruption Key Requests 2*.

![Anomalies generated by 'Encryption Key Requests 2' in the active alarms tab](images/Encryption_Key_Requests_Active_Alarms.gif)

Again, two anomalies are generated, but now they appear in the *Active alarms* tab, and they are marked as critical.
The severity is determined by how severe DataMiner considers the anomaly to be. Larger jumps will for instance be
considered more severe than lower jumps.
Note that the *Anomalies* tab, opened via the Light Bulb icon, still contains these events, while the
*Suggestion events* tab does not.

Again, you can inspect the trend data by double-clicking the alarm. Note that the anomalies are now indicated in red
at the bottom of the trend graph, corresponding to the critical severity of the alarm that was generated.

![The trend graph of the 'Encryption Key Requests' parameter showing the anomalous region in red](images/Encryption_Key_Requests_Trend_Graph_Alarms.gif)

### Step 2.2: Generating alarms from specific anomaly types

In some cases, it can be useful to only generate alarms from certain types of anomalies. Consider for instance
the bitrate parameter from Step 1.1. The jumps between different encoding bitrates might be expected, depending
on the stream that gets encoded at that time.
However, we might want to get notified if the bitrate starts fluctuating a lot on a certain stream (e.g.
because it is being encoded using a variable bit rate scheme instead of an constant bit rate scheme).
We can do that by turning on alarming only for *variance changes*, as follows.

### [DataMiner 10.3.12 or higher](#tab/variance-change-new-version)

1. Right-click the element *Audio bit rate (CBR-VBR)* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming on variance changes*.
1. Turn on alarming on the parameter *Audio Bit Rate Channel 1* by checking the box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it) and
click the button in that column.
1. In the pop-up that shows up, check the boxes before *Variance increase* and *Variance decrease*.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![Configure alarming on variance increases and decreases](images/Anomaly_Alarming_Popup_Variance_Changes.gif)

### [Earlier versions](#tab/variance-change-old-version)

1. Right-click the element *Audio bit rate (CBR-VBR)* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming on variance changes*.
1. Turn on alarming on the parameter *Audio Bit Rate Channel 1* by checking the box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it) and
click the button in that column.
1. In the pop-up that shows up, click the button next to *Variance change* to switch it to *Enabled*.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![Configure alarming on variance increases and decreases](images/Anomaly_Alarming_Popup_Variance_Changes_Legacy.gif)

***

Now, simulate the data by pressing *Generate Data* on *Audio bit rate (CBR-VBR)*. After a few seconds, a
*variance increase* alarm will show up in the *Active alarms* tab.

![A variance increase on 'Audio bit rate (CBR-VBR)' in the active alarms tab](images/Audio_Bit_Rate_CBR_Alarm_Console_Variance_Increase.png)

By double-clicking the alarm, you will see that it indeed
corresponds
to a region with a much higher fluctuation in bit rate than normal. Note that the other anomalies that are detected on
the parameter only show up in the *Suggestion events* tab and not in the *Active alarms* tab.

![The trend graph of the 'Audio bit rate' parameter on 'Audio bit rate (CBR-VBR)'](images/Audio_Bit_Rate_CBR_Trending_Variance_Increase.png)

Note that it would not be easy, or even next to impossible to configure similar alarming behavior in the examples above
using static alarm thresholds. This shows the power of alarming on anomalies for detecting sudden unexpected behavior.
For a complete list of all options related to alarming on anomalies, see
[Configuring anomaly detection alarms for specific parameters](xref:Configuring_anomaly_detection_alarms).

## Step 3: Setting custom alarm thresholds (requires DataMiner 10.3.12 or higher)

In the previous steps, DataMiner determined autonomously whether certain behavior was considered anomalous or not.
This is definitely handy, as it requires very little configuration, but in some cases it might be required to give
DataMiner a bit more input. In this step, you will configure specific thresholds for alarming on *level shifts*
anomalies.

Let us look at the element *Cable Modems Out of Service*, containing a parameter representing the number of
cable modems that are out of service at a CMTS. Press the *Generate Data* button and open the trend graph
whenever the data generation is finished.

![Trend graph of 'Cable Modems Out of Service' without alarming configured](images/CMOOS_Trend_Graph_No_Alarming.png)

As you can see, the data tends to follow a wave pattern with a low number of cable modems out of service during a day,
and a high number at night.
This is caused by a significant number of people turning off their cable modem at night, making the CMTS unable
to connect to it. Moreover, in the last 2 days, you can see four periods where more modems were out of service than
expected: the data suddenly jumps up with around 70 units before dropping again a few hours later.
Unfortunately, DataMiner only detects the first and the 3rd period as anomalous, as seen by the dark grey
blocks in the trend graph. This is because DataMiner assumes too quickly that the observed behavior is not anomalous
since it has seen it before.

The element *Cable Modems Out of Service 2* contains exactly the same data as above. You can configure thresholds
for *level shift increase* anomalies in the alarm template
so that alarms are generated during all four periods of anomalous behavior, as follows.

1. Right-click the element *Cable Modems Out of Service 2* in the surveyor.
1. Go to *Protocols & Templates* > *Assign alarm templates* > *New alarm template*.
1. Give your alarm template a name, e.g. *Alarming with absolute thresholds*.
1. Turn on alarming on the parameter *Cable Modems Out of Service* by checking the box in the Monitored (*MON*) column.
1. Look for the column *ANOMALIES* on the right-hand side (you might have to scroll to the right to see it) and
click the button in that column.
1. Check the box before *Level increases*.
1. In the drop-down list next to it, select *Absolute*.
1. Fill in 50 in the yellow box, corresponding to a major severity.
1. Press *Close* to close the pop-up.
1. Press *OK* to save the alarm template.

![Configure alarming on level increases of size 50 or higher](images/Anomaly_Alarming_Popup_Level_Increase_50.gif)

Generate data on element *Cable Modems Out of Service 2* by pressing the corresponding button.
When the data generation is done, open the trend graph. As you can see all four jumps upwards received a major alarm.

![Trend graph of 'Cable Modems Out of Service' with absolute thresholds configured for level shifts](images/CMOOS_Trend_Graph_With_Absolute_Alarming.png)

That is great! However, one could argue that the third
major alarm is less severe than the other three, as a lot of other cable modems are already offline when the jump
happens. Indeed, hovering over the change point, we see that the parameter jumps from around 300 to around 385 at that
point, representing an increase of around 28%,
while the first, second and fourth jump represent increases of around 38%, 35% and 33%, respectively. Hence, we might
only want a minor alarm for the third jump.

![Details of the third level shift, a jump from 301 to 386 units](images/CMOOS_Trend_Graph_Details_Third_Level_Shift.png)

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

![Configure alarming on level increases using relative thresholds](images/Anomaly_Alarming_Popup_Level_Increase_Relative.gif)

Again, generate data on element *Cable Modems Out of Service 3* by pressing the corresponding button, and open the trend
graph when the data generation is done. You should indeed see major alarms on the first, second and forth jump
and a minor alarm on the third jump.

![Trend graph of 'Cable Modems Out of Service' with relative thresholds configured for level shifts](images/CMOOS_Trend_Graph_With_Relative_Alarming.png)

In exactly the same way, one can configure alarming on *outlier* anomalies. A complete description can be found
[here](xref:Configuring_anomaly_detection_alarms).

## Step 4: Finishing exercise

You have now learned everything there is to know about DataMiner's Behavioral Anomaly Detection features. But, we have one
last exercise for you, where you will need to apply everything you have learned today! Open the element
*Signal Strength*. It represents the strength of a signal received by a sattelite dish. Your task is to make sure
alarms are generated when something goes wrong, without creating too many alarms.

As you can see on the image below, the data contains

- a period of about a week with higher fluctuations than normal, starting at October 11th on the picture,
- three short drops, on October 24th, October 25th and October 29th on the picture,
- two longer drops, on October 25th on the picture.

The alarms you have to generate for this exercise depend on your version of DataMiner. Note that the version for versions ealier
than DataMiner 10.3.12 can also be done on a DataMiner version 10.3.12 or higher, but not the other way around.
Remember that you can always duplicate the element to try a second time, if you did not yet reach optimal
results on your first attempt.

### [DataMiner 10.3.12 or higher](#tab/exercise-new-version)

You will have to configure the alarm template such that alarms the following alarms are generated

- a *major* alarm for all three shorter drops,
- a *critical* alarm for both longer drops,
- a *critical* alarm at the start of the period with higher fluctuations.

Make sure that no extra alarm is generated. In particular, no alarm should be generated

- at the moment the higher fluctuations stop, around october 18th on the picture,
- for any other drop than indicated in the picture below.

Below is a picture of the situation you should achieve. Good luck!

![Trend graph of 'Signal strength' with the required alarms](images/Signal_Strength_Goal.png)

### [Earlier versions](#tab/exercise-old-version)

You will have to configure the alarm template such that the alarms are generated for both longer drops, but no
alarm is generated for the higher fluctuations, or the shorter drops.

The severity of the generated alarms does not matter for the exercise. Below is a picture of the situation you should achieve. Good luck!

![Trend graph of 'Signal strength' with the required alarms](images/Signal_Strength_Goal_legacy.png)

***

If you complete one of the exercises above correctly, and send us a picture of the trend
graph along with a [.dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file) containing your element,
you will be rewarded with DevOps Points.

Adhere to the following email format:

- Subject: Tutorial - Anomalies tutorial
- To: [ai@skyline.be](mailto:ai@skyline.be)
- Body:
  - Exercise version: Mention whether you completed the exercise for DataMiner version 10.3.12 or higher, or for
    an earlier version (or both).
  - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using
    a different email addess to send this email
  - Feedback (optionally): We value your feedback! Please share any thoughts or suggestions regarding this tutorial or
    the anomaly detection feature.
- Attachment:
  - A picture of the trend graph with the correct anomalies.
  - A [.dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file) containing your element with the correct alarms.

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as
a token of your accomplishment.

### Look for anomalies detected in your operation

We believe DataMiner's behavioral anomaly detection feature will help you to detect incidents in your daily operation.
However, no feature is perfect and your feedback is always helpful! Help us by looking for a good example of a detected
anomaly and/or an example where the detection can be improved (either no anomaly was detected, or an anomaly was detected
for something that is not problematic). Send us your examples and be rewarded with DevOps Points.

Adhere to the following email format:

- Subject: Tutorial - Anomaly detection feedback
- To: [ai@skyline.be](mailto:ai@skyline.be)
- Body:
  - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using
    a different email addess to send this email.
  - Feedback: Provide a short explanation of what we see on the examples you are sending us and why the detected anomaly
    is good or bad.
- Attachment:
  - A picture of the trend graph with the detected anomaly.
  - An [export of your trend graph](xref:Exporting_a_trend_graph) obtained by right-clicking the trend graph and
    selecting *Export to CSV*.

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as
a token of appreciation for your effort in helping improving DataMiner.
