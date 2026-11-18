---
uid: github_reusable_workflows_okf_source_sync_review_workflow
description: "Learn how to call the shared OKF source-sync review workflow for generated pull requests in DataMiner repositories."
---

# OKF source-sync review workflow

The OKF Source Sync Review Workflow requests a review from the author of the merged source pull request when an OKF source-sync workflow generates a pull request.

## About OKF

[Open Knowledge Format (OKF)](https://github.com/GoogleCloudPlatform/open-knowledge-format) is a vendor-neutral format for representing knowledge in Markdown files. For the format specification, refer to the [OKF specification](https://github.com/GoogleCloudPlatform/open-knowledge-format/blob/main/SPEC.md).

## How to use this workflow

Keep the `workflow_run` trigger in the caller repository, then delegate the reviewer request to the shared workflow. The caller must grant `actions: read`, `contents: read`, and `pull-requests: write`:

```yml
name: Request OKF source-sync review

on:
  workflow_run:
    workflows:
      - OKF source sync
    types:
      - completed

permissions:
  actions: read
  contents: read
  pull-requests: write

jobs:
  request-review:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/OKF%20Source%20Sync%20Review%20Workflow.yml@main
```

The shared workflow acts only after a successful source-sync run. It matches the generated pull request to that exact run, validates the referenced merged source pull request and author, and requests a review without creating duplicates if the workflow runs more than once. It safely skips preview, no-op, ambiguous, and ineligible cases.
