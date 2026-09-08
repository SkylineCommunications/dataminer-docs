---
uid: Web_apps_Feature_Release_10.6.11
---

# DataMiner web apps Feature Release 10.6.11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU8].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.11](xref:General_Feature_Release_10.6.11).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.11](xref:Cube_Feature_Release_10.6.11).

## Highlights

*No highlights have been selected yet.*

## New features

*This release does not contain any new features yet.*

## Changes

### Enhancements

#### GQI DxM: Write-only parameter table columns are now excluded by default [ID 46033]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Some protocol parameters are write-only (e.g., buttons or action/configuration fields) and do not return readable values. Up to now, these columns could still appear in default output or in query-builder capabilities for parameter-related data sources.

From now on, write-only columns are retained for backward compatibility but excluded from default selections and from new capability choices.

Existing queries can still resolve and run if such columns were already explicitly referenced. If a write-only column is explicitly selected, it remains available for subsequent operators such as *Filter*, *Sort*, *Aggregate*, and *Join*.

#### GQI DxM - Parameter table: Enhanced optimization of regex filters [ID 46099]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

For the table parameter data sources (*Parameter table by parameter ID* and the table-parameter path used by *Get parameters for elements where*), regex filter optimization has been improved.

Previously, a *Regex* filter was only optimized when it could be reduced to exact string values:

- On discrete string columns, the regex was optimized only when it could be transformed to an exact-value comparison on the discrete values.
- On non-discrete string columns, regex filters were not forwarded as a native server regex filter and were instead evaluated afterwards in .NET.
- The *Not regex* comparer was not optimized.

This limitation existed because native server regex evaluation is not equivalent to .NET regex evaluation. The native server filter uses Boost.Regex, compiled with a global case-insensitive flag and executed with `regex_match`, while GQI regex filters are expected to behave like .NET `Regex.IsMatch` without regex options. This creates important semantic differences for case sensitivity, search versus whole-string matching, anchors, dot behavior, and several .NET-specific regex constructs.

From now on, GQI optimizes a larger but conservative subset of table-parameter *Regex* filters by translating supported .NET patterns to an equivalent Boost pattern for native server-side execution. This translation preserves .NET-like search semantics, restores default case-sensitive behavior, preserves default dot behavior, and compensates for the native use of `regex_match`.

The filter is now optimized only when the regex can be translated safely, including for example:

- Literal patterns, and escaped literals such as `\.`, `\^`, and `\$`.
- Ordinary character classes, without .NET character class subtraction or POSIX-style bracket expressions.
- Capturing and non-capturing groups, alternation, and quantifiers.
- Negative lookahead assertions.
- Atomic groups.
- Named groups and named backreferences, provided the names are non-numeric, unique, and not balancing groups.
- Single-digit numeric backreferences when capture numbering is unambiguous.
- Conditional groups with numeric capture references or negative-lookahead conditions.
- `^`, `$`, `\A`, and `\z`.
- Supported escapes such as `\uFFFF`, `\v`, and octal escapes in character classes.
- Inline options that only use supported singleline/case-sensitive combinations, such as enabling or disabling `s` and disabling `i`.

The filter is still not optimized, and instead remains post-filtered in .NET, when GQI cannot guarantee equivalent native behavior. This includes for example:

- `\w`, `\W`, `\d`, `\D`, `\s`, `\S`, `\p{...}`, and `\P{...}`.
- `\b` and `\B`.
- `\G` and `\Z`.
- Positive lookahead assertions and lookbehind assertions.
- Inline options that use `m`, `x`, `n`, enable `i`, or use unsupported option combinations.
- Balancing groups, numeric named captures, duplicate named captures, and named conditional references.
- Multi-digit numeric backreferences.
- Conditional groups with arbitrary or unsupported conditions.
- .NET character class subtraction, such as `[a-z-[aeiou]]`.
- POSIX-style bracket expressions inside character classes.
- Invalid .NET regex patterns.

The *Not regex* comparer remains post-filtered.

#### Jobs app: All code has now been removed from the web repository [ID 46170]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

The Jobs module has been end-of-life since DataMiner 10.5.0. All code related to this module has now been removed from the web repository.

#### Dashboards/Low-Code Apps - Query builder: Hidden tree argument items are now excluded by default [ID 46246]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

In the query builder, tree argument items that are marked as hidden by GQI are now excluded by default.

To preserve backward compatibility, existing queries that already selected one of these hidden items can still be loaded and executed.

If you deselect such a hidden item, it remains available in that editing session. After you close and reopen the query builder, the hidden item is no longer offered as a selectable option.

### Fixes

#### Dashboards/Low-Code Apps: Linked dropdown components feeding data to each other could cause a dashboard or app to become unresponsive [ID 46314]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, when two dropdown components were configured to feed data to each other, in some cases, the dashboard or low-code app could become unresponsive.
