---
uid: Starting_the_protocol_for_x_failed
---

# Starting the protocol for x failed. y (hr = z)

In an error message of this type:

- "x" is the element name.
- "y" is a descriptive text with the reason of the failure.
- "z" is a hexadecimal error code.

## Symptom

Element "x" is not active.

## Possible cause

SLProtocol was not able to read out the element settings of element "x".

## Resolution

Check whether the correct tags were specified in the *element.xml* file of element "x".
