---
uid: Creating_a_repository
---

# Creating a repository

In order to create a new repository, click the *Create repository* button. This will open the *Create New Repository* pop-up window, where you can provide the name of the vendor and data source.

> [!NOTE]
> The name of the data source should start with the name of the vendor. If it does not, the following error will be shown in the status bar: (ERROR) Data Source does not start with: \<VendorName>.

![](~/develop/images/SLCSERepoManager_Create.png)<br>
*SLC SE Repository Manager: Creating a repository*

- In case no version of this protocol exists on SVN yet, when the create button is clicked, the following message will be shown:

  ![](~/develop/images/SLCSERepoManager_Create_confirm.png)<br>
  *SLC SE Repository Manager: Creation confirmation*

  When you click *Yes*, a new Git repository will be created on the server with the specified name. The repository will automatically be cloned to your local path after the remote repository has been created by Gerrit.

  Every new repository contains the following files:

  - .gitignore: This file makes it possible to automatically keep certain files from being tracked (such as build output).

  - Jenkinsfile: This file is used by the Jenkins build server.

- In case some versions of the specified protocol already exist on SVN, the SLC SE Repository Manager tool will create a new Git repository with branches corresponding with the ranges that exist on SVN. For each version of the protocol on SVN, a tag will be created in the Git repository.

  ![](~/develop/images/SLCSERepoManager_Convert_confirm.png)<br>
  *SLC SE Repository Manager: Conversion confirmation*

  Consider the following example: Suppose you need to create a new version of the *Generic Database* protocol. On SVN, the following versions exist of this protocol:

  - 1.0.0.1

  - 1.0.0.2

  - 1.0.0.3

  - …

  - 1.0.0.8

  - 2.0.0.1

  - 2.0.0.2

  - 2.0.0.3

  This means that when you create a new Git repository for this protocol, the SLC SE Repository Manager tool will create a new Git repository with two branches, "1.0.0.X" and "2.0.0.X", and it will also create tags for each version of the protocol.

  Each version of this repository will have a "fromSvn" folder containing the content that was found on SVN for that version. This will typically be the protocol.xml file and the checklist.

> [!IMPORTANT]
> Once a Git repository has been created for a protocol, this repository should be used for creating new versions. This means new versions must no longer be manually added on SVN. On SVN, you can verify whether this protocol has been migrated to Git already by checking for the presence of a "ConvertedToGit.txt" text file in a version folder.
