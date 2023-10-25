---
uid: ChangeColumnOrder
---

# Change column order

Changing the order (idx) of the columns in a table is considered a major change only when the table information can be requested externally (other elements, WebAPI, Automation scripts, etc).

If the table is hidden (*RTDisplay* = false) it is not considered a major change.

## Impact

A shift in idx will result in incorrect parsing of the data where requesting the table information from external sources.

Note that when the column of type *displaykey* needs to be moved (for example to add new columns in front), then no major change is required (only when the display key column is already the last column idx).

The *displaykey* column is in this case only used to display the display key in Cube and should not be causing issues.

## Workarounds

There is no workaround.