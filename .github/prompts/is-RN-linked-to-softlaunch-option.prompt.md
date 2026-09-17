---
agent: 'agent'
description: 'This prompt is used to find out whether a release note is linked to the soft launch option'
---

Can you ask me a release note ID, and then check if it is linked to one of the soft launch options listed on the following page:

<https://docs.dataminer.services/dataminer/Reference/Soft-launch_options/Overview_of_Soft_Launch_Options.html>

If so, then return the soft launch option it is linked to in the chat using the following syntax:

```markdown
Release Note ID: <RELEASE_NOTE_ID>
Soft Launch Option: [<SOFT_LAUNCH_OPTION>](<Link to the soft launch option>)
```
