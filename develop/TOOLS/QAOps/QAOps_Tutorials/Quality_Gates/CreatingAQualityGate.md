---
uid: QAOps_Tutorials_Creating_A_Quality_Gate
description: "Create your first QAOps quality gate, choose evidence freshness settings, and understand gate ownership before adding internal or external checks."
---

# Creating a quality gate

In this tutorial, you will create a quality gate for a release-readiness overview. You will configure the basics and learn where to add checks and editors.

Expected duration: 10 minutes.

## Prerequisites

- Access to [QAOps Sandbox Quality Gates](https://qaops-sandbox.skyline.be/public/qaops-quality-gates/index.html), with permission to create gates.

- A basic understanding of [QAOps quality gates](xref:QAOps_Quality_Gates).

Use sandbox throughout this tutorial. Do not copy configuration IDs or tokens from production or staging into the exercise. The screenshots were captured on staging; create your own gate in sandbox.

## Step 1: Create the gate

1. Open the sandbox Quality Gates app.

1. Click *Create gate*.

1. In *Gate name*, enter `Example release readiness`, or another name you can recognize.

1. In *Description*, explain the decision this gate supports.

   For example: `Combine QAOps regression results with an external validation report.`

   ![Create quality gate form with an example name, description, refresh interval, and evidence freshness](~/develop/images/QAOps_QualityGates_CreateGate.png)

## Step 2: Choose how evidence is evaluated

1. Leave *Refresh interval (seconds)* at `300` for this exercise.

   This is the interval for reevaluating status. It does not schedule test runs.

1. Leave *Evidence freshness (seconds)* at `172800`.

   Evidence will be considered outdated after 48 hours. In a real gate, choose a freshness window that fits how often your checks actually produce results.

1. Keep *Require proven result completeness* selected.

   This helps prevent an apparently successful run with missing results from being treated as sufficient evidence.

## Step 3: Save and verify the gate

1. Click *Create gate* at the bottom of the form.

1. Wait until the app opens the saved gate.

   If the app says the server accepted the save and is verifying the saved state, do not submit it again. Use *Check saved gate* when available if verification takes longer.

1. Check that the gate name and description match what you entered.

   Your signed-in account will be the gate owner. The gate will not pass yet because it has no checks. Saving the gate does not run tests or send notifications.

## Step 4: Review who can maintain the gate

1. Open *Configure gate*.

1. Go to *People and permissions*.

1. If someone else should maintain the gate, enter their name in *Find people to add as editors*.

1. Click *Search people*.

1. Select the intended editor from the results.

1. Click *Save gate* if you changed the editors.

   Gate data is visible to signed-in app users. Editing permission does not automatically grant permission to run checks. Only a Quality Gate administrator can enable editing for *All Users*.

You now have a saved gate. Continue with [Adding QAOps checks](xref:QAOps_Tutorials_Adding_QAOps_Checks) or [Adding and reporting external checks](xref:QAOps_Tutorials_External_Quality_Gate_Checks).
