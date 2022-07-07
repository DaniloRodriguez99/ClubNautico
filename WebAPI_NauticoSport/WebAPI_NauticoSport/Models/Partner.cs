namespace WebAPI_NauticoSport.Models
{
    public class Partner
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public int PartnerId { get; set; }
        public int Type { get; set; }
        public string PerfilPicture { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public int SexId { get; set; }
    }
}
