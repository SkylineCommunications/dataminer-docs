---
uid: UsingWildcardsOrRegularExpressionsInAlarmFilters
---

# Using wildcards or regular expressions in alarm filters

## Using wildcard expressions

The example below shows a filter for elements matching a particular wildcard expression.

![Example of alarm filter with wildcard](~/dataminer/images/alarm_filter_wildcard_DM9.png)

## Using regular expressions

If you want to filter alarms using a regular expression:

1. When creating a filter, select the *Matches Regular Expression* operator.

1. Specify a regular expression.

![Example of alarm filter with regular expression](~/dataminer/images/alarm_filter_regex_DM9.png)

### Regular expression syntax

You can use any regular expression.

For more information on how to construct regular expressions, here are a few interesting links:

- [Regular Expression Language - Quick Reference](http://msdn.microsoft.com/en-us/library/az24scfc.aspx)

- [RegExLib.com Regular Expression Cheat Sheet](http://regexlib.com/CheatSheet.aspx)

> [!NOTE]
>
> - DataMiner always wraps a regular expression in ^( and )$. This means that the expression must match the entire string.
> - The checks are executed using the invariant culture and ignoring case.

### Regular expression examples

```txt
London.*
```

- Matches ...

  - London-Amplifier-1

  - London-Amplifier-2

- Does not match ...

  - NewYork-Amplifier-1

  - East-London-Amplifier

  - Paris-Amplifier

```txt
(London|NewYork)-Amplifier-[0-9]+
```

- Matches ...

  - London-Amplifier-1

  - NewYork-Amplifier-5

- Does not match ...

  - Paris-Amplifier-7

  - London-Amplifier-XYZ

```txt
MAC-^([0-9A-F]{2}[-]){5}([0-9A-F]{2})
```

- Matches ...

  - MAC-A0-12-EF-DE-A1-C3

- Does not match ...

  - MAC-99-99-99-99-99
