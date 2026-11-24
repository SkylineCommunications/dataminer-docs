---
uid: MediaOps_Plan_2.0.2
---

# MediaOps Plan 2.0.2 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Fixes

### Job actions could bypass state rules during concurrent changes [ID 47182]

If a job's state changed between reading the job and acquiring its lock, job actions could bypass state rules. Because actions validated a stale copy of the job, this could cause several issues:

- Deleting a job could leave its resources booked.
- A confirmed reservation could be removed without the job being completed.
- A job that was already completed or canceled could still be modified.

The following actions now re-read the stored job after acquiring the lock and validate its state again before making changes:

- **Delete**: Rechecks whether the job is in the *Draft*, *Canceled*, or *Completed* state (unless a forced delete is requested) and removes the reservation based on the stored state. If the job no longer exists, it is reported as deleted.
- **Update**: Rejects the update with an invalid-state error if the stored state differs from the state when the job was read. You can then read the job again and retry.
- **MarkAsCompleted**, **SaveAsTentative**, **Start**, and **Stop**: Re-evaluate their state and timing validations against the stored job.

If an action targets a state that the job has already reached, it is now reported as successful. Note that starting an already running job only succeeds when no new start time is requested, and stopping an already completed job returns an error because its end time cannot be modified.

### Concurrent changes could cause inconsistencies between resources and linked core resources [ID 47183]

Changing a resource at the same time as another user or process could cause actions to use outdated information about the resource's state, leading to inconsistencies between the resource and its linked core resource (i.e., the corresponding resource in the SRM framework).

Previously, this could result in the following issues:

- **Delete**: A resource that had just been completed or restored could be deleted, leaving its linked core resource orphaned.
- **Update**: Changes could be saved without being synchronized to the linked core resource, or changes could be saved on a resource that had just been deprecated.
- **Complete**: A second core resource could be created, overwriting concurrent changes.
- **Deprecate** or **Restore**: The core resource mode could be changed even though the resource state transition then failed.

The **Update**, **Delete**, **Complete**, **Deprecate**, and **Restore** actions now re-read the stored resource while holding the lock and re-evaluate its state before acting:

- **Update** rejects changes with an invalid-state error if the resource state changed after it was read. You can then read the resource again and retry.
- **Delete** removes the core resource that is linked at that time, and cancels the deletion of the resource if removing the core resource fails. If the resource no longer exists, it is reported as deleted.

If an action is performed on a resource that has already reached the target state, it is now reported as successful.

### Concurrent changes to resource pools could produce inconsistent results [ID 47184]

When multiple users or processes modified a resource pool concurrently, actions could produce inconsistent results. Because the resource pool state was validated using a copy that was read before acquiring the lock, concurrent state transitions (for example, from *Draft* to *Complete*) could go unnoticed.

Depending on the action, this could cause several problems:

- **Delete**: A linked core resource pool (i.e., the corresponding resource pool in the SRM framework) could be left orphaned, a complete resource pool could be deleted unexpectedly, or resources could be unassigned from a resource pool that was ultimately not deleted.
- **Update**: Capability changes could fail to propagate to the core resource pool and its resources, or changes could be saved on a deprecated resource pool.
- **Complete**: A second core resource pool could be created, overwriting the stored resource pool with a stale copy.
- **Deprecate**: Resources could be deprecated even if the resource pool was already deprecated and the state transition failed.

The **Update**, **Delete**, **Complete**, and **Deprecate** actions now acquire the resource pool lock first, and then re-read and re-validate the stored resource pool state before making changes:

- **Update** rejects the modification with an invalid-state error if the stored resource pool state differs from the state when it was read.
- **Delete** only removes resources, parent links, category items, and the core resource pool for resource pools that have actually been deleted. If a resource cannot be unassigned, the deletion fails and the resource pool remains in place to prevent dangling references.

If an action is performed on a resource pool that has already reached the target state, it is now reported as successful.
