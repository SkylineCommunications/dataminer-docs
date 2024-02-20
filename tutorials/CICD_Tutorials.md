---
uid: CICD_Tutorials
keywords: connector, protocol, driver, cicd, pipeline, workflow
---

# CI/CD

CI/CD stands for continuous integration and continuous delivery/deployment.

**Continuous integration** is the practice of regularly merging code changes from multiple developers into a shared repository and verifying those changes through automated builds and tests.

**Continuous delivery** is the practice of automating the entire software release process, from building the code to deploying it to production, with the goal of quickly and reliably getting changes into the hands of users.

**Continuous deployment** is similar to continuous delivery, but goes a step further by automatically deploying changes to production as soon as they pass all tests and checks.

Together, CI/CD allows teams to deliver software more quickly, with higher quality and reliability, by automating the build, test, and deployment process.

Skyline Communications provides additional tooling that you can include into your CI/CD technology to automate DataMiner specific activities. You can find a quick overview of specific CI/CD tooling offered by Skyline Communications in our [documentation](xref:Platform_independent_CICD).

## Examples

You can find examples of running simple pipelines using our provided tooling within other CI/CD in our documentation:

At the time of writing this tutorial we have examples on:

1. [Azure Devops](xref:CICD_Azure_DevOps_Examples)

1. [Concourse](xref:CICD_Concourse_Examples)

1. [GitHub](xref:CICD_GitHub_Examples)

1. [GitLab](xref:CICD_GitLab_Examples)

1. [Jenkins](xref:CICD_Jenkins_Examples)

You can even run our tooling through [Command line](xref:CICD_Command_Line_Examples) on both Windows or Ubuntu.

## Tutorials

| Name | Description |
|--|--|
| [Setting up a GitHub Workflow for Connectors](xref:CICD_Tutorial_Connector) | Set up a basic quality control and automatic deployment for a DataMiner Connector to a staging system through a CI/CD Pipeline. |
