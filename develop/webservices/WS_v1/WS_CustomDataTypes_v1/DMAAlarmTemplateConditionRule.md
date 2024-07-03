---
uid: DMAAlarmTemplateConditionRule
---

# DMAAlarmTemplateConditionRule

| Item | Format | Description |
|---|---|---|
| ParameterID | Integer         | The ID of the parameter used in the rule. |
| Comparer    | DMAComparerType | One of the following values:<br> -  Equals = 0,<br> -  NotEquals = 1<br> -  LessThan = 2<br> -  GreaterThan = 3<br> -  WildcardEquals = 4<br> -  WildcardNotEquals = 5 |
| Value       | String          | The value the parameter is compared with. |
