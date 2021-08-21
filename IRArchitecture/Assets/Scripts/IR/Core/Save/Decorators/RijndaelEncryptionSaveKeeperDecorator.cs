using IRCore.Encryption;

namespace IRCore.Save.Decorators
{
    class RijndaelEncryptionSaveKeeperDecorator : SaveKeeperDecorator
    {
        private readonly string _password;

        public RijndaelEncryptionSaveKeeperDecorator(string password, ISaveKeeper saveKeeper)
            : base(saveKeeper)
        {
            _password = password;
        }

        public override string Load(string key)
        {
            var encodedJson = base.Load(key);
            var json = RijndaelEncryption.Decrypt(encodedJson, _password);

            return json;
        }
        public override void Save(string key, string content)
        {
            var encodedValue = RijndaelEncryption.Encrypt(content, _password);
            base.Save(key, encodedValue);
        }
    }
}