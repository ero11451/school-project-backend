// Model for creating a new user
public class CreateUserModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

// Model for updating a user
public class UpdateUserModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
}
