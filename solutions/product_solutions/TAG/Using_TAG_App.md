---
uid: How_to_TAG_App
---

# Using the TAG Management app

The sidebar on the left of the TAG Management application contains buttons that can be used to access different pages of the app:

| Button | Page description |
|:--:|--|
| ![Overview](~/dataminer/images/TAG_Overview_Icon.png) | Opens the [*Overview* page](#overview-page), which displays an overview of all the TAG devices in your system. |
| ![Channels](~/dataminer/images/TAG_Channels_Icon.png) | Opens the [*Channel Status* page](#channel-status-page), which displays an overview of all channels configured in the TAG devices. |
| ![Outputs & Layouts](~/dataminer/images/TAG_Outputs_Layouts_Icon.png) | Opens the [*Outputs* page](#outputs-page), which displays an overview of all available outputs alongside their associated layouts. |

## Overview page

The *Overview* page provides an overview of all your TAG devices, including key metrics such as CPU and memory usage. Additionally, it tracks license usage per instance and presents an overview of channel and output usage.

![Overview page](~/dataminer/images/TAG_Overview_Page.png)

> [!NOTE]
> Without TAG's Media Control System (MCS) in place, the *Overview* page may lack the following information: temperature, recorders, and outputs limit.

## Channel Status page

The *Channel Status* page provides a table listing the currently configured channels, alongside additional information such as alarm severity, active events, bitrate, memory usage, and more.

For each listed channel, you can do the following:

- **Review channel events**: When you click the ![Review channel](~/dataminer/images/TAG_Review_Channel_Icon.png) icon next to the severity level, a new panel opens with the current active and inactive events associated with the channel. The events are ordered first by state, then by timestamp.

  ![Channel events](~/dataminer/images/TAG_Channel_Review_Panel.png)

  This panel provides a quick way to review the latest alarms reported by TAG.
  
- **Send a channel to a layout**: When you click the ![Layout](~/dataminer/images/TAG_Layout_Icon.png) button in the *Send to layout* column, a pop-up window appears that allows you to assign the channel to one of the existing layouts.

  ![Layout pop-up window](~/dataminer/images/TAG_Layout_Pop-up_Window.png)

  If the chosen layout does not contain any more available spaces, the prompt will suggest overwriting the first position of the layout.

> [!NOTE]
> Without TAG's Media Control System (MCS) in place, the *Channel Status* page may lack the following information: bitrate, CPU usage, memory allocation, and profile data.

In the top-left corner of the header bar you can switch to the *Channels Configuration* page by clicking *Channels Configuration*. This page offers an overview of all channels alongside its profiles and PIDs.

> [!NOTE]
> Without TAG's Media Control System (MCS) in place, the *Channels Configuration* page may lack recording information.

## Outputs page

The *Outputs* page presents a list of available outputs, alongside their associated layout tiles.

![Outputs page](~/dataminer/images/TAG_Outputs_Page.png)

- To change the layout associated with a selected output, click the *Modify Layout* button in the top-right corner, and select a new layout from the available options.

- When you have selected an output and a layout, click the downward arrow in the *Title* column and select *Edit position* to modify the channels assigned to the different positions in the layout tiles table.

- To edit the UMD text for a layout tile, select the layout tile and click the ![Edit UMD](~/dataminer/images/TAG_UMD_Edit_Icon.png) button. The UMD Editor will appear.

  ![UMD](~/dataminer/images/TAG_UMD.png)

- To select the audio stream that should be decoded and output by the selected TAG output, click the ![Audio](~/dataminer/images/TAG_Audio_Icon.png) button in the *Set audio* column.

## Limitation: missing information

To optimize application performance, we highly recommend using TAG's Media Control System (MCS). While TAG MCM alone can sustain functionality, certain information and KPIs may be missing from the app.

Potential causes of discrepancies:

- TAG MCM's API might not cover all the data available in TAG MCS's API, resulting in missing information.

- The TAG Video Systems MCM-9000 connector might lack specific functionalities necessary to display all the information in the app.

- In some instances, the low-code app might fail to collect all the necessary data through GQI.

> [!IMPORTANT]
> If you suspect missing information falls under the latter two categories, we recommend reaching out to your Technical Account Manager. They can ensure that any necessary updates are implemented in the application.
