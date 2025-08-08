---
uid: Conditional_shape_highlighting
---

# Conditional shape highlighting

Visio shapes linked to elements, services, redundancy groups or views can be highlighted based on whether or not a condition is true.

> [!NOTE]
>
> - For more information on how to make a shape display the number of highlighted shapes, see [Making a shape display the number of highlighted shapes on a page](xref:Making_a_shape_display_the_number_of_highlighted_shapes_on_a_page).
> - In order to trigger conditional highlighting based on parameters, alarms or properties that are not present on the element represented by the current shape, extended conditional shape manipulation can be used. See [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions).
> - If multiple kinds of highlighting are used in one drawing, and only a single highlighting style is used, all highlight conditions must be true for an object to be highlighted.
> - If multiple kinds of highlighting are used in one drawing, i.e. connectivity highlighting using the _HighlightTarget_ shape data combined with redundancy group highlighting and/or conditional shape highlighting, and a different highlighting style is used for each type, a shape will be highlighted as soon as one of the highlight conditions is true. See [Applying highlight styles depending on various conditions](xref:Options_for_highlighting_DCF_connections#applying-highlight-styles-depending-on-various-conditions).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[dcf > HIGHLIGHT and MULTI]* pages.

## Configuration

1. Define a highlight style: create a shape, apply a custom style to it, add a shape data field to it of type **Options** and set its value to "HighlightStyle".

1. To each shape, add a shape data field of type **Highlight** in which you specify when that shape has to adopt the highlight style defined in step 1:

   ```txt
   Condition1|Condition2|...|ConditionX
   ```

## Condition syntax

Every condition specified in a shape data field of type **Highlight** has to have the following syntax:

```txt
Source=RegEx
```

Source has to be either

- the name of the element, service, redundancy group or view, or
- a property of the element, service or view ("Property:xxx").

RegEx has to be a regular expression.

> [!NOTE]
> In conditions, both single equal signs ("=") and double equal signs ("==") are supported.

## Creating dynamic conditions

Inside a condition, you can use placeholders referring to parameter values or session variables. This way, highlight styles can be applied dynamically.

Suppose you have an element shape with the following highlight condition:

```txt
[Sep:|^]Name=.*[Var:SearchServiceQuery].*^Property:Type=.*[Var:CheckBoxes].*
```

The first part of the regular expression (\*Name=.\*\[Var:SearchServiceQuery\].\*\*) defines that the name of the element has to contain the value of the session variable named “SearchServiceQuery”.

The second part of the regular expression (\*Property:Type=.\*\[Var:CheckBoxes\].\*\*) defines that the element property *Type* has to contain one of the types in session variable *CheckBoxes* (which can contain multiple values separated by pipe characters).
