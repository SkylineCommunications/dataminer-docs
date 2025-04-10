---
uid: Tutorial_Resource_Studio
---

# Getting started with the Resource Studio

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.8 and Ping Monitoring version 1.0.1-CU12.

## Prerequisites

## Overview

Say we have a set of devices that can convert signals between [SDI](https://en.wikipedia.org/wiki/Serial_digital_interface) and [IP](https://en.wikipedia.org/wiki/Internet_Protocol), SDI-to-IP being an **encoder** and IP-to-SDI converter being a **decoder**. To represent these 2 types of devices, we can create 2 matching resource pools. First open the **New** resource pool popup:

![New Resource Pool](~/solutions/images/Resource_Studio_New_Resource_Pool.png)

Next, fill in the form with appropriate names (**Encoder** and **Decoder**) for the resource pools. For now you don't have to change anything else in this form:

![New Resource Pool Form](~/solutions/images/Resource_Studio_New_Resource_Pool_Form.png)

After you **Save** both resource pools, you can see them listed in the **Resource Pools** table:

![New Resource Pool Created](~/solutions/images/Resource_Studio_New_Resource_Pools_Created.png)

Now that the resource pools are created, we can proceed with creating the resources and assigning them to the resource pools. The procedure is similar to creating resource pools, only this time we navigate to the **Resources** page.

![New Resource](~/solutions/images/Resource_Studio_New_Resource.png)

Name the resources "Video Solutions 001" and "NewTek 001", set the **Type** to `Unmanaged` and **Save** them. Also, let's assume that the first resource is just an **Encoder**, while the second one can be used either as an **Encoder** or **Decoder**, but it can act as only one of those at a time.

![New Resource Form](~/solutions/images/Resource_Studio_New_Resource_Form.png)

To make both resources available for assigninment to resource pools, open up their respective **Edit** panels and **Mark complete** both of the resources.

![Mark Complete](~/solutions/images/Resource_Studio_Resource_Mark_Complete.png)

Now that both the resources are created and available for usage, we can proceed with assigning them to the pools.

![Assign Resources](~/solutions/images/Resource_Studio_Assign_Resources.png)

In the assign resources panel, at the top of the screen you can see which resource pool you're assigning to. Below you can find all the resources, which you can also filter by their name. Once you find the resource you want to add to the pool, **select** it and click the **ADD** button on the top right.

![Assign Resources Panel](~/solutions/images/Resource_Studio_Assign_Resources_Panel.png)

> [!TIP]
> If you can't find your resource in the above panel, double check if it has been "marked complete".

You should add the "Video Solutions 001" and "NewTek 001" resources to the "Encoders" resource pool. If all went well, now you should see your resources have moved to the column on the right, which means they are  part of the resource pool. After that is done, open up the "Decoders" resource pool and add only "NewTek 001" resource to it. Now you have your resources and resource pools neatly organized and ready for use in other apps such as [Scheduling](xref:MO_Scheduling) and [Resource Studio](xref:MO_Resource_Studio).

One final step is to navigate to the **Edit** panel of both resource pools and **Mark complete** each of them. These resources and resource pools now can be assigned to jobs, as you will see in other examples in the the documentation.

![Mark Complete](~/solutions/images/Resource_Studio_Mark_Complete.png)

> [!TIP]
> You can also **Change icon** of the resource pools and make them convey more visual information when used in other apps.
