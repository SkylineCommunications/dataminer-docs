---
uid: Positioning_shapes_in_a_grid_layout
---

# Positioning shapes in a grid layout

In a Visio drawing, you can position shapes in a grid layout. This allows you to create shapes that automatically adapt to the available screen real estate.

> [!NOTE]
>
> - When this feature is used, the Visio drawing will be displayed at 100% zoom level.
> - From DataMiner 9.5.11 onwards, placeholders for variables can be used in Layout shape data, so that the positioning of shapes in a grid can be controlled dynamically (e.g. by using a session variable).

> [!TIP]
>
> - See also: [DataMiner Inspire – Advanced Visual Overview Features](https://community.dataminer.services/video/dataminer-inspire-advanced-visual-overview-features/) ![Video](~/user-guide/images/video_Duo.png)
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[positioning > GRID]* page.

## Configuring the shape data fields

### On page level

On page level, use a shape data field of type Layout to define the following grid properties.

| Property | Description |
| -------- | ----------- |
| Control=Grid | Indication that you want to create a grid. |
| Columns= | The column definitions, separated by semicolons (";").<br>Every column definition can have the following format (*MinWidth* and *MaxWidth* are optional):<br>*Width,MinWidth,MaxWidth*<br> Possible values: See [Column and row definitions](#column-and-row-definitions). |
| Rows= | The row definitions, separated by semicolons (";").<br>Every row definition can have the following format (*MinHeight* and *MaxHeight* are optional):<br> *Height,MinHeight,MaxHeight*<br>Possible values: See [Column and row definitions](#column-and-row-definitions). |
| VerticalScrollBarVisibility | Whether or not there has to be a vertical scrollbar. Optional.<br>Possible values: "Auto", "Hidden", "Disabled" or "Visible"<br>See also [Column and row definitions](#column-and-row-definitions) .                                                                    |
| HorizontalScrollbarVisibility | Whether or not there has to be a horizontal scrollbar. Optional.<br>Possible values: "Auto", "Hidden", "Disabled" or "Visible"<br>See also [Column and row definitions](#column-and-row-definitions). |

### On shape level

To every shape that you want to place inside the grid, add a shape data field of type **Layout** and specify the following properties as required. It is not necessary to specify all properties; only add those for which you want the shape to behave different from the default behavior.

| Property | Description |
| -------- | ----------- |
| Grid.Col= | The column in which to put the shape. |
| Grid.ColSpan= | The number of columns the shape has to span. |
| Grid.Row= | The row in which to put the shape. |
| Grid.RowSpan= | The number of rows the shape has to span. |
| Margin= | The margin between the shape and the cell borders.<br>Order: left,top,right,bottom |
| VerticalAlignment= | The vertical alignment of the shape inside the cell. Should be set to one of the following values:<br>- *Top*<br>- *Center*<br>- *Bottom*<br>- *Stretch* (from DataMiner 9.6.12 onwards) |
| HorizontalAlignment= | The horizontal alignment of the shape inside the cell. Should be set to one of the following values:<br>- *Left*<br>- *Center*<br>- *Right*<br>- *Stretch* (from DataMiner 9.6.12 onwards) |
| Width= | The width of the shape. |
| MinWidth= | The minimum width of the shape. |
| MaxWidth= | The maximum width of the shape. |
| Height= | The height of the shape. |
| MinHeight= | The minimum height of the shape. |
| MaxHeight= | The maximum height of the shape. |

## Column and row definitions

In a column or a row definition, you specify a series of values (one for every column or row), separated by semicolons (";"). Each of those values can be an integer, an asterisk ("\*") or "Auto".

| Value   | Description                                                           |
| ------- | --------------------------------------------------------------------- |
| Integer | A number of pixels (i.e. a fixed column width or row height)          |
| \*      | A weighted proportion of the available width/height.                  |
| Auto    | Column width or row height is determined by the size of its contents. |

In case of "\*", you can also specify e.g. "2\*". If you have two columns and you specify "\*;2\*", then the first column will get one third of the available width and the second column will get two thirds of the available width.

The following code, for example, will create a grid with 6 columns and 9 rows:

```txt
Control=Grid|Columns=Auto;*;Auto;Auto;Auto;Auto| Rows=Auto;Auto;Auto;Auto;*;Auto;20;Auto;Auto| VerticalScrollBarVisibility=Disabled|HorizontalScrollBarVisibility=Disabled
```

By default, scrolling is disabled when using proportional column widths and row heights (i.e. when using column widths and row heights equal to "\*"). So, when you do not specify any scrollbar visibility settings, the following page-level settings will be used by default:

```txt
VerticalScrollBarVisibility=Disabled|HorizontalScrollBarVisibility=Disabled
```

> [!NOTE]
> Changing the default scroll behavior is not advised when using components that automatically generate a large number of shapes, as this can lead to unpractical layouts and high resource usage.

## Examples

Example of a page-level value:

```txt
Control=Grid|Columns=Auto;*;Auto;Auto;Auto;Auto| Rows=Auto;Auto;Auto;Auto;*;Auto;20;Auto;Auto| VerticalScrollBarVisibility=Disabled|HorizontalScrollBarVisibility=Disabled
```

Example of a shape-level value:

```txt
Grid.Col=5|Grid.Row=2|VerticalAlignment=Top|Margin=10 0 10 5
```
