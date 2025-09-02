---
uid: ImpactOfProtocolVersionChanges
---

# Impact of protocol version changes

Below, you can find an overview of all changes to a protocol that can cause impact when updating from a previous version. Some of the changes can be implemented using workarounds where the impact can actually be avoided.

For more information on protocol version numbering, see [Protocol version semantics](xref:ProtocolVersionSemantics).

> [!IMPORTANT]
> When an impacting change is implemented, a range change is required.

## Protocol version requests

A protocol version request needs to be made as soon as a change in a protocol will cause impact and no workaround can be implemented.

As a Skyline developer, to create such a request, go to the [Protocol Version Request](https://teams.microsoft.com/l/message/19:ad852d24461147ab918738dc0d3384d8@thread.skype/1695297680965?tenantId=5f175691-8d1c-4932-b7c8-ce990839ac40&groupId=38eed67d-cb0d-47f7-a6ea-d7487cc35ce3&parentMessageId=1695297028950&teamName=Expert%20Hub%20-%20Scripts%20%26%20Connectors&channelName=02.%20ECS%20-%20Protocol%20Versions&createdTime=1695297680965) page on Teams.

A team of System Developers is responsible for following up on these requests and guiding the developer to make the correct decision and assess if the impacting change can be implemented or if a workaround is possible.

Depending on whether the request is valid or not, the request will either be approved or rejected.

It is important to assess if a major change will be needed as soon as possible to avoid any delays that could impact the delivery of a task.

## Impacting changes

There are many protocol changes that can cause impact.

The nature and severity of the impact will be documented via the connector XML [VersionHistory](xref:Manifest.VersionHistory) subtags as well as the actions to take to overcome those. This information will then be exposed both in the Catalog and in DataMiner Cube when a pre-existing element is updated.

This can vary from a small impact such as having to update a related Automation script or dashboard, or having to review a small part of alarm or trend templates, all the way up to a large impact such as having to create a brand-new element leading to the loss of all alarm and trend history.

The impacted changes listed here are grouped based on the change that is implemented.

### Protocol changes

- [Change DCF](xref:ChangeDCF)
- [Change Unicode](xref:ChangeUnicode)
- [Change connection(s)](xref:ChangeConnections)
- [Change layout](xref:ChangeLayout)
- [Change exported protocol name (DVE)](xref:ChangeExportedProtocolName)
- [Change page name](xref:ChangePageName)
- [Change minimum required DataMiner version](xref:ChangeMinimumRequiredDMAVersion)
- [Change protocol name](xref:ChangeProtocolName)
- [Change InterApp range](xref:ChangeInterAppRange)

### Parameter changes

- [Change parameter description](xref:ChangeParameterDescription)
- [Change parameter ID](xref:ChangeParameterID)
- [Change parameter discreet and/or exception](xref:ChangeParameterDiscreetException)
- [Change parameter Interprete](xref:ChangeParameterInterprete)
- [Change parameter range](xref:ChangeParameterRange)
- [Change matrix parameter size](xref:ChangeMatrixParameterSize)
- [Change alarm monitoring and/or trending](xref:ChangeAlarmMonitoringTrending)
- [Remove parameter](xref:RemoveParameter)

### Table parameter changes

- [Change primary Key](xref:ChangePrimaryKey)
- [Change display key](xref:ChangeDisplayKey)
- [Replace displayColumn by naming](xref:ReplaceDisplayColumnByNaming)
- [Change to partial table](xref:ChangeToPartialTable)
- [Change logger table](xref:ChangeLoggerTable)
- [Change column order](xref:ChangeColumnOrder)
- [Change displayed column order](xref:ChangeDisplayedColumnOrder)

## Improving context awareness procedure

A procedure has been introduced to improve context awareness and to allow certain major changes to improve the overall quality of protocols even though they could cause impact.

### Context awareness

Any user familiar with a product should easily find all necessary information when using DataMiner protocols. This means that DataMiner protocols should not only perform great, but should also look the part and be straightforward to use.

Especially for new developments, the focus should be on getting them spot on from the start, especially since any changes that might be needed in the future could cause impact for existing users.

However, this should not stop you from improving existing protocols.

### Major changes

In the past, as many major changes as possible were blocked by providing workarounds or convincing the users to not make certain changes to avoid impact. While this worked, this meant new users might not get a perfect product. To improve the quality of DataMiner protocols, a different approach is therefore needed.

### Procedure

Whenever you receive feedback from a user that some improvements (changing parameter descriptions, change layout, etc.) could be done in a protocol, a major change can be requested to allow these changes.

As a Skyline developer, you should create such requests on the [Protocol Version Request](https://teams.microsoft.com/l/message/19:ad852d24461147ab918738dc0d3384d8@thread.skype/1695297680965?tenantId=5f175691-8d1c-4932-b7c8-ce990839ac40&groupId=38eed67d-cb0d-47f7-a6ea-d7487cc35ce3&parentMessageId=1695297028950&teamName=Expert%20Hub%20-%20Scripts%20%26%20Connectors&channelName=02.%20ECS%20-%20Protocol%20Versions&createdTime=1695297680965) page on Teams (similar to any other protocol version request), but no specific task is needed (unless you already have a task in your project).

The *Protocol Version Request* team will evaluate the requested changes and, when the request is valid, they will create a task in the [SLC-SE-Internal Protocol Reviews](https://collaboration.skyline.be/project/5938/list) project.

> [!NOTE]
> The *Protocol Version Request* team is in charge of creating these tasks, and no tasks should be created in this project without the team knowing about it.

### Tasks

Whenever you are working on a task for a protocol, please keep an eye on this project and see if no other improvements could be taken along.

No additional version request is needed anymore as these changes were already approved.

This is also a call to all Product Owners to keep an eye on this project and try to get these tasks picked up whenever changes are done in the protocols of which they are the owner.
