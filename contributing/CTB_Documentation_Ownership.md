---
metadata_version: 1
uid: CTB_Documentation_Ownership
description: Define accountable ownership, review routing, and follow-up requirements for DataMiner Docs changes and documentation workstreams.
area: contributing
content_type: conceptual
authority: canonical
authority_source: not_applicable
applies_to:
  - DataMiner documentation
version: "D0.3"
owner: unknown
---

# Documentation ownership and review routing

The Docs Writing Team is accountable for the DataMiner Docs pull requests, documentation review routing, and the documentation workstreams listed below. The accountable owner is a team responsibility, not an instruction to assign an unconfirmed individual or GitHub handle.

The review targets, stale-content thresholds, escalation path, and unresolved-conflict rules are defined in [Documentation governance and review cadence](xref:CTB_Documentation_Governance). This page defines the accountable repository route; it does not replace the D0.1 metadata contract or assign page owners.

## Accountable workstreams

The Docs Writing Team owns the review and maintenance process for:

- Connector documentation, including connector development guidance, protocol schema documentation, and related tooling documentation.
- Automation documentation, including Automation development guidance, Automation schema documentation, and relevant API documentation.
- Generated schema and API documentation, including the source configuration and the generated-page review process.
- Documentation tooling and CI, including DocFX configuration, repository scripts, workflow changes, validation, and artifact handling.
- Product-to-documentation dependency mapping and coupling evidence, including the affected UID and area report and the documentation-release gate. This does not assign a product owner or cross-repository workflow permission.

The team also owns the quality and compatibility review of changes elsewhere in the repository when those changes affect the published DataMiner Docs site.

## Pull request review routing

All documentation pull requests should use the repository's normal review flow:

1. The contributor describes the affected documentation area and any generated output in the pull request.

1. When a product change is the source of the documentation work, the contributor includes the D6.2 coupling report, affected UIDs and areas, source release or package identity, and acknowledgement/update gate status. Unconfirmed cross-repository values remain `unknown` with a follow-up.

1. The Docs Writing Team reviews the content, navigation, cross-references, generated documentation impact, and applicable policy boundaries.

1. The pull request is merged only after the required checks pass and the accountable reviewers approve it.

The repository currently contains a global CODEOWNERS route for `@SkylineCommunications/team-docs-reviewers`. This existing route is not treated as confirmation of the exact GitHub handle for the Docs Writing Team.

> [!IMPORTANT]
> Follow-up: confirm the exact GitHub team handle for the Docs Writing Team, then update `.github/CODEOWNERS` if a dedicated handle is required. Do not replace the current route with a guessed alias.

Until that follow-up is completed, use the documented team name in ownership decisions and the existing CODEOWNERS route for repository review notifications. Record unconfirmed ownership as `unknown` in version 1 page metadata instead of inventing an owner.

## Ownership changes

Changes to accountable ownership, review routing, or workstream scope must be documented in the pull request that makes the change. A contributor may propose a routing change, but the change is not effective until the Docs Writing Team confirms it and the repository configuration is updated with a verified handle.
