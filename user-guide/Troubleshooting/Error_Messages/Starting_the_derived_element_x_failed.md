---
uid: Starting_the_derived_element_x_failed
---

# Starting the DERIVED element x failed. y (hr = z)

In an error message of this type:

- "x" is the element name.
- "y" is a descriptive text with the reason of the failure.
- "z" is a hexadecimal error code.

## Symptom

Element "x" is not active.

## Possible cause

Element "x", a "derived element" (i.e. a virtual element in a redundancy group), could not be started.

## Resolution

Check whether the correct tags were specified in the *element.xml* file of element "x".
