---
uid: Remote_Connecting_Issues
---

# Remote Connecting Issues
If you're encountering issues with remote connections, here are some common problems and potential solutions:

## Check CloudGateway Status
One of the common issues why the remote access is unavailable is due to the CloudGateway DxM not being up. In this way it is impossible to connect with the DataMiner Agent using remote instances. 
The following possible options may be the solution to the problem:
1. Verify whether CloudGateway DxM is running. If not, start it.
2. Restart the CloudGateway DxM to refresh its state.
3. Consider upgrading the CloudGateway DxM (and other DxMs in the Cloud Pack) to the latest version. Mostly an update can resolve connectivity issues.

## Check DMS Status
It could be that the DataMiner is offline or stopped.  It's recommended to verify the status of the DMS and ensure that the system is operational, if not, start the DMS. 
Additionally, confirm if the version of DataMiner System being used is compatible for remote connections. 

## Undetermined Problem
When the previous solutions did not solve the problem, please contact [support](https://skyline.be/contact/tech-support).
