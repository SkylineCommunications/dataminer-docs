---
uid: Smart_Trap_Processor_Tutorial
---

# Getting started with the Smart Trap Processor

In this tutorial, you will learn how to get started with the Smart Trap Processor tool and define rules for collecting and processing SNMP traps from various sources.

Expected duration: 30 minutes.

> [!TIP]
> See also: [Kata #48: Smart Trap Processor tool](https://community.dataminer.services/courses/kata-48/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

> [!TIP]
> If you use a [DaaS system](xref:Creating_a_DMS_on_dataminer_services), these prerequisites are automatically met.

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the Smart Trap Processor Training package from the Catalog](#step-1-deploy-the-smart-trap-processor-training-package-from-the-catalog)
- [Step 2: Configure the Trap IP Sources](#step-2-configure-the-trap-ip-sources)
- [Step 3: Configure the Rules Table](#step-3-configure-the-rules-table)
- [Step 4: Configure the Source Name Table](#step-4-configure-the-source-name-table)
- [Step 5: Configure the Source IP Name Table](#step-5-configure-the-source-ip-name-table)
- [Step 6: Send traps via the Trap Simulator](#step-6-send-traps-via-the-trap-simulator)
- [Step 7: Configure a rule in case of a matching set/clear OID](#step-7-configure-a-rule-in-case-of-a-matching-setclear-oid)

## Step 1: Deploy the Smart Trap Processor Training package from the Catalog

1. Go to the [Smart Trap Processor Training](https://catalog.dataminer.services/details/24f3c73d-2926-48a4-9486-cc34ddfca901) package in the Catalog.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. In DataMiner Cube, check whether the following items have been added to your DataMiner Agent:

   - A **view** named *Smart Trap Processor*.
   - An **element** named *Smart Trap Processor*.
   - An **element** named *Trap Simulator*.

   ![Surveyor view](~/dataminer/images/TrapProcessor_SurveyorView.png)

1. Browse to the [landing page of your DMA](xref:Accessing_the_web_apps), and check if the *Smart Trap Processor* app is available.

## Step 2: Configure the Trap IP Sources

Before the incoming traps can be processed as desired, you will need to configure a few parameters that will define what kinds of traps will be filtered.

1. Open the *Smart Trap Processor* app.

1. On the *Processor Configuration* page, set the *Trap IP Sources* parameter to local IP address `127.0.0.1`.

   This parameter needs to be set to the IP address corresponding with the source of the SNMP traps sent to the DataMiner System, which in the case of this demo setup is the system itself. In real setups, you can specify more than one IP address if needed, using a comma as separator.

![Smart Trap Processor IP Sources](~/dataminer/images/TrapProcessor_IPSources.png)

## Step 3: Configure the Rules Table

The rules defined in the *Rules Table* determine which traps from the source are processed to be displayed and monitored in the *Processed Traps* table and *Heartbeat Traps* table.

1. Below the *Rules Table*, click the **Add Rule** button.

   This will add a row to the table.

1. Configure the new row as follows:

   - Set the **Rule Status** to *Enabled*.
   - Set the **Rule Type** to *Regular*.
   - Leave **Heartbeat Interval** empty for now.
   - Set the **Priority** to `1`.
   - Set the **Event State Method** to *OID*.
   - Leave **Event State Binding**, **Binding Value Set**, and **Binding Value Clear** empty for now.
   - Set the **Raw OID Set** to `1.3.6.1.4.1.9.9.548.1.3.1.1.3`.
   - Set the **Raw OID Clear** to `1.3.6.1.4.1.9.9.548.1.3.1.1.4`.
   - Set the **Unique Entry** to `$1/$2/$8`.
   - Set the **Alarm Set** to `$9`.
   - Set the **Alarm Clear** to `$9`.
   - Leave **Clear After** empty.
   - Set the **Severity** to `$7`.
   - Set **Binding 1 Filter** to `Source 1`, and leave the other fields empty.

1. In the *Duplicate* column, click the button to duplicate the row.

1. Change the **Rule Type** of the new row to *Heartbeat*, set the **Heartbeat Interval** to *10 minutes*, and change **Binding 1 Filter** to `*Heartbeat`.

![Trap Processor Rules Table](~/dataminer/images/TrapProcessor_RulesTable.png)

> [!TIP]
> For more information about the parameters in this table, see [Configuring processing rules](xref:Processor_configuration)

## Step 4: Configure the Source Name Table

In this step, you will configure the names that will be used for the *Source Name* parameter in the *Processed Traps* table. This is optional.

1. Below the *Source Name Table*, click the **Add Source Name** button.

   This will add a row to the table.

1. Configure the new row as follows:

   - Set the **Priority** to `1`.
   - Set the **IP Address** to `127.0.0.1`.
   - Set the **Source Name** to `$1`.
   - Leave the **Binding 1-20 Filters** empty.

![Trap Processor Source Name Table](~/dataminer/images/TrapProcessor_SourceNameTable.png)

## Step 5: Configure the Source IP Name Table

In this step, you will configure the values that will be used for the *Source IP Name* parameter in the *Processed Traps* table. This is optional.

1. Below the *Source IP Name Table*, click the **Add Source IP Name** button.

   This will add a row to the table.

1. Configure the new row as follows:

   - Set the **IP Address** to `127.0.0.1`.
   - Set the **Source IP Name** to `Trap Test`.

![Trap Processor Source IP Name Table](~/dataminer/images/TrapProcessor_SourceIPNameTable.png)

## Step 6: Send traps via the trap simulator

1. In DataMiner Cube, go to the *Trap Simulator* element.

   On the element card, you will see 8 different traps that have been pre-configured for the purpose of this tutorial.

   ![Trap Processor Simulator](~/dataminer/images/TrapProcessor_Simulator.png)

1. In the first row, click **Send Trap**.

   This will send a trap with the matching configuration you have created in the *Rules Table*, allowing it to land in the *Processed Messages Table*. The trap will also match the trap OID you set for *Raw OID Set*, so it will get the event state *Active*.

1. In the *Smart Trap Processor* app, go to the *Processed Traps* page and check the *Processed Traps* table.

   You will see that the *Alarm*, *Source IP*, *Source IP Name*, *Source Name*, and *Unique Entry* parameters all match the settings you configured earlier.

1. Back in the *Trap Simulator* element in DataMiner Cube, click the *Send Trap* button in the **second** row.

   This will send a trap with the trap OID you configured for *RAW OID Clear*, so it will update the same row and classify the trap as *Cleared*.

1. In the *Smart Trap Processor* app, check the *Processed Traps* table again.

   You will see that the *Event State* is now *Cleared* and that the *Trap Count* has increased for this specific row.

1. Back in the *Trap Simulator* element in DataMiner Cube, click the *Send Trap* button in the **third** row.

   Binding 1 for this trap contains "Heartbeat", so as you configured the heartbeat traps to match Binding 1 with `*Heartbeat`, this trap will be added in the *Heartbeat Traps Table*.

1. In the *Smart Trap Processor* app, check the *Heartbeat Traps* table.

   This table shows the *Time Since Last Heartbeat*, which is the time since the last heartbeat trap was received, the *Heartbeat Interval*, which you defined in the *Heartbeat* row of the *Rules Table*, and the *Heartbeat Status*. If the *Time Since Last Heartbeat* is less than or equal to the *Heartbeat Interval*, the *Heartbeat Status* is *OK*; otherwise, it is *FAIL*.

1. Back in the *Trap Simulator* element in DataMiner Cube, click the *Send Trap* button in the **fifth** row.

   Notice that Binding 1 for this trap is *Source 2*, and you configured *Binding 1 Filter* in the *Rules Table* to filter only *Source 1*. As a consequence, this trap will not be shown in the *Processed Traps* table.

1. On the *Processor Configuration* page in the *Smart Trap Processor* app, change the **Binding 1 Filter** in the first row to `Source*`.

1. Click *Send Trap* in the **fifth** row of the *Trap Simulator* element again.

1. In the *Smart Trap Processor* app, check the *Processed Traps* table again.

   You will see that now a new row is added to the table for the trap you have just sent.

## Step 7: Configure a rule in case of a matching set/clear OID

Traps come in different formats. Instead of the trap OID specifying if a trap is a set or a clear event, a trap may have the same trap OIDs for set and clear events but specify these with a binding instead. In this step, you will change the rule configuration to take this into account.

1. In DataMiner Cube, go to the *Processed Messages* page of the *Smart Trap Processor* element and click the **Clear** button to clear the table.

   This will clear all processed traps from the *Processed Traps* table in the *Smart Trap Processor* app.

1. In the *Smart Trap Processor* app, go back to the *Rules Table* and modify the first row as follows:

   1. Switch the **Event State Method** to *Binding*.

   1. Set the **Event State Binding** value to `$10`, corresponding to Binding 10.

   1. Set **Binding Value Set** to `Set`.

   1. Set **Event Value Clear** to `Clear`.

   1. Change **Raw OID Set** and **Raw OID Clear** to `1.3.6.1.4.1.9.9.548.1.3.1.1.5`.

1. Back in the *Trap Simulator* element in DataMiner Cube, take a look at the last two rows.

   You will see that these have the same trap OID, but Binding 10 contains the set and clear values.

1. In the **seventh** row, click *Send Trap*.

1. Go to the app and take a look at the *Processed Messages Table* to confirm if the trap has been processed.

   ![Trap Processor Processed Messages](~/dataminer/images/TrapProcessor_ProcessMessages.png)

1. In the *Trap Simulator* element in DataMiner Cube, click *Send Trap* in the **eighth** row.

1. Go to the app and take a look at the *Processed Messages Table*.

   You will notice that the same row has now been updated to *Cleared*.
