---
uid: Installing_Smart_Trap_Processor
---

# Installing the Smart Trap Processor tool

## Prerequisites

- DataMiner web apps 10.4.1 or higher.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the Smart Trap Processor tool

1. Look up the [*Smart Trap Processor* package](https://catalog.dataminer.services/details/0c70b4b6-f687-459f-8cc9-bd1c9025dd50) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   If this is the first time you install the tool, a new view and element named "Smart Trap Processor" will automatically be created when the package is installed. Optionally, you can rename the element and view, and you can change their location in the Surveyor.

   Once the package has been installed, you can access the *Smart Trap Processor* low-code app at `http(s)://[DMA name]/root`.

   ![Smart Trap Processor app](~/dataminer/images/TrapProcessor_Access.png)

> [!NOTE]
>
> - To **update** the Smart Trap Processor tool, redeploy the [*Smart Trap Processor* package](https://catalog.dataminer.services/details/0c70b4b6-f687-459f-8cc9-bd1c9025dd50). The tool will be updated, but no new Trap Processor element will be created, as one should already exist in your DMS.
> - When you install the tool, default alarm and trend templates are applied to enable alarm monitoring and trending on the *Event State* and *Heartbeat Status* parameters. You can customize these templates, for example if more complex alarm thresholds are required beyond the defaults. See [About the alarm template editor](xref:About_the_alarm_template_editor).
