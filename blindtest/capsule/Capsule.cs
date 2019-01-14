using Newtonsoft.Json;

namespace BlindTest.capsule
{
    class Capsule
    {
        public static Capsule FromString(string str)
        {
            return JsonConvert.DeserializeObject<Capsule>(str);
        }

        public string Head { get; set; }
        public string[] Data { get; set; }

        public Capsule()
        {
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this).Replace('\n', ' ');
        }
    }
}
