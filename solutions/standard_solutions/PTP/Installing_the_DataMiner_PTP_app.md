---
uid: Installing_the_DataMiner_PTP_app
---

# Installing the DataMiner PTP app

## Deploying the package

To deploy or upgrade the DataMiner PTP app:

### [From DataMiner PTP 1.1.4 onwards](#tab/tabid-1)

Contact your Skyline representative to receive the PTP package. Skyline employees can get the [DataMiner PTP package](https://catalog.dataminer.services/details/9c5eb0a1-43bc-42d2-bca2-de4982ee57d7) from the Catalog.

When you have received the package, deploy it as described under [Installing an app package](xref:Installing_an_app_package).

### [Prior to DataMiner PTP 1.1.4](#tab/tabid-2)

In DataMiner Cube, go to *Apps* > *System Center* > *Agents* > *Manage*, and install the package in the same manner as a [DataMiner upgrade](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

> [!NOTE]
> DataMiner PTP should be installed on all DataMiner Agents in the DataMiner System.

***

## Setup and configuration

To set up and configure the DataMiner PTP app:

1. In DataMiner Cube, go to *Apps* > *Automation*.

1. Select the script *PTP_SetupWizard* and click *Execute*.

1. On the first page, click the button *Execute Now*.

1. In the first step of the wizard, specify a domain name if necessary. If there are already several PTP domains in your DMS, specifying a domain name is mandatory. Otherwise, you can select the checkbox *I don't want to configure a domain name* to set up the app without a domain name.

1. Click *Next*.

1. On the view selection page, specify the view that should be used by the DataMiner PTP app.

   Either select *Create a new view* or select *Use existing view* and select the view in the drop-down list, and click *Confirm*.

1. On the following page, which informs you that the wizard will now create the DataMiner PTP app, click *Confirm*. If necessary, you can also abort the wizard by clicking *Abort* in the bottom-right corner.

1. On the following page, which informs you that the wizard will now configure the DataMiner PTP app, click *Confirm*. If necessary, you can also abort the wizard by clicking *Abort* in the bottom-right corner.

1. On the following page, select the pages that the PTP app should display, and click *Next*.

   If, for example, your system does not include PTP analyzer, then do not select the *Analyzers* page.

1. On the following page, select the elements to include in the PTP topology, and click *Next*.

   - The list on the left shows the elements that have not (yet) been included.

     If necessary, this list can be filtered to show only the supported devices. If you add an unsupported device to the PTP topology, it will not be mediated. Manual configuration of that element (i.e. indicating which parameters are PTP-related) will then be required.

   - The list of the right shows the elements that have been included.

1. On the following page, assign a role to each of the PTP elements you selected in the previous step, and click *Next*.

   By default, all elements are assigned the “slave” role. Go through the entire list of elements using the *Next* and *Prev* buttons and, if necessary, change their role by selecting another checkbox.

1. On the following page, select at least one preferred grandmaster clock, and click *Next*.

1. On the following page, optionally indicate which slave devices should act as PTP analyzers, and click *Next*.

1. On the following page, select the device that will act as PTP probe, and click *Next*.

   The PTP probe will be in charge of identifying the current active grandmaster clock in the PTP topology.

1. On the last page of the wizard, check the overview, and click *Confirm*.

1. When the configuration has finished, which may take some time, click *Finish*, and on the next page, click *Close*.
