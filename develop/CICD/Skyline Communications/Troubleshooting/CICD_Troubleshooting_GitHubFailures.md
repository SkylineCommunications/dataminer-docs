---
uid: CICD_Troubleshooting_GitHubFailures
keywords: trigger initial analysis fail, template is not valid, quality gate fail, automatic analysis
---

# GitHub failures

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

As much as we want to simplify workflows for everyone, some places as still prone to errors. Below is a list of common issues beside the obvious ones like unit tests that are failing.

The errors are grouped by step and then by specific errors.

## Trigger Initial Analysis

### Error: The template is not valid. Newtonsoft.Json.JsonReaderException: Error reading JToken from JsonReader. Path '', line 0, position 0

This error occurs when your repository is private and you forgot to create the `SONAR_TOKEN` secret.

For public repositories, the analysis step uses the `SONAR_TOKEN` organization secret. For private repositories, you will need to create a repository secret with name SONAR_TOKEN (as private repositories cannot access the organization secret). The value of the secret is an API token that can be created in SonarCloud under the [Security](https://sonarcloud.io/account/security) tab of the account settings.

## Quality Gate

The Quality Gate can fail due to multiple reasons. The 'normal' ones would be unit tests that fail or SonarCloud that reports issues.

Unfortunately due to misconfiguration or admin-only settings on SonarCloud, it can be that there are issues that are less clear.

### Could not retrieve SonarCloud quality gate status

If this error is being show in your workflow, you will need to check the *SonarCloud Quality Gate check* step and the *Analyze* step for more information.

#### 'Analyze' step - You are running CI analysis while Automatic Analysis is enabled. Please consider disabling one or the other

This setting is unfortunately only accessible for people with admin rights on SonarCloud. To have this disabled, contact the Data-Acq Tools team.

<!-- In the future this will be partially solved by a repository that will hourly? run a workflow to go over each project on SonarCloud and disable the automatic analysis. -->

#### 'Sonar Quality Gate check' step - Quality Gate not set for the project. Please configure the Quality Gate in SonarQube or remove sonarqube-quality-gate action from the workflow

This happens when you run the CI before you have created the SonarCloud project. This makes a SonarCloud project without the proper configuration.

Contact the Data-Acq Tools team so they can remove the project so you can recreate the project with the correct settings.
