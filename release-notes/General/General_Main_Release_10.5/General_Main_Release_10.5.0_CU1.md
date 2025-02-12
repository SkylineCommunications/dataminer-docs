---
uid: General_Main_Release_10.5.0_CU1
---

# General Main Release 10.5.0 CU1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Web visual overviews: Load balancing [ID 41434] [ID 41728]

<!-- MR 10.5.0 [CU1]/10.6.0 [CU0] - FR 10.5.2 -->

It is now possible to implement load balancing among DataMiner Agents in a DMS for visual overviews shown in web apps.

Up to now, the DataMiner Agent to which you were connected would handle all requests and updates with regard to web visual overviews.

##### Configuration

In the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file of a particular DataMiner Agent, add the following keys in the `<appSettings>` section:

- `<add key="visualOverviewLoadBalancer" value="true" />`

  Enables or disables load balancing on the DataMiner Agent in question.

  - When this key is set to **true**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will by default be handled in a balanced manner by all the DataMiner Agents in the cluster.

    However, if you also add the `dmasForLoadBalancer` key (see below), these requests and updates will only be handled by the DataMiner Agents specified in that `dmasForLoadBalancer` key.

  - When this key is set to **false**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will be handled by the local SLHelper process.

- `<add key="dmasForLoadBalancer" value="1;2;15" />`

  If you enabled load balancing by setting the `visualOverviewLoadBalancer` key to true, you can use this key to restrict the number of DataMiner Agents that will be used for visual overview load balancing.

  The key's value must be set to a semicolon-separated list of DMA IDs. For example, if the value is set to "1;2;15", the DataMiner Agents with ID 1, 2, and 15 will be used to handle all requests and updates with regard to web visual overviews.

  If you only specify one ID (without trailing semicolon), only that specific DataMiner Agent will be used to handle all requests and updates with regard to web visual overviews.

> [!NOTE]
> These settings are not synchronized among the Agents in the cluster.

##### New server messages

The following new messages can now be used to  which you can target to be sent to other DMAs in the cluster:

- `TargetedGetVisualOverviewDataMessage` allows you to retrieve a Visual Overview data message containing the image and the content of a visual overview.

- `TargetedSetVisualOverviewDataMessage` allows you to execute actions on a visual overview that is rendered on a specific DataMiner Agent.

> [!NOTE]
> DataMiner Agents will now automatically detect that a visual overview they are rendering has been updated. This means that other agents in the cluster will now be able to correctly process update events and request new images for their clients.

##### Logging

Additional logging with regard to visual overview load balancing will be available in the web logs located in the *C:\\Skyline DataMiner\\Logging\\Web* folder.

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

### Fixes

#### Issue in SLNet could cause errors to be thrown in low-code apps [ID 40978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.2 -->

Because of an issue in SLNet, after a restart of a DataMiner Agent, "not supported by the current server version" errors could get thrown in all low-code apps.

#### SLAnalytics: Memory leak due to an excessive number of messages being received following an alarm template update [ID 42047]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an alarm template was updated, in some cases, the alarm focus manager could receive a excessive number of messages, causing SLAnalytics to leak memory.

#### Mobile Visual Overview: Problem with user context [ID 42061]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when no user context was needed in mobile visual overviews, an attempt would be made to reuse server-side cards among users. However, in some cases, this could cause problems, especially when handling popups or embedded visual overviews.

To make sure the user context is always correct and that it get passed correctly to popups, from now on, mobile visual overviews will always use a separate card for each user and create a new card whenever a user requests a new visual overview in a web app.
