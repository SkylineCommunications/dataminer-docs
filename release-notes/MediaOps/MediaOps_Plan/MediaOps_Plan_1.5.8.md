---
uid: MediaOps_Plan_1.5.8
---

# MediaOps Plan 1.5.8 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher.
> - The [GQI DxM](xref:GQI_DxM), which must be installed and enabled.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## Changes

### Fixes

#### Workflow Designer: Resource pool not automatically selected when swapping resource [ID 45527]

When you tried to swap a resource in the Workflow Designer app, the resource pool was not automatically selected, so that you had to manually locate the resource pool before performing the swap. Now the resource pool will be correctly auto-populated based on the selected resource.

#### Scheduling: Exception because of invalid node reference made workflow inaccessible in 'Edit job' panel [ID 45591]

When you opened the *Edit job* panel, the following exception could occur in the workflow: `The given key was not present in the dictionary`. This was caused by connections referencing non-existing node IDs, for example, after a node was removed but its associated connections were not updated. This exception made it impossible for operators to view the workflow, and manual intervention in the DOM instance was required to resolve the issue.

To resolve this, the handling of invalid node references has now been improved. Connections with non-existing node IDs are now gracefully ignored or handled, preventing the exception and ensuring that the workflow remains visible to operators.

#### Scheduling: Node icon not updated after node swap [ID 45644]

When an existing node of a non-running job was swapped, the node icon was not updated. Now swapping the node will cause the icon to be updated to match the new node.
