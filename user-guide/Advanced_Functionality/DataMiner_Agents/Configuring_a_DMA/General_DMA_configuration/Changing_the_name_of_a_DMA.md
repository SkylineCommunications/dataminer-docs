---
uid: Changing_the_name_of_a_DMA
---

# Changing the name of a DMA

By default, a DataMiner Agent always takes the name of its host server. However, it is possible to configure a custom name.

## Setting the DMA name in Cube

To set a custom DMA name in Cube:

1. Go to *Apps* > *System Center*.

1. In System Center, select the *Agents* page.

1. In the *Manage* tab, select the DMA of which you wish to set the name.

1. Fill in the new name in the *Name* field and click *Apply*.

1. In case you also want to change the hostname of the server, in the confirmation box, select the checkbox next to the name, and then click *Apply*. Keep in mind that if you do so, a server reboot will be required.

   If you only want to change the alias used in DataMiner instead of changing the actual server name, simply click *Apply* without selecting the checkbox.

## Setting the DMA name in DataMiner.xml

Though it is advisable to change a DMA name in Cube, it is also possible to set the DMA name directly in the file *C:\\Skyline DataMiner\\DataMiner.xml*.

To do so:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

1. In the *\<DMAName>* start tag, add a *mode* attribute, and set its value to “manual”.

1. Between the *\<DMAName>* start tag and the *\</DMAName>* end tag, specify the name of the DataMiner Agent. For example:

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
