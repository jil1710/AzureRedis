

<img src="https://github.com/jil1710/AzureRedis/assets/125335932/83decc43-eb16-492d-be08-5c5bdade779d" alt="drawing" width="220" height="100"/> 

# Azure Redis Cache

-  Azure Cache for Redis is secure in-memory cache for data storage and retrieval. It's fully managed, and you can use it to build high-performance applications that have scalable architectures. You can take advantage of Azure Cache for Redis to handle massive volumes of requests per second.

-  The cache is the memory storage that is used to store the frequent access data into the temporary storage, it will improve the performance drastically and avoid unnecessary database hit and store frequently used data into the cache.

    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/19813832-eabb-42b6-8e1b-3c8de1602d6a)


## Types of Cache
    
Basically, there are two types of caching .NET Core supports

- **In-Memory Caching**
- **Distributed Caching**
    
When we use In-Memory Cache, data is stored in the application server memory; whenever we need it, we fetch data from that and use it wherever we need it. And in Distributed Caching there are many third-party mechanisms like Redis and many others. But in this section, we look into the Redis Cache in detail and how it works in the .NET Core

## Redis cache 

Redis is an in-memory database that stores data in the server memory and a popular tool to cache data.


- **Redis Cache Features :**
    - Increases application performance
    - Increases availability (Geo-Replication)
    - Provides in-memory data
    - Fully managed by Azure and based on the open-source Data Backups
    - Stores data in - Strings (max 521 MB), Hashes (unordered), Lists (ordered by sequence), and Sets (only unique values)

## Let's implement Azure Redis with an examples

- **Step 1 :** 
    
    Create Azure redis service in Azure portal and click on the access key menu to get the connection string after that mark down the primary connection string.
    - [click to start with azure redis cache](https://azure.microsoft.com/en-in/get-started/azure-portal)

- **Step 2 :**

    Download the below nuget package in order to start with azure redis cache.

    ```
    StackExchange.Redis
    ```

    ```
    Microsoft.Extensions.Caching.StackExchange
    ```

- **Step 3 :**

    Now configure the service to use the redis cache in `program.cs` or `startup.cs`

    ```json
      "ConnectionStrings": {
          "AzureRedisCache": "[YOUR-REDIS-CACHE-CONNECTION-STRING]"
      }
    ```
    
    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/6912f38d-a38a-4f66-bfb0-9fe3e0ab484f)


- **Step 4 :**

    Using `IDistributedCache` interface pertaining to the `Microsoft.Extensions.Caching.Distributed` namespace represents a distributed cache. To manipulate the data stored in the distributed cache, you can use the following methods:

    - **Get or GetAsync :** To retrieve items from the distributed cache based on its key.
    - **Set or SetAsync :** To store items into the distributed cache.
    - **Refresh or RefreshAsync :** To refresh an item in the distributed cache.
    - **Remove or RemoveAsync :** To delete an item from the distributed cache based on its key.

- Here I performed simple example in which, I fetch the product data from external service api so instead of calling the service again an again we cache the data into azure redis that helps to improve the perfomance.

    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/b83fc459-e9d1-4d12-9e98-fb7778ba3d74)

    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/7b79c92a-660d-40bf-8124-d6c16121b5ca)

    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/0173ab7f-932d-4e7c-b1af-f560a9ebed48)

    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/28d0892f-7caf-4643-8c2c-88808a465a3c)

- After saving the data into azure redis cache
  
    ![image](https://github.com/jil1710/AzureRedis/assets/125335932/41a9deb1-d67d-4d70-91ac-30ea6910cf11)



  - [click here to see demo](https://github.com/jil1710/AzureRedis/tree/master/AzureRedis)







    







