---
uid: ClassLibraryDevelopment
keywords: class library
---

# DataMinerSystem library development

> [!IMPORTANT]
> This information in this section is only applicable for Skyline employees.

## The DataMinerSystem library is open to contributions

Everyone at Skyline is encouraged to help maintain and add features to the DataMinerSystem library. If you have code that deals with DataMiner and could be useful for everyone developing protocols or scripts, then the DataMinerSystem library might be the place to add it.

Adding to the DataMinerSystem library is relatively easy, and your changes can be used in development and production right away. The official merge and release as a stable version is handled within the Skyline Data Acquisition domain after code reviewing and QA.

If you would like to have input on code design, do not hesitate to ask Data Acquisition for assistance (by sending an email to [support.data-acquisition@skyline.be](mailto:support.data-acquisition@skyline.be)).

These are the most important things to keep in mind:

- Avoid breaking changes at all costs.
- Make sure your code does not block possible future additions.
- Document all public classes and methods, including possible exceptions.
- Add unit and integration tests to avoid regression.
- Write code in a generic but user-friendly way, avoiding anything project-specific or hard-coded.

## Contribution workflow

1. Make a new task if one does not exist yet under the *R&D Communication & Synchronisation
* project. You can set the type to *New Feature*.

1. Fork the private DataMinerSystem library repository [SkylineCommunications/Skyline.DataMiner.Core.DataMinerSystem](https://github.com/SkylineCommunications/Skyline.DataMiner.Core.DataMinerSystem), and clone your fork.

1. In your fork, select the branch for the highest supported DataMiner version you want to start with.

1. Make a new branch.

1. If your branch introduces a new minimum required DataMiner version, configure the corresponding version of the `Skyline.DataMiner.Dev.*` NuGet packages.

1. Start development.

1. Remember to add integration tests. You can look at the existing tests to see how this is done, and run them locally from within Visual Studio in the same way as the unit tests. The integration tests will then run on your local agent.

1. When you are ready:

   1. Commit your changes and push your branch to your fork on GitHub.

   1. Open a pull request to the main repository for code review.

      > [!NOTE]
      > If your feature requires a higher DataMiner version and the main repository does not have a corresponding branch yet, contact Data Acquisition first by sending an email to [support.data-acquisition@skyline.be](mailto:support.data-acquisition@skyline.be).

   1. Assign the task to the Data Acquisition user, with the task status *Code Review*.

   1. Email [support.data-acquisition@skyline.be](mailto:support.data-acquisition@skyline.be) mentioning that you added something and include a link to the pull request.
