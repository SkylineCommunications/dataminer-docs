---
uid: CICD_Troubleshooting_GitHubFailures
keywords: trigger initial analysis fail, template is not valid, quality gate fail, automatic analysis
---

# GitHub failures

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Though we try to simplify workflows as much as possible for everyone, some places are still prone to errors. Below is a list of common issues besides obvious ones like failing unit tests.

The errors are grouped by step and then by specific error.

## Trigger Initial Analysis

### Error: The template is not valid. Newtonsoft.Json.JsonReaderException: Error reading JToken from JsonReader. Path '', line 0, position 0

This error occurs when your repository is private and you forgot to create the `SONAR_TOKEN` secret.

For public repositories, the analysis step uses the `SONAR_TOKEN` organization secret. For private repositories, you will need to create a repository secret with name `SONAR_TOKEN` (as private repositories cannot access the organization secret). The value of the secret is an API token that can be created in SonarCloud under the [Security](https://sonarcloud.io/account/security) tab of the account settings.

## Quality Gate

The Quality Gate can fail because of multiple reasons. The "normal" ones would be unit tests that fail or SonarCloud that reports issues.

Unfortunately, because of a misconfiguration or admin-only settings on SonarCloud, it can occur that there are issues that are less clear.

### Could not retrieve SonarCloud quality gate status

If this error is shown in your workflow, you will need to check the *SonarCloud Quality Gate check* step and the *Analyze* step for more information.

#### 'Analyze' step - You are running CI analysis while Automatic Analysis is enabled. Please consider disabling one or the other

This setting is only accessible for people with admin rights on SonarCloud. However, a [SonarCloudFixer repository](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.SonarCloudFixer) has been set up that checks every 10 minutes whether *Automatic Analysis* is enabled in any projects and, if so, disables it.

Once the setting is disabled, run your workflow again to verify if everything is OK.

#### 'Sonar Quality Gate check' step - Quality Gate not set for the project. Please configure the Quality Gate in SonarQube or remove sonarqube-quality-gate action from the workflow

This happens when you run the CI before you have created the SonarCloud project. This makes a SonarCloud project without the proper configuration.

Contact the BOOST team so they can remove the project. You can then recreate the project with the correct settings.

## Deploy Action

### Error: 'agent-destination-id' must be provided for the Deploy stage

As of version 3 of the Deploy Action, the action uses organization keys instead of system keys. This means that a new input needs to be specified to determine the system to which the package needs to be deployed.

For more information about the *agent-destination-id*, refer to the [Deploy Action readme](https://github.com/SkylineCommunications/Skyline-DataMiner-Deploy-Action?tab=readme-ov-file#destination-agent-id).
