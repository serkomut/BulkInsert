# Rescop.BulkInsert
How does it work?
``` csharp
var datas = new List<YourModel>();
for (int i = 0; i < 1000000; i++)
{
    datas.Add(new YourModel
    {
        Id = Guid.NewGuid(),
        Name = "Name",
        Description = "Description",
        Date = DateTime.Now
    });
}

string connectionString = "Your ConnectionString";
var bulkRepostory = new BulkRepostory(new SqlConnection(connectionString));

await bulkRepostory.BuklInsert<YourModel>(datas);
```

``` csharp
public class YourModel
{
    [Field()]
    public Guid Id {get; set;}

    [Field("Definition")]
    public string Name {get; set;}

    public string Description {get; set;}

    [Field("CreateDate")]
    public DateTime Date {get; set;}
}
```