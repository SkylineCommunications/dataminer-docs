---
uid: SLNetClientTest_retrain_rad_model
---

# Retraining the internal model used by RAD

In some cases, it can be useful to retrain the internal model used by [relational anomaly detection (RAD)](xref:Relational_anomaly_detection). This allows you to indicate the periods during which a parameter group was behaving as expected, so that RAD can better identify when the parameters deviate from that expected behavior in the future.

> [!TIP]
> Instead of using the SLNetClientTest tool, from DataMiner 10.5.4/10.6.0 onwards, you can also use the [RAD Manager](xref:RAD_manager#configuring-model-training) app to retrain a RAD parameter group.

1. [Connect to the DMA hosting the grouped parameters using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* dropdown list, select the message *Skyline.DataMiner.Analytics.Rad.RetrainRADModelMessage*.

   > [!NOTE]
   > Prior to DataMiner 10.5.5/10.6.0<!--RN 42480-->, the message is called "*Skyline.DataMiner.Analytics.MAD.RetrainMADModelMessage*" instead. In this message, "MAD" stands for "multivariate anomaly detection", which is another name for RAD.

1. Configure the following fields:

   - *GroupName*: The name of the parameter group as configured in the *ai_rad_models_v2* database table. In versions prior to DataMiner 10.5.9/10.6.0, this is configured in the *RelationalAnomalyDetection.xml* file instead.
   - *StartTime*: The start time of the period during which the parameter group was behaving as expected.
   - *EndTime*: The end time of the period during which the parameter group was behaving as expected.

1. Click *Send Message*.

> [!NOTE]
>
> - From DataMiner 10.5.4/10.6.0 onwards, [other messages](xref:SLNetClientTest_managing_RAD_parameter_groups) are also available that can be used to add a parameter group, retrieve a parameter group, or retrieve all configuration information for a particular group.<!-- RN 42181 -->
> - Keep in mind that the group names need to be unique. Prior to DataMiner 10.5.4/10.6.0, casing is taken into account for this, but this no longer matters in later DataMiner versions.<!-- RN 42276 -->

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
