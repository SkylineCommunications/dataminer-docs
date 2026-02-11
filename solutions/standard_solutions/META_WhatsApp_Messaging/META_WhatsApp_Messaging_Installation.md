---
uid: META_WhatsApp_Messaging_Installation
---

# Installing the META WhatsApp Messaging Solution

## Prerequisites

Before [installing the *META WhatsApp Messaging* connector](#installing-the-meta-whatsapp-messaging-connector), ensure you meet all the prerequisites:

- Make sure you are [registered as a Meta Developer](https://developers.facebook.com/docs/development/register).

- [Create the *DataMiner Alarm Notification* app](#create-the-dataminer-alarm-notification-app).

- [Create a Business Manager account](#create-a-business-manager-account).

- [Add WhatsApp to your app and send a test message](#add-whatsapp-to-your-app-and-send-a-test-message).

- [Create a system user](#create-a-system-user).

### Create the 'DataMiner Alarm Notification' app

1. Navigate to *My Apps* and select *Create App*.

1. Select *I don't want to connect a business portfolio yet*.

1. Select *Other* as the use case.

1. Set the app type to *Business*.

1. Specify the following app details:

   - Name: `DataMiner Alarm Notification`

   - Email address: The email address to be used to contact you about this app

1. Click *Create App*.

   Your app will be loaded in the App Dashboard.

   ![App in META Developers Account](~/dataminer/images/META_WhatsApp_Messaging_MetaRegister.png)

> [!TIP]
> See also: [App Type Creation Flow](https://developers.facebook.com/docs/development/create-an-app/other-app-types)

### Create a Business Manager account

1. Go to the [*Meta Business Suite*](https://business.facebook.com/) and select *Create an account*.

1. Provide the following information:

   - Your business name

   - Your name (i.e. the owner)

   - Your business email (i.e. the email address you will use to conduct company business)

     > [!NOTE]
     > Make sure you choose an email address you have access to as you will need to confirm it later.

1. Specify the required details of the business.

1. Confirm the business email address.

![META Business Account](~/dataminer/images/META_WhatsApp_Messaging_BusinessAccount.png)

### Add WhatsApp to your app and send a test message

1. Go to the App Dashboard and select the *DataMiner Alarm Notification* app.

1. Locate *WhatsApp* under the *Add Products* section and select *Set up*.

1. Click *Quick Start* and select the commercial portfolio you previously created.

1. Navigate to *API Configuration* > *Send and receive messages* and follow steps 1 and 2:

   1. Add a new recipient’s phone number.

      > [!NOTE]
      > Add all the recipient numbers you want the WhatsApp alarm notifications to be sent to.

   1. Verify the new phone number by entering the verification code you have received via WhatsApp.

   1. Select the recipient's phone number.

   1. To send a test message to your newly added phone number, click *Send message* in the lower-right corner.

1. Save the *Phone number identifier* and the *WhatsApp Business Account ID*, which you can find right below the sender's number.

![META App](~/dataminer/images/META_WhatsApp_Messaging_MetaApp.png)

### Create a system user

1. Go to the [*Meta Business Suite*](https://business.facebook.com/).

1. Navigate to *Users > System Users* and click the *+ Add* button in the top-right corner.

1. In the pop-up window, enter a name for your new system user and choose the appropriate role (*Employee* or *Admin*).

1. Select the user you created, click the ellipsis button ("..."), and select *Assign assets*.

1. Select the app you want to assign to this system user (i.e. the *DataMiner Alarm Notification* app), and grant them the appropriate permissions.

1. Select *Generate token*.

1. Select the app you previously assigned to the user.

1. Choose the duration for the token's validity. For security reasons, a 60-day expiry period is recommended.

1. Ensure that the following permissions are selected for the generated token:

   - *business_management*

   - *whats_app_business_messaging*

   - *whats_app_business_management*

1. After the token is generated, copy it and store it securely. You will need this token when [configuring the connector](xref:Using_META_WhatsApp_Messaging).

![META Business Account](~/dataminer/images/META_WhatsApp_Messaging_UserToken.png)

## Installing the 'META WhatsApp Messaging' connector

1. Look up the [*META WhatsApp Messaging* Solution](https://catalog.dataminer.services/details/909de004-7a8f-43bd-b40c-824051fe3fe1) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   This will create a DataMiner element named "META WhatsApp Alerter" in your system. The element will be located in the *DataMiner Apps & Solutions* view.

   A new automation script named "Meta Alarm Detection" will also be added to your system.

1. In Cube, go to the *DATA > Configuration* page of the *META WhatsApp Alerter* element.

1. Fill in the *Phone Number ID*, *WhatsApp Business ID*, and *Token* parameters with the values you saved earlier.
