---
uid: Basic_conditional_shape_manipulation_actions
---

# Basic conditional shape manipulation actions

In some shape data fields, especially fields that display the current value of a parameter, property or session variable, you can specify conditional shape manipulation actions. These allow you to have a shape shown, hidden, flipped, rotated or colored based on the current value of the parameter, property or session variable to which that shape is linked.

> [!NOTE]
>
> - To also apply conditional shape manipulation actions on other linked shapes, e.g. shapes linked to Automation scripts, or to combine multiple conditions, see [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[misc > MANIPULATION]* page.

## Action overview

- **Show;condition**

  The shape will be shown if the condition is TRUE.

- **Hide;condition**

  The shape will be hidden if the condition is TRUE.

- **FlipX;condition**

  The shape will be flipped around its X axis if the condition is TRUE.

- **FlipY;condition**

  The shape will be flipped around its Y axis if the condition is TRUE.

- **Rotate;condition,degrees**

  The shape will be rotated a number of degrees (clockwise) if the condition is TRUE.

- **Blink;condition**

  The shape will blink if the condition is TRUE.

- **LineColor;condition,color**

  The line color of the shape (or the connection) will be set to the specified color if the condition is TRUE. Colors can be specified either as predefined names (see link below) or as hexadecimal RGB values ("#rgb", "#rrggbb", "#aarrggbb"). <https://msdn.microsoft.com/en-us/windows/aa358802(v=vs.71)>

- **FillColor;condition,color**

  The fill color of the shape will be set to the specified color if the condition is TRUE. Colors can be specified either as predefined names (see link below) or as hexadecimal RGB values ("#rgb", "#rrggbb", "#aarrggbb"). <https://msdn.microsoft.com/en-us/windows/aa358802(v=vs.71)>

> [!NOTE]
> It is not possible to use wildcards in the condition, but you can use regular expressions.

## Condition operators

The condition section of the action can contain the following operators:

| Operator | Description              |
| -------- | ------------------------ |
| =        | equal to                 |
| ==       | equal to                 |
| \>=      | greater than or equal to |
| \>       | greater than             |
| \<=      | less than or equal to    |
| \<       | less than                |
| !=       | not equal to             |

> [!NOTE]
> String values can only be compared using "=" or "!=".

## Combining actions and conditions

Actions can be combined using pipe characters ("\|").

- Example:

  ```txt
  FlipX;<10|Rotate;=10,90|FlipY;>10
  ```

Within one type of action, multiple conditions can be separated by semicolons (";").

- Examples

  ```txt
  34|Rotate;Auto,180;Int,90;Auxif,270
  176|LineColor;=9,Pink;=15,AliceBlue|FillColor;=9,AliceBlue;=15,Pink
  ```

If you combine unconditional actions, separate them by semicolons (";"), but make sure to repeat the action.

- Example:

  ```txt
  Show;=Available;Show;=Failed
  ```
