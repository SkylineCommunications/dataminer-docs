function initSearch() {
  const BASE_DOCS_URL = "https://docs.dataminer.services";
  const BASE_STORAGE_ACCOUNT_URL = "https://docshelp.blob.core.windows.net";
  const BLOB_CONTAINER_NAMES = [
    "docs-connectors", // https://docs.dataminer.services/connector (connectors)
    "docs", // https://docs.dataminer.services/* (main)
  ];

  createSearchResultsNewHtml();
  initEventHandlersCloseOpenSearch();
  tryHandleURL();

  function tryHandleURL() {
    const searchQuery = new URLSearchParams(window.location.search)?.get('search') ?? '';
    if (!searchQuery)
      return;

    const words = new Set(searchQuery
      .split('/')
      .slice(-1)
      .map(part => part.replace(/\.[^/.]+$/, '').replace(/[_\-]/g, ' ').replace(/([A-Z][a-z])/g, ' $1'))
      .filter(Boolean)
      .join(' ')
      .toLowerCase()
      .split(/\s+/));

    if (!words.size)
      return;

    const query = Array.from(words).join(' ');
    showSearch(true);
    document.getElementById("search-input").value = query;
    doGetHttpRequest(query);
  }

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
    searchBox.addEventListener("keyup", debounce(search, 350));
  }

  function getTitle(str) {
    const endsWith = " | DataMiner Docs"

    if (str.length >= endsWith.length) {
      const lastIndex = str.lastIndexOf(endsWith);
      if (lastIndex + 1 === (str.length - endsWith.length)) {
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
    // example url docs main: https://docshelp.blob.core.windows.net/docs/dataminer/Getting_started/Deploying_a_DataMiner_System.html
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
    var body = '{"search": \'' + searchTermEnhanced + '\',"searchMode": "all","queryType": "full","top": 300}';

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
        addHtmlToResultElement('<p>No results found.</p>');
        return;
    }

    // Predefined category rules
    const CATEGORY_RULES = {
        "Overview": "dataminer/",
        "Solutions": "solutions/",
        "Dev Guide": "develop/",
        "Connectors": "connector/",
        "Release Notes": "release-notes/"
    };

    const categories = { "all": { count: 0, items: [] } };
    for (const category in CATEGORY_RULES) {
        categories[category] = { count: 0, items: [] };
    }
    categories["Other"] = { count: 0, items: [] };

    const results = [];

    // Categorize and store results with scores
    for (const result of data.value) {
        if (result.metadata_storage_name !== "toc.html" && result.metadata_title !== null) {
            const title = getTitle(result.metadata_title);
            const url = getDocsUrlFromBlobStoragePathUri(result.storage_path);
            const score = result["@search.score"] || 0;

            // Determine category based on URL pattern
            let category = "Other";
            for (const [key, prefix] of Object.entries(CATEGORY_RULES)) {
                if (url.includes(prefix)) {
                    category = key;
                    break;
                }
            }

            categories["all"].count++;
            categories[category].count++;

            // results.push({
            //     html: `<div class="result" data-category="${category}" data-score="${score}">
            //               <div class="category-label">${category}</div>
            //               <a href="${url}?q=${encodeURIComponent(searchTerm)}">
            //                   <div class="title">${title}</div>
            //                   <div class="url">${url}</div>
            //               </a>
            //            </div>`,
            //     score,
            //     category
            // });
            results.push({
                html: `<div class="result" data-category="${category}" data-score="${score}" style="display: block;">
                        <div class="result-content">
                          <div class="result-text">
                            <a href="${url}?q=${encodeURIComponent(searchTerm)}">
                              <div class="title">${title}</div>
                              <div class="url">${url}</div>
                            </a>
                          </div>
                          <div class="category-label">${category}</div>
                          </div>
                       </div>`,
                score,
                category
            });
        }
    }

    // Sort results by score (highest first)
    results.sort((a, b) => b.score - a.score);

    // Generate filter checkboxes dynamically (Only "Show All" checked by default)
    let filterHtml = `<div id="filters"><label><input type="checkbox" checked data-category="all">&nbsp;All (${categories["all"].count})</label>`;
    for (const [category, info] of Object.entries(categories))
    {
        if (category !== "all" && info.count > 0)
        {
            filterHtml += `&nbsp;<label><input type="checkbox" data-category="${category}"> ${category} (${info.count})</label>`;
        }
    }
    filterHtml += `</div>`;
    addHtmlToResultElement(filterHtml);

    // Append sorted results
    addHtmlToResultElement(results.map(r => r.html).join(''));

    // Add filter event handlers with improved logic
    document.querySelectorAll('#filters input').forEach(input => {
        input.addEventListener('change', () => {
            const allCheckbox = document.querySelector('input[data-category="all"]');
            const categoryCheckboxes = document.querySelectorAll('input:not([data-category="all"])');

            if (input.dataset.category === "all") {
                if (input.checked) {
                    categoryCheckboxes.forEach(cb => cb.checked = false);
                }
            } else {
                if (input.checked) {
                    allCheckbox.checked = false;
                }

                // If no category checkboxes are checked
                const anyChecked = Array.from(categoryCheckboxes).some(cb => cb.checked);
                if (!anyChecked) allCheckbox.checked = true;
            }

            // Update visibility of results
            const selectedCategories = Array.from(document.querySelectorAll('#filters input:checked')).map(i => i.dataset.category);
            document.querySelectorAll('.result').forEach(result => {
                result.style.display = selectedCategories.includes("all") || selectedCategories.includes(result.dataset.category) ? "block" : "none";
            });
        });
    });
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