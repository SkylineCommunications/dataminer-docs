---
uid: QAOps_Tutorials_User_Tutorials_Basic_How_To_View_Results
---

# Viewing test results

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to open a QAOps test run and interpret what each test result means. This tutorial focuses on meaning and analysis rather than merely navigation.

Expected duration: 5 minutes.

## Prerequisites

- Access to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be). This "QAOps Sandbox Environment" environment should be used for every QAOps tutorial.

  > [!NOTE]
  > Please contact <support.boost@skyline.be> to receive a username and password for access to the Sandbox system.

- A completed test using the *Demo Configuration* and *Demo Test Suite*.

## Overview

- [Step 1: Open a test run](#step-1-open-a-test-run)

- [Step 2: Understand the result scope](#step-2-understand-the-result-scope)

- [Step 3: Interpret the outcome](#step-3-interpret-the-outcome)

- [Step 4: Interpret the test aspect](#step-4-interpret-the-test-aspect)

- [Step 5: Use message, duration, and tags](#step-5-use-message-duration-and-tags)

- [Step 6: Decide your next action](#step-6-decide-your-next-action)

## Step 1: Open a test run

1. Go to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

1. Select the green application named *QAOps* (also known as the *QAOps User* app).

1. In the navigation pane on the left, select *Configurations*.

1. Select *Demo Configuration*.

1. Select *Demo Test Suite*.

1. Select a completed run in the list of test runs.

## Step 2: Understand the result scope

Before you interpret individual rows, identify the scope of the selected run:

1. Confirm which configuration and test suite are selected.

1. Confirm that you are looking at one specific run, not a mixed list of multiple runs.

1. Refer to [QAOps test run](xref:QAOps_Test_Run) and check the run status context, so you understand where in the lifecycle this run is or was.

Each test result represents one test case execution in that run.

## Step 3: Interpret the outcome

While the test run is selected, check the results in the *Outcome* column of the test results overview. This column is the primary signal of what happened with the test case.

- Treat *Ok* as a passed test case.

- Treat *Fail* as a failed test case that requires investigation. A high number of *Fail* outcomes usually indicates a product or environment problem.

- Treat *NotExecuted* as "did not run". A high number of *NotExecuted* outcomes often indicates setup, dependency, or orchestration issues.

- Treat *NotApplicable* as "intentionally not relevant" for this context. A high number of *NotApplicable* outcomes can be valid, but you should verify that test targeting rules are correct.

> [!TIP]
> For field definitions, see [QAOps test result](xref:QAOps_Test_Result).

## Step 4: Interpret the test aspect

The *TestAspect* column in the test results overview tells you what type of failure you are looking at:

- Treat *Assertion* as product-behavior validation. *Fail* + *Assertion* usually means the system under test does not meet expected behavior.

- Treat *Execution* as test framework or runner health. *Fail* + *Execution* usually means setup or framework instability, not necessarily a product defect.

- If many results fail with *Execution*, stabilize the test environment before drawing product conclusions.

## Step 5: Use message, duration, and tags

After you understand *Outcome* and *TestAspect*, use optional fields to refine your analysis.

- Read *Message* to identify what was checked and why a failure occurred. A clear message reduces investigation time and makes triage faster.

- Check *Duration* to detect slow or unstable tests. Increasing duration over time can indicate performance regression, infrastructure contention, or retries.

- Use *RawTags* to group and filter related results by ownership, component, or run metadata. These tags improve filtering and help route failures to the correct team.<!-- TBD -->

## Step 6: Decide your next action

1. Choose the right follow-up action based on the results:

   - If failures are mainly *Assertion*, investigate product behavior.

   - If failures are mainly *Execution*, investigate pipeline stability, dependencies, and environment readiness.

   - If outcomes are mostly *NotExecuted*, verify run prerequisites and setup order.

   - If outcomes are mostly *NotApplicable*, verify test selection logic.

1. Record your conclusion (e.g., in Collaboration), making sure to refer to the run, key results, and evidence from *Message*, *Duration*, and *Tags*.

This approach helps you avoid false conclusions and keeps troubleshooting focused on the actual failure type.
