---
uid: skyline_dataminer_sdk_frequently_asked_questions
keywords: Skyline.DataMiner.Sdk
---

# Skyline DataMiner SDK - FAQ

## What about custom DLLs?

For Connector solutions and the old Automation Script solutions, there was a dedicated DLLs directory to store the custom DLLs that are needed. With Skyline DataMiner SDK, this is not present anymore. The Skyline DataMiner SDK will look at the paths in the csproj file to find the custom DLLs to be able to package it.

For ease of use, this can still be manually added by you, but you are free to choose where and how. The only requirement is that the file needs to be accessible when building the DataMiner application package. This means that if you store your code on Git, your directory with DLLs need to be pushed as well.

## Will X be supported in the future?

X being a DataMiner component (like Automation Script, Dashboard, etc.).

There are no clear plans on what will and won't be supported. This is an evolving process. If there is a component that you really want to have included, feel free to make a [feature suggestion on Dojo](https://community.dataminer.services/feature-suggestions) or create an issue on our [GitHub repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Sdk).

## Do I need to change the Version and VersionComment each release?

If you are using the GitHub workflows, this is not needed as the workflow itself will fill those in. If you are releasing manually, then yes, you will need to update them.
