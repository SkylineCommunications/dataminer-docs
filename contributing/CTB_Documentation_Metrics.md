---
metadata_version: 1
uid: CTB_Documentation_Metrics
description: Explain the deterministic D6.3 quality and synchronization metrics that combine DataMiner Docs evidence without exposing prose or secrets.
area: contributing
content_type: conceptual
authority: canonical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner documentation
version: "D6.3"
owner: unknown
review_status: approved
review_date: 2026-09-19
compatibility:
  uid: stable
  url: stable
---

# Documentation quality and synchronization metrics

D6.3 combines the existing D2-D6 validation evidence into one deterministic, metadata-only report. The report is written to `_artifacts/documentation-metrics.json` and is validated against `contributing/metadata/documentation-metrics-v1.schema.json`.

The report is an internal CI evidence artifact. It contains counts, statuses, stable identities, artifact paths, hashes, and explicit gaps. It does not contain Markdown, rendered page text, transformed snippets, prompts, summaries, embeddings, credentials, or secrets.

## Metric groups

The report includes the following metric groups:

- `metadataCoverage`: D2 metadata page coverage and unknown version, authority, owner, and review values.
- `uidUrlLinkHealth`: stable UID and URL inventory, cross-reference health, local links, external-link results, and sitemap URL counts.
- `snippetValidation`: C# compilation and XML schema validation counts.
- `qualityGates`: D4 quality findings, legacy exceptions, external-link failures, and pre-existing warning counts.
- `safety`: D4 safety findings, new versus legacy findings, allowlisted findings, classification gaps, and normative contradictions.
- `generatedProvenance`: D2 generated API and schema output and source-artifact counts.
- `governance`: D6.1 stale reviews, pending reviews, owner and authority gaps, and evidence gaps.
- `coupling`: D6.2 matched entries, targeted checks, acknowledgement state, release-gate state, and unresolved follow-ups.
- `sourceDocumentationDelta`: D3 manifest, D5 deployment-delta, sitemap, and source-to-documentation event counts.
- `agentSync`: synchronization event counts and lag when an approved event source is available.

Connector and Automation values are retained separately in each metric group when the source report provides a domain or a path that can be classified safely. A value is not assigned to a domain when the evidence does not support that classification.

## Unknown values and gaps

Use `unknown` when a source exists but cannot confirm a value. Use `not_available` when the source artifact or event source does not exist. These values are different from zero. For example, a missing agent event source produces an `agentSync` lag of `unknown` and an explicit `not_available` gap; it does not invent a synchronization event, timestamp, owner, or service-level target.

The report retains unresolved contradictions and gaps as coded counts. Existing warnings remain visible as pre-existing evidence and are not described as fixed by the metrics report. The report identity is a SHA-256 value derived from the source revision, input artifact fingerprints, metric values, and gap records. Generation dates are excluded from that identity.

When the D5 deployment delta contains no events, redirects, or tombstones, D6.3 records `empty: true` and produces a stable identity for the same inputs. A missing delta remains `not_available` instead of being reported as an empty deployment.

## Generate and validate the report

From the repository root, run the following commands after the D2-D6 reports have been generated:

```powershell
.\scripts\generate-documentation-metrics.ps1 `
  -RepositoryRoot . `
  -BaselinePath .\docs-corpus-baseline.generated.json `
  -OutputPath .\_artifacts\documentation-metrics.json
.\scripts\validate-documentation-metrics.ps1 `
  -RepositoryRoot . `
  -Path .\_artifacts\documentation-metrics.json
```

The workflow validates the report on pull requests and retains it only for the canonical protected `main` branch or a scheduled run. Retention is 90 days, matching the approved operational retention boundary for commit-addressed metadata evidence. The report is not deployed with the documentation site.
