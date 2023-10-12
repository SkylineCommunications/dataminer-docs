---
uid: Alarm_cards
---

# Alarm cards

An alarm card shows detailed information about an alarm. To open an alarm card, right-click an alarm in the Alarm Console in DataMiner Cube, and select *Open \> Alarm Card*.

If the user setting *Alarm double-click action* is set to *Open alarm card*, you can also simply double-click the alarm in the Alarm Console. See [Alarm Console settings](xref:User_settings#alarm-console-settings).

Alarm cards consist of three panes:

- The **top pane** shows **general information** about the alarm, such as which parameters are in alarm and when the alarm started.

  > [!NOTE]
  > If more than one parameter is in alarm on the same element, click the downward arrow next to “other parameters in alarm” to view a drop-down list containing these parameters. To view the alarm card for such a parameter, select it in the list.

- The **pane on the left** shows the **history** of the alarm. For correlated alarms, it also shows the source alarms.

  > [!NOTE]
  > If the *AlarmSettings*.*MustSquashAlarms* option is enabled in *MaintenanceSettings.xml*, from DataMiner 10.0.12 onwards, an alarm tree can contain consolidated alarm events (i.e. consecutive alarm events without a severity change that are combined into a consolidated event). To view all the separate events within a consolidated alarm event, click the *Show alarm events* option at the bottom of this pane.

- The **large pane on the right** has three tabs:

  - **Details**: Details about the alarm, such as the current value of the parameter in alarm, the RCA level, the alarm status, any alarm comments, etc.

  - **Impact**: A list of the element, services and views the alarm has an impact on.

  - **Properties**: A list of properties that have been set for the alarm, or for views, elements or services it relates to.

At the bottom of the alarm card, there can be several **buttons**:

- **Mask alarm**: Allows masking of active alarms to prevent unnecessary follow-up, for instance when a device is intentionally manipulated for testing purposes. See [Masking and unmasking alarms](xref:Masking_and_unmasking_alarms).

- **Unmask alarm**: Unmasks an alarm that has previously been masked. See [Masking and unmasking alarms](xref:Masking_and_unmasking_alarms).

- **Clear alarm**: Allows you to clear an alarm if it is in a clearable state.

- **Copy full alarm**: Copies all properties of the alarm to the clipboard.

- **Take ownership**: Used in order to claim ownership of an alarm. See [Changing ownership of alarms](xref:Changing_ownership_of_alarms).

- **Release ownership**: Used in order to release ownership of an alarm, if you have previously claimed ownership. See [Changing ownership of alarms](xref:Changing_ownership_of_alarms).

- **Forced release ownership**: Forces the ownership of an alarm to be released, if a different user has previously claimed ownership. See [Changing ownership of alarms](xref:Changing_ownership_of_alarms).

- **Add comment**: Allows you to add a comment, for instance to communicate important information to other users. See [Adding comments to an alarm](xref:Adding_comments_to_an_alarm).

- **Send by SMS**: Forwards an alarm record by SMS.

- **View connectivity**: Displays the connectivity chains of which the element is a part (one tab per chain). For more information on connectivity chains, see [Working with the Connectivity Editor](xref:Working_with_the_Connectivity_Editor).

> [!NOTE]
> If a particular functionality is not available for an alarm, the button in question will not be displayed.
