---
uid: Parsing_the_settings_for_x_failed
---

# Parsing the settings for x failed. y (hr = z)

In an error message of this type:

- "x" is the element name.
- "y" is a descriptive text with the reason of the failure.
- "z" is a hexadecimal error code.

## Symptom

Element "x" is not active.

## Possible cause

Element "x" could not be loaded because the *element.xml* file of element "x" contains invalid tags.

## Resolution

Check whether the correct tags were specified in the *element.xml* file of element "x".
