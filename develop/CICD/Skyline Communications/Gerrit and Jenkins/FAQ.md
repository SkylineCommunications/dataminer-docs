---
uid: FAQ
---

# FAQ

In this section, you can find answers to a number of frequently asked questions.

Regarding protocol development:

- [How do I start the development of a brand-new protocol?](#how-do-i-start-the-development-of-a-brand-new-protocol)

- [How do I start the development of a new version in an existing range of an existing protocol?](#how-do-i-start-the-development-of-a-new-version-in-an-existing-range-of-an-existing-protocol)

- [How do I start the development of a new range of an existing protocol?](#how-do-i-start-the-development-of-a-new-range-of-an-existing-protocol)

- [I'm still busy developing but I want to push my work to the remote repository so I have a backup on Gerrit. How do I do this?](#im-still-busy-developing-but-i-want-to-push-my-work-to-the-remote-repository-so-i-have-a-backup-on-gerrit-how-do-i-do-this)

- [I'm still busy developing but I want to push my work to the remote repository to let the pipeline run. How do I this?](#im-still-busy-developing-but-i-want-to-push-my-work-to-the-remote-repository-to-let-the-pipeline-run-how-do-i-this)

- [Where do I provide the protocol development checklist?](#where-do-i-provide-the-protocol-development-checklist)

- [I only have a very small fix to perform and therefore I do not require it to go through code review. Is this possible?](#i-only-have-a-very-small-fix-to-perform-and-therefore-i-do-not-require-it-to-go-through-code-review-is-this-possible)

- [I finished development. How do I create a tag for the new version?](#i-finished-development-how-do-i-create-a-tag-for-the-new-version)

- [I started a new minor version but now it appears that my additional changes introduce a major change. How do I fix this?](#i-started-a-new-minor-version-but-now-it-appears-that-my-additional-changes-introduce-a-major-change-how-do-i-fix-this)

- [I realized I have been committing and pushing to the wrong branch. How do I fix this?](#i-realized-i-have-been-committing-and-pushing-to-the-wrong-branch-how-do-i-fix-this)

- [I want to apply a fix to multiple ranges. How do I do this?](#i-want-to-apply-a-fix-to-multiple-ranges-how-do-i-do-this)

- [How can I work in parallel with other developers?](#how-can-i-work-in-parallel-with-other-developers)

Regarding Gerrit code review:

- [I have finished development of a feature and want this to get reviewed. How do I do this?](#i-have-finished-development-of-a-feature-and-want-this-to-get-reviewed-how-do-i-do-this)

- [I received an email stating that I should perform a code review. How do I do this?](#i-received-an-email-stating-that-i-should-perform-a-code-review-how-do-i-do-this)

- [I received an email notifying me that a code review failed. How do I continue?](#i-received-an-email-notifying-me-that-a-code-review-failed-how-do-i-continue)

- [I received an email notifying me that a code review failed. How do I continue?](#i-received-an-email-notifying-me-that-a-code-review-failed-how-do-i-continue)

### How do I start the development of a brand-new protocol?

To start the development of a new protocol (version 1.0.0.1), perform the following steps:

1. Open the SLC SE Repository Manager tool (part of the Time Registration tool).

1. Click the *Create Repository* button. Provide the name of the vendor and data source and click the *Create* button.

   > [!NOTE]
   > The name of the data source should start with the name of the vendor.

   ![](~/develop/images/SLCSERepoManager_CreateRepo.png)<br>
   *SLC SE Repository Manager: Creating a repository*

1. In the confirmation box, click *Yes*.

   The SLC SE Repository Manager tool will automatically clone the remote repository to your configured folder.

1. Create a new DataMiner protocol Visual Studio solution in the local repository folder.

   1. Start Visual Studio and go to *File* > *New* > *DataMiner Protocol Solution*.

   1. Specify the protocol name.

   1. For the target location, specify the local Git repository folder that you created earlier.

   1. Click *OK*.

   ![](~/develop/images/VS_NewProtocolSolution.png)<br>
   *New DataMiner Protocol Solution window*

1. Specify the vendor in the protocol.xml file.

1. Open your local repository using SourceTree. You will see that the repository already has a 1.0.0.X branch. Now create a new local branch with the following name: *gerrit/DCP\<TaskID>_\<Description>* (e.g. DCP1234_FixLayout).

   ![](~/develop/images/SourceTree_BranchCreation.png)<br>
   *Creating a branch in SourceTree*

   > [!NOTE]
   > Normally, Sourcetree should automatically switch to this branch. If for some reason this does not happen, switch to this branch manually.

1. Perform an initial commit: Stage all the new files of the newly created Visual Studio solution and provide a commit message, then click *Commit*.

   ![](~/develop/images/SourceTree_InitialCommit.png)<br>
   *Initial commit in SourceTree*

   A new commit will be added to your new branch.

   ![](~/develop/images/SourceTree_CommitAddedToBranch.png)<br>
   *New commit added to new branch in SourceTree*

1. Implement your work, performing as many commits as you want.

   > [!NOTE]
   > Performing a commit only updates your local repository. In case you want to push your work in progress to Gerrit to have a backup on the server, see [I'm still busy developing but I want to push my work to the remote repository so I have a backup on Gerrit. How do I do this?](#im-still-busy-developing-but-i-want-to-push-my-work-to-the-remote-repository-so-i-have-a-backup-on-gerrit-how-do-i-do-this).

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Protocol Development":  CI/CD HowTo - Start a new Protocol Development.

### How do I start the development of a new version in an existing range of an existing protocol?

1. Open the SLC SE Repository Manager tool.

1. Navigate to the vendor in the tree control and verify whether your data source is already listed under that vendor.

   If the data source is already listed under that vendor, the protocol has already been migrated to Git, and you can therefore skip to step 5.

1. If the data source you will work on was not yet listed, click the *Create Repository* button, specify the name of the vendor and data source and click *Create*.

   ![](~/develop/images/SLCSERepoManager_CreateRepoExisting.png)<br>
   *SLC SE Repository Manager: Creating a repository*

1. A confirmation message will be displayed, stating that the protocol was found on SVN and asking if you want to convert this into a Git repository. Click *Yes* to confirm.

   The SLC SE Repository Manager tool will automatically clone the repository.

1. Open the repository in SourceTree.

   > [!NOTE]
   > Always make sure your local repository is up to date.

   ![](~/develop/images/SourceTree_Repo.png)<br>
   *Repository in SourceTree*

   Under REMOTES, you can see the branches that have been defined (in the example above, 1.0.0.X and 2.0.0.X) and in the *Graph* overview, you can see all the versions/tags of this protocol.

1. Check out the range you are going to work on. (By default, range 1.0.0.X is checked out).

   ![](~/develop/images/SourceTree_RangeCheckout.png)<br>
   *Checking out a range in SourceTree*

1. Navigate to the repository folder in File Explorer and verify if the previous version already contains a DataMiner protocol Visual Studio solution. If it does, skip to step 11.

1. If the previous version contained no solution yet, in the *fromSvn* folder, you should find a protocol.xml file. Open this file in Visual Studio and convert it to a Visual Studio solution using DIS.

   1. In Visual Studio, go to *DIS* > *Protocol* > *Convert to Solution*.

      ![](~/develop/images/VS_ConvertToSolution.png)<br>
      *Convert to Solution in DIS*

   1. In the pop-up window, specify the repository path as the target location and click *Convert*.

      ![](~/develop/images/ConvertToSolution.png)<br>
      *Convert Protocol to Solution window*

1. In SourceTree, commit the solution you created in the previous step.

   ![](~/develop/images/SourceTree_CommitSolution.png)<br>
   *Committing a solution in SourceTree*

1. In Sourcetree, push the commit to the server

   ![](~/develop/images/SourceTree_PushCommit.png)<br>
   *Pushing a commit to the server in SourceTree*

1. Create a new local branch with the following name: *gerrit/DCP\<TaskID>_\<Description>* (e.g. DCP1234_FixLayout).

   ![](~/develop/images/SourceTree_NewLocalBranch.png)<br>
   *Creating a new local branch in SourceTree*

   > [!NOTE]
   > Normally, Sourcetree should automatically switch to this branch. If for some reason this does not happen, switch to this branch manually.

1. Start development on the new branch.

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Protocol Development":  CI/CD HowTo - Start a protocol from an existing one on SVN

### How do I start the development of a new range of an existing protocol?

This is very similar to creating a new version in an existing range branch. Before you create your Gerrit task branch, perform the following steps:

1. Check out the range branch for which you want to create a new branch. For example, if you need to create a 2.0.1.X branch, first check out the 2.0.0.X range branch.

1. Create the new range branch, for example 2.0.1.X.

   ![](~/develop/images/SourceTree_NewRangeBranch.png)<br>
   *Creating a new range branch in SourceTree*

1. Push this branch to the server so the Git repository hosted by Gerrit is aware of this branch.

   ![](~/develop/images/SourceTree_PushNewBranch.png)<br>
   *Pushing a new branch to the server in SourceTree*

1. Create your task branch based on the newly created range branch and start development.

### I'm still busy developing but I want to push my work to the remote repository so I have a backup on Gerrit. How do I do this?

For your development, you will typically have created a branch with name *DCP\<TaskID>_\<Description>* (e.g. DCP1234_FixLayout).

To push this to the remote Git repository so you have a backup on the server (without initiating a code review), click the *Push* button in SourceTree. Select your task branch and click *Push*.

![](~/develop/images/SourceTree_PushToServer.png)<br>
*Pushing work to the remote repository using SourceTree*

Alternatively, you can choose to push your work into Gerrit as work in progress, so that it will not introduce a code review. You can do this in the SLC SE Repository Manager tool. Select the repository in the tree control and click the *Push* button, then select the desired range and click the *Push for Work in Progress* button.

> [!NOTE]
> Be aware that you when you push for work in progress, your commits will be squashed into a single commit. In case this is not something you want, for example because you may want to return to some specific commit, then push your work the remote Git repository using SourceTree.

![](~/develop/images/SLCSERepoManager_PushWIP.png)<br>
*Pushing work into Gerrit as work in progress*

### I'm still busy developing but I want to push my work to the remote repository to let the pipeline run. How do I this?

This means your development is still work in progress.

Because every push to the remote Git repository triggers a run of the pipeline in Jenkins, you can perform the exact same steps as in [I'm still busy developing but I want to push my work to the remote repository so I have a backup on Gerrit. How do I do this?](#im-still-busy-developing-but-i-want-to-push-my-work-to-the-remote-repository-so-i-have-a-backup-on-gerrit-how-do-i-do-this)

### Where do I provide the protocol development checklist?

The protocol development checklist should be included next to the protocol Visual Studio solution in the Git repository.

1. Download the checklist from [Dojo](https://community.dataminer.services/documentation/protocol-development-checklists/).

1. Fill in the checklist.

1. Commit the checklist to your local Git repository using SourceTree.

1. Push the commit. As the checklist itself does not require any code review, you can push the checklist immediately to the remote Git repository hosted by Gerrit using SourceTree.

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Protocol Development":  CI/CD HowTo - Development Checklist and DriverQA.

### I only have a very small fix to perform and therefore I do not require it to go through code review. Is this possible?

In Sourcetree, you can immediately push commits to a range branch in the remote Git repository.

However, be aware that in general a code review phase is required and therefore you will typically push to Gerrit via the SLC SE Repository Manager tool. Only push immediately to Git if you are sure no code review is required for the items you will push, for example when you want to push the checklist.

### I finished development. How do I create a tag for the new version?

1. In the commit overview in SourceTree, select the commit for which you would like to create a tag, right-click, and select *Tag* in the context menu.

   ![](~/develop/images/SourceTree_CreateTag.png)<br>
   *Creating a tag for a commit in SourceTree*

1. Specify the tag name (e.g. "1.0.0.9"), ensure that the *Specified commit* option is selected and select the check box *Push tag*, so that the tag also gets pushed to the remote repository.

   ![](~/develop/images/SourceTree_CreateTagWindow.png)<br>
   *Creating a tag for a commit in SourceTree*

1. Click *Add Tag*. This will make Jenkins perform a final execution of the pipeline for this newly created protocol version. It will detect that you provided a tag and will therefore publish this version on SVN.

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Protocol Development":  CI/CD HowTo - How to release a new version.

### I started a new minor version but now it appears that my additional changes introduce a major change. How do I fix this?

Suppose you started development on a task and assumed that the new version was going to be a new minor version. After you have performed some commits and pushed these to the remote Git repository, the Jenkins pipeline suddenly indicates that a new commit pushed results in a major change. After you verify with the major change request team, they confirm that a new major range is indeed required.

How can you now fix your Git repository?

Suppose you were working on a new version 1.0.0.3 and now you realize that you need to create a new major range 1.0.1.X. The first thing to do is to introduce the new branch with the changes you have made so far:

1. The first step is to select your latest commit in the range you were working on (in this example 1.0.0.X) and select the branch icon in SourceTree to create the a new branch for the new major range.

   ![](~/develop/images/SourceTree_BranchIcon.png)<br>
   *The branch icon in SourceTree*

1. In the pop-up window, provide the name of the new branch (in this example, 1.0.1.X) and click *Create Branch*.

   ![](~/develop/images/SourceTree_CreateBranch.png)<br>
   *Creating a branch in SourceTree*

   You should now see that the new range has been created locally:

   ![](~/develop/images/SourceTree_BranchCreated.png)<br>
   *New local range*

1. Now you also need to push this new range to the remote. To do this, click the *Push* button and, in the pop-up window, select the check box for the new branch and click *Push*.

   ![](~/develop/images/SourceTree_PushRange.png)<br>
   *Pushing a new range in SourceTree*

   You should now see that the new range has been created on the remote as well:

   ![](~/develop/images/NewRangeCreated.png)<br>
   *New range on the remote*

At this point, you have introduced the new branch with the changes you have made so far. What is left to do is to clean up the commits on the 1.0.0.X branch, so that it appears that development on your task started on the 1.0.1.X range from the outset.

> [!IMPORTANT]
> Before starting to clean up commits on the wrong branch, make sure that no one else has made commits to this branch in the meantime.

1. To remove the commits from the 1.0.0.X branch, first make sure this range is the one that is currently checked out.

1. Then select the commit that represents the latest valid commit. This should be the commit that represents the tag of the previous version (in this example, the commit for tag 1.0.0.2).

1. After selecting the commit in the graph overview, right-click and select *Reset current branch to this commit* in the context menu.

   ![](~/develop/images/SourceTree_CurrentBranchToCommit.png)<br>
   *“Reset current branch to this commit” option*

1. In the pop-up window, select the mode *Hard* (this will discard all working copy changes) and click *OK*.

   ![](~/develop/images/SourceTree_ResetToCommit.png)<br>
   *Hard reset mode selection*

1. In the pop-up window asking for confirmation, click *Yes*.

   ![](~/develop/images/DestructiveOperation.png)<br>
   *Confirmation window for hard reset mode*

   At this point, you should see that your head of the local 1.0.0.X branch is pointing to the commit for the 1.0.0.2 tag. However, the head of origin/1.0.0.X is not. This is because we first need to push.

   ![](~/develop/images/PointyBranch.png)<br>
   *1.0.0.X branch is pointing to the commit for the 1.0.0.2 tag*

   > [!NOTE]
   > Pushing a reset is not allowed by default. To enable this, go to *Tools* &gt; *Options*, select the *Git* tab and make sure the check box for the *Enable Force Push* option is checked. ![](../../images/EnableForcePush.png

1. To push, click the *Push* button and make sure the *Force Push* check box is selected. Then click *Push*.

   ![](~/develop/images/ForcePush.png)<br>
   *“Force Push” option*

1. In the confirmation box, click *Yes*.

   ![](~/develop/images/ConfirmForcePush.png)<br>
   *Force Push confirmation box*

    At this point, you should see that head of the origin/1.0.0.X branch is now also pointing to the desired commit.

   ![](~/develop/images/GoodPointyBranch.png)<br>
   *1.0.0.X branch pointing to correct commit*

Your Git repository is now in a correct state again. Now you can checkout the new branch (1.0.1.X) and update the version of the protocol (changing it from 1.0.0.3 to 1.0.1.1) using the protocol Version History editor.

> [!IMPORTANT]
> On DCP, a record may already exist for the minor version you were working on (1.0.0.3 in this example). This record should be removed. Contact IT to take care of this.

### I realized I have been committing and pushing to the wrong branch. How do I fix this?

Suppose for example that you have committed and pushed changes to the 1.0.0.X range, but you really intended to be working on the 1.0.1.X range instead.

![](~/develop/images/ChangeInTheWrongRange.png)<br>
*Changes pushed to 1.0.0.X range*

1. Perform a checkout of the branch you want to work on (in this example 1.0.1.X) and make sure this is your active branch.

1. Now you need to apply the commits on the correct 1.0.1.X branch in the same order as you applied them on the 1.0.0.X branch. To do this, you will apply cherry picking. Select the first commit (in the example *feature 1*) right-click and select *Cherry Pick* in the context menu:

   ![](~/develop/images/CherryPick.png)<br>
   *Cherry pick a commit*

1. In the pop-up window, click *OK*.

   ![](~/develop/images/ConfirmCherryPicking.png)<br>
   *Confirm cherry picking*

1. Repeat this for all the commits you want to have on the current branch.

   ![](~/develop/images/RepeatForBranch.png)<br>
   *Repeat for the commits on the current branch*

1. Push the cherry-picked commits to the remote repository.

   ![](~/develop/images/PushingCherries.png)<br>
   *Push the cherry-picked commits to the remote repository*

   ![](~/develop/images/PushedCherries.png)<br>
   *The cherry-picked commits in the remote repository*

1. Now you will still need to remove the commits on the branch you were originally working on (in this example, 1.0.0.X). To do this, check out the 1.0.0.X branch to make it the active one.

   > [!IMPORTANT]
   > Before you start to clean up commits on the wrong branch, make sure that no one else has made commits to this branch in the meantime.

1. To remove the commits from the 1.0.0.X branch, make sure this range is the one that is currently checked out. Then select the commit that represents the latest valid commit. This should be the commit that represents the tag of the previous version.

1. When you have selected the commit in the graph overview, right-click and select *Reset current branch to this commit* in the context menu.

1. In the pop-up window, select the mode *Hard* (this will discard all working copy changes) and click *OK*.

   ![](~/develop/images/SourceTree_ResetToCommit00077.png)<br>
   *Hard reset mode selection*

1. In the pop-up window asking for confirmation, click *Yes*.

   ![](~/develop/images/DestructiveOperation00078.png)<br>
   *Confirmation window for hard reset mode*

1. At this point, you should see that the head of your local 1.0.0.X branch is pointing to the commit for the 1.0.0.2 tag. However, the head of origin/1.0.0.X is not. This is because you first need to push. To push, select the *Push* button and make sure the *Force Push* check box is checked. Then click *Push*.

1. In the confirmation box, click *Yes* to confirm.

   ![](~/develop/images/ConfirmForcePush00079.png)<br>
   *Force Push confirmation box*

### I want to apply a fix to multiple ranges. How do I do this?

Suppose you created a fix in a specific range that would also be useful in a number of other ranges. To apply a specific commit from a branch to other branches, you can use a technique referred to as cherry picking.

For example, suppose you created a commit in range 1.0.1.X and you want to apply the same fix in 1.0.2.X.

![](~/develop/images/FixedBranch.png)<br>
*Fix in range 1.0.1.X*

1. First, perform a checkout of the branch you want to include the commit (in this example 1.0.2.X).

1. Then select the commit you want to cherry pick, right-click and select *Cherry Pick* in the context menu.

   ![](~/develop/images/CherryPickFix.png)<br>
   *Cherry pick a fix*

1. In the pop-up window, click *OK*.

   ![](~/develop/images/ConfirmCherryPicking00080.png)<br>
   *Confirm cherry picking*

Now you will see that the change has been committed to the 1.0.2.X branch.

![](~/develop/images/FixCommittedToBranch.png)<br>
*Fix in range 1.0.2.X*

At this point you can either cherry pick another commit or continue development (e.g. create a new version on the 1.0.2.X range for this specific fix).

### How can I work in parallel with other developers?

In case you want to work on a protocol that is already being worked on by another developer, make sure to first communicate with the other developer to avoid merge conflicts later on as much as possible (e.g. agree upon different parameter ranges to use, different QActions, etc.).

Then create a new development branch for your development and push it so other developers are aware that you are working on that protocol.

### I have finished development of a feature and want this to get reviewed. How do I do this?

> [!NOTE]
> The procedure below explains how to get your code changes reviewed via Gerrit, which is **optional**. Today, there are other good alternatives, such as simply using the Visual Studio GIT Commits compare feature, etc.

This means you have some work committed and want this work to be reviewed.

1. Open the SLC SE Repository Manager tool, select the protocol you want to push for review in the tree control and select the *Push Repository* button.

   ![](~/develop/images/SLCSERepoManager_PushRepo.png)<br>
   *Pushing a repository in SLC SE Repository Manager*

1. Select the branch you will eventually merge your work into and click the *Push for Gerrit Review* button.

   ![](~/develop/images/SLCSERepoManager_PushForReview.png)<br>
   *Push for Gerrit review*

   > [!NOTE]
   > When you push for review, your commits will be squashed into a single commit. This is because each commit introduces a code review item in Gerrit Code Review. In order to only have one code review item when you perform the push for review, the commits get squashed into a single commit before they are pushed.

1. In Gerrit, select the new entry in the review dashboard in the *Outgoing reviews* section.

   This will open a new page for this item.

   ![](~/develop/images/GerritOutgoingReviews.png)<br>
   *Outgoing reviews in Gerrit*

1. In the *Assignee* field, specify the name of the person who should perform the review.

   ![](~/develop/images/GerritSpecifyAssignee.png)<br>
   *Specifying the name of the reviewer in Gerrit*

   The reviewer will now be notified by email.

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Gerrit Code Review":  CI/CD HowTo - Assign a Gerrit Code Review.

### I received an email stating that I should perform a code review. How do I do this?

When someone has assigned a code review to you in Gerrit, you will receive an email to notify you. To do the code review, perform the following steps:

1. In Gerrit, on the review dashboard page, select the new entry in the *Incoming reviews* section.

   ![](~/develop/images/GerritIncomingReviews.png)<br>
   *Incoming reviews in Gerrit*

   On the review page, you will see an overview of all the files that have been updated in the Files section.

   ![](~/develop/images/GerritUpdatedFiles.png)<br>
   *Overview of updated files in Gerrit*

   > [!NOTE]
   > Jenkins will also automatically have executed the CI/CD pipeline. In case the pipeline failed, this will be marked by a -1 for the Jenkins tag. In this case, do not start a review, but notify the developer stating that the pipeline should succeed first.

1. Click on the files to see the details of the changes to these files and review those.

   ![](~/develop/images/GerritCodeReview.png)<br>
   *Code review in Gerrit*

1. Provide review comments where necessary by double-clicking the desired location in the code and selecting *Provide comment* (or use the c shortcut). When you have entered a comment, click *save*.

1. When you have reviewed all changed files, on the review page, click the reply button and provide the necessary feedback.

   - In case you noticed an issue, provide -2 for the Code Review tag.

   - In case everything was fine, provide +2 for the Code Review tag.

   ![](~/develop/images/GerritCodeReviewReply.png)<br>
   *Code review in Gerrit*

   The Code Review values should be interpreted as follows (see also [https://gerrit-review.googlesource.com/Documentation/config-labels.html](https://gerrit-review.googlesource.com/Documentation/config-labels.html)):

   - -2: This will not be merged.

   - -1: I would prefer if this is not merged as is.

   - 0: No score

   - +1: Looks good to me, but someone else must approve it.

   - +2: Looks good to me; approved.

   > [!NOTE]
   > For an in-depth explanation of the Gerrit review UI, see [https://gerrit.skyline.be/review/Documentation/user-review-ui.html](https://gerrit.skyline.be/review/Documentation/user-review-ui.html).

1. Click *Send*. Now the developer will receive an email about this review.

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Gerrit Code Review":  CI/CD HowTo – Perform a Gerrit Code Review and CI/CD HowTo – Handle fixes sent to Gerrit.

### I received an email notifying me that a code review failed. How do I continue?

1. In Gerrit, on the review dashboard page, click the reviewed item.

   ![](~/develop/images/GerritReviewedItem.png)<br>
   *Reviewed item in Gerrit*

1. In the files section, you can see in the *Comments* column which files have comments. Select a file to see all the comments for that file.

   ![](~/develop/images/GerritCommentsOnFile.png)<br>
   *Comments on a file in Gerrit*

   ![](~/develop/images/GerritCommentsOnFile2.png)<br>
   *Comments on a file in Gerrit*

1. In SourceTree, make sure you have checked out the corresponding branch and make sure it is up to date. In case you no longer have this branch locally, check it out from the remote repository.

1. Implement the required changes to address all code review remarks.

1. Commit your new changes in SourceTree.

1. Using the SLC SE Repository manager tool, send the new commit for code review.

   ![](~/develop/images/SLCSERepoManager_PushForReview2.png)<br>
   *Sending a commit for code review in SLC SE Repository Manager*

   This will now create a new patch set for the reviewer to review in Gerrit.

> [!TIP]
> See also:
> Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Gerrit Code Review":  CI/CD HowTo – Fixing an issue reported through Gerrit.

### I received an email notifying me that a code review succeeded. How do I continue?

1. In Gerrit, on the review page of your item you will now see a *Ready to submit* notification. Click the *SUBMIT* button.

   ![](~/develop/images/GerritReadyToSubmit.png)<br>
   *Ready to submit notification in Gerrit*

   Now it should show a *Merged* notification.

   ![](~/develop/images/GerritMerged.png)<br>
   *Merged notification in Gerrit*

   If you now fetch the branch you merged into, you will see that the origin now points to your merged commit.

   ![](~/develop/images/SourceTree_MergedCommit.png)<br>
   *Merged commit in branch*

1. In SourceTree, you can now delete your development branch:

   1. Make sure you are currently on a branch other than the one you want to delete, as otherwise SourceTree will not allow this action.

   1. Select the branch to delete, right-click, and select *Delete* in the context menu.

      ![](~/develop/images/SourceTree_DeleteBranch.png)<br>
      *Deleting a development branch in SourceTree*

      This will now show a pop-up window as illustrated below.

      ![](~/develop/images/ConfirmBranchDeletion.png)<br>
      *Confirm Branch Deletion window*

1. Click *OK* to remove the branch.

1. Also remove the development branch in the remote repository:

   1. Under REMOTES, select the branch to delete, right-click and then select *Delete origin/….* in the context menu.

   1. Click *OK* in the pop-up window.

   ![](~/develop/images/SourceTree_RemoveDevelopmentBranch.png)<br>
   *Removing a development branch in the remote repository*

1. At this point, you will typically will want to create a tag to define a new version of the protocol. For more information on how to do this, refer to [I finished development. How do I create a tag for the new version?](#i-finished-development-how-do-i-create-a-tag-for-the-new-version).

> [!TIP]
> See also: Learning path "System Dev - CI/CD, git, Gerrit" on LinkedIn Learning, Section "Tutorial Gerrit Code Review":  CI/CD HowTo – Finalize a Gerrit Code Review
