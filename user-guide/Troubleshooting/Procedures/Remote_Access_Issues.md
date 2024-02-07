---
uid: Remote_Access_Issues
---

# Remote Access Issues
Follow the guide below when you're encountering connections issues with dataminer.services features and your DataMiner System.

## Check Status of DxMs
A common cause for issues with [dataminer.services](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/About_the_Cloud_Platform.html?q=dataminer.services) features and your DMS is due to the connection from the [CloudGateway](https://docs.dataminer.services/user-guide/Reference/DataMiner_Extension_Modules.html?q=dxm#cloudgateway) towards dataminer.services being unavailable. 
Resolve this by taking the following steps:
1. Verify whether the installed CloudGateway [DxMs](https://docs.dataminer.services/user-guide/Reference/DataMiner_Extension_Modules.html) are running, otherwise start them.
1. Make sure to have the most [recent versions](https://docs.dataminer.services/release-notes/Cloud/DCP_change_log.html) of the [DxMs](https://docs.dataminer.services/user-guide/Reference/DataMiner_Extension_Modules.html) installed to avoid dealing with issues that might have been fixed. 

## Check DMS Status
Verify the status of the DMS and ensure that the system is operational, if not, start the DMS. 

## Check Session
Verify in DataMiner Cube if the session is still available and not expired, otherwise renew the tokens.

## Undetermined Problem
When the previous solutions did not solve the problem, ensure that all [requirements](https://docs.dataminer.services/user-guide/Cloud_Platform/RemoteAccess/Accessing_DMS_remotely_with_Cube.html) for remote access are fulfilled. Please contact [support](https://skyline.be/contact/tech-support) if none of the above solved the problem.
