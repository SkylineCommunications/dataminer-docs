---
uid: Grouping_Alarms
---

# Grouping alarms

This action is available from DataMiner 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 onwards<!--RN 44973-->.

Use this action in a correlation rule to generate a group alarm that combines all base alarms matching the rule.

## Configuring a correlation rule to generate a group alarm

1. In the *Actions* section of the details pane, click *Add Action* and select *Group alarms*.

1. Click the underlined field to the right of "with alarm value", and specify a parameter value.

   Instead of a fixed value, you can also enter a placeholder. For more information, see [Correlation rule syntax](xref:Correlation_rule_syntax).

## Group alarms in the Alarm Console

When a correlated group alarm appears in the Alarm Console:

- The **element name** depends on whether you have selected [*Correlate across DMAs*](xref:General_configuration_of_Correlation_rules) and whether [alarm grouping](xref:Grouping_alarms_in_Correlation_rules) is configured:

  | *Correlate across DMAs* | Alarm grouping configured | Element name |
  | -- | -- | -- |
  | Enabled | No | Cluster name |
  | Enabled | Yes | Grouped object name |
  | Disabled | No | DataMiner Agent name |
  | Disabled | Yes | DataMiner Agent name + Grouped object name |

- The **parameter description** is set to the name of the correlation rule.

- The **severity** corresponds to the highest severity among the base alarms. The alarm icon color reflects this severity.

> [!NOTE]
> When filtering alarms in the Alarm Console using the [quick filter](xref:UsingTheQuickFilterBox) or an [alarm filter](xref:Adding_alarm_filters_to_Correlation_rules), both the group alarm and its source alarms are shown if:
>
> - The group alarm matches the filter, or
> - At least one of its source alarms matches the filter.
