---
uid: Smart_Trap_Processor_Tutorial
---

# Getting started with the Smart Trap Processor

In this tutorial, you will learn how to get started with the Smart Trap Processor tool and define rules for collecting and processing SNMP traps from various sources.

Expected duration: 30 minutes.

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

1. Go to the [Smart Trap Processor Training](https://catalog.dataminer.services/details/24f3c73d-2926-48a4-9486-cc34ddfca901) package in the DataMiner Catalog.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. In DataMiner Cube, check whether the following items have been added to your DataMiner Agent:

   - A **view** named *Smart Trap Processor*.
   - An **element** named *Smart Trap Processor*.
   - An **element** named *Trap Simulator*.

   ![Surveyor view](~/user-guide/images/TrapProcessor_SurveyorView.png)

1. Browse to the [landing page of your DMA](xref:Accessing_custom_apps), and check if the *Smart Trap Processor* app is available.

## Step 2: Configure the Trap IP Sources

Before the incoming traps can be processed as desired, you will need to configure a few parameters that will define what kinds of traps will be filtered.

1. Open the *Smart Trap Processor* app.

1. On the *Processor Configuration* page, set the *Trap IP Sources* parameter to local IP address `127.0.0.1`.

   This parameter needs to be set to the IP address corresponding with the source of the SNMP traps sent to the DataMiner System, which in the case of this demo setup is the system itself. In real setups, you can specify more than one IP address if needed, using a comma as separator.

![Smart Trap Processor IP Sources](~/user-guide/images/TrapProcessor_IPSources.png)

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

1. Change the **Rule Type** of the new row to *Heartbeat*, set the **Heartbeat Interval** to *10 minutes*, and change **Binding 1 Filter** to **Heartbeat*.

![Trap Processor Rules Table](~/user-guide/images/TrapProcessor_RulesTable.png)

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

![Trap Processor Source Name Table](~/user-guide/images/TrapProcessor_SourceNameTable.png)

## Step 5: Configure the Source IP Name Table

In this step, you will configure the values that will be used for the *Source IP Name* parameter in the *Processed Traps* table. This is optional.

1. Below the *Source IP Name Table*, click the **Add Source IP Name** button.

   This will add a row to the table.

1. Configure the new row as follows:

   - Set the **IP Address** to `127.0.0.1`.
   - Set the **Source IP Name** to `Trap Test`.

![Trap Processor Source IP Name Table](~/user-guide/images/TrapProcessor_SourceIPNameTable.png)

## Step 6: Send traps via the Trap Simulator

![Trap Processor Simulator](~/user-guide/images/TrapProcessor_Simulator.png)

1. Go to the *Trap Simulator* element on cube. We see a total of 8 different traps that are pre-configured for the purpose of this tutorial.

1. On the first row, click **Send Trap**. This will send a trap with all the matching configurations we created on the *Rules Table*, allowing it to land on the *Processed Messages Table*. It also matches the Trap OID we set for **Raw OID Set**, so it will classify the trap as *Active* on the **Event State**. Go to the app and take a look at the *Processed Messages Table*. Notice the **Alarm**, **Source IP**, **Source IP Name**, **Source Name**, and the **Unique Entry** parameters we configured.

1. Go back to the *Trap Simulator* element on cube, on the second row, click **Send Trap**. This trap has the Trap OID we set for **RAW OID Clear**, so it will update the same row and classify the trap as *Cleared* on the **Event State**. Go to the app and take a look at the *Processed Messages Table*. Notice the **Trap Count** increase for this specific row.

1. Go back to the *Trap Simulator* element on cube, on the third row, click **Send Trap**. Notice the bindings on this trap are different. We configured our heartbeat traps to match Binding 1 with *Heartbeat, so this trap will populate on the *Heartbeat Traps Table*. Go back to the app and take a look at the *Heartbeat Traps Table*. On this table we have **Time Since Last Heartbeat** which displays the time since the last heartbeat trap was received, the **Heartbeat Interval**, which we defined on the heartbeat row on the Rules Table, and the **Heartbeat Status**, which is *OK* if the Time Since Last Heartbeat is less than or equal to the Heartbeat Interval, otherwise it’s *FAIL*.

1. Go back to the *Trap Simulator* element on cube, on the fifth row, click **Send Trap**. Notice that the Binding 1 for this trap is Source 2, and we configured **Binding 1 Filter** on the *Rules Table* to filter only *Source 1*. So this trap will not appear on the Processed Messages Table.

1. Edit **Binding 1 Filter** on the *Rules Table* to *Source**. And click **Send Trap** on the fifth row again from the *Trap Simulator* element. Notice how it now is able to populate the table with a new row for that trap.

## Step 7: Configure a rule in case of a matching set/clear OID

Traps come in different formats, instead of the Trap OID specifying if a trap is a set or a clear, a trap may have the same Trap OIDs for sets and clears but specify it on a binding instead.

![Trap Processor Processed Messages](~/user-guide/images/TrapProcessor_ProcessMessages.png)

1. Go to the *Process Messages Table* and click **clear** to clear the table.

1. Go back to the *Rules Table* and modify the **Event State Method** parameter of the Regular rule row to *Binding*.

1. Initialize the **Event State Binding** to *$10*, corresponding to Binding 10.

1. Initialize the **Event Value Set** to *Set*.

1. Initialize the **Event Value Clear** to *Clear*.

1. Change the **Raw OID Set** and the **Raw OID Clear** to *1.3.6.1.4.1.9.9.548.1.3.1.1.5*.

1. Go back to the *Trap Simulator* element on cube and notice the last two traps. They have the same Trap OID, but the value on Binding 10 corresponds to the set and clear.

1. On the seventh row, click **Send Trap**. Go to the app and take a look at the *Processed Messages Table* to confirm it has been processed.

1. Go back to the *Trap Simulator* element on cube, on the eighth row, click **Send Trap**. Go to the app and take a look at the *Processed Messages Table* to confirm the same row has been updated to clear.
