---
uid: Tutorial_MediaOps_Scheduling_Configurations
---

# Scheduling a job using a resource pool with specific capabilities

This tutorial builds on the [Assigning capabilities to resources](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities) tutorial, showing you how you can schedule a job using a resource pool with specific [capabilities](xref:MO_Resource_Studio#capabilities).

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.3.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **Scheduling** application.
- You have complete the tutorials [Configuring resources and resource pools](xref:Tutorial_MediaOps_Resource_Studio_Intro) and [Assigning capabilities to resources](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities).

> [!NOTE]
> Ideally, you should also follow the tutorial [Creating a job and configuring it with resources](xref:Tutorial_MediaOps_Scheduling_Encoder_Decoder) first, so you have a better understanding of how to create a basic job.

## Overview

- [Step 1: Create a new job](#step-1-create-a-new-job)
- [Step 2: Add the Converter resource pool to the job](#step-2-add-the-converter-resource-pool-to-the-job)
- [Step 3: Configure the resource pools](#step-3-configure-the-resource-pools)
- [Step 4: Pick resources](#step-4-pick-resources)
- [Step 5: Confirm the job](#step-5-confirm-the-job)

## Step 1: Create a new job

1. Open the **Scheduling** app.

1. On the *Job View* page, click the **+ New** button.

1. Specify a name of your choice for the job and click **Create Job**.

## Step 2: Add the Converter resource pool to the job

1. Click the **pencil** icon on the job to open the *Edit job* panel.

1. Scroll down to the *Workflow* section of the panel, and click **Add Node**.

   ![Add Node](~/solutions/images/Scheduling_Add_Node.png)

1. On the left side of the *Add Node* panel, select the **Converter** resource pool, and then click the **+ Add Resource Pool** button.

   ![Add Resource Pool](~/solutions/images/Scheduling_Add_Resource_Pool.png)

1. First select the newly added node, and then click the **Add After** button to add another resource pool.

   ![Add After](~/solutions/images/Scheduling_Add_After.png)

1. Again select the **Converter** resource pool and click **+ Add Resource Pool**.

   This will be the resulting workflow:

   ![Converters workflow](~/solutions/images/Scheduling_Workflow_Converters.png)

   If you do not see this result immediately, use the refresh button in the top-right corner of the *Workflow* section.

    ![Refresh button](~/solutions/images/Scheduling_Workflow_Refresh.png)

## Step 3: Configure the resource pools

1. Select the first node in the *Workflow* section, and click the *Configure* button.

1. In the *Select Configuration* window, make sure **Conversion Type** is selected.

   This is the parameter that was configured in the last step of the tutorial [Assigning capabilities to resources](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities).

1. Select the checkbox to enable option selection, and select **SDI to IP**.

1. Click **Update**.

   ![Select Configuration](~/solutions/images/Scheduling_Select_Configuration.png)

1. Select the second node and repeat the steps above, selecting **IP to SDI** instead.

## Step 4: Pick resources

1. Scroll up to the *Nodes* section of the *Edit* panel.

   You will see that for both resource pools the ![Red Hand](~/solutions/images/Red_Hand_icon.png) icon is shown in the *Resource Select Column*, which means that the resources still need to be picked for these.

1. Click this icon for the first resource pool, and then select the *Video Solutions 001* resource and click *Pick*.

   Note how only the resources matching your configuration will be available for selection.

   ![Pick Resource](~/solutions/images/Scheduling_Pick_Resource.png)

1. Click the icon for the second resource pool, and now select *NewTek 001* and select *Pick*.

   Note how the options for resource selection have been narrowed down further at this point: the resource you picked earlier is no longer available for selection.

## Step 5: Confirm the job

1. Scroll up to the **Job Info** section.

1. Click the **Save as Tentative** button.

1. Click the **Confirm Job** button.

You have now successfully scheduled a job using a resource pool featuring a capability and parameter configuration.

## Up next

To learn how you can create a workflow template that can be used in different jobs, making the job configuration easier and more user-friendly when the same workflow is used in multiple jobs, follow the next tutorial [Creating a workflow to use as a template for a job](xref:Tutorial_MediaOps_Workflow_Designer_Intro).
