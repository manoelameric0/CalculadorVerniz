self.addEventListener("install", function(event){
    event.waitUntil(
        caches.open(CACHE_NAME).then(function (cache){
            return cache.addAll(urlsToCache);
        })
    )
});

self.addEventListener("activate", function (event){
    event.waitUntil(
        caches.keys().then(function (cacheNames){
            return Promise.all(
                cacheNames.map(function (cacheNames){
                    if (cacheNames !== CACHE_NAME) {
                        return caches.delete(cacheNames);
                    }
                })
            )
        })
    )
})

self.addEventListener("fetch", function (event){
    event.respondWith(
        caches.match(event.request).then(function (response){
            return response || fetch(event.request);
        })
    );
});

const CACHE_NAME = "verniz-cache-v5";
const urlsToCache = [
    "/",
    "/index.html",
    "style.css",
    "/script.js",
    "/manifest.json",
    "/verniz-service.js"
];