---
uid: QAOps_Tutorials_User_Tutorials_Basic_How_To_View_Results
---

# How to view test results

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you learn how to open a QAOps test run and interpret what each test result means.

This tutorial focuses on meaning and analysis, not only navigation.

For all tutorials, always use the "QAOps Sandbox Environment": [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

Expected duration: 10 minutes.

## Prerequisites

- Access to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

- A completed test run in *Demo Configuration* and *Demo Test Suite*.

> [!IMPORTANT]
> Please contact support.boost@skyline.be to receive a username and password for access to the Sandbox system.

## Overview

- [Step 1: Open a test run](#step-1-open-a-test-run)

- [Step 2: Understand result scope](#step-2-understand-result-scope)

- [Step 3: Interpret the outcome](#step-3-interpret-the-outcome)

- [Step 4: Interpret the test aspect](#step-4-interpret-the-test-aspect)

- [Step 5: Use message, duration, and tags](#step-5-use-message-duration-and-tags)

- [Step 6: Decide your next action](#step-6-decide-your-next-action)

Related information:

- [QAOps main UI](xref:QAOps_Main_UI)

- [QAOps test run](xref:QAOps_Test_Run)

- [QAOps test result](xref:QAOps_Test_Result)

## Step 1: Open a test run

1. Go to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

1. Select the green application named *QAOps*.

1. In the left-side menu, select *Configurations*.

1. Select *Demo Configuration*.

1. Select *Demo Test Suite*.

1. Select one completed run from the list.

## Step 2: Understand result scope

Before you interpret individual rows, identify the scope of the selected run.

1. Confirm which configuration and test suite are selected.

1. Confirm that you are looking at one specific run, not a mixed list of multiple runs.

1. Review the run status context in [QAOps test run](xref:QAOps_Test_Run), so you understand where in the lifecycle this run is or was.

Each test result represents one test case execution in that run.

## Step 3: Interpret the outcome

For field definitions, see [QAOps test result](xref:QAOps_Test_Result).

Start with the *Outcome* value, because it is the primary signal.

1. Treat *Ok* as a passed test case.

1. Treat *Fail* as a failed test case that requires investigation.

1. Treat *NotExecuted* as "did not run".

1. Treat *NotApplicable* as "intentionally not relevant" for this context.

Interpretation guidance:

- A high number of *Fail* outcomes usually indicates a product or environment problem.

- A high number of *NotExecuted* outcomes often indicates setup, dependency, or orchestration issues.

- A high number of *NotApplicable* outcomes can be valid, but you should verify that test targeting rules are correct.

## Step 4: Interpret the test aspect

The *TestAspect* field tells you what type of failure you are seeing.

1. Treat *Assertion* as product-behavior validation.

1. Treat *Execution* as test framework or runner health.

Interpretation guidance:

- *Fail* + *Assertion* usually means the system under test does not meet expected behavior.

- *Fail* + *Execution* usually means setup or framework instability, not necessarily a product defect.

- If many results fail with *Execution*, stabilize the test environment before drawing product conclusions.

## Step 5: Use message, duration, and tags

After you understand *Outcome* and *TestAspect*, use optional fields to refine your analysis.

1. Read *Message* to identify what was checked and why a failure occurred.

1. Check *Duration* to detect slow or unstable tests.

1. Use *Tags* to group and filter related results by ownership, component, or run metadata.

Interpretation guidance:

- A clear *Message* reduces investigation time and makes triage faster.

- Increasing *Duration* over time can indicate performance regression, infrastructure contention, or retries.

- Consistent *Tags* improve filtering and help route failures to the correct team.

## Step 6: Decide your next action

Use the result meaning to choose the right follow-up action.

1. If failures are mainly *Assertion*, investigate product behavior.

1. If failures are mainly *Execution*, investigate pipeline stability, dependencies, and environment readiness.

1. If outcomes are mostly *NotExecuted*, verify run prerequisites and setup order.

1. If outcomes are mostly *NotApplicable*, verify test selection logic.

1. Record your conclusion with links to the run, key results, and evidence from *Message*, *Duration*, and *Tags*.

This approach helps you avoid false conclusions and keeps troubleshooting focused on the actual failure type.

