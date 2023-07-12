---
uid: Masking_and_unmasking_alarms
---

# Masking and unmasking alarms

Active alarms can be masked to prevent unnecessary follow-up.

If a device is shut down for maintenance purposes, or if its settings are intentionally being changed for testing purposes, alarms raised as a result of such an action can be masked. This way, operators monitoring the DataMiner System know that these alarms do not require any intervention.

> [!TIP]
> See also: [Masking or unmasking an element](xref:Masking_or_unmasking_an_element)

## Masking an alarm

To manually mask an alarm:

1. In the Alarm Console in DataMiner Cube, right-click the alarm and select *Mask alarm*.

1. In the *Mask* dialog box, select whether to only mask the alarm, or to mask the element completely.

1. Choose the masking method:

   - **Mask the alarm for a limited period of time**: You will then need to specify the number of minutes during which the alarm should be masked. After this time, it will automatically be unmasked. Even when it gets cleared and reappears afterwards, it will remain masked for the specified period of time.

     > [!NOTE]
     > The maximum masking duration if you mask an alarm for a limited period of time is 30 days.

   - **Mask alarm until unmasked**: This will keep the alarm masked even if it is cleared. This way, if the alarm is first cleared and then reoccurs, there will be no need to mask it again.

   - **Mask alarm until cleared**: This will mask the alarm until it gets cleared. It will then automatically be unmasked.

   > [!NOTE]
   > Depending on the configuration of your DataMiner System, you may need to specify a motivation before you can select the masking method. See [Enforcing motivation of alarm actions](xref:Enforcing_motivation_of_alarm_actions).

1. Enter a comment, which will be stored in the *Comment* field of the new alarm record.

A new alarm record will be added to the life cycle of the alarm, with *Status* and *Alarm Type* set to “Mask”. The masked alarm will disappear from the *Active alarms* tab, and is added to the *Masked alarms* tab instead

> [!NOTE]
>
> - When an alarm is masked, the masked alarm no longer influences the overall alarm status of the element.
> - When an alarm is masked, any items linked to parameters that are consequentially masked, such as Visio items, LED bars, oscilloscopes, tables etc., will be displayed in purple.
> - When a row in a monitored table is deleted and then re-added, it can occur that a masked state applied on a cell in that row is lost, even if it was not configured to be masked until cleared. To prevent this, set the *AutoClear* option to false for the alarm in question. See [Setting the autoclear options for alarms in an alarm template](xref:Setting_the_autoclear_option_in_alarm_template).

## Unmasking an alarm

Masked alarms can be manually unmasked at any time and can also be masked again, e.g. to change the masking method.

To manually unmask an alarm:

1. In the *Masked alarms* tab of the Alarm Console in DataMiner Cube, right-click the alarm, and

   - if only the select alarm has been masked, select *Unmask alarm*.

   - if the element has been masked completely, select *Unmask element*.

1. Enter a comment, which will be stored in the Comment field of the new alarm record.

   > [!NOTE]
   > When, in case of timed masking, an alarm is automatically unmasked by the system, the system will automatically add a comment to indicate that it unmasked the alarm because the masking time has elapsed.

When you unmask an alarm, a new alarm record is added to its alarm life cycle, with *Status* set to “Open” and *Alarm Type* set to “Unmask”. The alarm will disappear from the *Masked alarms* tab, and return to the *Active alarms* tab instead.
