---
uid: Connector_help_Sky_UK_Service_Alarm_Workflow
---

# Sky UK Service Alarm Workflow

This connector can be used to create an enhanced service that monitors specific elements. All the alarms of the elements will be displayed in a single table, the ALPB Table. The end result of this monitoring and the triggered alarm are determined based on the conditions in the Workflow Logic Table, which can use any parameter from any element.

## About

This connector uses a subscription mechanism that will update the Parameter Value column in the Subscription Table every time a parameter changes in an element included in the enhanced service.

The parameters must be selected when the service is created. First you will need to select the target elements and then the target parameters from each element. After this, the connector will automatically assign a subscription name to specific parameters. The subscription name works as an alias that can be used in the Condition column of the Workflow Logic Table and Input Faults Table. Note that every subscription name that is used in the Workflow Logic Table should be also present in the Subscriptions Table. Otherwise, the condition will be considered invalid and it will not be taken into account in the workflow.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. | No                  | Yes                     |

## Installation and configuration

### Creation

When you create the service, you should select the elements and parameters to include in the service. You can select any parameter according to your preferences.

The following table shows the default configuration:

| **Protocol**                                 | **Description**                         | **Subscription Name**           |
|----------------------------------------------|-----------------------------------------|---------------------------------|
| Imagine Communications EPIC MV (Primary)     | Audio Low State                         | AudioQuietStatePrimary          |
| Imagine Communications EPIC MV (Primary)     | Audio Peak State                        | AudioLoudStatePrimary           |
| Imagine Communications EPIC MV (Primary)     | Audio Silence State                     | AudioSilenceStatePrimary        |
| Imagine Communications EPIC MV (Primary)     | Video Black State                       | VideoBlackStatePrimary          |
| Imagine Communications EPIC MV (Primary)     | Video Freeze State                      | VideoFreezeStatePrimary         |
| Imagine Communications EPIC MV (Primary)     | Video Lost State                        | VideoLossStatePrimary           |
| Imagine Communications EPIC MV (Alternative) | Audio Low State                         | AudioQuietStateAlt              |
| Imagine Communications EPIC MV (Alternative) | Audio Peak State                        | AudioLoudStateAlt               |
| Imagine Communications EPIC MV (Alternative) | Audio Silence State                     | AudioSilenceStateAlt            |
| Imagine Communications EPIC MV (Alternative) | Video Black State                       | VideoBlackStateAlt              |
| Imagine Communications EPIC MV (Alternative) | Video Freeze State                      | VideoFreezeStateAlt             |
| Imagine Communications EPIC MV (Alternative) | Video Lost State                        | VideoLossStateAlt               |
| Axon GXG110                                  | SDI 1 De-Embedder Format 01/02 (GXG110) | FrameSyncAudioFormat0102        |
| Axon GXG110                                  | Signal Input 1 (GXG110)                 | FrameSyncSignalInput1           |
| Axon 2HX10                                   | Audio A1                                | PostClarityAudioChannel1AStatus |
| Axon 2HX10                                   | Audio A2                                | PostClarityAudioChannel2AStatus |
| Axon 2HX10                                   | Audio B1                                | PostClarityAudioChannel1BStatus |
| Axon 2HX10                                   | Audio B2                                | PostClarityAudioChannel2BStatus |
| Axon 2HX10                                   | Black-A                                 | PostClarityBlackAStatus         |
| Axon 2HX10                                   | Black-B                                 | PostClarityBlackBStatus         |
| Axon 2HX10                                   | Format A                                | PostClarityFormatA              |
| Axon 2HX10                                   | Format B                                | PostClarityFormatB              |
| Axon 2HX10                                   | Freeze-A                                | PostClarityFreezeAStatus        |
| Axon 2HX10                                   | Freeze-B                                | PostClarityFreezeBStatus        |
| Axon 2HX10                                   | Active A                                | PostClaritySwitchActiveA        |
| Sky UK VICC                                  | Type of Material                        | OnAirEventTypeOfMaterial        |
| Sky UK VICC                                  | End Type                                | OnAirEventEndType               |
| Sky UK SSR                                   | Service Key (Current Events) \[IDX\]    | CurrentEventScheduledServiceKey |
| Sky UK SSR                                   | Sound Type (Current Events)             | CurrentEventScheduledSoundType  |
| Axon ACP - GDR26                             | Active A (GDR26)                        | MainReserveSwitchActiveA        |

