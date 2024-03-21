---
uid: CICD_Troubleshooting_JenkinsFailures
keywords: jenkins fail, semaphore, dcp registration fail
---

# Jenkins failures

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

As much as we want to simplify workflows for everyone, some places as still prone to errors. Below is a list of common issues beside the obvious ones like unit tests that are failing.

The errors are grouped by stage and then by specific errors.

## Validate Possible Dependency NuGets

### System.ObjectDisposedException: The semaphore has been disposed

This error is sometimes thrown by a tool made by [Team Security](mailto:squad.create.security-heimdall@skyline.be). You can contact them for this issue.

As this isn't a consistent error, you can just rebuild the pipeline again. The proper way to do this is by going to the 'old' UI of Jenkins and use the *Build Now* button. The *Rerun* button on 'Ocean Blue' UI of Jenkins is not a full rebuild. Certain parts will be cached which could give unexpected issues when running the pipeline.

![Build Now button in Jenkins](~/develop/images/CICD_Troubleshooting_JenkinsFailures_Rebuild.png)

## Quality Gate

### SonarQube - Connectors

If SonarQube complains about the QAction_Helper project, then this means that you don't have any other C# project in your solution. Due to an issue in SonarQube, when there are no projects to analyze (as QAction_Helper is exluded), then it ignores the exclusion and analyzes the QAction_Helper project anyway.

You can fix this by adding another QAction project to the solution (e.g.: with id 0) and then remove it again. Make sure to not remove the project from the file explorer so that SonarQube still sees it.

## DCP Registration, Prepare for SVN, Push to SVN & Push to Azure

If an error occurrs here, contact Data-Acq Tools team as there is a potential that the release happened partially, meaning that the next run it will fail. The team will clean up the records so that the pipeline can properly be rebuild.
