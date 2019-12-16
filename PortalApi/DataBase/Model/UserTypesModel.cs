using PortalApi.DTO.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalApi.DataBase.Model
{
    [Table("UserTypes")]
    public class UserTypesModel
    {
        /// <summary>
        /// UserType id.
        /// </summary>
        [Key]
        [Column("UserTypeId")]
        public int UserTypeId { get; set; }

        /// <summary>
        /// Enum with the types of users.
        /// </summary>
        [Column("Type")]
        public UserTypes Type { get; set; }

    }
}
