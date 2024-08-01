namespace EmployeeManagement.ViewModels
{
    public class RoleEditViewModel : RoleCreateViewModel
    {
        public RoleEditViewModel()
        {
            User = new List<string>();
        }
        public string Id { get; set; }
        public List<string> User { get; set; }
    }
}
