---
uid: Pipeline_stages_for_dashboards
---

# Pipeline stages for dashboards

Currently, the pipeline consists of the following stages:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [Validate tag](#validate-tag)

- [Build .dmapp package](#build-dmapp-package)

- [(Release) Prepare for SVN](#release-prepare-for-svn)

- [(Release) Push to SVN](#release-push-to-svn).

- Declarative post actions

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. During this stage, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

During this stage, Jenkins loads the current repository from Git.

## Validate tag

This stage is only executed for pipeline runs for a tag. It will verify whether the specified tag meets the following conditions:

- The tag has the correct format.
- The tag is in the expected branch. For example, a tag "1.0.0.1" provided on a commit that is part of the "1.0.0.x" branch will succeed, while a tag "1.0.0.1" provided on a commit belonging to branch 1.0.1.x will fail.
- All expected previous minor versions of the tag are present. For example, if a commit has been tagged with "1.0.0.4", the tags "1.0.0.1", "1.0.0.2" and "1.0.0.3" are expected to be present already.
- The tag is an annotated tag and not a lightweight tag.

## Build .dmapp package

This stage creates a .dmapp package containing the dashboard.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Push to SVN

This stage performs the actual push to SVN. Once this stage is executed, you should find a new version of the dashboard on SVN in the corresponding folder (<https://svn.skyline.be/!/#SystemEngineering/view/head/Dashboards>).
