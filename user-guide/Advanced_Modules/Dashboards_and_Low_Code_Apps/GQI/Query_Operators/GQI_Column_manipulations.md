---
uid: GQI_Column_manipulations
---

# Column manipulations

The *Column manipulations* query operator creates a new column based on existing columns. When you select this option, you also need to select a manipulation method:

If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

> [!TIP]
> See also: [How to do Column Manipulation with GQI](https://community.dataminer.services/video/how-to-do-column-manipulation-with-gqi/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
