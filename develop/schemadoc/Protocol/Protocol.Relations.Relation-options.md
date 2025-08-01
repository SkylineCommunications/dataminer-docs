---
uid: Protocol.Relations.Relation-options
---

# options attribute

Defines a number of options.

## Content Type

string

## Parent

[Relation](xref:Protocol.Relations.Relation)

## Remarks

In this attribute, you can specify the following options.

### chain

Example:

```xml
<Relation path="6000;21000;21200;21400;22200" options="chain:VoD HW view"/>
```

### includeInAlarms

This will add an extra property to enable alarm bubble-up on tree controls. Each relation should have a unique property name.

Example:

```xml
<Relation path="100;200" options="includeInAlarms:topology1"/>
<Relation path="100;300" options="includeInAlarms:topology2"/>
<Relation path="100;200;300;400;500" options="includeInAlarms:topology:rightTopLevel"/>
```

> [!NOTE]
> See [Alarm bubble-Up](xref:UIComponentsTreeControlAlarmBubbleUp) for more information.
