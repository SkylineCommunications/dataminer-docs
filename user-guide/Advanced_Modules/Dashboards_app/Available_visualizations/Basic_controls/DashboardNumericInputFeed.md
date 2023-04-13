---
uid: DashboardNumericInputFeed
---

# Numeric input

Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35902 -->. This basic control allows the user to enter numbers, which will then be available as a number feed in the dashboard or low-code app. The number feed can be used by queries and by script parameters in low-code app actions.

The following options are available to fine-tune the component layout:

- *Label*: Text that will be displayed next to the numeric input box.

- *Placeholder*: Placeholder that will be displayed inside the numeric input box.

- *Icon*: Icon that will be displayed in the numeric input box.

In the *Settings* tab, you can also configure the following optional settings:

- *Feed value on*: Determines when the value in the box becomes available as a feed. This can be when the user presses Enter ("Enter"), when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change"). If you select *Focus lost*, the value will also become available when the user presses Enter.

- *Step size*: The value the user specifies will need to be a multiple of the value specified with this option. For example, if the step size is 3, the user can enter 3, 6, 9, etc. but not 2 or 5.

- *Number of decimals*: The maximum number of decimals.

- *Minimum*: The minimum value for the numeric input.

- *Maximum*: The maximum value for the numeric input.
