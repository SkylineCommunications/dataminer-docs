---
uid: UIComponentsTreeControl
---

# Tree control

DataMiner Cube supports representing data in a hierarchical way by means of a tree control. A typical example of where a tree control can be used is a DVB probe. The probe typically consists of a number of inputs and each input consists of a number of transport streams. A transport stream then defines a number of services and each service consists of a number of elementary streams.

- <xref:UIComponentsTreeControlTag>
- <xref:UIComponentsTreeControlAdvancedHierarchy>
- <xref:UIComponentsTreeControlAlarmBubbleUp>
- <xref:UIComponentsTreeControlIcons>
- <xref:UIComponentsTreeControlMNRelations>

> [!NOTE]
>
> - An example protocol "SLC SDF Treecontrol" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).
> - For a tree control to function correctly, make sure the primary/foreign keys do not contain reserved characters used in the dynamic table filter syntax, as mentioned in Primary keys and Foreign keys.

## See also

DataMiner Protocol Markup Language:

- [Protocol.TreeControls](xref:Protocol.TreeControls)
- [Protocol.Params.Param.Measurement.Discreets.Discreet@iconRef](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-iconRef)
- [Protocol.Relations.Relation](xref:Protocol.Relations.Relation)

Coding guidelines

- [User Interface](xref:CODUserInterface)
