---
uid: ElementID_x_not_unique_y_existing_z
---

# ElementID (x) Not unique y existing = z

In an error message of this type:

- "x" is the duplicate ID.
- "y" is the new element name.
- "z" is the existing element name.

## Symptom

Element "y" is not active.

## Possible cause

Element "y" could not be loaded because its element ID is not unique.

This error usually occurs in Failover pairs in the following scenario:

1. An element *elementname* is renamed to *elementname_new* on an active DataMiner Agent in a Failover pair.
1. The standby Agent is not reachable at that moment, misses the notification about the renaming of the element, and keeps the information about the element *elementname* unchanged.
1. When the standby Agent becomes reachable again, it receives information about the element *elementname_new* and creates a new subfolder in `C:\Skyline DataMiner\Elements` for this element.
1. When the standby Agent is switched to active mode, it starts up its elements and detects the element ID conflict, because it has data for both elements *elementname* and *elementname_new*.

## Resolution

Identify the incorrect element name and delete the respective folder in `C:\Skyline DataMiner\Elements`. Make sure that on both Agents in the Failover pair the contents of `C:\Skyline DataMiner\Elements` are identical.
