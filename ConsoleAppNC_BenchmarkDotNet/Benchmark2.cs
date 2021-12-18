using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ConsoleAppNC_BenchmarkDotNet
{
  class MyObjectBase
  {
    public int INT { get; set; }
    public long LONG { get; set; }
    public double DOUBLE { get; set; }
    public string STRING { get; set; }
    public DateTime DATETIME { get; set; }
    public DateTimeOffset DATETIMEOFFSET { get; set; }
  }

  class MyObject : MyObjectBase
  {
    public List<MyObjectBase> MYLIST { get; set; }
  }

  public static class ExpandoHelper
  {
    public static ExpandoObject ToExpando<T>(this T obj) where T : class
    {
      IDictionary<string, object> expando = new ExpandoObject();
      foreach (var propertyInfo in typeof(T).GetProperties())
        expando.Add(propertyInfo.Name, propertyInfo.GetValue(obj));

      return expando as ExpandoObject;
    }
  }

  [MemoryDiagnoser]
  public class Benchmark2
  {
    private readonly ExpandoObject Data;
    public Benchmark2()
    {
      dynamic data = new ExpandoObject();

      data.INT = (int)12345;
      data.LONG = (long)9999999999999999;
      data.DOUBLE = (double)2.45678;
      data.STRING = "string base 1";
      data.DATETIME = DateTime.Parse("2021-12-18T06:07:55.602Z");
      data.DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T06:07:55.602Z");

      data.MYLIST1 = new List<int> { 1, 2, 3, 4 };

      data.MYOBJECT = new MyObjectBase { INT = 98765, LONG = 7777777777777777, DOUBLE = 33.45678, STRING = "string base 2", DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), }.ToExpando();

      data.MYLIST2 = new List<ExpandoObject>
      {
        new MyObjectBase { INT = 98765, LONG = 7777777777777777, DOUBLE = 33.45678, STRING = "string base 2", DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), }.ToExpando(),
        new MyObjectBase { INT = 12345, LONG = 8888888888888888, DOUBLE = 99.45678, STRING = "string base 3", DATETIME = DateTime.Parse("2021-12-18T04:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T08:07:55.602Z"), }.ToExpando(),
      };

      Data = data;
    }

    /*public void Check()
    {
      Console.WriteLine(Newtonsoft_Json_JsonConvert_SerializeObject());
      Console.WriteLine("all done");
      Console.WriteLine(System_Text_Json());
      Console.WriteLine("all done");
      Console.WriteLine(Utf8Json_JsonSerializer_ToJsonString());
      Console.WriteLine("all done");
      Console.WriteLine(System.Text.Encoding.Default.GetString(Utf8Json_JsonSerializer_Serialize()));
      Console.WriteLine("all done");
    }*/

    [Benchmark]
    public string Newtonsoft_Json_JsonConvert_SerializeObject() => Newtonsoft.Json.JsonConvert.SerializeObject(Data);

    [Benchmark]
    public string System_Text_Json() => System.Text.Json.JsonSerializer.Serialize(Data);

    [Benchmark]
    public string Utf8Json_JsonSerializer_ToJsonString() => Utf8Json.JsonSerializer.ToJsonString(Data);

    [Benchmark]
    public byte[] Utf8Json_JsonSerializer_Serialize() => Utf8Json.JsonSerializer.Serialize(Data);
  }
}
