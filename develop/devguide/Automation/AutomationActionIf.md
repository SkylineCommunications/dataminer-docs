---
uid: AutomationActionIf
---

# If

Defines an if-else clause.

An if-else clause is implemented using Exe blocks of type "if", "else" and "endif" as illustrated next:

```xml
<Exe id="2" type="if">
   <Type>conditions</Type>
   <Condition combination="and" type="param" protocol="1" pid="64501" compare="lt" ref="param1"></Condition>
</Exe>
<Exe id="3" type="...">
      <!-- Code to execute when condition is met (if-clause) -->
</Exe>
<Exe id="4" type="else"/>
<Exe id="5" type="...">
      <!-- Code to execute when condition is not met (else-clause) -->
</Exe>
<Exe id="6" type="endif"/>
```
