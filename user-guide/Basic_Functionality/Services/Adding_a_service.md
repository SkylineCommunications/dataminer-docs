---
uid: Adding_a_service
---

# Adding a service

> [!TIP]
> See also: [Rui’s Rapid Recap – Creating a service](https://community.dataminer.services/video/ruis-rapid-recap-creating-a-service/) ![Video](~/user-guide/images/video_Duo.png)

1. Right-click in the Surveyor and select *New \> Service* to add a new service.

   > [!NOTE]
   >
   > - A service that uses a service protocol can also be created via the Protocols & Templates module. To do so, in the Protocols & Templates module, select the service protocol, the version, the alarm template and the trend template, right-click in the *Elements* column and select *New service*.
   > - From DataMiner 9.0.1 onwards, you can instead transform an existing view into a service, if that view has no child views. The child elements in the view will become child elements of the new service. To transform a view into a service, right-click the view and select *Actions* > *Upgrade to service*. If necessary, you can then still edit the new service in order to fine-tune it according to the procedure below.

1. Enter a name for the service.

   > [!NOTE]
   >
   > - This name has to be unique. In a DMS, you cannot have two services with the same name.
   > - The name of the service can be changed at any time after the service is created. The service is uniquely identified by its ID, which is a combination of the DMA ID of the DMA where the service is originally created and the ID of the service itself.

    > [!TIP]
    > See also:
    > [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc)

1. Optionally, add a description with more detailed information.

   > [!NOTE]
   > If required information is missing or incorrect, the label in question will be displayed in red.

1. If there is more than one DMA available in your DMS, select the DMA that will manage the service.

1. If you wish to replicate an existing service located in another DMS, select the *Replicate* checkbox, and:

   1. Enter the IP address or the hostname of the DMA where the service is located.

   1. Connect to the DMA with a user account and password.

   1. Click the *Retrieve services* button.

      Depending on the rights the account has been granted on the DMA, a list of services will be displayed.

   1. Select the service you wish to replicate from the list.

      > [!NOTE]
      >
      > - The source and replication DMA must use the same DataMiner version.
      > - External authentication credentials cannot be used when replicating services. This is for instance the case when users are authenticated against an Atlassian Crowd server.
      > - Unlike element replication (where the replicated element shows all data from the original element), service replication only replicates the summary severity of the original service and does not provide access to any of the service data. This also applies for enhanced services.

1. Optionally, configure more advanced options:

   - If you do not want timeouts to be included in the alarm status of the service, clear the checkbox *Include timeouts in alarm status of the service*. By default, this option is selected.

   - Add a service protocol (also known as “service definition” in earlier versions of DataMiner):

        1. Select an existing service protocol.

        1. Choose a version from the available options.

        1. Choose an alarm or trend template, if available.

           > [!NOTE]
           >
           > - You can also quickly change the selected template by clicking the following button to the right of the field: ![App icon](~/user-guide/images/Open_protocols_app_icon.png)<br>This will temporarily open the Protocol & Templates app, where you can make the necessary changes. See [Configuring alarm thresholds](xref:Configuring_normal_alarm_thresholds) and [Configuring trend templates](xref:Configuring_trend_templates).
           > - A service that has been created using a service protocol is called an “enhanced service”.

1. Click the *Next* button in the lower right corner to go to the *parameters* page.

1. Click the buttons in the lower left corner to add elements, services, or a group of elements and/or services.

   - To add elements or services:

        1. Click *Add element*.

        1. Select the elements or services you want to add in the column on the left, and use the *Add* button to move them to the column with included elements on the right. To remove elements or services again, select them in the column on the right and click the *Remove* button. Click *Close* when ready.

        1. Select a service child item to configure it further.

        1. Optionally, enter an alias for the selected item.

           > [!NOTE]
           >
           > It is possible to add multiple instances of the same element in a service. Specifying an alias is mandatory for all duplicate instances, and it is the alias of the service elements that will be displayed in the Surveyor.

        1. If an element or enhanced service is selected, to include only some parameters, clear the checkbox *All parameters for this element*, and select the parameters in question.

           > [!NOTE]
           >
           > - For a matrix element, you can select specific inputs or outputs to be included from the list of parameters.
           > - If you select a table parameter to include, a filter allows you to select the rows to be included in the service. You can select a row in the drop-down list, or specify a filter yourself. If you specify the filter, you can also select rows by primary key. For example, enter the filter \*24\* to include all rows of which the display key contains “24”, or enter ^pk^\*24\* to include all rows of which the primary key contains “24”.

        1. Indicate if the selected item should always be included, or if it should be excluded depending on one or more conditions.

        1. Indicate if the selected item should influence the alarm severity of the service you are creating, or if this should depend on one or more conditions. When it does not influence the alarm severity, the element or service will be set to *Not Used*.

           > [!NOTE]
           > For more information on how to include elements conditionally, see [Conditionally including an element in a service](xref:Conditionally_including_an_element_in_a_service).

        1. In the *ADVANCED* section, set a maximum severity for the service item if it has the status “included” or “not used”. For more information on the possible statuses, see [DATA](xref:Service_card_pages#data).

        1. Repeat from step c for each additional item that needs to be configured.

   - To add a group:

        1. Click *Add group*.

        1. Specify a name for the group.

        1. Indicate if the group is always to be included, or if this should depend on one or more conditions.

        1. Indicate whether the group should influence the alarm severity of the service, or if this should depend on one or more conditions. When it does not influence the alarm severity, all elements or services in the group will be set to *Not Used*.

           > [!NOTE]
           > The procedure to include a group conditionally is the same as that to include an element conditionally. See [Conditionally including an element in a service](xref:Conditionally_including_an_element_in_a_service).

        1. In the *ADVANCED* section, set a maximum severity for the items included in the group if they have the status “included” or “not used”.

           > [!NOTE]
           >
           > - Maximum severity settings on item level override those on group level.
           > - For more information on the possible statuses, see [DATA](xref:Service_card_pages#data).

        1. Click *Create*.

        1. Select the group in the list on the left, and click *Add element* to add elements or services to the group.

   - To remove any items you have added, click the *x* to the right of the item.

1. Click the *Next* button in the lower right corner to go to the *Views* page.

1. Indicate the view where you want to add the service.

1. Optionally, click the *Next* button in the lower right corner to go to the *Properties* page, and enter any custom properties.

   > [!NOTE]
   > You can also add, edit or delete custom properties later, by right-clicking the service in the Surveyor and selecting *Properties*. For more information, see [Managing element properties](xref:Managing_element_properties).

1. Click the *Create* button in the lower right corner to finish creating the service.

   > [!NOTE]
   >
   > - If you want to edit the settings of a service after creation, right-click the service in the Surveyor, and choose *Edit*. You will then have the same options as during the creation of the service.
   > - A service can also be created by a parent element. In that case, it is possible that it is not or only partly editable, except by an Administrator or via the parent element.
