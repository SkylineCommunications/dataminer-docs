---
uid: CTB_Collaborating_Draft_Branch
---

# Collaborating with others on a draft branch

When you work together with several other people to add new information to the documentation, it can be useful to work together on the same draft branch without publishing your changes to the main branch yet. This way, you can add multiple changes that others can then further work on, but nothing will be published on docs.dataminer.services yet.

![Create pull request to draft branch](~/images/Pull_Request_Draft_Branch.png)

You can do so as follows:

1. Select the draft branch you want to use in GitHub Desktop.

   If the branch does not exist yet, ask <team.technical.writing@skyline.be> to create it. If you were to create a new branch in your fork of the repository instead, other people would not be able to contribute to it as easily.

   ![Select the draft branch](~/images/Contrib_SelectDraftBranch.png)

1. Open the branch in Visual Studio Code. You can do so by clicking the *Open in Visual Studio Code* button in GitHub Desktop.

1. Make your changes in Visual Studio Code and make sure they are saved. Keep the items listed under [Things to watch out for](xref:CTB_Watch_out_for) in mind.

1. In GitHub Desktop, add a short summary of your changes in the box in the lower-right corner. Optionally, you can also add a description. Then click the *Commit* button.

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

## Keeping the draft branch up to date in your fork

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

## Creating the final pull request to merge the draft branch

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
