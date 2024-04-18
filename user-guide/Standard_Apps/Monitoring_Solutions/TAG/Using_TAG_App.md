---
uid: How_to_TAG_App
---

# Using the TAG Management app

The sidebar on the left of the TAG Management application contains buttons that can be used to access different pages of the app:

| Button | Page description |
|:--:|--|
| ![Overview](~/user-guide/images/TAG_Overview_Icon.png) | Opens the [*Overview* page](#overview-page), which displays an overview of all the TAG devices in your system. |
| ![Channels](~/user-guide/images/TAG_Channels_Icon.png) | Opens the [*Channel Status* page](#channel-status-page), which displays an overview of all channels configured in the TAG devices. |
| ![Outputs & Layouts](~/user-guide/images/TAG_Outputs_Layouts_Icon.png) | Opens the [*Outputs* page](#outputs-page), which displays an overview of all available outputs alongside their associated layouts. |

## Overview page

The *Overview* page provides an overview of all your TAG devices, including key metrics such as CPU and memory usage. Additionally, it tracks license usage per instance and presents an overview of channel and output usage.

![Overview page](~/user-guide/images/TAG_Overview_Page.png)

## Channel Status page

The *Channel Status* page provides a table listing the currently configured channels, alongside additional information such as alarm severity, active events, bitrate, memory usage, and more.

For each listed channel, you can do the following:

- **Review channel events**: When you click the ![Review channel](~/user-guide/images/TAG_Review_Channel_Icon.png) icon next to the severity level, a new panel opens with the current active and inactive events associated with the channel. The events are ordered first by state, then by timestamp.

  ![Channel events](~/user-guide/images/TAG_Channel_Review_Panel.png)

  This panel provides a quick way to review the latest alarms reported by TAG.
  
- **Send a channel to a layout**: When you click the ![Layout](~/user-guide/images/TAG_Layout_Icon.png) button in the *Send to layout* column, a pop-up window appears that allows you to assign the channel to one of the existing layouts.

  ![Layout pop-up window](~/user-guide/images/TAG_Layout_Pop-up_Window.png)

  If the chosen layout does not contain any more available spaces, the prompt will suggest overwriting the first position of the layout.

## Outputs page

The *Outputs* page presents a list of available outputs, alongside their associated layout tiles.

![Outputs page](~/user-guide/images/TAG_Outputs_Page.png)

- To change the layout associated with a selected output, click the *Modify Layout* button in the top-right corner, and select a new layout from the available options.

- When you have selected an output and a layout, click the downward arrow in the *Title* column and select *Edit position* to modify the channels assigned to the different positions in the layout tiles table.

- To edit the UMD text for a layout tile, select the layout tile and click the ![Edit UMD](~/user-guide/images/TAG_UMD_Edit_Icon.png) button. The UMD Editor will appear.

  ![UMD](~/user-guide/images/TAG_UMD.png)

- To select the audio stream that should be decoded and output by the selected TAG output, click the ![Audio](~/user-guide/images/TAG_Audio_Icon.png) button in the *Set audio* column.
