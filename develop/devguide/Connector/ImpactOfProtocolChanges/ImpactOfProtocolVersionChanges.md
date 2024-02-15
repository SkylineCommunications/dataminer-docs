---
uid: ImpactOfProtocolVersionChanges
---

# Impact of protocol version changes

Below, you can find an overview of all changes to a protocol that can cause impact when updating from a previous version. Some of the changes can be implemented using workarounds where impact can actually be avoided.

For more information on protocol version numbering, see [Protocol version semantics](xref:ProtocolVersionSemantics).

> [!IMPORTANT]
> When an impacting change is implemented, a range change is required.

## Protocol version requests

A protocol version request needs to be made as soon as a change in a protocol will cause impact and no workaround can be implemented.

To create such a request, go to the [Protocol Version Request](https://teams.microsoft.com/l/message/19:ad852d24461147ab918738dc0d3384d8@thread.skype/1695297680965?tenantId=5f175691-8d1c-4932-b7c8-ce990839ac40&groupId=38eed67d-cb0d-47f7-a6ea-d7487cc35ce3&parentMessageId=1695297028950&teamName=Expert%20Hub%20-%20Scripts%20%26%20Connectors&channelName=02.%20ECS%20-%20Protocol%20Versions&createdTime=1695297680965) page on Teams.

A team of System Developers is responsible to follow up on these requests and guide the developer to make the correct decision and assess if the impacting change can be implemented or if a workaround is possible.

Depending on whether the request is valid or not, the request will either be approved or rejected.

It is important to assess if a major change will be needed as soon as possible to avoid any delays that could impact the delivery of a task.

## Impacting changes

There are quite a lot of protocol changes that can cause impact.

Causing impact means that if you have an existing element using a previous version of this protocol, that you cannot upgrade to the new version because something in your system will (or might) break depending on what specific features of the protocol or DataMiner are being used.

The impacted changes listed here are grouped based on the change that is implemented.

### Protocol changes

- [Change DCF](xref:ChangeDCF)
- [Change Unicode](xref:ChangeUnicode)
- [Change connection(s)](xref:ChangeConnections)
- [Change layout](xref:ChangeLayout)
- [Change Exported Protocol Name (DVE)](xref:ChangeExportedProtocolName)
- [Change Page Name](xref:ChangePageName)
- [Change Minimum Required DMA Version](xref:ChangeMinimumRequiredDMAVersion)
- [Change Protocol Name](xref:ChangeProtocolName)

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

- [Change Primary Key](xref:ChangePrimaryKey)
- [Change Display Key [PENDING]](xref:ChangeDisplayKey)
- [Replace displayColumn by naming [PENDING]](xref:ReplaceDisplayColumnByNaming)
- [Change to Partial Table [PENDING]](xref:ChangeToPartialTable)
- [Change Logger Table [TBD]](xref:ChangeLoggerTable)
- [Change Column Order (Idx) [TBD]](xref:ChangeColumnOrder)
- [Change Displayed Column Order (Layout) [TBD]](xref:ChangeDisplayedColumnOrder)

## Improving context awareness procedure

A procedure has been introduced to improve context awareness and to allow certain major changes to improve the overall quality of our protocols even though they could cause impact.

### Context awareness

Any user familiar with a product should easily find all necessary information when using our protocols.

This means that our protocols should not only perform great, but should also look the part and should be straightforward to use.

Especially for new developments, we should focus on getting them spot on from the start as we can only make a first impression once, and any changes we might need in the future could cause impact for existing users.

However, this should not stop us from improving our existing protocols.

### Major changes

In the past, we have always tried to block as many major changes as possible by providing workarounds or convincing the users to not make certain changes to avoid impact.

So far, this worked out and we could always explain this to our existing users, but this also means any new user will also not get a perfect product.

This is something we would like to change to be able to also improve the quality of our existing protocols.

### Procedure

Whenever you receive feedback from a user (i.e. a customer, a colleague from Sales or Product Marketing, etc.) that some improvements (changing parameter descriptions, change layout, etc.) could be done in a protocol, a major change can be requested to allow these changes.

The requests should be created on the [Protocol Version Request](https://teams.microsoft.com/l/message/19:ad852d24461147ab918738dc0d3384d8@thread.skype/1695297680965?tenantId=5f175691-8d1c-4932-b7c8-ce990839ac40&groupId=38eed67d-cb0d-47f7-a6ea-d7487cc35ce3&parentMessageId=1695297028950&teamName=Expert%20Hub%20-%20Scripts%20%26%20Connectors&channelName=02.%20ECS%20-%20Protocol%20Versions&createdTime=1695297680965) intranet page (similar to any other protocol version request), but no specific task is needed (unless you already have a task in your customer project).

The *Protocol Version Request* team will evaluate the requested changes and, when valid, will create a task in the [SLC-SE-Internal Protocol Reviews](https://collaboration.skyline.be/project/5938/list) project.

> [!NOTE]
> The *Protocol Version Request* team is in charge of creating these tasks and no tasks should be created in this project without the team knowing about it.

### Tasks

Whenever you are working on a task for a protocol, please keep an eye on this project and see if no other improvements could be taken along.

No additional version request is needed anymore as these changes were already approved.

This is also a call to all Driver Product Owners to keep an eye on this project and try to get these tasks picked up whenever changes are done in the protocols you are the owner for.
