---
uid: High-level_overview
---

# High-level overview

In this section, you can find a high-level overview of protocol development prior to the introduction of the CI/CD pipeline, compared to the new way of working.

Consider for example the development of a protocol. Previously, System Developers put new versions of a protocol on <https://svn.skyline.be>, where the protocol was an XML file.

![](~/develop/images/ProtocolOnSVN.jpg)<br>
*Previous workflow: Protocol published on SVN by developer*

With the introduction of the CI/CD pipeline, Visual Studio solutions are now used instead of XML files (see e.g. [Developing using DIS](xref:DisVisualStudioSolutions)).

Every Visual Studio solution is stored in its own Git repository. The repository has different release branches defined for the different ranges (e.g. 1.0.0.X) and each protocol version is a tag in the Git repository (e.g. 1.0.0.1, 1.0.0.2, etc.). Note that this is different from the previous approach on SVN, where every version of a protocol was provided as a separate file.

These Git repositories are hosted by [Gerrit Code Review](https://www.gerritcodereview.com/), a software package used for code reviewing, managing and serving Git repositories, etc. (https://gerrit.skyline.be). For each push to a Git repository hosted by Gerrit, the CI/CD pipeline automatically triggers and executes multiple steps such as building the solution, executing unit tests, performing code analysis, running the DIS validator and publishing a new version of the protocol on SVN if needed.

System Developers therefore no longer put new versions of protocols, Automation scripts, etc. on SVN. Instead, a new version is created by creating a tag in the Git repository. The CI/CD pipeline then automatically publishes the new version on SVN.

![](~/develop/images/GerritCodeReview.jpg)<br>
*New workflow: Protocol published on Git by developer and on SVN by CI/CD pipeline*
