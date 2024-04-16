---
uid: LinkingShapeEpmObjectSystemNameType
---

# Linking a shape to an EPM object using System Name and Type

From DataMiner 10.1.0/10.0.4 onwards, it is possible to link a shape to an EPM object using its system name and system type. Clicking the shape will then navigate to that EPM object on the current card. The context menu of the shape will allow you to navigate to the object on the current card, on a new card, or on a new undocked card.

To link a shape to an EPM object, add the SystemType and SystemName shape data fields, and specify the system type and system name of the object as their respective values.

![image](~/develop/images/EPM_link_shape_to_object.png)

> [!NOTE]
> `[Field]` in this case is the name of the EPM object. This makes it dynamic within an EPM environment.

For more detailed information, see [Linking a shape to an EPM object](xref:Linking_a_shape_to_an_EPM_object).
