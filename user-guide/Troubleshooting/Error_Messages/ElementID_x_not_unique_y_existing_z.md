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

## Resolution

Make the necessary corrections to the *element.xml* file of element "y", and restart the DataMiner Agent.
