---
uid: About_DMS_Correlation
---

# About DataMiner Correlation

DataMiner Correlation automatically analyzes raw alarm information and real-time parameter values, and acts upon that information according to the rule sets you define in its knowledge base. It is not only capable of detecting single events, but also persistent and recurring events.

Based on the rules set by the user, DataMiner Correlation can create correlated alarms or send notifications via text message or email, so that operators are informed of certain events. It can also trigger automation scripts, so that automatic countermeasures are possible in case of emergency or preventive actions in case of emerging issues.

![Correlation engine concept](~/dataminer/images/correlation_engine_conceptv2.jpg)

## correlation rules: basic concept

Each of the correlation rules in the knowledge base consists of:

- A trigger, which determines when the rule is applied.

- An action, which determines what happens when the rule is applied.

The trigger consists of:

- An event that has to occur to trigger the rule.

- A mechanism, i.e. the behavior of the event that will trigger the rule, e.g. the event recurs a particular number of times.

The event is a combination of:

- One or more alarm filters (optional): These limit the number of alarms that will be taken into consideration for the correlation rule.

- Alarm grouping (optional): This combines alarms matching the same criteria into separate correlated alarms. For example, when alarms are grouped per element, one correlated alarm is created per element.

- Rule conditions: These conditions determines when the correlation rule is triggered. Ideally, a correlation rule should always contain at least one condition.

![Correlation rule concept](~/dataminer/images/Correlation_rulev2.jpg)

## Correlation in DataMiner Cube vs. System Display

Prior to DataMiner 10.5.1/10.6.0, two different engines are available for DataMiner Correlation: the deprecated System Display engine and the DataMiner Cube Correlation engine. Rules created with the System Display engine are no longer supported in DataMiner Cube from DataMiner 10.5.1/10.6.0 onwards. In earlier DataMiner versions, they are still available but marked as deprecated.<!--RN 40834-->

The Cube Correlation Engine offers several functions that are not available in the deprecated System Display engine, such as:

- Alarm filtering by means of regular expressions

- Alarm grouping prior to Correlation rule evaluation

- Elaborate Correlation rule conditions

## Correlation in DataMiner clusters

### Which DMA handles which rule?

In the DMS, each rule is either handled by one specific DMA, or handled by all DMAs separately, depending on whether the option *Correlate across DMAs* is selected. (See [General configuration of correlation rules](xref:General_configuration_of_Correlation_rules).)

- If this option is selected, the rule will accept all alarm events from the entire DMS that match the configured alarm filter. One single rule can combine base alarm events from multiple Agents.

- Otherwise, each DMA will individually manage the rule for its local alarm events only. There will be no actions combining base alarm events from multiple DMAs. This means that, for example, if there are three different elements, each on a different DMA, for which a correlation rule triggers an alarm, these could trigger three separate correlated alarms, rather than one combined alarm.

### What if the connection between Agents is lost?

If a rule is managed by one single DMA, events will be collected from the point of view of that DMA:

- When the connection is lost with a remote DMA, the base events which originated from that DMA will no longer be taken into account for the correlation rule. Once the connection is restored, these base events will be included again, and actions will be updated if necessary.

- When a remote Agent is not available at the moment when a correlated alarm event needs to be generated, the alarm is created as soon as the connection with the Agent becomes available, unless the condition has been cleared by then.

- When the DMA managing the rule is down, the rule will not be executed.

When a remote Agent is disconnected, this can cause actions to be executed for rules using base alarms from the remote Agent. For example:

- A correlated alarm can be updated because remote base alarm events are removed, or cleared, when the rule conditions no longer match.

- Actions that are executed whenever the base alarm updates or when the condition is cleared can be executed, because the remote base alarm event is removed or the condition is no longer true.

When contact with the remote Agent is re-established, this can also cause actions to be executed, as the remote base alarms are added again.

> [!NOTE]
> If an alarm event was both cleared and generated on a remote Agent while no connection was available with that Agent, this event will never be included as a base alarm event for a correlation rule handled only by the local Agent.
