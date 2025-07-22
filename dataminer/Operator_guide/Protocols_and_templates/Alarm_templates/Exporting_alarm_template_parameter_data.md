---
uid: Exporting_alarm_template_parameter_data
---

# Exporting alarm template parameter data

It is possible to export the parameter data from an alarm template or an alarm template group to a CSV file. This can for instance be useful for debugging purposes.

To do so, in the list of parameters of the alarm template or alarm template group, right-click and select *Export parameter data*.

Each row in the exported CSV file will contain a parameter ID, a parameter name and a list of linked fields (e.g. severity columns).

Only the parameters visible in the parameter list will be exported, for example:

- If *Only monitored parameters* was selected in the top right corner, only the monitored parameters will be exported.

- If you entered a search string in the filter box, only the parameters matching the search string will be exported.

> [!NOTE]
>
> - Hysteresis columns contain 2 values: the hysteresis value and the set of severities (“\*” in case of all severities) for which the hysteresis is used.
> - Condition columns contain 2 values: the name and the ID.

The name of the export file is a combination of the template name, the protocol name and the protocol version.
