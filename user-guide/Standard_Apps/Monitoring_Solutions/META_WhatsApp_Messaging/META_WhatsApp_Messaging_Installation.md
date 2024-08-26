---
uid: META_WhatsApp_Messaging_Installation
---

# Installing the META WhatsApp Messaging solution

## Prerequisites

Before installing the *META WhatsApp Messaging* connector, ensure you meet all the prerequisites:

1. Make sure you are [registered as a Meta Developer](https://developers.facebook.com/docs/development/register).

1. [Create the *DataMiner Alarm Notification* app](#create-the-dataminer-alarm-notification-app).

1. [Create a Business Manager account](#create-a-business-manager-account).

1. [Add WhatsApp to your app and send a test message](#add-whatsapp-to-your-app-and-send-a-test-message).

### Create the 'DataMiner Alarm Notification' app

1. Navigate to *My Apps* and select *Create App*.

1. Select *I don't want to connect a business portfolio yet*.

1. Select *Other* as the use case.

1. Set the app type to *Business*.

1. Specify the following app details:

   - Name: `DataMiner Alarm Notification`

   - Email address: The email address to be used to contact you about this app

1. Click *Create App*.

   Your app will be loaded in the app Dashboard.

   ![App in META Developers Account](~/user-guide/images/META_WhatsApp_Messaging_MetaRegister.png)

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

![META Business Account](~/user-guide/images/META_WhatsApp_Messaging_BusinessAccount.png)

### Add WhatsApp to your app and send a test message

1. Go to the App Dashboard of the *DataMiner Alarm Notification* app.

1. Locate *WhatsApp* under the *Add Products* section and select *Set up*.

1. Click *Quick Start* and select the commercial portfolio you previously created.

1. Navigate to *API Configuration* > *Send and receive messages* and follow steps 1 and 2:

   1. Add a new recipient’s phone number.

      > [!NOTE]
      > Add all the recipient numbers you want the WhatsApp alarm notifications to be sent to.

   1. Verify the new phone number by entering the verification code you have received via WhatsApp.

   1. Select the recipient's phone number.

   1. To send a test message to your newly added phone number, click *Send message* in the lower right corner.

1. Save the *Phone number identifier* and the *WhatsApp Business Account ID*, which you can find right below the sender's number.

![META App](~/user-guide/images/META_WhatsApp_Messaging_MetaApp.png)

### Create a System User

1. Go to [*Meta Business Suite*](https://business.facebook.com/).

1. Go to *Users > System Users* and select *+ Add* in the top-right corner.

1. Give your new system user a name and a role (*Employee* or *Admin*).

1. Select the user you created, click the ellipsis button ("..."), and select *Assign assets*.

1. Assign your app to the new user, and give them the appropriate permissions.

1. Select *Generate token*.

1. Select the app.

- Choose the desired time for the token to expire (60 days recommended for security).
- Assign the following permissions: *business_management, whats_app_business_messaging, whats_app_business_management*
- Save the **generated token** in a safe place, as it will be needed for the **connector configuration**.

![META Business Account](~/user-guide/images/META_WhatsApp_Messaging_UserToken.png)

## Installing the 'META WhatsApp Messaging' connector

1. Look up the [*META WhatsApp Messaging* solution](https://catalog.dataminer.services/details/909de004-7a8f-43bd-b40c-824051fe3fe1) in the DataMiner Catalog.
1. Click the *Deploy* button.
1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.
    - *If this is the first time you install the solution, a new automation script named **"Meta Alarm Detection"**, a new view called **"Dataminer Apps & Solutions"** and an element named **"META WhatsApp Alerter"** will automatically be created. Optionally, you can rename any of them and change their locations.*
1. Create a correlation rule.
    1. Set the alarm filter desired to trigger the correlation.
    1. Set an action to run the ***"META Alarm Detection"*** script recently included in the proper DMA.

*For more info about correlation rules visit [Orchestration & Automation courses](https://community.dataminer.services/learning/courses/orchestration-automation/) and [About DataMiner Correlation](https://docs.dataminer.services/user-guide/Advanced_Modules/Correlation/About_DMS_Correlation.html)*.

> [!IMPORTANT]
> You can create as many correlation rules and elements as you need to send different alarms to different contacts.
