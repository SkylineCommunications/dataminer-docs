---
metadata_version: 1
uid: CTB_Documentation_Corpus_Policy
description: Define CI artifact retention, publication boundaries, metadata manifest fields, licensing, attribution, and internal AI corpus handling for DataMiner Docs.
area: contributing
content_type: conceptual
authority: canonical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner documentation
version: "D0.3"
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Documentation corpus and distribution policy

This is a conservative project policy for the DataMiner Docs repository. It is not legal advice and does not replace a rights review for a particular contribution, source, or distribution.

## CI and artifact boundaries

Pull request workflows build and validate the documentation only. They must not deploy documentation or publish a machine-readable corpus or manifest to a public location. A pull request site preview or diagnostic artifact may be retained for 14 days when it is needed for validation, but it must not contain secrets or internal diagnostics that are not needed for that validation.

Publication and deployment are allowed only from the protected `main` branch in the canonical `SkylineCommunications/dataminer-docs` repository. The workflow must make this boundary explicit in its job conditions; a pull request must never reach a deployment or publication job.

Commit-addressed baseline and manifest artifacts must include all of the following:

- The full source commit revision.
- The generator name and version, and the manifest or baseline schema version.
- Content and configuration hashes.
- The scope that was audited or published.
- Stable UIDs and public URLs where they exist.
- License and attribution metadata.

Operational baseline copies may be retained for 90 days. Durable baseline history belongs in Git or controlled storage, not in an indefinitely retained workflow artifact. The committed D0.2 baseline is durable history; newly generated operational copies must remain tied to the source revision that produced them.

## Generated schema and API provenance

The D2.3 provenance artifact is generated after `docfx metadata` at `_artifacts/generated-metadata-provenance.json` and is validated against `contributing/metadata/generated-metadata-provenance-v1.schema.json`. It is a metadata-only CI artifact and is not deployed with the documentation site.

The artifact records the full source revision, deterministic generation date, DocFX configuration hash, generated API and schema output paths, URLs, and hashes, and the exact source project, source file, assembly, XML documentation, NuGet package, and overwrite identities that are available to the pipeline. Output records contain the raw artifact hash and a canonical hash with checkout-root paths normalized, so repeat-run comparisons do not depend on the local worktree path. Assembly and package versions are read from the artifact or restored package metadata. A schema page is linked to its documented schema identity and confirmed version; when the actual schema package is not present, the missing source is recorded as a gap rather than guessed.

Generated facts and manual material are separate fields. Required, default, range, enum, introduced, deprecated, and removed constraints are included only when they are present in generated tables or source XML documentation. Remarks and examples are represented as manual counts and section names, so they cannot be mistaken for generated contract facts.

Repeat runs with the same source revision and generation date must produce byte-identical JSON. The local generator derives its date from the explicit argument, `SOURCE_DATE_EPOCH`, or the source commit date, in that order. It never uses an unrecorded current time or invents package versions or lifecycle dates.

## Public metadata-only manifests

A public metadata-only manifest is allowed in principle, but it is not a public copy of the documentation corpus. Each entry must include:

- `uid`: the stable documentation UID.
- `url`: the public page URL.
- `sourceCommit`: the full source commit.
- `sourceBlob`: the source-file URL for that commit.
- `contentHash`: the hash of the normalized source content.
- `type`: the content type.
- `authority`: the authority classification, or `unknown` when it has not been confirmed.
- `lifecycle`: the lifecycle classification, or `unknown` when it has not been confirmed.
- `compatibility`: the UID and URL compatibility status.
- `license`: the license that applies to the referenced source.
- `attribution`: the required attribution.

The manifest must contain metadata only. Do not include Markdown, rendered page text, code excerpts, chunks, summaries, embeddings, prompts, or other transformed content in a public manifest. A source commit or blob URL is a pointer to the source, not a grant of additional rights to copy that source.

The D3.1 AI content manifest is generated at `_artifacts/ai-content-manifest.json` by `scripts/generate-ai-content-manifest.ps1` and is validated against `contributing/metadata/ai-content-manifest-v1.schema.json`. It extends the D0.3 source inventory rather than creating a second page inventory. Entries are sorted by UID and source path and contain only stable metadata, hashes, source pointers, and dependency identifiers. A run can compare a prior D3.1 manifest and marks each current entry as `added`, `changed`, `moved`, or `unchanged`; removed entries are retained as `removed` tombstones with their prior immutable source identity and the removal commit. A content change combined with a move is marked `changed` with `moved: true` and a `previous` identity. When the existing corpus contains duplicate or missing UIDs, the manifest retains the source-path identity where possible and records a gap instead of inventing a UID.

The workflow retains the commit-addressed D3.1 manifest for 90 days only from the protected `main` branch in the canonical repository. Pull requests may validate a generated copy but must not publish it to a public location. Consumers must treat the manifest as a discovery index and fetch the referenced source under its governing license rather than treating the manifest as a copy of the content.

## Deployment deltas

The D5.2 deployment delta is generated at `_artifacts/deployment-delta.json` by `scripts/generate-deployment-delta.ps1` and is validated against `contributing/metadata/deployment-delta-v1.schema.json`. It compares the current commit-addressed D3.1 manifest with the prior versioned manifest retrieved from protected-main workflow artifacts. The first deployment is safe when no prior artifact exists: the delta records the previous-manifest gap and additions rather than failing.

