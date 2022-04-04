namespace Telephony
{
    public interface IBrowsing
    {
        public string WebSite { get; set; }
        public void Browsing(string website);
    }
}