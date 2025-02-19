---
uid: Installing_Starlink_Enterprise
---

# Installing the Starlink Enterprise APP

## Prerequisites

- DataMiner web apps 10.4.1 or higher.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the Smart Trap Processor tool

1. Look up the [*Starlink Enterprise* package](https://catalog.dataminer.services/details/package/5755) in the DataMiner Catalog.  [TODO update link!!!]

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   If this is the first time you install the tool, a new view and element named "Smart Trap Processor" will automatically be created when the package is installed. Optionally, you can rename the element and view, and you can change their location in the Surveyor.   [TODO update text!!!]

   Once the package has been installed, you can access the *Starlink Enterprise* low-code app at `http(s)://[DMA name]/root`.

   ![Starlink Enterprise app](~/user-guide/images/StarlinkEnterprise_Access.png) [TODO add image!!]

> [!NOTE]
>
> - To **update** the Smart Trap Processor tool, redeploy the [*Smart Trap Processor* package](https://catalog.dataminer.services/details/package/5755). The tool will be updated, but no new Trap Processor element will be created, as one should already exist in your DMS.
> - When you install the tool, default alarm and trend templates are applied to enable alarm monitoring and trending on the *Event State* and *Heartbeat Status* parameters. You can customize these templates, for example if more complex alarm thresholds are required beyond the defaults. See [About the alarm template editor](xref:About_the_alarm_template_editor).
