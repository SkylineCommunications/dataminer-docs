---
uid: SCH_Edit_Job
---

# Editing a job

Jobs can be edited through the Edit Job panel. This panel can be accessed from the **job view**, **resource view**, **Ops Board** or **Search Jobs** pages, through the 🖉 icon. On top of the Edit Job panel the current state of the job is indicated and what states will follow under normal circumstances. The panel contains sections which are described below.

- **Job info**: Contains the general information (e.g. Name, Description, start, end) of the job and based on the [state of the job](xref:MO_S_Job_States) different buttons will be shown:
  - **Save as Tentative** (Draft): Move the job from Draft to a tentative state which will reserve all resources.
  - **Edit job config** (Draft, Tentative, Confirmed): some buttons to change the state of the job or to access the [profile configuration](xref:MO_S_Configuration) of the job itself. The configuration for the nodes can be accessed from both the Nodes and Workflow section.
  - **Confirm job** (Tentative): Move the job from Tentative to confirmed. Once the job is confirmed, the orchestration script will be executed.
  - **Cancel job** (Tentative, Confirmed): To cancel the job and to free up the resources again.
  - **Manual start** (Confirmed): When the event needs to start immediately, you can use this action to move the start time to now. This will change the job state to running.
  - **Stop early** (Running): When the event needs to stop immediately, you can use this action to trigger the stop actions. This will change the job state to Confirmed.
- **Related**: Contains all related/linked objects to the job. New links can be added by clicking the 'Add Link' button. New types can be added from the [App Configuration](xref:MO_S_App_Configuration) page.
- **Administration**: This section provides information to which organization the job can be billed. The billing depends on the contract selected.
- **Nodes**: Provides a list view of all nodes in the job. Resources or resource pools can be added from this section through the 'Add Resource' button.
- **Workflow**: Provides a workflow diagram of all nodes. Nodes and connection between them can be managed from this view.
