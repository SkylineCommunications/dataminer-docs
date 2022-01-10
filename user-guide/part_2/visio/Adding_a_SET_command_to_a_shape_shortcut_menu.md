## Adding a SET command to a shape shortcut menu

If a shape is linked to an element, you can use a shape data field of type **Set** to add a SET command to the shape’s shortcut menu. Such a menu command will allow users to change parameter values simply by right-clicking a shape.

### Configuring the shape data field

Add a shape data field of type **Set** to the shape, and set its value to:

```txt
ID of a write parameter;Shortcut menu command[;TableRow]
```

> [!NOTE]
> If you want to add multiple commands, separate the entries by pipe characters.

### Examples

```txt
1103;Change password
```

When users right-click the shape, they will notice a *Change password...* command at the bottom of the shortcut menu. If they click that command, a *Set Parameter* dialog box will appear, allowing them to change the value of that parameter.

```txt
1102;Change username|1103;Change password
```

When users right-click the shape, they will notice two commands at the bottom of the shortcut menu: *Change username...* and *Change password...*
