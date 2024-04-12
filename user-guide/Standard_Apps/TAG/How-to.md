---
uid: How_to_TAG_App
---

# How to

The app contains multiple functions that allows interaction with the TAG MCS or TAG MCM elements available in the system. To ensure the app works properly, it is necessary to have the following versions set to production at minimum:

- TAG Video Systems MCM-9000 connector version 1.1.6.10
- TAG Video Systems Media Control System (MCS) connector version 1.0.2.1

For more information on the most important features, see below.

## Channel status

The *Channel status* page presents a table listing the current channels configured in the TAG devices.

For each channel, you can do the following:

- **Review channel events**: When you click the icon next to the severity value, a new panel will be presented with the current active and inactive events associated with the channel. The events are ordered first by state, then by timestamp. This provides a quick way to review the last alarms reported by TAG.
  
- **Send a channel to a layout**: When you click the *Send to layout* button, you will be prompted to select the layout where the channel should be set. If the chosen layout does not contain any more available spaces, the prompt will suggest overwriting the first position of the layout.

## Layouts

The *Outputs & layouts* page presents a list of outputs, with the associated layouts shown for each output.

On this page, you can do the following:

- Change the layout associated with a selected output by clicking the *Modify Layout* button and selecting a new layout from the available options.

- For the selected output and layout, modify the channels assigned to the different positions in the layout tiles table. Also, edit the UMD text for each tile.

- Use the *Set audio* button to select the audio stream that should be decoded and output by the selected TAG output.
