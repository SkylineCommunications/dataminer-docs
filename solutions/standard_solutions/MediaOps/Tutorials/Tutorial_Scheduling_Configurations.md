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

> [!NOTE]
> This tutorial continues from the tutorials [Configuring resources and resource pools](xref:Tutorial_MediaOps_Resource_Studio_Intro), [Creating a job and configuring it with resources](xref:Tutorial_MediaOps_Scheduling_Encoder_Decoder), and [Assigning capabilities to resources](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities). Ideally, you should follow these tutorials first, so that you have an understanding of the basic concepts they introduce. The current tutorial will also make us of the resources with capabilities created in this last tutorial.

## Overview

- [Step 1: Create a new job](#step-1-create-a-new-job)
- [Step 2: Add the Converter resource pool to the job](#step-2-add-the-converter-resource-pool-to-the-job)
- [Step 3: Configure resource pools](#step-3-configure-resource-pools)
- [Step 4: Pick resources](#step-4-pick-resources)
- [Step 5: Confirm the job](#step-5-confirm-the-job)

## Step 1: Create a new job

1. Open the **Scheduling** app.

1. On the *Job View* page, click the **+ New** button.

1. Specify a name of your choice for the job and click **Create Job**.

## Step 2: Add the Converter resource pool to the job

1. Click the **pencil** icon for the job to open the *Edit* panel.

1. Scroll down to the *Workflow* section of the panel, and click **Add Node**.

   ![Add Node](~/solutions/images/Scheduling_Add_Node.png)

1. Select the "**Converter**" resource pool.

1. Click the *+ Add Resource Pool* button.

   ![Add Resource Pool](~/solutions/images/Scheduling_Add_Resource_Pool.png)

1. **Select** the newly added node.

1. Click the *Add After* button to add another resource pool.

   ![Add After](~/solutions/images/Scheduling_Add_After.png)

1. Add "**Converter**" resource pool node again.

   ![Workflow Converters](~/solutions/images/Scheduling_Workflow_Converters.png)

1. If you do not see the results immediately in the node-edge graph, use the *Workflow* section's *Refresh* button.

    ![Refresh Node-Edge Graph](~/solutions/images/Scheduling_Workflow_Refresh.png)

## Step 3: Configure resource pools

1. In the *Workflow* section of both nodes, click the *Configure* button.

1. In the *CONFIGURATION* section, select "**Conversion Type**" from the dropdown menu.

1. Select the check box to enable option selection.

1. For the first resource, choose the "**SDI to IP**" option, and for the second one choose the "**IP to SDI**".

1. Click *Update*.

   ![Select Configuration](~/solutions/images/Scheduling_Select_Configuration.png)

## Step 4: Pick resources

1. Navigate to the *Nodes* section of the *Edit* panel of the job.

1. Notice that both of the resources pools have a red hand symbol in the *Resource Select Column*, which means that we still have to pick actual resources for them.

1. For both resources, click the *Red hand icon*.

1. For the first resource pool, choose the *Video Solutions 001* resource. For the second one, choose *NewTek 001*.

   ![Pick Resource](~/solutions/images/Scheduling_Pick_Resource.png)

   > [!NOTE]
   > Notice how the options get narrowed down when picking resources. Above, you can see that the resources shown are only those that match the configuration selected earlier.

## Step 5: Confirm the job

1. Navigate to the *Job Info* section.

1. Click the *Save as Tentative* button.

1. Click *Confirm Job* button.

You have now successfully scheduled a job with the use of configurations.
