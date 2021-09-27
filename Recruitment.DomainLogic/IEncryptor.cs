namespace Recruitment.DomainLogic
{
    public interface IEncryptor
    {
        string Encrypt(string source);
    }
}