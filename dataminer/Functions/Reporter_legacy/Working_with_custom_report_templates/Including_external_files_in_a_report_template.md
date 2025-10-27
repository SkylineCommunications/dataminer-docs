---
uid: Including_external_files_in_a_report_template
---

# Including external files in a report template

When using the DataMiner JScript methods to include graphs, you do not need to worry about how to get these graphs into an email message. The framework will do this for you. However, when you want to link style sheets or images of your own, you will need to take some extra actions.

## List the external files at the top of the template file

Call the *addExtraFilesToInclude()* method at the very top of the template. Be sure to do this before sending any output to the client:

```xml
<%@ Language="JScript" %>
<!-- #include file="Templates.inc.asp" -->
<%
  template.addExtraFilesToInclude(new Array(
    'styles/mail.css',
    'images/myimage.gif'
  ));
>
```

> [!NOTE]
> File references must be either absolute or relative to the following folder:<br> `C:\Skyline DataMiner\Webpages\Reports\templates`

## Edit references inside the template

Once you have included the necessary external files using the *addExtraFilesToInclude()* method, each time you refer to one of those files, you have to replace their original path with the content ID prefix. That way, all links to included files will be correctly interpreted in the HTML source of the email message.

See the examples below.

| Instead of writing ...   | write ...             |
|--------------------------|-----------------------|
| href="styles/mail.css"   | href="cid:mail.css"   |
| src="images/myimage.jpg" | src="cid:myimage.jpg" |
