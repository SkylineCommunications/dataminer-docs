---
uid: Installing_DM_using_the_DM_installer
---

# Installing DataMiner using the DataMiner Installer

## Prerequisites

Before you run the installer, install the latest .NET Framework version.

- For more information on recommended versions, see [DataMiner Compute Requirements](https://community.dataminer.services/dataminer-compute-requirements/).
- For installation information, see <https://docs.microsoft.com/en-us/dotnet/framework/install/>

## Running the installer

The DataMiner installer allows you to run a default DataMiner installation, which includes a Cassandra database on the C drive, or to run a custom installation. A custom installation can for instance be used to install a MySQL database instead of a Cassandra database.

> [!NOTE]
> The default installation requires that the built-in Windows Administrator account is enabled and that WinPcap is installed.

### Default DataMiner installation

1. Double-click *Setup.exe*.

1. Click *Install*.

1. Enter the DataMiner ID.

    > [!IMPORTANT]
    > To get this DataMiner ID, you must contact Skyline. The DataMiner ID will uniquely identify the DataMiner Agent you are installing.

1. Click next.

    The progress of the installation will be displayed. A *cancel* button in the lower right corner allows you to cancel the installation process if necessary.

1. Once the installation is complete, click *next*.

1. Click *go to Request.lic* to browse to *Request.lic*.

1. Send the *Request.lic* file to <dataminer.licensing@skyline.be>, and wait until you receive the reply.

1. Once you have received the license files, save these somewhere on the computer; however, not in the "Skyline DataMiner" folder.

1. In the *License* tab of the DataMiner Installer, click *browse and upload*, and navigate to the license files.

1. Once all files have been uploaded successfully, click *restart DataMiner*.

1. When DataMiner has successfully restarted, click *Close*.

> [!NOTE]
> To view detailed log information on the installation process, in the last step of the Installer, click the *open log files* button.

### Custom DataMiner installation

1. Double-click *Setup.exe*.

1. Click *Customize*.

1. Enter the DataMiner ID.

    > [!IMPORTANT]
    > To get this DataMiner ID, you must contact Skyline. The DataMiner ID will uniquely identify the DataMiner Agent you are installing.

1. Optionally, customize the database installation:

    - To install a MySQL database instead of a Cassandra database, select *MySQL Server*, and optionally *MySQL Workbench*.
    
        > [!NOTE]
        > If a MySQL database is used, certain DataMiner features (e.g. trend predictions) will not be available.

    - If you wish to install Cassandra but use a different drive than the default C drive, keep Cassandra selected and click *select data drive*. Then select the drive and click *OK*.

        > [!NOTE]
        > By default, a DataMiner Agent uses a single Cassandra node that is hosted on the same physical or virtual server. However, different architectures are also possible. For more information, see [DataMiner Compute Requirements](https://community.dataminer.services/dataminer-compute-requirements/), or check with your Technical Account Manager.

    - To install WinPcap, click *Install WinPcap*. The Setup Wizard of WinPcap is launched. Follow the wizard, select *Automatically start the WinPcap driver at boot time*, and click *Next* when necessary.

        On Windows 8 and Windows Server 2012, click *Run without getting online help*. Follow the WinPcap setup. When an error occurs, click *OK*.

    - If the built-in Administrator account is not enabled, select *Create administrator account for current user* to create a Windows user account.

1. Click *Next*.

    The progress of the installation will be displayed. A *cancel* button in the lower right corner allows you to cancel the installation process if necessary.

1. Once the installation is complete, click *next*.

1. Click *go to Request.lic* to browse to *Request.lic*.

1. Send the *Request.lic* file to <dataminer.licensing@skyline.be>, and wait until you receive the reply.

1. Once you have received the license files, save these somewhere on the computer; however, not in the "Skyline DataMiner" folder.

1. In the *License* tab of the DataMiner Installer, click *browse and upload*, and navigate to the license files.

1. Once all files have been uploaded successfully, click *restart DataMiner*.

1. When DataMiner has successfully restarted, click *Close*.

> [!NOTE]
> To view detailed log information on the installation process, in the last step of the Installer, click the *open log files* button.
