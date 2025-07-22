---
uid: Re-registering_DataMiner_services_and_DLLs
---

# Re-registering DataMiner services and DLLs

In certain situations, DataMiner services may fail to start or function properly because they are not correctly registered within the operating system. This can occur, for example, after a Windows update. If this is the case, follow the steps below to recover DataMiner:

1. Go to the folder `C:\Skyline DataMiner\Tools`.

1. Run the following scripts as Administrator, in the specified order:

   - *DataMiner Stop DataMiner And SLNET.bat*

   - *UnRegister DataMiner.bat*

   - *UnRegister DLLs of DataMiner.bat*

   - *Register DLLs of DataMiner (silent).bat*

   - *Register DataMiner as Service.bat*

   - *DataMiner Restart DataMiner And SLNET.bat*
