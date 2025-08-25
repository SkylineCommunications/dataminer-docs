---
uid: MbgNMS_1.4.1_CU1
---

# MbgNMS 1.4.1 CU1

## Fixes

#### 'Directory not found' exception during first-time installation [ID 43512]

When the Meinberg Element Manager was installed for the first time, this could trigger the following exception: `System.IO.DirectoryNotFoundException: Could not find a part of the path 'C:\Skyline DataMiner\Webpages\Meinberg\Meinberg_Element_Manager_About.htm'.`

To resolve this, the folder `C:\Skyline DataMiner\Webpages\Meinberg\` will now be created during installation if it does not exist yet.

This issue did not occur on systems where a previous version of the Meinberg Element Manager had already been installed.
