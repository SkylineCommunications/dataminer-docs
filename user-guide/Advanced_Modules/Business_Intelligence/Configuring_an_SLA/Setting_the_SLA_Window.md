---
uid: Setting_the_SLA_Window
---

# Setting the SLA Window

To set the SLA window, do the following:

1. In DataMiner Cube, go to the *SLA Configuration* page of the SLA element.

2. In the *Window settings* section:

    1. Click the toggle button in the *Type* area to switch from sliding to fixed window or vice versa.

        > [!NOTE]
        > If set to fixed window, the window starts at a fixed point in time, for instance at midnight every day. If set to sliding window, the window moves along with the current time. That means that the end time for a sliding window is always now.

    2. Select a unit of measurement in the *Unit* area, e.g. Minutes.

    3. Set a duration for the window in the *Time* area, either by using the slider, by typing the value directly, or by using the up and down arrows.

> [!NOTE]
> It is also possible to define a fixed window that starts at a particular time instead of e.g. the beginning of the month. To do this, enter a time value under *Base Timestamp* in the *Extra settings* section, in the format yyyy/mm/dd hh:mm:ss. This time value will then be rounded down to minutes. However, take care not to set this time value to a date at the end of the month, e.g. the 30th, as this may cause issues, given that not all months have 30 days.
>
