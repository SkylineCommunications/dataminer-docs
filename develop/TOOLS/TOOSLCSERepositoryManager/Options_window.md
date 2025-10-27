---
uid: Options_window
---

# Options window

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

![](~/develop/images/SLCSERepoManager_Options.png)<br>
*SLC SE Repo Manager: Options window*

Via *Tools* > *Options*, you can access a window that provides the following options:

- *Local Git Root*: Specifies the path to the local root folder.

- *SourceTree path*: Specifies the path to the SourceTree executable. This is used for the SourceTree link on the main window. By default, the SLC SE Repo Manager will look in the default installation location. If you installed SourceTree in a custom location, you will need to specify the location here.

- *Sandbox Mode*: Toggles between sandbox and normal mode.

- *DebugLog*: Link to the SLC SE Repo Manager log file.

- *Override Clone Path*: This is applicable for remote offices that have a mirror location. It contains the path to the mirror server. When a repository is cloned, the SLC SE Repo Manager will try to find the repository in this location first. If it does not exist, the SLC SE Repo Manager will fall back to the HQ.

  - For the US (available from the office or via VPN), specify **\\\SLA-REPOMIRROR\gerrit.skyline.be**
  - For Singapore (available from the office), specify **\\\SG-SERVER1\gerrit.skyline.be**
  - For Bosnia (available from the office or via VPN), specify **\\\SLB-SRV-01\gerrit.skyline.be**

  Note that this is no longer available for the Portugal office.