Note that when a different parameter is included, the connector will set a generic subscription name (e.g. S1).

If the Service Status parameter from BSS Schedule Data - Bus is included, this workflow will not trigger any alarms when this is *Off-Air*. If the parameter has a different value (*NA* or *On-Air*), or if this parameter is not included, the workflow will run as expected.

## Usage

By default, each service has a **Devices** section, listing the elements and parameters included in the service. If the Sky UK Service Alarm Workflow service definition has been assigned to a service, it also has a **Summary** section, which contains the enhancements included in this service definition. Within this section, you will find the pages detailed below.

### Alarms

On this page, you can find the **ALPB Table**, with the Index, Cause, Suggested Action, Alarm State, Alarm Target UI, Channel Name, Short Description and Cause of Alarm columns.

In the Cause and Short Description columns, the string \[Audio/Video\] can be different according to the detected fault. If an audio fault is detected, \[Audio/Video\] will change to Audio. If a video fault is detected, \[Audio/Video\] will change to Video. If both are detected, \[Audio/Video\] will change to Audio/Video.

### Input Faults

This page contains information about the detected faults and the delays configured for each fault. When a fault is detected, a timer starts counting, decreasing the Time Remaining parameter value every second. When Time Remaining is 0, the fault is considered active and the workflow will continue.

Each sub-genre has a specific delay value. The **SSR Service Key** and **SSR Genre** parameters show the sub-genre and service key used. These parameters are updated every time a fault is detected.

With the **Single Path Delay** parameter, you can configure a delay before the alarm is triggered in case of a single fault (on Alt or Primary).

When no SSR data are available (for example in the case of NBCU), the **SSR Genre Delay** can be disabled. In that case, you need to fill in a **General Content Delay** value and this value will be used as the Total Time in the Input Fault Table.

In the **Input Fault Table**, you will find the alarms Black on Alt, Black on Primary, Freeze on Alt, Freeze on Primary, Loud on Alt, Loud on Primary, Quiet on Alt , Quiet on Primary, Silence on Alt and Silence on Primary. These can be mapped to the subscription selected in the **Subscription Name** column. The **Delay Status** column will display the status of this delay: *Ready* means it has not been triggered yet, *Waiting* means it is currently running, *Expired* means it has already been triggered and reached 0. **Time Remaining** is the remaining time that is needed to wait until the fault becomes active. **Total Time** is the total delay time configured for this alarm. Time Remaining and Total Time are updated every time a fault is detected.

### Admin

This page contains configurable parameters related to the service and information about the elements in the service.

The **Mixer Chain** and **Service Probe At Clarity Bypass?** parameters can be set to *Yes* or *No*, according your system configuration.

**Debug Logging** allows you to enable or disable detailed logging while the service is working. Enabling this parameter is recommended when you suspect that there is an issue with the service.

**Service Element Status** shows an overview of the status of the elements included in the service.

### Subscriptions

This page contains the **Subscription Table** and **ReSub** action button.

The **Subscription Table** lists the parameters included in this enhanced service. Its primary key is the **Source Key**, which is a concatenation of the DataMiner ID, element ID, parameter ID and row key filter of the parameter, separated by a forward slash. The display key is a concatenation of the subscription name and source key of the parameter, separated by a colon. The table also displays the **Protocol Name**, **Element Name**, **Parameter Description** and **Parameter Value**. The parameter value is always displayed as a string, even if it is a numeric parameter. The **Subscription Name** works as an alias to be used in the Condition column of the **Workflow Logic Table** and **Input Faults Table**.

### Workflow Logic

This page contains **Workflow Logic Table** and **Refresh Logic Values** action button.

The **Workflow Logic Table** has the following columns:

- **Process**: Description of the condition defined for this workflow.
- **Condition**: The logical expression that will determine the condition value. The logical expressions used in this column need to respect the format "\<A\>or\<B\>or\<C\>;A\|S1=12;B-\|S2=3;C\|S1=5", where A, B and C are groups, which are defined with simple logical conditions. The allowed logical operators for groups are AND, OR and NOT. For conditions, the following operators are allowed: Equal "=", Not Equal "!=", Greater "\>", Minor "\<", Greater and Equal "\>=", and Minor and Equal "\<=". You can also make a condition based on another subscription value, e.g. "\<A\>;A\|S1=S2".
- **Value**: The value of the current condition (*Yes* or *No*).

### General Parameters

This page shows the value of the general parameters of the service.
