namespace Core.Entities.IdentityEntities
{
    public class IdentityCode
    {
        public int Id { get; set; }
        public string AppUserEmail { get; set; }
        public AppUser User { get; set; }
        public string Code { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool IsRegistered { get; set; }
        public DateTime? ActivationTime { get; set; }
    }
}