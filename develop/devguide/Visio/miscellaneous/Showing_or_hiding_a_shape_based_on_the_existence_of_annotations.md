---
uid: Showing_or_hiding_a_shape_based_on_the_existence_of_annotations
---

# Showing or hiding a shape based on the existence of annotations

If you have linked a shape to a view, an element or a service, that shape can be set to appear or disappear based on whether or not that view, element or service has annotations.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[misc > OTHER]* page.

## Configuring the shape data field

Add a shape data field of type **Annotations** to the shape, and set its value to "\|SHOW" or "\|HIDE".

## Examples

If the shape has to be shown when there are annotations, then specify:

```txt
|SHOW
```

If the shape has to be hidden when there are annotations, then specify:

```txt
|HIDE
```
