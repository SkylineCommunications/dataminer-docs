---
uid: ChangePrimaryKey
---

# Change primary key

Changing the primary key of a table is considered a major change.

This change will typically not be allowed unless the current primary key is causing problems (not unique, causes shifts in index, too long, etc.).

## Impact

### Loss of data

Changing the primary key of a table has a large impact, as all saved data references the primary key and will be lost.

This includes:

- Element data, i.e. all columns that have been saved.
- Alarm/trend data: all these records have a reference to the primary key.

### Broken functionality

Any components that rely on a specific primary key will be broken.

This could be any component in DataMiner (dashboards, automation scripts, Visual Overview, etc.).

## Workarounds

There is no workaround that can be used to avoid loss of data or prevent an impact.
