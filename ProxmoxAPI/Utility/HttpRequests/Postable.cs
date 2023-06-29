namespace ProxmoxAPI.Utility.HttpRequests
{
    public interface Postable
    {
        public FormUrlEncodedContent FormContent();
    }
}
