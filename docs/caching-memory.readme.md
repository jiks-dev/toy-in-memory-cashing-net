# caching-memory.readme

## Package 
* https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory/


## Official Docs
* https://docs.microsoft.com/ko-kr/aspnet/core/performance/caching/memory?view=aspnetcore-6.0

## Thread Safe?

https://stackoverflow.com/questions/20149796/memorycache-thread-safety-is-locking-necessary

The default MS-provided MemoryCache is entirely thread safe.
Any custom implementation that derives from MemoryCache may not be thread safe.
If you're using plain MemoryCache out of the box, it is thread safe. 
Browse the source code of my open source distributed caching solution to see how I use it (MemCache.cs):