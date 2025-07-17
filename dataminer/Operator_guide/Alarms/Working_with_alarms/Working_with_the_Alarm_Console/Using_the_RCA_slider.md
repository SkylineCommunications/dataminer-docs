---
uid: UsingTheRCASlider
---

# Using the RCA slider

Alarms on elements, parameters or services included in a connectivity chain have an RCA level. This indicates how far the element, parameter or service is away from the most probable cause of the alarm. In the Alarm Console, it is possible to filter alarms based on Root Cause Analysis (RCA). This way, you can for instance filter out alarms with high RCA levels to get an overview of the root problems only.

![RCA Filter](~/dataminer/images/RCA_Filter.png)<br>*Alarm Console and RCA filter in DataMiner 10.4.5*

The levels are indicated as three values, separated by commas. The values represent, in sequence, the RCA level for services, elements, and parameters. Each value has the following meaning:

- none: not part of a connectivity chain.

- 0: there are no services/elements/parameters higher up in the chain that are in alarm state.

- 1: there is one service/element/parameters higher up in the chain that is in alarm state.

- 2: there are two services/elements/parameters higher up in the chain that are in alarm state.

- etc.

To filter alarms based on their RCA level:

1. Click the RCA slider in the alarm bar, indicated by the following icon: ![RCA slider icon](~/dataminer/images/RCA_Filter_icon.png)

1. Select the RCA level.

   To indicate that the RCA filter is applied, the alarm tab will be displayed with a blue background. The total number of alarms will still be indicated in the alarm bar, with the number of displayed filtered alarms in parentheses.

> [!NOTE]
> - Alarms without an RCA level will always be shown, regardless of the level of the RCA slider.
> - The setting of the RCA slider is a user setting per alarm tab that is remembered across sessions.
> - To have a look at the connectivity chain for a particular alarm, right-click the alarm and select *View connectivity*.

> [!TIP]
> See also: [Working with the Connectivity Editor](xref:Working_with_the_Connectivity_Editor)
