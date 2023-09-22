---
uid: ChangePrimaryKey
---

# Change primary key

Changing the primary key of a table is considered a major change.

Note however that this change will typically not be allowed unless the current primary key is causing problems (not unique, causes shifts in index, too long, etc.).

## Impact

### Loss of data

Changing the primary key of a table has a lot of impact as all saved data references the primary key and would be lost.

This includes:

- Element Data: all columns that were saved
- Alarm/Trend data: all these records have a reference to the primary key
- ...

### Broken functionality

Any components that rely on a specific primary key will be broken.

This could be any component in DataMiner (Dashboard, Automation Script, Visio, etc.).

## Workarounds

There is no workaround that can be used to avoid loss of data or would not cause any impact.
