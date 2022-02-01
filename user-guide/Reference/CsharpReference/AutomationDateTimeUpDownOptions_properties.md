---
uid: AutomationDateTimeUpDownOptions_properties
---

# AutomationDateTimeUpDownOptions properties

- [AllowSpin](#allowspin)

- [ClipValueToMinMax](#clipvaluetominmax)

- [Format](#format)

- [FormatString](#formatstring)

- [Kind](#kind)

- [Maximum](#maximum)

- [Minimum](#minimum)

- [ShowButtonSpinner](#showbuttonspinner)

- [UpdateValueOnEnterKey](#updatevalueonenterkey)

### AllowSpin

Enables or disables the spinner button.

```txt
bool AllowSpin
```

Default: True

### ClipValueToMinMax

Enables or disables the *ClipValueToMinMax* option.

```txt
bool ClipValueToMinMax
```

Default: False

### Format

Gets or sets the date and time format used by the date-time up-down control.

```txt
DateTimeFormat Format
```

The following possibilities are available for DateTimeFormat:

- FullDateTime

- LongDate

- LongTime

- ShortDate

- ShortTime

- SortableDateTime

- UniversalSortableDatetime

- MonthDay

- RFC1123

- Custom

Default:

- In DataMiner 9.5.3: FullDateTime

- From DataMiner 9.5.4 onwards: general datetime

```txt
DateTimeFormat.Custom
```

### FormatString

Gets or sets the date-time format to be used by the control when Format is set to 'Custom'.

```txt
String FormatString
```

Default: G (from DataMiner 9.5.4 onwards; previously the default value was null)

### Kind

Gets or sets the DateTimeKind (.NET) used by the datetime up-down control.

```txt
DateTimeKind Kind
```

Default:

```txt
DateTimeKind.Unspecified
```

### Maximum

Gets or sets the maximum timestamp.

```txt
DateTime Maximum
```

Default:

```txt
DateTime.MaxValue
```

### Minimum

Gets or sets the minimum timestamp.

```txt
DateTime Minimum
```

Default:

```txt
DateTime.MinValue
```

### ShowButtonSpinner

Show or hides the spinner button.

```txt
bool ShowButtonSpinner
```

Default: True

### UpdateValueOnEnterKey

Enables or disables the option to trigger an update with the control when the Enter key is pressed.

```txt
bool UpdateValueOnEnterKey
```

Default: True

> [!NOTE]
> From 9.5.4 onwards, the functionality of this property has been updated. If it is set to true, the control will now only update when the Enter key is pressed. If it is set to false, the control will also update when the focus is moved to somewhere else.
>
