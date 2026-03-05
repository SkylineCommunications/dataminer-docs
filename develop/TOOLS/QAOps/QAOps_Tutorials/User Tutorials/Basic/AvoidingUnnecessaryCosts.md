---
uid: QAOps_Tutorials_User_Tutorials_Basic_Avoiding_Unnecessary_Costs
---

# How to avoid unnecessary costs as a user

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to avoid unnecessary costs when using the QAOps system.

You will start a test run that is expected to fail and then remove the related server to limit resource usage.

For all tutorials, always use the "QAOps Sandbox Environment": [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

Expected duration: 5 minutes.

## Prerequisites

- Access to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

> [!IMPORTANT]
> Please contact support.boost@skyline.be to receive a username and password for access to the Sandbox system.

- [dotnet 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Overview

- [Step 1: Download, install, and verify the QAOps tool](#step-1-download-install-and-verify-the-qaops-tool)

- [Step 2: Find the unique test and configuration identifiers](#step-2-find-the-unique-test-and-configuration-identifiers)

- [Step 3: Create a token](#step-3-create-a-token)

- [Step 4: Trigger the test run](#step-4-trigger-the-test-run)

- [Step 5: Verify that the request was received](#step-5-verify-that-the-request-was-received)

- [Step 6: Find the test run results](#step-6-find-the-test-run-results)

- [Step 7: Delete the server used for your test run](#step-7-delete-the-server-used-for-your-test-run)

## Step 1: Download, install, and verify the QAOps tool

1. Open a Command Prompt, Bash, or PowerShell window.

1. Install the QAOps tool:

    ```bash
    dotnet tool install skyline.dataminer.qaops --global
    ```

1. Verify that the tool is available:

    ```bash
    dataminer-qaops --help
    ```

The command output displays a description of the tool and the available commands.

## Step 2: Find the unique test and configuration identifiers

1. In the *User App*, go to [Configurations](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Configurations).

1. Locate the configuration and test suite you want to execute.

1. For this tutorial, use "Demo Configuration" and "Demo Test Suite - Failing Tests", because they are configured to produce a failing test.

1. Copy the configuration ID and save it in a text file.

1. Copy the test suite ID and save it in a text file.

## Step 3: Create a token

1. In the *User App*, go to [Tokens](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Tokens).

1. Click *Create Token* in the top-left corner.

1. Enter a name for the token.

1. Select the scope that matches the ".execute" scope for the "Demo Configuration".

1. If needed, use Shift+Click to select all scopes and allow full access. This is not recommended in production environments.

1. Click *Generate Token*.

1. Wait until the token value is shown.

1. Copy the token value and save it in a text file. In production environments, use a key vault solution.

## Step 4: Trigger the test run

1. Open a Command Prompt, Bash, or PowerShell window.

1. Run the following command, after replacing the placeholders:

    ```bash
    dataminer-qaops test-run --token "TOKEN" -t TESTSUITE -c CONFIGURATION -tags MYNAME -san saqaopssandbox
    ```

1. Replace the placeholders with your values:

    - `TOKEN`: the token value you copied earlier.

    - `TESTSUITE`: the test suite ID you copied earlier.

    - `CONFIGURATION`: the configuration ID you copied earlier.

    - `MYNAME`: your name, nickname, or another identifier that helps you find your request.

1. Press Enter to submit the request.

> [!IMPORTANT]
> For production systems, leave out the `-san` argument.

## Step 5: Verify that the request was received

1. In the *User App*, go to [Overview](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Overview).

1. Locate your tag in the list.

1. Use the top filter to find your request more quickly.

1. Wait until the test run is finished.

## Step 6: Find the test run results

1. In the *User App*, go to [Configurations](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Configurations).

1. Select "Demo Configuration".

1. Select "Demo Test Suite - Failing Tests".

1. Use your tags to find your test run, and then select it.

## Step 7: Delete the server used for your test run

1. Locate the server information in the top-right corner. This shows which server was used. It should indicate that the server is marked for deletion in four or more days.

1. Manually click the delete icon for the server.

1. Verify that the "Marked For Deletion" timestamp changes to the current UTC time.

1. After a few minutes the server information disappears. This indicates that the server was removed and costs were reduced.

In production, click the delete button after you have finished debugging and resolving the cause of the failing test.
