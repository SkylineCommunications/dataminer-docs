---
uid: Trending_techniques
---

# Trending techniques

There are two trending techniques: real-time trending and average trending.

## Real-time trending

Logging of all values, in a sliding window of maximum 1000 hours.

In most cases, real-time trending will be set to 24 or 48 hours.

> [!NOTE]
> It is possible to set a default sliding window size for real-time trending on a particular DMA. See [Setting the default sliding window size for real-time trending](xref:Setting_the_default_sliding_window_size_for_real-time_trending#setting-the-default-sliding-window-size-for-real-time-trending).

## Average trending

Logging of average values only, usually across longer time spans than those used for real-time trending.

- Last 48 hours, with 5-minute averages.

- Last week, with 5-minute averages (max. 2016 data points).

- Last month, with 5-minute averages (max. about 8640 data points).

- Last year, with 1-hour averages (max. about 8760 data points).

> [!NOTE]
> For average trending, the DMS stores more than just the average value for a particular time slot. For numeric parameters, it also stores the minimum and maximum value detected in that same time slot. For non-numeric parameters (such as [discrete and hybrid parameters](xref:Discrete_analog_and_hybrid_parameters)), the DMS stores the value that occurred the most, the value that was active the longest, and the percentage of time this value was active during the time slot.
