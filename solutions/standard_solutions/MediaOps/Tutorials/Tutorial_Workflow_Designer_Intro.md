---
uid: Tutorial_MediaOps_Workflow_Designer_Intro
---

# Getting started with the Workflow Designer app

In this tutorial, we will create a workflow similar to the one we created in the [Scheduling With Configurations Tutorial](xref:Tutorial_MediaOps_Scheduling_Configurations). This way, we will be able to reuse the workflow in as many jobs as we want, without the need to do the same setup and configuration each time.

Expected duration: 15 minutes

> [!NOTE]  
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.2.5-CU0.

> [!TIP]  
> See also: [Resource Studio](xref:MO_Resource_Studio) and [Scheduling](xref:MO_Scheduling) documentation.

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **Workflow Designer** application.
- Access to the **Scheduling** application.
- Having completed the [Resource Studio Capabilities Tutorial](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities).
- Having completed the [Scheduling With Configurations Tutorial](xref:Tutorial_MediaOps_Scheduling_Configurations).

## Overview

- [Step 1: Create a new workflow](#step-1-create-a-new-workflow)
- [Step 2: Add resource pools to the workflow](#step-2-add-resource-pools-to-the-workflow)
- [Step 3: Configure the resource pools](#step-3-configure-the-resource-pools)
- [Step 4: Complete the workflow](#step-4-complete-the-workflow)
- [Step 5: Create a new job with the workflow as a template](#step-5-create-a-new-job-with-the-workflow-as-a-template)

## Step 1: Create a new workflow

1. Navigate to the **Workflow Designer** app.

1. Click the *+ New Workflow* button in the upper-left part of the screen.

   ![New Workflow](~/solutions/images/Workflow_Designer_New_Workflow.png)

1. Give your workflow an arbitrary workflow name.

1. Optionally, mark it as a **favorite** so that it shows up at the top of your workflows.

1. Click *Save*.

   ![Save Workflow](~/solutions/images/Workflow_Designer_Save_Workflow.png)

1. Make sure the workflow was indeed created.

   ![All Workflow](~/solutions/images/Workflow_Designer_All_Workflows.png)

## Step 2: Add resource pools to the workflow

1. Select the newly created workflow in the list.

1. Click the *Add Node* button.

   ![Add Node to Workflow](~/solutions/images/Workflow_Designer_Add_Node.png)

1. Select *Resource Pool*.

1. Click *Next*.

   ![Select Resource Pool](~/solutions/images/Workflow_Designer_Select_Resource_Pool.png)

1. From the dropdown menu, select the *Converter* resource pool.

1. Click *Save*.

   ![Save Resource Pool](~/solutions/images/Workflow_Designer_Save_Resource_Pool.png)

1. Select the newly added resource pool.

1. Under *Node Actions* menu, click the *Add After* option.

   ![Add Node After](~/solutions/images/Workflow_Designer_Add_Node_After.png)

1. Similarly to the previously added resource pool, add another **Converter**.

1. Make sure your workflow looks as below.

   ![Node Configuration](~/solutions/images/Workflow_Designer_Node_Configuration.png)

## Step 3: Configure the resource pools

In this step, you will add some configuration to the workflow, so that one node represent an SDI-to-IP device, and the other will represent an IP-to-SDI device.

1. In the *Selected Workflow* section, select the **Converter (1)** node.

1. Under *Node Actions* dropdown menu, click the *Configure Node* option.

   ![Configure Node](~/solutions/images/Workflow_Designer_Configure_Node.png)

1. In the new window, to the right of the **Conversion Type**, click on the checkbox to enter the value.

1. In the new dropdown, select the *SDI to IP* option.

   ![Select Configuration](~/solutions/images/Workflow_Designer_Select_Configuration.png)

1. Do the similar thing to the second node, but when selecting the **Conversion Type**, select the *IP to SDI* option.

If all went as expected, you should have the same node configuration as the one we created in the tutorial for using configurations in the **Scheduling** app.

## Step 4: Complete the workflow

In order to be able to use the workflow we created in the **Scheduling** app, we need change the workflow's state to *Complete*.

1. Select the workflow we have just created.

1. Click the pencil icon in the *EDIT* column.

1. In the newly opened panel, at the bottom-right, click the *Mark Complete* button.

1. Click the *Save* button.

Our workflow should now be ready for use in the **Scheduling** app.

## Step 5: Create a new job with the workflow as a template

1. Navigate to the Scheduling app.

1. To go to the panel for creating new job, click on the *+ New* button.

1. In the newly opened panel, give the job an arbitrary name.

1. Optionally, **delay** the time of the job for several hours, so that it does not start executing right away.

1. Set *Workflow* field to the workflow we created earlier in the tutorial, **SDI/IP Base Workflow**.

1. Click the *Create Job* button.

   ![Scheduling Create Job](~/solutions/images/Scheduling_Create_Job_With_Workflow.png)

1. If all went well, you should see your job in the timeline. Notice that the job has a *Red Hand* symbol on it, meaning that it still needs to have its resources selected before it can execute.

   ![New Job](~/solutions/images/Scheduling_Workflow_New_Job.png)

1. Click the pencil icon to open the edit panel for the job.

1. Similarly to how we did it in the [Scheduling With Configurations Tutorial](xref:Tutorial_MediaOps_Scheduling_Configurations#step-4-pick-resources), for the first resource pool, choose the *Video Solutions 001* resource, and for the second resource pool choose the *NewTek 001* resource.

1. Navigate to the *Job Info* section.

1. Click the *Save as Tentative* button.

1. Click the *Confirm Job* button.

You should now have created a job which uses the encoded and decoder resources with a predefined workflow.
