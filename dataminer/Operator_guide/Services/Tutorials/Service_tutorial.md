---
uid: Service_tutorial
---

# Providing a customer-centric system view with services

In this tutorial, you will learn how to create a service for a television channel. In a first setup, this service will take its input from two different receiver elements. Depending on the position of a switch, one or the other will be picked to include in the service. Afterwards, you will reconfigure the service so it will always include both elements but will limit the influence the element alarm states have on the overall alarm severity of the service based on the switch position. In both situations, your service will indicate how it is performing towards your customers, regardless of the underlying infrastructure.

The content and screenshots for this tutorial have been created using DataMiner 10.5.2.

Expected duration: 20 minutes

> [!TIP]
> See also: [Kata #60: Building a customer-centric system view with services](https://community.dataminer.services/courses/kata-60/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the DataMiner Service Tutorial package from the Catalog](#step-1-deploy-the-dataminer-service-tutorial-package-from-the-catalog)
- [Step 2: Create a new service](#step-2-create-a-new-service)
- [Step 3: Configure your service for dynamic element inclusion](#step-3-configure-your-service-for-dynamic-element-inclusion)
- [Step 4: Reconfigure your service for dynamic service alarm influencing](#step-4-reconfigure-your-service-for-dynamic-service-alarm-influencing)

## Step 1: Deploy the *DataMiner Service Tutorial* package from the Catalog

1. Go to <https://catalog.dataminer.services/details/62840610-072c-4316-9e04-703f7688e857>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

When the package has been fully deployed, you will see the following view structure in the Surveyor in DataMiner Cube:

![Surveyor](~/dataminer/images/tutorial_services_step1_surveyor.png)

## Step 2: Create a new service

1. In the Cube Surveyor, right-click the view *Services - Tutorial* > *TV Channels* and select *New* > *Service*.

1. On the *edit* page, in the *Name* field, specify **BBC Sports**.

1. Click *Next*.

1. On the *parameters* page, click *Add element*.

1. Select **ird-uk-lon-01** and **ird-uk-man-01** and click *ADD > >*.

1. Click *OK* to close the pop-up window.

1. Click *Create* to create the service.

At this point, you have created a service that includes two elements:

![BBC Sports service](~/dataminer/images/tutorial_services_step2_new.png)

## Step 3: Configure your service for dynamic element inclusion

In this step, you will configure the service to dynamically include the element providing the active signal source, based on the position of a switch.

1. In the Surveyor, right-click the **BBC Sports** service you created earlier and select *Edit*.

1. Go to the *parameters* page.

1. Select the **ird-uk-lon-01** element and configure the following details in the pane on the right:

   1. In the *Alias* field, specify **Site 1**.

   1. Clear the *All parameters* checkbox.

   1. Select the **Audio Output Level** parameter.

   1. Under *THIS ELEMENT IS INCLUDED IN THE SERVICE*, select *Based on conditions* and *Include (In use when condition matches)*.

   1. Click *Add condition* and configure the following condition:

     ![Is Parameter value sw-uk-01 Switch Site Selection Equal to value Site 1](~/dataminer/images/tutorial_services_step3_condition.png)

   The configuration for this element should now look like this:

   ![Element configuration for ird-uk-lon-01](~/dataminer/images/tutorial_services_step3_ird-uk-lon-01.png)

1. Select the **ird-uk-man-01** element and configure the following details in the pane on the right:

   1. In the *Alias* field, specify **Site 2**.

   1. Clear the *All parameters* checkbox.

   1. Select the **Audio Output Level** parameter.

   1. Under *THIS ELEMENT IS INCLUDED IN THE SERVICE*, select *Based on conditions* and *Include (In use when condition matches)*.

   1. Click *Add condition* and configure the following condition:

      ![Is Parameter value sw-uk-01 Switch Site Selection Equal to value Site 2](~/dataminer/images/tutorial_services_step3_condition2.png)

   The configuration for this element should now look like this:

   ![Element configuration for ird-uk-man-01](~/dataminer/images/tutorial_services_step3_ird-uk-man-01.png)

1. Click *Apply* to save the changes.

Now your service will only include the element that is active based on the **Switch Site Selection** parameter from the **sw-uk-01** element. Switching this parameter from *Site 1* to *Site 2* and vice versa will change the included element. This makes sure you will get the live status of your service regardless of the source of your signal.

![BBC Sports service with dynamic inclusion](~/dataminer/images/tutorial_services_step3_service.png)

![Switch position](~/dataminer/images/tutorial_services_step3_switch-position.png)

## Step 4: Reconfigure your service for dynamic service alarm influencing

Having only the active element in your service can give you a false sense of security. Your service could be running fine on the current source input, but your other source might have an alarm that you are currently missing. This means that when you need to switch to the other source, you could run into problems. In this step, you will adapt the service to get an early warning for potential problems with the other signal.

1. In the Surveyor, right-click the **BBC Sports** service you created earlier and select *Edit*.

1. Go to the *parameters* page.

1. Select the **ird-uk-lon-01** element and configure the following details in the pane on the right:

   1. Under *THIS ELEMENT IS INCLUDED IN THE SERVICE*, select *Always*.

   1. Under *ONCE INCLUDED, THIS ELEMENT WILL INFLUENCE THE OVERALL ALARM SEVERITY OF THE SERVICE*, select *Based on conditions*.

   1. Add the condition **Is Parameter value sw-uk-01 Switch Site Selection Equal to value Site 1**.

   1. Under *ADVANCED*, configure the option *Maximum severity on element not used* and set it to **Warning**.

   The configuration for this element should now look like this:

   ![Element configuration for ird-uk-lon-01](~/dataminer/images/tutorial_services_step4_ird-uk-lon-01.png)

1. Select the **ird-uk-man-01** element and configure the following details in the pane on the right:

   1. Under *THIS ELEMENT IS INCLUDED IN THE SERVICE*, select *Always*.

   1. Under *ONCE INCLUDED, THIS ELEMENT WILL INFLUENCE THE OVERALL ALARM SEVERITY OF THE SERVICE*, select *Based on conditions*.

   1. Add the condition **Is Parameter value sw-uk-01 Switch Site Selection Equal to value Site 2**.

   1. Under *ADVANCED*, configure the option *Maximum severity on element not used* and set it to **Warning**.

   The configuration for this element should now look like this:

   ![Element configuration for ird-uk-man-01](~/dataminer/images/tutorial_services_step4_ird-uk-man-01.png)

1. Click *Apply* to save the changes.

1. Open the **sw-uk-01** element and change the **Switch Site Selection** parameter to **Site 2**.

Now your service will include both elements, but the service will indicate the one that is in use. The source that is not active will at most cause a warning alarm on the service.

In Cube, you will now see a warning alarm on the service coming from the signal from Site 1, while the signal from Site 2 is working fine. This way, you will be able to spot problems with the other signal early, before you need to use it.

![BBC Sports service with dynamic service alarm influencing](~/dataminer/images/tutorial_services_step4_service.png)
