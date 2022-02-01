---
uid: Having_multiple_lines_drawn_between_elements_in_case_of_element_connectivity
---

# Having multiple lines drawn between elements in case of element connectivity

If you have set up element connectivity via a Connection Manager element (i.e. a connection table), you can specify that multiple connections should be drawn between certain elements.

For example, add a shape data field of type **Connection** to a connection and set its value to:

```txt
*|10002|10007|Alarm|MultipleLinesMode
```

By default, the space between two lines will be five times the line thickness. This setting can be customized using the “*LineDistance*” option. In the following example, the space between two lines is set to twice the line thickness:

```txt
*|10002|10007|Alarm|MultipleLinesMode|LineDistance=2
```
