---
metadata_version: 1
uid: CTB_Documentation_Governance
description: Define review ownership, cadence, stale thresholds, escalation, and conflict handling for DataMiner Docs workstreams and metadata.
area: contributing
content_type: conceptual
authority: canonical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner documentation
version: "D6.1"
owner: unknown
review_status: approved
review_date: 2026-09-19
compatibility:
  uid: stable
  url: stable
---

# Documentation governance and review cadence

The Docs Writing Team is the accountable repository pull request and review owner. This accountability covers the content, navigation, generated output, metadata, and CI evidence needed to publish DataMiner Docs. It does not assign an individual or an unconfirmed GitHub team handle.

The machine-readable policy is stored in `contributing/metadata/documentation-governance-v1.json`. The policy is checked by `scripts/validate-documentation-governance.ps1` and is intended to complement, not replace, the version 1 metadata contract in [Documentation metadata contract](xref:CTB_Documentation_Metadata).

## Workstreams and review cadence

The following targets are calendar-based review targets, not service-level agreements. A review can happen earlier when a source contract, package, product behavior, or publication process changes.

| Workstream or content class | Authority and change pattern | Review target | Stale-content threshold | Primary evidence |
|--|--|--:|--:|--|
| Schema and API generation | Canonical or reference, high-frequency generated output | 90 days | 120 days | D2.3 generated-metadata provenance, D3.1 manifest, and generated build output |
| Package and tooling | Canonical or reference, high-frequency dependencies and validation tools | 90 days | 120 days | Package metadata, repository scripts, build workflow, and validation results |
| Connector normative guidance | Canonical or reference, normative product and development guidance | 180 days | 270 days | D2.2 Connector migration report, source schema, and DocFX validation |
| Automation normative guidance | Canonical or reference, normative product and development guidance | 180 days | 270 days | D2.2 Automation migration report, source schema, and DocFX validation |
| Documentation platform | Canonical or reference, repository process and publication infrastructure | 180 days | 270 days | D0.3 ownership and corpus policy, D4 quality and safety reports, and D5 sitemap or deployment-delta reports |
| Illustrative and example content | Illustrative authority, lower change rate | 365 days | 540 days | Example source, linked contract, and DocFX validation |
| Legacy and historical content | Historical authority or `legacy` content type | 730 days | 1095 days | Source history, release context, and an explicit migration or archival decision |

The generated API and schema profile takes precedence for `schema` and `api` pages in the Connector and Automation paths. The workstream still identifies the accountable evidence and review route.

When `authority` is `unknown` or `not_applicable`, the validator reports an authority gap instead of assigning a cadence. The page remains eligible for normal review, but its date must not be presented as evidence that an unconfirmed contract is current. A page that reaches the review target is due for review; a page that reaches the stale threshold must be updated, explicitly marked `needs_update`, or have the unresolved reason recorded in the pull request.

## Ownership and metadata expectations

1. New pages and pages in an opted-in migration scope use `metadata_version: 1` and all required fields from the metadata contract.

1. The `owner` value is an existing owner handle, `unknown`, or `not_applicable` exactly as permitted by the metadata contract. Do not use the name of the Docs Writing Team as a substitute for a confirmed handle, and do not invent a person, email address, or team alias.

1. `authority`, `content_type`, and `lifecycle` describe what the page claims and how it is maintained. Select the cadence from the authority and change pattern, not from the folder name alone.

1. `review_status` and `review_date` record the latest evidence-based review. Use `needs_update` when a known review or content gap remains, `unknown` when no review evidence is available, and `not_applicable` only when review has no meaningful application. Do not refresh a date without reviewing the page.

1. Preserve the UID and published URL by default. If a URL must change, use the compatibility and redirect rules from the metadata contract and the D5.2 deployment-delta policy.

The governance validator reports owner and authority gaps without replacing them with guesses. Existing D2.2 pages can therefore remain on the documented migration path while their unresolved values are visible for follow-up.

## Review and escalation path

Use the repository's normal pull request flow. Include the affected workstream, authority and change-rate classification, generated outputs or source contracts, validation evidence, and any stale or unresolved metadata in the pull request description.

1. The contributor checks the page metadata and runs `scripts/validate-documentation-metadata.ps1` and `scripts/validate-documentation-governance.ps1`. The latter produces a metadata-only report and does not publish a corpus or deployment artifact.

1. The Docs Writing Team reviews the requested change, navigation, cross-references, metadata, generated-output provenance, and applicable D0.3 distribution boundaries. Domain evidence can be supplied by contributors or subject-matter reviewers without changing repository accountability.

1. If the change affects generated API or schema pages, regenerate from the documented source and inspect D2.3 provenance before reviewing the rendered result. Do not hand-edit generated output to hide a source mismatch.

1. If a change affects the D3.1 manifest, D4 quality or safety evidence, D5.1 sitemap output, or D5.2 deployment delta, review the corresponding report and preserve its immutable identity, URL, license, and attribution rules.

1. If a published page is materially misleading, submit a narrow corrective pull request, mark the known review or content gap as `needs_update`, and describe the risk and evidence. This process defines routing, not a response-time promise.

## Unresolved conflicts

When sources disagree, do not silently choose a convenient value.

- A confirmed canonical source takes precedence over a reference or illustrative page. Keep the page's UID and URL stable while correcting the content.
- If two sources have equal authority, or no source can be confirmed, record the conflict in the pull request, route it to the Docs Writing Team, and do not merge a normative resolution until the authority decision is documented.
- If generated output disagrees with its source, resolve the source or generation configuration and rerun the provenance check. The D5.2 delta must report ambiguous identity matches rather than guessing a move or redirect.
- If ownership or the exact review handle is unresolved, retain `unknown`, keep the existing CODEOWNERS route, and record the follow-up. Do not block a safe corrective change by fabricating an owner, but do not represent the unresolved page as approved evidence for a new contract.

The exact GitHub team handle for the Docs Writing Team is still unconfirmed. The explicit follow-up is to confirm that handle before changing `.github/CODEOWNERS`; the current route must not be replaced with a guessed alias.

## Local and CI checks

From the repository root, run the governance validator after the version 1 metadata validator:

```powershell
.\scripts\validate-documentation-metadata.ps1 -RepositoryRoot .
.\scripts\validate-documentation-governance.ps1 -RepositoryRoot . -ReportPath .\_artifacts\documentation-governance.json
```

The workflow also runs the D2.2 migration, D2.3 provenance, D3 manifest, D5 deployment-delta, baseline, and DocFX checks. Treat warnings introduced by a change as failures. Report warnings that predate the change separately in the pull request, as described in [Making a local test build before pushing changes](xref:CTB_Local_Test_Build).
