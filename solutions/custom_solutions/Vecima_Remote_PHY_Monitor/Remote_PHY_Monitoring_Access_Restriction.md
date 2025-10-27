---
uid: Remote_PHY_Monitoring_Access_Restriction
---

# Restricting access to Remote PHY Monitoring

To use the *R-PHY Analog & RF* low-code app, users need to have access to the DMS where this low-code app is located. If you want to ensure that these users do not have access to other information that they do not need, you can add a group-level restriction to the parameters that are not used in this low-code app.

1. Create a group for the users with restricted access:

   1. In the Users / Groups module in Cube, create a group with a security level of 5 or higher.

      > [!TIP]
      > See also: [Configuring a user group](xref:Configuring_a_set_of_user_group_settings)

   1. Assign the R-PHY Analog & RF users for which you want to restrict access to the newly created group.

1. For each [protocol used in the Remote PHY Monitoring Solution](xref:Remote_PHY_Monitoring_components), change the level attribute for the parameters these users should not have access to:

   1. In the Protocols & Templates module in Cube, right-click the Production version of the protocol for which you want to restrict access, and click *Open*:

      > [!TIP]
      > See also: [Making changes to a protocol.xml file](xref:Advanced_protocol_functionality#making-changes-to-a-protocolxml-file)

   1. Search for **level="5"**.

      > [!TIP]
      > See also: [level attribute](xref:Protocol.Params.Param-level)

   1. Change the level to a lower number than 5.

      The users with security level 5 or higher will no longer be able to access this parameter.

   1. When you have done this for all parameters for which you want to restrict access, click *OK*.

> [!NOTE]
> You can also limit which users or user groups have access to the low-code app itself. See [Configuring app security](xref:LowCodeApps_security_config).
