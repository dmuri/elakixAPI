namespace elakixAPI.Models
{
    public class TestPersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Numbers { get; set; } = new List<string>();

    }
}
