---
uid: Installing_PLM_tool
---

# Installing the PLM tool

## Prerequisites

- DataMiner version 10.3.6 or higher.

- DataMiner web apps version 10.3.6 or higher.

  > [!TIP]
  > See also: [Upgrading the DataMiner web apps](xref:Upgrading_Downgrading_Webapps)

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the PLM tool

1. Look up the [EPM PLM package](https://catalog.dataminer.services/details/package/5064) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   Once the package is installed, a new PLM element is automatically created, if your DataMiner System did not contain a PLM element already.

   The *EPM PLM* low-code app is accessible at `http(s)://[DMA name]/root`.

   ![EPL PLM app](~/user-guide/images/EPM_PLM_app.png)

> [!NOTE]
> To update the Planned Maintenance tool, redeploy the [*EPM PLM* package](https://catalog.dataminer.services/details/package/5064). While the tool will be updated, no new PLM element will be created, as one should already exist on your DMS.

## Configuring the EPM PLM element

1. In Cube, locate the *EPM PLM* element under the *EPM PLM* view.

   ![PLM_Element](~/user-guide/images/PLM_Element.png)

   > [!NOTE]
   > Optionally, you can rename the element and view, and change their location in the surveyor.

1. Click the *EPM PLM* element and navigate to *Data > Configuration*.

1. Adjust the following settings based on your preferences:

   - *PLM Polling Configuration > PLM Status*: Enables or disables PLM polling. Enabling this option allows the periodical updating of PLM activity statuses, according to the configured time span.

   - *PLM Polling Configuration > PLM Timer*: Allows you to set the interval at which PLM activities receive status updates in the overview (*Data > General*).

     > [!NOTE]
     > The maximum configurable interval is 30 days.

   - *PLM Polling Configuration > PLM Processing Status*: Allows you to manually trigger a status update for all PLM activities.

   - *PLM Overview Options > Auto Delete*: Enables or disables the automatic deletion of PLM activities. Enabling this option allows completed or expired PLM activities to be deleted automatically from the overview (*Data > PLM*).

   - *PLM Overview Options > Auto Delete Delay*: Allows you to configure the amount of time completed or expired PLM activities remain in the overview (*Data > PLM*) before they are automatically removed.

     > [!NOTE]
     > The maximum configurable delay is 365 days.

   - *PLM Records Options > Auto Delete*: Enables or disables the automatic deletion of PLM records. Enabling this option allows PLM records to be automatically deleted from the overview (*Data > PLM Records*).

   - *PLM Records Options > Auto Delete Delay*: Allows you to configure the amount of time PLM records remain in the overview (*Data > PLM Records*) before they are automatically removed.

     > [!NOTE]
     > The maximum configurable delay is 365 days.
