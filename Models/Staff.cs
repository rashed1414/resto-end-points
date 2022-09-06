namespace ResturantEndPoints.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public double? Salary { get; set; }
        
        public Role role  { get; set; }
    }
}
