---
uid: LineOptions
---

# LineOptions

Layers of type "table" and of type "relations" can have a `<LineOptions>` tag with the following (optional) attributes.

- **weight**: The stroke width in pixels. Default: 5.

- **color**: The stroke color. All CSS3 colors are supported, except the extended named colors.

  If you do not specify this "color" attribute and the coordinates are fetched from a database table, then you can make the lines take alarm colors by means of the TableSourceInfo.AlarmLevelColumnPID tag. for more information, see [TableSourceInfo](xref:TableSourceInfo).

  If you do not specify this "color" attribute and no other color information could be found, then the lines will take the color #BBBBBB.

- **opacity**: The stroke opacity. Range: 0.0 to 1.0. Default: 1.0.

- **geodesic**: When true, edges of the polygon are interpreted as geodesic and will follow the curvature of the Earth. When false, edges of the polygon are rendered as straight lines in screen space. Default: true.

Example:

```xml
<LineOptions weight="1" color="black" opacity="0.5" geodesic="true" />
```
