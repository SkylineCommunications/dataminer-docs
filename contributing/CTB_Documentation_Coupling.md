---
metadata_version: 1
uid: CTB_Documentation_Coupling
description: Explain how product schema, API, package, validator, template, and behavior changes map to DataMiner Docs checks and release acknowledgement.
area: contributing
content_type: conceptual
authority: canonical
authority_source: CTB_Documentation_Governance
lifecycle: active
applies_to:
  - DataMiner documentation
version: "D6.2"
owner: unknown
review_status: approved
review_date: 2026-09-19
compatibility:
  uid: stable
  url: stable
---

# Documentation dependency mapping and coupling

Product contracts and product behavior can change outside the DataMiner Docs repository. A schema, API, package, validator, template, or behavior change can therefore make a page inaccurate even when no Markdown file was changed. D6.2 makes that coupling explicit without assigning a cross-repository owner, GitHub handle, permission, or service-level agreement.

The machine-readable map is `contributing/metadata/documentation-dependency-map-v1.json`. Its contract is `contributing/metadata/documentation-dependency-map-v1.schema.json`, and the caller-supplied product change contract is `contributing/metadata/documentation-coupling-change-v1.schema.json`. The map is repository metadata. It does not change the public documentation, its license, or its distribution boundary.

## Identify the affected documentation

The product PR or change author supplies a version 1 change object to `scripts/resolve-documentation-coupling.ps1`. The object must contain:

- `changeKinds`: one or more of `schema`, `api`, `package`, `validator`, `template`, or `behavior`.
- `changedPaths`: paths in the product change, normalized with `/`.
- `affectedDocumentation.uids`: the stable documentation UIDs that may need an update.
- `affectedDocumentation.areas`: the affected top-level documentation areas.
- `source`: the product repository, pull request, immutable revision, release, and package identity. Use `unknown` with a follow-up when a value cannot be confirmed.

The resolver matches a change by change kind, source path pattern, explicit UID, explicit area, or changed documentation path. It reports every matching map entry, target UID, target area, target path, and check. It does not infer a product owner or silently broaden an unresolved scope. A product change that matches no entry is reported as an unmapped change.

For a documentation-only pull request, the same resolver can derive changed paths from Git:

```powershell
.\scripts\resolve-documentation-coupling.ps1 `
  -RepositoryRoot . `
  -BaseRevision $env:COUPLING_BASE_REVISION `
  -HeadRevision $env:GITHUB_SHA `
  -OutputPath .\_artifacts\documentation-coupling.json
```

For a product PR, invoke the resolver after checking out this repository or make the map and scripts available to the product workflow:

```powershell
.\scripts\resolve-documentation-coupling.ps1 `
  -RepositoryRoot . `
  -ChangePath .\product-change.json `
  -OutputPath .\_artifacts\documentation-coupling.json `
  -FailOnUnmapped `
  -FailOnGate
```

The map records the cross-repository trigger as `unknown` and `caller_supplied`. No `repository_dispatch` permission is assumed. Confirming whether a product workflow can invoke the resolver is an explicit follow-up in the map.

## Trigger the targeted checks

The resolver returns `targetedChecks` in the coupling report. The check IDs compose the existing D0-D5 and D6.1 contracts:

| Check | Purpose |
|--|--|
| `dependency-map` | Validate the D6.2 map, target UIDs, regular expressions, and unresolved follow-ups. |
| `metadata` | Validate version 1 front matter for affected pages. |
| `governance` | Apply D6.1 ownership, authority, cadence, and stale-content reporting. |
| `provenance` | Validate D2.3 generated API and schema provenance when generated output is affected. |
| `manifest` | Validate the D3.1 metadata-only content manifest. |
| `delta` | Validate the D5.2 deployment delta when a publication identity can change. |
| `docfx` | Run DocFX metadata and `docfx build --warningsAsErrors`. |
| `actionlint` | Check workflow syntax when the change affects workflow or CI configuration. |

The documentation repository workflow validates the map and emits a coupling report for the repository diff. A product workflow can use the same report to run only the checks returned for its matched entries. The report is metadata-only and internal CI evidence. The normal full documentation workflow remains a valid superset of the targeted checks.

Run the map checks locally in this order:

1. Validate the dependency map and optional product change object:

   ```powershell
   .\scripts\validate-documentation-dependency-map.ps1 -RepositoryRoot . -ChangePath .\product-change.json
   ```

1. Resolve the coupling report and enforce both the mapping and documentation gates:

   ```powershell
   .\scripts\resolve-documentation-coupling.ps1 -RepositoryRoot . -ChangePath .\product-change.json -FailOnUnmapped -FailOnGate
   ```

1. Run the checks listed in `targetedChecks`. For a schema or API change, this includes the D2.3 provenance check after `docfx metadata`. For a publication-affecting change, it includes the D3.1 manifest, D5.2 delta, and DocFX checks.

Treat warnings introduced by the change as failures. Report warnings that predate the change separately; do not suppress them or present them as resolved by the coupling report.

## Record generated source identity

Generated API and schema references, and generated examples, must record the source identity that was used to produce or verify them:

- `generatedReferences.contentTypes` identifies `api`, `schema`, and/or `example`.
- `generatedReferences.sourceIdentity.release` records the product release.
- `generatedReferences.sourceIdentity.package.id` and `package.version` record the package identity.
- D2.3 `artifacts` and `artifactIds` remain the evidence for generated source files, assemblies, XML documentation, schema identities, and NuGet packages.

Do not replace an unavailable release or package value with the documentation commit, a guessed version, or a current date. Use `unknown` and keep the required follow-up. The resolver leaves the documentation gate pending when a matched generated dependency has an unresolved source identity.

The D3.1 manifest remains metadata-only. It may retain dependency identifiers and immutable source pointers, but it must not contain generated prose, examples, code excerpts, chunks, summaries, embeddings, prompts, or secrets.

## Acknowledge and update before documentation release

The `documentation-release-gate` is required before a documentation release for a matched product change. It passes only when:

1. `acknowledgement.status` is `acknowledged` and its evidence is recorded.
2. `documentationUpdate.status` is `updated` or `not_applicable`, with the affected UIDs and areas recorded.
3. Every required generated source identity is known, or the change is explicitly held as unresolved with a follow-up.

`unknown` produces a pending gate. `not_acknowledged`, `required`, or an unmapped product change fails the gate when `-FailOnGate` or `-FailOnUnmapped` is used. The map deliberately reports the relationship to a product release as `unknown`; it does not claim a product release blocker or an SLA.

Keep existing UIDs and published URLs stable. If a documentation path must move, apply the D0.1 compatibility and D5.2 redirect and tombstone contracts rather than changing an identity to make a dependency match.

## Distribution and unresolved follow-ups

The dependency map and coupling report do not publish product source, internal diagnostics, or transformed content. The public documentation remains unchanged and continues to use the existing D0.3 license and attribution. CI reports can be retained as internal validation evidence under the existing workflow retention boundaries.

The map keeps the following values unresolved until confirmed:

- the exact Docs Writing Team GitHub handle;
- the product repository and product workflow that can invoke the resolver;
- any cross-repository dispatch permission;
- the owner and product release relationship for the documentation gate.

Use the explicit follow-up fields in the map and change contract. Do not replace them with a person, team alias, permission claim, or response-time promise.
