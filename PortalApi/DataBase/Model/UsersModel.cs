using PortalApi.DTO.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalApi.DataBase.Model
{
    [Table("Users")]
    public class UsersModel
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [Key]
        [Column("UsersId")]
        public int UserId { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Username of the user.
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }

        /// <summary>
        /// ForeingKey to know the type of user.
        /// </summary>
        [ForeignKey("UserTypesModel")]
        [Column("UserTypeId")]
        public int UserTypeId { get; set; }
        public UserTypesModel UserType { get; set; }
        public ICollection<CandidatesModel> Candidates { get; set; }

    }
}
