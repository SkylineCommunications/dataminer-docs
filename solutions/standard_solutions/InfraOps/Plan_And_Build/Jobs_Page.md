---
uid: Jobs_Page
---

# Jobs List

## List and timeline overview

On the Jobs List page, the buttons in the top-left corner allow you to switch between a list and timeline overview of the available infrastructure jobs.

![Jobs List Overview](~/solutions/images/Plan_And_Build_Jobs_List_Overview.png)

![Jobs Timeline](~/solutions/images/Plan_And_Build_Jobs_Timeline.png)

## Adding a job

Adding a new job is possible via the *New Job* button in the top-right corner of the Jobs List page and App Configuration page.

This will open a wizard where you will need to configure the job as follows:

1. Specify the job's name, start time, type (*Add*, *Remove*, or *Update*), priority (*Critical*, *High*, *Low*, or *Normal*) and "sub state" (i.e. the secondary state of the job, which can be *Archived*, *Documentation Completed*, *Documentation Montage*, *Draft*, *In Progress*, *On Hold*, *Pending Approval*, *Pending Kickoff*, *Resource Allocation*, or *Reviewed*). Optionally, you can also add the end time, a description, and any additional remarks.

   ![Create job – Info window](~/solutions/images/Plan_And_Build_Create_Job_Info_Section.png)

1. Click *Next*, and optionally select the locations assigned to this job. You can select as many locations as necessary.

   ![Create job - Locations](~/solutions/images/Plan_And_Build_Create_Job_Locations_Section.png)

1. Click *Next*, and assign the necessary assets to the job. You will first need to specify a filter and then click *Load Assets* in order to be able to select one or more assets.

   ![Create job - Assets Selection](~/solutions/images/Plan_And_Build_Create_Job_Assets_Selection_Section.png)

1. Click *Next*, and select the type of action that will be conducted on the selected assets (see [Job action types](#job-action-types)).

   ![Create job - Action configuration](~/solutions/images/Plan_And_Build_Create_Job_Assets_Selection_And_Action_Configuration.png)

1. Click **Save**.

### Job action types

The following types of actions can be assigned for an asset in a job:

- **Audited**: The asset is reviewed for compliance or performance.

- **Cleaned**: Physical cleaning of the asset.

- **Commissioned**: The asset is tested and officially put into service.

- **Connected**/**Disconnected**: Network or power connections are made or removed.

- **Decommissioned**: The asset is retired from service but may still be physically present.

- **Dismantled**: The asset is broken down into components or parts.

- **Expanded**: Capacity or functionality is increased.

- **Inspected**: Physical or logical inspection is carried out.

- **Locked**/**Unlocked**: Access restrictions are applied or removed.

- **Modified**: The asset is changed in some way (for example, configuration or physical layout).

- **Newly Installed**: The asset is added for the first time.

- **Patched**: Software or firmware updates are applied.

- **Provisioned**: The asset is configured and made ready for use.

- **Reconfigured**: Settings or parameters are changed.

- **Reinstalled**: The asset was previously removed and is now installed again.

- **Relocated**: The asset is moved to a different physical or logical location.

- **Removed**: The asset is physically taken out.

- **Repaired**: Faults or issues are fixed.

- **Serviced**: Routine maintenance is performed.

- **Tagged**: The asset is labeled or identified.

- **Tested**: The asset undergoes diagnostic or performance testing.

- **Uninstalled**: Software or firmware are removed from the asset.

- **Upgraded**: The asset receives improved hardware or software.

- **Virtualized**: The asset is converted to or deployed as a virtual instance.

## Viewing job details

To view the details for a job, in the list of jobs, click the ⓘ icon for the job. This will open the pane illustrated below. Depending on the state of the job, this pane also allows you to edit the job details, change the selected assets and locations, [assign a user and activate the job](#assigning-and-activating-a-job), or [mark the job as complete](#completing-a-job):

![Job details pane](~/solutions/images/Plan_And_Build_Job_Details_Side_Panel.png)

<!-- TBD: What is the purpose of the Export Cabling Plans button? How should this be used? -->

## Assigning and activating a job

1. At the bottom of the [*Job details* pane](#viewing-job-details), click *Assign*.

1. Select the user and group that should be assigned to the job, and click *Finish*.

   ![Assign job wizard](~/solutions/images/Plan_And_Build_Assign_Job_Wizard.png)

   This will change the main state of the job to "Assigned", making it possible to activate the job.

1. To activate the job, at the bottom of the *Job details* pane, click *Activate*.

1. Finally, to send the job for review, click *Assign to Review* at the bottom of the *Job details* pane, select the user and group for the review, and click *Finish*.

   ![Send job to review](~/solutions/images/Plan_And_Build_Send_Job_To_Review_Wizard.png)

## Completing a job

When a job is in the "Review" state, it is possible to mark it as complete. To do so, open the [*Job details* pane](#viewing-job-details) for the job, and click the *Complete* button at the bottom.

Note that when a job has been marked as complete, it will no longer be possible to change anything to the job.

## Deleting a job

To delete a job, in the list of jobs, click the ![Hamburger icon](~/solutions/images/PB_Hamburger_icon.png) icon and select *Delete Job*.

![Delete job option](~/solutions/images/PB_Delete_job.png)

<!-- TBD: are there any restrictions for job deletion? any consequences we should warn for? -->
