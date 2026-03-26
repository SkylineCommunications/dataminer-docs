---
uid: Uninstalling_Elasticsearch_from_a_DMA
---

# Uninstalling Elasticsearch from a DMA

If you have a setup with [storage per DMA](xref:Configuring_storage_per_DMA) and you have [installed Elasticsearch on a DMA via DataMiner](xref:Installing_Elasticsearch_via_DataMiner), you can uninstall it as detailed below.

> [!WARNING]
> This procedure requires expert knowledge, and it can have far-reaching consequences for your DataMiner System, including loss of data. Contact a Skyline DevOps Engineer if you are unsure about any of the steps.

1. Stop DataMiner.

1. Stop the Elasticsearch service. If the process does not stop properly, end the process.

1. Run *cmd.exe* as Administrator and enter the following command to delete the Elasticsearch service:

   ```txt
   sc delete elasticsearch-service-x64
   ```

1. Run *regedit* as Administrator and delete `HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\elasticsearch-service-x64`.

1. Delete the Elasticsearch data folder, e.g., `C:\ProgramData\Elasticsearch`. If you are unsure where to find the directory, look for path.data in the elasticsearch.yml file.

   > [!NOTE]
   > The *ProgramData* folder is not displayed by default, so you may need to select to display hidden items in order to access this folder.

1. Delete the folder `C:\Program Files\Elasticsearch`.

1. If any Elasticsearch firewall rule exists, delete it.

1. On the DataMiner Agent, remove the folder `C:\Skyline DataMiner\Tools\Elasticsearch`, if it exists.

1. On the DataMiner Agent, remove any packages that mention "Elastic" from the folder `C:\Skyline Dataminer\Upgrades\Packages`.

1. In the `C:\Skyline DataMiner` folder of the DataMiner Agent, open *DB.xml*.

1. In *DB.xml*, remove the database tag referring to the indexing database. For more information, see [Indexing database settings](xref:DB_xml#indexing-database-settings).

1. Restart DataMiner.
