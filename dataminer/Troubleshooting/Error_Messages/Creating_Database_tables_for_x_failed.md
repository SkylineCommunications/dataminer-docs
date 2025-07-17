---
uid: Creating_Database_tables_for_x_failed
---

# Creating Database tables for x failed. y (hr = z)

In an error message of this type:

- "x" is the element name.
- "y" is a descriptive text with the reason of the failure.
- "z" is a hexadecimal error code.

## Symptom

Element "x" is not active.

## Possible cause

Creating the database tables for element "x" failed.

## Resolution

Open `SLDatabase[SLDataMiner].txt`, and check which table could not be created (`data_` or `dataavg_`).
