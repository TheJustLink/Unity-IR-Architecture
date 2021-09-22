using IR.Encryption;

namespace IR.Save.Decorators
{
    public class RijndaelEncryptionSaveKeeperDecorator : SaveKeeperDecorator
    {
        private readonly RijndaelEncryption _encryption;

        public RijndaelEncryptionSaveKeeperDecorator(ISaveKeeper saveKeeper, string password)
            : base(saveKeeper)
        {
            _encryption = new RijndaelEncryption(password);
        }

        public override string Load(string key)
        {
            var encodedJson = base.Load(key);
            var json = _encryption.Decrypt(encodedJson);

            return json;
        }
        public override void Save(string key, string content)
        {
            var encodedValue = _encryption.Encrypt(content);
            base.Save(key, encodedValue);
        }
    }
}