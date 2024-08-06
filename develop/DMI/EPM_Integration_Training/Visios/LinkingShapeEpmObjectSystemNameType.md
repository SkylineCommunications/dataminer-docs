---
uid: LinkingShapeEpmObjectSystemNameType
---

# Linking a shape to an EPM object

From DataMiner 10.1.0/10.0.4 onwards, you can link a shape to an EPM object. Clicking the shape will then navigate to that EPM object on the current card. The context menu of the shape will allow you to navigate to the object on the current card, on a new card, or on a new undocked card.

You can configure this by adding the **SystemType** and **SystemName** shape data fields to the shape and setting the value of the fields to the system name and system type of the object, respectively.

For example:

![Shape example with placeholder](~/develop/images/EPM_link_shape_to_object_shape.png)

![Shape data configuration example](~/develop/images/EPM_link_shape_to_object_field.png)

> [!NOTE]
> In the example above, `[field]` is the name of the EPM object. This makes it dynamic within an EPM environment.

> [!TIP]
> For more detailed information, see [Linking a shape to an EPM object](xref:Linking_a_shape_to_an_EPM_object).

Example of a live system:

![Example live system](~/develop/images/Linking_Shape_to_EPM_Object.png)
