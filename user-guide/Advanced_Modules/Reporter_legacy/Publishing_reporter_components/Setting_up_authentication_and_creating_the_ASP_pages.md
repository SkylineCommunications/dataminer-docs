---
uid: Setting_up_authentication_and_creating_the_ASP_pages
---

# Setting up authentication and creating the ASP pages

Do the following if you want to be able to show DataMiner report components on webpages by means of \<img> tags:

1. Copy the `C:\Skyline DataMiner\Webpages\Reports\RemoteGraphs` folder from the DataMiner Agent to an arbitrary location on your web server.

1. On the DataMiner Agent, create a file named `C:\Skyline DataMiner\Reporter.xml`. In it, specify the secret string that will be shared by the DataMiner Agent and the web server as a means of authentication:

   ```xml
   <Reporter>
     <RemoteGraphs>
       <SharedSecret>secret string</SharedSecret>
     </RemoteGraphs>
   </Reporter>
   ```

1. On the web server, open the `RemoteGraphs\Config.inc.asp` file and edit the following two lines:

   ```txt
   strRemoteUrl = 'http://DataMiner Agent IP Address/Reports/Graphs/';
   strSharedSecret = 'secret string';
   ```

1. In the *RemoteGraphs* folder on the web server, create an ASP page for each report graph. Here you see the ASP page for the Alarm Distribution graph (*MyAlarmDistribution.asp*):

   ```xml
   <%@ Language="JScript" %>
   <!-- #include file="RemoteImages.inc.asp" -->
   <%
     var strUrl = createAlarmDistributionUrl(
       ALL_ELEMENTS, // element
       DISTRIBUTION_DAY, // distriType
       TIMEPERIOD_WEEK, // avgType
       600, // width
       300, // height
       0, // distriTypeParam
       '' // view filter
     );
     getRemoteImage(strUrl);
   %>
   ```

   For more information on the *create...Url* methods you can use in your ASP scripts, see [Component overview](xref:Component_overview).

1. Once your ASP pages have all been created, you can refer to them in any webpage using an \<img> tag similar to this one:

   ```xml
   <img
     src="http://webserver/RemoteGraphs/MyAlarmDistribution.asp"
     width="600" height="300" alt="Alarm Distribution for last day"
   />
   ```
