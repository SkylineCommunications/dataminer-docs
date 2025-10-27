---
uid: Consulting_or_editing_a_task
---

# Consulting or editing a task

To consult or edit a task under the current project, do the following:

- In the *List* view:

  1. Click the task in the list on the left.

  1. Make the necessary changes in the pane on the right.

  1. At the top of the pane, click *Save*.

- In the *Board* view:

  1. Click the task.

  1. Make the necessary changes in the pop-up window.

  1. At the top of the window, click *Save*.

In the top-right corner, you can find two buttons:

- Clicking the first button will copy the URL of the task to the Windows clipboard.

- Clicking the second button will open a menu that contains a number of commands:

  - Click *Full screen* to expand the task pane (List view only). In full-screen mode, you can then click *Split view* to exit the full-screen mode.

  - Click *Show/Hide planning fields* to have the task pane also show planning fields (e.g. *Start date*).

  - Click *Show/Hide customer response fields* to have the task pane also show the SLA metrics used to calculate the SLA timings (if the task is subject to an SLA):

    | Field | Description  |
    |--|--|
    | Issue reported | The time when the issue was reported to Skyline. |
    | Initial response | The time when Skyline acknowledged the issue. |
    | Workaround provided | The time when Skyline provided a workaround. |
    | Solution provided | The time when Skyline provide a permanent solution. |

## Task editing limitations

When editing a task, you are only allowed to make a limited number of changes. See below.

| Task field | Editing limitation |
|--|--|
| Status | \-  When the status is “Waiting”, you can set it to “Investigation”.<br> -  When the status is “Customer Acceptance”, you can set it to “Completed” or “In Progress”. |
| Type | Cannot be changed. |
| Developer | Cannot be changed. |
| Start date | Cannot be changed. |
| Released in version | Cannot be changed. |

> [!NOTE]
>
> - Only open tasks can be edited or deleted. Once a task has been closed, i.e. set to status “Closed” or “Closed - Rejected”, it can no longer be edited or deleted.
> - A task can only be deleted by the person who created it.
