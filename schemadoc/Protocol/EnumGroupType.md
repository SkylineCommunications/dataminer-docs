---
uid: Protocol-EnumGroupType
---

# EnumGroupType simple type

Specifies the group type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|action|The group will be executed at once and run the action.|
|&nbsp;&nbsp;Enumeration|poll|The group will be added to the queue, awaiting execution. On execution, the parameters in the group will be retrieved.|
|&nbsp;&nbsp;Enumeration|poll action|The group will be added to the queue, awaiting execution. On execution, the action will be run.|
|&nbsp;&nbsp;Enumeration|poll trigger|The group will be added to the queue, awaiting execution. On execution the trigger will be fired.|
|&nbsp;&nbsp;Enumeration|trigger|The group will be executed at once and fire the trigger.|
