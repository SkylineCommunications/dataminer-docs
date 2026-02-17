---
uid: Condition_format
---

# Condition format

A script condition in a correlation rule should use the following format:

```xml
<value> <operator> <value>
```

Examples:

```txt
count(*) > 5
field(pid)==123
field(value) == "Connected"
parameter(7,56,110,"SLDataMiner") > 55.2
round(avg(field(value)),3) == "12.555"
field(value) == "Status: \"OK\""
```

> [!NOTE]
> For more examples, refer to [Examples of script conditions](xref:Examples_of_script_conditions).

## Available operators

- Numeric comparison (values parsed into double, using invariant culture)

  - \<

  - \>

  - \<=

  - \>=

- String comparison (case insensitive, invariant culture)

  - !=

  - ==

## Values

- String values can be enclosed in double quotes:

  ```txt
  "Connected"
  ```

- Double quotes in a quoted string can be encoded by adding a backslash in front:

  ```txt
  "string with a\"in it"
  ```

- When not enclosed in double quotes, values can contain the following characters:

  - a-z

  - A-Z

  - 0-9

  - *\_* (underscore)

  - *-* (dash)

  - *.* (dot)

  - *\** (asterisk)

## Remarks

- Any white space characters (including space, tab, form feed, etc.) in between values, function names, function arguments, etc. are ignored.

- When script conditions use functions, fields or properties outside the min/max/avg aggregated functions context, values will be retrieved from one of the alarms in the bucket only. This will typically be the triggering alarm or the most recent one in the rule bucket.

- Within a single script condition, it is not possible to combine multiple conditions using *and* or *or*.
