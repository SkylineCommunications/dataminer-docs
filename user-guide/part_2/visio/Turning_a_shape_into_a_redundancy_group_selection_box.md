---
uid: Turning_a_shape_into_a_redundancy_group_selection_box
---

# Turning a shape into a redundancy group selection box

In a Visio drawing, elements belonging to the same redundancy group can be highlighted by means of a selection box.

To turn a shape into a redundancy group selection box, add a shape data field to it of type **Connection**, and set its value to “*ConnectionRGs*”.

- If you want to format the selection box items (which by default only show the element name), you can use the “*ItemFormat=*” option.

- If you want the selection box to contain an extra item that represents “No selection”, you can use the “*NoSelectionDisplay=*” option. This item will always be the first item in the list.

Example:

```txt
ConnectionRGs|ItemFormat=RG: '{0}'|NoSelectionDisplay=<None>
```

> [!NOTE]
> You can also highlight all elements belonging to a particular redundancy group by means of a shortcut menu command. Just right-click a shape, and select *Highlight Redundancy Group*.
>
