---
uid: ClassLibraryDevelopment
---

# Class library development

> [!IMPORTANT]
> This information in this section is only applicable for Skyline employees.

## The class library is open to contributions

Everyone at Skyline is encouraged to help maintain and add features to the base class library. If you have code that deals with DataMiner and could be useful for everyone developing protocols or scripts, then the base class library might be the place to add it.

Adding to the class library is relatively simple, and your changes can be used in development and production right away. The official merge and release as a stable version for everyone is handled within the Skyline Data Acquisition domain after code reviewing and QA, but this does not block use in projects and possible releases.

If you would like to have input on code design, do not hesitate to ask Data Acquisition for assistance (by sending an email to [domain.create.data-acquisition@skyline.be](mailto:domain.create.data-acquisition@skyline.be)).

These are the most important things to keep in mind:

- Avoid breaking changes at all costs.
- Make sure your code does not block possible future additions.
- Document all public classes and methods, including possible exceptions.
- Add unit and integration tests to avoid regression.
- Write code in a generic but user-friendly way, avoiding anything project-specific or hard-coded.

## Contribution workflow

1. Make a new task if one does not exist yet under the *SLC-SE-Class Library* project. You can set the type to *Consultancy*.

1. Clone the repo *Custom Solutions/Generic/Skyline.DataMiner.Core/DataMinerSystem*.

    >[!NOTE]
    > If you are working remotely and the clone takes longer than 15 minutes, please ask Data Acquisition for assistance (by sending an email to [domain.create.data-acquisition@skyline.be](mailto:domain.create.data-acquisition@skyline.be)).

1. Select the master branch you want to start with.

1. Make a new branch: gerrit/DCPxxxx_subject (or dev/DCPxxxx if you are not using Gerrit).

1. In a text editor, change the Jenkins file from *jenkins.groovy* to *jenkinsNoIntegration.groovy*.

1. Commit these changes and push them.

1. Wait until SonarQube is finished, then open the *Issues* tab and bulk edit everything as "won't fix".

    > [!NOTE]
    > You may find 20 or so code smells that were not fixed, but these can be ignored. All new issues reported in SonarQube from now on will be related to your changes specifically.

1. If your branch introduces a new minimum required DataMiner version, configure the corresponding version of the `Skyline.DataMiner.Dev.*` NuGet packages.

1. Start development.

1. Remember to add integration tests. You can look at the existing tests to see how this is done. The DMA server running integration tests is 10.11.6.51.

1. When you are ready:

    1. Do a Gerrit push for code review, or just do a push in case you are not using Gerrit.

    1. Assign the task to the Data Acquisition user, with the task status *Code Review* and with the *Tools* tag added.

    1. Send an email to [domain.create.data-acquisition@skyline.be](mailto:domain.create.data-acquisition@skyline.be) mentioning that you added something and in which branch this was done.

> [!TIP]
> At this point, if you already want to use a beta package of your new class library version (and possibly even release your protocols with it), Under the SLC internal Nuget store, you will also be able to find a NuGet of your class library branch for use instead of the DIS code generation.
