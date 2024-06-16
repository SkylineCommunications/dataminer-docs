---
uid: SLA_tutorial
---
# Using DataMiner business intelligence to manage and monitor your SLAs

This tutorial will show you how to configure and use a Service Level Agreement (SLA) to monitor a power service. You will learn to customize SLA parameters to track service metrics towards high availability compliance.

Because services are at the heart of SLAs, you will also learn how to use an existing service as the starting point for SLA management.

You will also see how to configure and alarm template to monitor and visualize alarms for city streets affected by power service degradation.

Expected duration: 20 minutes

> [!TIP]
> See also:
>
> - [Business intelligence](xref:sla)
> - [Skyline SLA Definition Basic connector help](https://docs.dataminer.services/connector/doc/Skyline_SLA_Definition_Basic.html)
> - [Services](xref:About_services)
> - [Alarm templates](xref:About_alarm_templates)
> - [Kata #TBD: Learn how to configure and manage your own SLAs](https://community.dataminer.services/courses/kata-TBD/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

> [!NOTE]
> The content and screenshots for this tutorial have been created using [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) version 10.4.7.0-14409.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the DataMiner SLA tutorial package from the Catalog and explore its content](#step-1-deploy-the-dataminer-sla-tutorial-package-from-the-catalog-and-explore-its-content)
- [Step 2: Create and configure a new SLA](#step-2-create-and-configure-a-new-sla)
- [Step 3: Assign a customized alarm template](#step-3-assign-a-customized-alarm-template)
- [Step 4: View and analyze SLA metrics](#step-4-view-and-analyze-sla-metrics)

## Step 1: Deploy the *DataMiner SLA tutorial* package from the Catalog and explore its content

1. Go to <https://catalog.dataminer.services/details/ac72d9e5-4c12-4408-a591-2fc2316abebf>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check that the following items are created in your DataMiner agent:
    1. View: *DataMiner SLA tutorial*
    1. Element: *Power Monitoring - Miami*
    1. Service: *Power Service - South Beach*

   If that is the case, the package has been successfully deployed.

   On the *Data* > *Table* page of the element, you will see that the *Street Overview* and *Power Parameters* tables contain pre-provisioned data:

   ![Street Overview and Power Parameters tables](~/user-guide/images/SLA_tutorial_img00.png)

    On the *Data* > *Table* page of the service, you will see that some of the power parameters have been included:

    ![Service power parameters](~/user-guide/images/SLA_tutorial_img01.png)

## Step 2: Create and configure a new SLA

1. Create "Power SLA - South Beach" element

    Right click on the *DataMiner SLA tutorial* view > *New* > *SLA*:

    ![Create SLA](~/user-guide/images/SLA_tutorial_img02.png)

    On the *New SLA* screen configure the following fields:
    - Name: *Power SLA - South Beach*
    - Service: *Power Service - South Beach*
    - Protocol: *Skyline SLA Definition Basic*
    - Version: *Production*

    Click Create.

    ![New SLA screen](~/user-guide/images/SLA_tutorial_img03.png)

1. Configure SLA element parameters

    On the *SLA Configuration* page configure the following parameters:
    - Window settings
        - Type: *Fixed window*
        - Time: *1*
        - Unit: *Minutes*
    - Alarm settings
        - Violation level: *Warning*
        - Delay time: *Not used*
        - Minimum outage threshold: *Full outage*
    - Extra settings
        - Admin state: *Tracking*
        - Base timestamp: *2001/01/01 00:00:00*
        - Time to keep outages: *1 Month*
        - SLA validity start time: *Since creation*
        - SLA validity end time: *Forever*

    ![SLA configuration](~/user-guide/images/SLA_tutorial_img04.png)

    On the *Compliance configuration* page configure the following parameters:
    - Total violation
        - Maximum total violations type: *Absolute*
        - Maximum total violations value: *20*
        - Maximum total violations unit: *Seconds*
    - Single violation
        - Maximum single violation type: *Absolute*
        - Maximum single violation value: *5*
        - Maximum single violation unit: *Seconds*
    - Violation count
        - Total violations before breached: *0*

    ![Compliance configuration](~/user-guide/images/SLA_tutorial_img05.png)

    On the *Advanced configuration* page configure the following parameters:
    - Active Alarms: *Show*
    - Outages: *Enabled*

    ![Advanced configuration](~/user-guide/images/SLA_tutorial_img06.png)

## Step 3: Assign a customized alarm template

1. Configure and assign the *DataMiner SLA tutorial* alarm template

    On *Apps* > *Protocols & Templates* > *Skyline Generic Virtual Connector*, open the *DataMiner SLA tutorial* alarm template and configure it as it follows:

    ![Open DataMiner SLA tutorial alarm template](~/user-guide/images/SLA_tutorial_img07.png)

    ![Configure DataMiner SLA tutorial alarm template](~/user-guide/images/SLA_tutorial_img08.png)

    Click Apply and then OK.

    Right click on the *Power Monitoring - Miami* element > *Protocols & Templates* > *Assign alarm template* and select the DataMiner SLA tutorial template.

    ![Assign DataMiner SLA tutorial alarm template](~/user-guide/images/SLA_tutorial_img09.png)

1. Generate an alarm

    On the *Power Monitoring - Miami* element > *Power Parameters* table, right click on *Ocean Drive* > *Edit item..* and set the Voltage to 115.

    ![Generate a Voltage alarm](~/user-guide/images/SLA_tutorial_img10.png)

    Click OK.

    See how a new Voltage alarm has been generated and how it impacts the *Power Service - South Beach* service.

   ![Voltage alarm](~/user-guide/images/SLA_tutorial_img10.1.png)

## Step 4: View and analyze SLA metrics

1. View general SLA metrics

    On the *Power SLA - South Beach* element > "Main View" page, see how the SLA has been breached due to the Voltage alarm.

    ![General SLA metrics](~/user-guide/images/SLA_tutorial_img11.png)

1. Restore service compliance and inspect SLA outages and history

    On the *Power Monitoring - Miami* element > *Power Parameters* table, right click on *Ocean Drive* > *Edit item..* and set the Voltage to 120, which will clear the Voltage alarm.

    On the *Power SLA - South Beach* element > "Main View" page, see how the SLA is restored to a compliance state.

    Review SLA *Outage List* and *History Statistics*, which show SLA compliance metrics over time.

    ![SLA outage list](~/user-guide/images/SLA_tutorial_img12.png)

    ![SLA history statistics](~/user-guide/images/SLA_tutorial_img13.png)

> [!TIP]
> Try browsing through the rest of the *Power SLA - South Beach* element and get familiar with available options such as, *Offline window* and *Violation settings*.
> Refer to the provided resources for details on these and other features.
