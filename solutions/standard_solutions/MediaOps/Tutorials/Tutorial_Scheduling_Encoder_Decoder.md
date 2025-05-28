---
uid: Tutorial_MediaOps_Scheduling_Encoder_Decoder
---

# Getting started with the Scheduling app

In this tutorial, you will learn how to create and schedule jobs, swap resources and confirm the created jobs.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.2.5-CU0.

> [!TIP]
> See also: [Scheduling documentation](xref:MO_Scheduling)

## Prerequisites

- A DataMiner System using DataMiner 10.5.5 or higher.
- Access to the **Scheduling** application.
- Ideally you should have completed the [Resource Studio tutorial](xref:Tutorial_MediaOps_Resource_Studio_Intro), since we're going to make use of the resources from that tutorial here.

## Overview

- [Step 1: Create a new job](#step-1-create-a-new-job)
- [Step 2: Add resources to the job](#step-2-add-resources-to-the-job)
- [Step 3: Reserving the resource](#step-3-reserving-the-resource)
- [Step 4: Add another resource](#step-4-add-another-resource)
- [Step 5: Swap resources](#step-5-swap-resources)
- [Step 6: Confirming the job](#step-6-confirming-the-job)

## Step 1: Create a new job

1. Head over to the new job panel by clicking the *+ New* button.

   ![NewJob Button Placement](~/solutions/images/Scheduling_New_Job_Button_Placement.png)

1. Give the job a name of your choice and create it. Ideally, delay the job *Start Time* and *End Time* for several hours to give the job some time before it starts.

   ![Create Job Panel](~/solutions/images/Scheduling_Create_Job_Panel.png)

   > [!NOTE]
   > The default duration for a new job is one hour, starting at the job creation time.

1. You should be able to see the newly created job in the timeline.

   ![New Job Created](~/solutions/images/Scheduling_New_Job_Created.png)

## Step 2: Add resources to the job

1. Open the *Edit job* panel.

   ![Edit Job Icon](~/solutions/images/Scheduling_Edit_Job_Icon.png)

1. Scroll down to the bottom of the panel, where you should be presented with the *Workflow* section. Here you can manage the resources that should be included in the job.

   ![Edit Job Workflow](~/solutions/images/Scheduling_Edit_Job_Workflow.png)

1. Open the *Add Node* panel and *+ Add Resource* **NewTek 001** from the *Encoder* resource pool to your job.

   ![Add Encoder Resource](~/solutions/images/Scheduling_Edit_Job_Add_Encoder_Resource.png)

1. Close the panel and make sure that you see your resource in the node-edge graph.

   > [!NOTE]
   > If you do not see the newly created resource, you might need to hit the **Workflow refresh** button in the upper right corner of the *Workflow* section.

   ![Check out the newly added resource](~/solutions/images/Scheduling_Workflow_Resource_Added.png)

## Step 3: Reserving the resource

To reserve the resource for your job:

1. Open the **Edit job** panel.

1. Save the job as *Tentative*.

   ![Save Job as Tentative](~/solutions/images/Scheduling_Edit_Job_Save_As_Tentative.png)

1. Close the *Edit Job* panel and confirm that the color of the job has changed, indicating that it is now in the *Tentative* state.

## Step 4: Add another resource

Let's add another resource to our job, a decoder this time.

1. Open the *Edit job* panel and head over to the *Workflow* section.

1. **Select** the *NewTek 001* resource and open the *Add After* panel.

   ![Add After](~/solutions/images/Scheduling_Create_Job_Add_After.png)

1. Select the **Decoder** pool. But there's no any resources available to add to our job. Worry not! We will take care of that later. For now, to declare that we need a decoder resource in the job, click *Add Resource Pool*.

   ![Add Resource Pool](~/solutions/images/Scheduling_Create_Job_Add_Resource_Pool.png)

   > [!TIP]  
   > If you get an error in this step, make sure that you have **selected** the resource node in the previous step.

1. Resource pool should now be added to our job.

   ![Resource Pool Added with Red Hand](~/solutions/images/Scheduling_Create_Job_Red_Hand.png)

   > [!NOTE]
   > Note the red hand icon on the resource pool in the *Nodes* table. It means that we still have to pick a concrete resource for our job.

## Step 5: Swap resources

Since the *NewTek 001* resource can act both as an encoder and as a decoder, in this step, you will swap its role and use it as a decoder in the job. Then the *Video Solutions 001* resource is still available to be used as an encoder.

1. Open the *Edit job* panel and head over to the *Nodes* table.

1. Select the *Encoder* row, and under the *Actions* column, click the **swap action**.

    ![Swap Action](~/solutions/images/Scheduling_Create_Job_Swap_Action.png)

1. In the newly opened window, the *Encoder* resource pool should be preselected. Select the *Video Solutions 001* resource and click the swap button.

    ![Swap Resource](~/solutions/images/Scheduling_Create_Job_Swap_Resource.png)

1. If you do not see the results immediately in the node edge graph, use the *Workflow* section's *Refresh* button.

    ![Refresh Node-Edge Graph](~/solutions/images/Scheduling_Workflow_Refresh.png)

1. Now we should have a resource available in the decoder pool to assign it to our job. In the *Nodes* table, select the *Decoder* resource pool and click the *Red Hand* icon.

1. The *Decoder* resource pool should be preselected. Select the *NewTek 001* resource and pick it.

    ![Pick Resource](~/solutions/images/Scheduling_Create_Job_Pick_Resource.png)

1. You should see both resources displayed in *Nodes* and *Workflow* sections now.

## Step 6: Confirming the job

Now that we have the resources in place, it's time to confirm the job.

1. Head over to the *Job info* section and click *Confirm job*.

   ![Confirm Job](~/solutions/images/Scheduling_Create_Job_Confirm.png)

1. You should see you job now colored in blue, with a green underline, which indicates that it's successfully created.
