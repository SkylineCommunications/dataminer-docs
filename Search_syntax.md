---
uid: Advanced_Search_Syntax
---

# Advanced search syntax

The search functionality in the DataMiner documentation is powered by Azure AI Search. By default, the search uses [wildcard search syntax](https://learn.microsoft.com/en-us/azure/search/query-lucene-syntax#bkmk_wildcard) to help you find relevant results even when search terms are incomplete or slightly different from the indexed content.

In addition to this default behavior, several advanced search syntaxes are supported:

- Proximity search: Find terms that appear close to each other by adding a tilde `~` followed by the maximum number of words allowed between the terms.

  ```txt
  "updating time"~3
  ```

- Fuzzy search: Find terms with similar spellings by adding a tilde `~` after a single word.

  ```txt
  connectr~
  ```

- ...

> [!TIP]
> For more information about supported Lucene query syntax features in Azure AI Search, see [Lucene query syntax in Azure AI Search](https://learn.microsoft.com/en-us/azure/search/query-lucene-syntax).
