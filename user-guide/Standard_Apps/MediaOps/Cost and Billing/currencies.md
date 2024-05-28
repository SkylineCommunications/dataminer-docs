---
uid: cost_billing_currencies
---

# Currencies

In the Cost and Billing application, Currencies contain the following properties:

1. **Currency**: This is the Currency ISO code that can be picked from a fixed enumerated list containing all possible Currencies available.

1. **Rate to nominal**: Represents the rate against the *Nominal Currency* specified by the application. The rate to nominal is used during billing calculation to convert between the Ratecard and Contract currencies if they're different.

1. **Tag**: This is the currency's ISO code in a text format.

## Nominal Currency

The Nominal Currency is a currency set at application level that will be the basis for conversion to any other currencies being used. Each Currency has a "Rate to Nominal" which allows them to be converted to the Nominal Currency, and then to different currency if necessary.

> [!NOTE]
> Currency's Rates to Nominal are at the moment managed manually by the user.

The Nominal Currency can be set in the Configuration page of the Cost and Billing application.
