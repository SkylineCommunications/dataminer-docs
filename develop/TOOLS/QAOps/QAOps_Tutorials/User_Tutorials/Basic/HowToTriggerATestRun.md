---
uid: QAOps_Tutorials_User_Tutorials_Basic_How_To_Trigger_A_Test_Run
---

# Triggering a test run

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to trigger a [QAOps test run](xref:QAOps_Test_Run).

Expected duration: 15 minutes.

## Prerequisites

- Access to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be). This "QAOps Sandbox Environment" environment should be used for every QAOps tutorial.

  > [!NOTE]
  > Please contact <support.boost@skyline.be> to receive a username and password for access to the Sandbox system.

- [dotnet 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) is required, even if a higher SDK version is already installed.

## Overview

- [Step 1: Download, install, and verify the QAOps tool](#step-1-download-install-and-verify-the-qaops-tool)

- [Step 2: Find the unique test and configuration identifiers](#step-2-find-the-unique-test-and-configuration-identifiers)

- [Step 3: Create a token](#step-3-create-a-token)

- [Step 4: Trigger the test run](#step-4-trigger-the-test-run)

- [Step 5: Verify that the request was received](#step-5-verify-that-the-request-was-received)

## Step 1: Download, install, and verify the QAOps tool

1. Open a Command Prompt, Bash, or PowerShell window.

1. Check if you have `nuget.org` as a known NuGet source:

   ```bash
   dotnet nuget list source
   ```

1. Verify that the output contains `nuget.org [Enabled]`.

   > [!NOTE]
   > The first time you run a `dotnet` command on a computer, you will see a welcome message. The output of your command is displayed below that message.

1. If your sources do not contain `nuget.org`, add it with the following command. Otherwise, skip this step.

   ```bash
   dotnet nuget add source https://api.nuget.org/v3/index.json -n "nuget.org"
   ```

1. Install the QAOps tool:

   ```bash
   dotnet tool install skyline.dataminer.qaops --global
   ```

1. Verify that the tool is available:

   ```bash
   dataminer-qaops --help
   ```

   The command output will display a description of the tool and the available commands.

> [!NOTE]
> If you see the exception "Unable to load the service index for source ...", one of your configured NuGet sources may be unreachable or may have expired credentials.
>
> To continue this tutorial, you can temporarily remove the failing source and add it again later when needed:
>
> ```bash
> dotnet nuget remove source "NameOfSource"
> ```

## Step 2: Find the unique test and configuration identifiers

1. In the QAOps User app (i.e., the green *QAOps* app), go to the [Configurations](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Configurations) page.

1. Select *Demo Configuration* and *Demo Test Suite*.

1. Copy the configuration ID and save it in a text file.

1. Copy the test suite ID and save it in a text file.

![QAOps Identifier Selections](~/develop/images/QAOps_SelectIdentifiers.png)

## Step 3: Create a token

1. In the QAOps User app, go to the [Tokens](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Tokens) page.

1. In the upper-left corner, click *Create Token* .

1. Enter a name for the token.

1. Select the scope that matches the ".execute" scope for your chosen configuration.

1. Click *Generate Token*.

1. Wait until the token value is shown.

1. Copy the token value and save it in a text file.

   For production environments, use a key vault solution.

## Step 4: Trigger the test run

1. Open a Command Prompt, Bash, or PowerShell window.

1. Run the following command, after replacing the placeholders as indicated below, making sure to keep the double quotes around the TOKEN value:

   ```bash
   dataminer-qaops test-run --token "TOKEN" -t TESTSUITE -c CONFIGURATION -tags MYNAME -san saqaopssandbox
   ```

   - `TOKEN`: The token value you copied earlier. Make sure this value is enclosed in double quotes.

   - `TESTSUITE`: The test suite ID you copied earlier.

   - `CONFIGURATION`: The configuration ID you copied earlier.

   - `MYNAME`: Your name, nickname, or another identifier that helps you find your request.

   > [!NOTE]
   > For production systems, leave out the -san argument. This argument indicates to which QAOps System you want to send commands, in this case the QAOps Sandbox system. The default is the production QAOps system.

## Step 5: Verify that the request was received

1. In the QAOps User app, go to the [Overview](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Overview) page.

1. Locate your tag in the list.

1. Use the top filter to find your request more quickly.

1. Track the [test run life cycle](xref:QAOps_Test_Run).

To view and interpret the test results, follow the tutorial [Viewing test results](xref:QAOps_Tutorials_User_Tutorials_Basic_How_To_View_Results) tutorial.
