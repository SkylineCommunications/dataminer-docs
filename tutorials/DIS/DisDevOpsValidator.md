---
uid: DisTutorials_DevOpsGitHubValidator
---

# Tutorial: DIS Validator and basic GitHub DevOps

In this 15-minute exercise, explore collaborative software development and DevOps with a focus on DIS (DataMiner Integration Studio). Learn how to integrate DIS into your GitHub-based development in Visual Studio. With a hands-on exercise using a dummy connector, you'll get to utilize GitHub to Fork, Clone and Pull Request your changes while leveraging DIS for effective contribution validation.

> [!NOTE]
> This tutorial uses DataMiner Integration Studio version 2.44.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [GIT](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [GitHub Account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

## Step 1: Fork the repository
Go to [https://github.com/SkylineCommunications/SLC-C-DevOpsExercise1](https://github.com/SkylineCommunications/SLC-C-DevOpsExercise1)
On the top right, click on Fork. Follow the wizard and create a Fork of the repository under your own account.

## Step 2: Clone your Fork
On your fork, click on the green button saying Code and select: Open in Visual Studio  (Other options are also valid, if preferred)

## Step 3: Install DIS
If you don't have DIS yet, you should now download and install it.
[DIS Downloads](https://community.dataminer.services/exphub-dis/#downloads)

## Step 4: Run the Validator
On your visual studio, you can click the button Validate, provided by DIS.
This will show several problems in the connector you can sort out.

## Step 5: Commit and Push your changes.
On the top bar in visual studio you can select Git/Commit or Stash.
This opens a new window where you can select Commit All & Push.

## Step 6: Create a Pull Request
In order to share your changes with the original owner, you create a Pull Request.
You can do this either from within Visual Studio. VS2022 will detect you did a commit/push to a forked repository and suggest making a pull request.
You can also do this from github itself by navigating to the Pull Request tab and then clicking the green New Pull Request button.

This will trigger an automatic deployment pipeline that will:

1. Zip the contents of your changes
1. Mail them to us for validation
1. Close & delete your pull request

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you are awarded the appropriate DevOps Points as a token of your accomplishment!