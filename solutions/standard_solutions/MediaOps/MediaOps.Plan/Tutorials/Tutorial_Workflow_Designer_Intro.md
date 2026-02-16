---
uid: Tutorial_MediaOps_Workflow_Designer_Intro
---

# Creating a workflow to use as a template for a job

In this tutorial, you will use the [Workflow Designer app](xref:MO_Workflow_Designer) to create a workflow similar to the one created in the tutorial [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations). This way, you will be able to reuse the workflow in as many jobs as you want, without the need to do the same setup and configuration each time.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.3.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **Workflow Designer** application.
- Access to the **Scheduling** application.
- You have completed the tutorials [Configuring resources and resource pools](xref:Tutorial_MediaOps_Resource_Studio_Intro), [Assigning capabilities to resources](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities), and [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations).

## Overview

- [Step 1: Create a new workflow](#step-1-create-a-new-workflow)
- [Step 2: Add resource pools to the workflow](#step-2-add-resource-pools-to-the-workflow)
- [Step 3: Configure the resource pools](#step-3-configure-the-resource-pools)
- [Step 4: Complete the workflow](#step-4-complete-the-workflow)
- [Step 5: Create a new job with the workflow as a template](#step-5-create-a-new-job-with-the-workflow-as-a-template)

## Step 1: Create a new workflow

1. Navigate to the **Workflow Designer** app.

1. In the top-left corner, click **+ New workflow**.

   ![New workflow button](~/solutions/images/Workflow_Designer_New_Workflow.png)

1. Specify a name of your choice in the **Workflow name** box, e.g. *SDI/IP Base Workflow*.

1. If you want the workflow to show up at the top of the list of workflows, select the **Favorite** box.

1. Click the **Save** button at the top.

   ![Save button](~/solutions/images/Workflow_Designer_Save_Workflow.png)

You should now see your workflow in the list on the left, for example:

![Workflow overview](~/solutions/images/Workflow_Designer_All_Workflows.png)

## Step 2: Add resource pools to the workflow

1. Select the newly created workflow in the list, and click the **Add node** button.

   ![Add node button](~/solutions/images/Workflow_Designer_Add_Node.png)

1. Select **Resource Pool**, and click *Next*.

   ![Select Resource Pool](~/solutions/images/Workflow_Designer_Select_Resource_Pool.png)

1. In the dropdown box, select the **Converter** resource pool, and click *Save*.

   ![Save Resource Pool](~/solutions/images/Workflow_Designer_Save_Resource_Pool.png)

1. Select the newly added resource pool in the *Selected workflow* pane.

1. Expand the **Node Actions** menu at the top, and select **Add After**.

   ![Add Node After](~/solutions/images/Workflow_Designer_Add_Node_After.png)

1. Again select to add a resource pool and select the **Converter** resource pool.

Your workflow should now look like this:

![Node configuration](~/solutions/images/Workflow_Designer_Node_Configuration.png)

## Step 3: Configure the resource pools

In this step, you will add some configuration to the workflow, so that one node will represent an SDI-to-IP device, and the other will represent an IP-to-SDI device.

1. In the *Selected Workflow* pane, select the **Converter (1)** node.

1. Expand the **Node Actions** menu, and select **Configure Node**.

   ![Configure Node option](~/solutions/images/Workflow_Designer_Configure_Node.png)

1. In the pop-up window, select the checkbox and then select the **SDI to IP** option and click *Create*.

   ![Select Configuration window](~/solutions/images/Workflow_Designer_Select_Configuration.png)

1. Select the **Converter (2)** node and repeat the steps above, but select the **IP to SDI** option instead.

You should have the same node configuration as in the tutorial [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations).

## Step 4: Complete the workflow

In order to be able to use this workflow in the Scheduling app, the workflow's state now has to be set to *Complete*:

1. Select the workflow you have just created and click the **pencil icon** in the *EDIT* column.

1. In the newly opened panel, click the **Mark Complete** button at the bottom.

1. Click the **Save** button at the top.

## Step 5: Create a new job with the workflow as a template

1. Open the **Scheduling** app.

1. On the *Job View* page, click the **+ New** button at the top.

1. In the *Create job* panel, specify a **name** of your choice for the job.

1. In the **Start Time** and **End Time** boxes, customize the timing for the job so that it does not start executing right away.

1. In the **Workflow** box, select the workflow you created earlier, e.g. *SDI/IP Base Workflow*.

1. Click the **Create Job** button.

   ![Create job panel](~/solutions/images/Scheduling_Create_Job_With_Workflow.png)

   You should now see your job on the timeline. A red hand symbol will be shown in the box representing the job, which means that resources still need to be selected before the job can be executed.

   ![Job on the timeline](~/solutions/images/Scheduling_Workflow_New_Job.png)

1. Click the **pencil icon** to open the edit panel for the job.

1. In the **Nodes** section, pick the *Video Solutions 001* resource for the first resource pool, and the *NewTek 001* resource for the second resource pool.

   This is done in the same way as in the tutorial [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations), so you can refer to that tutorial for more details.

1. Scroll up to the **Job Info** section.

1. Click the **Save as Tentative** button.

1. Click the **Confirm Job** button.

You have now created a job that uses the encoder and decoder resources with a predefined workflow.
