---
uid: Grouping_Alarms
---

# Grouping alarms

This action is available from DataMiner 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 onwards<!--RN 44973-->.

Use this action to have a correlation rule generate a group alarm that groups the base alarms that match the rule.

To make a correlation rule trigger a group alarm:

1. In the *Actions* section of the details pane, click *Add Action* and select *Group alarms*.

1. Click the underlined field to the right of "with alarm value", and specify a parameter value.

   Instead of a value, you can also enter a placeholder. For more information, see [Correlation rule syntax](xref:Correlation_rule_syntax).

When a group alarm appears in the Alarm Console:

- The element name depends on whether you correlate across DMAs and whether [alarm grouping](xref:Grouping_alarms_in_Correlation_rules) is defined in the rule:

  | *Correlate across DMAs* setting | Alarm grouping? | Element name |
  | -- | -- | -- |
  | Enabled | No | Name of the cluster |
  | Enabled | Yes | Name of the grouped object |
  | Disabled | No | Name of the DataMiner Agent |
  | Disabled | Yes | Name of the DataMiner Agent + Name of the grouped object |

- The parameter description is set to the name of the correlation rule.

- The severity shown is the severity of the base alarm with the highest severity. The alarm icon color is also based on that severity.

> [!NOTE]
> When alarms are filtered in the Alarm Console, using the [quick filter](xref:UsingTheQuickFilterBox) or an [alarm filter](xref:Adding_alarm_filters_to_Correlation_rules), an alarm group and its sources are shown when the group alarm matches the filter or when one of its sources matches the filter.
