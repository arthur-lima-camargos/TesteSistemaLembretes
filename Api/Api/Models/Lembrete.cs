namespace Api.Models
{
    public class Lembrete
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public Lembrete(string name, string date)
        {
            this.Id = new Guid().ToString();
            this.Name = name;
            this.Date = date;
        }
    }
}
