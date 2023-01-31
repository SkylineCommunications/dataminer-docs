---
uid: Installing_an_app_package
---

# Installing an application package

Application packages can be uploaded, viewed, installed and configured using the SLNetClientTest tool. All commands related to application packages can be found under *Advanced > Apps > AppPackages*.

From DataMiner 10.2.10 (RN 33969) onwards, you can double click on the application package which will start the install procedure.

> [!IMPORTANT]
>
> It is currently not supported to install an application package via the System Center in DataMiner.

> [!NOTE]
>
> - To be able to install application packages, you must have the following user permission: *Modules > System configuration > Agents > Install App packages*.

Although the above-mentioned method is to be preferred, it is also possible to embed an application package into a *.dmupgrade* package. To do so:

1. Create a .dmupgrade package.

1. In the *UpdateContent.txt* file of that package, add an `InstallApp` instruction, followed by the path to the application package you created earlier:

    `InstallApp ./Path/To/AppPackage/AppPackage.zip`

1. Install the *.dmupgrade* package on a DataMiner Agent that is running.

> [!NOTE]
>
> - Make sure the *.dmupgrade* package does not contain any instructions to stop the DMA. Also, if you intend to install the *.dmupgrade* package on a DMA using the DataMiner Taskbar Utility, make sure the DMA is running.
> - If you install the *.dmupgrade* package in a DMS, the DataMiner Agent on which the upgrade is launched will run the installation script in the application package. If the upgrade is launched from a DMA that is not a member of the DMS, the DMA with the first IP address (in alphabetical order) will run the installation script.
> - To install an application package on multiple DMAs in a DMS, select the DMAs to be upgraded while you are connected to one of the DMAs in the DMS, or install the package using the DataMiner Taskbar Utility.
