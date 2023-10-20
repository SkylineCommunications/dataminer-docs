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



## Installing DIS on a locked down corporate workstation

The above method to install DIS will fail if your local user account does not have elevated privledges, or install but not have full functionality.

You may request your IT Service Desk or user that has administrative privledges on your workstation to install by the following method

1. Download the applicable DIS as per links above.
1. Supply the .visx file to your adminstrator.
1. With Visual Studio 2022 have them run the following in a command or powershell terminal with adminstrator privledges:
"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\VSIXInstaller.exe" /a C:\PathToLocaltionWithDIS\DataMinerIntegrationStudio17-2.45.1.4.vsix
Replacing the filename to match the actual vsix file provided.   The /a command installs the plugin for all users on that workstation.
