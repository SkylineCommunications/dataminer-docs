---
uid: CreatingTicketsFromCorrelation
---

# Configuring automatic ticket creation via Correlation

You can have DataMiner create tickets automatically based on a correlation rule. The correlation rule can detect specific alarm conditions and then trigger ticket creation without any user interaction.

1. In the Correlation module in DataMiner Cube, [create a correlation rule](xref:Adding_a_new_Correlation_rule).

1. Configure the rule to be triggered based on the needs of your use case.

   For example, you can [filter on alarms](xref:Adding_alarm_filters_to_Correlation_rules) with critical severity:

   ![Example Correlation rule configuration with alarm filter to trigger on critical alarms](~/solutions/images/Ticketing_Correlation_rule_trigger.png)<br>*Example Correlation rule configuration in DataMiner 10.6.7*

1. Select the action *Run script* and select the script *SLC-AutoCreateTicket*, which is included in the Ticketing Solution for this purpose.

   ![Example Correlation rule configuration with alarm filter to trigger on critical alarms](~/solutions/images/Ticketing_Correlation_rule_action.png)<br>*Example Correlation rule configuration in DataMiner 10.6.7*

1. Make sure your rule is enabled via the *Enable this rule* checkbox at the top.

1. Click *Apply* to save and apply the rule.

When an alarm is generated that triggers the rule, a ticket will be created immediately, linked to the alarm and related objects, and the ticket ID will be added to the alarms *Ticket ID* property.
