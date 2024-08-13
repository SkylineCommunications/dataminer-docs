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

No fix is available yet.

## Workaround

- For Cube clients without internet access:

  1. Request an upgrade package from an Administrator working on a DMS that has not been impacted by this issue.

  1. Manually upgrade your DMA using the provided package. See [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

- For clients enforced to use a version older than 10.4.2425.2536:

  1. Navigate to *System Center* > *System settings* > *Manage client versions*.

  1. Select a Cube version higher than 10.4.2425.2536. See [Managing client versions](xref:DMA_configuration_related_to_client_applications#managing-client-versions).

## Description

In Visual Overview, shapes with [*ButtonState* data](xref:Designing_buttons_with_four_different_states) fail to hide as expected.
