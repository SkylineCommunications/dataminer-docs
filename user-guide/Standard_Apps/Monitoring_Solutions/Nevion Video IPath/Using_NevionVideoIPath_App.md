---
uid: How_to_NevionVideoIPath_App
---

# Using the Nevion Video IPath app

The sidebar on the left of the Nevion Video IPath application contains buttons to two pages: Connect and Services:

| Button | Page description |
|:--:|--|
| ![Connect](~/user-guide/images/TAG_Overview_Icon.png) | Opens the [*Connect* page](#overview-page), which displays Profiles, Sources and Destinations. These sources and destinations can be connected to create services.
| ![Services](~/user-guide/images/TAG_Channels_Icon.png) | Opens the [*Services* page](#channel-status-page), which displays an overview of all available services.

## Overview page

The *Overview* page provides an overview of all your TAG devices, including key metrics such as CPU and memory usage. Additionally, it tracks license usage per instance and presents an overview of channel and output usage.

![Overview page](~/user-guide/images/TAG_Overview_Page.png)

> [!NOTE]
> Without TAG's Media Control System (MCS) in place, the *Overview* page may lack the following information: temperature, recorders, and outputs limit.

## Channel Status page

The *Channel Status* page provides a table listing the currently configured channels, alongside additional information such as alarm severity, active events, bitrate, memory usage, and more.

For each listed channel, you can do the following:

- **Review channel events**: When you click the ![Review channel](~/user-guide/images/TAG_Review_Channel_Icon.png) icon next to the severity level, a new panel opens with the current active and inactive events associated with the channel. The events are ordered first by state, then by timestamp.

  ![Channel events](~/user-guide/images/TAG_Channel_Review_Panel.png)

  This panel provides a quick way to review the latest alarms reported by TAG.
  
- **Send a channel to a layout**: When you click the ![Layout](~/user-guide/images/TAG_Layout_Icon.png) button in the *Send to layout* column, a pop-up window appears that allows you to assign the channel to one of the existing layouts.

  ![Layout pop-up window](~/user-guide/images/TAG_Layout_Pop-up_Window.png)

  If the chosen layout does not contain any more available spaces, the prompt will suggest overwriting the first position of the layout.

> [!NOTE]
> Without TAG's Media Control System (MCS) in place, the *Channel Status* page may lack the following information: bitrate, CPU usage, memory allocation, and profile data.

In the top-left corner of the header bar you can switch to the *Channels Configuration* page by clicking *Channels Configuration*. This page offers an overview of all channels alongside its profiles and PIDs.

> [!IMPORTANT]
> If you suspect missing information falls under the latter two categories, we recommend reaching out to your Technical Account Manager. They can ensure that any necessary updates are implemented in the application.
