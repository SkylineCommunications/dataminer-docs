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

1. Double-click *DataMinerIntegrationStudio.vsix*.
1. If multiple versions of Microsoft Visual Studio have been installed on your computer, select the version on top of which you want to install the *DataMinerIntegrationStudio.vsix* extension.
1. Click *Install*.
1. When the installation is complete, click *Close*.
1. Start Microsoft Visual Studio. If it was running during the installation of the *DataMinerIntegrationStudio.vsix* file, restart it.
1. In the DIS menu, go to *Settings > Account*, and sign in with your dataminer.services account.
1. When you open a tool window, the following message will appear:

    ```txt
    This copy of DataMiner Integration Studio is not licensed. Please contact dataminer.licensing@skyline.be
    ```

1. Send an email to dataminer.licensing@skyline.be to request a software license.
1. When you receive a reply from Skyline saying that your license has been activated, restart Microsoft Visual Studio.

> [!NOTE]
> The above-mentioned procedure can also be used to upgrade DataMiner Integration Studio.

## Changing the DataMiner Integration Studio settings

After installing DataMiner Integration Studio, you can configure its settings from within the Microsoft Visual Studio interface.

1. From the menu, choose *DIS \> Settings*.
1. Make the necessary changes to the different settings.

    For an overview of all DIS settings, see [DIS settings](xref:DIS_settings)

1. Click *OK*.
