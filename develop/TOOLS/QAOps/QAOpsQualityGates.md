---
uid: QAOps_Quality_Gates
description: Learn how QAOps quality gates combine internal and external checks, track evidence freshness, assign failures, and schedule status digests.
---

# QAOps quality gates

> [!IMPORTANT]
> This section contains information that is only applicable to Skyline employees.

A quality gate is a shared answer to a practical question: **Do we have enough recent evidence to trust this product or change?**

Instead of checking several test runs, build reports, and messages separately, you collect the checks that matter in one gate. For example, a release-readiness gate can combine regression tests on a release candidate with a validation report from an external pipeline. The gate shows whether the evidence is passing, failing, or needs attention, and helps your team decide what to investigate.

A gate does not, by itself, block a release. Your release process or pipeline must use its result to decide whether to continue.

## Open Quality Gates

Open the Quality Gates web app on your QAOps system. For the exercises in this section, use [QAOps Staging Quality Gates](https://qaopsstaging-skyline.on.dataminer.services/public/qaops-quality-gates/index.html).

The screenshots in this section were captured on QAOps Staging in November 2026. Objects, permissions, and credentials are specific to each environment.

![QAOps Quality Gates overview showing checks and the gate verdict](~/develop/images/QAOps_QualityGates_Overview.png)

## Combine QAOps and external checks

A gate supports two kinds of checks:

- **QAOps checks** connect a [configuration](xref:QAOps_Configuration) to a [test suite](xref:QAOps_Test_Suite). This identifies both what to test and the environment to test it on. The gate evaluates evidence for that exact pair, rather than combining all runs of a suite across different configurations.

- **External checks** receive a result from outside QAOps, such as a build pipeline, validation script, or another test platform. Each external check has its own reporting source and requires a token authorized to report to that source. Adding the check does not start the external process.

You can combine both kinds in the same gate. Open *Checks* to inspect the individual checks and their evidence, and follow result links when you need more detail.

## Understand the verdict

The gate summarizes the available evidence:

- **OK**: The required checks have fresh, usable passing evidence.

- **FAIL**: A required check has fresh failing evidence.

- **WARNING**: Evidence needs attention, for example because a report is missing, outdated, incomplete, or reports a warning.

An empty gate cannot pass. A gate that has not loaded its status can display *UNKNOWN*; this is not a passing result.

Running and queued checks are shown separately from the verdict. Starting a new run does not mean that it has already passed.

### Keep evidence recent and complete

The *Evidence freshness (seconds)* setting determines how old evidence may be before it becomes outdated. The default is 172800 seconds (48 hours). A previously passing result is no longer sufficient after it expires. An expired failure also becomes a warning about outdated evidence, not proof that the problem was fixed.

For QAOps checks, the gate uses the latest terminal run for the selected configuration and suite. It does not fall back to an older passing run when a newer one fails. Keep *Require proven result completeness* enabled so missing results cannot be mistaken for a successful test run.

The *Refresh interval (seconds)* controls status reevaluation, not how often tests run. *Refresh status* requests an evaluation of available evidence; it does not launch tests. *Run QAOps Checks* is a separate action that requires execution setup and run permission.

### Define what counts as a failure

Under *Configure gate* > *Failure policy*, you can define rules for QAOps evidence, for example a failed run, a completed run with no results, a drop in test count, or a metric crossing a threshold. Use *Preview policy* to inspect the effect before saving. Previewing a policy does not save it or run tests.

## Make responsibility visible

There are different kinds of ownership:

- **Gate owner and editors** maintain the definition. Your signed-in account becomes the owner when you create a gate. You can add named editors under *People and permissions*. Read access, editing, and permission to run checks are separate.

- **External source maintainer** identifies who maintains a reporting source. This does not replace the reporting token.

- **Failure assignee** identifies who is investigating an open failure. In *Failures*, open the failure responsibility view and use *Claim failure*. You can add notes and evidence links, unclaim your assignment, or take over an assignment with confirmation.

Claiming a failure does not turn a failing check into a passing check. It makes follow-up visible to the team. The *Unclaimed failures* count helps you spot problems that no one has picked up yet.

![Failure responsibility page with an unassigned failure, the Claim failure action, and fields for investigation notes and links](~/develop/images/QAOps_QualityGates_FailureResponsibility.png)

## Schedule digests and notifications

Under *Automation*, you can configure notification rules for failures, warnings, recovery, completed executions, and digests. Destinations can be email or a Teams Workflow.

A digest schedule uses a five-field cron expression and an explicit time zone. For example, `0 9 * * *` with `Europe/Brussels` schedules a daily digest at 09:00 Brussels time.

> [!NOTE]
> Scheduling currently supports **status digests, not automatic test execution**. A digest reevaluates the available evidence and queues a snapshot for matching notification rules. It does not start QAOps tests or your external process. Schedule those separately in your pipeline or scheduler.

Preview the upcoming occurrences before enabling a schedule. Use schedule history and notification delivery information to check what happened; saving a rule or schedule does not send a test notification.

## Tutorials

- [Creating a quality gate](xref:QAOps_Tutorials_Creating_A_Quality_Gate)

- [Adding QAOps checks to a quality gate](xref:QAOps_Tutorials_Adding_QAOps_Checks)

- [Scheduling a quality gate digest](xref:QAOps_Tutorials_Scheduling_A_Quality_Gate)

- [Adding and reporting external checks](xref:QAOps_Tutorials_External_Quality_Gate_Checks)
