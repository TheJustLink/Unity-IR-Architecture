using System;
using System.Text;

namespace IRCore.Save.Decorators
{
    class Base64SaveKeeperDecorator : SaveKeeperDecorator
    {
        public Base64SaveKeeperDecorator(ISaveKeeper saveKeeper)
            : base(saveKeeper) { }

        public override string Load(string key)
        {
            var encodedJson = base.Load(key);
            var rawJson = Convert.FromBase64String(encodedJson);
            var json = Encoding.UTF8.GetString(rawJson);

            return json;
        }
        public override void Save(string key, string content)
        {
            var encodedValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(content));
            base.Save(key, encodedValue);
        }
    }
}