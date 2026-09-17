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

## License and attribution

The existing rendered documentation and Markdown source remain under the repository's current **Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International (CC BY-NC-ND 4.0)** license. Use the repository `LICENSE` file as the governing license text.

When metadata refers to this documentation, identify the license as `CC BY-NC-ND 4.0` and the attribution as `Skyline Communications`, with the relevant source commit and public URL. Do not imply that a metadata manifest changes the license of the referenced documentation.

## Transformed AI corpus outputs

Normalized Markdown, extracted chunks, summaries, embeddings, and any other transformed AI corpus outputs are internal-only by default. They must not be publicly redistributed or used for model training or fine-tuning without separate written approval for the specific output and use.

The internal-only default applies even when the source page or a metadata-only manifest is publicly accessible. Keep transformed outputs, diagnostic details, and any credentials or secrets out of public artifacts and public documentation.
