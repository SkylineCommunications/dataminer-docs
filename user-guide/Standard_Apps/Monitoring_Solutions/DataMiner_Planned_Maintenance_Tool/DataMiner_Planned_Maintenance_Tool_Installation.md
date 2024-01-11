---
uid: DataMiner_Planned_Maintenance_Tool_Installation
---

# Installing the DataMiner Planned Maintenance Tool

## Solution Deployment

1. Make sure the following **prerequisites** are met:

   - DataMiner System uses DataMiner 10.3.6 or higher and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

   - DataMiner web apps are upgraded to DataMiner 10.3.6 or higher.

   - DataMiner system is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

     > [!TIP]
     > See also: [Upgrading the DataMiner web apps](xref:Upgrading_Downgrading_Webapps)

1. Deploy the *EPM PLM* package:

   - Go to <https://catalog.dataminer.services/details/package/5064>.

   - Click the *Deploy* button.

   - Select the target DataMiner System and confirm the deployment.

      - The package will be pushed to the DataMiner System and installed.

      - After the package installs, you will find that a new PLM element was automatically created in the case the DataMiner system did not already have a PLM element. 

## Element Configuration

1. Configure the *EPM PLM* element:

    - Open DataMiner Cube and locate the *EPM PLM* element that has been created under the *EPM PLM* View.

      - You are able to rename the element and view as well as change their location within the surveyor.

    -	Open the PLM element and navigate to the Configuration data page. 

      - Configure the following following settings to the desired preferences:
      
        1. **PLM Status**: Enable/Disable PLM Polling. Enabling PLM Status allows for PLM activies statuses to be updated periodically depending on the interval set on the PLM timer. 

        1. **PLM Timer**: The interval for how often PLM activies receive status updates on the PLM Overview table.

        3. **PLM Overview Options - Auto Delete**: Enable/Disable PLM activities to auto delete from the PLM Overview table.

        4. **PLM Overview Options - Auto Delete Delay**: The amount of time completed or expired PLM activities will remain in the PLM Overview table. All activities older than the set delay will be removed from the table.

        5. **PLM Records Options - Auto Delete**: Enable/Disable PLM records to auto delete from the Records table.

        6. **PLM Records Options - Auto Delete Delay**: The amount of time records wil remain in the PLM Records table. All records older than the set delay will be removed from the table. 

> [!NOTE]
> If you want to **update** an existing installation of the DataMiner Planned Maintenance Tool, you can do so by going to the [*EPM PLM* package](https://catalog.dataminer.services/details/package/5064) in the Catalog and deploying it again. A new element will not be automatically created due to an existing PLM element being present in the system.
