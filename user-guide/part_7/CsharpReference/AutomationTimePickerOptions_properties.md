---
uid: AutomationTimePickerOptions_properties
---

## AutomationTimePickerOptions properties

- [EndTime](#endtime)

- [MaxDropDownHeight](#maxdropdownheight)

- [ShowDropDownButton](#showdropdownbutton)

- [StartTime](#starttime)

- [TimeInterval](#timeinterval)

> [!NOTE]
> All properties of the *AutomationDateTimeUpDownOptions* class can also be used.

#### EndTime

Gets or sets the last time listed in the time picker control.

```txt
TimeSpan EndTime
```

Default:

```txt
TimeSpan.FromMinutes(1439)
```

> [!NOTE]
> 1439 = 1440 minutes (1 day) minus a minute

#### MaxDropDownHeight

Gets or sets the height of the time picker control.

```txt
double MaxDropDownHeight
```

Default: 130

#### ShowDropDownButton

Enables or disables the drop-down button of the time picker control.

```txt
bool ShowDropDownButton
```

Default: True

#### StartTime

Gets or sets the earliest time listed in the time picker control.

```txt
TimeSpan StartTime
```

Default:

```txt
TimeSpan.Zero
```

#### TimeInterval

Gets or sets the time interval between two time items in the time picker control.

```txt
TimeSpan TimeInterval
```

Default:

```txt
TimeSpan.FromHours(1)
```
