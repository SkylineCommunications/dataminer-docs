---
uid: Linking_a_shape_to_an_Asset_Manager_table
---

# Linking a shape to an Asset Manager table

It is possible to link a shape to an Asset Manager table. To do so, create a shape, and add the following shape data fields to it:

| Shape data field | Value |
|--|--|
| Component | IAM |
| AssetConfig | The name of the Asset Manager database configuration that contains the table to be displayed (without the ".xml" extension). |
| Table | The name of the database table. |
| Columns | The comma-separated list of columns that have to be displayed.<br> If you do not specify this shape data field or leave it empty, all columns will be displayed. |
| Filter | The comma-separated list of conditions that have to be used as a row filter. If multiple conditions are specified, a row will only be displayed if all the conditions are met.<br> Each of the conditions must have the following syntax: *ColumnName==Value*<br> Note: *Value* has to be an actual database value. If, for example, you want to specify a boolean value, specify "1" instead of "True". |

Optionally, you can also add the following shape data fields:

| Shape data field | Value |
|--|--|
| Limit | Integer indicating the maximum number of rows. |
| Order by | The name of the column by which to order the table. |
| Options | *WhereCombination=AND*, or *WhereCombination=OR*<br>The operator that will be used to combine the filter items in the shape data field of type *Filter*. Default: AND. |

> [!NOTE]
>
> - [Dynamic placeholders](xref:Placeholders_for_variables_in_shape_data_values) can be used in each of these shape data fields.
> - To specify a column name, ideally, you should use the database column name. However, it is also possible to use the display column name.
