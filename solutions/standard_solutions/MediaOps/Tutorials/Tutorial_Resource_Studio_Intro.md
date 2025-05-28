---
uid: Tutorial_MediaOps_Resource_Studio_Intro
---

# Getting started with the Resource Studio

In this tutorial, you will learn how to create and configure resource pools and resources using the Resource Studio.

Expected duration: 15 minutes

> [!NOTE]  
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.2.5-CU0.

> [!TIP]  
> See also: [Resource Studio documentation](xref:MO_Resource_Studio)

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **Resource Studio** application.

## Overview

- [Step 1: Create resource pools](#step-1-create-resource-pools)
- [Step 2: Create resources](#step-2-create-resources)
- [Step 3: Assign resources to pools](#step-3-assign-resources-to-pools)

## Step 1: Create resource pools

Assume that you have a set of devices you would like to add to the Resource Studio app. The devices convert signals between [SDI](https://en.wikipedia.org/wiki/Serial_digital_interface) and [IP](https://en.wikipedia.org/wiki/Internet_Protocol). SDI-to-IP devices act as **encoders**, and IP-to-SDI devices as **decoders**.

To represent these device types in the Resource Studio app, you can create two matching resource pools:

1. Open the *+ New* Resource Pool window.

   ![New Resource Pool](~/solutions/images/Resource_Studio_New_Resource_Pool.png)

1. Fill in the form with the names "Encoder" and "Decoder" for the respective pools.

   ![New Resource Pool Form](~/solutions/images/Resource_Studio_New_Resource_Pool_Form.png)

   > [!TIP]  
   > You don’t need to modify other fields in the form for this tutorial.

1. Click **Save as Completed**.

   > [!NOTE]
   > *Complete* is one of the states a resource pool can be in. If you choose to save it in the *Draft* state (on the bottom left) instead, you will be able to finish the tutorial, but the resource pools will not be available for use in the other apps like [Scheduling](xref:MO_Scheduling) and [Resource Studio](xref:MO_Resource_Studio).

1. Confirm both resource pools are listed in the **Resource Pools** table.

   ![New Resource Pool Created](~/solutions/images/Resource_Studio_New_Resource_Pools_Created.png)

## Step 2: Create resources

Now that the resource pools are created, we can proceed to create resources and assign them to the resource pools.

1. Go to the **Resources** page.

   ![New Resource](~/solutions/images/Resource_Studio_New_Resource.png)

1. Create two resources:

   - *Video Solutions 001*
   - *NewTek 001*

1. For both resources, the **Type** should be *Unmanaged*.

1. Click **Save as Completed**.

   ![New Resource Form](~/solutions/images/Resource_Studio_New_Resource_Form.png)

> [!NOTE]  
> In this example, *Video Solutions 001* is an **Encoder** only, while *NewTek 001* can act as either an **Encoder** or **Decoder**, but only one at a time.

## Step 3: Assign resources to pools

1. Navigate to the **Resource Pools** page.

1. On the **Encoder** resource pool that we created earlier, click *...* to open up the context menu.

1. Click **Assign Resources**.

   ![Assign Resources](~/solutions/images/Resource_Studio_Assign_Resources.png)

1. At the top of the panel, confirm the resource pool name matches the one you actually want to assigning resources to, namely "**Encoder**".

1. Optionally, use the filter box to locate the resources you want to assign.

1. Select *Video Solutions 001* and *NewTek 001* resources, and click *+ ADD*.

   ![Assign Resources Panel](~/solutions/images/Resource_Studio_Assign_Resources_Panel.png)

1. Similarly, assign *NewTek 001* resource to the **Decoder** pool.

> [!TIP]  
> If your resource doesn’t show up, make sure it has been **marked complete**.

You should now see the resources listed in the right-hand column of each pool. This brings us to the end of this tutorial. By now, if all went well, you should have some resources and resource pools ready for use in other applications such as [Scheduling](xref:MO_Scheduling) and [Resource Studio](xref:MO_Resource_Studio).

> [!NOTE]
> In case your resources or resource pools are in *Draft* state, you can change the state to *Complete* as follows:
>
> 1. By clicking the pencil icon, open the **Edit** panel of each resource/resource pool you want to edit.
> 1. Click **Complete**.

![Mark Complete](~/solutions/images/Resource_Studio_Complete.png)

> [!TIP]
> You can also **Change icon** of the resource pools to add visual context in other applications.
