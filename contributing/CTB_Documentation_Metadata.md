---
metadata_version: 1
uid: CTB_Documentation_Metadata
description: Define the version 1 documentation metadata contract, authority model, controlled values, compatibility, and validation rules for DataMiner docs.
area: contributing
content_type: schema
authority: canonical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner documentation
version: "1.0"
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Documentation metadata contract

Use this contract when you add a new page or make a substantial change to a page. The contract makes the purpose, authority, lifecycle, applicability, and compatibility of a page machine-readable without assigning an organizational owner or a license.

The version 1 schema is stored in `contributing/metadata/documentation-metadata-v1.schema.json`. It applies to a page when the page contains `metadata_version: 1`. The D2.2 migration opts the current Connector and Automation guide/schema scopes into this contract with `scripts/migrate-documentation-metadata.ps1`; pages outside those scopes without this field remain on the legacy migration path.

## Required front matter

Every page that opts in to version 1 must include the following fields:

| Field | Purpose |
|--|--|
| `metadata_version` | Must be the integer `1`. |
| `uid` | The permanent, unique DocFX identifier. |
| `description` | A 100- to 155-character description of the page. |
| `area` | The top-level documentation area. |
| `content_type` | The controlled classification of the page. |
| `authority` | The authority claim made by the page. |
| `lifecycle` | The current publication lifecycle. |
| `applies_to` | The product, platform, or scope covered by the page. |
| `version` | The documented contract or release version. |
| `owner` | An existing owner handle, or a reserved sentinel. |
| `review_status` | The status of the most recent review. |
| `review_date` | The review date, or its required sentinel. |
| `compatibility` | The UID and URL compatibility guarantees. |

The optional `authority_source` field identifies an existing UID or URI when a page derives its information from another source. The optional `keywords` field contains the comma-separated keywords already supported by the documentation site. Version 1 does not allow undocumented front matter keys.

## Controlled values

### Content type

Use exactly one of the following values:

| Value | Use for |
|--|--|
| `conceptual` | Explanations of a concept, behavior, workflow, or task. |
| `schema` | A data model, metadata contract, configuration shape, or other structured definition. |
| `api` | A supported API surface, including methods, parameters, return values, and errors. |
| `example` | A sample or walkthrough that demonstrates a task without defining a contract. |
| `release-note` | A time-bound record of a change in a product or solution release. |
| `legacy` | Content retained for historical or migration purposes and not yet classified as a current type. |

`legacy` is a classification value for content, not a permission to omit version 1 fields. Use the sentinel values described below when a legacy page cannot provide a current value.

### Authority

Use exactly one of the following values:

| Value | Meaning |
|--|--|
| `canonical` | This page is the designated source of truth for the documented contract or behavior. |
| `reference` | This page provides a supported description, but another source is canonical. |
| `illustrative` | This page demonstrates usage and must not be treated as a contract. |
| `historical` | This page records a past state, release, or behavior. |
| `unknown` | The authority has not been established. |
| `not_applicable` | The page has no meaningful authority claim. |

Use `authority_source` for a reference, illustrative, or historical page when an existing UID or URI identifies the source. Do not create an owner or source value merely to fill the field.

### Lifecycle

Use exactly one of `draft`, `active`, `deprecated`, `archived`, or `unknown`.

- `draft` is work in progress and is not a completed contract.
- `active` is currently published and maintained.
- `deprecated` remains published but should no longer be used for new work.
- `archived` is retained for history and is not current guidance.
- `unknown` means that the lifecycle still needs to be confirmed.

### Area

Use the top-level repository area: `root`, `dataminer`, `develop`, `solutions`, `tutorials`, `connectors`, `release-notes`, or `contributing`. Use `unknown` when the area is not confirmed and `not_applicable` only when the field has no meaningful value.

### Review status and date

Use exactly one of `draft`, `in_review`, `approved`, `needs_update`, `unknown`, or `not_applicable` for `review_status`.

- For `draft`, `in_review`, `approved`, and `needs_update`, `review_date` must be an ISO 8601 date in `YYYY-MM-DD` form.
- For `unknown`, `review_date` must be `unknown`.
- For `not_applicable`, `review_date` must be `not_applicable`.

An `approved` status records that the metadata and content were checked against this contract. It does not assign an organizational owner.

## Applicability and version

`applies_to` is an array of one or more existing product, platform, or scope names. Do not create a new controlled product list in page metadata. For an unconfirmed or inapplicable value, use exactly one of these arrays:

```yaml
applies_to:
  - unknown
```

```yaml
applies_to:
  - not_applicable
```

