---
uid: MediaOps_Plan_2.0.2
description: "Read the release notes for MediaOps Plan 2.0.2, including faster reads, clearer job errors, and fixes for resource and job management."
---

# MediaOps Plan 2.0.2

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.11/10.7.0 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.1.3 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.3.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes. This requires MediaOps Live **1.2.0** or higher.

## Breaking changes

### Job node equality now includes start and end times [ID 47213]

`JobNode` equality now takes start and end times into account. Comparisons of node graphs and jobs therefore also detect timing differences. Two reads of the same job with different node times no longer compare as equal, and a change to only a node's end time is now detected and saved.

> [!IMPORTANT]
> This affects the use of `JobNode` objects in hash-based collections. Saving writes node times to the caller's node objects, so a `JobNode` stored in a dictionary or hash set using the default comparer can become unreachable after an update. If your integration stores `JobNode` objects in hash-based collections, use the node ID as the key or use a reference comparer instead.

### Unassigning resources from pools now checks for usage [ID 47224]

Unassigning a resource from a resource pool is now refused when a workflow, or a job that is not canceled and whose post-roll has not yet ended, still uses that resource from that pool. Previously, unassignment always succeeded, but affected jobs and workflows could then no longer be saved because their validation reported that the resource was not part of the pool.

This check applies to all unassignment routes: `UnassignResourcesFromPool`, changing a resource's pools through `Resources.Update` or `CreateOrUpdate`, and the REST API. In bulk operations, resources without usage are still updated.

The following new errors report the pool and the IDs of the jobs or workflows using it:

- `ResourcePoolAssignmentInUseByJobsError`
- `ResourcePoolAssignmentInUseByWorkflowsError`

Both errors map to a `409 InUse` response in the REST API.

Usage through a different pool, usage by a pool node only, and usage by canceled jobs do not block unassignment.

> [!IMPORTANT]
> If your integration unassigns resources from pools, it must handle these new errors.

## Enhancements

### Faster reads through lazy loading of orchestration settings [ID 47215]

Jobs, recurring jobs, workflows, and resource pools are now read faster because their orchestration settings are only loaded when needed. Previously, every read also fetched the orchestration settings of the object and its nodes, along with the profile parameters they reference, even if those settings were not used.

This behavior has been modified as follows:

- **Orchestration settings** are loaded the first time they are accessed. The settings of the object and all its nodes are then read in a single call.
- **Profile parameters**, including those used by orchestration events, are read in a single call and shared by all objects returned from the same read.
- **Change tracking and saving** no longer trigger a settings load. Changes to loaded settings are still detected and saved, while saving without accessing the settings leaves them intact.

Validation, configuration state calculation, and live synchronization load the settings of all involved objects in one batch. If settings cannot be read when a job is validated, this is now reported as a validation error instead of an exception.

As already happens for properties, settings and profile parameters are now read on first access rather than when the object is read. Comparing or hashing objects still takes their full settings into account and therefore loads the settings.

### Affected nodes identified in job error messages [ID 47237]

Job error messages now identify the affected nodes, so you no longer need to look them up in the database. For example, a message can now end with "Affected node(s): Encoder Pool (1), Encoder Pool (2)."

This applies to node-related errors, including nodes without an assigned resource, nodes missing mandatory configuration, resource pool nodes that are not allowed, invalid nodes in the job graph, and nodes added, removed, or swapped during the post-roll period.

The messages use the following conventions:

- Identical errors for the same job are grouped into one line, listing the affected nodes in the order they first appear.
- Nodes are identified by alias, or otherwise by resource name or resource pool name. Duplicate names are numbered to match the labels in the Workflow Designer.
- If the node or job cannot be found in the saved job, for example because a node has never been saved, the node ID is shown instead. Errors without an associated node are formatted as before.

This applies to all interactive scripts that display these errors, including the Job DOM Button Actions.

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

### Removing nodes from running jobs could delete resource usage history [ID 47214]

In MediaOps versions after 1.6.x, removing an existing node from a job in the *Running* state permanently deleted the node and its resource usage history.

The node is now retained with its end time set to the moment of removal. Its connections, parent-child links, and group memberships are preserved, as are children removed together with their parent. The resource is released from the removal time onward. Nodes that have already ended remain unchanged, so their history cannot be deleted.

This change only applies to jobs in the *Running* state. Nodes are still removed entirely from *Draft*, *Tentative*, and *Confirmed* jobs, and removing a node during the post-roll period is still rejected.

### Resources used by active recurring jobs could be deprecated [ID 47223]

Deprecating a resource used by an active recurring job was incorrectly allowed because the recurring job lookup compared the wrong identifier.

This action is now rejected with a `ResourceInUseByRecurringJobsError`, consistent with how resources used by jobs and workflows are handled.

