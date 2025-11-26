---
uid: Time-based_license
---

# Time-based license

For a time-based license for a DataMiner Agent, the following procedure applies:

1. Wait until you receive a DMA ID from Skyline.

1. Install the DataMiner software.

1. Start the DataMiner Agent.

   At this point, startup will fail.

1. Email a copy of the file *request.lic*, located in the folder `C:\Skyline DataMiner\`, to <dataminer.licensing@skyline.be>.

1. Wait until you receive a file called *response.lic* from Skyline.

1. Copy the file *response.lic* to the folder `C:\Skyline DataMiner\`.

1. Start the DataMiner Agent.

> [!NOTE]
> DataMiner periodically checks the license. This means that if you replace the *response.lic* file with a new version at a later date, it is not necessary to restart the DataMiner Agent for the new license to get applied. This also means that if the license expires and the license check fails, the DataMiner Agent will automatically shut down.
