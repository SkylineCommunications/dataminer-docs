---
uid: scheduling_resource_timeline
---

# Scheduling - Resource Timeline

## Overview

The Resource Timeline provides a resource centered view of Jobs. It is very convenient for when you need to find a specific type of resource or perhaps want to see at a glance the activities for a certain type of resource such as trucks, rooms or even satellite space.

TODO - UPDATE IMAGE WITH RESOURCE TIMELINE IMAGE
<p>
<img src="~/user-guide/images/mediaops_s_job_timeline.png" width="1267" alt="Job Timeline">

The Resource Timeline is divided into several different sections. They include:

1. *The Timeline* - A graphical representation of when the Jobs start and stop for a given group of Resources. Jobs on the timeline display some basic information such as the Job Name, Job #, associated Organization (if applicable) and various colors to indicate the status of the Job.
1. *Time Navigation Controls* - quick pick time selectors that allow you to resize the timeline realtive to now. For example, the *Next Three Hours* button will zoom the timeline to Now and the next three hours.
1. *Resource Pools* -  
1. *Capabilities Filter* -
1. *Additional Filters* - on the right side of the screen are some addition filters that allow you to find Jobs by their Action Status (an indication of if additional Job configuration is needed) and type of Job. There are currently two types,  Scheduled Jobs which are created in the Scheduling App and Ad-Hoc Jobs created by the Control Panel when two Virtual Signal groups are created.
1. *New Job button* - this button allows you to create a new Job. To start a booking on this page, you must first select a Resource Group and a Resource. A new Job will be created in the Tentative state with the selected resource already assigned to the Job.

## Navigating the Timeline

The quick pick selectors shown in #2 above allow you to quickly scope the timeline relative to the current time. Sometimes more precise control is desired. In that case, a few other navigation tools might be useful, including:

- **Left Click and Drag**: holding down the Left mouse button and dragging the mouse left or right allows you to move the timeline either backwards or forwards in time.
- **Scroll Wheel**: if Jobs extend past the bottom of the visible screen, you can use the scroll wheel to move vertically.
- **CTRL + Scroll Wheel**: holding down the CTRL button while using the scroll wheel zooms in/out of the timeline so you can see more or less detail.
- **Right Click and Drag**: you can also zoom the timeline by right clicking and dragging over the time range you wish to zoom in on. To zoom back out, use the CTRL+Scroll Wheel or the Quick Pick time selectors.

<p>
<img style="margin-left: 65px;" src="~/user-guide/images/mediaops_s_job_timeline_timerange_select.png" width="1267" alt="Selecting a time range on the Job Timeline">

## Filtering the Resources using Capacities

When using the Resource Timeline, you can

## Interacting with a Job

In the Job Timeline section of the user manual, Jobs are depicted as rectangles extending from the Job Start Time to the Job End Time. Moreover, each Job features essential displays and actions, enabling seamless interaction directly from the timeline.
<p>
<img style="margin-left: 65px;" src="~/user-guide/images/mediaops_s_job_timeline_job_details.png" width="1267" alt="Job Details">

A few features to note:

- The **Context Menu** empowers users to perform essential actions on the Job, such as changing its state, duplicating, and deleting Jobs (when permitted). Keep in mind that the menu options may vary based on the Job's current state.
- In case the desired action cannot be executed using the Context Menu, you have the option to access comprehensive Job details by clicking on the pencil icon to **Open the Job Panel.**
- The **Job State Indicator** serves as a visual cue for the Job's current state. Consult the color legend in the right-hand margin of the Job Timeline view for quick reference. For a deeper understanding of the Job Lifecycle, refer to the (Scheduling Lifecycle)[xref:scheduling_job_lifecycle] page.
- The **Action Indicator** highlights Jobs requiring additional information from a user before becoming eligible to transition to the Confirmed state. For instance, the presence of the "Hand icon" signifies that specific resource assignments still need to be made for the Job.
