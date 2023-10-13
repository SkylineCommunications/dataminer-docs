---
uid: GetUsers
---

# GetUsers

Use this method to retrieve the users configured on a DMA.

## Input

| Item       | Format | Description                                                                      |
|------------|--------|----------------------------------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item           | Format           | Description                                         |
|----------------|------------------|-----------------------------------------------------|
| GetUsersResult | Array of [DMAUser](xref:DMAUser) | An array of DMAUser objects, consisting of the login name, full name, and email address of each user. |

> [!NOTE]
> Prior to DataMiner 10.3.9/10.4.0, only users with the user permission [Modules > System configuration > Security > UI available](xref:DataMiner_user_permissions#modules--system-configuration--security--ui-available) can view the list of DataMiner users. From DataMiner 10.3.9/10.4.0 onwards, users without this user permission will be able to view the list of DataMiner users who are a member of any of the groups they themselves are a member of.<!-- RN 36556 -->
