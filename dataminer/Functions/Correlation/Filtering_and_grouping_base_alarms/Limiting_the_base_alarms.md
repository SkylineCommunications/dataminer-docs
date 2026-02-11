---
uid: Limiting_the_base_alarms
---

# Limiting the base alarms

In the Correlation module, the *Actions* section of the details pane allows you to limit the base alarms for a correlation rule, as an alternative to or in addition to adding alarm filters.

1. In the *Actions* section, click *Add Option* and select *Limit the base alarms*.

1. Click *Select a filter*.

1. Select one of the listed properties and create a filter condition, or select *Saved filters* and select an existing alarm filter.

   > [!NOTE]
   > Private alarm filters are not available for use in Correlation rules.

1. If necessary, select the option *Include all Alarms generated ... before and after the moment this rule was triggered* and specify a time span.

   When you select this option, any alarms that match the filter and occur within the indicated time span will be included in the same correlated alarm.

   > [!NOTE]
   > It is also possible to select this option without specifying a filter. In this case, any alarm events matching the rule that were detected during the indicated time span will be included as base alarm events.
