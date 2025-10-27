---
uid: Creating_a_text_block_control
---

# Creating a text block control

It is possible to display a block of text in Visual Overview like a regular Cube text block control, with the default Cube font and font size.

- To do so, to the shape containing the text, add the shape data field **Options**, and set it to *Control=TextBlock*.

  | Shape data field | Value             |
  |--------------------|-------------------|
  | Options            | Control=Textblock |

- To also specify the behavior of the text block scrollbars, add the *HorizontalScrollbarVisibility=* and *VerticalScrollbarVisibility=* options to the **Options** shape data field:

  | Shape data field | Value                                                                                                   |
  |------------------|---------------------------------------------------------------------------------------------------------|
  | Options          | Control=Textblock\|<br> HorizontalScrollbarVisibility=*Value*\|<br> VerticalScrollbarVisibility=*Value* |

  *HorizontalScrollbarVisibility* and *VerticalScrollbarVisibility* can be set to the following values:

  - *Auto*: A scrollbar is displayed when the text block cannot display all the content.

  - *Visible*: The scrollbar is always displayed.

  - *Hidden*: The scrollbar is never displayed, but the content is allowed to scroll.

  - *Disabled*: The scrollbar is never displayed and scrolling is not possible.

  > [!NOTE]
  > For more detailed information on these values, see <https://msdn.microsoft.com/en-us/library/system.windows.controls.scrollbarvisibility(v=vs.110).aspx>
