namespace Wassandashboard.Data.Models.Odk
{
    public class OdkResponse<T>
    {
        public T[] value { get; set; }
        public string odatacontext { get; set; }
        public string odatanextLink { get; set; }
    }


}
