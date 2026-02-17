---
uid: Specifying_additional_tables_for_the_EPM_Details_pane
---

# Specifying additional tables for the EPM Details pane

Using a shape data field of type **SelectionDetails**, you can specify additional tables that you want to see listed in the *Details* pane of the EPM interface when someone selects the shape or the line.

## Configuring the shape data field

Add a shape data field of type **SelectionDetails** to the shape, and set its value to:

```txt
|ExtraTableID1|ExtraTableID2|...
```

Example:

```txt
|3000|3001|3002
```
