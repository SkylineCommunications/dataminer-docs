---
uid: Changing_the_DMA_ID
description: "On a new DMA, change the DataMiner ID in DataMiner.xml, then restart DataMiner to apply the new ID safely."
---

# Changing the DataMiner ID of a DMA

> [!WARNING]
> Changing the DataMiner ID in *DataMiner.xml* is only allowed on new DMAs that have not yet been put into use.

In the *DataMiner.xml* file of a DMA, you can change its DataMiner ID.

To do so:

1. Stop the DataMiner software.

1. Open the file `C:\Skyline Dataminer\DataMiner.xml`.

1. In the [id](xref:DataMiner-id) attribute of the `<DataMiner>` tag, specify the new DataMiner ID of the DMA.

1. Save the file.

1. Restart the DataMiner software.

For example, in the tag below, the DataMiner ID has been set to 7:

```xml
<DataMiner id="7">...</DataMiner>
```
