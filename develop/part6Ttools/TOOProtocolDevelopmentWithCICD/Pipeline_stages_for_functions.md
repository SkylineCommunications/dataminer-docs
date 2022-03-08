---
uid: Pipeline_stages_for_functions
---

# Pipeline stages for functions

Currently, the pipeline for function development consists of the following steps:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [(Release) Prepare for SVN](#release-prepare-for-svn)

- [(Release) Push to SVN](#release-push-to-svn)

- Declarative post actions

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. In this step, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

In this step, Jenkins loads the current repository from Git.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Push to SVN

This step performs the actual push to SVN. Once this step is executed, you should find a new version of the Visio on SVN in the corresponding folder(<https://svn.skyline.be/!/#SystemEngineering/view/head/Functions>).
