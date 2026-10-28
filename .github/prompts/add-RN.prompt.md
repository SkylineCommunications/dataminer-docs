---
agent: 'agent'
description: 'This prompt is used to retrieve a release note from SkylineApi and add it on docs'
---

Can you do the following:

1. Ask me for a release note ID.

1. Retrieve the release note from SkylineApi.

1. Check if the release note is linked to one of the soft-launch options listed on the page `/dataminer/Reference/Soft-launch_options/Overview_of_Soft_Launch_Options.md`.

1. If it is linked to one of the soft launch options, return the soft launch option it is linked to in the chat using the following specified syntax, and abort the process. Do not continue to the next step.

   ```markdown
   RN <RELEASE_NOTE_ID> is linked to soft launch option [<SOFT_LAUNCH_OPTION>](<Link to the soft launch option>).
   It will not be documented in the release notes.
   ```

1. If the release note is not linked to any of the existing soft launch options, document it in the correct markdown file in `dataminer-docs/release-notes`.

<!-- To use this prompt, you will first have to make sure you are connected to the Collaboration MCP Server. To do so, in VS Code, press Ctrl + Shift + P and select "MCP: List Servers". If the server is not listed yet, select "+ Add Server", then select HTTP, and then enter the URL "https://collaboration-mcp-server.thankfulsea-26bd4902.westeurope.azurecontainerapps.io/mcp", and select "Global". Note that this will only work for Skyline employees. -->
