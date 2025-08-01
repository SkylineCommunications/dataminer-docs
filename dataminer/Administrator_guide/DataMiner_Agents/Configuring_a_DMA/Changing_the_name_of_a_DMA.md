---
uid: Changing_the_name_of_a_DMA
---

# Changing the name of a DMA

By default, a DataMiner Agent always takes the name of its host server. However, it is possible to configure a custom name or alias in *DataMiner.xml*.

If an alias has been configured in *DataMiner.xml*, changing the DMA name in Cube will change that alias. Otherwise, changing the DMA name in Cube will change the actual server name, which will require a reboot (which can be triggered in Cube).

## Configuring an alias in DataMiner.xml

To configure an alias in *DataMiner.xml*, you will need to activate "manual" mode and specify the custom name for the DMA:

1. Stop the DataMiner software.

1. Open the file `C:\Skyline Dataminer\DataMiner.xml`.

1. In the [DMAName](xref:DataMiner.DMA.DMAName) opening tag, add a *mode* attribute, and set its value to “manual”.

1. In the `<DMAName>` element, specify the custom name of the DataMiner Agent. For example:

   ```xml
   <DataMiner ...>
     <DMA>
       <DMAName mode="manual">MyCustomName</DMAName>
       ...
     </DMA>
   </DataMiner>
   ```

1. Save the file.

1. Restart the DataMiner software.

## Setting the DMA name in Cube

To set the DMA name in Cube:

1. Go to *Apps* > *System Center*.

1. In System Center, select the *Agents* page.

1. In the *Manage* tab, select the DMA of which you wish to set the name.

1. Fill in the new name in the *Name* field and click *Apply*.

   > [!NOTE]
   > Depending on whether [an alias is configured in DataMiner.xml](#configuring-an-alias-in-dataminerxml), a reboot may be required after this step. If no alias is configured, changing the name via Cube will update the server name, which requires a reboot. You can trigger a reboot via the checkbox in the confirmation dialog.
