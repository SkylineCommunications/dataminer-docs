---
uid: SCH_Edit_Job
---

# Editing a job

To edit a job, click the pencil icon for that job on the *Job View*, *Resource View*, *Ops Board*, or *Search Jobs* page. This will open the *Edit job* panel. This panel consists of different sections where you can view and edit job settings and information, as detailed below.

<!-- TODO: Add nice example screenshots of the sections -->

## Header bar

In the header bar, several buttons are available:

![Header bar Edit job panel](~/solutions/images/Edit_job_header_bar.png)

1. The **Contacts** button opens a panel where you can manage contacts related to the job. With the *Add Contact* button at the bottom of the panel, you can add contacts that have been configured in the [People & Organizations](xref:People_Organizations) app. You can remove contacts again with the x button in the list.
1. The **Duplicate** button opens the *Duplicate job* window, where you can configure a new job based on the current one.
1. The ![Copy to clipboard](~/solutions/images/Scheduling_edit_job_copy.png) button copies the URL of the job to the clipboard.<!-- RN 43059 -->

## State overview

All the way at the top of the panel, you can see an overview indicating the current [state of the job](xref:MO_S_Job_States) and the states that will follow it under normal circumstances.

## Job Info

This section contains the **general information** about the job: the ID, name, description, priority, and the start and end time. Clicking the pencil icon in the top-right corner allows you to make changes to this. The pencil icon below that can be used to modify the properties of the job.

Below this general information, different buttons are shown depending on the [state of the job](xref:MO_S_Job_States):

| Job state | Available buttons |
|--|--|
| Draft | Save as Tentative, Edit job config |
| Tentative | Edit job config, Confirm, Cancel job |
| Confirmed | Edit job config, Manual start, Cancel job, Return to Tentative |
| Running | Stop early |

These buttons can be used for the following actions:

- **Save as Tentative**: Moves the job to the tentative state, which will reserve all resources.
- **Edit job config**: Allows you to configure the capabilities and/or capacities linked to the job.
- **Confirm**: Moves the job from the tentative to the confirmed state, which will execute the orchestration script linked to the job.
- **Cancel job**: Cancels the job and frees up the resources again.
- **Return to Tentative**: Moves the job back to the tentative state, which frees up the resources again.<!-- RN 43042 -->
- **Manual start**: Moves the start time of the job to the current time, so that it starts immediately. This will change the job state to running.
- **Stop early**: Triggers the stop actions, so that the job stops immediately. This will change the job state to confirmed.

## Related

This section contains all related objects that have been linked to the job.

You can add new links with the *Add Link* button at the top.

New types of objects can be added in the *Reference Types* section of the [App Configuration](xref:MO_S_App_Configuration) page.

<!-- TODO: Explain the practical use of this, with an example -->

## Administration

This section shows the organization and job owner that the job is linked to, if any. Via the pencil icon, you can change the linked organization and job owner.

## Nodes

This section provides a list view of all nodes in the job. With the *Add Node* button at the top, you can add more resources or resource pools as nodes in the job.

If a node is linked to a resource pool but the resource itself still needs to be selected, the ![Red Hand](~/solutions/images/Red_Hand_icon.png) icon will be shown in the *Resource Select Column*. In that case, you can click the icon to pick the resource from the available resources in the pool.

## Workflow

This section shows the nodes in the job in a workflow diagram and allows you to manage both the nodes and the connections between them.

For a practical example, refer to the tutorial [Creating a job and configuring it with resources](xref:Tutorial_MediaOps_Scheduling_Encoder_Decoder).
