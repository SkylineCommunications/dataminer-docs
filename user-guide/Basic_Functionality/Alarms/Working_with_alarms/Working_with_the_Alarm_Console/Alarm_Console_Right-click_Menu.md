---
uid: AlarmConsoleRightClickMenu
---

# Alarm Console right-click menu

When you right-click an alarm in the Alarm Console, depending on the configuration, the following options can be available:

- **Open**: Displays a shortcut menu that allows you to open the alarm card or to open the view, element or service cards of the views, elements or services affected by the alarm.

- **Set element state**: Allows you to set the element state to *Activate*, *Pause*, *Stop* or *Restart*.

- **Ticket**: Allows you to create a new ticket linked to the alarm you right-clicked. From DataMiner 9.5.7 onwards, you can also view existing tickets related to the alarm via this submenu. (Requires DataMiner Ticketing.)

- **Change**: Allows you to quickly modify the alarm template, trend template or information template for the parameter on which the alarm occurs. See also:

  - [Editing the information template for one parameter](xref:Editing_the_information_template_for_one_parameter)

  - [Changing the alarm range for one parameter](xref:Changing_the_alarm_range_for_one_parameter)

  - [Changing the trend template for one parameter](xref:Configuring_trend_templates#changing-the-trend-template-for-one-parameter)

- **Mask alarm**: Allows you to mask the alarm or the element on which it occurred. See [Masking and unmasking alarms](xref:Masking_and_unmasking_alarms).

- **Unmask alarm**: Allows you to unmask the alarm. See [Masking and unmasking alarms](xref:Masking_and_unmasking_alarms).

- **Unmask element**: Allows you to unmask a masked element from the Alarm Console instead of from the Surveyor. See [Masking or unmasking an element](xref:Masking_or_unmasking_an_element).

- **Remove all cleared alarms**: Removes all cleared alarms, in case cleared alarms are not removed automatically. See [Alarm Console settings](xref:AlarmConsoleSettings).

- **Remove selected cleared alarm**: Removes the selected cleared alarm, in case cleared alarms are not removed automatically. See [Alarm Console settings](xref:AlarmConsoleSettings).

- **Copy \> Cell**: Copies the value of the cell you right-clicked, without the column name. This option is not available on any of the Action columns.

- **Copy \> Visible columns**: Copies the column names and values of the selected rows for the columns that are displayed in the Alarm Console.

- **Copy \> All columns**: Copies all column names along with the values of the selected rows.

  > [!NOTE]
  > The columns *Trend*, *Element heatline* and *Parameter heatline* cannot be copied. If you select to copy visible columns or all columns, these columns will never be included.

- **Copy \> Custom**: Opens a pop-up window where you can first select which alarm fields should be copied and in which order, and then copy them.

  The selected configuration will be saved in your user settings, so that the next time you select this option, your previous selection will be displayed.

- **Take ownership**: Allows you to take ownership of the alarm. See [Changing ownership of alarms](xref:Changing_ownership_of_alarms).

- **Release ownership**: Allows you to release ownership of the alarm. See [Changing ownership of alarms](xref:Changing_ownership_of_alarms).

- **Forced release ownership**: Allows you to force another user to release ownership of the alarm. See [Changing ownership of alarms](xref:Changing_ownership_of_alarms).

- **Add comment**: Allows you to add a comment to the alarm.

- **Send by SMS**: Allows you to forward the selected alarm to other users by text message (requires DataMiner Mobile Gateway).

- **Set alarm as unread**: Allows you to set an alarm as “unread”.

- **View comments**: Allows you to view all comments added to the selected alarm.

- **View connectivity**: Allows you to view the RCA connectivity chains that the associated element is part of.

- **Hyperlinks**: Custom hyperlinks associated with the alarm. See [Adding a custom command to the Alarm Console shortcut menu](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu).

- **Actions**: Allows you to set an alarm filter in order to be alerted when certain alarms occur.

- **Select all**: Selects all the alarms in the alarm tab.

- **Show side panel**: Opens the Alarm Console side panel. See [Using the collapsible side panel of the Alarm Console](xref:UsingTheCollapsibleSidePanel).

- **Hide side panel**: Closes the Alarm Console side panel. See [Using the collapsible side panel of the Alarm Console](xref:UsingTheCollapsibleSidePanel).

- **Properties**: Opens the alarm properties window. See [Changing custom alarm properties](xref:Changing_custom_alarm_properties).
