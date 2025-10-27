---
uid: EPM_1.0.1_xPON
---

# EPM 1.0.1 xPON

## New features

#### Alarm suppression at lower levels via alarm template conditions for routes, distributions, and FAT levels [ID 36874]

In order to suppress alarms for routes, distributions, and FAT levels, the alarm template has been modified to include conditions for these levels. The alarm will be suppressed if the following conditions are met:

- The route reports that 100% of its ONTs are offline.
- The route has more than 3 ONTs.

Both of these conditions must be met for the alarm to be suppressed.

The Skyline EPM Platform xPON has been modified to calculate the percentage of ONTs that are offline. This information is used to determine if the alarm should be suppressed.

#### xPON maps integration [ID 36995]

The QUICK topology now allows access to xPON system maps, with the following three levels: Route, Distribution, and FATs.

- At Route level, the map displays subscribers and the split FATs connected to them. Because no latitude and longitude information is available for distribution, this is not shown on this map.
- At Distribution level, the map displays subscribers and associated split FATs.
- At FAT level, the map shows the connected subscribers.

When you click any shape on the map, a pop-up will show device-specific information. For subscriber shapes, it shows the following information:

- ONT Serial
- ONT Slot Name
- ONT Port Name
- OLT Name
- ONT State
- ONT Rx Power State
- ONT Tx Power State

For a split FAT shape, the pop-up shows the following information:

- Total ONT
- ONT Offline
- Percentage ONT Offline

#### New subscriber ONT OVERVIEW dashboard [ID 37471]

A new *ONT OVERVIEW* dashboard has been created, using ad hoc queries. For this purpose, the GQI ad hoc data source script has been adjusted to allow users to access comprehensive subscriber information on the dashboard. As a result, it now provides details such as Contract ID, Main Street, Street 1, Street 2, and Neighborhood. Additionally, this dashboard functionality has been integrated at the port, distribution, and FAT levels. The dashboard also has the capability to display only those ONTs that meet specific Out of Spec (OOS) parameter criteria.

At the Port level, a new Visual page has also been added that presents general port information.

Finally, a new column has been incorporated into the Port, Split Distribution, and Split Fat tables. This column houses the OLT element ID, facilitating the GQI script in its search for the corresponding ONTs.

## Changes

### Enhancements

#### Route EPM Entity moved to front end [ID 36683]

To prevent possible duplicate entries, the Route EPM Entity has been moved from the back-end managers to the front-end manager.

#### Number ONT KPI improved [ID 37024]

The logic that calculates the Number ONT KPI at network level has been adjusted to provide a more accurate count of the ONTs in the system.

#### Improved EPM front-end ID request flow [ID 37036]

To improve the EPM front-end ID request flow, so that new entities are available to the user more quickly, the EPM front-end element now no longer has to assign IDs to the xPON CPE devices.

#### Remote view parameters moved from ONT overview to dashboard [ID 37160]

To improve the overall performance of the solution, the remote view parameters have been removed from the ONT overview table. These parameters will now instead be available in a dashboard that the user will be able to navigate to from the *Visual* page at the ONT level.

#### Improved organization of KPIs [ID 37170]

In the service topology, the KPIs have now been arranged in a user-friendly manner. To achieve this, new pages have been created with the "CPEIntegration_Data/" prefix, where the necessary parameters have been placed for improved visibility.

#### Supply Voltage units updated from mV to V [ID 37222]

In the ONT overview table, the units for the Supply Voltage parameter have been updated from mV to V.
