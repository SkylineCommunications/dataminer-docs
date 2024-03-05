---
uid: Remote_PHY_Monitoring_Access_Restriction
---

# Access Restriction

The user of the R-PHY analog & RF low-code app must have access to the DMS where the low-code application is located. 
If these users should not have access to unnecessary information, a group level restriction has been added to the parameters that are not being used in the R-PHY analog & RF low-code app.


## Group Level Restriction

To use the restrictions added you should create a group that will have fewer premissions than level 5 and assing all R-PHY Analog & RF users to that group.

> [!TIP]
> The lower the number of a user's security level, the more levels they can access.       
See also: [Configuring a user group](xref:Configuring_a_set_of_user_group_settings)


### Change level attribute 

To change the level attribute restriction:

1. Open Dataminer Cube
1. Go to Apps > Protocols & Templates 
1. Open the Production version of the drivers related to the package.
	> [!TIP]
	> Check: [Remote PHY Monitoring system connectors](xref:Remote_PHY_Monitoring_components)
1. Search for **level="5"**.
1. Change the level to the requested one.

> [!TIP]
> See also: [level attribute](xref:Protocol.Params.Param-level)

## Configure security for R-PHY Monitoring 

To configure which users or group of users can access the low code app please check [Configuring security for a low-code app](xref:LowCodeApps_security_config).
