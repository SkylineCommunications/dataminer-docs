---
uid: CTB_Creating_PR
---

# Creating a pull request

When your changes are ready, you can create a pull request to submit them for review:

1. Make sure you have saved your changes in Visual Studio Code. As long as a blue circle is displayed on top of the topmost icon in the sidebar on the left, there are still unsaved changes. The number in this circle indicates the number of files with unsaved changes.

   ![Example of unsaved changes](~/images/Contrib_UnsavedChanges.png)

1. Check the overview of your changes in GitHub Desktop.

1. If all changes are OK, fill in a title for the update in the *Summary* box in the lower-right corner and click the *Commit* button.

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
