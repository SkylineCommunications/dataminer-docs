---
uid: Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities
---

# Assigning capabilities to resources

In this tutorial, you will learn how to model real devices in the [Resource Studio app](xref:MO_Resource_Studio), making use of [capabilities](xref:MO_Resource_Studio#capabilities) and [capacities](xref:MO_Resource_Studio#capacities). The tutorial will use the example of a **converter** device that is capable of doing a conversion between SDI and IP. The conversion types will be modeled with a **resource capability** that has the two types as its discrete values.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.3.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **Resource Studio** application.
- You have complete the tutorial [Configuring resources and resource pools](xref:Tutorial_MediaOps_Resource_Studio_Intro).

## Overview

- [Step 1: Create a new resource pool](#step-1-create-a-new-resource-pool)
- [Step 2: Create a new capability](#step-2-create-a-new-capability)
- [Step 3: Assign the capability to resources](#step-3-assign-the-capability-to-resources)
- [Step 4: Assign resources to the pool](#step-4-assign-resources-to-the-pool)
- [Step 5: Define a parameter on the resource pool](#step-5-define-a-parameter-on-the-resource-pool)

## Step 1: Create a new resource pool

1. Open the **Resource Studio** app.

1. On the *Resource Pools* page, click the **+ New** button in the upper left corner.

   This will open the **Add New Resource Pool** panel.

1. Specify the name `Converter` and click **Save as Completed** to save your new resource pool.

   ![New Converter resource pool](~/solutions/images/Resource_Studio_New_Converter_Pool.png)

## Step 2: Create a new capability

1. Navigate to the **Capability Management** page.

1. Click **+ New Capability** in the upper left corner to open the *New Capability* panel.

   ![Capability Management](~/solutions/images/Resource_Studio_Capability_Management.png)

1. Specify the name `Conversion Type`.

1. Select the **Is Mandatory** checkbox.

1. Next to **Options**, specify `IP to SDI`.

1. Click **Add Discrete**, and specify `SDI to IP` in the additional options box.

1. Click **Add** to add the new capability.

   ![New capability](~/solutions/images/Resource_Studio_New_Capability.png)

## Step 3: Assign the capability to resources

1. Navigate to the **Resources** page.

1. Select the **Video Solution 001** resource.

1. In the **Capabilities** section on the right, click the **Edit** button.

1. In the newly opened *Manage Capabilities* window, from the `- Add Capability -` dropdown, select the **Conversion Type** option.

   ![Manage Capabilities](~/solutions/images/Resource_Studio_Manage_Capabilities.png)

1. In the new `- Add Option -` dropdown, select the **SDI to IP** option.

   ![Manage Capabilities - Discretes](~/solutions/images/Resource_Studio_Manage_Capabilities_Discretes.png)

1. Click **Update**.

1. Select the **NewTek 001** resource.

1. Repeat the steps from the *Video Solution 001* resource to add **both the *SDI to IP* and *IP to SDI* capability discretes** to the *NewTek 001* resource.

## Step 4: Assign resources to the pool

1. Navigate to the **Resource Pools** page.

1. Next to the **Converter** resource pool that you created earlier, click ... to open up the context menu, and select **Assign Resources**.

1. Select the *Video Solution 001* and *NewTek 001* resources and click the **+Add** button at the top.

## Step 5: Define a parameter on the resource pool

In this step, you will define a parameter on a resource pool, which can come in handy when a job is scheduled and you need to select resources for it. <!-- TODO: either explain why, or link to section that explains configuration management for more info -->

1. On the *Resource Pools* page, click ... next to the **Converter** resource pool, and select the *Edit Parameters* option.

   ![Edit Resource Pool Parameters](~/solutions/images/Resource_Studio_Edit_Resource_Pool_Parameters.png)

1. Click the *+* button and select the *Conversion Type* option from the dropdown.

1. Click *Update*.

   ![Edit Resource Pool Parameters Popup](~/solutions/images/Resource_Studio_Edit_Resource_Pool_Parameters_Popup.png)

## Up next

When you have finished this tutorial, follow the tutorial [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations) to learn how you can use schedule a job using the resource pool you have configured in this tutorial.
