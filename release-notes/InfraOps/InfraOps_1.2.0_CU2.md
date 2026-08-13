---
uid: InfraOps_1.2.0_CU2
---

# InfraOps 1.2.0 CU2

## Fixes

#### Asset Manager: Missing DOM instance in validator context during save operations [ID 45821]

Previously, when calling `Save()` on a `DomInstanceWrapper` without explicitly specifying a `ValidatorContext`, an empty context was created. As a result, validators did not receive the DOM instance being saved and could not validate it correctly.

The default `Save()` operation now automatically includes the current entry as the base entry of the `ValidatorContext`, ensuring that validators always receive the data they need during save operations.

#### Asset Manager: False 'port already in use' error when editing data connections [ID 45822]

When editing an existing connection, validation could incorrectly fail with a "port already in use" error. This occurred because the connection being edited was included in the destination port's connection count, causing the port to appear fully occupied.

This has now been fixed by excluding the connection being edited from the port connection count during validation.

Additionally, source port availability is now also validated during connection edits. Previously, only destination port availability was checked.
