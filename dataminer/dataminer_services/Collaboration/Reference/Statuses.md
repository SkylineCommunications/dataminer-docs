---
uid: Statuses
---

# Statuses

## Project statuses

A project can have the following statuses:

| Status | Description |
|---|---|
| Pending intake | When a project is handed over from Skyline Sales to Skyline Project Management, normally its state changes from “Initiating” to “Preparing”. If, for any reason, there is not enough information to continue processing the project, it is handed over to Skyline Sales with its state set to “Pending intake”.<br>Only when a sufficient amount of information has been provided will the state of the project change to “Preparing" again. |
| Preparing      | The project and its initial set of tasks are being defined by Skyline Project Management.<br>At this stage, the project is owned by the member of Skyline Project Management who is preparing the project. |
| Not started    | The project has been defined and is ready to be executed.<br>At this stage, the project is owned by the Skyline Project Manager, i.e. a Skyline Technical Account Manager or a member from Skyline Project Management, to whom the project has been assigned. |
| In progress    | The project is ongoing.<br>The Skyline Project Manager has set the status of the project to “In progress” and must now follow up on it. |
| Completed      | All tasks defined in the project have been completed.<br>The Skyline Project Manager has set the status of the project to “Completed” and has assigned it to the Skyline System Engineering Director. |
| Closed         | The project is closed.<br>The Skyline System Engineering Director has set the status of the project to “Closed” and will now<br>- verify whether all contractual obligations have been met, and<br>- notify Skyline Finance & Administration that the project has been completed (by sending them an FC reference). |

## Task statuses

A task can have the following statuses:

| Status | Description |
|---|---|
| Not started         | The task, which has just been created, is ready to be investigated.<br>The following people can set the status of a task to “Not started”:<br>- all members of Skyline Project Management and Skyline Sales<br>(task type: any)<br>- the Skyline Project Manager (task type: “New Feature” or “Issue”)<br>- the customer (task type: “New Feature” or “Issue”) |
| Investigation       | The task is being investigated by a Skyline staff member.<br> Any information relevant to the task is collected and attached to it. |
| To be scheduled     | All information relevant to the task is available. The task is now ready to be scheduled.<br>At this stage, the task is assigned to Planning.<br>Note: All tasks with status “To be scheduled” are collectively known as the backlog. |
| Scheduled           | The task is now ready to be processed and scheduled to be executed at the specified time.<br>Planning has assigned the task to a Skyline staff member or a Skyline squad. |
| In progress         | The task is being processed by the Skyline staff member to whom it was assigned. |
| Code review         | The programming code that was created or updated by the developer assigned to the task is being reviewed by a peer. |
| Quality assurance   | The work described in the task has been completed and is now being verified by Quality Assurance.<br>Note: Not all tasks should go through this QA stage. Driver installations, for example, do not need to go through this stage. |
| Ready to deploy     | The deliverables requested in the task are ready to be deployed. |
| Customer acceptance | The task has been assigned to the customer, who has explicitly been asked to either accept or reject the task.<br>If the customer rejects the task, it will be reassigned to QA. They will then set the status of the task back to “In Progress”.<br>**IMPORTANT: Tasks of type “New driver feature” or “Driver issue” that have been in status “Customer acceptance” for more than 3 weeks, will automatically be set to “Completed”.** |
| Completed           | The work described in the task has been completed, but it still needs to be verified by the Project Manager.<br>A task can only be set to “Completed” after its compliance with all relevant QA documents is checked. |
| Closed              | The task has been closed. All contractual obligations are met and Skyline Finance & Administration has been notified (if applicable).<br>A task can only be set to “Closed” by either the Skyline System Engineering Director or the Skyline Project Manager responsible for the task. |
| Waiting             | Skyline cannot proceed with the task, typically because they are waiting for a deliverable from the customer or a third party (e.g. a vendor).<br>If the status of a task is set to “Waiting”, an option also has to be selected in the *Reason for waiting* box and the task has to be assigned to the customer. |
| Hotfix request      | Skyline development has been asked to provide a hotfix. |
| Rejected            | In case a task is of type “New feature” or “Issue”, its status will be set to “Rejected” when it has been decided that the new feature will not be implemented, that the issue is actually not an issue, or that the issue was not caused by Skyline.<br>The status of a task can only be set to “Rejected” after either the Product Owner of the relevant Create domain or the Skyline System Engineering Director is consulted.<br>When a task is set to “Rejected”, it must be assigned to the Skyline Project Manager, who will then contact the customer if necessary. |
| Closed - Rejected   | The task, which was previously set to “Rejected”, is now closed. |
