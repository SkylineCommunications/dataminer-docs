---
uid: Escalating_an_event
---

# Escalating an event

Use this action to escalate each of the base alarms of a Correlation rule by one level. This means alarms will escalate as follows:

| Base alarm | Correlated alarm |
|------------|------------------|
| Normal     | Warning          |
| Warning    | Minor            |
| Minor      | Major            |
| Major      | Critical         |
| Critical   | Critical         |
| Other      | Warning          |

Any extra base alarms that are added while the rule is active will also be escalated.

To configure this, in the *Actions* section of the details pane:

1. Click *Add Action* and select *Escalate event*.

1. Optionally, to also clear the escalated correlated alarm when the conditions are no longer fulfilled, select *Autoclear*.
