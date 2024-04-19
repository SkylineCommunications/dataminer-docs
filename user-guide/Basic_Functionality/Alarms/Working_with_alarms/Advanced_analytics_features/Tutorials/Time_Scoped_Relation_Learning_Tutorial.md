---
uid: Time_Scoped_Relation_Learning_Tutorial
---

# Gain insights using Time-Scoped Relation Learning

Estimated duration: 20 minutes.

This tutorial walks you through the use of DataMiner's [Time-Scoped Relation Learning](xref:Working_with_behavioral_anomaly_detection). You will select a time range where a certain parameter seems to be misbehaving and DataMiner will automatically lead you to the root cause of the problem.

To detect unexpected behavior, DataMiner first needs to learn the normal behavior of a parameter, so we will make use of [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter) to push in historical trend data. We have enabled trending on the parameters used in this tutorial.

> [!TIP]
>
> - See also: [Kata #28: "Automated Relation Learning for Seamless Root Cause Analysis"](https://community.dataminer.services/courses/kata-28/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- DataMiner 10.3.8 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Behavioral Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 2 weeks for minute records.

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Discover anomaly detection in trend graphs](#step-2-discover-anomaly-detection-in-trend-graphs)
- [Step 3: Discover the proactive cap detection functionality](#step-3-discover-the-proactive-cap-detection-functionality)
- [Step 4: Find the root cause manually: an easy use case](#step-4-discover-the-root-cause-manually-for-an-easy-use-case)
- [Step 5: Use time-scoped Relation Learning to deal with more complicated use cases](#step-5-use-time-scoped-relation-learning-to-deal-with-more-complicated-use-cases)
- [Step 6: Final exercise](#step-6-final-exercise)

## Step 1: Install the example package from the catalog

1. Go to <https://catalog.dataminer.services/details/package/6057>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button. (Alternatively, download the item and install it manually.)

   This will create an element named *Relation Learning Tutorial - Kata Relation Learning* in your system that will be used throughout the rest of the tutorial. The element will be located in the view *DataMiner Catalog* > *Augmented Operations* > *Relation Learning Tutorial*.
   
## Step 2: Discover anomaly detection in trend graphs

1. In DataMiner Cube, select the element *Relation Learning Tutorial - Kata Relation Learning* in the Surveyor.

   This element shows the available physical memory on a fictitious server and its task manager table, showing the memory usage of various processes running on that server.

1. Click the *Generate Data* button to push in historical trend data.
    
   > [!NOTE]
   > When pressing the run button, you should see something happening within 10 seconds. A lot of historical trend data will now be pushed through DataMiner and analyzed in real-time.

   > [!NOTE]
   > The protocols used in this tutorial can only load data for a parameter once. If you have made a mistake or want to retry an exercise, you can rerun the simulation by [duplicating](xref:Duplicating_elements) the element and generating the data again on the duplicated element.

1. Wait until the *Data Generated?* parameter displays *Yes*.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Available Physical Memory* parameter.

1. Click *Month to date* at the top right to see the trend data for the past month.

   The available physical memory seemed quite stable at first but during the last 10 days you can see three anomalous events:
   a temporary decrease of the memory, a permanent decrease and finally a decreasing trend in the memory.

   Under each of the behavioral changes, a grey block is displayed. These blocks indicate a detected change in behavior, or **change point**.

 1. Hover the mouse pointer over a change point to see more detail about the type of change point (e.g. a level shift). If necessary, zoom in to see all details, such as the begin and end value of the change.

   ![Available physical memory: investigate behavioral changes (as in DataMiner Version 10.4.0)](~/user-guide/images/ExploreChangePoints.gif)

   > [!TIP]
   > For more information on the possible types of change points, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection)


## Step 3: Discover the proactive cap detection functionality

The main topic for this tutorial is Relation Learning, but this use case also offers an ideal opportunity to say a few words about the proactive cap detection functionality. As you can see, the available physical memory parameter is getting dangerously close to 0MB. DataMiner knows however that a free memory parameter is not allowed to go below zero, so without doing any configuration work, DataMiner can warn you about this behavior ahead of time.
  
1. Click the light bulb icon in the top-right corner of the Alarm Console.

   This icon lights up in blue to indicate that DataMiner Analytics found something interesting. For more detailed info, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).
1. A menu opens: select the entry referring to alarms being predicted in the near future.

    A new tab opens in the alarm template, displaying a list of predicted issues.
1. In the list, look for the event related to the Available Physical Memory of our Relation Learning Tutorial element.

    The event shows an estimate of when the system will run out of memory.
1. Double click the event to automatically open the trend graph of the parameter in question.

   ![Available physical memory: investigate the proactive alarm (as in DataMiner Version 10.4.0)](~/user-guide/images/ProactiveAlarm.gif)

## Step 4: Discover the root cause manually for an easy use case

It is now time to investigate the memory leak problem, causing our system to run out of memory. To do so, we do not need any
fancy techniques:

 1. From the trend graph of the *Available Physical Memory* parameter, hit the *Up to Data Display* button in the top left.
 1. Browse through the list of processes to find the one using the most memory: the *MyStockController* process seems to be our culprit.
 1. Open the trend graph of the memory usage of this process.
 1. Hit *Week to date* to see that this process started leaking memory about three days ago.
 1. Compare this trend graph with the trend graph of the *Available Physical Memory*.
 
    You will see that the *Available Physical Memory* started dropping just when the *MyStockController* memory started to leak. Culprit found!
   
   ![Manual root cause analysis for a memory leak (as in DataMiner Version 10.4.0)](~/user-guide/images/MemoryLeakManualResolution.gif)

## Step 5: Use time-scoped Relation Learning to deal with more complicated use cases

It was easy to solve the previous use case manually as it was quite extreme and still ongoing (ie we could check the current values
to easily find the culprit). This method would not work when we would be investigating issues that occurred for example
one week ago or when the issue was more subtle. 

To tackle a more difficult problem, let us focus on the permanent drop in *Available Physical Memory* that happened about a week ago.

1. Open the trend graph of the *Available Physical Memory* parameter.
1. Click *Month to date* to see data for the past month.
1. Look for the region where the *Available Physical Memory* parameter shows a permanent drop (about a week ago)
1. Either press control and select the area of the trend graph containing the drop or click the grey box under the drop
(the one that represents the change point related to this drop as explained in [Step 2](#step-2-discover-anomaly-detection-in-trend-graphs))

    This creates an overlay showing 3 buttons.

1. Click the lightbulb

    DataMiner is proposing to add the memory usage of the Java Runtime to the trend graph.
1. Click *Add 'Task manager: Memory Usage Java runtime' of 'Relation Learning Tutorial - Kata Relation Learning' to trend graph.*
1. Notice that we have found our culprit: the Java Runtime started taking more memory just when the *Available Physical Memory* went down.

   ![Use Time-scoped relation learning to find the root cause of a permanent memory drop (as in DataMiner Version 10.4.0)](~/user-guide/images/MemoryIssueSolveUsingTSR.gif)

## Step 6: Final exercise

Time to show what you learned! The *Available Physical Memory* parameter has another strange behavior: a temporary drop in memory about 10 days ago.
Which process was responsible for this? Can you crack the case, earning you at least 75 juicy devops points?

> If you are a member of the DevOps Program and you have completed the exercise above, send us an email to get DevOps Points.
>
> Use the following email format:
>
> - Subject: Tutorial - Relation Learning Tutorial - *** (but replace *** with the process that caused the temporary memory drop
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email
>   - If possible, add a screen shot containing the trend graph of both the *Available Physical Memory* and the memory usage of the process causing the issue.
>   - Feedback (optionally): We value your feedback! Please share any thoughts or suggestions regarding this tutorial or the anomaly detection feature.
> 
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.

> [!IMPORTANT]
> We want to keep improving our relation learning features, and your feedback is very helpful for this. That is why you can also earn DevOps points by sending us examples where Relation Learning helped you solve a problem or examples where Relation Learning didn't perform as well as you had hoped.
>
> Use the following email format to send us your examples:
>
> - Subject: Tutorial - Relation Learning Feedback
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback: Provide a short explanation of what is shown in the examples you are sending us and why Relation Learning was useful or not.
>   - A screen shot referring to this use case
>
> Skyline will review your submission. Upon successful validation, you will be awarded the DevOps Points.
