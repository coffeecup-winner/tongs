Tongs is a data wrangling library for quick and dirty data analysis.

Tongs is designed to be used in a LINQPad or any other C# code execution environment.

Example - Searching for keywords in files:

```csharp
using Tongs;

Cube.Create(
    Get.Files("<tongs-root>", "*.cs"),
    new[] { "where", "readonly" },
    (f, w) => f.Contains(w)) // not tokenized, just a substring

    .Print("Keywords by file:")
    .PrintDump()

    .Transpose()

    .Print("Files by keyword:")
    .PrintDump();
```

will output something like

```
Keywords by file:
<tongs-root>\src\Tongs\ConsoleOutputExtensions.cs
    where
<tongs-root>\src\Tongs\Option.cs
    readonly
<tongs-root>\src\Tongs\DataSource\FileDataSource.cs
    readonly
<tongs-root>\src\Tongs\DataSource\StringDataSource.cs
    readonly
<tongs-root>\src\Tongs\Storage\NCube.cs
    readonly

Files by keyword:
where
    <tongs-root>\src\Tongs\ConsoleOutputExtensions.cs
readonly
    <tongs-root>\src\Tongs\Option.cs
    <tongs-root>\src\Tongs\DataSource\FileDataSource.cs
    <tongs-root>\src\Tongs\DataSource\StringDataSource.cs
    <tongs-root>\src\Tongs\Storage\NCube.cs
```
