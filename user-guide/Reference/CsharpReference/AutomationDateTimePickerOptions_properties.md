---
uid: AutomationDateTimePickerOptions_properties
---

# AutomationDateTimePickerOptions properties

- [AutoCloseCalendar](#autoclosecalendar)

- [CalendarDisplayMode](#calendardisplaymode)

- [ShowDropDownButton](#showdropdownbutton)

- [TimeFormat](#timeformat)

- [TimeFormatString](#timeformatstring)

- [TimePickerAllowSpin](#timepickerallowspin)

- [TimePickerShowButtonSpinner](#timepickershowbuttonspinner)

- [TimePickerVisible](#timepickervisible)

> [!NOTE]
> All properties of the *AutomationDateTimeUpDownOptions* class can also be used.

### AutoCloseCalendar

When true, the calendar pop-up will close when the user clicks a new date.

```txt
bool AutoCloseCalendar
```

Default: False

### CalendarDisplayMode

Gets or sets the display mode of the calendar inside the date-time picker control.

```txt
CalendarMode CalendarDisplayMode
```

The following possibilities are available for CalendarMode:

- Month

- Year

- Decade

Default:

```txt
CalendarMode.Month
```

### ShowDropDownButton

Enables or disables the drop-down button to show the calendar control.

```txt
bool ShowDropDownButton
```

Default: True

### TimeFormat

Gets or sets the time format.

```txt
DateTimeFormat TimeFormat
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

```txt
DateTimeFormat.ShortTime
```

### TimeFormatString

Gets or sets the time format string used when TimeFormat is set to “Custom”.

```txt
String TimeFormatString
```

### TimePickerAllowSpin

Enables or disables the spinner button of the calendar control.

```txt
bool TimePickerAllowSpin
```

Default: True

### TimePickerShowButtonSpinner

Shows or hides the spin box of the calendar control.

```txt
bool TimePickerShowButtonSpinner
```

Default: False

### TimePickerVisible

Shows or hides the time picker within the calendar control.

```txt
bool TimePickerVisible
```

Default: True
