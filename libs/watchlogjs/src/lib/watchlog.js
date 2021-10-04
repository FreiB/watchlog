function watchlog() {
  var serviceUrl = document.currentScript.getAttribute('data-service-url');
  if (!serviceUrl) {
    throw 'WATCHLOG: Missing data-service-url attribute on script tag!';
  }
  var collectInterval =
    Number(document.currentScript.getAttribute('data-collect-interval')) ||
    3000;
  var collectDelay =
    Number(document.currentScript.getAttribute('data-collect-delay')) || 5000;
  var collectLimit =
    Number(document.currentScript.getAttribute('data-collect-limit')) || 5;

  var watchlog_collector = {
    serviceUrl,
    collectInterval,
    collectDelay,
    collectLimit,
    collection: [],
  };

  window.watchlog_collector = watchlog_collector;

  window.addEventListener('load', (e) => {
    setTimeout(function () {
      initSession().then(() => {
        //collection = getPerformanceEntries().map((en) => collect(en));
        postCollectionRepeating();
      });
    }, collectDelay);
  });

  var perfObserver = new PerformanceObserver(function (list, obj) {
    // Get all the resource entries collected so far
    // (You can also use getEntriesByType/getEntriesByName here)
    watchlog_collector.collection = [
      ...watchlog_collector.collection,
      ...list
        .getEntries()
        .filter(filterEntries)
        .map((en) => collect(en)),
    ];
  });

  perfObserver.observe({
    // Polls for Navigation and Resource Timing entries
    entryTypes: ['navigation', 'resource', 'paint', 'measure'],
  });

  function filterEntries(entry) {
    if (entry.name.includes(serviceUrl)) {
      return false;
    }

    if (entry.entryType === 'measure' && entry.name.slice(0, 3) !== 'wl_') {
      return false;
    }

    return true;
  }

  function initSession() {
    return fetch(serviceUrl + '/session', {
      method: 'GET',
      mode: 'cors',
      cache: 'no-cache',
      credentials: 'include',
    });
  }

  function getPerformanceEntries(list) {
    return [
      ...performance.getEntriesByType('navigation'),
      ...performance.getEntriesByType('resource'),
      ...performance.getEntriesByType('paint'),
    ];
  }

  function postCollectionRepeating() {
    setTimeout(function () {
      postCollection();
      postCollectionRepeating();
    }, collectInterval);
  }

  function postCollection() {
    if (watchlog_collector.collection.length > 0) {
      var itemsToSend = watchlog_collector.collection.splice(0, collectLimit);
      fetch(serviceUrl + '/collect', {
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'include',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ collection: itemsToSend }),
      }).then(console.log('js collected'));
    }
  }

  function collect(entry) {
    var collectable = createCollectable('perf-' + entry.entryType, entry);
    return collectable;
  }

  function createCollectable(type, message) {
    return {
      type: type,
      timestamp: Date.now(),
      route: window.location.href.split('?')[0],
      message: message,
    };
  }
}
watchlog();
