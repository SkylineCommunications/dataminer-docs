---
uid: CTB_Documentation_Tools
---

# Getting started with your documentation tools

For larger contributions, e.g. to add several new pages, we recommend that you install the following (free) software, in the indicated order:

- [Git](https://git-scm.com/downloads)

  > [!NOTE]
  >
  > - While it is also possible to use the tools below without Git, some features in Visual Studio Code, such as branch and repository information, will not be available.
  > - If you install Git, it is important that you do so **before you install GitHub Desktop**, as otherwise you may experience [issues](xref:CTB_Troubleshooting#github-desktop-keeps-basing-branches-on-an-outdated-version-of-the-main-branch).

- [GitHub Desktop](https://desktop.github.com/)

- [Visual Studio Code](https://code.visualstudio.com/) (with the [Learn Authoring Pack](https://marketplace.visualstudio.com/items?itemName=docsmsft.docs-authoring-pack) and [Code Spell Checker](https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker) extensions).

  > [!NOTE]
  > Microsoft also provides a zero-install Visual Studio Code for the web. When you are working in GitHub online, you can access this by pressing the "." button on your keyboard. This version offers a complete overview of the repository like in the downloadable version of Visual Studio Code, but it does not offer any extensions, e.g. a spell check.

- [DocFX](xref:CTB_Local_Test_Build#installing-and-configuring-docfx) (optional): If you are making a larger contribution, we recommend making a test build on your local machine before pushing your changes to the repository, which requires DocFX.

When you install GitHub Desktop, you will also need to add the correct repository:

1. Install GitHub Desktop and log in with your GitHub account.

1. Select *Clone a repository from the Internet*.

   ![Install GitHub 1](~/images/Installing_Github_Desktop.png)

1. Next, you will be asked which repository you want to use. Clone the *SkylineCommunications/dataminer-docs* repository to your local machine. The easiest way to do so is by specifying the URL `https://github.com/SkylineCommunications/dataminer-docs` in the URL tab.

   ![Install GitHub 2](~/images/InstallGithub2.png)

   > [!IMPORTANT]
   >
   > - Make sure the local path you clone the repository to is relatively short. Using a long file path will lead to errors, as Windows will be unable to create certain files in the repository.
   > - Do not clone the repository to a folder that is synced with OneDrive, as this can cause errors.

1. If you do not have write access to the repository, you will find an alert in the lower-left corner of the GitHub Desktop UI.

   ![Install GitHub3](~/images/InstallGitHub3.png)

   If this is the case:

   1. Select *Create a fork*.

   1. Make sure the option *Copy the main branch only* is not selected.

      ![Copy the main branch only option](~/images/Copy_Main_Branch_Only.png)

   1. Click *Fork this repository*.

      ![Install GitHub 4](~/images/InstallGitHub4.png)

   1. When you are asked how you are planning to use this fork, select *To contribute to the parent project*.

> [!NOTE]
> If you have already made a fork of the repository in the past, you can also immediately add this fork as the URL when you clone the repository (e.g. `https://github.com/MyGitHubName/dataminer-docs`).

> [!TIP]
> Creating a fork will allow you to make changes that you can then add to a pull request. If Visual Studio Code has been installed, you can click *Open in Visual Studio Code* to immediately start working on the fork. However, note that if you have other editors installed as well (e.g. Notepad++), this button might display a different editor. You can change this via the *Options* link in the box containing the button.
>
> ![GitHub Desktop](~/images/Contrib_GitHubDesktop.png)

For more information on how to work with Visual Studio Code, refer to the [Visual Studio Code documentation](https://code.visualstudio.com/docs). As our documentation is written in Markdown, aside from the general functionality of the application, the [Markdown](https://code.visualstudio.com/docs/languages/markdown) section is of specific interest there.

Also keep in mind that we are using **DocFX Flavored Markdown**. For more information about this, see [Markdown syntax](xref:CTB_Markdown_Syntax). Make sure the Learn Authoring Pack extension is installed in Visual Studio Code to make it easier to work with this Markdown flavor.
