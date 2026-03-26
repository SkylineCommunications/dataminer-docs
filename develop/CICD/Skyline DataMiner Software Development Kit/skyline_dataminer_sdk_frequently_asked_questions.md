---
uid: skyline_dataminer_sdk_frequently_asked_questions
keywords: Skyline.DataMiner.Sdk
---

# Frequently asked questions about the Skyline DataMiner SDK

## What about custom DLLs?

For connector solutions and the old automation script solutions, there was a dedicated DLLs directory to store the necessary custom DLLs. With Skyline DataMiner SDK, this is no longer present. Instead, the Skyline DataMiner SDK will look at the **paths in the .csproj file** to find the custom DLLs to be able to package the solution.

For ease of use, you can still manually add this, but you are free to choose where and how. The only requirement is that the file needs to be accessible when building the DataMiner application package. This means that if you store your code on Git, your directory with DLLs need to be pushed as well.

## Will other DataMiner components be supported in the future?

At present, there are no exact plans as to what will or will not be supported. This is an evolving process.

If there is a component that you really want to have included, you can add a [feature suggestion on Dojo](https://community.dataminer.services/feature-suggestions) or create an issue in the [Skyline.DataMiner.Sdk GitHub repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Sdk).

## Do I need to change the Version and VersionComment for each release?

If you are using the GitHub workflows, this is not needed, as the workflow itself will fill those in.

However, if you are releasing manually, you will indeed need to update these.
