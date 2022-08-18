---
uid: ClassLibraryDevelopment
---

# Class Library Development

## Goal

Everyone is encouraged to help maintain and add features to the Base Class Library.
If you have code that deals with DataMiner and could be useful for everyone developing drivers or scripts then the Base Class Library might be the place to add it.

Adding to the class library is relatively simple and your changes can be used in development and production right away. Official merge and release as a stable version for everyone is handled within Data Acquisition domain after code reviewing and QA, but this is not blocking use in projects and possible release.

Don't hesitate to ask for assistance with Data Acquisition (domain.create.data-acquisition@skyline.be) if you'd like some input on code design.

The most important things are:

- avoid breaking changes at all costs
- make sure your code does not block possible future additions
- document all public classes and methods, including possible exceptions
- add unit and integration tests to avoid regression
- write code in a generic but user friendly way, nothing project specific or hardcoded

## Workflow

1. Make a new task if one does not exist (type consultancy is fine) under SLC-SE-Class Library project.
2. Clone the repo: Custom Solutions/Internal/Class Library/Base Class Library
    >[!NOTE]
    > If you are remote and the clone takes longer than 15 minutes. Please ask assistance with Data Acquisition (domain.create.data-acquisition@skyline.be).
3. Select the master branch you want to start with (1.2.0.X or 1.1.2.X current)
4. Make a new branch :  gerrit/DCPxxxx_subject   (or dev/DCPxxxx if not using gerrit)
5. Jenkins file change in text editor:  jenkins.groovy into jenkinsNoIntegration.groovy
6. Manifest file change in texteditor: change the version so it starts with 10.  instead of 1. (this is for the version of the old code generated class library .zip file)
7. Commit the 2 changes & Push
8. Wait until SonarQube is finished then open the Issues tab and Bulk Edit everything as: 'won't fix'.

    - Note here: you may find 20 or so code smells weren't fixed, you can ignore these.
    - b. All new issues reported in sonarqube will now be from your changes specifically.

9. (Only necessary for branches older than 1.1.2.X) In Visual Studio: open tools/Nuget Package Manager/Package Manager Settings

    - Select Package Sources
    - Add as a new source: DataMinerDevPacks  with path:  \\SLC-NAS-01.skyline.local\Shares\Public\Squad\Lightning\POC Nuget

10. Start Development
11. Remember to add Integration Tests. U can look at the existing tests to see how it is done. The DMA server running integration tests is: 10.11.6.51
12. When finished:

    - do a gerrit push for code review
    - assign the task to Data Acquisition user in code review with the 'Tools' tag added.  (or just do a push, if not using gerrit)
    - Send a quick e-mail to domain.create.data-acquisition@skyline.be indicating you added something and in what branch.

13. You can find a beta package of your new class library version in jenkins artifacts of your branch. You can use it (and even release your drivers with this!) by adding it to: %DIS_PATH%\Files\Class Library then selecting it in the DIS options class library.
14. You will also find under SLC internal nuget store a NuGet of your class library branch for use instead of the DIS code generation (requires minimum dma: 10.0.10)

> [!IMPORTANT]
> This information is only applicable to members of Skyline Communications
