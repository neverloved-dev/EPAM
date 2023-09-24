using System.Runtime.Serialization;

namespace Task2
{
    [Serializable]
    public class GiganticClass : ISerializable
    {
        public string GiganticName { get; set; }
        public ulong MyDreamMoney { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", GiganticName);
            info.AddValue("Money", MyDreamMoney);
        }

        public static void SerializeData()
        {

        }

        public static void DeserializeObject()
        {

        }    

    }

    public class Program
    {
        public static void Main() 
        {

        }

    }

}