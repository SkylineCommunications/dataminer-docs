---
uid: Installing_the_DataMiner_PTP_app
description: Deploy the PTP package from the DataMiner Catalog, set up the app, and configure all necessary settings.
---

# Installing the PTP app

## Prerequisites

Before deploying the PTP package:

1. Ensure that the devices you plan to monitor are already created and configured as elements in DataMiner. Note that configuring alarm templates for these elements is the responsibility of the user, as the PTP solution does not manage or deploy alarm templates automatically.
1. Verify that your devices are supported by the solution. For the definitive list of supported vendor connectors, see [Skyline PTP Technical](https://docs.dataminer.services/connector/doc/Skyline_PTP_Technical.html).
1. Make sure you have at least one **Grandmaster** clock and one additional device configured to act as the **PTP probe** before the solution can be functional.

## Deploying the package

To deploy or upgrade the PTP app:

### [From DataMiner PTP 1.1.4 onwards](#tab/deploy-1-1-4)

Deploy the [PTP package](https://catalog.dataminer.services/details/9c5eb0a1-43bc-42d2-bca2-de4982ee57d7) from the Catalog.

### [Prior to DataMiner PTP 1.1.4](#tab/deploy-legacy)

In DataMiner Cube, go to *Apps* > *System Center* > *Agents* > *Manage*, and install the package in the same manner as a [DataMiner upgrade](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

> [!NOTE]
> DataMiner PTP should be installed on all DataMiner Agents in the DataMiner System.

***

## Setup and configuration

To set up and configure the DataMiner PTP app:

### [From DataMiner PTP 2.0.0 onwards](#tab/setup-2-0)

From version 2.0.0 onwards, all initial setup is performed directly within the PTP custom web application through built-in configuration wizards, without requiring the manual execution of Automation scripts.

To complete the first-time setup:

1. In a web browser, navigate to `/public/ptp/` on your DataMiner System.

   Because no domains exist yet, an onboarding overlay will be displayed prompting you to set up your first PTP domain.

1. Specify a name for the PTP domain and select the corresponding DataMiner view. This view is used to place the domain element and service. Users who need to access the PTP Monitor web application must have read permissions for this view and its elements.

1. Select the elements to include in the domain. Only elements that are supported by the PTP solution will be displayed.

1. Assign a role to each device (*Grandmaster*, *Boundary Clock*, *Transparent Clock*, or *Follower Clock*). A default role is automatically preselected based on the connector of the element.

1. Select at least one preferred grandmaster clock.

1. Select the device that will act as the PTP probe.

   The PTP probe will identify the active grandmaster in the network.

Once the initial setup is finished, the in-connector mediation layer in the *Skyline PTP* connector will immediately begin processing data for the configured devices.

> [!NOTE]
> To add additional PTP domains, manage existing domains, or adjust device roles at any time, use the *Admin* page in the app.

### [Prior to DataMiner PTP 2.0.0](#tab/setup-legacy)

1. In DataMiner Cube, go to *Apps* > *Automation*.

1. Select the script *PTP_SetupWizard* and click *Execute*.

1. On the first page, click the button *Execute Now*.

1. In the first step of the wizard, specify a domain name if necessary. If there are already several PTP domains in your DMS, specifying a domain name is mandatory. Otherwise, you can select the checkbox *I don't want to configure a domain name* to set up the app without a domain name.

1. Click *Next*.

1. On the view selection page, specify the view that should be used by the DataMiner PTP app.

   Either select *Create a new view* or select *Use existing view* and select the view in the dropdown list, and click *Confirm*.

1. On the following page, which informs you that the wizard will now create the DataMiner PTP app, click *Confirm*. If necessary, you can also abort the wizard by clicking *Abort* in the lower-right corner.

1. On the following page, which informs you that the wizard will now configure the DataMiner PTP app, click *Confirm*. If necessary, you can also abort the wizard by clicking *Abort* in the lower-right corner.

1. On the following page, select the pages that the PTP app should display, and click *Next*.

   If, for example, your system does not include a PTP analyzer, then do not select the *Analyzers* page.

1. On the following page, select the elements to include in the PTP topology, and click *Next*.

   - The list on the left shows the elements that have not (yet) been included.

     If necessary, this list can be filtered to show only the supported devices. If you add an unsupported device to the PTP topology, it will not be mediated. Manual configuration of that element (i.e., indicating which parameters are PTP-related) will then be required.

   - The list of the right shows the elements that have been included.

1. On the following page, assign a role to each of the PTP elements you selected in the previous step, and click *Next*.

   By default, all elements are assigned the follower role (labeled "slave" in earlier versions). Go through the entire list of elements using the *Next* and *Prev* buttons and, if necessary, change their role by selecting another checkbox.

1. On the following page, select at least one preferred grandmaster clock, and click *Next*.

1. On the following page, optionally indicate which follower devices should act as PTP analyzers, and click *Next*.

1. On the following page, select the device that will act as PTP probe, and click *Next*.

   The PTP probe will be in charge of identifying the current active grandmaster clock in the PTP topology.

1. On the last page of the wizard, check the overview, and click *Confirm*.

1. When the configuration has finished, which may take some time, click *Finish*, and on the next page, click *Close*.

***
