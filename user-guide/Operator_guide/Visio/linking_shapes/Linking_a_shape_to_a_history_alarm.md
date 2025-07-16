---
uid: Linking_a_shape_to_a_history_alarm
---

# Linking a shape to a history alarm

From DataMiner 10.2.0/10.1.8 onwards, when a shape is linked to an element, parameter or service, you can make it show the alarm state for this linked object at a specific point in the past. This can be done with the **HistoryMode** shape data field, which can be added to a specific shape or to a complete page.

Configure the shape data field as follows:

1. Add a shape data field of type **HistoryMode** to the shape or page, depending on whether you want to show only this shape in history mode, or all shapes on the page.

1. Set the value of the shape data field as follows:

   ```txt
   State=[On/Off]|TimeStamp=[datetime value]
   ```

   Refer to the table below for the value syntax:

   | Value | Explanation |
   |--|--|
   | State | Can be "On" or "Off". On means history mode is active, Off means real-time alarm information should be shown instead. You can use a placeholder to change this value dynamically. |
   | TimeStamp | The date and time for which the alarm value should be displayed. You can use a placeholder to change this value dynamically. |

   For example:

   | Shape data field | Value |
   |--|--|
   | HistoryMode | State=On\|TimeStamp=\[var:myTime\] |
