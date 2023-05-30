---
uid: General_Main_Release_10.2.0_CU17
---

# General Main Release 10.2.0 CU17 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Cassandra: gc_grace_seconds will now be set to 1 day by default and to 4 hours for records with TTL set [ID_34763]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

In Cassandra databases, the table property `gc_grace_seconds` will now be set to 1 day by default.

For tables containing data with TTL set, this property will be set to 4 hours.

#### SSH settings saved in parameters are now passed to SLPort together instead of separately [ID_36404]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.7 -->

When you set up an SSH connection in a protocol, you can store the username, the password, the SSH options and the IP address in parameters using a `<Type options="">` element inside the `<Param>` element.

| Parameter          | Option                          |
|--------------------|---------------------------------|
| SSH username       | `<Type options="SSH USERNAME">` |
| SSH password       | `<Type options="SSH PWD">`      |
| SSH options        | `<Type options="SSH OPTIONS">`  |
| Dynamic IP address | `<Type options="DYNAMIC IP">`<br>Note: This value can also be used for other types of connections. |

Up to now, when an element with an SSH connection was started, these values would each be passed separately to SLPort. From now on, they will all be passed together to SLPort.

> [!NOTE]
> A separate set will be performed whenever one of the above-mentioned values is changed at runtime.

#### Dashboards app & Low-Code Apps: No visual replacement will be displayed anymore when a State component feeds empty query rows [ID_36460]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when a *State* component fed empty query rows, a visual replacement would be displayed. From now on, this will no longer be the case.

### Fixes

#### DataMiner Cube - Visual Overview: Problem with element or view scope of Children shapes [ID_36354]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

In some cases, when a placeholder was used in the *Element* or *View* shape data field of a *Children* shape, the scope would not be updated when changes were made to the placeholder.

From now on, the scope will be updated correctly whenever changes are made to the placeholder in the *Element* or *View* shape data field.
