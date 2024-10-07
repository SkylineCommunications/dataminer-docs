---
uid: KI_ButtonState_shapes_in_Visual_Overview_fail_to_hide_as_expected
---

# ButtonState shapes in Visual Overview fail to hide as expected

## Affected versions

- DataMiner 10.4.8, if your Cube client does not have internet access.

- Cube clients that have been enforced to use a Cube version prior to 10.4.2425.2536, which can be configured using the *Force a specific version* setting in *System Center* > *System settings* > *Manage client versions*.

## Cause

The method of displaying images in Visual Overview was modified to prevent freezes. However, during this change, an oversight occurred, leading to a rendering fault specifically affecting *ButtonState* shapes.

## Fix

- For Cube clients without internet access: Install DataMiner 10.3.0 [CU19], 10.4.0 [CU7], or 10.4.10<!--RN 40454-->.

- For clients enforced to use a version older than 10.4.2425.2536: Make sure the client uses version 10.4.2425.2536 or higher. See [Managing client versions](xref:DMA_configuration_related_to_client_applications#managing-client-versions).

## Description

In Visual Overview, shapes with [*ButtonState* data](xref:Designing_buttons_with_four_different_states) fail to hide as expected.
