---
uid: Calibrating_the_X_and_Y_coordinates_in_a_Visio_drawing
---

# Calibrating the X and Y coordinates in a Visio drawing

If, in a Visio drawing, you want to position shapes using X and Y coordinates, you have to calibrate the X and Y axis.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[positioning > DYNAMIC]* page.

## Calibrating the X and Y axis

Create two dummy shapes, and add two shape data fields to each of them: one of type **XPos** and one of type **YPos**.

1. Create a dummy shape in the top-left corner with the following shape data fields:

   | Shape data field | Value                                 |
   | ---------------- | ------------------------------------- |
   | XPos             | *\[Leftmost position on the X-axis\]* |
   | YPos             | *\[Topmost position on the Y-axis\]*  |

1. Create a dummy shape in the lower right corner with the following shape data fields:

   | Shape data field | Value                                   |
   | ---------------- | --------------------------------------- |
   | XPos             | *\[Rightmost position on the X-axis\]*  |
   | YPos             | *\[Bottommost position on the Y-axis\]* |

Result: The page now has a virtual grid in relation to which all other shapes can be positioned.

## Example

If you want a Visio page to have an X-Y grid of 100 by 50, create the following shapes.

- In the top-left corner, create a shape with the following shape data fields:

  | Shape data field | Value |
  | ---------------- | ----- |
  | XPos             | 00    |
  | YPos             | 00    |

- In the lower right corner, create a shape with the following shape data fields:

  | Shape data field | Value |
  | ---------------- | ----- |
  | XPos             | 100   |
  | YPos             | 50    |
