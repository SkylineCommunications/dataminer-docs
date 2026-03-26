---
uid: RAD_Manager_4.0.1
---

# RAD Manager 4.0.1

> [!NOTE]
> This RAD Manager version requires that **DataMiner 10.6.0/10.6.2 or higher** is installed.

## Changes

### Fixes

#### Incorrect behavior caused by historical anomalies being shown based on group name [ID 44238]

In the RAD Manager app, historical anomalies will now be shown based on their group ID instead of their group name. Previously, they were shown based on the group name, which could lead to the following unwanted behavior:

- When a group was renamed, the historical anomalies from before the rename were no longer shown.
- When a group was removed, and a new group with the same name was added, the historical anomalies of the removed group would also be shown.
