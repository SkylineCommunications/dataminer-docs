---
uid: Pipeline_stages_for_visual_overviews
---

# Pipeline stages for visual overviews

Currently, the pipeline consists of the following steps:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [Validate tag](#validate-tag)

- [Check Visio file size](#check-visio-file-size)

- [Build .dmapp package](#build-dmapp-package)

- [(Development) Catalog registration](#development-catalog-registration)

- [(Release) Prepare for SVN](#release-prepare-for-svn)

- [(Release) Catalog registration](#release-catalog-registration)

- [(Release) Push to SVN](#release-push-to-svn)

- Declarative post actions

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. In this step, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

In this step, Jenkins loads the current repository from Git.

## Validate tag

This step is only executed for pipeline runs for a tag. It will verify whether the specified tag meets the following conditions:

- The tag has the correct format.
- The tag is in the expected branch. For example, a tag "1.0.0.1" provided on a commit that is part of the "1.0.0.x" branch will succeed, while a tag "1.0.0.1" provided on a commit belonging to branch 1.0.1.x will fail.
- All expected previous minor versions of the tag are present. For example, if a commit has been tagged with "1.0.0.4", the tags "1.0.0.1", "1.0.0.2" and "1.0.0.3" are expected to be present already.
- The tag is an annotated tag and not a lightweight tag.

## Check Visio file size

In this step, Jenkins verifies the file size of the Visio file in the repository:

- If the file size is over 20 MB, the pipeline will be marked as error.

- If the file size is over 10 MB, the pipeline will be marked as unstable.

## Build .dmapp package

This step creates a .dmapp package containing the Visio file.

## (Development) Catalog registration

This stage will perform registration in the catalog.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Catalog registration

This stage will perform registration in the catalog.

## (Release) Push to SVN

This step performs the actual push to SVN. Once this step is executed, you should find a new version of the visual overview on SVN in the corresponding folder (<https://svn.skyline.be/!/#SystemEngineering/view/head/Visios>).
