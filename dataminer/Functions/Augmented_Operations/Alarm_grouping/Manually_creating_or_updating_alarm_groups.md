---
uid: Manually_creating_or_updating_alarm_groups
---

# Manually creating or updating an alarm group

From DataMiner 10.2.5/10.3.0 onwards, you can manually update an alarm group in the Alarm Console. You can add or remove alarms, create an alarm group manually, or rename an alarm group.

- To **create an alarm group**, right-click an alarm that is not part of an alarm group yet, and select *Add to alarm group* (or prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!-- 43903 -->: *Add to incident*). In the pop-up window, select to create a new alarm group (or incident) and add the alarm to it.

- To **add an alarm** to an existing alarm group, right-click an alarm that is not part of an alarm group yet, and select *Add to alarm group* (or prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!-- 43903 -->: *Add to incident*). In the pop-up window, select to add the alarm to an existing alarm group (or incident).

  > [!NOTE]
  > The following types of alarms cannot be added to an alarm group: correlated alarms, information events, suggestion events, other alarm groups, and clearable alarms. Prior to DataMiner 10.2.9/10.3.0, it is also not possible to add alarms without focus information, such as notices and errors.

- To **remove an alarm** from an alarm group, right-click an alarm that is part of an alarm group and select *Remove from alarm group* (or prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!-- 43903 -->: *Remove from incident*).

- To **rename an alarm group**, click the pencil icon next to the alarm group name and specify a new name.

- To **move an alarm** from one alarm group to another (supported from DataMiner 10.2.6/10.3.0 onwards), right-click an alarm that is part of an alarm group and select *Move to another alarm group* (or prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!-- 43903 -->: *Move to another incident*). You will then be able to select a different alarm group or create a new one to add the alarm to.

- From DataMiner 10.2.7/10.3.0 onwards, you can also modify an alarm group with **drag-and-drop editing**. To do so:

  1. In the Alarm Console, open the side panel. See [Alarm Console right-click menu](xref:AlarmConsoleRightClickMenu).

  1. Select the alarm group in the Alarm Console.

  1. In the side panel, click *Drag-and-drop editing*.

     This will freeze the current alarm tab and lock the side panel to the currently selected alarm group. To make changes, you can then:

     - Drag an alarm from the alarm tab to the side panel to add it to the alarm group.
     - Click the *x* next to an alarm in the side panel to remove it from the alarm group.

     > [!NOTE]
     > If you right-click an alarm group and select *Edit alarm group* (or prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!-- 43903 -->: *Edit incident*), this will open the side panel and activate drag-and-drop editing, so you can edit the alarm group in the same way as described here.

  1. When you are done, click *Apply*.

> [!NOTE]
>
> - When an alarm group has been updated manually, it **will no longer be updated automatically**.
> - From DataMiner 10.2.6/10.3.0 onwards, you can manually create an alarm group even when automatic alarm grouping is not activated in the alarm tab. From DataMiner 10.2.7/10.3.0 onwards, this is even possible when alarm grouping is not [enabled in System Center](xref:Automatic_alarm_grouping#automatic-alarm-grouping-configuration-in-system-center).
> - From DataMiner 10.2.6/10.3.0 onwards, the right-click menu of an alarm group (or incident) also allows you to take or (force) release ownership of the alarm group, add a comment, clear the alarm group in case it was created manually, assign a ticket to the alarm group, or view a ticket that was assigned to the alarm group.
> - From DataMiner 10.2.6/10.3.0 onwards, when an alarm group is created or edited manually, it will always receive focus. Automatically created alarm groups receive focus if at least one of the base alarms has focus. See [Alarm focus](xref:Alarm_focus).
