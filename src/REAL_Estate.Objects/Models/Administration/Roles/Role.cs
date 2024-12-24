using Microsoft.EntityFrameworkCore;

namespace REAL_Estate.Objects;

[Index(nameof(Title), IsUnique = true)]
public class Role : AModel
{
    [StringLength(128)]
    public String Title { get; set; }

    public virtual List<Account> Accounts { get; set; }
    public virtual List<RolePermission> Permissions { get; set; }
}