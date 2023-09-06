---
uid: Connector_help_Sky_UK_Subtitles_Workflow
---

# Sky UK Subtitles Workflow

This driver can be used to create an enhanced service that allows you to monitor issues in subtitles for a specific channel. Alarms can be triggered depending on the conditions in the Workflow Logic Table.

Any parameter from any element can be included in the service and used in the Workflow Logic Table.

This driver uses a subscription mechanism that will update the Parameter Value column in the Subscription Table every time a parameter changes in a child element. These parameters must be selected when the service is created.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

To use this driver, create a service that uses it as its service definition. Then select the child elements and the parameters of these elements that should be included in the service. You can select any parameter according to your preferences. This service needs the VICC element for the target channel to monitor and also SSR and Axon HSI10 elements.

This is the default service configuration:

| **Driver**                             | **Description**                                                   | **Subscription Name**          |
|----------------------------------------|-------------------------------------------------------------------|--------------------------------|
| Axon ACP - HSI10                       | Slot Status 0                                                     | InserterSlot0Status            |
| Axon ACP - HSI10                       | Protocol Status                                                   | InserterProtocolStatus         |
| Axon ACP - GDR26                       | Active A                                                          | MainReserveSwitchActiveA       |
| Imagine Multiviewer EPIC MV            | Video Teletext Missing State                                      | VideoTeletextMissingState      |
| Sky UK SSR or Sky UK NBCU Raw Schedule | Subtitle Hearing (Current Events)OnAir Subtitles (Now Next Table) | CurrentEventSubtitleFlag       |
| Sky UK VICC                            | Type Of Material                                                  | OnAirEventTypeOfMaterial       |
| Sky UK VICC                            | Subtitles File ID                                                 | OnAirEventSubtitleFileId       |
| Sky UK VICC                            | End Type                                                          | OnAirEventEndType              |
| Sky UK VICC                            | Video Item                                                        | OnAirEventVideoItem            |
| Cavena Subtitle Unit                   | Subtitle File ID (Event)                                          | SubtitleUnitFileId             |
| Cavena Subtitle Unit                   | Valid (Timecode)                                                  | SubtitleUnitTimecodeValidState |
| Cavena Subtitle Unit                   | Status (Event)                                                    | SubtitleUnitOnAir              |
| Cavena Subtitle Unit                   | Message (Event)                                                   | SubtitleUnitMessage            |

The driver will automatically assign a subscription name to specific parameters. This subscription name works as an alias that can be used in the Condition column of the Workflow Logic Table and Input Faults Table. Every subscription name that is used in the Workflow Logic Table should be also present in the Subscriptions Table. If this is not the case, the driver will assume that the condition is invalid and it will be considered false in the workflow. If you include a parameter that is not listed above, the driver will set a generic subscription name (e.g. S1).

If the **Service Status** parameter from BSS Schedule Data - Bus is added, this workflow will not trigger any alarms if this parameter is set to *Off-Air*. If it is set to *NA* or *On-Air*, or if this parameter is not included, the workflow will run as expected.

Axon ACP - HSI10 parameters can be omitted in case there is no HSI10 card present in the chain. In that case, make sure that the parameter **Is there a HSI10 and a Cavena?** on the **Admin** page is set to *No*, as otherwise this workflow can trigger an unexpected alarm.

## How to Use

A service created using this driver will have the data pages detailed below.

### Alarms

This page contains the **ALPB** **Table**, with the Index, Cause, Suggested Action, Alarm State, Alarm Target UI, Channel Name and Short Description columns.

### Admin

On this page, you can configure the service and check information related to its child elements.

- **Is there a HSI10 and a Cavena?** should be set to *Yes* or *No* depending on your system configuration (see "Configuration" section above).
- **Debug Logging** allows you to enable or disable detailed logging while the service is working, which can be useful in case you suspect the service is not working correctly
- **Service Element Status** shows an overview of the status of the service child elements.

### Subscriptions

This page contains the **Subscription Table** and **ReSub** action button.

The **Subscription Table** lists all the parameters within this enhanced service. The primary key of the table is the **SourceKey**, which is a string concatenation of the DataMiner ID, element ID, parameter ID and row key filter of each parameter, with a forward slash ("/") as separator. The **Display Key** column contains the display key of the table, which is a string concatenation of the subscription name and SourceKey of each parameter, with a colon (":") as separator. For each parameter, the table also displays information about the Protocol Name, Element Name, Parameter Description and Parameter Value. The latter is always displayed as a string, even if it is a numeric parameter. **Subscription Name** works as an alias that should be used in the Condition column of the **Workflow Logic Table**.

### Workflow Logic

This page contains the **Workflow Logic Table** and **Refresh Logic Values** action button.

The **Workflow Logic Table** has the following columns:

- **Process**: Description of the condition defined for this workflow
- **Condition**: The logical expression that will determine the value of the condition.The logical expressions used in the Condition column need to use the following format: "\<A\>or\<B\>or\<C\>;A\|S1=12;B-\|S2=3;C\|S1=5", where A, B and C are groups, which are defined with simple logical conditions. The allowed logical operators for groups are AND, OR and NOT. For conditions, the allowed operators are: Equal: "=", Not Equal:"!=", Greater: "\>", Minor: "\<", Greater and Equal: "\>=" and Minor and Equal: "\<=". A condition can also be made based on another subscription value, e.g. "\<A\>;A\|S1=S2".
- **Value**: The current value of the condition (*Yes* or *No*).

### General Parameters

This page contains the general parameters of the service.

### INCLUDED - IN USE

This page lists the elements that are included in the service, with their included parameters, detailing where those parameters are located in the elements.
