---
uid: Tutorial_MediaOps_Scheduling_Configurations
---

# Add node configuration

In this tutorial we will see how to add the capabilities we created in the [Resource Studio Capabilities Tutorial](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities) to the jobs in the Scheduling app.

Expected duration: 15 minutes

> [!NOTE]  
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.2.5-CU0.

> [!TIP]  
> See also: [Resource Studio](xref:MO_Resource_Studio) and [Scheduling](xref:MO_Scheduling) documentation.

## Prerequisites

- A DataMiner System using DataMiner `10.5.4` or higher.
- Access to the **Scheduling** application.
- Understading of the basic Resource Studio concepts, explained in the [Resource Studio Intro Tutorial](xref:Tutorial_MediaOps_Resource_Studio_Intro).
- Understanding of the basic Scheduling app concepts, explained in the [Scheduling Intro Tutorial](xref:Tutorial_MediaOps_Scheduling_Encoder_Decoder).
- Having the resources with capabilities created in the [Resource Studio Capabilities Tutorial](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities).

## Overview

## Step 1: Create a new job

1. Open the **Scheduling** app.

1. Navigate to the `Job View` panel.

1. Open `+ New` job dialog and give your job an arbitrary name.

1. `Create job`.

> [!NOTE]  
> More detailed guide on creating jobs is presented in the [Scheduling Intro Tutorial](xref:Tutorial_MediaOps_Scheduling_Encoder_Decoder).

## Step 2: Add `Converter` resource pool to the job

1. Open the `✏️ Edit` panel of the job created in the previous step.

1. Navigate to the `Workflow` section of the job at the bottom of the Edit panel.

1. Click on the `Add Node` button.

   ![Add Node](~/solutions/images/Scheduling_Add_Node.png)

1. Select the "**Converter**" resource pool.

1. Click on the `+ Add Resource Pool` button.

   ![Add Resource Pool](~/solutions/images/Scheduling_Add_Resource_Pool.png)

1. **Select** the newly added node.

1. Click on `Add After` button to add another resource pool.

   ![Add After](~/solutions/images/Scheduling_Add_After.png)

1. Add "**Converter**" resource pool node again.

   ![Workflo Converters](~/solutions/images/Scheduling_Workflow_Converters.png)

    > [!NOTE]  
    > Depending on the Scheduling app **version**, you might need to hit the **refresh** button to see the newly added resource.

## Step 3: Configure resource pools

1. In the `Workflow` section of both nodes, click on the `Configure` button.

1. In the `CONFIGURATION` section, select "**Conversion Type**" from the dropdown menu.

1. Check the tickbox to enable option selection.

1. For the first resource, choose the "**SDI to IP**" option, and for the second one choose the "**IP to SDI**".

1. Click `Update`.

   ![Select Configuration](~/solutions/images/Scheduling_Select_Configuration.png)

## Step 4: Pick resources

1. Navigate to the `Nodes` section of the `Edit` panel of the job.

1. Notice that both of the resources pools have a red hand symbol in the `Resource Select Column`, which means that we still have to pick concrete resources for them.

1. For both resources, click the `Red hand icon`.

1. For the first resource pool, choose the `Video Solutions 001` resource. For the second one, chose `NewTek 001`.

   ![Pick Resource](~/solutions/images/Scheduling_Pick_Resource.png)
   
    > [!NOTE]  
    > Notice how the options get narrowed down when picking resources. In the above picture, the resources shown are only those that match the configurations we choose earlier. Pretty neat!

## Step 5: Confirm the job

1. Navigate to the `Job Info` section.

1. Click on the `Save as Tentative` button.

1. Click on `Confirm Job` button.

🎉 Congratulations, you have successfully scheduled a job! 🎉
