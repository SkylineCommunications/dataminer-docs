---
uid: General_Main_Release_10.3.0_CU5
---

# General Main Release 10.3.0 CU5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SSH settings saved in parameters are now passed to SLPort together instead of separately [ID_36404]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU5] - FR 10.3.7 -->

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

#### DataMiner Agents joining a cluster will now synchronize their ProtocolScripts\DllImport folder [ID_36494]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When a DataMiner Agent joins a cluster, it will now synchronize its `ProtocolScripts\DllImport` folder.

Also, when processing a protocol, a DataMiner Agent will now synchronize

- the files in the `ProtocolScripts/DllImport` folder, and
- the files in the folders mentioned in the *QAction@dllImport* attribute.

#### Stream Viewer will now display parameter IDs in decimal format instead of octal format [ID_36525]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Stream Viewer will display an error message when an SNMP poll group contained either an invalid parameter or a parameter that did not have its SNMP setting enabled.

Up to now, that error message would contain the ID of the parameter in octal format. From now on, it will contain the ID of the parameter in decimal format instead.

### Fixes

*No fixes have been added yet*