`version` is an opaque, non-empty string taken from the established version notation for the documented contract or release. The reserved values are `unknown`, `not_applicable`, and `unversioned`. Do not invent a version range syntax.

`owner` is an existing owner handle. Use `unknown` when the owner has not been confirmed and `not_applicable` when ownership has no meaning for the page. Do not add organizational owner names to this contract.

## UID and URL compatibility

The following guarantees apply to every version 1 page:

- A `uid` is unique, contains no spaces, and is a permanent DocFX identifier. Once published, do not change it or reuse it for another page.
- Moving or renaming a source file must preserve its `uid`. A changed `uid` is a breaking cross-reference change and requires an explicit migration decision.
- A published URL is stable by default. Keep the source path stable when `compatibility.url` is `stable`.
- If a source path must change, set `compatibility.url` to `redirect_required`, list every known old path in `compatibility.url_aliases`, and do not remove the old route until the redirect is available.
- `unknown` means that the guarantee has not been checked. It is not equivalent to `stable`.
- `not_applicable` is reserved for content with no published identity. Do not use it to avoid checking a UID or URL.

For a normal new page, use `stable` for both `compatibility.uid` and `compatibility.url`:

```yaml
compatibility:
  uid: stable
  url: stable
```

## Examples

The following complete front matter blocks show the intended classifications. Each block is valid against the version 1 schema.

### Conceptual page

```yaml
---
metadata_version: 1
uid: Example_Conceptual_Page
description: Explain a DataMiner concept, behavior, or workflow and link to the current reference contract when one exists.
area: dataminer
content_type: conceptual
authority: reference
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unversioned
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---
```

### Schema page

```yaml
---
metadata_version: 1
uid: Example_Schema_Page
description: Define the canonical structure and constraints for a DataMiner data contract so tools and authors can validate metadata consistently.
area: develop
content_type: schema
authority: canonical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner documentation
version: "1.0"
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---
```

### API page

```yaml
---
metadata_version: 1
uid: Example_Api_Page
description: Describe the supported DataMiner API surface, including parameters, return values, errors, and compatibility expectations for callers.
area: develop
content_type: api
authority: canonical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner
version: "10.6.8"
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---
```

### Example page

```yaml
---
metadata_version: 1
uid: Example_Usage_Page
description: Demonstrate a supported DataMiner task without defining a normative API or configuration contract for other pages.
area: tutorials
content_type: example
authority: illustrative
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: "10.6.8"
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---
```

### Release-note page

```yaml
---
metadata_version: 1
uid: Example_Release_Note
description: Record a time-bound DataMiner change and its affected release so readers can trace when behavior was introduced or changed.
area: release-notes
content_type: release-note
authority: historical
authority_source: not_applicable
lifecycle: active
applies_to:
  - DataMiner
version: "10.6.8"
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---
```

### Legacy page

```yaml
---
metadata_version: 1
uid: Example_Legacy_Page
description: Retain this page for historical reference while its current applicability and documentation authority remain unconfirmed.
area: unknown
content_type: legacy
authority: historical
authority_source: unknown
lifecycle: archived
applies_to:
  - unknown
version: unknown
owner: unknown
review_status: not_applicable
review_date: not_applicable
compatibility:
  uid: unknown
  url: unknown
---
```

## Deterministic validation

When you add `metadata_version: 1`, validate the complete front matter object against `contributing/metadata/documentation-metadata-v1.schema.json` with `scripts/validate-documentation-metadata.ps1`. The validator reads the schema instead of maintaining a second list of fields or values. It must reject missing required fields, values outside the controlled lists, empty strings, unknown metadata keys, invalid dates, and mixed `unknown` or `not_applicable` applicability arrays. Pages without `metadata_version: 1` are legacy pages and remain out of scope for this opt-in validation until their migration scope is scheduled. The D2.2 target scope and coverage report are defined in `contributing/metadata/d2-2-migration-scope.json` and `d2-2-metadata-migration-report.json`.

For a repository-wide check of opted-in pages, run:

```powershell
.\scripts\validate-documentation-metadata.ps1 -RepositoryRoot .
```

For a new page, require version 1 metadata explicitly:

```powershell
.\scripts\validate-documentation-metadata.ps1 -RepositoryRoot . -Path .\path\to\new-page.md -RequireVersion1
```

Then run the repository's existing DocFX build with warnings treated as errors:

```powershell
docfx metadata
docfx build --warningsAsErrors
```

The DocFX build checks UID, TOC, cross-reference, and Markdown integration. It does not replace JSON Schema validation. If a validator is not available locally, use the field tables above as a deterministic review checklist and record unresolved values as `unknown`, never as an empty value or an invented owner.
