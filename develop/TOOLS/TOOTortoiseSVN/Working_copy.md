---
uid: Working_copy
---

# Working copy

The repository is located on a central server and a local working copy is needed for a developer to make changes to a file or to create new files.

Developers can work on their PC to make changes to a file or create a new file and can then commit their changes to the repository.

- The folder structure of a working copy should reflect the structure from the repository.

- The folder structure needs to be linked to the repository by means of a checkout.

For example, to work with the SystemEngineering repository illustrated in Figure 120, do the following:

1. If you want to work on protocols, an empty directory *Protocols* should be created. (The same goes for the other folders.) When trying to pull example protocols from the repository, start off by creating an empty directory *Examples*. This way, your local structure will resemble the structure of the repository.

   ![](~/develop/images/SVN_base_structure.png)<br>
   *Repository structure.*

   Note that you can create these folders directly in a Visual Studio project as well. In the screenshots below, a new Visual Studio project was created and both folders where created by using the *Add* functionality.

   The advantage of using Visual Studio is that we typically work in Visual Studio and the files are then directly included in Visual Studio.

   ![](~/develop/images/SVN_add_in_VS_1.png)<br>
   *Visual Studio solution*

   ![](~/develop/images/SVN_add_in_VS_2.png)<br>
   *Visual Studio Add menu*

1. The next step is to link the working copy folders and files with the repository by performing a checkout on them. A checkout can be performed through the Repo-browser.

   1. Open the folder, for example *Protocols*, right-click, and select *TortoiseSVN* > *Repo-browser*.

      ![](~/develop/images/SVN_repo_browser.png)<br>
      *TortoiseSVN Repo-browser*

   1. Because you are not linked to the repository yet, a pop-up message will appear, asking for the URL to the repository. Enter the following URL: `https://svn.skyline.be/svn/SystemEngineering/`.

      ![](~/develop/images/SVN_URL_repository.png)<br>
      *TortoiseSVN Repository URL configuration*

      The repository browser will open and you will see a window with all the available repository content.

   1. If you want to get a working copy of the protocols folders, the first thing you should then do is perform a checkout (via right-click on *Protocols*) on the folder in the repository browser.

      Set the checkout depth to *Only this item*. Otherwise, you will download all protocols.

      ![](~/develop/images/SVN_checkout.png)<br>
      *TortoiseSVN Checkout window*

      A hidden folder will then be created in your local folder. If you notice this folder, this means that the linking to the repository was successful. **Do not make any changes to this folder.**

   1. Repeat the previous step for every folder that is directly under *SystemEngineering*.

      ![](~/develop/images/SVN_folders_under_systemengineering.png)<br>
      *System Engineering folder structure*
