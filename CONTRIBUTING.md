---
uid: contributing
---

# Contributing to the DataMiner docs

Welcome to the docs.dataminer.services contributor guide!

Our documentation is open to contributions from any user. Contributions are created, reviewed, and merged via GitHub. This page will explain how you can add and review contributions, ranging from simple changes to a single page, to larger changes where entire sections of the documentation are added or modified.

## General guidelines

- Use **US English** spelling when you contribute to the DataMiner documentation.

- Try to conform to the [Microsoft Style Guide](https://docs.microsoft.com/en-us/style-guide/) as much as possible.

- Use DocFX Flavored Markdown (DFM). If you are unfamiliar with this syntax, refer to [Markdown syntax](#markdown-syntax) below.

- Do not make changes to the root folder of the repository, to the *.github* folder, or to the *templates* folder. As a rule, such changes will be rejected.

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

### Code blocks

To display code examples in separate code blocks, place three backquotes ("`") above and below those blocks. In addition, next to the three backquotes above the blocks, specify the type of code, e.g. *csharp*, *md*, *xml*, etc.

To display inline code within a paragraph, add a backquote before and after the code.

### Links and cross-references

To add a link, place the link text that should be displayed in square brackets, followed by the link itself in parentheses. For example:

```md
For more detailed info about DFM syntax, see [Docs Markdown reference](https://docs.microsoft.com/en-us/contribute/markdown-reference).
```

To add a cross-reference, i.e. a link to another page in the documentation, use the same format, but specify the link in the format "xref:uid". For example:

```md
See [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).
```

To find this UID, open the page you want to link to in the repository. Each page has a UID specified at the top. For example, for the current page, this looks like this:

```md
---
uid: contributing
---
```

To add a cross-reference to a header on the same page as the cross-reference itself, do not specify "xref:", but instead add a hash followed by the header text, without special characters and with hyphens instead of spaces. For example:

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

## Doing a quick edit to a page

On every page of the documentation on docs.dataminer.services, an *Improve this doc* link is available in the top-right corner. Clicking this link will open the source of the documentation on GitHub. You can then make changes as follows:

![Improve this doc link](~/images/Contrib_ImproveThisDoc.png)

1. Make sure you are logged in to GitHub.

1. On the page you intend to edit in GitHub, click the pencil button in the top-right corner.

   ![Pencil button](~/images/Contrib_PencilButton.png)

   This will create a "fork" of the documentation, i.e. a copy where you can freely make changes.

1. Make your changes using the web editor. To get a preview of the changes, go to the *Preview* tab.

1. Once you have made your changes, scroll to the bottom of the page. Enter a title and description for your changes and click *Propose changes*. For example:

   ![Proposing changes](~/images/Contrib_ProposeChanges.png)

1. A page will be displayed with a summary of your changes. At the top of the page, click *Create pull request*. A “pull request” is a request to pull changes into the repository.

1. Double-check the title and description for the pull request, and modify them if necessary. We recommend that you select the option *Allow edits by maintainers*, so that the documentation team will be able to correct any small issues (e.g. typos) directly.

1. Click *Create pull request*.

   ![Create a pull request for your changes](~/images/Contrib_CreatePullRequestForChanges.png)

   The documentation team will review the request and merge it if it is approved. If changes are needed before it can be merged, you will receive feedback.

   > [!NOTE]
   > Do not forget to create a pull request! Otherwise, your changes may be lost.

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

For larger contributions, e.g. to add several new pages, we recommend that you install the following (free) software:

- [GitHub Desktop](https://desktop.github.com/)

- [Visual Studio Code](https://code.visualstudio.com/) (with the [Docs Authoring Pack](https://marketplace.visualstudio.com/items?itemName=docsmsft.docs-authoring-pack) extension)

When you install GitHub Desktop, you will also need to add the correct repository:

1. Install GitHub Desktop and log in with your GitHub account.

1. Select *Create a New Repository on your hard drive*.

   ![Install GitHub 1](~/images/InstallGithub1.png)

1. Next, you will be asked which repository you want to use. Clone the *SkylineCommunications/dataminer-docs* repository to your local machine. The easiest way to do so is by specifying the URL `https://github.com/SkylineCommunications/dataminer-docs` in the URL tab.

   ![Install GitHub 2](~/images/InstallGithub2.png)

1. If you do not have write access to the repository, you will find an alert in the lower left corner.

   ![Install GitHub3](~/images/InstallGitHub3.png)

   If this is the case:

   1. Select *Create a fork*.

   1. Click *Fork this repository*.

      ![Install GitHub 4](~/images/InstallGitHub4.png)

   1. When you are asked how you are planning to use this fork, select *To contribute to the parent project*.

> [!NOTE]
> If you have already made a fork of the repository in the past, you can also immediately add this fork as the URL when you clone the repository (e.g. `https://github.com/MyGitHubName/dataminer-docs`).

> [!TIP]
> Creating a fork will allow you to make changes that you can then add to a pull request. If Visual Studio Code has been installed, you can click *Open in Visual Studio Code* to immediately start working on the fork.
>
> ![GitHub Desktop](~/images/Contrib_GitHubDesktop.png)

For more information on how to work with Visual Studio Code, refer to the [Visual Studio Code documentation](https://code.visualstudio.com/docs). As our documentation is written in Markdown, aside from the general functionality of the application, the [Markdown](https://code.visualstudio.com/docs/languages/markdown) section is of specific interest there.

Also keep in mind that we are using **DocFX Flavored Markdown**. Refer to the [Markdown syntax](#markdown-syntax) section above for more information about this. Make sure the Docs Authoring Pack extension is installed in Visual Studio Code to make it easier to work with this Markdown flavor.

### Things to watch out for

#### Make sure your fork is up to date

When you are working on your own fork, make sure you regularly **check in GitHub whether your fork is still up to date** with the main repository. To do so:

1. Go to <https://github.com/SkylineCommunications/dataminer-docs>.

1. In the About section on the right, click the link to the forks:

   ![Link to forks](~/images/Contrib_Forks.png)

1. Look up your fork in the list, and click the link to go the page for your own fork.

1. Check the top of your fork page. If it says the branch is a number of commits behind SkylineCommunications:main, your fork is no longer up to date. If there is no such indication, there is no need to continue with this procedure.

   ![Indication of outdated fork](~/user-guide/images/Contributing_Sync_Fork.png)

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
  - name: Connecting your DataMiner System to the cloud
    topicUid: Connecting_your_DataMiner_System_to_the_cloud
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

1. Go to your fork on GitHub (see [Things to watch out for](#things-to-watch-out-for) for more information on how to get to your fork), and select *Contribute* > *Open pull request*.

   ![Open pull request](~/images/Contrib_OpenPullRequest.png)

   This will open another overview of the changes that will be included in the pull request.

1. At the top, click *Create pull request*.

   > [!NOTE]
   > You can also create a draft pull request, for example if you still want to have someone else make changes before the pull request can be merged. In that case, click the triangle button next to *Create pull request* and select *Create draft pull request*.
   >
   > ![Create draft pull request](~/images/Contrib_draftPR.png)
   >
   > When the pull request is ready to be merged, you can click *Ready for review* on the pull request page to change it from a draft into a full pull request.

1. Specify a title for the pull request, and optionally add a comment with more information about your changes.

   > [!NOTE]
   > We recommend that you keep the option *Allow edits by maintainers* selected, so that the documentation team will be able to correct any small issues directly. Note that if you instead see the option *Allow edits and access to secrets by maintainers*, this means that the pull request includes workflows of your forked repository, which means you could potentially reveal values of secrets and grant access to other branches if you allow edits. If you do not want this, do not select this option.

1. Click *Create pull request*. Your pull request will now be submitted for review.

   The documentation team will review the request and merge it if it is approved. If changes are needed before it can be merged, you will receive feedback.

### Collaborating with others on a draft branch

When you work together with several other people to add new information to the documentation, it can be useful to work together on the same draft branch without publishing your changes to the main branch yet. This way, you can add multiple changes that others can then further work on, but nothing will be published on docs.dataminer.services yet.

You can do so as follows:

1. Select the draft branch you want to use in GitHub Desktop.

   If the branch does not exist yet, ask <team.technical.writing@skyline.be> to create it. If you were to create a new branch in your fork of the repository instead, other people would not be able to contribute to it as easily.

   ![Select the draft branch](~/images/Contrib_SelectDraftBranch.png)

1. Open the branch in Visual Studio Code. You can do so by clicking the *Open in Visual Studio Code* button in GitHub Desktop.

1. Make your changes in Visual Studio Code and make sure they are saved. Keep the items listed under [Things to watch out](#things-to-watch-out-for) for in mind.

1. In GitHub Desktop, add a short summary of your changes in the box in the lower right corner. Optionally, you can also add a description. Then click the *Commit* button.

   ![Commit to the draft branch](~/images/Contrib_CommitToDraftBranch.png)

1. Click *Push origin* to push the changes to the remote.

   ![Push the commit to the remote](~/images/Contrib_PushDraft.png)

   > [!NOTE]
   > If you see *Push upstream* instead of *Push origin*, you are attempting to work directly on the repository instead of on a fork, which means you will get an error when you click this button as you do not have the rights to push directly to the repository. Make sure you are using a fork as detailed in [Cloning and forking repositories from GitHub Desktop](https://docs.github.com/en/desktop/contributing-and-collaborating-using-github-desktop/adding-and-cloning-repositories/cloning-and-forking-repositories-from-github-desktop).

1. Click the *Create Pull Request* button. This will open GitHub in a browser.

   ![Create Pull Request](~/images/Contrib_CreatePullRequest.png)

1. In the browser, make sure that the base you are merging to is the draft branch. If a different base branch is selected, make sure to select the correct branch.

   ![Create Pull Request](~/images/Contrib_DraftBranchForPullRequest.png)

1. Click *Create pull request*.

The Skyline documentation team will then need to merge your pull request, so that it becomes available in the branch for other people as well. This can take some time. We recommend that you enable notifications in your account settings so that you get a notification when the merge is done. When your pull request has been merged, others can continue to work on your changes as described above.

When all the necessary changes have been made and the draft branch is ready for publication, create a pull request as detailed above, but select the main branch instead of the draft branch as the base.

### Making a local test build before pushing changes

Before you push your changes to the repository, it is often a good idea to make a test build on your local machine. This is especially the case if your changes involve adding or removing files, adding cross-references, changing headers, and/or updating a toc.yml file.

To be able to make a local test build, you need to have DocFX installed. DocFX is the static website generator that is used under the hood to create the <https://docs.dataminer.services/> website.

#### Installing and configuring DocFX

1. Go to <https://github.com/dotnet/docfx/releases>, and download the latest version of the `docfx.zip` package (e.g. version 2.59.4).

    > [!CAUTION]
    > We recommend that you do not use any of the beta versions.

1. Extract `docfx.zip` to a folder of your choice (e.g. `C:\DocFX`).

1. Add the folder (e.g. `C:\DocFX`) to the environment variable **Path** (user variable or system variable).

    On Windows 10 or 11 systems, do the following:

    1. In your Windows search box, enter "path".
    1. Click *Edit the system environment variables*.
    1. In the *Advanced* tab of the *System Properties* window, click *Environment Variables*.
    1. In the *Environment Variables* window, select the **Path** variable in either the *User variables for \<user\>* list or the *System variables* list, and click *Edit*.
    1. In the *Edit environment variable* window, click *New*, enter e.g. `C:\DocFX`, and click *OK*.

1. Test whether DocFX was installed correctly:

    1. Open a command prompt.
    1. Enter `docfx help`.

    If information similar to the following text is returned, DocFX was installed correctly:

    ```txt
    docfx 2.58.4.0
    Copyright (C) 2022 ¸ Microsoft Corporation. All rights reserved.
    This is open-source software under MIT License.  
    ...
    ```

> [!TIP]
> Alternative ways to install DocFX can be found on the [DocFX website](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool).

#### First-time setup

Before you make your first test build, we recommend the first-time setup detailed below. If you do not do this, you will still be able to make a test build, but there may be many warnings in the terminal, and some pages may not be included in the build.

1. Check if your fork is up to date with the latest changes from the main dataminer-docs repository (See [Make sure your fork is up to date](#make-sure-your-fork-is-up-to-date).

1. Make sure you have Visual Studio 2019 or higher installed.

1. Install the .NET framework SDK Developer Pack. To do so, go to <https://dotnet.microsoft.com/en-us/download/visual-studio-sdks> and choose the .NET Framework 4.8 Developer Pack.

1. Go to the folder containing your dataminer-docs repository.

   > [!TIP]
   > To quickly find this folder from Visual Studio Code, right-click a folder from the repository in the Explorer tab and select *Reveal in File Explorer*.

   1. In the `\dataminer-docs\src\DataMiner\` subfolder open the folder *Dataminer.sln* with Visual Studio.

   1. Go to the solution explorer in the top-right corner, right-click the solution node and select *Restore NuGet Packages*.

      ![Restore Nuget Packages](~/user-guide/images/Contributing_Solution_Node.png)

   1. Start a build by pressing CTR+SHIFT+b.

   1. Repeat the steps above for the file *Code Library.sln* in the `dataminer-docs\src\Base Class Library\` subfolder of the repository.

1. Open Visual Studio Code and go to *Terminal* > *New Terminal*.

1. In the terminal, enter `docfx metadata -f`.

   If everything is OK, you will get no warnings.

> [!NOTE]
> It is not necessary to do this for every test build. However, when there have been significant changes to the source code, you will need to do this procedure again starting from step 4.

#### Making a test build

1. If no Terminal pane is open in Visual Studio Code, go to *Terminal > New Terminal*.

1. In the Terminal pane, do the following:

   1. Enter `clear` to clear the terminal.

   1. Enter `docfx build -f` to make a test build.

      > [!NOTE]
      > If you get a lot of warnings when you try to create a test build, it could be that you need to do part of the [first-time setup](#first-time-setup) again to make sure the metadata are up to date.

   1. Enter `docfx serve _site`.

   1. In a browser, go to <http://localhost:8080/> to preview the website.

      > [!TIP]
      > If you are not able to access localhost:8080, you can specify a different port by entering e.g. `docfx serve _site -p 8090`.

      When you have finished previewing the website, in the Terminal pane, press ENTER to exit the preview mode.

      > [!NOTE]
      > Using the search box when viewing the test website on <http://localhost:8080/> will not return any pages from the test website. The search engine only indexes the published content on <https://docs.dataminer.services/> and will, as such, only return pages from that website.

> [!IMPORTANT]
> If you make test builds often, you may need to occasionally clear the files in the `\dataminer-docs\obj\.cache\build\` folder of your local version of the documentation. In the long run, these can pile up and take up a large amount of memory.

## References

As our way of working is very similar to the approach used for Microsoft Docs, it can be useful to take a look at the [Microsoft Docs Contributor Guide](https://docs.microsoft.com/en-us/contribute/) for additional information and guidelines.

For more information about DocFX, you can also refer to [Getting Started with DocFX](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html).

For more information on GitHub pull requests, see [Pull requests](https://docs.github.com/en/pull-requests).
