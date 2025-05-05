function initSearch() {
  const BASE_DOCS_URL = "https://docs.dataminer.services";
  const BASE_STORAGE_ACCOUNT_URL = "https://docshelp.blob.core.windows.net";
  const BLOB_CONTAINER_NAMES = [
    "docs-connectors", // https://docs.dataminer.services/connector (connectors)
    "docs", // https://docs.dataminer.services/* (main)
  ];

  createSearchResultsNewHtml();
  initEventHandlersCloseOpenSearch();

  function debounce(func, wait, immediate) {
    var timeout;
    return function () {
      var context = this, args = arguments;
      var later = function () {
        timeout = null;
        if (!immediate) func.apply(context, args);
      };
      var callNow = immediate && !timeout;
      clearTimeout(timeout);
      timeout = setTimeout(later, wait);
      if (callNow) func.apply(context.target.value, args);
    };
  };

  function createSearchResultsNewHtml() {
    var searchBox = document.getElementById("search-input")
    searchBox.addEventListener("keyup", debounce(search, 250));
  }

  function getTitle(str) {
    const endsWith = "| DataMiner Docs"

    if (str.length >= endsWith.length) {
      const lastIndex = str.lastIndexOf(endsWith);
      if (lastIndex === (str.length - endsWith.length)) {
        // strings ends with endsWith
        return str.slice(0, lastIndex);
      }
    }
    return str;
  }

  function getUrlBlobStorageContainer(storageAccountUrl, blobContainerName) {
    return `${storageAccountUrl}/${blobContainerName}/`;
  }

  function composeDocsUrlWithoutBeginPart(blobUri, beginPartUrl) {
    return `${BASE_DOCS_URL}/${blobUri.substring(beginPartUrl.length)}`;
  }

  function getDocsUrlFromBlobStoragePathUri(blobUri) {
    // example url docs main: https://docshelp.blob.core.windows.net/docs/user-guide/Getting_started/Creating_a_DataMiner_System.html
    // example url docs connectors: https://docshelp.blob.core.windows.net/docs-connectors/connector/doc/Skyline_Regression_Test_Result_Collector.html

    for (const blobContainerName of BLOB_CONTAINER_NAMES) {
      const beginPartUrl = getUrlBlobStorageContainer(BASE_STORAGE_ACCOUNT_URL, blobContainerName);

      if (blobUri.startsWith(beginPartUrl)) {
        return composeDocsUrlWithoutBeginPart(blobUri, beginPartUrl);
      }
    }

    return '';
  }

  function initEventHandlersCloseOpenSearch() {

    var newSearchBox = document.getElementById("new-search-btn");

    newSearchBox.addEventListener("click", (event) => {
      showSearch(true);
      document.getElementById('search-input').focus();
    });

    //attach a click handler to the close icon
    var searchCloseButton = document.getElementById("search-close-btn");
    searchCloseButton.addEventListener("click", (event) => {
      showSearch(false);
      clearResults();
      clearSearchInput();
    });
  }

  function search(e) {
    var searchTerm = e.target.value;
    if (searchTerm.length) {
      doGetHttpRequest(searchTerm);
    } else {
      clearResults();
    }
  }

  function doGetHttpRequest(searchTerm) {
    var url = `https://docs-srch.search.windows.net/indexes/index1745835548900/docs/search?api-version=2025-03-01-preview&api-key=5630827C003AFD513AA4D8D21A0A79B7`;
    var searchTermEnhanced = searchTerm;
    var pattern = /[a-zA-Z]$/;
    if (pattern.test(searchTermEnhanced)) {
      searchTermEnhanced += "*";
    }
    var body = '{"search": \'' + searchTermEnhanced + '\',"searchMode": "all","queryType": "full","top": 200}';

    let xhr = new XMLHttpRequest()
    xhr.onload = function () {
      if (xhr.status === 200) {
        processSearchResults(JSON.parse(xhr.responseText), searchTerm);
      }
    }
    xhr.onerror = () => {
      clearResults();
      addHtmlToResultElement('<p>Unsupported search query.</p>');
    };
    xhr.open('POST', url, true)
    xhr.setRequestHeader('Content-type', 'application/json; charset=UTF-8')
    xhr.send(body);
  }

  function clearResults() {
    document.getElementById("search-result-items").innerHTML = "";;
  }

  function clearSearchInput() {
    document.getElementById('search-input').value = '';
  }

  function addHtmlToResultElement(html) {
    const resultElement = document.getElementById("search-result-items");
    //resultElement.append(html);
    resultElement.innerHTML += html;
  }

  function processSearchResults(data, searchTerm) {
    clearResults();

    if (!data.value || data.value.length < 1) {
      addHtmlToResultElement('<p>No results found.</p>')
    } else {
      const html = [];

      for (const result of data.value) {
        if (result.metadata_storage_name !== "toc.html" && result.metadata_title !== null) {
          // results with toc.html files (table of contents) + without title are skipped
          const title = getTitle(result.metadata_title);
          const url = getDocsUrlFromBlobStoragePathUri(result.storage_path);
          const htmlString = `<div class="result"><a href="${url}?q=${encodeURIComponent(searchTerm)}"><div class="url">${url}</div><div class="title">${title}</div></a></div>`;
          html.push(htmlString)
        }
      }

      addHtmlToResultElement(html.join(''))
    }
  }

  function showSearch(showSearch) {
    var searchResults = document.getElementById('search-results-new');
    if (showSearch) {
      document.getElementById("main").style.display = "none";
      searchResults.style.display = "block";
    } else {
      document.getElementById("main").style = null;
      searchResults.style.display = "none";
    }
  }
}
