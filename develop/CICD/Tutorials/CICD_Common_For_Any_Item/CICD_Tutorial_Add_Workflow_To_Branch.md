---
uid: CICD_Tutorial_Add_Workflow_To_Branch
description: Learn how to add a GitHub Actions workflow to a specific repository branch and commit the workflow directly from GitHub.
---

# Setting up a workflow on a specific branch via GitHub

In this tutorial, you will learn how to add a GitHub Actions workflow directly to a specific branch in your repository on GitHub.

Expected duration: 5 minutes.

## Prerequisites

- A [GitHub](https://github.com/) account with write access to the repository where you want to add the workflow.

## Overview

- [Step 1: Select the workflow](#step-1-select-the-workflow)
- [Step 2: Select the branch and commit the workflow](#step-2-select-the-branch-and-commit-the-workflow)

## Step 1: Select the workflow

1. Go to your repository on [GitHub](https://github.com/).

1. Select the *Actions* tab.

1. Click the green *Add workflow* button.

1. Find the workflow you want to add, and click *Configure*.

## Step 2: Select the branch and commit the workflow

1. At the top of the workflow editor, open the branch dropdown.

   The default branch, typically *main*, will be selected automatically.

1. Select the branch where you want to add the workflow.

1. Click the green *Commit changes* button.

1. Enter the commit details, and confirm the commit.

   The workflow file will be committed and pushed to the selected branch.

The following example shows how to add the DataMiner connector workflow to a specific branch:

![Adding the DataMiner connector workflow to a specific GitHub branch](~/develop/images/AddWorkflowToBranch.gif)
