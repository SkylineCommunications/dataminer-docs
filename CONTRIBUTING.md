---
uid: contributing
---

# Contributing to the DataMiner docs

Welcome to the docs.dataminer.services contributor guide!

Our documentation is open to contributions from any user. Contributions are created, reviewed, and merged via GitHub. This page will explain how you can add and review contributions, ranging from simple changes to a single page, to larger changes where entire sections of the documentation are added or modified.

> [!TIP]
> Are you a member of the DataMiner DevOps Professional Program? You can earn points by proposing changes or pointing out issues in the documentation! Find out [how many DevOps Points you can earn](xref:Benefits_DevOps_Professionals_Program#accumulating-devops-points).

## General guidelines

- Use **US English** spelling when you contribute to the DataMiner documentation.

- Try to conform to the [Microsoft Style Guide](https://docs.microsoft.com/en-us/style-guide/) as much as possible.

- Use DocFX Flavored Markdown (DFM). If you are unfamiliar with this syntax, refer to [Markdown syntax](#markdown-syntax) below.

- Do not make changes to the root folder of the repository, to the *.github* folder, or to the *templates* folder. As a rule, such changes will be rejected.

## Doing a quick edit to a page

> [!TIP]
> See also: [Making a small contribution to DataMiner Docs](https://community.dataminer.services/video/making-a-small-contribution-to-dataminer-docs/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

On every page of the documentation on docs.dataminer.services, a *Propose changes* link is available in the top-right corner. Clicking this link will open the source of the documentation on GitHub. You can then make changes as follows:

![Propose changes link](~/images/Propose_Changes.png)

1. Make sure you are logged in to GitHub.

1. On the page you intend to edit in GitHub, click the pencil button in the top-right corner.

   ![Pencil button](~/images/Contrib_PencilButton.png)

   This will create a "fork" of the documentation, i.e. a copy where you can freely make changes.

1. Make your changes using the web editor. To get a preview of the changes, go to the *Preview* tab.

1. Once you have made your changes, click *Commit changes* in the top-right corner. This will open a pop-up window.

   ![Commit changes](~/images/Commit_Changes.png)

1. In the pop-up window, you can enter a title and description for your changes and click *Propose changes*. For example:

   ![Proposing changes](~/images/Contrib_ProposeChanges.png)

1. A page will be displayed with a summary of your changes. At the top of the page, click *Create pull request*. A “pull request” is a request to pull changes into the repository.

   ![Create a pull request for your changes](~/images/Contrib_CreatePullRequestForChanges.png)

1. Double-check the title and description for the pull request, and modify them if necessary. We recommend that you select the option *Allow edits by maintainers*, so that the documentation team will be able to correct any small issues (e.g. typos) directly.

1. Click *Create pull request*.

   The documentation team will review the request and merge it if it is approved. If changes are needed before it can be merged, you will receive feedback.

   > [!IMPORTANT]
   > Do not forget to create a pull request! Otherwise, your changes may be lost.

## Reporting an issue

GitHub offers the possibility to report an issue. This feature can be used if you think information is missing or notice a mistake but are unsure of how to change it using the [web editor](#doing-a-quick-edit-to-a-page) or [GitHub Desktop](#making-a-larger-contribution). You can report an issue as follows:

1. Go to the [dataminer-docs repository](https://github.com/SkylineCommunications/dataminer-docs) on GitHub.

1. In the top-left corner, select *Issues*.

1. Select *New issue*.

1. Choose a title for the issue and leave a comment.

1. Select *Submit new issue*.

The Skyline documentation team will review the issue and provide you with feedback.

## Reviewing a contribution from someone else

Most contributions to the documentation are added in the form of "pull requests", i.e. requests to pull specific changes into the repository. The pull requests are listed under <https://github.com/SkylineCommunications/dataminer-docs/pulls>.

Until a pull request is merged, everyone can review it and add comments of their own. To do so:

1. Open the pull request, for instance by selecting it in the list of pull requests or by using a direct link to the pull request.

1. Go to the *Files changed* tab. This will show an overview of all the changes in the pull request.

1. Check the changes in each file. For larger modifications, you may need to click *Load diff* first.

1. To add a comment, hover the mouse pointer over the relevant line and click the blue "+" button.

   ![Button to add a comment](~/images/Contrib_PlusButton.png)

1. Write your comment and click *Add single comment* or *Start a review*, depending on whether you want to add more comments or not.

   ![Adding a comment](~/images/Contrib_Comment.png)

1. If you started a review, when you have reviewed everything, click the *Finish your review* button at the top. Optionally, instead of the default *Comment* option, select *Approve* to indicate that you approve the changes in the pull request or *Request changes* to indicate that you think further changes are necessary before the pull request can be merged. Then click *Submit review*.

   ![Submitting a review](~/images/Contrib_SubmitReview.png)

> [!NOTE]
> You can also submit a review without adding comments directly in a file, by only clicking the green review button and using the window displayed above.

> [!TIP]
> If the Markdown source looks confusing, and you would prefer to see a preview of a file, in the *Files changed* tab, click "..." in the top-right corner of the box representing the file, and select *View file*. However, note that it is not possible to submit comments in this preview.

## Making a larger contribution

**Check with the [Skyline documentation team](mailto:team.technical.writing@skyline.be) before you use the procedure below.** This way you can avoid unnecessary work, e.g. because the information you want to add is already available elsewhere in the documentation. If you are unsure of how to fit your information in the current structure of the documentation, or if you do not feel comfortable working in Markdown, **you can always submit your contribution by emailing it to <team.technical.writing@skyline.be> instead**.

### Getting started

> [!TIP]
> See also:
>
> - [Getting started with your Documentation Tools](https://community.dataminer.services/video/getting-started-with-your-documentation-tools/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
> - [Making a large contribution to DataMiner Docs](https://community.dataminer.services/video/making-a-large-contribution-to-the-dataminer-docs/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
>
> Note that these videos are less update-friendly than the instructions below.

For larger contributions, e.g. to add several new pages, we recommend that you install the following (free) software, in the indicated order:

- [Git](https://git-scm.com/downloads)

  > [!NOTE]
  >
  > - While it is also possible to use the tools below without Git, some features in Visual Studio Code, such as branch and repository information, will not be available.
  > - If you install Git, it is important that you do so **before you install GitHub Desktop**, as otherwise you may experience [issues](#github-desktop-keeps-basing-branches-on-an-outdated-version-of-the-main-branch).

- [GitHub Desktop](https://desktop.github.com/)

- [Visual Studio Code](https://code.visualstudio.com/) (with the [Learn Authoring Pack](https://marketplace.visualstudio.com/items?itemName=docsmsft.docs-authoring-pack) extension)

> [!NOTE]
> Microsoft also provides a zero-install Visual Studio Code for the web. When you are working in GitHub online, you can access this by pressing the "." button on your keyboard. This version offers a complete overview of the repository like in the downloadable version of Visual Studio Code, but it does not offer any extensions, e.g. a spell check.

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

1. If you do not have write access to the repository, you will find an alert in the lower left corner of the GitHub Desktop UI.

   ![Install GitHub3](~/images/InstallGitHub3.png)

   If this is the case:

   1. Select *Create a fork*.

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

Also keep in mind that we are using **DocFX Flavored Markdown**. Refer to the [Markdown syntax](#markdown-syntax) section below for more information about this. Make sure the Learn Authoring Pack extension is installed in Visual Studio Code to make it easier to work with this Markdown flavor.

### Things to watch out for

#### Make sure your fork is up to date

When you are working on your own fork, make sure you regularly **check in GitHub whether your fork is still up to date** with the main repository. To do so:

1. Go to <https://github.com/SkylineCommunications/dataminer-docs>.

1. In the About section on the right, click the link to the forks:

   ![Link to forks](~/images/Contrib_Forks.png)

1. Look up your fork in the list, and click the link to go the page for your own fork.

1. Check the top of your fork page. If it says the branch is a number of commits behind SkylineCommunications:main, your fork is no longer up to date. If there is no such indication, there is no need to continue with this procedure.

   ![Indication of outdated fork](~/images/Contributing_Sync_Fork.png)

1. To update your fork, click the triangle button next to *Sync fork* and select *Update branch*.

   ![Link to forks](~/user-guide/images/Contributing_Update_Branch.png)

#### Adding a new page

When you add a page to the documentation:

- Make sure there is a UID at the top of your new file. Add this UID in a metadata section. For example:

  ```md
  ---
  uid: contributing
  ---
  ```

  > [!NOTE]
  > Do not use spaces in a UID.

- Add the new page to the relevant *toc.yml* file so that it is included in the table of contents. To do so, specify the name and UID as follows:

  ```yml
  - name: The name of the page as it should appear in the table of contents
    topicUid: The file UID
  ```

  For example:

  ```yml
  - name: Basic concepts
    topicUid: BasicConcepts
  ```

  To add the new page at a lower level in the table of contents, use the following syntax:

  ```yml
  - name: The name of the page at the level above the page you are adding
    topicUid: The file UID
    items:
    - name: The name of the new page as it should appear in the table of contents
    - topicUid: The file UID of the new page
  ```

- Check if there are any smaller content overviews that also need to be updated with a link. For example, if you add something in the user guide, usually there is a page at a higher level in the guide that gives an overview of all underlying pages. Add a link to your new page on that page.

#### Adding cross-references

To avoid adding duplicate information, use cross-references to refer to information that is already available in the documentation.

When you add a cross-reference to a different file, make sure that you always link to the file’s UID. While it is possible to link to the actual file instead, this should be avoided as such a link is broken when the file name or file structure changes. For more information, see [Links and cross-references](#links-and-cross-references).

### Creating a pull request

When your changes are ready, you can create a pull request to submit them for review:

1. Make sure you have saved your changes in Visual Studio Code. As long as a blue circle is displayed on top of the topmost icon in the sidebar on the left, there are still unsaved changes. The number in this circle indicates the number of files with unsaved changes.

   ![Example of unsaved changes](~/images/Contrib_UnsavedChanges.png)

1. Check the overview of your changes in GitHub Desktop.
1. If all changes are OK, fill in a title for the update in the *Summary* box in the lower right corner and click the *Commit* button.
1. In the central pane of GitHub Desktop, click *Push origin*.

   ![Push origin](~/images/Contrib_PushOrigin.png)

1. Next click *Create Pull Request*. This will open GitHub in a browser.

   ![Create Pull Request](~/images/Contrib_CreatePullRequest.png)

   > [!NOTE]
   > You can also select *Preview Pull Request* to get a complete overview of the changes you are about to commit and the base you are merging this to. If necessary, you can select a different base branch here as well. If all changes are OK, select *Create pull request*.

1. In the browser, make sure that the base you are merging to is the main branch. If a different base branch is selected, make sure to select the correct branch. Scroll down for another overview of the changes that will be included in the pull request.

1. Specify a title for the pull request, and optionally add a comment with more information about your changes.

   > [!NOTE]
   > We recommend that you keep the option *Allow edits by maintainers* selected, so that the documentation team will be able to correct any small issues directly. Note that if you instead see the option *Allow edits and access to secrets by maintainers*, this means that the pull request includes workflows of your forked repository, which means you could potentially reveal values of secrets and grant access to other branches if you allow edits. If you do not want this, do not select this option.

1. Click *Create pull request*. Your pull request will now be submitted for review.

   The documentation team will review the request and merge it if it is approved. If changes are needed before it can be merged, you will receive feedback.

      > [!NOTE]
      > You can also create a draft pull request, for example if you still want to have someone else make changes before the pull request can be merged. In that case, click the triangle button next to *Create pull request* and select *Create draft pull request*.
      >
      > ![Create draft pull request](~/images/Contrib_draftPR.png)
      >
      > When the pull request is ready to be merged, you can click *Ready for review* on the pull request page to change it from a draft into a full pull request.

### Collaborating with others on a draft branch

When you work together with several other people to add new information to the documentation, it can be useful to work together on the same draft branch without publishing your changes to the main branch yet. This way, you can add multiple changes that others can then further work on, but nothing will be published on docs.dataminer.services yet.

![Create pull request to draft branch](~/images/Pull_Request_Draft_Branch.png)

You can do so as follows:

1. Select the draft branch you want to use in GitHub Desktop.

   If the branch does not exist yet, ask <team.technical.writing@skyline.be> to create it. If you were to create a new branch in your fork of the repository instead, other people would not be able to contribute to it as easily.

   ![Select the draft branch](~/images/Contrib_SelectDraftBranch.png)

1. Open the branch in Visual Studio Code. You can do so by clicking the *Open in Visual Studio Code* button in GitHub Desktop.

1. Make your changes in Visual Studio Code and make sure they are saved. Keep the items listed under [Things to watch out for](#things-to-watch-out-for) in mind.

1. In GitHub Desktop, add a short summary of your changes in the box in the lower right corner. Optionally, you can also add a description. Then click the *Commit* button.

   ![Commit to the draft branch](~/images/Contrib_CommitToDraftBranch.png)

1. Click *Push origin* to push the changes to the remote.

   > [!NOTE]
   > If you get an error when you click this button, this usually means you are trying to push the changes directly to the main repository instead of to your fork. In GitHub Desktop, go to *Repository* > *Repository settings*, and make sure the specified *Primary remote repository* is your fork. To find the URL of your fork, go to <https://github.com/SkylineCommunications/dataminer-docs/network/members>, search for your GitHub username, and click the *dataminer-docs* link next to it.

1. Click the *Create Pull Request* button. This will open GitHub in a browser.

   ![Create Pull Request](~/images/Contrib_CreatePullRequest.png)

1. In the browser, make sure that the base you are merging to is the draft branch. If a different base branch is selected, make sure to select the correct branch.

   ![Create Pull Request](~/images/Contrib_DraftBranchForPullRequest.png)

1. Click *Create pull request*.

After you have created a pull request, the Skyline documentation team will need to merge your pull request so that it **becomes available in the branch for other people as well**.

> [!TIP]
> This can take some time. We recommend that you enable notifications in your account settings so that you get a notification when the merge is done.

#### Keeping the draft branch up to date in your fork

When your pull request has been merged, others can continue to work on your changes. However, to see all recent changes merged to the draft branch in your own fork, you will need to make sure that **the draft branch in your fork is up to date**.

![Sync Branch](~/images/Sync_Branch.png)

1. Go to the [dataminer-docs repository](https://github.com/SkylineCommunications/dataminer-docs) on GitHub.

1. In the top-right corner, click the triangle button next to *Fork* and select your fork.

   ![Your existing forks](~/images/Your_Existing_Forks.png)

1. In the top-left corner, change the branch from *main* to your draft branch.

   ![Main to draft branch](~/images/Main_to_Draft.png)

1. Check the top of the page. If it says the branch is a number of commits behind the draft branch located on the dataminer-docs repository, your branch is no longer up to date. If there is no such indication, there is no need to continue with this procedure.

1. To update your fork, click the triangle button next to *Synch fork* and select *Update branch*.

1. In GitHub Desktop, click *Fetch origin*. If there are commits on the branch that do not yet exist on your machine, the option to *Pull origin* will become available.

   ![Fetch origin](~/images/Fetch_Origin.png)

Now that all commits are available on your machine, you can [continue to make changes](#collaborating-with-others-on-a-draft-branch).

#### Creating the final pull request to merge the draft branch

![Publish to docs](~/images/Publish_to_Docs.png)

When all the necessary changes have been made and the draft branch is ready for publication:

1. Go to the [dataminer-docs repository](https://github.com/SkylineCommunications/dataminer-docs) on GitHub.

1. In the top-left corner, switch from the main branch to the draft branch.

1. At the top of this page, click the number of commits the branch is ahead SkylineCommunications:main.

   ![Draft_Branch](~/images/Draft_Branch.png)

   A page will be displayed with a summary of all changes made to the draft branch.

1. Make sure the base you are merging to is set to *main*.

1. Click *Create pull request*.

1. Double-check the title and description for the pull request, and modify them if necessary.

1. Click *Create pull request*.

All changes saved on the draft branch will now be published to docs.dataminer.services.

### Working on an existing pull request

After you have made a pull request and before it is merged into the main branch by the Skyline documentation team, it is possible to continue working on that existing pull request.

You can do so as follows:

1. Change the pull request from a full pull request to a draft pull request.

   1. Go to your pull request on GitHub.

   1. In the *Reviewers* tab in the top right, select *Convert to draft*.

      ![Convert to draft](~/images/Convert_To_Draft.png)

1. Open GitHub Desktop and select *Current branch*.

1. In the *Pull requests* tab, select the pull request you want to continue working on. Your current branch will now have changed.

   ![Pull Request](~/images/Pull_Request.png)

1. Open the branch in Visual Studio Code. You can do so by clicking the *Open in Visual Studio Code* button in GitHub Desktop.

1. Make your changes in Visual Studio Code and make sure they are saved. Keep the items listed under [Things to watch out for](#things-to-watch-out-for) in mind.

1. In GitHub Desktop, add a short summary of your changes in the box in the lower right corner. Optionally, you can also add a description. Then click the *Commit* button. This commit will now be added to the previous pull request.

1. When the pull request is ready to be merged, you can click *Ready for review* on the pull request page to change it from a draft into a full pull request.

### Making a local test build before pushing changes

Before you push your changes to the repository, it is often a good idea to make a test build on your local machine. This is especially the case if your changes involve adding or removing files, adding cross-references, changing headers, and/or updating a toc.yml file.

To be able to make a local test build, you need to have DocFX installed. DocFX is the static website generator that is used under the hood to create the <https://docs.dataminer.services/> website.

#### Installing and configuring DocFX

1. Install .NET 6.0 SDK or higher from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

1. Open a command prompt and enter the command `dotnet tool update -g docfx`

1. Test whether DocFX was installed correctly by entering `docfx --version`.

    If information similar to the following text is returned, DocFX was installed correctly:

    ```txt
    2.67.3+f28165af43dde2ec072a79fa2479f475fcd947ad
    ...
    ```

> [!TIP]
> Alternative ways to install DocFX can be found on the [DocFX website](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool).

> [!NOTE]
> If you use this "dotnet" command, it is no longer necessary to add the DocFX folder to the Windows Path variable as was the case in the past. If you configured this earlier, we recommend that you remove this folder from the Path variable again and reboot.

#### Making a test build

##### Making a test build using buildDocs.cmd

1. Make sure **.NET 6.0 SDK or higher** is installed on your machine. You can download the latest version from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

1. Go to the root folder of the repository on your local machine, e.g. `C:\GitHub\dataminer-docs\dataminer-docs`.

1. Double-click the file *buildDocs.cmd*.

   This will open a command window where the following commands will run:

   - `dotnet restore "src/NuGetPackages"`

   - `dotnet build "src/NuGetPackages" --configuration Release`

   - `docfx metadata`

   - `docfx build`

   - `docfx serve _site`

1. In a browser, go to <http://localhost:8080/> to preview the website.

   > [!NOTE]
   > Using the search box when viewing the test website on <http://localhost:8080/> will not return any pages from the test website. The search engine only indexes the published content on <https://docs.dataminer.services/> and will, as such, only return pages from that website.

1. When you have finished previewing the website, close the command window.

> [!NOTE]
> If port 8080 is not available, you will need to run *buildDocs.cmd* from a command prompt with the correct port as an argument, e.g. `buildDocs 8081`.

> [!IMPORTANT]
> If you make test builds often, you may need to occasionally clear the files in the `\dataminer-docs\obj\.cache\build\` folder of your local version of the documentation. Depending on your DocFX version, these can pile up and take up a large amount of memory in the long run.

##### Making a test build in the Visual Studio Code terminal

If you make repeated test builds to check changes you have made, and you are only making changes to markdown files, you can also run these commands manually in the Visual Studio Code terminal. This has the advantage that you do not need to run all of the commands every time, so your test builds can be generated more quickly.

1. If no Terminal pane is open in Visual Studio Code, go to *Terminal > New Terminal*.

1. In the Terminal pane, do the following:

   1. Enter `clear` to clear the terminal.

   1. Enter the following commands:

      - `dotnet restore "src/NuGetPackages"`

      - `dotnet build "src/NuGetPackages" --configuration Release`

      - `docfx metadata`

      - `docfx build`

      - `docfx serve _site`

      > [!NOTE]
      >
      > - The first three commands are needed to generate the API docs. If you make repeated test builds to check changes you have made, and you are only making changes to markdown files, you can skip these three commands after your first build.
      > - This step requires that **.NET 6.0 SDK or higher** is installed on your machine. If this is not installed yet, you will get a build error. You can download the latest version from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

   1. In a browser, go to <http://localhost:8080/> to preview the website.

      > [!TIP]
      > If you are not able to access localhost:8080, you can specify a different port by entering e.g. `docfx serve _site -p 8090`.

      When you have finished previewing the website, in the Terminal pane, press Ctrl+C to exit the preview mode.

      > [!NOTE]
      > Using the search box when viewing the test website on <http://localhost:8080/> will not return any pages from the test website. The search engine only indexes the published content on <https://docs.dataminer.services/> and will, as such, only return pages from that website.

> [!IMPORTANT]
> If you make test builds often, you may need to occasionally clear the files in the `\dataminer-docs\obj\.cache\build\` folder of your local version of the documentation. Depending on your DocFX version, these can pile up and take up a large amount of memory in the long run.

## Markdown syntax

Markdown is a lightweight markup language with plain text formatting syntax. It exists in different "flavors". We make use of DocFX Flavored Markdown (DFM). The easiest way to learn how to work with this is to look at our existing documentation and imitate what you see. You can also find more information about DFM basics below.

For more detailed info about DFM syntax, see [Docs Markdown reference](https://docs.microsoft.com/en-us/contribute/markdown-reference).

### Paragraphs

Each paragraph should be separated from the next paragraph by an empty line. If you do not add this empty line, the paragraphs will be combined into one. For example, the markdown below will be generated as one single paragraph:

```md
My text.
My additional text.
```

This will look like this:

`My text. My additional text.`

To separate these lines into individual paragraphs, an empty line is needed:

```md
My text.

My additional text.
```

> [!NOTE]
> Every page should also end in an empty line.

### Italics and bold

To display text in bold, add two asterisks before and after the text.

For example:

```md
This is an example of **bold** text.
```

To display text in italics, add an asterisk before and after the text.

For example:

```md
This is an example of *italics*.
```

> [!NOTE]
> If you use underscores instead of asterisks to display text in italics, this will also be displayed correctly in our documentation. However, for the sake of consistency, this is not recommended.

### Lists

DFM supports both bulleted and numbered lists. Use numbered lists if the order of the list items is important, for example in a procedure where each list item represents a step of the procedure. Otherwise, use bulleted lists.

To create a bulleted list, add a hyphen at the start of each list item. For example:

```md
- A list item
- Another list item
```

To create a numbered list, add "1. " at the start of each list item. For example:

```md
1. First list item
1. Second list item
```

When the documentation is generated, the numbering will automatically be adjusted to a correctly numbered list.

While it is possible to use "1. ", "2. ", "3. ", etc., we do not recommend this, as it can lead to a lot of needless editing if something is added or removed in an existing numbered list.

> [!NOTE]
> Unlike for regular paragraphs, it is not necessary to leave an empty line between the different items of the same list (although you can do so if you prefer this). However, there must always be an empty line before and after a list.

### Indents

To create an indented paragraph, add spaces before the paragraph. If you want to use indented paragraphs with bulleted or numbered lists, make sure the number of spaces matches the number of characters in front of the list text, so that the text is aligned correctly. For example:

```md
1. First list item

   Indented text in between the list items.

1. Second list item
```

If you use an inconsistent number of spaces, the indentation may not be displayed correctly.

It is also possible to add indented lists and to add indented paragraphs in between those. Just make sure the spacing is always consistent. For example:

```md
1. First main list item

   Indented text in between the list items, introducing another list:

   1. First list item
   1. Second list item

      Indented text in between the list items

   1. Third list item

1. Second main list item
```

### Headings

Headings are indicated with a hash symbol. Add one hash symbol in front of the title at the top of each page. For subsequent headings, use a number of hash symbols corresponding with the header level.

For example:

```md
# Page title: heading level 1

## First sublevel: heading level 2

### Second sublevel: heading level 3

#### Third sublevel: heading level 4.

##### Fourth sublevel: heading level 5.
```

Do not skip heading levels. For example, do not use heading level 3 right after heading level 1 while there is no heading level 2 in between.

You can use up to five heading levels on a single page. If you need more levels, you will need to divide your content over several pages.

### Tables

To create a table, use pipe characters to show the column edges. Each table should have a header row, which is followed by a row where dashes fill in the space between the pipe characters. For example:

```md
| Column name | Another Column name |
|-------------|---------------------|
| Column text | More column text    |
| Column text | More column text   |
```

You can align the pipe characters so that the table also looks like a table in the Markdown source, but this is not necessary. If you specify the table above as follows, it will look exactly the same in the published version of the documentation:

```md
| Column name | Another Column name |
|--|--|
| Column text | More column text |
| Column text | More column text |
```

If table cells contain a lot of text, it can be next to impossible to keep everything neatly aligned in the Markdown source, so in that case this second syntax may be preferable. Just make sure you use the correct number of pipe characters so that your number of columns is the same in each row, otherwise the table will not be generated correctly.

Also note that you can align table columns by using colons. See the following example:

```md
| Fun                  | With                 | Tables          |
| :------------------- | -------------------: |:---------------:|
| left-aligned column  | right-aligned column | centered column |
| $100                 | $100                 | $100            |
| $10                  | $10                  | $10             |
| $1                   | $1                   | $1              |
```

### Code blocks

To display code examples in separate code blocks, place three backquotes (```) above and below those blocks. In addition, next to the three backquotes above the blocks, specify the type of code, e.g. *csharp*, *md*, *xml*, etc.

To display inline code within a paragraph, add a backquote before and after the code.

### Links and cross-references

To add a link, place the link text that should be displayed in square brackets, followed by the link itself in parentheses. For example:

```md
For more detailed info about DFM syntax, see [Docs Markdown reference](https://docs.microsoft.com/en-us/contribute/markdown-reference).
```

To add a cross-reference, i.e. a link to another page in the documentation, use the same format, but specify the link in the format "xref:uid". For example:

```md
See [Basic concepts](xref:BasicConcepts).
```

To find this UID, open the page you want to link to in the repository. Each page has a UID specified at the top. For example, for the current page, this looks like this:

```md
---
uid: contributing
---
```

To add a cross-reference to a header on the same page as the cross-reference itself, do not specify "xref:", but instead add a hash followed by the header text, lowercase without special characters and with hyphens instead of spaces. For example:

```md
If you are unfamiliar with this syntax, refer to [Markdown syntax](#markdown-syntax).
```

To add a cross-reference to a specific header of a different page in the documentation, use the "xref:uid" syntax, followed by a hash and the header text, specified in the same way as for a link on the same page. For example:

```md
See [System components](xref:BasicConcepts#system-components).
```

### Images

To add an image, first place the image in the correct folder in the repository. For example, to add an image for the user guide section of the documentation, add the image in the folder "user-guide/images".

To then display the image in the text, use the following syntax:

```md
![Alt text](~/folder containing the images folder/images/ImageName.png)
```

For example:

```md
![Awards](~/dataminer-overview/images/awards.png)
```

> [!NOTE]
> To upload images, use GitHub Desktop. See [Making a larger contribution](#making-a-larger-contribution).

### Alerts

It is possible to display special "alert" blocks that focus the reader's attention on something important. The following types of alerts are supported:

```md
> [!NOTE]
> Information that should stand out from the rest of the text.

> [!TIP]
> Optional information that could be helpful. This is for example used for cross-references to sections with other information that may be relevant.

> [!IMPORTANT]
> Essential information that users must definitely keep in mind.

> [!CAUTION]
> Information about possible negative consequences of an action.

> [!WARNING]
> Information about dangerous consequences of an action.
```

These alerts are displayed as follows:

> [!NOTE]
> Information that should stand out from the rest of the text.

> [!TIP]
> Optional information that could be helpful. This is for example used for cross-references to sections with other information that may be relevant.

> [!IMPORTANT]
> Essential information that users must definitely keep in mind.

> [!CAUTION]
> Information about possible negative consequences of an action.

> [!WARNING]
> Information about dangerous consequences of an action.

### Reserved characters

Some characters, such as angle brackets and backslashes, are used as part of the Markdown syntax. If you want to just display these characters, this may not work. Add a backslash in front of such a character to make sure it is displayed correctly.

For example, to make sure `<script name>` is displayed correctly, specify `\<script name>` instead.

This is not necessary in text that is formatted as inline code or as a code block (using backquotes).

## Tips for writing documentation

To allow easier editing and ensure consistency with the rest of the documentation, keep the following things in mind when you write a new section in the documentation.

### Use numbered lists for procedures

When you add a procedure that consists of several steps, use a **numbered list**, and make sure each list item corresponds with one step in the procedure. This way the user will have a clear overview of the different steps.

If you want to add information related to a step that is not actually something the user needs to do (e.g. the result of a step), add this as an indented paragraph in the list.

For example:

1. Click *Add*.

   A pop-up window will open.

1. Fill in the boxes in the pop-up window.

> [!TIP]
> In your list, just use the prefix "1." for each item. The list will automatically be updated to the correct numbering when the documentation is generated. Creating lists this way allows you to add items in the list without having to manually alter the numbering for every item that follows them. See also the [Microsoft Docs Contributor Guide](https://learn.microsoft.com/en-us/contribute/markdown-reference#numbered-list).

### Only use numbered lists when needed

Only use numbered lists if the order of each list item is important. If you for instance want to enumerate several things, but their order does not matter, use a **bulleted list** (using the prefix "-" for each item).

### Avoid contractions

Avoid contractions (e.g. you're, they're, it's). In formal documentation, these are not usually used.

### Use italic type for UI text

Exact references to text in the UI are usually displayed in italic type. This can help to avoid confusion, as otherwise it may not always be clear which part of the text is a UI reference.

For example: "Below *Exclusions*, click *Add exclusion* and select either *Protocol* or the name of the app."

### Use double quotation marks except in titles

In accordance with the [Microsoft style guide](https://docs.microsoft.com/en-us/style-guide/punctuation/quotation-marks), double quotation marks are used in our documentation instead of single quotation marks.

However, there is one exception to this. Because DocFX cannot handle double quotation marks in titles, try to avoid quotation marks in them as much as possible or use single quotation marks if you cannot do without.

### Think twice about screenshots

Be careful when you use screenshots of the DataMiner Cube UI, as these can get outdated quickly. For this reason, do not use screenshots if this has no added value.

If you do add a screenshot, ideally there should be some indication of the version of the software displayed in the screenshot, so it is clear if the screenshot is outdated.

### Address the reader directly

Avoid writing about your reader as "the user", but instead use "you".

The only time when "the user" is appropriate is when whoever you are writing for will create or configure something for another user, and it is that other user you want to indicate.

**Examples:**

- *You can find more information on DataMiner Dojo.* (Instead of *The user can find more information on DataMiner Dojo.*)

- *When you add a feed component to a dashboard, the user of the dashboard will be able to select a feed.*

## Troubleshooting

### There is a duplicate item in the TOC even though it only occurs once in the toc.yml

**Symptom**: An item shows up twice in the table of contents even though it was only entered once in the *toc.yml*.

**Resolution**: Make sure there is no hyphen in front of the topicUid line. Only the name line should be preceded by a hyphen.

![TOC](~/images/TOC.png)

### No instances of MSBuild could be detected

**Symptom**: When trying to create a build, you get the exception "No instances of MSBuild could be detected".

**Resolution**: If you only have .NET 7 installed, and not .NET 6, adjust the .csproj file in the build folder of the repository so that it targets "net7.0" instead of "net6.0".

### Build failed because assembly or file could not be loaded

**Symptom**: When you try to create a test build, this fails with the following error:

```txt
   Build failed.
   [22-11-04 12:34:56.248]Warning:[ImportPlugins]Skipping file D:\DocFX\plugins_2xobfivj.yks\plugins\System.Memory.dll due to load failure: Could 
   not load file or assembly 'System.Memory, Version=4.0.1.2, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' or one of its dependencies. 
   The located assembly's manifest definition does not match the assembly reference.
   (Exception from HRESULT: 0x80131040)
```

**Resolution**: Install [the latest version of DocFX](#installing-and-configuring-docfx).

### Build failed because config or content files are missing

**Symptom**: When you try to create a test build, this fails with the following error:

```txt
   Build failed.
   [22-11-04 12:34:56.248]Error:Either provide config file or specify content files to start building documentation.
           O Warning(s)
           1 Error(s)
```

**Resolution**: This issue occurs if you try to make a build of only part of the repository. There are specific files in the root of the repository that are needed to be able to start building documentation, so make sure you always create your test builds based on the complete repository.

### Recent changes do not show up in a build

**Symptom**: When you create a test build, it does not include your recent changes.

**Resolution**: Make sure your changes are all saved. If the *Explorer* icon in the top-left corner shows a blue circle with a number in it, there are unsaved changes in a number of files corresponding with that number. The files that contain unsaved changes are marked with a white dot in the file header.

![Unsaved changes](~/images/Unsaved_Changes.png)

### GitHub Desktop keeps basing branches on an outdated version of the main branch

**Symptom**: Newly created branches indicate that they were created a longer time ago.

**Resolution**:

- Make sure [your fork is up to date](#make-sure-your-fork-is-up-to-date).

- If you installed Git after you installed GitHub Desktop, remove the repository in GitHub Desktop and add it again.

### GitHub Desktop throws "Author identity unknown" error

**Symptom**: When you try to push a commit using GitHub Desktop, this fails with the following error:

```txt
Author identity unknown

*** Please tell me who you are.

Run

    git config --global user.email "you@example.com"
    git config --global user.name "Your Name"

to set your account's default identity.
Omit ---global to set the identity only in this repository.

fatal: empty ident name (for <>) not allowed
```

**Resolution**:

1. In GitHub Desktop, select *Repository* in the top-left corner and click *Repository settings*.

1. In the *Git config* tab, select *Use my global Git config* and click *Save*.

   ![Git config](~/images/Git_config.png)

### The template does not load correctly in the test build

**Symptom**: When you view your test build, it is not displayed correctly. Among others, no search box is available in the top-right corner.

**Resolution**: Install [the latest version of DocFX](#installing-and-configuring-docfx).

> [!TIP]
> You can use the command `docfx help` to check which version is installed.

> [!NOTE]
> If you have upgraded DocFX, but this upgrade does not seem to have taken effect, check whether you have a path parameter configured that leads to an older version. Go to *Edit the system environment variables* > *Advanced* > *Environment Variables*, select the *Path* parameter, if available, and click *Edit*. If an entry is listed that goes to a DocFX folder containing an old version of DocFX, delete that entry.

## References

As our way of working is very similar to the approach used for Microsoft Docs, it can be useful to take a look at the [Microsoft Docs Contributor Guide](https://docs.microsoft.com/en-us/contribute/) for additional information and guidelines.

For more information about DocFX, you can also refer to [Getting Started with DocFX](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html).

For more information on GitHub pull requests, see [Pull requests](https://docs.github.com/en/pull-requests).
