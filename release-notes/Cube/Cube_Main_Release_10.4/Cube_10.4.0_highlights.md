---
uid: Cube_Main_Release_10.4.0_highlights
---

# DataMiner Cube Main Release 10.4.0 – Highlights - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Visual Overview: New BookingData component [ID_33215] [ID_36489]

<!-- MR 10.4.0 - FR 10.3.8 -->

You can now create a special *BookingData* shape and make it display all data associated with a particular booking.

To do so, create a shape with the following shape data fields:

|Shape data field | Value |
|-------------|---------------|
| Component   | `BookingData` |
| Reservation | The ID of the booking<br>Example: `[pagevar:SRMRESERVATIONS_IDOfSelection]` |

A *BookingData* shape will show the following information:

- On the left-hand side, you will find a list of resources used by the booking.

  For every resource, this list shows the following information:
  
  - the resource name
  - an icon indicating the function of the resource
  - an icon indicating whether the resource is linked to a service definition node
  - the node label or, if no node label is defined, the name of the function definition

- On the right-hand side, you see the profile data of the node or node interface you selected in the list on the left:

  - the profile instance (if applicable), and
  - the profile parameter values that will be used (note that these values can be overridden on several levels).
  
  > [!NOTE]
  > Priority of profile parameter value overrides:
  >
  > 1. Values defined in the parameter overrides (stored in the booking)
  > 1. Values defined in the profile instance
  > 1. Values defined in the profile definition

To be able to use the *BookingData* component, you will need

- a system with an Elasticsearch database
- a service manager license
- a resource manager license
- the following user permissions:

  - Modules > Bookings > UI Available
  - Modules > Functions > UI Available
  - Modules > Profiles > UI Available
  - Modules > Resources > UI Available
  - Modules > Services > UI Available

#### Trending - Pattern matching: Multivariate trend data patterns [ID_35010] [ID_35301] [ID_36327] [ID_36454] [ID_36628] [ID_36731]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, DataMiner was able to recognize patterns in trend graphs showing trend information for one single parameter. From now on, it is also capable of recognizing patterns in trend graphs showing trend information for multiple parameters.

When you open a trend graph showing trend information for multiple parameters, you can now define a so-called *multivariate trend pattern*.

As with single-parameter patterns (i.e. univariate patterns), a number of options can be specified:

- If you want the patterns to be available for other DataMiner functionality, e.g. to generate suggestion events or via the Generic Query Interface in dashboards or low-code apps, select *Continuously detect patterns in the background*.

- If you want the patterns to be detected for all elements using the protocol instead of the current element only, next to *Apply to*, click the element name and select the protocol instead.

If you are viewing a trend graph that shows trend information for multiple parameters in which multivariate patterns were detected, these will be highlighted in orange when you hover the mouse pointer over the button representing a pattern, or if the option *Expand tags* is selected in the right-click menu. Also, a special icon will indicate that this is a pattern that combines trend information from different parameters. If you click that icon, all trend graphs of all parameters that are part of the pattern will be loaded.

#### Automation: New user/group setting to specify whether users have to confirm program executions launched from interactive Automation scripts [ID_35418]

<!-- MR 10.4.0 - FR 10.3.3 -->

A new user/group setting named *Do not confirm program executions from scripts*, found in the *User > Cube* tab of the *Settings* window, now allows you to specify whether users will have to explicitly confirm each program execution that is launched from an interactive Automation script.

By default, this option will be disabled, meaning that users will have to give their consent each time an interactive Automation script wants to launch a program. The confirmation box will also allow users to change the setting by selecting the *Don't show this confirmation again. Always launch program executions.* checkbox.

Each time a program is launched, a start entry and an end entry will be added to the Cube logging as well as to the *SLClient.txt* log file on the DataMiner Agent.

- The start entry will contain the following data:

  - the name of the Automation script
  - the ID of the Automation script
  - the user's login data (full name, client machine name, client app name and last login date)
  - the program that will be launched
  - the arguments that will be passed to the program (if any)

- The end entry will contain the following data:

  - the user's login data (full name, client machine name, client app name and last login date)
  - the process ID of the program
  - the time at which the process ended
  - the name of the program that ended
  - the arguments that were passed to the program (if any)

#### Trending: Time-scoped relations [ID_36434] [ID_36760]

<!-- RN 36434: MR 10.4.0 - FR 10.3.8 -->
<!-- RN 36760: MR 10.4.0 - FR 10.3.9 -->

A light bulb icon will now be displayed when you select a time range on the trend graph of a parameter. If you want to know which other parameters are related to this parameter, based purely on the behavior during the selected time range, then you can click this icon to add or view related parameters. Even if multiple curves are displayed on the same trend graph, the light bulb always shows relations with one specific parameter, whose name is mentioned in the light bulb tooltip.

You can for instance use this in case a parameter (e.g. the total available memory of a server) behaves oddly during a particular time range (e.g. a downward spike), in order to find out if other parameters of the same device also showed unusual behavior during the same time range.

For more information, see [Adding time-scoped related parameters to a trend graph](xref:Adding_time_scoped_related_parameters_to_a_trend_graph).

> [!NOTE]
>
> - Currently, the feature only proposes parameters from the same DataMiner element.
> - When the requirements of a light bulb are not met, an entry is added to the Cube logging. These log entries will make a clear distinction between the "relation light bulb feature" (i.e. the icon appearing in the top-right corner) and the "time-scoped relation feature" (i.e. the icon appearing when you select a trend graph section).
