---
uid: Combining_filter_conditions
---

# Combining filter conditions

When you combine multiple filter conditions in one correlation rule, the way these conditions are structured directly determines how alarms in the bucket are evaluated and, ultimately, whether the rule is triggered.

Each filter condition is evaluated against individual alarms. The system checks whether there is at least one alarm in the bucket (i.e., the group of alarms that results from the [initial filtering and grouping](xref:Filtering_and_grouping_base_alarms_for_Correlation_rules)) that fully satisfies all the conditions defined within that filter condition. The logic of a filter condition is strict and self-contained: the **entire condition must be matched by a single alarm instance**. The evaluation iterates through the alarms in the bucket until such a match is found.

When **multiple** filter conditions are configured, they are **evaluated independently**. For each filter condition, alarms in the bucket are examined to determine whether any single alarm satisfies the corresponding condition. Because each filter condition is examined individually, the system **does not require one single alarm to satisfy all filter conditions simultaneously**. Instead, each filter condition may be fulfilled by different alarms.

This allows rules to be triggered based on more **complex scenarios**, such as combinations of alarms or even the absence of certain alarms. The system verifies whether the logical combination of all configured filter conditions is satisfied, rather than enforcing that all filter conditions must apply to a single alarm.

This distinction becomes particularly important when combining inclusion criteria (positive logic) and exclusion criteria (negative logic):

- When multiple criteria are grouped within a single filter condition, all inclusion and exclusion requirements must be satisfied by the same alarm.
- When criteria are split across multiple filter conditions, the evaluation is no longer limited to a single alarm:
  - Inclusion requirements can be satisfied by one alarm.
  - Exclusion requirements can be evaluated based on the presence or absence of other alarms in the bucket.

More broadly, the distinction can be summarized as follows:

- A single filter condition enforces that all constraints describe one alarm.
- Multiple filter conditions allow the rule to evaluate the entire set of alarms as a whole.

This explains why two rule configurations that appear similar can produce different outcomes in practice, if one relies on a single alarm matching all conditions, while the other evaluates conditions across multiple alarms within the same bucket.
