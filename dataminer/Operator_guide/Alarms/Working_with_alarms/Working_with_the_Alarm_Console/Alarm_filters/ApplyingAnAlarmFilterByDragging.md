---
uid: ApplyingAnAlarmFilterByDragging
---

# Applying an alarm filter by dragging an item onto the Alarm Console

Instead of manually applying a filter in an Alarm Console tab, you can drag an item from the Cube UI onto the Alarm Console to create a tab filtered specifically for that item:

1. Drag an element, protocol, parameter, etc. onto the Alarm Console. A new tab will automatically be created.

   > [!NOTE]
   >
   > - With a redundancy group, this way of creating a filtered tab is not possible.
   > - To open a filtered tab for an element, service or view, you can also right-click the item in the Surveyor or on a card and select *Actions* > *Add tab to global Alarm Console*.

1. In the new tab, indicate the time frame for the alarms you want to display: active alarms, or a past time range.

1. In the *What* column, select whether to show non-masked alarms, information events and/or masked alarms.

1. In the next column, select the items to filter on.

   The options in this step differ depending on the type of item you dragged onto the Alarm Console. E.g. for a parameter, you may be able to click *Load more elements*, so that you can select several elements that have this parameter.

1. Click *Show alarms*.

> [!NOTE]
>
> - Alarm filters based on views also include alarm events based on aggregation rules.
> - If you want to open a filtered tab containing only alarms related to a particular DMA, this is possible from the *System Center* module. Go to the *Agents* page of System Center and select the DMA in question in the *manage* tab. Then click the *Show agent alarms* link at the top of the pane on the right. The filtered tab will then be opened in the Alarm Console. It will show all alarms on the DMA itself with severity Notice, Timeout or Error.
