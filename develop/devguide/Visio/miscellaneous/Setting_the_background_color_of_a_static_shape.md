---
uid: Setting_the_background_color_of_a_static_shape
---

# Setting the background color of a static shape

From DataMiner 10.1.11/10.2.0 onwards, you can set the background color of a static shape, i.e. a shape that is not linked to an element, a service or a view.

To do so, add a shape data field of type **BackgroundColor**, and set the value to the color you want to use.

| Shape data field | Value |
|--|--|
| BackgroundColor  | A color, which can be configured in one of the following ways:<br> - An HTML color code (e.g. #FF102030)<br> - An RGB color code (e.g. 40,50,60)<br> - A standard color name (e.g. magenta)<br> - A color placeholder referring to one of the configured DataMiner alarm colors (e.g. \[color:severity=minor\])<br> - A placeholder referring to a variable containing a color value (e.g. \[PageVar:MyColorSessionVar\]) |

> [!NOTE]
> If a valid color is specified or retrieved via a placeholder, this background color is enforced on the shape. If blinking was enabled, it will be disabled because of this.
