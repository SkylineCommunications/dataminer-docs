---
uid: Installing_PLM_tool
---

# Installing the PLM tool

## Prerequisites

- DataMiner version 10.3.6 or higher.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the PLM tool

1. Look up the [*DataMiner Planned Maintenance Tool* package](https://catalog.dataminer.services/details/88b1f821-bf68-4f4b-a244-6a547b087cd2) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   If your DataMiner System does not contain a PLM element yet, a new PLM element is automatically created when the package is installed.

   Once the package has been installed, you can access the *DataMiner Planned Maintenance Tool* low-code app at `http(s)://[DMA name]/root`.

   ![EPL PLM app](~/dataminer/images/EPM_PLM_app.png)

> [!NOTE]
> To update the Planned Maintenance tool, redeploy the [*DataMiner Planned Maintenance Tool* package](https://catalog.dataminer.services/details/88b1f821-bf68-4f4b-a244-6a547b087cd2). The tool will be updated, but no new PLM element will be created, as one should already exist in your DMS.

## Configuring the 'Planned Maintenance Tool' element

1. In Cube, locate the *Planned Maintenance Tool* element under the *DataMiner Planned Maintenance* view.

   ![PLM_Element](~/dataminer/images/PLM_Element.png)

   > [!NOTE]
   > Optionally, you can rename the element and view, and change their location in the surveyor.

1. Click the *Planned Maintenance Tool* element and navigate to *Data > Configuration*.

1. Adjust the following settings based on your preferences:

   - *PLM Polling Configuration > PLM Status*: Enables or disables PLM polling. Enabling this option allows the periodical updating of PLM activity statuses according to the configured time span.

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
