---
uid: CICD_Troubleshooting_JenkinsFailures
keywords: jenkins fail, semaphore, dcp registration fail
---

# Jenkins failures

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Though we try to simplify workflows as much as possible for everyone, some places are still prone to errors. Below is a list of common issues besides obvious ones like failing unit tests.

The errors are grouped by stage and then by specific error.

## Validate Possible Dependency NuGets

### System.ObjectDisposedException: The semaphore has been disposed

This error is sometimes thrown by a tool made by [Team Security](mailto:squad.create.security-heimdall@skyline.be). You can contact them for this issue.

As this is not a consistent error, you can just rebuild the pipeline again. The proper way to do this is by going to the "old" UI of Jenkins and using the *Build Now* button. The *Rerun* button on the "Ocean Blue" UI of Jenkins is not a full rebuild. Certain parts will be cached, which could cause unexpected issues when running the pipeline.

![Build Now button in Jenkins](~/develop/images/CICD_Troubleshooting_JenkinsFailures_Rebuild.png)

## Quality Gate

### SonarQube - Connectors

If SonarQube complains about the *QAction_Helper* project, this means that you do not have any other C# project in your solution. Because of an issue in SonarQube, when there are no projects to analyze, it ignores the fact that *QAction_Helper* is excluded and analyzes that project anyway.

You can fix this by adding another QAction project to the solution (e.g. with ID 0) and then removing it again. Make sure to not remove the project from the file explorer, so that SonarQube still sees it.

## DCP Registration, Prepare for SVN, Push to SVN & Push to Azure

If an error occurs here, contact the BOOST team, as the release may have happened partially, meaning that the next run will fail. The team will clean up the records so that the pipeline can be properly rebuilt.
