---
uid: PA_Queue_Element
---

# Queue element

The execution of activities is managed by queue elements.

- **Resource tasks**: For each type of resource task, a dedicated queue element is present. It will be used to manage all resources that are part of the same pool.

- **Script tasks** and **user tasks**: One single queue element can be used to support all script and user tasks.

Queue elements are used for the following purposes:

- Preventing too many activities running at the same time.

- Making sure that a resource is not concurrently used by multiple process instances associated with the same activation window.

- Communicating with other queues when an activity completes and a next activity needs to be triggered.

- Triggering the execution of each type of task.
