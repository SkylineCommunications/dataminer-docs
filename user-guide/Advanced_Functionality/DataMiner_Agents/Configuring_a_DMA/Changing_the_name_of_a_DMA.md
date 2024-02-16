---
uid: Changing_the_name_of_a_DMA
---

# Changing the name of a DMA

By default, a DataMiner Agent always takes the name of its host server. However, it is possible to configure a custom name or alias. This can be done via its 'mode'.

## Default mode: Agent Name is linked with Server Name

Changing the name via Cube will change the actual server name and will require a reboot (which can be triggered in Cube).

## Manual mode: Agent Name is used as an Alias and is not linked with Server Name

Changing the name via Cube will only change the display name of the Agent and does not require a reboot.

To configure 'Manual' mode:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

1. In the *\<DMAName>* start tag, add a *mode* attribute, and set its value to “manual”.

1. Between the *\<DMAName>* start tag and the *\</DMAName>* end tag, specify the custom name of the DataMiner Agent. For example:

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

1. Optionally you can trigger a reboot of the Agents via the checkbox in the confirmation popup

> [!NOTE]
> Depending on the configured mode, changing the name via Cube will update the server name as well and will require a reboot.
