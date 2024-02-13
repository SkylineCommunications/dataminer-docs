---
uid: Cloud_Connection_Issues
---

# Investigating dataminer.services connection issues

This page provides solutions for potential connectivity problems with [dataminer.services](xref:AboutCloudPlatform).

## Remote access issues

If you encounter issues with dataminer.services features that may be caused by connection issues, follow the actions below in the specified order:

1. [Check the status of the DxMs](#check-the-status-of-the-dxms).
1. [Check the status of the DMS](#check-the-status-of-the-dms).
1. [Check the cloud session](#check-the-cloud-session)
1. [Make sure requirements are met](#make-sure-requirements-are-met)

### Check the status of the DxMs

A common cause for issues with dataminer.services features is a problem with the connection from the [DxMs](xref:DataMinerExtensionModules) towards dataminer.services.

You can resolve this as follows:

1. Verify whether all installed [DxMs](xref:DataMinerExtensionModules) are running, otherwise start them.

1. Make sure the most recent versions of the DxMs are installed. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

   This way, you avoid dealing with issues that have already been fixed.

1. Verify the accessibility of the DMA host:

   1. In the `C:\Skyline DataMiner\` folder of the DMA, open the file *MaintenanceSettings.xml*.

   1. Look up the address specified in the *name* attribute of the *HTTPS* tag. For example:

       ```xml
       <MaintenanceSettings>
          ...
          <HTTPS enabled="true" name="foo.skyline.local"/>
          ...
       </MaintenanceSettings>
       ```

   1. Open a browser and navigate to this address.

      If the page loads correctly, this indicates that the DMA host is locally accessible, but there may be an issue with the [proxy](xref:Connect_to_cloud_via_proxy) or [DMZ](xref:Connect_to_cloud_with_DMZ) settings.

### Check the status of the DMS

Verify the status of the DMS and ensure that the system is operational, if not, start the DMS.

### Check the cloud session

In DataMiner Cube, go to *System Center* > *Cloud* and check if the cloud identity is still valid.

If it is no longer valid, [renew the cloud identity](#renewing-the-cloud-identity).

### Make sure requirements are met

If none of the previous steps solved the problem, make sure that all [requirements](xref:Accessing_DMS_remotely_with_Cube) for remote access are fulfilled.

If the issue still persists even though all requirements are met, contact [tech support](https://skyline.be/contact/tech-support).

## Renewing the cloud identity

Manually renewing the cloud identity can be necessary if dataminer.services could not renew its tokens automatically for too long. This can for example happen if no internet access was available for an extended period (usually minimum 3 days).

To renew the cloud identity of your DataMiner System:

1. In DataMiner Cube, go to *System Center* > *Cloud*.

1. Click the *Renew Session* button.

   > [!NOTE]
   > This button is only available if the cloud identity has expired. It is also only available for users who have the [*Owner* role](xref:Changing_the_role_of_a_DCP_user) in the DMS.
