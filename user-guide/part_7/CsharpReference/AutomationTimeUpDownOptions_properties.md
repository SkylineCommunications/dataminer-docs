---
uid: AutomationTimeUpDownOptions_properties
---

# AutomationTimeUpDownOptions properties

- [AllowSpin](#allowspin)

- [ClipValueToMinMax](#clipvaluetominmax)

- [FractionalSecondsDigitsCount](#fractionalsecondsdigitscount)

- [Maximum](#maximum)

- [Minimum](#minimum)

- [ShowButtonSpinner](#showbuttonspinner)

- [ShowSeconds](#showseconds)

- [UpdateValueOnEnterKey](#updatevalueonenterkey)

### AllowSpin

Enables or disables the spinner button.

```txt
bool AllowSpin
```

Default: True

### ClipValueToMinMax

Enables or disables the ClipValueToMinMax option.

```txt
bool ClipValueToMinMax
```

Default: False

### FractionalSecondsDigitsCount

Gets or sets the number of digits to be used in order to represent the fractions of seconds.

```txt
int FractionalSecondsDigitsCount
```

Default: 0

### Maximum

Gets or sets the maximum time span.

```txt
TimeSpan Maximum
```

Default:

```txt
Timespan.MaxValue
```

### Minimum

Gets or sets the minimum time span.

```txt
TimeSpan Minimum
```

Default:

```txt
Timespan.MinValue
```

### ShowButtonSpinner

Shows or hides the spinner button.

```txt
bool ShowButtonSpinner
```

Default: True

### ShowSeconds

Enables or disables displaying seconds in the control.

```txt
bool ShowSeconds
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
