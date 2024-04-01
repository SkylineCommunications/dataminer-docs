---
uid: IDP_Tutorial_TakeConfigurationBackup
keywords: idp tutorial, idp kata, idp configuration backup
---

# Getting started with configuration backup

This tutorial will show how you can use IDP to retrieve and store device configurations.

Expected duration: 20 minutes.

## Prerequisites

- DataMiner version is 10.3.0 [CU0] or higher.
- The latest version of [IDP](https://catalog.dataminer.services/details/package/3163) is installed.
- A shared folder is accessible from the system to store the backups.

> [!IMPORTANT]
> This tutorial can not be followed in a DaaS system, because is not possible to configure a shared folder, or access a shared folder outside the DaaS system.

## Overview

- [Step 1: Create CI Type](#step-1-create-ci-type)
- [Step 2: Create an element and manage it](#step-2-create-an-element-and-manage-it)
- [Step 3: Setup configuration archive](#step-3-setup-configuration-archive)
- [Step 4: Create the script to retrieve the configuration backup](#step-4-create-the-script-to-retrieve-the-configuration-backup)
- [Step 5: Retrieve the device configuration](#step-5-retrieve-the-device-configuration)

## Step 1: Create CI Type

First, a [CI Type](xref:CI_Types) needs to be created for IDP to know how to manage the element or device.

Instead of creating the CI Type from scratch, it will be generated based on an existing connector.

> [!NOTE]
> As an example, the [Generic Switch](https://catalog.dataminer.services/details/connector/931) connector will be used to generate the CI Type, but you can use any other connector.

### Deploy connector

1. Deploy the latest version of the [Generic Switch](https://catalog.dataminer.services/details/connector/931) connector
1. Make sure the version is set as production

    ![Generic Switch connector](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_ProtocolTemplates.png)

### Generate CI Type

1. Open the *DataMiner IDP* app
1. Navigate to *Admin* > *CI Types*
1. Click on the *Generate* button to trigger the interactive automation script

    ![Start to generate CI Type script](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_GenerateCiType_0.png)

    ![Select connector](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_GenerateCiType_1.png)

1. Selected the connector and click the *Generate* button in the interactive automation script
1. By toggling off the *Show All* button, you can easily locate the generated CI Type

    ![Generate CI Type](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_GenerateCiType_2.png)

## Step 2: Create an element and manage it

1. Create an element with the [deployed connector](#deploy-connector)
1. Navigate to *Inventory* > *Unmanaged*
1. Click on the *Refresh* button to refresh the table

    > [!NOTE]
    > Make sure the *Detected CI Type* is filled in with the [generated CI Type](#generate-ci-type).
    >
    > If not, confirm that the element was created with the production version.

1. Select the recently created element and click on the *Manage* button

    ![Unmanaged element](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_UnmanageElement.png)

1. Confirm the element is now managed by IDP, by navigating to *Inventory* > *Managed*

    ![Managed element](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_ManageElement.png)

## Step 3: Setup configuration archive

For IDP to store the configurations it needs to access a local folder or a shared folder.

1. Open the *DataMiner IDP* app.
1. Navigate to *Admin* > *Configuration*
1. Fill the *Dataminer Configuration Archive* settings

    ![Setup configuration archive credentials](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_ConfigurationArchiveSetup.png)

1. Click the *Connect* button

> At this point, we have already
>
> 1. generated the CI Type
> 1. created an element and added it to the managed elements
> 1. configured IDP to access the archive

In the next step, we will create the script responsible for getting the configuration and sending it to IDP.

## Step 4: Create the script to retrieve the configuration backup

When IDP is installed it comes with an example script on how to retrieve the configuration and send it to IDP. First, we will start by duplicating the example script and, then change it to retrieve the parameter values from the [element created in Step 2](#step-2-create-an-element-and-manage-it).

### Duplicate the example configuration backup script

1. Navigate to *Automation* application
1. Expand the folder until you reach *DataMiner Solutions* > *IDP* > *CI Type Management* > *Configuration Management* > *Backup*
1. Duplicate the script *IDP_Example_Custom_ConfigurationBackup* and rename it

    ![Duplicated script](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_DuplicateScript.png)

### Update the script

1. Open the script
1. Navigate to the function *GetDeviceFullBackupAsText*
1. Change the function to retrieve the values from parameters 502 (*System Contact*) and 504 (*System Location*). Note that these parameters are from the suggested connector. If you have chosen another connector, you should adapt these parameters accordingly.

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

1. Go to the function *CreateAndSendBackup*
1. Change it to only include the *fullBackupData*

    ```csharp
    private void CreateAndSendBackup(IEngine engine)
    {
        string fullBackupData = BackupDevice(engine, GetDeviceFullBackupAsText);
        backupManager.SendBackupContentToIdp(fullBackupData);
    }
    ```

1. Click the button *Save script*
1. Before moving on, open the element you have created and set values to parameters 502 (*System Contact*) and 504 (*System Location*)

    ![Set parameter values](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_SetElementValue.png)

## Step 5: Retrieve the device configuration

1. Open *DataMiner IDP* app
1. Navigate to *Admin* > *CI Types* > *Configuration Management*
1. Select the backup script

    ![Select the backup script](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_SelectScript.png)

1. Navigate to *Configuration* > *Summary*
1. Select the element and click the *Backup* button

    ![Run the script](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_RunScript.png)

1. Select a *Type* and click *Next*, then click *Finish*

    ![Confirmation popup script](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_ConfirmationPopup.png)

1. Select again the element and click the *Show Backups* button
1. Select the recent backup and click *Show content*

    ![Backup content](~/user-guide/images/IDP_Tutorial_TakeConfigurationBackup_BackupContent.png)

Congratulations, you have saved your first device configuration with IDP!

> [!NOTE]
> For more information visit [Implementing the Configuration Backup script](xref:ConfigurationBackupScript).

> [!NOTE]
> To be granted DevOps points, take a screenshot of *Show content* result and either send it to [thunder@skyline.be](mailto:thunder@skyline.be) or upload it via the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/).
