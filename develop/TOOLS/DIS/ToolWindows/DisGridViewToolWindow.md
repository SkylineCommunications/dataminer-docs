---
uid: DisGridViewToolWindow
---

# DIS Grid View

If you click *Tool Windows > DIS Grid View*, the *DIS Grid* window will appear.

This tool window allows you to manage and configure all parameters in the protocol using a spreadsheet-like view.

By default, the *DIS Grid* window will open undocked. Dock it just as you would dock any other tool window in Visual Studio.

![DIS Grid View tool window](~/develop/images/DisGridViewToolWindow.png)

## Filtering the parameter list

At the top of the window, there is a filter bar that allows you to narrow down the parameters list.

- To set a filter, enter a piece of text or select a preset value in one or more of the filter boxes.

- To clear the filter, click *Clear filter*.

## Editing cell content

To edit data in the parameter list, just click inside a cell, and change its contents.

In some cells, you can enter text, while in other cells, you have to select a preset value or a checkbox.

## Using the right-click menu commands

When you right-click a row in the parameter list, a shortcut menu appears.

| Select... | in order to... |
|-----------|----------------|
| Fix Description | Apply the capitalization rules to the parameter description. |
| Insert Before | Add a new, blank parameter row above the one you right-clicked. |
| Insert After | Add a new, blank parameter row below the one you right-clicked. |
| Duplicate | Duplicate the row you right-clicked. |
| Delete | Delete a parameter row from the list. |
| Navigate | Make the cursor in the file tab containing the protocol code jump to the corresponding [Param](xref:Protocol.Params.Param) tag.<br> Note: Instead of selecting *Navigate*, you can also press F12. |

## Managing parameter positions

When you have selected a parameter in the list, the *Positions* list at the bottom of the window lists all places where that parameter appears on the element card.

To edit existing data, just click inside a cell, and change its contents.

When you right-click a row, a shortcut menu appears.

| Select... | in order to... |
|-----------|----------------|
| Insert Before | Add a new, blank parameter row above the one you right-clicked. |
| Insert After | Add a new, blank parameter row below the one you right-clicked. |
| Duplicate | Duplicate the row you right-clicked. |
| Delete | Delete a parameter row from the list. |
| Navigate | Make the cursor in the file tab containing the protocol code jump to the corresponding *\<Position>* tag.<br> Note: Instead of selecting *Navigate*, you can also press F12. |

> [!NOTE]
> If you prefer to position parameters using a graphical user interface, use the Display Editor. See [Display editor](xref:Display_editor)

## Managing discreet values

When, in the list, you have selected a parameter of type "discreet", the *Discreets* list at the bottom of the window lists all discreet values that are defined for that parameter.

To edit existing data, just click inside a cell, and change its contents.

When you right-click a row, a shortcut menu appears.

| Select... | in order to... |
|-----------|----------------|
| Insert Before | Add a new, blank parameter row above the one you right-clicked. |
| Insert After | Add a new, blank parameter row below the one you right-clicked. |
| Duplicate | Duplicate the row you right-clicked. |
| Delete | Delete a row from the list. |
| Navigate | Make the cursor in the file tab containing the protocol code jump to the corresponding *\<Discreet>* tag.<br> Note: Instead of selecting *Navigate*, you can also press F12. |
