---
uid: Display_editor
---

# Display editor

If you click *Display Editor* in the file tab header when editing a protocol XML file, the XML editor you are working in will be turned into a graphical interface editor. This editor allows you to design the Data Display pages of the protocol using simple drag-and-drop operations.

![Display editor](~/develop/images/DIS_PageEditor.png)

> [!NOTE]
> When DVE elements are defined in the protocol, the drop-down box in the top-left corner allows you to select either the main protocol or one of the DVE elements. The editor will then only display the pages and parameters of the item you selected.

## Pages

On the left, you can find the list of existing pages.

This section visualizes data pages and pop-up windows in a tree view, similar to the way in which they are displayed in DataMiner Cube. Pop-up windows are shown as child items of the data pages in which they are defined.

> [!NOTE]
> Warning icons will appear next to pages that are empty and pop-up windows in which other pop-up windows are defined.

To add a new page to the list, click *New page.* In the *Add New Page* dialog box, you can then specify the name and the type of the page.

When you right-click a page, a shortcut menu will appear, containing the following commands:

| Command        | Keyboard shortcut | Function                                                                  |
|----------------|-------------------|---------------------------------------------------------------------------|
| Set as default | \-                | Turns the page into the default page.                                     |
| Rename         | F2                | Allows you to rename the page.                                            |
| Move Up        | CTRL+UP           | Moves a page in the *Manual Order* section one position up in the list.   |
| Move Down      | CTRL+DOWN         | Moves a page in the *Manual Order* section one position down in the list. |
| Remove         | DELETE            | Removes the entire page.                                                  |

## Layout / Parameters

You can drag parameters from the *Parameters* list on the right onto a column in the *Layout* section, which represents the layout of the selected page. An extra column is suggested the moment you drag a parameter onto the *Layout* section. If you drop the parameter onto that extra column, a new column will be added to the page.

If you want a page to have only one column spanning across the entire width, then, in the *Options* section below, select *Wide column*. Note that this only works if no parameters have been added except in the left-most column.

### Layout

Every parameter you drag onto a page is represented by a building block similar to the one in the screen shot below.

![](~/develop/images/dis_display_editor_param.png)

By default, a parameter building block shows the ID, the name and the type of the parameter. When you hover with the mouse over it, a tooltip will appear, showing the contents of the parameter’s *\<Information>\<Subtext>* tag.

In case of a Read/Write parameter, use the *Read* and *Write* checkboxes to indicate whether you want the page to contain the Read parameter, the Write parameter, or both.

On the right, you will notice the following buttons (depending on the type of parameter):

| Button | Function |
|--------|----------|
| Edit Parameter | Turns the parameter building block into a box that allows you to edit the parameter properties.<br> Click the red X in the upper-right corner to exit edit mode. |
| Edit Table | Opens the table editor to allow you to configure the (table) parameter in question. |
| Enable Trending | Enable trending for the parameter in question. |
| Enable Alarm Monitoring | Enable alarm monitoring for the parameter in question. |

When you right-click after selecting a parameter (or multiple parameters), a shortcut menu appears.

| Select...                 | in order to...                                          |
|---------------------------|---------------------------------------------------------|
| Go To XML (Apply Changes) | Save all changes and return to the XML editor.          |
| Trending \> Enabled       | Enable trending for the selected parameter(s).          |
| Trending \> Disabled      | Disable trending for the selected parameter(s).         |
| Alarm \> Enabled          | Enable alarm monitoring for the selected parameter(s).  |
| Alarm \> Disabled         | Disable alarm monitoring for the selected parameter(s). |
| Remove                    | Remove the selected parameter(s) from the page.         |

> [!NOTE]
> To select more than one parameter box, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive parameter boxes, click the first one in the list and then click the last one while holding down the SHIFT key.

### Parameters

By default, the *Parameters* list shows the ID and the name of every parameter defined in the protocol.

If, however, you click the magnifying glass icon at the top of the *Parameters* list, the list will show the ID, the name, the description, the type and the RTDisplay value of every parameter defined in the protocol.

Notice that, in the default *Parameters* list, the font color indicates whether a parameter has already been placed on one of the pages:

- Parameters in gray typeface have already been placed on one of the pages.
- Parameters in normal (black) typeface have not yet been placed on any of the pages.

At the bottom of the *Parameters* list, you can find the list filter.

## Apply changes / Cancel

If you want to save the changes you made and return to the XLM editor, click *Apply Changes*. If you want to discard the changes you made, click *Cancel*.

## Warning

A warning box can appear when you try to open the display editor.

Errors that cause this *Warning* box to appear include:

- No default page
- ...

> [!NOTE]
>
> - Parameters of which the RTDisplay attribute is set to False will be ignored. This way, we avoid problems with "disappearing parameters" in protocols in which multiple parameters have been assigned identical names.
> - When you place two parameters at the same location, a red box will be drawn around those parameters, and a warning icon will appear next to the page. You can then drag one of the parameters to another location to resolve the problem.
