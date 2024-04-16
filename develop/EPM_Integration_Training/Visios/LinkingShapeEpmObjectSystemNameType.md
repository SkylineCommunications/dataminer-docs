---
uid: LinkingShapeEpmObjectSystemNameType
---

# Linking a shape to an EPM object

From DataMiner 10.1.0/10.0.4 onwards, you can link a shape to an EPM object. Clicking the shape will then navigate to that EPM object on the current card. The context menu of the shape will allow you to navigate to the object on the current card, on a new card, or on a new undocked card.

You can configure this by adding the **SystemType** and **SystemName** shape data fields to the shape and setting the value of the fields to the system name and system type of the object, respectively.

For example:

![image](~/develop/images/EPM_link_shape_to_object.png)

> [!NOTE]
> In the example above, `[field]` is the name of the EPM object. This makes it dynamic within an EPM environment.

> [!TIP]
> For more detailed information, see [Linking a shape to an EPM object](xref:Linking_a_shape_to_an_EPM_object).
