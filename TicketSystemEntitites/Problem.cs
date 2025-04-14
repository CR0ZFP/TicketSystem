namespace TicketSystem.Entitites
{
    public class Problem
    {
        string Id { get; set; }
        string UserId { get; set; }
        DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
