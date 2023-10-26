---
uid: Installing_and_configuring_DataMiner_Integration_Studio
---

# Installing and configuring DataMiner Integration Studio

## Installing the DataMinerIntegrationStudio.vsix extension

To install DataMiner Integration Studio, you have to install the *DataMinerIntegrationStudio.vsix* extension file on top of Microsoft Visual Studio.

1. Check which version of Visual Studio you are using, download the correct *DataMinerIntegrationStudio.vsix* extension file, and place it in a temporary folder on your computer:

   | Visual Studio version | Download location |
   |-----------------------|-------------------|
   | Visual Studio 2019 or newer | <https://community.dataminer.services/exphub-dis/> |
   | Visual Studio 2010 to 2019  | <https://community.dataminer.services/dataminer-integration-studio-other-downloads/> |

   > [!IMPORTANT]
   > In order to download DataMiner Integration Studio, you will need to log in with your Dojo account. If you do not have one yet, go to <https://community.dataminer.services/> and click *Register*.

1. Verify whether you have administrator privileges on your computer. If you do not, you will need to contact someone with these privileges to install DIS for you.

   > [!NOTE]
   > If your local user account does not have elevated privileges, you will not be able to install DIS yourself. To ask your IT Service Desk or a user with administrative privileges to install DIS, download the applicable DIS version as mentioned above and supply it to the person with administrative privileges. With Visual Studio 2022, they can run the following command in a command prompt or powershell terminal with administrator privileges, replacing "Filename" with the actual .vsix file name:
   >
   > `C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\VSIXInstaller.exe" /a C:\PathToLocationWithDIS\Filename.vsix`
   >
   > The `/a` command will install the plugin for all users on the workstation.

1. If Microsoft Visual Studio is running, close it before continuing the installation process.

1. Double-click *DataMinerIntegrationStudio.vsix*.

1. If multiple versions of Microsoft Visual Studio have been installed on your computer, select the version on top of which you want to install the *DataMinerIntegrationStudio.vsix* extension.

1. Click *Install*.

1. When the installation is complete, click *Close*.

1. Start Microsoft Visual Studio.

1. In the DIS menu, go to *Settings > Account*, and sign in with your dataminer.services account.

> [!NOTE]
> The above-mentioned procedure can also be used to upgrade DataMiner Integration Studio.

## Changing the DataMiner Integration Studio settings

After installing DataMiner Integration Studio, you can configure its settings from within the Microsoft Visual Studio interface.

1. From the menu, choose *DIS \> Settings*.
1. Make the necessary changes to the different settings.

    For an overview of all DIS settings, see [DIS settings](xref:DIS_settings)

1. Click *OK*.
