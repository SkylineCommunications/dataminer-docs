---
uid: Function_editor
---

# Function editor

If you click *Function Editor* in the file tab header when editing a function XML file, the XML editor you are working in will be turned into a graphical function interface editor. This editor allows you to manage the functions defined in a function XML file and design function pages using simple drag-and-drop operations.

![Function editor](~/develop/images/DIS_FunctionEditor.png)

> [!NOTE]
> If you open a function XML file and click *Function Editor* in the file tab header, DIS will ask you to open the associated protocol XML file as well if you have not yet done so already.

## Function

This selection box contains all functions defined in the function XML file you are editing. If you select a function from the list, the *Pages* section will show a list of all pages defined for that specific function, and the *Layout* section will display the page that was set as default.

To add a new function to the function XML file:

1. Click *New function*.
1. In the *Add new function* box,

    - enter the name of the new function,
    - select a profile,
    - select an entry point,
    - configure the interfaces, and
    - click *OK*.

To edit a function:

1. In the *Function* selection box, select the function you want to edit, and click the edit icon.
1. In the *Edit function...* window,

    - change the name of the function,
    - select a profile,
    - select an entry point,
    - configure the interfaces, and
    - click *OK*.

To delete a function from the function XML file:

1. In the *Function* selection box, select the function you want to delete, and click the red X.
1. In the *Delete function* box, click *Yes* to confirm the deletion.

## Pages

In the *Pages* list on the left, you can find the list of pages defined in the function selected in the *Function* section above.

> [!NOTE]
> Warning icons will appear next to pages that are empty.

To add a new page to the list, click *New page*. In the *Add New Page* dialog box, you can then specify the name and the type of the page.

When you right-click a page, a shortcut menu will appear, containing the following commands:

| Command        | Keyboard shortcut | Function                                    |
|----------------|-------------------|---------------------------------------------|
| Set as default | \-                | Turns the page into the default page.       |
| Rename         | F2                | Allows you to rename the page.              |
| Move Up        | CTRL+UP           | Moves a page one position up in the list.   |
| Move Down      | CTRL+DOWN         | Moves a page one position down in the list. |
| Remove         | DELETE            | Removes the entire page.                    |

## Layout / Parameters

You can drag parameters from the *Parameters* list on the right, which contains all parameters defined in the protocol XML file linked to the function XML file you are editing, onto a column in the *Layout* section, which represents the layout of the selected page. An extra column is suggested the moment you drag a parameter onto the *Layout* section. If you drop the parameter onto that extra column, a new column will be added to the page.

If you want a page to have only one column spanning across the entire width, then, in the *Options* section below, select *Wide column*. Note that this only works if no parameters have been added except in the left-most column.

### Layout

Every parameter you drag onto a page is represented by a building block that, by default, shows the ID and the name of the parameter.

In case of a Read/Write parameter, use the *Read* and *Write* checkboxes to indicate whether you want the page to contain the Read parameter, the Write parameter, or both.

In case of a table parameter, you can click the *Edit Parameter* button in the top-right corner of the building block and select the columns you want to include.

When you right-click after selecting a parameter (or multiple parameters), a shortcut menu appears.

| Select...                 | in order to...                                  |
|---------------------------|-------------------------------------------------|
| Go To XML (Apply Changes) | Save all changes and return to the XML editor.  |
| Remove                    | Remove the selected parameter(s) from the page. |

> [!NOTE]
> To select more than one parameter box, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive parameter boxes, click the first one in the list and then click the last one while holding down the SHIFT key.

### Parameters

By default, the *Parameters* list shows the ID and the name of every parameter defined in the protocol XML file linked to the function XML file you are editing.

At the bottom of the *Parameters* list, you can select *Group by page* to have the parameters in the list grouped by protocol page, and you can open a filter section that will allow you to filter the list.

## Apply changes / Cancel

If you want to save the changes you made and return to the XML editor, click *Apply Changes*. If you want to discard the changes you made, click *Cancel*.

## Warning

A warning box can appear when you try to open the function editor.

Errors that cause this *Warning* box to appear include:

- No default page
- ...

> [!NOTE]
> - Parameters of which the RTDisplay attribute is set to False will be ignored. This way, we avoid problems with "disappearing parameters" in protocols in which multiple parameters have been assigned identical names.
> - When you place two parameters at the same location, a red box will be drawn around those parameters, and a warning icon will appear next to the page. You can then drag one of the parameters to another location to resolve the problem.
