---
uid: How_to_TAG_App
---

# How To

The app contains multiple functions that allows interaction with the TAG MCS or TAG MCM elements available in the system. To ensure the app works properly, it's necessary to have the following versions set to production at minimum:

- TAG Video Systems MCM-9000 connector version 1.1.6.10
- TAG Video Systems Media Control System (MCS) connector version 1.0.2.1

The most important features are described below:

## Channel Status
The Channel Status page presents a table with the current Channels configured in the TAG devices. For each Channel, you can:

- **Review Channel Events**: By clicking the icon next to the Severity value, a new panel will be presented with the current Active and Inactive Events associated with the channel. The events are ordered first by State, then by Timestamp. This provides a quick way to review the last alarms reported by TAG.
  
- **Send a Channel to a Layout**: Clicking the *Send To Layout* button will prompt the user to select the layout where the channel should be set. If the chosen layout does not contain any more available spaces, the prompt will suggest overwriting the first position of the layout.


## Layouts
The Outputs & Layouts page presents a list of outputs, with the associated layouts shown for each output. Over this page, it is possible to:

- Change the layout associated with a selected output by clicking the "Modify Layout" button and selecting a new layout from the available options.
- For the selected output and layout, you can modify the channels assigned to the different positions in the layout tiles table. Additionally, you can edit the UMD text for each tile.
- Use the "Set Audio" button to select the audio stream that should be decoded and output by the selected TAG output.
