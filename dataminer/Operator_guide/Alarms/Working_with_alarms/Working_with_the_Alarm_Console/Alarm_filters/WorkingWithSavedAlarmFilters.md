---
uid: WorkingWithSavedAlarmFilters
---

# Working with saved alarm filters

When you create a filter in the Alarm Console, you can save it in order to use it again later or in other DataMiner applications.

## Saving an alarm filter

1. Create a filter as described in [Manually applying an alarm filter in an Alarm Console tab](xref:ManuallyApplyingAnAlarmFilter).

1. Before clicking *Show alarms* to apply the filter in the tab, click *Save the current filter combination*.

   > [!NOTE]
   > If the current filter combination contains a private alarm filter, it will not be possible to save the filter combination as a public or protected filter.

1. Enter a name for the alarm filter.

   > [!NOTE]
   > Alarm filters may not start or end with a space.

1. Indicate whether the filter should be private, public, or protected. See [Alarm filters](xref:Alarm_filters)

1. Optionally, add a description.

1. Click *Save*.

## Using a saved alarm filter

1. Create a filtered tab as described in steps 1 and 2 in [Manually applying an alarm filter in an Alarm Console tab](xref:ManuallyApplyingAnAlarmFilter).

1. When you select a filter, as described in step 3 of the same procedure, scroll to the bottom of the list and select *Saved filters*.

1. To the right of *Saved filters*, click *\<Click to select>* and select the filter you want.

   > [!NOTE]
   > If you have selected a saved filter, but you do not have the user permission *Edit / delete protected filters*, an eye icon will be displayed next to the filter. Click this icon to view the contents of the filter.

1. Proceed as in [Manually applying an alarm filter in an Alarm Console tab](xref:ManuallyApplyingAnAlarmFilter).

## Editing or deleting a saved alarm filter

1. Select the filter from the *Saved filters* as if you were going to use it.

1. Click the pencil icon to the right of the filter.

1. In the edit window, the following actions are possible:

   - Click the *Delete* button to delete the alarm filter. You will receive a warning message mentioning where the filter may be used.

     > [!NOTE]
     > It is not possible to delete an alarm filter that is currently in use.

   - Enter a description for the filter in the *Description* field.

   - Change the fields of the filter itself, or delete parts of a combined filter, in the same way as when creating a new filter.

1. To save any changes, click *OK*.
