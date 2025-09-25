---
uid: KI_gRPC_connected_Cube_stuck_when_using_Automation
---

# gRPC-connected Cube not responding when Automation module is used

## Affected versions

- Main Release versions from DataMiner 10.4.0 [CU16] to [CU18] and 10.5.0 [CU4] to [CU6]. In earlier Main Release versions, starting from DataMiner 10.3.0, the issue can also occur, but only if a recent version of Cube is used (i.e. 10.5.2521.130 or higher).
- Feature Release versions from DataMiner 10.3.2 to 10.5.5, but only if a recent version of Cube is used (i.e. 10.5.2521.130 or higher).

## Cause

When Automation scripts are opened, it can occur that Cube sends a message to the server that is not supported, resulting in deserialization exceptions in SLNet. If gRPC is used, these exceptions are not handled correctly, resulting in the client waiting for a response that will never arrive, until the timeout time of 15 minutes has elapsed.

## Workaround

If you are using a DataMiner version where this issue only occurs depending on the Cube version used, a workaround is to force Cube to use the version that was shipped with the server upgrade package (see [Managing client versions](xref:DMA_configuration_related_to_client_applications#managing-client-versions)). However, this workaround will not work for Main Release versions 10.4.0 [CU16] to [CU18] and 10.5.0 [CU4] to [CU6].

An alternative workaround for this issue is adjusting the configuration in [ConnectionSettings.txt](xref:ConnectionSettings_txt) so the system will use .NET Remoting instead of gRPC for client connections. However, as .NET Remoting is less secure, we do not recommend this.

## Fix

No fix is available yet. <!--RN 43756-->

## Description

When scripts are opened in the Automation module in DataMiner Cube, after a short time, the user interface stops responding.

To check whether you are using a recent version of Cube that may cause you to run into this issue (i.e. 10.5.2521.130 or higher), open the user menu, select *About*, and then check the *versions* tab.

To check whether the Cube connection uses gRPC, open the user menu, select *About*, and then check the *connection* tab. If the *Attributes* line contains the *GrpcConnection* item, the connection uses gRPC.
