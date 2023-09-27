---
uid: Creating_a_repository_for_an_install_package
---

# Creating a repository for an install package

An install package is defined through a manifest XML file. This manifest provides information about the install package such as its name, version and content (e.g. protocols, Automation scripts, Visio files).

On the *Packages* tab of the SLC SE Repo Manager, you can create a new repository for an install package.

![](~/develop/images/TOOProtocolDevelopmentWithCICD00071.jpg)

When you click the new package button on the right, a new window will pop up:

![](~/develop/images/InstallPackage2.png)

If you select the *Selection Mode* checkbox, you will enter selection mode. In this mode, you can select items to include in the package from the other tabs in the repo manager (by double-clicking on an item in the tree view).

Once the desired items have been selected, click the *Create* button to create the new repository.

After creating and cloning the repository, you will find a repository with a solution containing the manifest.xml file and an install script.

The manifest file will contain the items you previously selected in selection mode in the repo manager. Note that the content of the manifest can be adapted and extended with additional items.

The install script is an Automation script that performs the installation of the package. This installation script by default only performs installation of the package items but can be customized to your needs.
