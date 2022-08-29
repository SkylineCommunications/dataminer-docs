---
uid: Making_a_shape_display_a_custom_drawing_using_Path_markup
---

# Making a shape display a custom drawing using Path markup

In Visio shapes, you can make custom drawings using WPF Path markup.

Add a shape data field of type **Path** to a shape, and enter path markup in its value:

```txt
data;Stroke;Fill;StrokeThickness;Tooltip;YAxisUp;bottomLeftX;bottomLeftY;topRightX;topRightY;link
```

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > PATH]* page.

## Syntax

See below for more information on the different components of the Path string.

- **data**: The Path markup that defines the drawing. For more information on Path markup, see <http://msdn.microsoft.com/en-us/library/ms752293(v=vs.110).aspx>.
- **Stroke**: The line color (name of color or "#aarrggbb").
- **Fill**: The line color (name of color or "#aarrggbb").
- **Strokethickness**: The line thickness.
- **Tooltip**: The tooltip text.
- **YAxisUp**: 0 or 1.
- **bottomLeftX;bottomLeftY;topRightX;topRightY**: The coordinates of the lower left and top-right corner of the shape. To be used when using relative positioning.
- **link**: The name or the ID of the element or service to jump to when the shape is clicked. When you right-click the shape, you will see the default shortcut menu of that element or service.

### Example of a Path string

```txt
M 0,10 L 0,7 L 2,6 L 4,9 L 6,12 L 8,11 L 10,9 L 12,8 L 14,14 L 16,6 L 18,11 L 20,5 L 22, 7 L 24,8 L 26,14 L 28,11 L 30,11 L 32,7 L 34,11 L 36,12 L 38,12 L 40,14 L 42,5 L 44,6 L 46, 8 L 48,12 L 50,10 M 200,10 L 202,8 L 204,9 L 206,8 L 208,10 L 210,8 L 212,5 L 214,6 L 216, 7 L 218,9 L 220,12 L 222,6 L 224,6 L 226,13 L 228,14 L 230,8 L 232,14 L 234,11 L 236,13 L 238, 11 L 240,14 L 242,10 L 244,11 L 246,6 L 248,5 L 250,10 M 302,10 L 304,11 L 306,11 L 308,6 L 310, 10 L 312,11 L 314,8 L 316,8 L 318,10 L 320,6 L 322,14 L 324,13 L 326,5 L 328,8 L 330,13 L 332, 12 L 334,8 L 336,13 L 338,13 L 340,9 L 342,7 L 344,12 L 346,13 L 348,8 L 350,10 M 400,10 L 404, 8 L 406,6 L 408,5 L 410,14 L 412,9 L 414,13 L 416,7 L 418,9 L 420,12 L 422,6 L 424,7 L 426, 5 L 428,6 L 430,7 L 432,14 L 434,6 L 436,5 L 438,9 L 440,10 L 442,13 L 444,11 L 446,9 L 448, 9 L 450,10 L 452,14 L 454,8 L 456,14 L 458,5 L 460,9 L 462,6 L 464,11 L 466,13 L 468,8 L 470, 5 L 472,10 L 474,13 L 476,11 L 478,5 L 480,8 L 482,9 L 484,11 L 486,7 L 488,11 L 490,7 L 492, 7 L 494,8 L 496,7 L 498,10 L 500,8;Green;#ff0000;1;noise;true;0;0;500;150;MyElement
```

### Multiple paths in one shape

One shape data field of type **Path** can contain multiple paths, separated by pipe characters:

```txt
path1|path2|...|pathZ
```

Example:

```txt
M 98,399 L 92,380 91,363 90,349 87,336 335,378 350,392 358,398 99,399 z;white;Black;0; This is a tooltip;false;|M 89,339 L 86,310 85,292 81,259 82,234 91,203 101,187 110, 184 118,189 131,192 147,196 164,199 171,223 179,242 191,254 205,259 218,263 232,268 235, 281 245,302 255,326 264,356 262,377 262,397 96,399 91,375 90,354 Z;white;white;0
```

### Multiple paths fetched from a table

In a shape data field of type **Path**, you can also refer to a table in which each row contains a path to be drawn:

```txt
[Param:element,tablePid]
```

In the table you can define a pathFormat for the row in the column options of the primary key column. In that path format, you can use \[Param:ColPid\] to refer to a cell value in a particular column of the row.

Example:

```xml
<ColumnOption idx="0" pid="111" type="custom" value=""
  options="[Sep:;|]PathFormat=M [Param:114],
    [Param:122] L [Param:116],[Param:124] L [Param:118],
    [Param:126] L [Param:120],[Param:128];DarkGray;
    #99000000;1;[Param:130]&#xA;
    Start Frequency: [Param:114]&#xA;&#xA;(Click to open);
    true;0;0;500;150;[Param:132]" />
```

## Making subshapes display labels

In subshapes, you can define labels. The text in those shapes will then be replaced by the actual position, based on the path data.

Add a shape data field of type **Path** and set its value to:

```txt
XLabel
YLabel
```

> [!NOTE]
> For this label feature to work, you have to specify *bottomLeft* and *topRight* coordinates in the path data.

## Making subshapes display units of measure

It is possible to have one or more subshapes display units of measure. To do so:

- In the main shape, add the following components to the WPF Path specified in a shape data field of type **Path**:

  | Component    | Description                                               |
  | ------------ | --------------------------------------------------------- |
  | LabelFactorX | Factor with which to multiply the X-axis values (double). |
  | LabelFactorY | Factor with which to multiply the Y-axis values (double). |
  | UnitX        | The unit of measure for the X-axis (string).              |
  | UnitY        | The unit of measure for the Y-axis (string).              |

  Path syntax:

  ```txt
  Path:data;Stroke;Fill;StrokeThickness;Tooltip;YAxisUp;bottomLeftX; bottomLeftY;topRightX;topRightY;link;LabelFactorX;LabelFactorY; UnitX;UnitY
  ```

- In every subshape that has to contain a unit of measure, add a shape data field of type **Path**, and set its value to one of the following values:

  ```txt
  XUnit
  YUnit
  ```

## Enabling horizontal zooming

From DataMiner 9.0.5 onwards, it is possible to enable horizontal zooming on a shape configured to display a custom drawing using path markup.

To do so, add the following option to the shape:

| Shape data field | Value                |
| ---------------- | -------------------- |
| Options          | EnableHorizontalZoom |

> [!NOTE]
>
> - If labels are defined for the path shapes, these will update along with the zoom level.
> - Zooming in on the Visual Overview page is still possible when the mouse pointer is not over the shape.
