---
uid: IDP_Tutorial_TakeConfigurationBackup
keywords: idp tutorial, idp kata, idp configuration backup
---

# Getting started with configuration backups

This tutorial will show how you can use IDP to retrieve and store device configurations.

Expected duration: 20 minutes.

> [!NOTE]
> The content and screenshots for this tutorial were created using DataMiner version 10.4.3 and IDP version 1.5.0.

> [!TIP]
> See also: [Kata #26: Set up IDP to back up your device configuration](https://community.dataminer.services/courses/kata-26/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- The DataMiner System used for this tutorial has to meet the following requirements:

  - The DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

  - The DataMiner version is 10.3.0 [CU0] or higher.

  - The latest version of IDP is installed.

    > [!TIP]
    > See [Installing DataMiner IDP](xref:Installing_DataMiner_IDP)

- A shared folder must be accessible from the system to store the backups.

> [!IMPORTANT]
> Do not use a DaaS system to follow this tutorial. On DaaS systems, it is not possible to configure a shared folder or access a shared folder outside the DaaS system.

## Overview

- [Step 1: Create the CI Type](#step-1-create-the-ci-type)
- [Step 2: Create an element and manage it](#step-2-create-an-element-and-manage-it)
- [Step 3: Set up the configuration archive](#step-3-set-up-the-configuration-archive)
- [Step 4: Create the script to retrieve the configuration backup](#step-4-create-the-script-to-retrieve-the-configuration-backup)
- [Step 5: Retrieve the device configuration](#step-5-retrieve-the-device-configuration)

## Step 1: Create the CI Type

First, a [CI Type](xref:CI_Types) needs to be created for IDP to know how to manage the element or device.

Instead of creating the CI Type from scratch, you will generate it based on an existing connector. In this example, the [Generic Switch](https://catalog.dataminer.services/details/ae750d4e-50b1-489d-b948-1abe1af591dd) connector is used, but you can use any other connector.

1. Deploy the connector to start from:

   1. Deploy the latest version of the [Generic Switch](https://catalog.dataminer.services/details/ae750d4e-50b1-489d-b948-1abe1af591dd) connector from the Catalog.

      > [!TIP]
      > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

   1. Make sure the latest version is [set as production](xref:Promoting_a_protocol_version_to_production_version).

      ![Generic Switch connector](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_ProtocolTemplates.png)

1. Generate the CI Type:

   1. Open the IDP app.

   1. Go to *Admin* > *CI Types*.

   1. Above the table on the right, click *Generate* to start the wizard.

      ![Start to generate the CI Type script](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_GenerateCiType_0.png)

   1. In the wizard, select the connector and click *Generate*.

      ![Select the connector](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_GenerateCiType_1.png)

   1. Click *Finish* to close the wizard.

   1. Switch off the *Show All* button in the top-right corner to locate the generated CI Type more easily.

      ![Generate the CI Type](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_GenerateCiType_2.png)

## Step 2: Create an element and manage it

1. [Create an element](xref:Adding_elements) that uses the connector you deployed in the previous step.

   You can enter any IP address in the *IP address/host* field, for example `127.0.0.1`.

1. In the IDP app, go to *Inventory* > *Unmanaged*.

1. Click *Refresh* to refresh the table.

   > [!NOTE]
   > Make sure *Detected CI Type* contains the generated CI Type. If it does not, confirm that the element was created with the production version.

1. Select the recently created element, and click *Manage*.

   ![Unmanaged element](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_UnmanageElement.png)

1. Go to *Inventory* > *Managed* to confirm the element is now managed by IDP.

   ![Managed element](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_ManageElement.png)

## Step 3: Set up the configuration archive

For IDP to store the configurations, it needs to access a local folder or a shared folder.

1. In the *DataMiner IDP* app, go to *Admin* > *Configuration*.

1. Under *DataMiner Configuration Archive*, specify the settings to access the local or shared folder.

   - Click the triangle button in the top right corner to specify a value for each setting.

   - Specify the credentials for a user account that has access to the specified path.

   ![Setup configuration archive credentials](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_ConfigurationArchiveSetup.png)

1. Click *Connect*.

At this point, you have already generated the CI Type, created an element and added it to the managed elements, and configured IDP to access the archive. In the next step, you will create the script that will retrieve the configuration and send it to IDP.

## Step 4: Create the script to retrieve the configuration backup

When IDP is installed it comes with an example script on how to retrieve the configuration and send it to IDP. You will now need to duplicate this script and change it to retrieve the parameter values from the element created in [step 2](#step-2-create-an-element-and-manage-it).

1. Duplicate the example configuration backup script:

   1. Go to the Automation module.

   1. Expand the folders until you reach *DataMiner Solutions* > *IDP* > *CI Type Management* > *Configuration Management* > *Backup*.

   1. Within this folder, duplicate the *IDP_Example_Custom_ConfigurationBackup* script, and rename it.

      ![Duplicated script](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_DuplicateScript.png)

1. Update the script to retrieve the parameter values from the element you created earlier:

   1. Open the script.

   1. Go to the *GetDeviceFullBackupAsText* function.

   1. Change the function to retrieve the values from parameters 502 (*System Contact*) and 504 (*System Location*).

      ```csharp
      private static string GetDeviceFullBackupAsText(IActionableElement element)
      {
          StringBuilder builder = new StringBuilder();

          builder.Append(Convert.ToString(element.GetParameter(502)));
          builder.Append("\n");
          builder.Append(Convert.ToString(element.GetParameter(504)));

          return builder.ToString();
      }
      ```

      > [!NOTE]
      > Note that the above-mentioned parameters 502 and 504 are parameters of the suggested connector. If you have chosen another connector, you should adapt these parameters accordingly.

   1. Go to the *CreateAndSendBackup* function.

   1. Change it to only include the *fullBackupData*.

      ```csharp
      private void CreateAndSendBackup(IEngine engine)
      {
          string fullBackupData = BackupDevice(engine, GetDeviceFullBackupAsText);
          backupManager.SendBackupContentToIdp(fullBackupData);
      }
      ```

   1. Click *Save script*.

1. Open the element you created in [step 2](#step-2-create-an-element-and-manage-it), and assign values to parameters 502 (*System Contact*) and 504 (*System Location*).

   ![Set parameter values](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_SetElementValue.png)

## Step 5: Retrieve the device configuration

1. Open the *DataMiner IDP* app.

1. Go to *Admin* > *CI Types* > *Configuration Management*.

1. Select the backup script.

   ![Select the backup script](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_SelectScript.png)

   > [!NOTE]
   > If you cannot see the script in the dropdown, go to *Admin* > *Settings* and click the refresh button for the *Backup Script Folder* setting.
   >
   > ![Refresh backup script folder](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_RefreshScripts.png)

1. Go to *Configuration* > *Summary*.

1. Select the element, and click *Backup*.

   ![Run the script](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_RunScript.png)

   This will open a wizard.

1. Select a type (e.g. *Running*), click *Next*, and then click *Finish*.

   ![Confirmation pop-up script](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_ConfirmationPopup.png)

   > [!TIP]
   > See also: [Configuration types](xref:ConfigurationBackupScript#configuration-types-running-startup-golden)

1. Select the element again, and click *Show backups*.

1. Select the recent backup, and click *Show content*.

   ![Backup content](~/dataminer/images/IDP_Tutorial_TakeConfigurationBackup_BackupContent.png)

Congratulations, you have saved your first device configuration with IDP.

> [!NOTE]
>
> - For more information, see [Implementing the Configuration Backup script](xref:ConfigurationBackupScript).
> - To be granted DevOps points, take a screenshot of the *Show content* result and either send it to [thunder@skyline.be](mailto:thunder@skyline.be) or upload it via the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/).
