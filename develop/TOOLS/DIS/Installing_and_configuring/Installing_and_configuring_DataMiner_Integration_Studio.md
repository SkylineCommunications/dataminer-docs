---
uid: Installing_and_configuring_DataMiner_Integration_Studio
---

# Installing and configuring DataMiner Integration Studio

## Downloading DataMiner Integration Studio

To download the **current version** from the Visual Studio Marketplace, go to [DataMiner Integration Studio](https://marketplace.visualstudio.com/items?itemName=skyline-communications.DataMinerIntegrationStudio) on the Marketplace.

If you want to use an **older DIS version**, for instance because you are using an older version of Visual Studio, go to [DataMiner Integration Studio – Downloads](https://community.dataminer.services/dataminer-integration-studio-other-downloads/) on DataMiner Dojo. On this page, you will find both the current version and versions supporting Visual Studio 2019 or older.

To download the **Class Library Packages**, go to [Class Library Packages](https://community.dataminer.services/class-library-packages/) on DataMiner Dojo.

## Installing the DataMiner Integration Studio extension

To install DataMiner Integration Studio in Visual Studio, go to *Extensions* > *Manage Extensions...* to open the *Manage Extensions* dialog box.

In the *Browse* tab, type `DataMiner Integration Studio`, and the extension should show up in the list. Press the *Install* button for the extension.

> [!TIP]
> To automatically check for and/or install updates of an extension, go to *Tools* > *Options*. In the *Options* window, under *Environment*, select *Extensions*.
> Select the *Automatically check for updates* checkbox to automatically check for updates. Select the *Automatically update extension* checkbox to automatically update extensions.

Alternatively, go to [https://marketplace.visualstudio.com/](https://marketplace.visualstudio.com/). Make sure *Visual Studio* is selected, and enter `DataMiner Integration Studio` in the search box. Click the extension to go to the download page. Click the download button to download the .vsix package.

1. Verify whether you have administrator privileges on your computer. If you do not, you will need to contact someone with these privileges to install DIS for you.

   > [!NOTE]
   > If your local user account does not have elevated privileges, you will not be able to install DIS yourself. To ask your IT Service Desk or a user with administrative privileges to install DIS, download the applicable DIS version as mentioned above, and supply it to the person with administrative privileges. With Visual Studio 2022, they can run the following command in a command prompt or powershell terminal with administrator privileges, replacing "Filename" with the actual .vsix file name:
   >
   > `C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\VSIXInstaller.exe" /a C:\PathToLocationWithDIS\Filename.vsix`
   >
   > The `/a` command will install the plugin for all users on the workstation.

1. If Microsoft Visual Studio is running, close it before continuing the installation process.

1. Double-click *DataMinerIntegrationStudio.vsix*.

1. Click *Install*.

1. When the installation is complete, click *Close*.

1. Start Microsoft Visual Studio.

1. In the DIS menu, go to *Settings > Account*, and sign in with your dataminer.services account.

> [!NOTE]
> The above-mentioned procedure can also be used to upgrade DataMiner Integration Studio.

## Changing the DataMiner Integration Studio settings

After installing DataMiner Integration Studio, you can configure its settings from within the Microsoft Visual Studio interface.

1. From the menu, choose *DIS > Settings*.
1. Make the necessary changes to the different settings.

   For an overview of all DIS settings, see [DIS settings](xref:DIS_settings)

1. Click *OK*.
