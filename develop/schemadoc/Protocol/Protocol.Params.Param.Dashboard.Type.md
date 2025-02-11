---
uid: Protocol.Params.Param.Dashboard.Type
---

# Type element

Indicates the type of button panel.

## Content type

string

## Parent

[Dashboard](xref:Protocol.Params.Param.Dashboard)

## Remarks

Can be set to one of the following values:

- **button panel**: The parameter is a table containing all the buttons. Every row in the table represents a button. A button could be linked to a page (see button panel containers).
- **button panel containers**: The parameter lists the different "pages" or "containers".
- **button panel collection**: The parameter contains grouping information. A group is a collection of one or more button panels. Every row of this table parameter represents one group with all the necessary information for the dashboard to be able to display the button panels of that group. This parameter can be used as data in the dashboard that will allow the user to easily switch between dashboard groups.
