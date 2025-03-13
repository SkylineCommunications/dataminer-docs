---
uid: RS_Resource_States
---

# Resource States

A resource can be in one of the following states:

- **Draft**: Upon creation, resource state is set to `Draft`. In this stage the resource is not (yet) available to be scheduled in workflows and jobs. In this stage the pool can still be deleted, by clicking the pencil icon on the resource, and then clicking `Delete`.
- **Complete**: In this stage the resource pool is considered complete and can be used to create workflows and jobs. To make a resource complete, open edit panel of a resource in `Draft` state and click `Mark complete`.
- **Deprecated**: If you don't want a resource with `Complete` state to be shown anymore, you can deprecate it by going to edit panel and clicking `Deprecate`. You can find all the deprecated resources in **Recycle Bin** in the upper right corner. There you can either restore or completely delete deprecated resources.

# Resource Pool States

A resource pool can be in one of the following states:

- **Draft**: In this stage the resource pool is not (yet) available to be scheduled in workflows and jobs. In this stage the pool can still be removed directly.
- **Complete**: In this stage the resource pool is considered complete and can be used to create workflows and jobs.
- **Deprecated**: TBC WITH THE TEAM WHAT THIS MEANS => KEEP CURRENT BEHAVIOR