# LinqPager

LinqPager is a simple pagination and sorting utility for LINQ queries in C#. It allows easy pagination and sorting functionality for IEnumerable and IQueryable collections.

## Features

- **Pagination:** Enables paginating results from IQueryable and IEnumerable collections.
- **Sorting:** Sorts collections based on specified fields in ascending or descending order.
- **IPagination Interface:** Supports pagination using an `IPagination` interface for request models.
- **EF Core Compatibility:** Compatible with Entity Framework Core for database queries.

## Usage

### Installation

To use LinqPager in your project, you can install it via NuGet Package Manager:

`dotnet add package LinqPager`

[![NuGet](https://img.shields.io/nuget/v/LinqPager)](https://www.nuget.org/packages/LinqPager/)

### Getting Started

1. **Using Pagination:**

```csharp
using LinqPager.Project.Models;
using LinqPager.Project;

// Example usage with IQueryable<T>
var query = yourQueryableData.ToPagination(pageNumber, pageSize, "FieldName", "asc");

// Example usage with IEnumerable<T>
var collection = yourEnumerableData.ToPagination(pageNumber, pageSize, "FieldName", "desc");
```
### Using IPagination Interface

To simplify pagination with request models, you can implement the `IPagination` interface. Here is an example of how to use it:

#### Define Your Pagination Request Model

```csharp
public class YourPaginationRequestModel : IPagination
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; }
    public string SortType { get; set; }
}
```
Usage:
```csharp
using LinqPager.Project.Models;
using LinqPager.Project;

// Create an instance of your pagination request model
var request = new YourPaginationRequestModel
{
    Page = 1,
    PageSize = 10,
    SortBy = "FieldName",
    SortType = "asc"
};

// Use ToPagination with your request model
var result = yourQueryableData.ToPagination(request);
```