The delta is metadata-only. It records additions, content-hash changes, identity or URL moves, lifecycle transitions to `deprecated`, removals, immutable redirect mappings, and removed UID/URL tombstones. Current and previous records retain the UID, source path, full source commit, source blob, normalized content hash, compatibility metadata, license, and attribution. It never contains Markdown, rendered prose, summaries, chunks, embeddings, prompts, or secrets.

Existing UIDs and published URLs are preserved by default. A URL change is valid only with `compatibility.url: redirect_required` and exactly one permanent redirect mapping from the previous URL to the current URL. A changed UID or source path is reported as a move when a unique UID, source-path, or content-hash match proves the identity. Multiple possible matches are emitted as an ambiguous-move event and no redirect is guessed.

Removed entries are retained as UID/URL tombstones in the commit-addressed delta for the approved 90-day operational artifact period. A no-change deployment contains no events, redirects, or tombstones and sets `empty` to `true`. D5.2 artifacts are uploaded only from the canonical protected `main` branch, are not included in the deployed site, and use the same 90-day commit-addressed retention boundary as the D3.1 manifest.

## Governance evidence

The D6.1 governance report is generated at `_artifacts/documentation-governance.json` by `scripts/validate-documentation-governance.ps1`. It contains policy identifiers, workstream classifications, review-age findings, owner or authority gaps, and references to repository evidence paths. It does not contain page text, generated corpus content, secrets, or a substitute for the D0.1 metadata contract. The workflow retains the report for 14 days as validation evidence and does not publish it with the documentation site.

## Product-to-documentation coupling evidence

The D6.2 dependency map is stored in `contributing/metadata/documentation-dependency-map-v1.json`. The map and its reports are repository metadata and internal CI evidence. They preserve the public documentation distribution, the D0.3 license, and stable UID and URL identities. They must not contain product source, generated prose, examples, credentials, or other transformed corpus content.

The D6.2 resolver writes `_artifacts/documentation-coupling.json`. It records matched change kinds, documentation UIDs and areas, targeted check identifiers, source release and package identity fields, unresolved follow-ups, and the documentation-release gate. Product repositories may supply a change object using `contributing/metadata/documentation-coupling-change-v1.schema.json`; no cross-repository dispatch permission or product release blocker is assumed. An unavailable release or package value remains `unknown` with a follow-up.

## Quality and synchronization metrics

D6.3 combines D2 metadata coverage and provenance, D3 manifest and sitemap evidence, D4 quality, link, snippet, and safety evidence, D5 deployment deltas, and D6 governance and coupling reports. The generator is `scripts/generate-documentation-metrics.ps1`; its version 1 contract is `contributing/metadata/documentation-metrics-v1.schema.json`, and the metadata-only report is `_artifacts/documentation-metrics.json`.

The report contains counts, statuses, artifact paths, hashes, stable report identity, and explicit `unknown` or `not_available` values. Connector and Automation metrics are separate when the source evidence supports that classification. It does not contain Markdown, rendered prose, transformed snippets, prompts, summaries, embeddings, credentials, or secrets. A missing agent synchronization event source remains unknown and is recorded as a gap; no owner, timestamp, service-level target, or synchronization event is invented.

The D6.3 identity excludes the generation date and is derived from the source revision, input artifact fingerprints, metric values, and gap records. A no-change D5 delta therefore remains an empty delta with a stable report identity. Pull requests validate the report, while artifact retention is limited to the canonical protected `main` branch or scheduled runs for the approved 90-day operational period. The report is not deployed with the documentation site.

## License and attribution

The existing rendered documentation and Markdown source remain under the repository's current **Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International (CC BY-NC-ND 4.0)** license. Use the repository `LICENSE` file as the governing license text.

When metadata refers to this documentation, identify the license as `CC BY-NC-ND 4.0` and the attribution as `Skyline Communications`, with the relevant source commit and public URL. Do not imply that a metadata manifest changes the license of the referenced documentation.

## Transformed AI corpus outputs

Normalized Markdown, extracted chunks, summaries, embeddings, and any other transformed AI corpus outputs are internal-only by default. They must not be publicly redistributed or used for model training or fine-tuning without separate written approval for the specific output and use.

The internal-only default applies even when the source page or a metadata-only manifest is publicly accessible. Keep transformed outputs, diagnostic details, and any credentials or secrets out of public artifacts and public documentation.

### D3.2 internal topic packs

The D3.2 generator writes normalized Connector and Automation Markdown to `_artifacts/internal-only-topic-packs/`. The directory name, the `internal-only-topic-pack-manifest.json` filename, each `internal-only-*.md` filename, and the `internal-only-notice.txt` file are deliberate distribution markers. These files contain transformed prose and are not DocFX content, public metadata, or release artifacts.

The D3.2 manifest records the D3.1 manifest hash, full source commit, source path and blob, source UID, section identity, source and transformed-content hashes, generator and schema versions, license, attribution, link-resolution records, and deterministic generation metadata. Its distribution flags prohibit public redistribution, model training, and fine-tuning. The content identity excludes the generation date.

CI validates D3.2 on pull requests and normal builds but uploads the transformed pack only from a protected-main manual run in a non-public repository with the `D3_2_INTERNAL_ARTIFACTS_ENABLED` repository variable set to `true`. The artifact is named `internal-only-topic-packs-<commit>` and is retained for 14 days. It is never included in the public `release` artifact or deployed documentation. Local copies should follow the same 14-day operational retention unless a stricter internal policy applies.
