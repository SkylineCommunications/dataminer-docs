---
uid: MO_CB_Ratecards
---

# Ratecards

Ratecards define how the rate is calculated over time. The rate can represent the cost or the billing. Within ratecards we have the following fields:

1. **Name**: Name of the ratecard.

1. **Ratecard currency**: The currency used for this ratecard.

1. **Minimal time interval** & **Minimal time interval unit**: The minimal time interval that needs to be used to calculate the rate.

1. **Minimal time increment** & **Minimal time increment unit**: The minimal increments that have to be used when calculating the rate.

1. **Capped rate per job**: The max rate that should be used per job even if the calculation would exceed it.

1. **Rates**: Define the rates (multiple possible) that can be used for the different time units (days, hours, minutes or per use).

## Rate Calculation

The rate calculation is done by first defining the time for which the rate has to be calculated. Based on the job time interval, the minimal time and minimal time increment this can be defined. This is done based on the following formula:

- $T_{original}$ = Original time interval of the job
- $T_{min}$ = Minimum time interval
- $ΔT$ = Minimum time increment
- $T_{final}$ = Final time for rate calculation

$$
T_{final}
=
\begin{cases}
T_{min} \text{ if } T_{original} \leqslant T_{min}\\
T_{min} + \lceil \frac{T_{original} - T_{min}}{ΔT} \rceil * ΔT \text{ if } T_{original} > T_{min}
\end{cases}
$$

Once we have this time we can start counting with available rates. In following order we will add the following to the rate:

1. if *Per Use* rate is defined it is added
1. if *Day* rate is defined all full days are rated. If there is a remainder another day will be rated unless there is an *hour* or *minute* rate.
1. If *hour* rate is defined all full hours are rated of the remainder. If there is another remainder another hour will be rated unless there is an *minute* rate.
1. If *minute* rate is defined all remaining minutes rounded up are rated of the remainder.

TODO CHECK WHY WE MADE IT SO COMPLEX?