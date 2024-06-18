---
uid: SLA_tutorial
---
# Using an SLA to monitor a power service

In this tutorial, you will learn how to configure and use a Service Level Agreement (SLA) to monitor a power service. You will learn to customize SLA parameters to track service metrics towards high availability compliance.

Because services are at the heart of SLAs, you will also learn how to use an existing service as the starting point for SLA management.

Additionally, you will learn how to configure an alarm template to monitor and visualize alarms for city streets affected by power service degradation.

Expected duration: 20 minutes

> [!TIP]
> See also:
>
> - [Business intelligence](xref:sla)
> - [Connector documentation: Skyline SLA Definition Basic](https://docs.dataminer.services/connector/doc/Skyline_SLA_Definition_Basic.html)
> - [Services](xref:About_services)
> - [Alarm templates](xref:About_alarm_templates)

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.7.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the DataMiner SLA tutorial package from the Catalog](#step-1-deploy-the-dataminer-sla-tutorial-package-from-the-catalog)
- [Step 2: Create a new SLA](#step-2-create-a-new-sla)
- [Step 3: Configure your new SLA](#step-3-configure-your-new-sla)
- [Step 4: Assign and modify an alarm template](#step-4-assign-and-modify-an-alarm-template)
- [Step 5: Analyze the SLA metrics](#step-5-analyze-the-sla-metrics)

## Step 1: Deploy the *DataMiner SLA tutorial* package from the Catalog

1. Go to <https://catalog.dataminer.services/details/ac72d9e5-4c12-4408-a591-2fc2316abebf>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether the following items have been added to your DataMiner Agent:

   - A view named "DataMiner SLA tutorial" (1)

   - An element named "Power Monitoring - Miami" (2)

   - A service named "Power Service - South Beach" (3)

   ![DataMiner SLA tutorial](~/user-guide/images/DataMiner_SLA_Tutorial.png)

   If this is the case, the package has been successfully deployed.

   On the *Data* > *Table* page of the element, you will see that the *Street Overview* and *Power Parameters* tables contain pre-provisioned data:

   ![Street Overview and Power Parameters tables](~/user-guide/images/SLA_tutorial_img00.png)

    On the *Data* > *Power Monitoring - Miami* > *Table* page of the service, you will see that the *Power Parameters* table already contains two entries.

    ![Service power parameters](~/user-guide/images/SLA_tutorial_img01.png)

## Step 2: Create a new SLA

Now that you have installed the *DataMiner SLA tutorial* package, you will create a new Service Level Agreement (SLA).

1. In the Surveyor, right-click the *DataMiner SLA tutorial* view and select *New* > *SLA*.

   ![Create SLA](~/user-guide/images/SLA_tutorial_img02.png)

   A card will open.

1. Specify the following information:

   - *Name*: `Power SLA - South Beach`

   - *Service*: `Power Service - South Beach`

   - *Protocol*: `Skyline SLA Definition Basic`

   - *Version*: Production

1. Click *Create* to add the SLA.

   ![New SLA screen](~/user-guide/images/SLA_tutorial_img03.png)

## Step 3: Configure your new SLA

In this step, you will configure different data pages of your newly created SLA.

1. On the *Data* > *SLA Configuration* page of your SLA, configure the following parameters:

   - *Window settings* > *Type*: Fixed window

   - *Window settings* > *Time*: 1

   - *Window settings* > *Unit*: Minutes

   - *Alarm settings* > *Violation Level*: Warning

   - *Alarm settings* > *Delay Time*: Not used

   - *Alarm settings* > *Minimum outage threshold*: Full outage

   - *Extra settings* > *Admin State*: Tracking

   - *Extra settings* > *Base Timestamp*: 2001/01/01 00:00:00

   - *Extra settings* > *Time To Keep Outages*: 1 Month

   - *Extra settings* > *SLA Validity Start Time*: Since creation

   - *Extra settings* > *SLA Validity End Time*: Forever

   > [!TIP]
   > To save all changes simultaneously, click *Save all* in the lower right corner.

   ![SLA configuration](~/user-guide/images/SLA_tutorial_img04.png)

1. On the *Data* > *Compliance Configuration* page of your SLA, configure the following parameters:

   - *Total violation* > *Maximum Total Violations Type*: Absolute

   - *Total violation* > *Maximum Total Violations Value*: 20

   - *Total violation* > *Maximum Total Violations Unit*: Seconds

   - *Violation count* > *Total Violations Before Breach*: 0

   - *Single violation* > *Maximum Single Violation Type*: Absolute

   - *Single violation* > *Maximum Single Violation Value*: 5

   - *Single violation* > *Maximum Single Violation Unit*: Seconds

   > [!TIP]
   > To save all changes simultaneously, click *Save all* in the lower right corner.

   ![Compliance configuration](~/user-guide/images/SLA_tutorial_img05.png)

1. On the *Data* > *Advanced Configuration* page, configure the following parameters:

   - *Active Alarms*: Show

   - *Outages*: Enabled

   ![Advanced configuration](~/user-guide/images/SLA_tutorial_img06.png)

## Step 4: Assign and modify an alarm template

In the next step, you will assign an alarm template to the *Power Monitoring - Miami* element. This alarm template came included in the package you installed in a previous step. However, you will need to modify it.

1. In the Cube sidebar, go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, select *Skyline Generic Virtual Connector*.

1. Under *Alarm*, right-click *DataMiner SLA tutorial* and select *Open*.

   ![Open DataMiner SLA tutorial alarm template](~/user-guide/images/SLA_tutorial_img07.png)

1. Configure the alarm template:

   1. Under *Table*, set the *Power Parameters: Voltage (V)* parameter to *Included*.

   1. Configure the following alarm thresholds:

      - In the *WARN LO* column, enter `115`.

      - In the *NORMAL* column, enter `120`.

      ![Configure DataMiner SLA tutorial alarm template](~/user-guide/images/SLA_tutorial_img08.png)

   1. Click *Apply* and then *OK*.

1. In the Surveyor, right-click the *Power Monitoring - Miami* element and select *Protocols & Templates* > *Assign alarm template* > *DataMiner SLA tutorial*.

1. Confirm that you want to apply this alarm template.

1. Generate an alarm to verify whether the alarm template was correctly configured.

   1. In the Surveyor, select the *Power Monitoring - Miami* element.

   1. Go to the *DATA* > *Table* page, right-click the *Ocean Drive* entry in the *Power Parameters* table, and select *Edit item*.

   1. Lower the Voltage to 115.

      ![Generate a Voltage alarm](~/user-guide/images/SLA_tutorial_img10.png)

   1. Click *OK*.

   The *Power Parameters* table on the *DATA* > *TABLE* page of your element will now show an alarm in the *Voltage* column of the *Ocean Drive* entry.

   ![Voltage alarm](~/user-guide/images/SLA_tutorial_img10.1.png)

   In the Alarm Console, you will see an alarm of severity *Warning Low* for the *Power Monitoring - Miami* element.

   ![Alarm Console](~/user-guide/images/SLA_tutorial_Alarm_Console.png)

## Step 5: Analyze the SLA metrics

In this final step, you will learn to interpret the different SLA metrics.

1. Go to the *DATA* > *Main View* page of the *Power SLA - South Beach* SLA.

1. Under *Compliance Info*, verify whether *Compliance* is set to *Compliant* or *Breached*.

   Because of the Voltage alarm you simulated, it should show *Breached*.

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
