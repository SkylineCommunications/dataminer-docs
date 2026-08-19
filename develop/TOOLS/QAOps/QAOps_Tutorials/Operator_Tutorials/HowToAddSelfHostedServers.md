---
uid: QAOps_Tutorials_Operator_Tutorials_How_To_Add_Self_Hosted_Servers
---

# Adding self-hosted DataMiner servers

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to create a **self-hosted** [QAOps configuration](xref:QAOps_Configuration) and connect your own DataMiner servers to it — either a single DataMiner Agent or a DataMiner cluster — using the *Configure Self-Hosted DataMiners* wizard.

Use a self-hosted configuration when your tests must run on hardware or a DataMiner setup that QAOps cannot provision as DaaS, for example a lab machine with specific interfaces, a long-lived staging system, or a cluster.

Expected duration: 20 minutes.

## Prerequisites

- Operator access to the [QAOps Operator app](xref:QAOps_Main_UI#qaops-operator-app) (the blue app).

- At least one existing [test suite](xref:QAOps_Test_Suite).

- Access to the DataMiner server(s) you want to connect, so you can install the generated installer package on them.

## Overview

- [Step 1: Create a self-hosted configuration](#step-1-create-a-self-hosted-configuration)

- [Step 2: Get to know the Configure Self-Hosted DataMiners wizard](#step-2-get-to-know-the-configure-self-hosted-dataminers-wizard)

- [Step 3: Add a single DataMiner Agent](#step-3-add-a-single-dataminer-agent)

- [Step 4: Add a DataMiner cluster](#step-4-add-a-dataminer-cluster)

- [Step 5: Install the installer package on your server](#step-5-install-the-installer-package-on-your-server)

## Step 1: Create a self-hosted configuration

1. In the QAOps Operator app, go to the *Configurations* page.

1. Scroll to the bottom of the configuration card list and click the **⊕** button.

1. In the *Configuration Type* dropdown, keep the default **Self-hosted**.

1. Enter a **Name** and **Description**, select the allowed **Test Suites**, set **Test Runs To Keep**, and optionally select **Global Categories**, in the same way as for a QAOps-hosted configuration (see [Creating a QAOps configuration](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Create_A_Configuration)).

   Note that a self-hosted configuration has no provisioning section: QAOps does not deploy servers for it.

   ![Create dialog for a self-hosted configuration](~/develop/images/QAOps_Operator_CreateConfiguration_SelfHosted.png)

1. Click **Save Configuration** and check the *Status* box for confirmation.

   ![Saving the self-hosted configuration](~/develop/images/QAOps_Operator_CreateConfiguration_SelfHosted_Save.png)

   After the configuration is saved, the *Configure Self-Hosted DataMiners* wizard opens automatically.

## Step 2: Get to know the Configure Self-Hosted DataMiners wizard

![Configure Self-Hosted DataMiners wizard](~/develop/images/QAOps_Operator_ServerWizard_Single.png)

The wizard allows adding or updating servers:

- **Offline servers** (not yet connected to QAOps) can generate a `.dmapp` installer package that connects them to QAOps.

- **Online servers** that already run the QAOps Bridge DxM can be upgraded directly from the wizard.

At the top, the wizard shows the *QAOps Configuration ID* it belongs to and the *Latest known Bridge DxM version*.

With the *What are you adding?* dropdown, you choose the topology:

![What are you adding dropdown](~/develop/images/QAOps_Operator_ServerWizard_TypeDropdown.png)

- **Single DataMiner**: One standalone DataMiner Agent.

- **DataMiner Cluster**: Multiple DataMiner Agents that form one DataMiner System.

> [!TIP]
> You can reopen this wizard at any time for an existing self-hosted configuration by clicking the gear icon on the configuration card and saving, or via the server management button on the card.

## Step 3: Add a single DataMiner Agent

1. In the *What are you adding?* dropdown, select **Single DataMiner**.

   The wizard shows a server row with an automatically generated *Server ID*.

1. Enter a display name for the server in the *Server display name* box, and click **Update Name**.

   ![Wizard with server display name filled in](~/develop/images/QAOps_Operator_ServerWizard_Named.png)

1. Click **Create installer**.

   The status box shows *Packaging..* with a running timer while QAOps builds a `.dmapp` installer specific to this server.

   ![Wizard while packaging the installer](~/develop/images/QAOps_Operator_ServerWizard_Packaging.png)

1. Wait until the status shows **Finished**. The **Download installer** button then becomes active.

   ![Wizard with finished installer ready for download](~/develop/images/QAOps_Operator_ServerWizard_Finished.png)

1. Click **Download installer** to download the `.dmapp` package.

## Step 4: Add a DataMiner cluster

1. In the *What are you adding?* dropdown, select **DataMiner Cluster**.

   The wizard now shows a *DataMiner Cluster display name* row and one row per server in the cluster.

   ![Wizard in DataMiner Cluster mode](~/develop/images/QAOps_Operator_ServerWizard_Cluster.png)

1. Enter a display name for the cluster and click **Update Name** in the cluster row.

1. For each DataMiner Agent in the cluster, click the **+** button to add a server row.

   ![Cluster with two server rows](~/develop/images/QAOps_Operator_ServerWizard_Cluster_TwoServers.png)

1. For every server row: enter a display name, click **Update Name**, then click **Create installer** and wait for the status to show *Finished*.

1. Download the installer of each server with its **Download installer** button.

   Each installer is tied to its own *Server ID*, so make sure to install the right package on the right machine.

To remove a server from the cluster, click the **-** button in its row. To remove the whole cluster registration, click **Delete Complete Cluster Record**.

## Step 5: Install the installer package on your server

1. Copy the downloaded `.dmapp` file to the DataMiner server it was generated for.

1. Install it like any other DataMiner application package (for example with the DataMiner Application Package installer).

   The package installs the QAOps Bridge DxM preconfigured for your configuration, which connects the server to QAOps.

1. Back in the QAOps Operator app, select your configuration card on the *Configurations* page and verify in the *Servers* column that the server reports its status.

Once the server is online, test runs on this configuration will execute on your self-hosted DataMiner.

> [!NOTE]
> When a new Bridge DxM version becomes available, you can upgrade online servers directly from the wizard instead of generating a new installer.

## Next steps

- [Updating a configuration](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Update_A_Configuration)

- [Triggering a test run](xref:QAOps_Tutorials_User_Tutorials_Basic_How_To_Trigger_A_Test_Run)
