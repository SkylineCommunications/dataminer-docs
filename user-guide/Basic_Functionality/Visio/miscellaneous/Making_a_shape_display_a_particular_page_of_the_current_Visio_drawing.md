---
uid: Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing
---

# Making a shape display a particular page of the current Visio drawing

When a shape is linked to a view, a service or an element, it can be set to display a page of the Visio drawing linked to that view, service or element. From DataMiner 10.0.2 onwards, a shape can also be configured to display a page of the current Visio drawing when the shape is not linked to a particular object, or when it is linked to a different kind of object, e.g. an alarm.

That page can be displayed:

- inside the shape itself,

- in a pop-up window that appears when the shape is clicked,

- in a normal, undocked window that appears when the shape is clicked, or

- in a tooltip.

> [!NOTE]
>
> - You can only make a shape display pages other than the page actually containing the shape. This restriction is necessary to avoid loops of inline pages.
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _inline visio > BUTTONS_.

## Basic shape data field configuration

Add a shape data field of type **VdxPage** to the shape, and set its value to the name of the page, optionally followed by “_\|Popup_”, “_\|Window_” or “_\|Tooltip_”:

```txt
PageName|Option
```

| Shape data value  | Result                                                                        | Example                |
| ----------------- | ----------------------------------------------------------------------------- | ---------------------- |
| PageName          | The page is displayed in the shape itself.                                    | MyPage                 |
| PageName\|Popup   | The page is displayed in a pop-up window when the shape is clicked.           | MyPage\|Popup          |
| PageName\|Window  | The page is displayed in a normal, undocked window when the shape is clicked. | MyOtherPage\|Window    |
| PageName\|Tooltip | The page is displayed in a tooltip.                                           | MySpecialPage\|Tooltip |

> [!NOTE]
> If, in the value of the **VdxPage** shape data field, you replace the page name by “_\[auto\]_”, the window will contain the page of which the **InlineVdx** shape data field has been set to _TRUE_. See [Marking a page of a Visio drawing as the default page](xref:Marking_a_page_of_a_Visio_drawing_as_the_default_page).

## Optional configuration

To fine-tune the way the page is displayed, a number of additional options are available:

- [Making the window close automatically](#making-the-window-close-automatically)

- [Configuring what should happen when a window is closed](#configuring-what-should-happen-when-a-window-is-closed)

- [Configuring the size of the window](#configuring-the-size-of-the-window)

- [Configuring a custom shortcut menu](#configuring-a-custom-shortcut-menu)

- [Setting the border style of the window](#setting-the-border-style-of-the-window)

- [Setting the pop-up window to be displayed in front of other windows](#setting-the-pop-up-window-to-be-displayed-in-front-of-other-windows)

### Making the window close automatically

If **VdxPage** is set to “_PageName\|Popup_”, you can make the pop-up window close automatically when a shape is clicked inside the window. To do so, add a shape data field **Options** and set it to _AutoClosePopup_:

| Shape data field | Value          |
| ---------------- | -------------- |
| VdxPage          | MyPage\|Popup  |
| Options          | AutoClosePopup |

Alternatively, from DataMiner 9.6.1 onwards, you can configure a specific shape within the pop-up window to close the window after the shape’s main action is executed. To do so, add the _ClosePage_ option to the shape data of the shape:

| Shape data field | Value     |
| ---------------- | --------- |
| Options          | ClosePage |

### Configuring what should happen when a window is closed

From DataMiner 10.0.13 onwards, the **OnClosing** page-level shape data field allows you to configure what should happen when a Visual Overview window is closed. Depending on how this shape data is configured, a message box will be displayed asking for confirmation, possibly with a custom message.

In this shape data field, specify a script (example: Script:MyScript), and make sure the script contains an instruction like the following one:

```txt
engine.AddScriptOutput(UIVariables.VisualOverview.ClosingWindow_Result,ClosingMode.Continue.ToString());
```

The session variable named _ClosingWindow_Result_ can be set to “Continue”, “Stop” or “Abort”.

In the example above, it is set to “Continue”. If _ClosingWindow_Result_ is set to “Stop”, a message box of type “Yes/No” will appear. If the user then clicks “Yes”, the window will be closed. Note that in the session variable named _ClosingWindow_Message_, you can specify a custom message to be displayed. If you specify such a message, then it will be shown in a message box of type “OK”, regardless of the value of the _ClosingWindow_Result_ variable. However, if _ClosingWindow_Result_ is set to “Stop”, this custom message will be displayed in the message box of type “Yes/No” mentioned above.

> [!NOTE]
>
> - The _OnClosing_ shape data field only works for windows. It does not work for message boxes or tooltips.
> - The _OnClosing_ and _OnClose_ shape data fields do not influence each other. Both function independently from each other.
> - If you want to combine _OnClosing_ and _OnClose_, you can pass a session variable to the _OnClosing_ script and make it return another session variable. That variable can then be passed to the _OnClose_ script, which can optionally be made to return another session variable.

> [!TIP]
> See also:
> [Specifying a script to be executed when the page is closed](xref:Linking_a_shape_to_an_Automation_script#specifying-a-script-to-be-executed-when-the-page-is-closed)

### Configuring the size of the window

If you added a “_\|Popup_” or a “_\|Window_” option to have the Visio page appear in a separate window, you can use a shape data field of type **LinkOptions** to set the size of that window.

To do so:

- Add a shape data field of type **LinkOptions** to the shape, and set its value to:

  ```txt
  Width=999|Height=999
  ```

  For both the width and the height of the window, specify either a fixed number of pixels or a placeholder referring to a property, a parameter or a session variable containing a number of pixels. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _inline visio > BUTTONS_.

### Configuring a custom shortcut menu

By default, when you right-click a Visio drawing displayed in a shape, the shortcut menu of the Visio drawing containing that shape will appear. If you want the Visio drawing inside the shape to have its own shortcut menu, add a shape data field of type **Options** to the shape displaying the Visio drawing, and set its value to _InlineVisioContextMenuVisible_.

| Shape data field | Value                         |
| ---------------- | ----------------------------- |
| Options          | InlineVisioContextMenuVisible |

### Setting the border style of the window

From DataMiner 9.6.13 onwards, if you added a “_\|Window_” option to have the Visio page appear in a separate window, to set the border style of the window, you can use a shape data field of type **LinkOptions** and set it to one of the following values:

| Value                          | Description                                                                                 |
| ------------------------------ | ------------------------------------------------------------------------------------------- |
| WindowStyle=SingleBorderWindow | The window will be displayed with a single border                                           |
| WindowStyle=ThreeDBorderWindow | The window will be displayed with a 3D border.                                              |
| WindowStyle=ToolWindow         | The window will be displayed as a fixed-size tool window without minimize/maximize buttons. |

### Setting the pop-up window to be displayed in front of other windows

From DataMiner 9.6.13 onwards, if you added a “_\|Popup_” or a “_\|Window_” option to have the Visio page appear in a separate window, to make sure the window is always displayed in front of the window it was launched from, you can use a shape data field of type **LinkOptions** and set it to _KeepOnTop=true_.

| Shape data field | Value          |
| ---------------- | -------------- |
| LinkOptions      | KeepOnTop=true |
