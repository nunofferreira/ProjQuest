//Extension Methods:

//1. Class must be static
//2. Method must be static
//3. Use "this" on the input parameter

using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Allows serialising any object using the native dotnet serialiser or the newtonsofta
/// </summary>
public static class SerializerExtensions
{
    public static string ToJson(this object obj, SerializerType type = SerializerType.DotnetNative)
    //using lambda and ternary
    => (type == SerializerType.Newtonsoft)
        ? JsonConvert.SerializeObject(obj)
        : System.Text.Json.JsonSerializer.Serialize(obj);

    //{
    //    if (type == SerializerType.Newtonsoft)
    //        return JsonConvert.SerializeObject(obj);
    //    else
    //        return System.Text.Json.JsonSerializer.Serialize(obj);
    //}

    public static object? FromJson(this string json, object obj)
    {
        return System.Text.Json.JsonSerializer.Deserialize(json, obj.GetType());

        // => (type == SerializerType.Newtonsoft)
        //? JsonConvert.SerializeObject(obj)
        //: System.Text.Json.JsonSerializer.Serialize(obj);
    }
}


