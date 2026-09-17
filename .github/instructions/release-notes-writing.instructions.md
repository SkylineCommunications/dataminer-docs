---
description: "Use when creating or editing release note documentation in release-notes/."
applyTo: "release-notes/**/*.md"
---

# Release notes writing guidance

Apply these rules when writing release note documentation in `release-notes/`.

- Determine whether the release note describes a new feature, an enhancement, or a fix. Use the appropriate section heading for each type of release note. Keep in mind that it is the description of the release note that determines the type, not the "Type" field, as the latter is often incorrect.
- Within each section, sort the release notes based on the ID number, with the lowest number first. If no ID is available, place the most recent release note at the top.
- When documenting a fix, focus on the issue that users experienced so people who encountered it can recognize it immediately.
- Make each release note title brief and clear, summarizing the new feature, enhancement, or, for fixes, the issue.
- Every new release-note page must include version 1 metadata from `contributing/metadata/documentation-metadata-v1.schema.json`, with `content_type: release-note` and a `version` confirmed by the source. Do not invent owner, applicability, or review values.
