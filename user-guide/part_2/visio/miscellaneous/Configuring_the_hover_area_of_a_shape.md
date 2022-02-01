---
uid: Configuring_the_hover_area_of_a_shape
---

# Configuring the hover area of a shape

By default, when the mouse pointer hovers over a shape, the area that is highlighted is always a rectangle shape, which does not take shape rotation or other shape manipulations into account.

From DataMiner 9.5.14 onwards, you can add the following shape data in order to make the hover shape use the exact same geometry as the shape:

| Shape data field | Value              |
|------------------|--------------------|
| Options          | HoverType=Geometry |
