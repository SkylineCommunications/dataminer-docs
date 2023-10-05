---
uid: DisTutorials_DevOpsGitHubValidator
---

# DIS Validator and basic GitHub DevOps

In this tutorial, you will explore collaborative software development and DevOps with a focus on DIS (DataMiner Integration Studio). You will learn how to integrate DIS into your GitHub-based development in Visual Studio. With a hands-on exercise using a dummy connector, you will get to utilize GitHub to create a fork, a clone, and a pull request with your changes, while leveraging DIS for effective contribution validation.

Expected duration: 15 minutes.

> [!TIP]
> See also: [Kata #1: DIS validator](https://community.dataminer.services/courses/kata-1) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

> [!NOTE]
> This tutorial uses DataMiner Integration Studio version 2.44.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [GitHub Account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

## Step 1: Fork the repository

1. Go to [https://github.com/SkylineCommunications/SLC-C-DevOpsExercise1](https://github.com/SkylineCommunications/SLC-C-DevOpsExercise1)

1. In the top right corner, click *Fork*.

1. Follow the wizard to create a fork of the repository under your own account.

## Step 2: Clone your fork

On the page of your GitHub fork (e.g. `https://github.com/YourGitHubHandle/SLC-C-DevOpsExercise1`), click the green *Code* button and select *Open in Visual Studio*.

> [!NOTE]
> In some cases, the *Open in Visual Studio* option may not be available. In that case, you will need to use GitHub Desktop instead to make the clone. Make sure you have [GitHub Desktop](https://desktop.github.com/) installed, and when you click the *Code* button on your fork page, select the option *Open with GitHub Desktop* instead.

## Step 3: Install DIS

If you do not have DIS yet, you should now download and install it.

For detailed information, refer to [Installing and configuring DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio).

## Step 4: Run the Validator

In Visual Studio, click the *Validate* button. This button is provided by DIS.

This will show several problems in the connector you can sort out.

## Step 5: Commit and push your changes

1. In the top bar in Visual Studio, select *Git* > *Commit or Stash*.

   This opens a new window.

1. In the new window, select *Commit All & Push*.

## Step 6: Create a pull request

In order to share your changes with the original owner, you now need to create a pull request.

- If you are using Visual Studio 2022, you can do this from within Visual Studio. It will detect that you did a commit and push to a forked repository, and it will suggest making a pull request.

- You can also do this from GitHub by navigating to the *Pull requests* tab of your fork page and then clicking the *New pull request* button.

This will trigger an automatic deployment pipeline that will zip the contents of your changes, mail them to us for validation, and then close and delete your pull request.

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.
