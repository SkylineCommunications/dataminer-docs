---
uid: Conditionally_showing_or_hiding_a_page_of_a_Visio_drawing
---

# Conditionally showing or hiding a page of a Visio drawing

A page of a Visio drawing can be shown or hidden:

- depending on the current value of a parameter or a property (see [Depending on the current value of a parameter or a property](#depending-on-the-current-value-of-a-parameter-or-a-property)).
- depending on the DataMiner client application that is being used (see [Depending on the DataMiner client application that is being used](#depending-on-the-dataminer-client-application-that-is-being-used)).

If a page is hidden, it will not be displayed in the tree view of a card navigation pane.

> [!NOTE]
>
> - If a user opens the Visual pages of a card, but all Visio pages are hidden, e.g. because of conditional hiding, a line of type Info will be added to the Cube logging to indicate this.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[misc > CUBE ONLY]* page.

## Depending on the current value of a parameter or a property

Add a shape data field of type **Options** to the page, and set its value to:

```txt
Visible=[ParameterOrProperty];Condition;Condition;...
Hidden=[ParameterOrProperty];Condition;Condition;...
```

> [!NOTE]
>
> - The parameter or property is evaluated only when the page is (re)loaded. The page will not suddenly appear or disappear when the parameter or the property gets updated.
> - Currently, only the \[param:...\] and \[property:...\] placeholders are supported with this option.

### Examples

If you use the following option, the page will be visible if property *VisiblePage* contains "Value3":

```txt
Visible=[Property:VisiblePage];=Value3
```

If you use the following option, the page will be visible if parameter 177 of the current element does not contain 0, 1 or 3:

```txt
Hidden=[Param:*,177];=0;=1;=3
```

### Condition operators

| Operator | Description              |
| -------- | ------------------------ |
| =        | equal to                 |
| \>=      | greater than or equal to |
| \>       | greater than             |
| \<=      | less than or equal to    |
| \<       | less than                |
| !=       | not equal to             |

> [!NOTE]
> String values can only be compared using "=" or "!=".

## Depending on the DataMiner client application that is being used

By specifying that certain pages should be hidden in DataMiner Cube or in the DataMiner web apps, you can optimize your drawings for the type of client application where they will be used. This way you can for example hide pages using "Cube only" features in web apps, or make pages for use in for web apps only.

To do so, add a shape data field of type **Options** to the page, and set its value to:

```txt
Hidden=Cube|Mobile
```

For example, if you specify "Hidden=Cube", the page will only be shown in web apps such as the Monitoring app and the Dashboards app.
