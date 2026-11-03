---
uid: QAOps_Tutorials_Adding_QAOps_Checks
description: Add a QAOps test suite and configuration to a quality gate, inspect its evidence, and distinguish refreshing status from starting new tests.
---

# Adding QAOps checks to a quality gate

In this tutorial, you will add a QAOps check to the gate you [created earlier](xref:QAOps_Tutorials_Creating_A_Quality_Gate). A check connects one test suite to one configuration, so its result answers a specific question, such as whether your regression tests pass on a release candidate.

Expected duration: 10 minutes, excluding the duration of a new test run.

## Prerequisites

- A quality gate on [QAOps Sandbox](https://qaops-sandbox.skyline.be/public/qaops-quality-gates/index.html) that you can edit.

- An existing sandbox [configuration](xref:QAOps_Configuration) with an allowed [test suite](xref:QAOps_Test_Suite).

The screenshots use the staging configuration *Run-Scoped RC* and suite *Run-Scoped*. Select the pair appropriate for your own sandbox tests; available names and IDs can differ.

## Step 1: Add a QAOps check

1. Open your gate.

1. Click *Configure gate*.

1. Under *Checks*, click *Add QAOps check*.

1. Enter a *Check name*, for example `Release candidate regression`.

1. Select the *Configuration* on which the tests should run.

1. Select the *Test suite*.

   Only suites allowed by the selected configuration will be available. Changing the configuration can clear the selected suite.

   ![QAOps check named Release candidate regression with Run-Scoped RC configuration and Run-Scoped test suite selected](~/develop/images/QAOps_QualityGates_AddQAOpsCheck.png)

1. Click *Save gate*.

1. Wait for save verification and return to the saved gate.

## Step 2: Inspect the evidence

1. Open *Checks*.

1. Find your new check and inspect its status and evidence.

   The gate will evaluate the latest terminal run for the exact configuration and suite. Adding a check does not start a new run. If no suitable evidence exists, expect a warning rather than a pass.

1. Follow the available result link to inspect the underlying test results.

   If no link is available, open the QAOps User app's [Results page](xref:QAOps_Main_UI#qaops-user---results) on sandbox and select the same configuration and suite. A newer failing run will not be replaced by an older passing result. Outdated or incomplete evidence also needs attention.

1. Click *Refresh status* if you need to request reevaluation after results become available.

   Refreshing status does not execute the suite.

## Step 3: Produce a new result when needed

You can use the existing [test-run workflow](xref:QAOps_Tutorials_User_Tutorials_Basic_How_To_Trigger_A_Test_Run) to execute the selected configuration and suite on sandbox, then return to the gate. Use `-san saqaopssandbox` with the test-run command.

To run QAOps checks directly from the gate instead:

1. Open *Configure gate* > *Run setup*.

1. Select *Enable QAOps execution*.

   The gate owner or a Quality Gate administrator must set up execution. Being an editor alone does not grant run permission.

1. Under *Who can run*, review the allowed runners.

   To add a runner, enter their name in *Find a DataMiner user*, click *Find users*, and use *Allow* for the intended account.

1. Select an available *Execution credential*.

   The credential must authorize this gate and every QAOps configuration referenced by its checks. An external reporting token is not an execution credential.

   ![Run setup with allowed runners, an execution credential selector, and a separate save action that does not start tests](~/develop/images/QAOps_QualityGates_RunSetup.png)

   If no suitable credential is available, first follow [Creating an execution credential](#creating-an-execution-credential) below.

1. Click *Save execution settings*.

   Saving these settings will not start tests.

1. Return to the gate and click *Run QAOps Checks*.

   This action will request new QAOps runs and can provision DaaS servers. It will not execute external checks.

1. Follow the execution and inspect the resulting evidence.

   Running and queued counts describe activity, not a passing verdict.

### Creating an execution credential

If you do not have a suitable credential, create one from *Run setup* before saving execution settings:

1. Expand *Create an execution credential*.

1. Enter *Valid for (days)*.

1. Enter *Maximum test-suite runs*.

1. Click *Create credential*.

1. Once generation finishes, click *Refresh execution settings*.

1. Select the new credential.

   The generated name will start with `Gate execution:` followed by your gate ID. The Quality Gates app will not display the secret. Continue with *Save execution settings* in the procedure above.

For a daily status update without starting tests, continue with [Scheduling a quality gate digest](xref:QAOps_Tutorials_Scheduling_A_Quality_Gate).
