---
uid: Applying_conditional_connection_thickness
---

# Applying conditional connection thickness

It is possible to have the thickness of the connection lines change depending on the current value of a parameter, property or session variable.

To enable this, add a **Thickness** shape data field to the Connectivity shape, and configure its value as illustrated below. The thickness of the line will be multiplied by the amount specified in the value.

| Shape data field | Value                                                                                                                    |
|------------------|--------------------------------------------------------------------------------------------------------------------------|
| Connection       | Connectivity                                                                                                             |
| Thickness        | \<thickness>:\<Conditions>-\<thickness>:\<Conditions>-...\<Condition <br>specifications>-\<Condition specifications>-... |

> [!NOTE]
> The way the conditions are defined is similar to the way this is done for conditional shape manipulation actions. See [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions).

Example:

In the following example, several thickness values are specified (5, 3 and 2). If the corresponding condition is true, the thickness of the connection line will be multiplied by the thickness value linked to that condition.

| Shape data field | Value                                                                                                                                                                                                        |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Thickness        | 5:\<A>-3:(\<A>or\<B>)or(\<B>and\<C>)-2:(\<A>or\<B>)or(\<C>and not\<B>)-<br>A\|Connection\|Property:State\|=Active-B\|Connection\|Property:broadband\|=100 mb/s-C\|Connection\|Property:channel\|regex=cnn.\* |
