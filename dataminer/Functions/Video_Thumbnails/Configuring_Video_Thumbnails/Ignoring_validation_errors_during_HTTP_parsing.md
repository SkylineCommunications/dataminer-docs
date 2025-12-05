---
uid: Ignoring_validation_errors_during_HTTP_parsing
---

# Ignoring validation errors during HTTP parsing

It is possible to configure the thumbnail *web.config* file to ignore any validation errors that occur during HTTP parsing.

> [!CAUTION]
> Ignoring validation errors has security implications, so this should only be done as a last resort to gain backward compatibility with a server. However, we recommend that in such a case the software on the server is updated instead, so that it does send valid HTTP messages.

To do so:

1. Open the file `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`.

1. Add the following option:

   ```xml
   <add key="UseUnsafeHeaderParsing" value="true" />
   ```

   > [!NOTE]
   > When this property is set to false (the default setting), the following validation is performed during HTTP parsing:
   >
   > - In end-of-line code, only CRLF is allowed, not CR or LF alone.
   > - Headers names may not have spaces in them.
   > - If multiple status lines exist, all additional status lines are treated as malformed header name/value pairs.
   > - The status line must have a status description, in addition to a status code.
   >
   > Regardless of whether the property is set to true or false, header names may not contain non-ASCII characters.

> [!TIP]
> See also: <https://msdn.microsoft.com/en-us/library/system.net.configuration.httpwebrequestelement.useunsafeheaderparsing.aspx>
