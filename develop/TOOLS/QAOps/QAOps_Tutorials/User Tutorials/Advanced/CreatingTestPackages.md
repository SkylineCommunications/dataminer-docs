---
uid: QAOps_Tutorials_User_Tutorials_Advanced_Creating_Test_Packages
---

# How To Create a Test Package

In this tutorial, you will learn how to create a basic Test Package and Trigger a Test Run

For all tutorials, always use the "QAOps Sandbox Environment": [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

Expected duration: 15 minutes.

## Prerequisites

- Access to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

> [!IMPORTANT]
> Please contact support.boost@skyline.be to receive a username and password for access to the Sandbox system.

- You require [dotnet 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), even if you already have a higher SDK version installed.

- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
    - Enable the ASP.NET and Web Development workload in Visual Studio. [Troubleshooting](xref:skyline_dataminer_sdk_troubleshooting#missing-manage-user-secrets-context-menu-in-visual-studio)

## Overview

- [Step 1: Download, install, and verify the QAOps tool](#step-1-download-install-and-verify-the-qaops-tool)

- [Step 2: Find the unique test and configuration identifiers](#step-2-find-the-unique-test-and-configuration-identifiers)

- [Step 3: Create a token](#step-3-create-a-token)

- [Step 4: Trigger the test run](#step-4-trigger-the-test-run)

- [Step 5: Verify that the request was received](#step-5-verify-that-the-request-was-received)

- [Step 6: Find the test run results](#step-6-find-the-test-run-results)

- [Step 7: Delete the server used for your test run](#step-7-delete-the-server-used-for-your-test-run)

## Step 1: Create a new DataMiner Test Package Project

Open Visual Studio

