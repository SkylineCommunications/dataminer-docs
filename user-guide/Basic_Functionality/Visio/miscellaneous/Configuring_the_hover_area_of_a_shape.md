---
uid: Configuring_the_hover_area_of_a_shape
---

# Configuring the hover area of a shape

By default, when the mouse pointer hovers over a shape, the area that is highlighted is always a rectangle shape, which does not take shape rotation or other shape manipulations into account.

If you want the hover shape to use the exact same geometry as the shape instead, add the following shape data:

| Shape data field | Value              |
|------------------|--------------------|
| Options          | HoverType=Geometry |
