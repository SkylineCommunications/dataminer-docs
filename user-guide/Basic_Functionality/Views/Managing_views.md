---
uid: Managing_views
---

# Managing views

Views are displayed in the Surveyor tree, along with the various devices in your DMS.

In the Surveyor, the following actions are possible:

- [Creating a view](#creating-a-view)

- [Editing a view](#editing-a-view)

- [Removing an item from a view](#removing-an-item-from-a-view)

- [Managing custom properties for views](#managing-custom-properties-for-views)

> [!NOTE]
> It is possible that a view is created by a parent element. In that case, the view may not or only partly be editable, except by an Administrator or via the parent element.

## Creating a view

1. Right-click a view in the Surveyor and select *New \> View*.

   > [!NOTE]
   > To create a child view of an existing view, right-click the existing view.

1. Specify the name of the new view in the Surveyor

## Editing a view

1. Select *Drag and drop editing* in the right-click menu.

1. Drag items to or from the view as you see fit:

   - If you drag an item over a view to which it can be copied, the view will be displayed with a yellow background. If you drag it over a view to which it cannot be copied, a red “forbidden” icon will be displayed instead.

   - If you hold the item you are dragging over a collapsed view, after two seconds, the view will expand. Dragging the item to the top or bottom of the Surveyor list will make the Surveyor scroll automatically.

   - To move multiple items from one view to another at the same time, select the items on the “below this view” page of the source view using Shift or Ctrl and drag them all to the target view in the Surveyor at the same time.

     > [!NOTE]
     >
     > - Prior to DataMiner 10.3.5/10.4.0, this will copy the items instead of moving them. You can remove the items individually by right-clicking the element and selecting *Remove from parent*.
     > - If the source view is not yet open while you are in *Drag and drop editing* mode, use the Surveyor right-click menu to open it.

   - From DataMiner 10.3.5/10.4.0 onwards, press Ctrl while dragging to copy an item into the view. This will create a copy, not a duplicate item.

   - In the editing mode, complete views can be moved or copied as well.

1. Click *Exit editing* to exit the drag-and-drop editing mode.

> [!NOTE]
>
> - You can also move an item to a different view by editing the item itself and selecting a different view in the editor.
> - To just rename a view, you can right-click it in the Surveyor and select *Rename*.

## Removing an item from a view

There are several ways to remove an item from a view:

- Select *Drag-and-drop editing* in the right-click menu and then move the item somewhere else.

- Remove the item from the view by clicking *Remove from parent* in the right-click menu.

- Right-click the item and select *Edit*, and select a different view in the *Views* tab.

## Managing custom properties for views

Adding, editing or deleting custom properties for a view is done in a similar way as for an element.

> [!TIP]
> See also: [Managing element properties](xref:Managing_element_properties)
