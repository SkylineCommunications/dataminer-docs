---
uid: UIComponentsTreeControlAlarmBubbleUp
---

# Alarm bubble-Up

To enable alarms to bubble up in the tree, the “includeInAlarms" option needs to be used in a relation:

```xml
<Relation path="100;200;300;400;500" options="includeInAlarms:topology"/>
```

The option "includeInAlarms" will generate an extra alarm property named 'SL_TREE_INFO_topology' on alarms from the tables in the path. The value of this property will contain the primary keys x1, x2, x3, etc. for each node in the relation path, e.g. "SL_Table_100,x1;SL_Table_200,x2;SL_Table_300,x3;etc.". The tree control needs this information to be able to bubble up alarm levels in the tree.

In case alarm bubble-up is not working correctly, you should first verify whether this property exists on the alarms and contains a valid path. Verify that the path does not contain empty primary keys (the tree control could then ignore this property).

> [!NOTE]
> This property can only be seen in the alarm details of System Display. Cube will hide this property. Note that System Display is no longer available from DataMiner 9.6.0 onwards.

Each relation should define a unique property name:

```xml
<Relation path="100;200;500" options="includeInAlarms:topology1"/>
<Relation path="100;200;400;500" options="includeInAlarms:topology2"/>
<Relation path="100;200;300;400;500" options="includeInAlarms:topology3"/>
```

There is no alarm for a parameter in "Normal" state, so there will be no bubble-up: parent levels will be displayed in gray/Undefined instead of green/Normal.

> [!NOTE]
> Adding or deleting this option in a connector can have unexpected results, such as alarms that cannot bubble up until a new alarm is created, or bubble-up that remains present while the option has been removed. A potential workaround is to reapply the alarm template. However, keep in mind that this will adjust the time the alarm is created, which means that you will lose the history linked to the alarm.

Masked alarms will be ignored in the tree (similar to elements in the Surveyor). Since DataMiner version 7.5.5, the parameter itself will be displayed as masked; in earlier versions it will be displayed in alarm.
