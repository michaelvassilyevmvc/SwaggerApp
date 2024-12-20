using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwaggerApp.Models
{
    public class Person
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть длиной от 2 до 50 символов.")]
        [RegularExpression("^[A-Za-zА-Яа-яЁё]+$", ErrorMessage = "Имя может содержать только буквы.")]
        public string FirstName { get; set; } = String.Empty;

        ///<summary>
        /// Фамилия.
        /// </summary>
        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ("Фамилия должна быть длиной от 2 до 50 символов."))]
        [RegularExpression("^[A-Za-zА-Яа-яЁё]+$", ErrorMessage = "Фамилия может содержать только буквы")]
        public string LastName { get; set; } = String.Empty;

        ///<summary>
        /// Отчество.
        /// </summary>
        /// 
        [StringLength(50,ErrorMessage ="Отчество не должно превышать 50 символов.")]
        [RegularExpression("^[A-Za-zА-Яа-яЁЁ]+$", ErrorMessage = "Отчество может содержать только буквы")]
        public string MiddleName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Дата рождения обязательна для заполнения")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Person), nameof(ValidateBirthDate))]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        /// 
        [Required(ErrorMessage = "Пол обязателен для заполнения")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        [Required(ErrorMessage = "Электронная почта обязательна для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат адреса электронной поты")]
        [StringLength(100, ErrorMessage = "Электронная почта не должна превышат 100 символов")]
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// Адрес проживания 
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "Адрес не должен превышать 200 символов")]
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// Дата регистрации
        /// </summary>
        /// 
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        [Required(ErrorMessage = "Номер паспорта обязателен для заполнения")]
        [RegularExpression(@"^[0-9]{4}\s[0-9]{6}$",ErrorMessage ="Номер паспорта должен быть в формате XXXX XXXXXX.")]
        public string PassportNumber { get; set; } = String.Empty;

        /// <summary>
        /// Номер водительского удоствоверения
        /// </summary>
        [RegularExpression("^[A-Z0-9]{1,20}$", ErrorMessage = "Номер водительского удостовирения может содержат только буквы и цифры.")]
        [StringLength(20, ErrorMessage = "Номер водительского удостоверения не должен превышать 20 симвлов.")]
        public string DriverLicenseNumber { get; set; } = String.Empty;

        [RegularExpression(@"^(19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])\d{6}$")]
        [StringLength(14, MinimumLength = 14, ErrorMessage ="ИИН должен содержать 14 символов")]
        public string IIN { get; set; } = String.Empty;


        /// <summary>
        /// Проверка корректности даты рождения
        /// </summary>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="context">Контекст</param>
        /// <returns>Результат валидации</returns>
        public static ValidationResult ValidateBirthDate(DateTime birthDate, ValidationContext context)
        {
            if (birthDate > DateTime.Now.AddYears(-18))
            {
                return new ValidationResult("Должен быть старше 18 лет.");
            }
            return ValidationResult.Success;
        }
    }
}
