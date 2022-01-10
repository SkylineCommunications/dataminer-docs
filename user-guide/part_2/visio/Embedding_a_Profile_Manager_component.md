## Embedding a Profile Manager component

From DataMiner 9.6.7 onwards, for systems with the appropriate licenses, it is possible to embed a Profile Manager component in Visio. With this component, you can essentially embed the *Profiles* module in Visio.

To do so:

1. Add the shape that should contain the Profile Manager component.

2. Add the following shape data to the shape:

    | Shape data field | Value                                                                                          |
    |--------------------|------------------------------------------------------------------------------------------------|
    | Component          | *Profile Manager*<br> or <br> *Profiles* |

3. To further refine the component, optionally add the following shape data fields to the component shape:

    | Shape data field | Description                                                                                                                                                                                                                                                                                                                                                                                                                        |
    |--------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | ComponentOptions   | Allows you to specify whether you want the component to show the *definitions*, *instances* and/or *parameters* tabs. For example, to show only the *definitions* tab, configure the following value:<br> *ShowDefinitions=True\|ShowInstances=False\|ShowParameters=False* |
    | Profile            | Allows you to specify the GUID of one particular profile instance that has to be displayed in the *Instances* tab, together with any parent and child items.                                                                                                                                                                                                                                        |
