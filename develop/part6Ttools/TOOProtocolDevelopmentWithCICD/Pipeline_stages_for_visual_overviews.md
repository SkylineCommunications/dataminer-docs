---
uid: Pipeline_stages_for_visual_overviews
---

# Pipeline stages for visual overviews

Currently, the pipeline consists of the following steps:

- Loading Jenkinsfile

    See [Loading Jenkinsfile](#loading-jenkinsfile).

- Declarative checkout from SCM

    See [Declarative checkout from SCM](#declarative-checkout-from-scm).

- Check Visio File Size

    See [Check Visio File Size](#check-visio-file-size).

- (Development) Catalog registration

    See [(Development) Catalog registration](#development-catalog-registration).

- (Release) Prepare for SVN

    See [(Release) Prepare for SVN](#release-prepare-for-svn).

- (Release) Catalog registration

    See [(Release) Catalog registration](#release-catalog-registration).

- (Release) Push to SVN

    See [(Release) Push to SVN](#release-push-to-svn).

- Declarative post actions

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. In this step, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

In this step, Jenkins loads the current repository from Git.

## Check Visio File Size

In this step, Jenkins verifies the file size of the Visio file in the repository:

- If the file size is over 20 MB, the pipeline will be marked as error.

- If the file size is over 10 MB, the pipeline will be marked as unstable.

## (Development) Catalog registration

This stage will perform registration in the catalog.

## (Release) Prepare for SVN

In case a tag was detected and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Catalog registration

This stage will perform registration in the catalog.

## (Release) Push to SVN

This step performs the actual push to SVN. Once this step is executed, you should find a new version of the visual overview on SVN in the corresponding folder (<https://svn.skyline.be/!/#SystemEngineering/view/head/Visios>).
