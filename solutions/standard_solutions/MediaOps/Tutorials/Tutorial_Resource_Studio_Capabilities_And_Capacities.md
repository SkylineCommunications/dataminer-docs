---
uid: Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities
---

# Assigning capabilities to resources

In this tutorial, you will learn how to model real devices in the Resource Studio app, making use of [capabilities](xref:MO_Resource_Studio#capabilities) and [capacities](xref:MO_Resource_Studio#capacities). The tutorial will use the example of a **converter** device that is capable of doing a conversion between [SDI](https://en.wikipedia.org/wiki/Serial_digital_interface) and [IP](https://en.wikipedia.org/wiki/Internet_Protocol). The conversion types will be modeled with a **resource capability** that has the two types as its discrete values.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.3.1.

> [!TIP]
> See also: [Resource Studio](xref:MO_Resource_Studio) and [Scheduling](xref:MO_Scheduling) documentation.

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **Resource Studio** application.

> [!NOTE]
> This tutorial continues from the [Configuring resources and resource pools](xref:Tutorial_MediaOps_Resource_Studio_Intro) tutorial. Ideally, you should follow that tutorial first, as the current tutorial makes use of the resources that are configured in it.

## Overview

- [Step 1: Create new resource pool](#step-1-create-new-resource-pool)
- [Step 2: Creating the capability](#step-2-creating-the-capability)
- [Step 3: Assigning capabilities to resources](#step-3-assigning-capabilities-to-resources)
- [Step 4: Assign resources to the pool](#step-4-assign-resources-to-the-pool)
- [Step 5: Define parameter on the resource pool](#step-5-define-parameter-on-the-resource-pool)

## Step 1: Create new resource pool

1. Open the **Resource Studio** app.

1. Bring up the **Add New Resource Pool** panel by clicking the *+ New* button on the upper left corner.

1. Name the new resource "**Converter**".

1. *Save as Completed* the new resource pool.

   ![New Converter Resource Pool](~/solutions/images/Resource_Studio_New_Converter_Pool.png)

## Step 2: Creating the capability

1. Navigate to the *Capability Management* page.

1. Open the **New Capability** panel by clicking *+ New Capability* in the upper left corner.

   ![Capability Management](~/solutions/images/Resource_Studio_Capability_Management.png)

1. Give the new capability *Name* "**Conversion Type**".

1. Set the *Is Mandatory* toggle on.

1. *Add Discrete* options "**IP to SDI**" and "**SDI to IP**".

1. *Add* the new capacity.

   ![New Capability](~/solutions/images/Resource_Studio_New_Capability.png)

## Step 3: Assigning capabilities to resources

1. Navigate to the *Resources* page.

1. Select the **Video Solution 001** resource.

1. On the right side of the screen, you can see 3 sections: *Capabilities*, *Capacities*, and *Properties*. Click the *Edit* button in the *Capabilities*.

1. In the newly opened *Manage Capabilities* window, in the *CAPABILITIES* section click on the *+* button to add a new capability.

   ![Manage Capabilities](~/solutions/images/Resource_Studio_Manage_Capabilities.png)

1. In the new dropdown, select the *Conversion Type*.

1. Click the *Values* button to select the capability values.

1. In the *DISCRETES* section, click on the *+* button.

1. In the dropdown, select the *SDI to IP* option.

1. Click *Back*.

   ![Manage Capabilities - Discretes](~/solutions/images/Resource_Studio_Manage_Capabilities_Discretes.png)

1. Click *Apply*.

1. Repeat the steps to add both *SDI to IP* and *IP to SDA* capability discretes to the **NewTek 001** resource.

## Step 4: Assign resources to the pool

1. Assign both **Video Solution 001** and **NewTek 001** resources to the **Converter** resource pool.

## Step 5: Define parameter on the resource pool

In this step, you will define a parameter on a resource pool, which can come in handy later when selecting resources (see [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations)).

1. Navigate to the *Resource Pools* page.

1. Select the **Converter** resource.

1. Open the *...* menu and select the *Edit Parameters* option.

   ![Edit Resource Pool Parameters](~/solutions/images/Resource_Studio_Edit_Resource_Pool_Parameters.png)

1. Under the *CAPABILITIES* section, click the *+* button and select the *Conversion Type* option from the dropdown.

1. Click *Update*.

   ![Edit Resource Pool Parameters Popup](~/solutions/images/Resource_Studio_Edit_Resource_Pool_Parameters_Popup.png)