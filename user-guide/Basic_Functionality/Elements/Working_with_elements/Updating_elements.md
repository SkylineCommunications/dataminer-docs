---
uid: Updating_elements
---

# Updating elements

## Updating a single element

If you want to update one element:

1. Right-click the element in the Surveyor and select *Edit*.

   The same card will open as when you [create an element](xref:Adding_elements), but with all information already filled in.

1. Make the necessary changes, and click *Apply*.

> [!NOTE]
>
> - If you just want to rename an element, you can also right-click the element in the Surveyor, and immediately select *Rename*.
> - For a dynamic virtual element, to enable or disable child element creation, click *Advanced element settings* and select or clear *Enable DVE child creation*. See [Dynamic virtual elements](xref:Dynamic_virtual_elements).
> - When you edit a replicated element, if you want to change the remote element, you will need to enter the user credentials for the remote DMA again. See [Replicating elements](xref:Replicating_elements).
> - Some elements may be created by a different parent element. In that case, editing these elements may not be possible, except by an Administrator, or via the parent element.

## Setting a parameter value in multiple elements

1. Right-click an element in the Surveyor and click *Multiple set*.

1. In the *Multiple set* dialog box, select the elements of which you want to update a particular parameter value.

   - By default, the list will contain all elements using the same protocol version as the element you right-clicked.

   - If you want to list all elements using another protocol (version), just select another protocol and/or protocol version in the drop-down boxes in the top-left corner of the dialog box.

   - Click *Check all / none / invert* to respectively select all elements, select none of the elements, or invert your selection.

1. In the *Parameter* box, select the parameter for which you want to update the value.

   If, in the *Parameter* box, you select a dynamic table parameter, you will also have to specify a table key in the selection box below.

   > [!NOTE]
   > When you have selected a parameter, the current values of that parameter will be retrieved for all listed elements, and displayed in the list.

1. In the *Value* box, specify the new parameter value.

1. Click the *SET* button.
