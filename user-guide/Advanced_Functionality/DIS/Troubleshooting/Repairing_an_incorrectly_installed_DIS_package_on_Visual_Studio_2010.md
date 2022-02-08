---
uid: Repairing_an_incorrectly_installed_DIS_package_on_Visual_Studio_2010
---

# Repairing an incorrectly installed DIS package on Visual Studio 2010

If you inadvertently installed a recent DIS package on top of Visual Studio 2010, then do the following to repair the installation:

1. Uninstall DIS:

    1. In Visual Studio, go to *Tools \> Extensions and Updates.*
    1. In the list of extensions, click *DataMiner Integration Studio*, click *Uninstall*, and confirm your decision.
    1. Restart Visual Studio.

1. Download the compatible installation package from the following location, and install DIS again:

    <https://community.dataminer.services/dataminer-integration-studio-other-downloads/>

1. In the Visual Studio menu, go to *DIS \> Settings... \> Updates*, clear the *Check for plugin updates* option, and click *OK*.
