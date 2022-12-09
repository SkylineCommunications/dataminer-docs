---
uid: PA_1.2.2
---

# PA 1.2.2

## New features

#### Support for unlimited activity duration \[ID_29647\]

It is now possible to set the *Max Activity Duration* of a queue to *Unlimited*, so that repeat gateway functions can send tokens as long as the relevant activity is active. The SRM setup script will automatically set the duration of all queues for repeat gateways to be unlimited.

#### New PaProfileHelper class \[ID_29969\]

To facilitate the interaction with the Process Automation framework and make it easier to retrieve data from it, a new *PaProfileHelper* class is now available. This class can only be used in the context of Profile Load script execution.

The script *PA_ProfileLoadTemplate* has been adjusted to illustrate the use of this class.

## Changes

### Enhancements

#### Minimum value for repeat gateway duration, interval and total amount \[ID_29856\]

The Repeat Gateway parameters *PA GW Repeat Duration*, *PA GW Repeat Interval* and *PA GW Repeat Total Amount* have been adjusted to not allow a value below 1.

The script *PA_ProfileLoad_RepeatGateway* has also been adjusted to reflect these changes. If it encounters a value below 1, the script will throw an exception.

#### Additional validation at booking start time \[ID_29897\]

The LSO script will now carry out the following additional checks at the start time of a booking:

- Whether a queue element is available for the resources selected during booking creation.
- Whether the gateway node in the service definition is correctly configured, in case a gateway resource is used.
- Whether the Booking Manager has the pool feature enabled in case the selected resource is of type "pool resource".

If one of the checks fails, the booking will go into the failed state.

### Fixes

#### Problem when processing token with invalid token profile instance \[ID_29900\]

If a token had been generated with an invalid token profile instance, it could occur that the *Skyline Queue Manager* connector could not process the token, which caused the Queue element to be unable to process other incoming tokens.
