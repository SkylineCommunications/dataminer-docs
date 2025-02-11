---
uid: Configuring_a_custom_context_menu
---

# Configuring a custom context menu

It is possible to configure a custom context menu for a specific shape in Visio.

To do so, add the **ContextMenu** shape data to the shape. For now, the only supported action for this context menu is to copy the shape text, even if the shape is part of a disabled group shape. For this, the following value needs to be specified:

| Shape data field | Value                         |
|------------------|-------------------------------|
| ContextMenu      | MenuItem:Action=CopyShapeText |

To make sure that this action becomes the default action when a user left-clicks the shape, you can add *IsDefaultAction=True*:

| Shape data field | Value                                              |
|------------------|----------------------------------------------------|
| ContextMenu      | MenuItem:Action=CopyShapeText,IsDefaultAction=True |

> [!NOTE]
> If a shape contains text, by default a context menu item is available that allows users to copy the shape text. As such, in most cases it will not be necessary to specify these shape data to get the context menu.
