---
uid: UIComponentsTreeControlAlarmBubbleUp
---

# Alarm bubble-Up

To enable alarms to bubble up in the tree, the "includeInAlarms" option needs to be used in a relation:

```xml
<Relation path="100;200;300;400;500" options="includeInAlarms:topology"/>
```

Each relation should define a unique property name:

```xml
<Relation path="100;200;500" options="includeInAlarms:topology1"/>
<Relation path="100;200;400;500" options="includeInAlarms:topology2"/>
<Relation path="100;200;300;400;500" options="includeInAlarms:topology3"/>
```

There is no alarm for a parameter in "Normal" state, so there will be no bubble-up: parent levels will be displayed in gray/Undefined instead of green/Normal.

> [!NOTE]
> Adding or deleting this option in a connector can have unexpected results, such as alarms that cannot bubble up until a new alarm is created, or bubble-up that remains present while the option has been removed. A potential workaround is to reapply the alarm template. However, keep in mind that this will adjust the time the alarm is created, which means that you will lose the history linked to the alarm.

Masked alarms will be ignored in the tree (similar to elements in the Surveyor). The parameter itself will be displayed as masked.
