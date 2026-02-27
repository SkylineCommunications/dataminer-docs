---
uid: QAOps_Tutorials_User_Tutorials_Basic_How_To_Trigger_A_Test_Run
---

# How to trigger a test run

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to trigger a [QAOps test run](xref:QAOps_Test_Run).

For all tutorials, always use the "QAOps Staging Environment": [https://qaopsstaging-skyline.on.dataminer.services/root/](https://qaopsstaging-skyline.on.dataminer.services/root/).

Expected duration: 15 minutes.

## Prerequisites

- Access to [https://qaopsstaging-skyline.on.dataminer.services/root/](https://qaopsstaging-skyline.on.dataminer.services/root/).

## Overview

- [Step 1: Download, install, and verify the QAOps tool](#step-1-download-install-and-verify-the-qaops-tool)

- [Step 2: Find the unique test and configuration identifiers](#step-2-find-the-unique-test-and-configuration-identifiers)

- [Step 3: Create a token](#step-3-create-a-token)

- [Step 4: Trigger the test run](#step-4-trigger-the-test-run)

- [Step 5: Verify that the request was received](#step-5-verify-that-the-request-was-received)

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

1. In the *User App*, go to *Configurations*: [https://qaopsstaging-skyline.on.dataminer.services/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Configurations](https://qaopsstaging-skyline.on.dataminer.services/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Configurations).

1. Locate the configuration and test suite you want to execute.

1. It is recommended to use the "Demo Configuration" and "Demo Test Suite", because these are configured to provide servers.

1. Copy the configuration ID and save it in a text file.

1. Copy the test suite ID and save it in a text file.

## Step 3: Create a token

1. In the *User App*, go to *Tokens*: [https://qaopsstaging-skyline.on.dataminer.services/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Tokens](https://qaopsstaging-skyline.on.dataminer.services/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Tokens).

1. Click *Create Token* in the top-left corner.

1. Enter a name for the token.

1. Select the scope that matches the ".execute" scope for your chosen configuration.

1. If needed, use Shift+Click to select all scopes and allow full access. This is not recommended for production environments.

1. Click *Generate Token*.

1. Wait until the token value is shown.

1. Copy the token value and save it in a text file. For production environments, use a key vault solution.

## Step 4: Trigger the test run

1. Open a Command Prompt, Bash, or PowerShell window.

1. Run the following command:

	```bash
	dataminer-qaops test-run --token TOKEN -t TESTSUITE -c CONFIGURATION -tags MYNAME -san saqaopsstaging
	```

1. Replace the placeholders with your values:

	- `TOKEN`: the token value you copied earlier.

	- `TESTSUITE`: the test suite ID you copied earlier.

	- `CONFIGURATION`: the configuration ID you copied earlier.

	- `MYNAME`: your name, nickname, or another identifier that helps you find your request.

1. Press Enter to submit the request.

## Step 5: Verify that the request was received

1. In the *User App*, go to *Overview*: [https://qaopsstaging-skyline.on.dataminer.services/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Overview](https://qaopsstaging-skyline.on.dataminer.services/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Overview).

1. Locate your tag in the list.

1. Use the top filter to find your request more quickly.

1. Track the [test run life cycle](xref:QAOps_Test_Run).
