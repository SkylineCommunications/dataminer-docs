---
uid: Making_shapes_selectable
---

# Making shapes selectable

It is possible to tag a shape as "Selectable", so that instead of displaying the default hyperlink behavior, it will adopt a specially defined selection style when clicked.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[misc > SELECTABLE]* page.

## Tagging a shape as selectable

To tag a shape as "Selectable", add a shape data field to it of type **Options**, and set its value to "Selectable".

```txt
Selectable
```

## Defining a selection style

To define the selection style:

1. Create a shape.

1. Change its style in Visio.

1. Add a shape data field to it of type **Options** and set its value to "SelectionStyle".

   When a "Selectable" shape is clicked, it will adopt the style of this shape.

   ```txt
   SelectionStyle
   ```

## Making a selectable shape get copied to a session variable

If you want the text in a "Selectable" shape to be copied to a session variable when clicked, do the following:

1. Add a shape data field of type **Options** to the page.

1. Set the value of the shape data field to "SelectionVar=VariableName".

   ```txt
   SelectionVar=VariableName
   ```

1. By default the values of the selected shapes will be separated by a pipe character ("\|"). However, you can optionally specify that a different separator character should be used, for example in case the values need to be used in an Automation script.

   To do so, after the "SelectionVar=VariableName" option, add "\|MultipleValueSep=", followed by the separator of your choice. For example, if you specify the following, a semicolon will be used as the separator symbol:

   ```txt
   SelectionVar=VariableName|MultipleValueSep=;
   ```

> [!NOTE]
> When shapes are automatically generated, you can define a *SelectionVar* on group level, i.e. on the shape (or the shape group) where you specified a shape data field of type **Children**.

### Having the Selectable shape copied to multiple session variables

From DataMiner 9.5.1 onwards, it is possible to have the text of a "Selectable" shape copied to multiple session variables when a shape is clicked.

To do so, instead of specifying one variable name, as described above, specify a comma-separated list of session variables. The text displayed in the selectable shape will be copied to each of the listed variables when the shape is clicked.

| Shape data field | Value                                |
| ---------------- | ------------------------------------ |
| Options          | SelectionVar=*Var01*,*Var02*,*Var03* |

### Having specific information copied to particular session variables

From DataMiner 9.5.1 onwards, you can also have the session variables listed in a "SelectionVar=" clause set to a particular piece of information about the item to which the clicked Selectable shape is linked.

To do so, after you specify the variable, also specify the information to be set, using the same keywords as when making a shape display information about an item it is linked to.

| Shape data field | Value                                                              |
| ---------------- | ------------------------------------------------------------------ |
| Options          | SelectionVar=*Var01*=*Keyword*,*Var02*=*Keyword*,*Var03*=*Keyword* |

> [!NOTE]
> For an overview of the keywords that can be used, see [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

Example:

- In the following example, *Var01* will be set to the name of the object to which the shape is linked, and *Var02* will be set to the ID of the object to which the shape is linked.

  | Shape data field | Value                            |
  | ---------------- | -------------------------------- |
  | Options          | SelectionVar=Var01=Name,Var02=ID |

- In the following example, the shape is linked to an alarm. *Var01* will be set to the alarm ID, and *Var02* will be set to the alarm property called "Priority".

  | Shape data field | Value                                                    |
  | ---------------- | -------------------------------------------------------- |
  | Options          | SelectionVar=Var01=Alarm ID,Var02=AlarmProperty:Priority |
