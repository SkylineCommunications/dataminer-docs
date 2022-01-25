---
uid: UIBuilder_properties
---

## UIBuilder properties

- [ColumnDefs](#columndefs)

- [Height](#height)

- [MaxHeight](#maxheight)

- [MaxWidth](#maxwidth)

- [MinHeight](#minheight)

- [MinWidth](#minwidth)

- [RequireResponse](#requireresponse)

- [RowDefs](#rowdefs)

- [Title](#title)

- [Width](#width)

> [!NOTE]
> Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.

#### ColumnDefs

Gets or sets the widths (in pixels) of all columns of the dialog box grid, separated by semicolons.

Instead of a pixel value, you can also specify the following values:

| Value                                                               | Description                                                                                         |
|---------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|
| *auto* or *a* | The width of the column will be automatically adapted to the widest dialog box item in that column. |
| \*                                                                  | The column will have the largest possible width, depending on the width of the other columns.       |

```txt
string ColumnDefs
```

> [!NOTE]
> If automatic ColumnDefs are specified, e.g. "*a;a;a;a*", and you want to show a UIBlockDefinition with a columnspan, then the space for each column will be equal, so other blocks will also move. To avoid this, you can change the ColumnDefs to "*a;a;a;a;\**". The extra '\*' column will use all extra available space. Then change the columnspan so the block uses that new '\*' column.

Example:

```txt
UIBuilder uib = new UIBuilder();
uib.ColumnDefs = "a;a;a;a;*" //4 columns + extra space column
UIBlockDefinition uibd = new UIBlockDefinition();
uibd.Column = 0; //on column pos 0 (0-based)
uibd.ColumnSpan = 5 // if column pos=1, columnspan = 4
```

#### Height

Gets or sets the fixed height (in pixels) of the dialog box.

```txt
int Height
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### MaxHeight

Gets or sets the maximum height (in pixels) of the dialog box.

```txt
int MaxHeight
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### MaxWidth

Gets or sets the maximum width (in pixels) of the dialog box.

```txt
int MaxWidth
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### MinHeight

Gets or sets the minimum height (in pixels) of the dialog box.

```txt
int MinHeight
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### MinWidth

Gets or sets the minimum width (in pixels) of the dialog box.

```txt
int MinWidth
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### RequireResponse

Gets or sets a value indicating whether the dialog box expects some action from the user (e.g. clicking a button, selecting a checkbox, selecting an entry in a selection box, etc.).

```txt
bool RequireResponse
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### RowDefs

Gets or sets the height (in pixels) of all rows of the dialog box grid, separated by semicolons.

Instead of a pixel value, you can also specify the following values:

| Value | Description                                                                                     |
|-------|-------------------------------------------------------------------------------------------------|
| auto  | The height of the row will be automatically adapted to the highest dialog box item in that row. |
| \*    | The row will have the largest possible height, depending on the height of the other rows.       |

```txt
string RowDefs
```

Example: See [UIBuilder example](xref:UIBuilder_example).

#### Title

Gets or sets the title of the dialog box. Available from DataMiner 9.6.6 onwards.

```txt
string Title
```

Example:

```txt
var uib = new UIBuilder()
uib.Title = "Interactive Automation script"
```

> [!NOTE]
> In case no title is specified, the name of the Automation script is used as the title.

#### Width

Gets or sets the fixed width (in pixels) of the dialog box.

```txt
int Width
```

Example: See [UIBuilder example](xref:UIBuilder_example).
