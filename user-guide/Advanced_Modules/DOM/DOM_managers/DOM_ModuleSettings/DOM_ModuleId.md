---
uid: DOM_ModuleId
---

# Module ID property

This is the ID (string) used to distinguish between multiple running DOM managers. For more information, see [DOM managers](xref:DOM_managers).

Since this name is used in the index name of Elasticsearch, a few requirements are in place:

- The ID must not be empty or null.

- The ID must not be longer than 40 characters.

- The ID must be lowercase.

- The ID must not have one of the following characters:

  - "\" (backslash)
  - "/" (slash)
  - "*" (asterisk)
  - "?" (question mark)
  - """ (quotation mark)
  - "<" (less than)
  - ">" (greater than)
  - "|" (vertical bar or pipe)
  - " " (space)
  - "," (comma)
  - "#" (hashtag)
  - ":" (colon)
  - "-" (hyphen)
