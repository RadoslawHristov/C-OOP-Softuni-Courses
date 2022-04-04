namespace Telephony
{
    public interface ICall
    {
        public string PhoneNumber { get; set; }
        public void Calling(string number);
    }
}