# ZVJson Library Documentation

The ZVJson library is a versatile utility that simplifies JSON serialization and deserialization, HTTP requests, and image loading in Unity projects. This comprehensive documentation provides a guide on how to effectively integrate and use the ZVJson library within your Unity applications.

## Table of Contents

1. [Introduction](#introduction)
2. [Installation](#installation)
3. [JSON Serialization and Deserialization](#json-serialization-and-deserialization)
4. [HTTP Requests](#http-requests)
5. [Loading Images from URLs](#loading-images-from-urls)
6. [Examples](#examples)
   - [Combining GET Request and FromJson](#combining-get-request-and-fromjson)
   - [Creating a Type Matching JSON Data](#creating-a-type-matching-json-data)
7. [Error Handling and Status Codes](#error-handling-and-status-codes)
8. [Understanding useJsonFixer](#understanding-usejsonfixer)

## 1. Introduction <a name="introduction"></a>

The ZVJson library is designed to simplify common tasks related to JSON handling, HTTP requests, and image loading in Unity projects. Its set of utility methods allows developers to focus on the core logic of their applications while seamlessly integrating data manipulation and network communication.

## 2. Installation <a name="installation"></a>

To integrate the ZVJson library into your Unity project:

1. Download the provided `ZVJson.cs` file.
2. Place the downloaded `ZVJson.cs` file into a designated folder within your Unity project, such as `Assets/Scripts`.
3. Unity will automatically include and compile the library as part of your project.

## 3. JSON Serialization and Deserialization <a name="json-serialization-and-deserialization"></a>

The ZVJson library provides methods to facilitate JSON serialization and deserialization. These methods are particularly useful when working with JSON data from APIs or other sources.

### Deserializing JSON

```csharp
// Deserialize JSON data into an array of objects
YourObjectType[] objects = ZVJson.FromJson<YourObjectType>(jsonString, useJsonFixer);
```

### Serializing JSON

```csharp
// Serialize an array of objects into a JSON string
string jsonString = ZVJson.ToJson(objects);
```

## 4. HTTP Requests <a name="http-requests"></a>

The ZVJson library simplifies making HTTP GET requests and handling the responses.

### Sending a GET Request

```csharp
ZVJson.GetRequest(url, (statusCode, response) =>
{
    if (statusCode == 4)
    {
        // Process the response data
    }
    else
    {
        // Handle the error
        HandleError(statusCode);
    }
});
```

## 5. Loading Images from URLs <a name="loading-images-from-urls"></a>

The ZVJson library includes features to efficiently load images from URLs and convert them into Unity sprites.

```csharp
ZVJson.GetImageFromUrl(imageUrl, (statusCode, sprite) =>
{
    if (statusCode == 4)
    {
        // Use the loaded sprite
    }
    else
    {
        // Handle the error
        HandleError(statusCode);
    }
});
```

## 6. Examples <a name="examples"></a>

### Combining GET Request and FromJson <a name="combining-get-request-and-fromjson"></a>

Assuming you're working with a JSON API that provides data about books:

```csharp
// Load and process books from a JSON API
StartCoroutine(ZVJson.GetRequest(apiUrl, (statusCode, response) =>
{
    if (statusCode == 4)
    {
        BookData[] books = ZVJson.FromJson<BookData>(response, true);
        foreach (BookData book in books)
        {
            Debug.Log($"Title: {book.title}, Author: {book.author}, Page Count: {book.pageCount}");
        }
    }
    else
    {
        // Handle the error
        HandleError(statusCode);
    }
}));
```

### Creating a Type Matching JSON Data <a name="creating-a-type-matching-json-data"></a>

Create a C# class that matches the JSON data structure:

```csharp
[System.Serializable]
public class BookData
{
    public string title;
    public string author;
    public int pageCount;
}
```

By creating a matching class, you can easily deserialize JSON data into instances of this class.

## 7. Error Handling and Status Codes <a name="error-handling-and-status-codes"></a>

The ZVJson library provides status codes to help you understand the result of your operations:

- **Status Code 1**: Connection Error
- **Status Code 2**: Data Processing Error
- **Status Code 3**: Protocol Error
- **Status Code 4**: Success

You can use these status codes to handle errors and unexpected behaviors gracefully in your application.

## 8. Understanding useJsonFixer <a name="understanding-usejsonfixer"></a>

The `useJsonFixer` parameter in the `FromJson` method is used to handle a common issue when deserializing JSON arrays with a single root object. When set to `true`, the library automatically adds a wrapper object to the JSON string before deserialization, ensuring proper parsing of the JSON array.

- `useJsonFixer = true`: The library adds a wrapper object to the JSON before deserialization.
- `useJsonFixer = false`: The JSON is assumed to have a valid structure, and no additional modification is made.

Use `useJsonFixer` as needed based on the JSON structure you are working with.

## Conclusion

The ZVJson library streamlines JSON handling, HTTP requests, and image loading tasks in Unity projects. By following this documentation, you're well-equipped to integrate and leverage the ZVJson library to enhance your Unity application's functionality. For additional guidance or troubleshooting, refer back to this documentation or consult the Unity community.
